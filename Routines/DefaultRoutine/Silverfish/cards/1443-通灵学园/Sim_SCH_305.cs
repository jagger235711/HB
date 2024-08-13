using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_SCH_305 : SimTemplate //* 秘密通道 Secret Passage
    {
        //Replace your hand with 4 cards from your deck. Swap back next turn.
        //将你的手牌替换为你牌库中的4张牌。下回合换回。

        // 当这张卡牌被使用时，调用 onCardPlay 方法
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            // 将当前手牌暂存
            p.moveHandToTemporaryDeck(ownplay);

            // 从牌库中抽取4张牌替换手牌
            for (int i = 0; i < 4; i++)
            {
                p.drawACard(CardDB.cardNameEN.unknown, ownplay);
            }
        }

        // 在回合结束时触发该方法，用于将手牌换回原来的卡牌
        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (turnEndOfOwner == triggerEffectMinion.own)
            {
                // 将暂存区的手牌与当前手牌交换
                p.restoreTemporaryDeckToHand(turnEndOfOwner);
            }
        }
    }
}
