using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_REV_938 : SimTemplate //* 暗影之门 Door of Shadows
    {
        // 抽一张法术牌。注能（2）：将它的一张临时复制置入你的手牌。
        // Draw a spell. Infuse (2): Add a temporary copy of it to your hand.

        private const int INFUSE_REQUIREMENT = 2;

        public override void onCardInHand(Playfield p, Handmanager.Handcard hc, bool wasPlayed)
        {
            // 每当有随从死亡时，检查是否满足注能条件
            if (!wasPlayed && p.ownMinionsDiedThisGame >= INFUSE_REQUIREMENT)
            {
                // 如果满足注能条件，将卡牌变形为注能后的版本
                hc.setCard(CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.REV_938t));
            }
        }

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            // 抽一张法术牌
            CardDB.Card drawnCard = p.drawACard(CardDB.cardIDEnum.None, ownplay, true);

            // 如果是注能后的效果，并且抽到的牌是法术牌
            if (drawnCard.type == CardDB.cardtype.SPELL)
            {
                // 将该法术牌的临时复制加入玩家手牌
                Handmanager.Handcard tempCard = p.drawACard(drawnCard.cardIDenum, ownplay, true);
                if (tempCard != null)
                {
                    tempCard.isTemporary = true; // 这里假设有一个字段来标记卡牌为临时的
                }
            }
        }

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (turnEndOfOwner)
            {
                // 移除所有未使用的临时复制卡牌
                p.owncards.RemoveAll(card => card.isTemporary);
            }
        }
    }
}
