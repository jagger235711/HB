using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_TTN_922 : SimTemplate //* 换挡漂移 Gear Shift
	{
		//Shuffle the two left-most cards in your hand into your deck. Draw 3 cards.
		//将你最左边的两张手牌洗入你的牌库。抽三张牌。
        // 处理使用法术效果的方法
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            // 抽三张牌
            p.drawACard(CardDB.cardNameEN.unknown, ownplay, true);
            p.drawACard(CardDB.cardNameEN.unknown, ownplay, true);
            p.drawACard(CardDB.cardNameEN.unknown, ownplay, true);
        }

    }
}
