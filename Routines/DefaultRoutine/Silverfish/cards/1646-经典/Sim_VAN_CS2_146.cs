using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_VAN_CS2_146 : SimTemplate //* 南海船工 Southsea Deckhand
	{
		//Has <b>Charge</b> while you have a weapon equipped.
		//如果你装备一把武器，该随从具有<b>冲锋</b>。
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            if (own.own)
            {
                if (p.ownWeapon.Durability >= 1)
                {
                    p.minionGetCharge(own);
                }
            }
            else
            {
                if (p.enemyWeapon.Durability >= 1)
                {
                    p.minionGetCharge(own);
                }
            }
		}

	}
}