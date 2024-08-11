using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_LOOT_517 : SimTemplate //* 低语元素 Murmuring Elemental
//<b>Battlecry:</b> Your next <b>Battlecry</b> this turn triggers_twice.
//<b>战吼：</b>你在本回合使用的下一张<b>战吼</b>牌将触发两次。 
	{
		

		public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
		{
            if (m.own) p.ownBrannBronzebeard++;
		}
	}
}