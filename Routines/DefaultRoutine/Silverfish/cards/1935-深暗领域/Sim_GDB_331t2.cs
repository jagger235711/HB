using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	class Sim_GDB_331t2 : SimTemplate //* 分裂飞石 
	{
        //<b>Deathrattle:</b> Summon two 1/1 Pebbles.
        //<b>亡语：</b>召唤两个1/1的碎石。
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.GDB_331t3);

        public override void onDeathrattle(Playfield p, Minion m)
        {
            p.callKid(kid, m.zonepos - 1, m.own);
            p.callKid(kid, m.zonepos - 1, m.own);
        }

    }
}
