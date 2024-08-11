using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_SCH_514 : SimTemplate //* 亡者复生 Raise Dead
    {
        //Deal $3 damage to your hero. Return two friendly minions that died this game to your hand.
        //对你的英雄造成$3点伤害。将两个在本局对战中死亡的友方随从移回你的手牌。
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            // 如果己方任务进度最大值为8且任务进度大于等于5且己方手牌数量大于等于9，则增加评估惩罚1000
            if (p.ownQuest.maxProgress == 8 && p.ownQuest.questProgress >= 5 && p.owncards.Count >= 9) 
                p.evaluatePenality += 10000;
            
            int rebornCard = 2; // 需要复活的随从数量
            p.minionGetDamageOrHeal(ownplay ? p.ownHero : p.enemyHero, 3); // 对英雄造成3点伤害
            
            // 遍历己方墓地中的卡牌
            foreach (KeyValuePair<CardDB.cardIDEnum, int> e in p.ownGraveyard)
            {
                // 获取已死亡的随从卡牌
                CardDB.Card rebornMob = CardDB.Instance.getCardDataFromID(e.Key);
                // 如果不是随从类型，则跳过
                if (rebornMob.type != CardDB.cardtype.MOB) continue;

                rebornCard -= e.Value; // 更新需要复活的随从数量
                if (rebornCard < 0) break; // 如果已经复活足够数量的随从，则退出循环
                
                // 将随从移回手牌，并重复添加至需要复活的随从数量
                p.drawACard(e.Key, ownplay, true);
                if (e.Value > 1)
                {
                    p.drawACard(e.Key, ownplay, true);
                }
            }

            // 根据复活的随从数量进行评估惩罚的调整
            if (rebornCard == 2)
                p.evaluatePenality += 1000;
            else if (rebornCard == 1)
            {
                p.evaluatePenality -= 100000;
                
            }
            else
            {
                p.evaluatePenality -= 100000;
            }

            // 如果没有坦莫丝，并且手牌数量加2减去复活的随从数量大于10，则增加评估惩罚1000
            if (!p.anzTamsin && p.owncards.Count + 2 - rebornCard > 10) 
                p.evaluatePenality += 1000;
        }
    }
}
