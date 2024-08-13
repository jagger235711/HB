using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_075 : SimTemplate //* 船载火炮 Ship's Cannon
    {
        //[x]After you summon a Pirate, deal 2 damage to a random enemy.
        //在你召唤一个海盗后，随机对一个敌人造成2点伤害。

        // 当玩家召唤一个随从时触发该方法
        public override void onMinionIsSummoned(Playfield p, Minion triggerEffectMinion, Minion summonedMinion)
        {
            // 检查被召唤的随从是否是海盗，并且是否与船载火炮属于同一方
            if ((TAG_RACE)summonedMinion.handcard.card.race == TAG_RACE.PIRATE && triggerEffectMinion.own == summonedMinion.own)
            {
                // 随机选择一个敌方角色（包括随从或英雄）作为目标，造成2点伤害
                Minion target = p.getEnemyCharTargetForRandomSingleDamage(2);

                // 对选中的目标造成2点伤害
                if (target != null)
                {
                    p.minionGetDamageOrHeal(target, 2);
                }
            }
        }
    }
}
