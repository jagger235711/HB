using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    //法术 中立 费用：1
    //Pouch of Coins
    //钱袋
    //Get two Coins.
    //获取两张幸运币。
    class Sim_WW_001t18 : SimTemplate
    {
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                // 如果是玩家的法术，增加玩家幸运币的数量
                p.owncards.AddCard(CardDB.cardIDEnum.GAME_005, p.ownPlayer);
                p.owncards.AddCard(CardDB.cardIDEnum.GAME_005, p.ownPlayer);
            }
            else
            {
                // 如果是敌人的法术，增加敌人幸运币的数量
                p.enemycards.AddCard(CardDB.cardIDEnum.GAME_005, p.enemyPlayer);
                p.enemycards.AddCard(CardDB.cardIDEnum.GAME_005, p.enemyPlayer);
            }
        }
    }
}
