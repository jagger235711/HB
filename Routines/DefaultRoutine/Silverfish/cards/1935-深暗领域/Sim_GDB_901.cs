using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	//随从 萨满祭司 费用：3 攻击力：3 生命值：2
	//Ultraviolet Breaker
	//极紫外破坏者
	//[x]<b>Battlecry:</b> Deal 3 damage toan enemy minion. Shuffle 3Asteroids into your deck.
	//<b>战吼：</b>对一个敌方随从造成3点伤害。将3张小行星洗入你的牌库。
	class Sim_GDB_901 : SimTemplate
	{
		public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
		{
            int dmg = 3;
            p.minionGetDamageOrHeal(target, dmg);
			//TODO：三张小行星洗入牌库
		}
		
        public override PlayReq[] GetPlayReqs()
        {
            return new PlayReq[] {
                new PlayReq(CardDB.ErrorType2.REQ_MINION_TARGET),
                new PlayReq(CardDB.ErrorType2.REQ_ENEMY_TARGET),
                new PlayReq(CardDB.ErrorType2.REQ_TARGET_IF_AVAILABLE),
            };
        }
		
	}
}
