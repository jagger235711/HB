using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_TOY_518 : SimTemplate // 宝藏经销商 Treasure Distributor
    {
        // 在你召唤一个海盗后，使它和本随从各获得+1攻击力。

        public override void onMinionWasSummoned(Playfield p, Minion m, Minion summonedMinion)
        {
            // 检查召唤的随从是否是海盗并且是否属于同一阵营
            if (summonedMinion.own == m.own && summonedMinion.handcard.card.race == CardDB.Race.PIRATE)
            {
                // 使召唤的海盗获得+1攻击力
                p.minionGetBuffed(summonedMinion, 1, 0);

                // 使宝藏经销商自身获得+1攻击力
                p.minionGetBuffed(m, 1, 0);
            }
        }
    }
}
