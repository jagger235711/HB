using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	//法术 恶魔猎手 费用：2
	//Sigil of Skydiving
	//伞降咒符
	//At the start of yournext turn, summon three 1/1 Pirates with <b>Charge</b>.
	//在你的下个回合开始时，召唤三个1/1并具有<b>冲锋</b>的海盗。
	class Sim_VAC_925 : SimTemplate
    {
        // 当伞降咒符法术被施放时调用
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            // 如果该卡是由自己使用，则在Playfield标记需要在下一回合开始时触发
            if (ownplay)
            {
                p.sigilsToTriggerOnOwnTurnStart.Add(CardDB.cardIDEnum.VAC_925);
            }
        }
    }
}
