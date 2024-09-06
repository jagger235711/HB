using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	//随从 中立 费用：1 攻击力：1 生命值：1
	//Patches the Pirate
	//海盗帕奇斯
	//[x]After you play a Pirate,summon this minionfrom your deck.
	//在你使用一张海盗牌后，从你的牌库中召唤本随从。
	class Sim_CFM_637 : SimTemplate
	{
        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            // 检查是否是玩家自己的卡牌以及是否为海盗
            if (wasOwnCard && (TAG_RACE)hc.card.race == TAG_RACE.PIRATE)
            {
                // 检查玩家牌库中是否有“海盗帕奇斯”
                if (p.ownDeckSize > 0)
                {
                    // 遍历牌库中的卡牌
                    foreach (KeyValuePair<CardDB.cardIDEnum, int> entry in p.prozis.turnDeck)
                    {
                        // 如果找到“海盗帕奇斯”并且它在牌库中存在
                        if (entry.Key == CardDB.cardIDEnum.CFM_637 && entry.Value > 0)
                        {
                            // 召唤“海盗帕奇斯”
                            p.callKid(CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_637), p.ownMinions.Count, true);

                            // 从牌库中移除“海盗帕奇斯”
                            p.prozis.turnDeck[CardDB.cardIDEnum.CFM_637]--;

                            // 如果找到并召唤后，不再继续检查其他牌
                            break;
                        }
                    }
                }
            }
        }
    }
}
