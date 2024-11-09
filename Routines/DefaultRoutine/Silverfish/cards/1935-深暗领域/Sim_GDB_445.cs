using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	//法术 萨满祭司 费用：6
	//Meteor Storm
	//陨石风暴
	//Deal $5 damageto all minions.Shuffle 5 Asteroidsinto your deck.
	//对所有随从造成$5点伤害。将5张小行星洗入你的牌库。
	class Sim_GDB_445 : SimTemplate
	{
		
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
			p.allMinionsGetDamage(5);
        }
		
	}
}
