using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_DMF_519 : SimTemplate //* 奖品掠夺者 Prize Plunderer
	{
        //[x]<b>Combo:</b> Deal 1 damage toa minion for each other cardyou've played this turn.
        //<b>连击：</b>在本回合中，你每使用一张其他牌，便对一个随从造成1点伤害。
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                if (p.cardsPlayedThisTurn > 0)
                {
                    if (target != null) p.minionGetDamageOrHeal(target, p.cardsPlayedThisTurn);
                }
            }
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
