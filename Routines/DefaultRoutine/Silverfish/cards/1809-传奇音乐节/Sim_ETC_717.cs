
using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_ETC_717 : SimTemplate //* 悦耳嘻哈 Harmonic Hip Hop
                                    //造成1点伤害。使你的武器获得+3攻击力。&lt;i&gt;（每回合切换。）&lt;/i&gt;
                                    //Deal 1 damage. Give your weapon +3 Attack.&lt;i&gt;(Swaps each turn.)&lt;/i&gt;
    {
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            if(target != null)
            {
                int dmg = (ownplay) ? p.getSpellDamageDamage(1) : p.getEnemySpellDamageDamage(1);
                p.minionGetDamageOrHeal(target, dmg);
                if(p.ownWeapon.Durability > 0)
                    p.ownWeapon.Angr += 3;
            }
		}


        public override PlayReq[] GetPlayReqs()
        {
            return new PlayReq[] {
				new PlayReq(CardDB.ErrorType2.REQ_ENEMY_TARGET),
                new PlayReq(CardDB.ErrorType2.REQ_NONSELF_TARGET),
            };
        }
    }


}
        