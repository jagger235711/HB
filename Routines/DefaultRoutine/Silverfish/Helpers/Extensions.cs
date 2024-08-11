using Buddy.Coroutines;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Triton.Game;
using Triton.Game.Mapping;

namespace HREngine.Bots
{
    static class Extensions
    {
        internal static async Task Trade(this HSCard card, int timeout = 500)
        {
            await card.Pickup(timeout);
            Stopwatch stopwatch = Stopwatch.StartNew();
            var canTrade = false;
            while (stopwatch.ElapsedMilliseconds < timeout)
            {
                if (ZoneMgr.Get() == null)
                {
                    await Coroutine.Sleep(50);
                }
                else
                {
                    canTrade = true;
                    break;
                }
            }
            if (!canTrade)
                return;
            Collider collider = Board.Get().FindCollider("TradeArea");
            var center = collider.Bounds.m_Center;
            await Client.MoveCursorHumanLike(center);
            await Coroutine.Sleep(1);
            Client.LeftClickAt(center);
        }

        internal static ConstructorInfo hsCardCtor = typeof(HSCard).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance,
            null, new Type[] { typeof(Entity) }, null);
        static PerFrameCachedValue<Dictionary<int, HSCard>> cachedCardsDict;
        static int maxEntityId = 100;
        internal static Dictionary<int, HSCard> AllCardsDict
        {
            get
            {
                if (cachedCardsDict == null)
                {
                    cachedCardsDict = new PerFrameCachedValue<Dictionary<int, HSCard>>(() =>
                    {
                        var dict = new Dictionary<int, HSCard>();
                        var id = 0;
                        var paramArr = new object[1];
                        while (id++ < maxEntityId)
                        {
                            var e = TritonHs.GameState.GetEntity(id);
                            if (e != null)
                            {
                                paramArr[0] = e;
                                dict[id] = (HSCard)hsCardCtor.Invoke(paramArr);
                                maxEntityId = Math.Max(id + 30, maxEntityId);
                            }
                        }
                        return dict;
                    });
                }
                return cachedCardsDict;
            }
        }

        internal static List<HSCard> GetAllCards()
        {
            return AllCardsDict.Values.ToList();
        }
        /// <summary>
        /// 每局游戏新开时重置初始的最大ID
        /// </summary>
        internal static void ResetMaxId()
        {
            maxEntityId = 100;
        }
    }
}
