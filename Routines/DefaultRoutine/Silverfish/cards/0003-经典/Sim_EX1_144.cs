using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_CORE_EX1_144 : SimTemplate //* shadowstep 暗影步
    {
        //Return a friendly minion to your hand. It costs (2) less.
        //将一个友方随从移回你的手牌。该随从的法力值消耗减少（2）点。

        // 当这张卡牌被使用时，调用 onCardPlay 方法
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            // 将目标随从返回到拥有者的手牌，并使其法力值消耗减少2点
            p.minionReturnToHand(target, ownplay, -2);
        }

        // 获取这张卡牌的使用条件
        public override PlayReq[] GetPlayReqs()
        {
            // 返回卡牌的使用要求：
            // 1. 需要选择一个目标才能使用
            // 2. 目标必须是一个随从
            // 3. 目标必须是一个友方随从
            return new PlayReq[] {
                new PlayReq(CardDB.ErrorType2.REQ_TARGET_TO_PLAY), // 需要选择一个目标
                new PlayReq(CardDB.ErrorType2.REQ_MINION_TARGET),  // 目标必须是随从
                new PlayReq(CardDB.ErrorType2.REQ_FRIENDLY_TARGET), // 目标必须是友方随从
            };
        }
    }
}
