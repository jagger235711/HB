using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_VAN_CS2_073 : SimTemplate //* 冷血 Cold Blood
	{
		//Give a minion +2 Attack. <b>Combo:</b> +4 Attack instead.
		//使一个随从获得+2攻击力；<b>连击：</b>改为获得+4攻击力。
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int ag = (p.cardsPlayedThisTurn >= 1 || !ownplay) ? 4 : 2; // we suggest, whether enemy is playing this, it is combo
            p.minionGetBuffed(target, ag, 0);
		}


        public override PlayReq[] GetPlayReqs()
        {
            return new PlayReq[] {
                new PlayReq(CardDB.ErrorType2.REQ_TARGET_TO_PLAY),
                new PlayReq(CardDB.ErrorType2.REQ_MINION_TARGET),
            };
        }
	}
}