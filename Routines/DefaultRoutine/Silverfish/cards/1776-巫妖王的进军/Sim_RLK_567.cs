using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    // 法术 牧师 费用：0
    // Shadow of Demise
    // 殒命暗影
    // 每当你施放一个法术，变形成为该法术的复制。
    class Sim_RLK_567 : SimTemplate
    {
        // 当玩家施放任何法术时调用
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            // 获取最后施放的法术卡牌
            CardDB.Card lastSpell = p.lastPlayedCard;

            // 确保最后施放的卡牌是一个法术
            if (lastSpell != null && lastSpell.type == CardDB.cardtype.SPELL)
            {
                // 将"殒命暗影"变形为最后施放的法术
                if (ownplay)
                {
                    // 将“殒命暗影”替换为最后施放的法术
                    p.ownHandCards[p.owncards.Count - 1].setCard(lastSpell);
                }
            }
        }

        // 确保卡牌未变形前无法使用
        public override bool canPlay(Playfield p, int choice)
        {
            // 殒命暗影只有在变形后才能使用，这里假设它变形前的 ID 是 RLK_567
            foreach (var card in p.owncards)
            {
                if (card.card.cardIDenum == CardDB.cardIDEnum.RLK_567)
                {
                    return false; // 未变形前不能使用
                }
            }
            return true; // 变形后可正常使用
        }
    }
}
