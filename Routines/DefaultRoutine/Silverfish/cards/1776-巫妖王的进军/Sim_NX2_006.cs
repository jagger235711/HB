using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_NX2_006 : SimTemplate //* 旗标骷髅 Jolly Roger
                                    //在你的英雄攻击后，召唤一个1/1的亡灵海盗。
                                    //After your hero attacks, summon a 1/1 Undead Pirate.
    {
        // 定义一个CardDB.Card类型的变量kid，用于存储要召唤的1/1亡灵海盗的卡牌数据
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.NX2_006t);

        // 当英雄攻击后触发该方法
        public override void onHeroattack(Playfield p, Minion own, Minion target)
        {
            // 调用callKid方法，在指定位置（own.zonepos）召唤1/1亡灵海盗，own.own表示是己方英雄
            p.callKid(kid, own.zonepos, own.own);
        }
    }
}
