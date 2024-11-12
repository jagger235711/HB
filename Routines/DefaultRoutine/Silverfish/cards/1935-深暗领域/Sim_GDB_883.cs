using System;
using System.Collections.Generic;

namespace HREngine.Bots
{
    // 法术 德鲁伊 费用：4
    // Distress Signal
    // 求救信号
    // [x] 随机召唤两个法力值消耗为（2）的随从。复原我方 2 个法力水晶。
    class Sim_GDB_883 : SimTemplate
    {
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            // 随机召唤两个法力值消耗为 2 的随从
            for (int i = 0; i < 2; i++)
            {
                CardDB.Card randomTwoCostMinion = p.getRandomCardOfTypeAndCost(CardDB.cardtype.MOB, 2);
                if (randomTwoCostMinion != null)
                {
                    // 将随从召唤到战场上，位置在自己随从列表的末尾
                    p.callKid(randomTwoCostMinion, p.ownMinions.Count, ownplay);
                }
            }

            // 复原我方 2 个法力水晶
            if (ownplay)
            {
                p.mana = Math.Min(p.ownMaxMana, p.mana + 2); // 复原法力值，但不超过最大法力值
            }
        }
    }
}
