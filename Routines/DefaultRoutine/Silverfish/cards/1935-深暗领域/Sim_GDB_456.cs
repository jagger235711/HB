using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	//法术 法师 费用：2
	//Spontaneous Combustion
	//自燃
	//Deal $4 damage to a random enemy. If you played an Elemental last turn, choose the target.
	//随机对一个敌人造成$4点伤害。如果你在上个回合使用过元素牌，则可以选择目标。
	class Sim_GDB_456 : SimTemplate
	   {
        //<b>Deal 4 damage to a random enemy. If you played an Elemental last turn, choose the target.</b>

        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            Minion selectedTarget = null;

            // 检查玩家上回合是否使用过元素牌
            if (p.previousTurnPlayedElemental)
            {
                // 如果使用过元素牌，允许选择目标
                selectedTarget = target; // 这里的target应由玩家选择

                // 检查选择的目标是否为免疫状态
                if (selectedTarget.IsImmune)
                {
                    // 如果目标是免疫状态，选择随机目标
                    selectedTarget = p.getRandomEnemy();
                }
            }
            else
            {
                // 随机选择一个敌方随从作为目标
                selectedTarget = p.getRandomEnemy();
            }

            // 对目标造成4点伤害
            if (selectedTarget != null)
            {
                p.minionGetDamageOrHeal(selectedTarget, 4);
            }
        }

        public override PlayReq[] GetPlayReqs()
        {
            // 该卡牌需要选择目标
            return new PlayReq[] {
                new PlayReq(CardDB.ErrorType2.REQ_TARGET_TO_PLAY),  // 需要选择一个目标
                new PlayReq(CardDB.ErrorType2.REQ_MINION_TARGET_OR_HERO, // 目标必须是随从或英雄
                new PlayReq(CardDB.ErrorType2.REQ_ENEMY_TARGET),    // 目标必须是敌方
            };
        }
    }
}