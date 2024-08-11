using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_REV_938 : SimTemplate //* 暗影之门 Door of Shadows
//抽一张法术牌。注能（2）：将它的一张临时复制置入你的手牌。
//Draw a spell.Infuse (2): Add a temporary copy of it to your hand.
    {
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.drawACard(CardDB.cardIDEnum.None, ownplay);

        }
    }
}
