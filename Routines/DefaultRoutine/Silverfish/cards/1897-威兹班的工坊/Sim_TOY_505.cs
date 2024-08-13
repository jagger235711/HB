using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_TOY_505 : SimTemplate
    {
        // 玩具船 Toy Boat
        // 在你召唤一个海盗后，抽一张牌。
        // After you summon a Pirate, draw a card.

        public override void onMinionWasSummoned(Playfield p, Minion m, Minion summonedMinion)
        {
            // 判断是否是我方召唤的随从，并且该随从是海盗类型
            if (m.own && summonedMinion.handcard.card.race == TAG_RACE.PIRATE)
            {
                p.drawACard(CardDB.cardIDEnum.None, m.own); // 抽一张牌
            }
        }
        
        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            // 如果当前场上有玩具船，并且我们打出了一个海盗
            if (triggerEffectMinion != null && triggerEffectMinion.name == CardDB.cardName.ToyBoat && hc.card.race == TAG_RACE.PIRATE)
            {
                p.drawACard(CardDB.cardIDEnum.None, wasOwnCard); // 抽一张牌
            }
        }
    }
}