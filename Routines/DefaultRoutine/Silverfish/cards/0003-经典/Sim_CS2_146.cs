using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_CS2_146 : SimTemplate //* 南海船工 Southsea Deckhand
    {
        //Has <b>Charge</b> while you have a weapon equipped.
        //如果你装备一把武器，该随从具有<b>冲锋</b>。

        // 当南海船工被召唤或装备武器状态改变时，调用此方法来检查并更新随从的冲锋状态
        public override void onAuraStarts(Playfield p, Minion m)
        {
            // 更新南海船工的冲锋状态
            updateChargeStatus(p, m);
        }

        // 当光环效果结束时调用此方法，比如随从离场或其他影响效果消失时
        public override void onAuraEnds(Playfield p, Minion m)
        {
            // 更新南海船工的冲锋状态
            updateChargeStatus(p, m);
        }

        // 当己方武器发生变化时（装备或卸下武器），调用此方法
        public override void onWeaponChange(Playfield p, bool own)
        {
            if (own)
            {
                foreach (Minion m in p.ownMinions)
                {
                    if (m.name == CardDB.cardNameEN.southseadeckhand)
                    {
                        // 更新南海船工的冲锋状态
                        updateChargeStatus(p, m);
                    }
                }
            }
        }

        // 辅助方法，用于根据当前的武器状态为南海船工赋予或移除冲锋效果
        private void updateChargeStatus(Playfield p, Minion m)
        {
            // 检查己方是否装备了武器
            if (p.ownWeapon.Durability >= 1)
            {
                // 如果装备有武器，赋予南海船工冲锋效果
                p.minionGetCharge(m);
            }
            else
            {
                // 如果没有装备武器，移除南海船工的冲锋效果
                p.minionGetCharge(m, false);
            }
        }
    }
}
