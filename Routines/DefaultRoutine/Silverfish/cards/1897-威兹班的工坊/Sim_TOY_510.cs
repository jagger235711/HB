
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
            p.drawACard(CardDB.cardIDEnum.None, ownplay);
		}
    }
}
