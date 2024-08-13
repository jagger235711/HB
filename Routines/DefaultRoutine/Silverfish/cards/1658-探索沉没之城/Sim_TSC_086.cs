using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_TSC_086 : SimTemplate //* 剑鱼 Swordfish
    {
        // 战吼：探底。如果选中的是海盗牌，使这把武器和该海盗获得+2攻击力。
        // Battlecry: Dredge. If it's a Pirate, give this weapon and the Pirate +2 Attack.

        CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.TSC_086); // 剑鱼武器

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            // 装备剑鱼武器
            p.equipWeapon(weapon, ownplay);

            // 探底效果，这里假设探底是通过某种方法获得的，比如玩家手动选择一张卡牌
            CardDB.Card dredgedCard = p.getDredgedCard(ownplay); // 假设此方法能获取探底选中的卡牌

            if (dredgedCard != null && dredgedCard.race == TAG_RACE.PIRATE)
            {
                // 如果选中的卡牌是海盗，增加武器的攻击力
                p.ownWeapon.Angr += 2;
                p.minionGetBuffed(target, 2, 0); // 选中的海盗获得+2攻击力
            }
        }
    }
}
