using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    // 武器 牧师 费用：2 攻击力：1 耐久度：2
    // Quick Pick 疾速矿锄
    // 在你的英雄攻击后，抽一张牌。
    class Sim_DEEP_014 : SimTemplate
    {
        // 当玩家的英雄进行攻击时调用此方法
        public override void onHeroAttack(Playfield p, Minion attacker, Minion target, bool ownplay)
        {
            // 检查是否为玩家自己攻击并且装备了此武器
            if (ownplay && p.ownWeapon.card.cardIDenum == CardDB.cardIDEnum.DEEP_014)
            {
                // 抽一张牌
                p.drawACard(CardDB.cardIDEnum.None, ownplay);
            }
        }
    }
}
