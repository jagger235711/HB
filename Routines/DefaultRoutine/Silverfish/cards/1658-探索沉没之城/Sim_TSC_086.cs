using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_TSC_086 : SimTemplate //* 剑鱼 Swordfish
//战吼：探底。如果选中的是海盗牌，使这把武器和该海盗获得+2攻击力。
//Battlecry: Dredge.If it's a Pirate, give this weapon and the Pirate +2 Attack.
    {


        CardDB.Card weapon = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.TSC_086);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.equipWeapon(weapon, ownplay);
        }
    }
}