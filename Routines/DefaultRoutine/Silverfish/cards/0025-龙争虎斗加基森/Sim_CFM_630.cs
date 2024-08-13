using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_CFM_630 : SimTemplate //* 伪造的幸运币 Counterfeit Coin
    {
        // Gain 1 Mana Crystal this turn only.
        // 在本回合中，获得一个法力水晶。

        // 当玩家使用这张卡牌时调用此方法
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            // 只处理己方玩家的法力水晶
            if (ownplay)
            {
                // 增加一个可用的法力水晶，并限制最大值为10
                p.mana = Math.Min(p.mana + 1, 10);

                // 增加临时法力水晶，确保总法力水晶数不超过10
                p.ownMaxMana = Math.Min(p.ownMaxMana + 1, 10);
            }
        }
    }
}
