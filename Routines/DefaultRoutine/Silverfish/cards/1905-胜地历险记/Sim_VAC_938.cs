using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    // 随从 中立 费用：3 攻击力：2 生命值：4
    // Hozen Roughhouser
    // 粗暴的猢狲
    // Whenever another friendly Pirate attacks, give it +1/+1.
    // 每当其他友方海盗攻击时，使其获得+1/+1。
    class Sim_VAC_938 : SimTemplate
    {
        // 当其他友方海盗攻击时触发
        public override void onMinionAttacksTarget(Playfield p, Minion attacker, Minion target)
        {
            // 检查是否为友方海盗且攻击者不是粗暴的猢狲自己
            if (attacker.own && attacker != null && attacker.handcard.card.race == TAG_RACE.PIRATE && attacker.entitiyID != this.entitiyID)
            {
                // 给攻击的友方海盗+1/+1
                p.minionGetBuffed(attacker, 1, 1);
            }
        }
    }
}
