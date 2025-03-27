using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	//地标 战士 费用：1
	//Sanguine Depths
	//赤红深渊
	//[x]Deal 1 damage to a minion and give it +2 Attack.
	//对一个随从造成1点伤害，并使其获得+2攻击力。
	class Sim_CORE_REV_990 : SimTemplate
	{
        public override void useLocation(Playfield p, Minion triggerMinion, Minion target)
        {
            try
            {
                // 检查所有必要参数
                if (p == null || target == null)
                {
                    return;
                }

                // 检查目标随从是否仍然存活
                if (!target.isValidTarget())
                {
                    return;
                }

                // 对目标随从造成1点伤害
                p.minionGetDamageOrHeal(target, 1);

                // 再次检查目标是否存活
                if (!target.isValidTarget())
                {
                    return;
                }

                // 使目标随从获得+2攻击力（永久）
                p.minionGetBuffed(target, 2, 0); // 给予永久的攻击力加成
            }
            catch (Exception ex)
            {
                // 记录错误但允许游戏继续进行
                //Console.WriteLine($"Error in Sim_CORE_REV_990.useLocation: {ex.Message}");
            }
        }

        public override PlayReq[] GetUseAbilityReqs()
        {
            return new PlayReq[]
            {
                new PlayReq(CardDB.ErrorType2.REQ_TARGET_TO_PLAY), // 需要一个目标才能使用
                new PlayReq(CardDB.ErrorType2.REQ_MINION_TARGET), // 目标必须是一个随从
            };
        }
    }
}
