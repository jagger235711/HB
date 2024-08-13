using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_TOY_510 : SimTemplate // 挖掘宝藏
    {
        // 抽一张随从牌。如果是海盗牌，获取一张幸运币

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            // 抽一张牌
            CardDB.Card drawnCard = p.drawACard(CardDB.cardIDEnum.None, ownplay);

            // 检查抽到的是否是随从牌，并且是否是海盗
            if (drawnCard != null && drawnCard.type == CardDB.cardtype.MOB && drawnCard.race == TAG_RACE.PIRATE)
            {
                // 如果是海盗牌，给予玩家一张幸运币
                p.drawACard(CardDB.cardIDEnum.CFM_630, ownplay, true); // CFM_630 为“伪造的幸运币”的卡牌 ID
            }
        }
    }
}
