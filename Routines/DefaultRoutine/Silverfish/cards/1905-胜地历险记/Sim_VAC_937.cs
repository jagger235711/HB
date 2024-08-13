using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    // 随从 中立 费用：3 攻击力：2 生命值：4
    // Sailboat Captain 帆船舰长
    // <b>战吼：</b>使一个友方海盗获得<b>风怒</b>。
    // <b>Battlecry:</b> Give a friendly Pirate <b>Windfury</b>.
    class Sim_VAC_937 : SimTemplate
    {
        // 当随从的战吼效果触发时调用此方法
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            // 检查目标是否存在且是友方海盗
            if (target != null && target.handcard.card.race == TAG_RACE.PIRATE && target.own == own.own)
            {
                // 赋予目标风怒效果
                p.minionGetWindfury(target);
            }
        }

        public override PlayReq[] GetPlayReqs()
        {
            return new PlayReq[] {
                new PlayReq(CardDB.ErrorType2.REQ_TARGET_TO_PLAY),
                new PlayReq(CardDB.ErrorType2.REQ_MINION_TARGET),
                new PlayReq(CardDB.ErrorType2.REQ_FRIENDLY_TARGET),
                new PlayReq(CardDB.ErrorType2.REQ_PIRATE_TARGET),
            };
        }
    }
}
