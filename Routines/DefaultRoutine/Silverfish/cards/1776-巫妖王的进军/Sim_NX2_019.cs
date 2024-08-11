
using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_NX2_019 : SimTemplate //* 精神灼烧 Mind Sear
                                    //对一个随从造成2点伤害。如果该随从死亡，则对敌方英雄造成3点伤害。
                                    //Deal 2 damage to a minion. If it dies,deal 3 damage to the enemy hero.
    {
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int dmg = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);
            if (dmg >= target.Hp && !target.divineshild && !target.immune)
            {
                p.minionGetDamageOrHeal(p.enemyHero, 3);
            }
            p.minionGetDamageOrHeal(target, dmg);
            
		}


        public override PlayReq[] GetPlayReqs()
        {
            return new PlayReq[] {
                new PlayReq(CardDB.ErrorType2.REQ_TARGET_TO_PLAY),
                new PlayReq(CardDB.ErrorType2.REQ_MINION_TARGET),
                new PlayReq(CardDB.ErrorType2.REQ_ENEMY_TARGET),
            };
        }
    }


}
        
        
        