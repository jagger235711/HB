using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_VAC_442 : SimTemplate // Light the Candle Elemental
    {
        // 假设有一个用于追踪连续使用元素牌回合数的字段

        // <b>战吼：</b> 造成@点伤害<i>（每有一个你使用过元素牌的连续的回合，伤害都会提升）</i>。
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            
           

            // 将伤害值修改为根据玩家拥有的最大水晶数目来计算
            int dmg = p.ownMaxMana; // 玩家拥有的最大法力水晶数目

            // 对敌方英雄造成伤害
            p.minionGetDamageOrHeal(target, dmg);

            
        }

        public override PlayReq[] GetPlayReqs()
        {
            return new PlayReq[] {
                new PlayReq(CardDB.ErrorType2.REQ_ENEMY_TARGET),
                new PlayReq(CardDB.ErrorType2.REQ_TARGET_IF_AVAILABLE),
            };
        }
    }
}
