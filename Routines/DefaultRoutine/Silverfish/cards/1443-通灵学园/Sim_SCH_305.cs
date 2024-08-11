using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_SCH_305 : SimTemplate //* 秘密通道 Secret Passage
	{
		//Replace your hand with 5 cards from your deck. Swap back next turn.
		//将你的手牌替换为你牌库中的5张牌。下回合换回。

		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
			if (p.mana <= 3) p.evaluatePenality += 250;

			p.discardCards(10, ownplay);

			p.drawACard(CardDB.cardNameEN.unknown, ownplay);
			p.drawACard(CardDB.cardNameEN.unknown, ownplay);
			p.drawACard(CardDB.cardNameEN.unknown, ownplay);
            p.drawACard(CardDB.cardNameEN.unknown, ownplay);				
		}	
		public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
		{
			p.discardCards(4, turnEndOfOwner);
		}		
	}
}
