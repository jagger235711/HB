using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_TSC_963 : SimTemplate //* 鱼排斗士 Filletfighter
    {
        // 战吼：造成1点伤害。
        // Battlecry: Deal 1 damage.

        // 当随从的战吼效果触发时调用该方法
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            int dmg = 1; // 设置伤害值为1
            if (target != null)
            {
                // 对目标造成1点伤害
                p.minionGetDamageOrHeal(target, dmg);
            }
        }

        // 设置卡牌的使用条件
        public override PlayReq[] GetPlayReqs()
        {
            return new PlayReq[] {
                new PlayReq(CardDB.ErrorType2.REQ_NONSELF_TARGET),  // 需要一个非自身的目标
                new PlayReq(CardDB.ErrorType2.REQ_TARGET_IF_AVAILABLE), // 需要一个可用的目标
            };
        }
    }
}
