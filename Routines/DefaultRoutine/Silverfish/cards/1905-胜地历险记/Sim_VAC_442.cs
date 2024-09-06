using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_VAC_442 : SimTemplate // Light the Candle Elemental
    {
        // 假设有一个用于追踪连续使用元素牌回合数的字段
        private int consecutiveElementalTurns = 0;

        // <b>战吼：</b> 造成@点伤害<i>（每有一个你使用过元素牌的连续的回合，伤害都会提升）</i>。
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            // 计算伤害值，根据连续使用元素牌的回合数增加
            int dmg = 1 + consecutiveElementalTurns;

            // 对目标造成伤害
            p.minionGetDamageOrHeal(target, dmg);

            // 需要在合适的地方（例如在新的回合开始时）重置 consecutiveElementalTurns
        }

        public override PlayReq[] GetPlayReqs()
        {
            return new PlayReq[] {
                new PlayReq(CardDB.ErrorType2.REQ_NONSELF_TARGET),
                new PlayReq(CardDB.ErrorType2.REQ_TARGET_IF_AVAILABLE),
            };
        }

        // 在某个方法中增加逻辑来更新 consecutiveElementalTurns
        // 比如：当检测到玩家使用了元素牌且该回合符合条件时
        private void UpdateConsecutiveElementalTurns(bool playedElementalThisTurn)
        {
            if (playedElementalThisTurn)
            {
                consecutiveElementalTurns++;
            }
            else
            {
                consecutiveElementalTurns = 0;
            }
        }
    }
}
