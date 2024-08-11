using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_DED_513 : SimTemplate // Defias Leper
    {
        // Battlecry: If you're holding a Shadow spell, deal 2 damage.

        // 处理战吼效果的方法
        public override void getBattlecryEffect(Playfield p, Minion m, Minion target, int choice)
        {
            // 判断玩家的手牌中是否有暗影法术牌
            bool hasShadowSpell = false;
            foreach (Handmanager.Handcard hc in p.owncards)
            {
                if (hc.card.type == CardDB.cardtype.SPELL)	//  && hc.card.SpellSchool == CardDB.SpellSchool.SHADOW
                {
                    hasShadowSpell = true;
                    break;
                }
            }

            // 如果有暗影法术牌，对目标造成2点伤害
            if (hasShadowSpell && target != null)
            {
                p.minionGetDamageOrHeal(target, 2);
            }
        }
		public override PlayReq[] GetPlayReqs()
        {
            return new PlayReq[] {
                new PlayReq(CardDB.ErrorType2.REQ_TARGET_TO_PLAY),
				new PlayReq(CardDB.ErrorType2.REQ_ENEMY_TARGET),

            };
        }
    }
}
