using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	//法术 中立 费用：1
	//Heartblossom
	//心灵之花
	//Give a friendly minion +2/+2. Deal $2 damage to a random enemy minion.
	//使一个友方随从获得+2/+2。随机对一个敌方随从造成$2点伤害。
	class Sim_DEEP_999t1 : SimTemplate
	{
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
			if (target != null && target.own == ownplay)
			{
				// 使一个友方随从获得+2/+2
				p.minionGetBuffed(target, 2, 2);
			}

			List<Minion> temp = (ownplay) ? p.enemyMinions : p.ownMinions;
			int times = (ownplay) ? p.getSpellDamageDamage(2) : p.getEnemySpellDamageDamage(2);

			if (temp.Count >= 1)
			{

				Minion enemy = temp[0];
				int minhp = 10000;
				foreach (Minion m in temp)
				{
					if (m.Hp >= times + 1 && minhp > m.Hp)
					{
						enemy = m;
						minhp = m.Hp;
					}
				}

				p.minionGetDamageOrHeal(enemy, times);

			}
		}
		public override PlayReq[] GetPlayReqs()
		{
			return new PlayReq[] {
				new PlayReq(CardDB.ErrorType2.REQ_MINIMUM_ENEMY_MINIONS, 1),
			};
		}
	}
}
