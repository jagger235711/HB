using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_WW_424 : SimTemplate // Overflowing Lava
    {
        // <b>战吼：</b> 每有一个你使用过元素牌的连续的回合，召唤一个本随从的复制。<i>（召唤@个）</i>
        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            p.callKid(m.handcard.card, m.zonepos, m.own);
            p.callKid(m.handcard.card, m.zonepos, m.own);
            List<Minion> temp = (m.own) ? p.ownMinions : p.enemyMinions;
            int count = 0;
            foreach (Minion mnn in temp)
            {
                if (mnn.name == CardDB.cardNameEN.doppelgangster && m.entitiyID != mnn.entitiyID && mnn.playedThisTurn)
                {
                    mnn.setMinionToMinion(m);
                    count++;
                    if (count >= 2) break;
                }
            }
        }

    }
}
