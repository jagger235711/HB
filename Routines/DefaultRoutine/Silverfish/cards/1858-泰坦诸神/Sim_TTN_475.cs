using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_TTN_475 : SimTemplate // Chainbreaker Gladiator
    {
        // <b>战吼：</b> 抽一张牌。你在上个回合每使用一张元素牌，重复一次。<i>（抽@张牌）</i>
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            p.drawACard(CardDB.cardIDEnum.None, own.own);
            p.drawACard(CardDB.cardIDEnum.None, own.own);
		}

       
    }
}
