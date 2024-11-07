using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	//法术 恶魔猎手 费用：1
	//Parachute
	//降落伞
	//<b>Casts When Drawn</b>Summon a 1/1 Pirate with <b>Charge</b>.
	//<b>抽到时施放</b>召唤一个1/1并具有<b>冲锋</b>的海盗。
	class Sim_VAC_933t : SimTemplate
    {
        // 抽到时施放的效果
        public override void onCardIsDrawn(Playfield p, bool ownplay, Minion triggerEffectMinion)
        {
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            // 召唤一个1/1并具有冲锋的海盗
            p.callKid(CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.VAC_926t), pos, ownplay, true);
        }
    }
}
