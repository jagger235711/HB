using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_YOG_519 : SimTemplate // Corrupted Residue
    {
        // <b>战吼：</b> 造成7点伤害，随机分配到所有敌人身上。
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            int totalDamage = 7;
            List<Minion> enemyTargets = new List<Minion>(p.enemyMinions);
            
            if (p.enemyHero != null)
            {
                enemyTargets.Add(p.enemyHero);
            }

            // 如果没有敌方目标，直接返回
            if (enemyTargets.Count == 0)
            {
                return;
            }

            Random rand = new Random();

            for (int i = 0; i < totalDamage; i++)
            {
                if (enemyTargets.Count > 0)
                {
                    Minion selectedTarget = enemyTargets[rand.Next(enemyTargets.Count)];
                    p.minionGetDamageOrHeal(selectedTarget, 1);
                }
            }
        }
    }
}

        
        
