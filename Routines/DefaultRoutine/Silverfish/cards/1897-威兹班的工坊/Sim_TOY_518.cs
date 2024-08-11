using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_TOY_518 : SimTemplate // 宝藏经销商 Treasure Distributor
    {
        // 在你召唤一个随从后，使其获得+1攻击力。
        public override void onMinionWasSummoned(Playfield p, Minion m, Minion summonedMinion)
		{
			if((TAG_RACE)summonedMinion.handcard.card.race == TAG_RACE.PIRATE && summonedMinion.own == m.own )
			{
           		p.minionGetBuffed(summonedMinion, 1, 0);
			}

            if (m.entitiyID != summonedMinion.entitiyID && m.own == summonedMinion.own)
            {
                p.minionGetBuffed(m, 1, 0);
            }
		}
        
        
    }
}

