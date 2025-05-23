using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	//法术 德鲁伊 费用：3
	//New Heights
	//攀上新高
	//[x]Increase your maximumMana by 3 and gain anempty Mana Crystal.
	//将你的法力值上限提高3点，获得一个空的法力水晶。
	class Sim_VAC_949 : SimTemplate
	{
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            if (ownplay)
            {
                if (p.ownMaxMana < 10)
                {
                    p.ownMaxMana++;
                }
            }
            else
            {
                if (p.enemyMaxMana < 10)
                {
                    p.enemyMaxMana++;
                }
            }
		}
    }
}
