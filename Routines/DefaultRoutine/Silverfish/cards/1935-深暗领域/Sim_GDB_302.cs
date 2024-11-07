using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	//随从 法师 费用：3 攻击力：3 生命值：1
	//Blazing Accretion
	//吸积炽焰
	//<b>Battlecry:</b> Destroy the top 3 cards of your deck. Any Fire spells or Elementals are drawn instead.
	//<b>战吼：</b>摧毁你牌库顶的3张牌，其中的火焰法术牌或元素牌会由摧毁改为抽取。
	class Sim_GDB_302 : SimTemplate
	{
        /*
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            int cardsToProcess = Math.Min(3, p.ownDeck.Count); // 如果牌库不足3张，就只处理现有的牌数

            for (int i = 0; i < cardsToProcess; i++)
            {
                Card topCard = p.ownDeck[0]; // 牌库顶的第一张牌

                if (topCard.isFireSpell || topCard.isElemental) // 检查是否为火焰法术或元素牌
                {
                    p.drawACard(topCard.cardIDenum, own.own, true); // 抽取该牌
                }
                else
                {
                    p.removeCardFromDeck(topCard); // 将该牌从牌库中摧毁
                }
            }
        }
        */
	}
}

