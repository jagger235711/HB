
using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_NX2_006 : SimTemplate //* 旗标骷髅 Jolly Roger
                                    //在你的英雄攻击后，召唤一个1/1的亡灵海盗。
                                    //After your heroattacks, summon a1/1 Undead Pirate.
    {
		CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.NX2_006t);
        public override void onHeroattack(Playfield p, Minion own, Minion target)
        {
            p.callKid(kid, own.zonepos, own.own);
        }
    }


}
        