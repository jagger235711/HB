using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_DMF_519 : SimTemplate //* 奖品掠夺者 Prize Plunderer
    {
        //[x]<b>Combo:</b> Deal 1 damage to a minion for each other card you've played this turn.
        //<b>连击：</b>在本回合中，你每使用一张其他牌，便对一个随从造成1点伤害。

        // 当奖品掠夺者上场时，调用 getBattlecryEffect 方法
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            // 只有在随从属于己方且满足连击条件时，才会执行效果
            if (own.own)
            {
                // 如果本回合已经使用过至少一张其他牌
                if (p.cardsPlayedThisTurn > 0)
                {
                    // 如果指定了目标，则对其造成等同于已使用牌数量的伤害
                    if (target != null) p.minionGetDamageOrHeal(target, p.cardsPlayedThisTurn);
                }
            }
        }

        // 获取这张卡牌的使用条件
        public override PlayReq[] GetPlayReqs()
        {
            // 返回卡牌的使用要求：
            // 1. 需要选择一个目标才能使用
            // 2. 目标必须是一个随从
            // 3. 目标必须是敌方随从
            return new PlayReq[] {
                new PlayReq(CardDB.ErrorType2.REQ_TARGET_TO_PLAY), // 需要选择一个目标
                new PlayReq(CardDB.ErrorType2.REQ_MINION_TARGET),  // 目标必须是随从
                new PlayReq(CardDB.ErrorType2.REQ_ENEMY_TARGET),   // 目标必须是敌方随从
            };
        }
    }
}

