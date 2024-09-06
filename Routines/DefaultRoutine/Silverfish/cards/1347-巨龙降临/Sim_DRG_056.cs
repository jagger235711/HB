using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	//随从 中立 费用：2 攻击力：2 生命值：2
	//Parachute Brigand
	//空降歹徒
	//[x]After you play a Pirate,summon this minionfrom your hand.
	//在你使用一张海盗牌后，从你的手牌中召唤本随从。
	class Sim_DRG_056 : SimTemplate
	{
        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            // 如果打出的卡牌是海盗
            if (hc.card.race == CardDB.Race.PIRATE)
            {
                List<Handmanager.Handcard> tmp = p.owncards;
                for (int i = 0; i < p.owncards.Count; i++)
                {
                    Handmanager.Handcard handcard = tmp[i];
                    // 如果手牌中有“空降歹徒”且场上随从数小于7
                    if (handcard.card.cardIDenum == CardDB.cardIDEnum.DRG_056 && p.ownMinions.Count < 7)
                    {
                        p.callKid(handcard.card, p.ownMinions.Count, true);
                        p.removeCard(handcard);
                    }
                }
            }
        }
    }
}
