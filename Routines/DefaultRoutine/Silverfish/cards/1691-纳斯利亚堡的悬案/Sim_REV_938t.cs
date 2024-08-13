using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_REV_938t : SimTemplate //* 暗影之门 Door of Shadows（已注能）
    {
        // 已注能：抽一张法术牌，并将它的一张临时复制置入你的手牌。
        // Infused: Draw a spell. Add a temporary copy of it to your hand.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            // 抽一张法术牌
            CardDB.Card drawnCard = p.drawACard(CardDB.cardIDEnum.None, ownplay, true);

            // 确保抽到的牌是法术牌
            if (drawnCard != null && drawnCard.type == CardDB.cardtype.SPELL)
            {
                // 将该法术牌的临时复制加入玩家手牌
                Handmanager.Handcard tempCard = p.drawACard(drawnCard.cardIDenum, ownplay, true);

                // 标记这张卡牌为临时卡牌
                if (tempCard != null)
                {
                    tempCard.isTemporary = true; // 这里假设有一个字段来标记卡牌为临时的
                }
            }
        }

        // 在回合结束时，移除未使用的临时复制的牌
        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (turnEndOfOwner)
            {
                // 遍历玩家的手牌，移除所有标记为临时的卡牌
                p.owncards.RemoveAll(card => card.isTemporary);
            }
        }
    }
}
