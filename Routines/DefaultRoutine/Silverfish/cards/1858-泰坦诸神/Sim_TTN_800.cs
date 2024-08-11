using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_TTN_800 : SimTemplate
    {
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            switch (choice)
            {
                case 1: // 对所有敌人造成3点伤害，为所有友方角色恢复6点生命值
                    foreach (Minion enemyMinion in ownplay ? p.enemyMinions : p.ownMinions)
                    {
                        p.minionGetDamageOrHeal(enemyMinion, 3);
                    }
                    p.minionGetDamageOrHeal(ownplay ? p.ownHero : p.enemyHero, -6);
                    foreach (Minion ownMinion in ownplay ? p.ownMinions : p.enemyMinions)
                    {
                        p.minionGetDamageOrHeal(ownMinion, -6);
                    }
                    break;
                case 2: // 对另一个随从造成20点伤害
                    if (target != null)
                    {
                        int damage = 20;
                        p.minionGetDamageOrHeal(target, damage);
                    }
                    break;
                case 3: // 抽三张过载牌
                    for (int i = 0; i < 3; i++)
                    {
                        foreach (KeyValuePair<CardDB.cardIDEnum, int> kvp in p.prozis.turnDeck)
                        {
                            CardDB.cardIDEnum deckCard = kvp.Key;
                            CardDB.Card card = CardDB.Instance.getCardDataFromID(deckCard);
                            if (card.overload > 0)
                            {
                                p.drawACard(deckCard, true, false);
                                break;
                            }
                        }
                    }
                    break;
            }
        }

        public override PlayReq[] GetPlayReqs()
        {
            return new PlayReq[] {
                new PlayReq(CardDB.ErrorType2.REQ_TARGET_TO_PLAY),
            };
        }
    }
}

