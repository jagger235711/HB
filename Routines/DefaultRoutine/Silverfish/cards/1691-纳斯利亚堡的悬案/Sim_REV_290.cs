using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_REV_290 : SimTemplate //* 赎罪教堂 Cathedral of Atonement
                                    //使一个随从获得+2/+1。抽一张牌。
                                    //Give a minion +2/+1 and draw a card.
    {
        // 使用者使用该卡牌时，会触发这个方法
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
			p.minionGetBuffed(target, 2, 1);
			p.drawACard(CardDB.cardIDEnum.None, ownplay);
		}


		public override PlayReq[] GetPlayReqs()
        {
            return new PlayReq[] {
                new PlayReq(CardDB.ErrorType2.REQ_TARGET_TO_PLAY),
                new PlayReq(CardDB.ErrorType2.REQ_FRIENDLY_TARGET),
                new PlayReq(CardDB.ErrorType2.REQ_MINION_TARGET),
            };
        }
    }
}
