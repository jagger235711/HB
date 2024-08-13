using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    // 随从 中立 费用：2 攻击力：2 生命值：2
    // Parachute Brigand
    // 空降歹徒
    // [x]After you play a Pirate, summon this minion from your hand.
    // 在你使用一张海盗牌后，从你的手牌中召唤本随从。
    class Sim_DRG_056 : SimTemplate
    {
        // 当玩家使用一张海盗牌时触发该方法
        public override void onMinionWasSummoned(Playfield p, Minion m, Minion summonedMinion)
        {
            // 检查被召唤的随从是否是海盗，且是己方随从
            if (m.own && summonedMinion.handcard.card.race == TAG_RACE.PIRATE)
            {
                // 检查手牌中是否有“空降歹徒”
                foreach (Handmanager.Handcard hc in p.owncards.ToArray())
                {
                    if (hc.card.cardIDenum == CardDB.cardIDEnum.DRG_056)
                    {
                        // 将“空降歹徒”从手牌中移除，并召唤到战场
                        p.callKid(hc.card, m.zonepos, m.own);

                        // 将该手牌从玩家手牌中移除
                        p.removeCard(hc);
                        break; // 只召唤一张
                    }
                }
            }
        }
    }
}
