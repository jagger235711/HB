using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    // 随从 中立 费用：4 攻击力：3 生命值：3
    // Dread Corsair
    // 恐怖海盗
    // <b>Taunt</b> Costs (1) less per Attack of your weapon.
    // <b>嘲讽</b> 你的武器每有1点攻击力，该牌的法力值消耗便减少（1）点。
    class Sim_CORE_NEW1_022 : SimTemplate
    {
        // 在牌的法力值被计算时调用这个方法
        public override void getCostModifier(Playfield p, Handmanager.Handcard hc, Minion target, int choice)
        {
            if (p.ownWeapon.Angr > 0)
            {
                // 计算武器攻击力带来的减费效果
                hc.manacost -= p.ownWeapon.Angr;

                // 确保卡牌的法力值消耗不会低于0
                if (hc.manacost < 0)
                {
                    hc.manacost = 0;
                }
            }
        }
    }
}
