
using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_DEEP_008 : SimTemplate // 避免报错
    {
        // 在这里可以定义卡牌的属性，如法力值消耗、卡牌类型、效果等等

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (turnEndOfOwner == triggerEffectMinion.own)
            {
                p.drawACard(CardDB.cardIDEnum.None, turnEndOfOwner);
            }
            
            if (triggerEffectMinion.own)
                {
                    p.minionGetArmor(p.ownHero, 3);
                    
                }
                else
                {
                    p.minionGetArmor(p.enemyHero, 3);
                }
            
        }

        
        
    }
}
