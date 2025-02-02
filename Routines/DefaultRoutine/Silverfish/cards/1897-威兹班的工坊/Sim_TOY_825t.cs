using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	//法术 巫妖王 费用：1
	//Spinel Spellstone
	//法术尖晶石
	//Give Undead in your hand +2/+2. <i>(Gain @ |4(<b>Corpse</b>, <b>Corpses</b>) to upgrade.)</i>
	//使你手牌中的亡灵牌获得+2/+2。<i>（获得@具<b>尸体</b>后升级。）</i>
	class Sim_TOY_825t : SimTemplate
	{

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            // 获取当前玩家的手牌列表
            List<Handmanager.Handcard> tempHand = ownplay ? p.owncards : p.enemyHand;

            // 遍历手牌中的卡牌
            foreach (Handmanager.Handcard hc in tempHand)
            {
                // 检查是否为亡灵随从
                if ((TAG_RACE)hc.card.race == TAG_RACE.UNDEAD)
                {
                    // 为亡灵随从增加 +2/+2
                    hc.addattack += 2;
                    hc.addHp += 2;
                }
            }
        }
    }
}
