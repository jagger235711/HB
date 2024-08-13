using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_TOY_518 : SimTemplate // 宝藏经销商 Treasure Distributor
    {
        //宝藏经销商 Treasure Distributor
        //在你召唤一个海盗后，使它和本随从各获得+1攻击力。

        // 当有随从被召唤时，调用 onMinionWasSummoned 方法
        public override void onMinionWasSummoned(Playfield p, Minion m, Minion summonedMinion)
        {
            // 判断被召唤的随从是否是海盗，并且是与本随从在同一方
            if((TAG_RACE)summonedMinion.handcard.card.race == TAG_RACE.PIRATE && summonedMinion.own == m.own )
            {
                // 如果是海盗，则给予该海盗+1攻击力的加成
                p.minionGetBuffed(summonedMinion, 1, 0);
            }

            // 如果被召唤的随从不是本随从并且与本随从在同一方
            if (m.entitiyID != summonedMinion.entitiyID && m.own == summonedMinion.own)
            {
                // 给本随从+1攻击力的加成
                p.minionGetBuffed(m, 1, 0);
            }
        }
    }
}
