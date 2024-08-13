using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    // 随从 中立 费用：1 攻击力：1 生命值：1
    // Patches the Pirate
    // 海盗帕奇斯
    // [x]After you play a Pirate, summon this minion from your deck.
    // 在你使用一张海盗牌后，从你的牌库中召唤本随从。
    class Sim_CFM_637 : SimTemplate
    {
        // 当玩家使用一张海盗牌时，触发该方法
        public override void onMinionWasSummoned(Playfield p, Minion m, Minion summonedMinion)
        {
            // 检查是否是己方随从，且被召唤的随从是海盗
            if (m.own && summonedMinion.handcard.card.race == TAG_RACE.PIRATE)
            {
                // 检查牌库中是否有“海盗帕奇斯”
                if (p.ownDeckSize > 0 && p.hasCardInDeck(CardDB.cardIDEnum.CFM_637))
                {
                    // 找到“海盗帕奇斯”并将其从牌库中移除
                    p.removeCardFromDeck(CardDB.cardIDEnum.CFM_637);

                    // 从牌库中召唤“海盗帕奇斯”
                    p.callKid(CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_637), m.zonepos, m.own);
                }
            }
        }
    }
}
