using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	//法术 德鲁伊 费用：8
	//Hydration Station
	//补水区
	//Resurrect three of your different highest Cost <b>Taunt</b> minions.
	//复活你法力值消耗最高的三个不同的<b>嘲讽</b>随从。
	class Sim_VAC_948 : SimTemplate
	{
		public override void onCardPlay(Playfield p, bool ownplay, Minion m, int choice)
		{
			bool cost1 = false;
			bool cost2 = false;
			bool cost3 = false;
			string str = "我寻思开赛集结应该会召唤：";
			int pos = p.ownMinions.Count ;
			p.evaluatePenality += 10;

			foreach (KeyValuePair<CardDB.cardIDEnum, int> e in Probabilitymaker.Instance.ownGraveyard)
			{
				bool died = true;
				// 如果就在场上不认为已死亡
				foreach ( Minion mm in p.ownMinions ){
					if(mm.handcard.card.cardIDenum == e.Key && e.Value < 2){
						died = false;
						break;;
					}
				}
				// 死亡随从
				CardDB.Card rebornMob = CardDB.Instance.getCardDataFromID(e.Key);
				// 不是已死亡随从退出
				if(!died || rebornMob.type != CardDB.cardtype.MOB) continue;
				pos = p.ownMinions.Count ;
				if(!cost1 && rebornMob.cost == 6){
					p.callKid(rebornMob, pos, ownplay);
					str += rebornMob.nameCN + " ";
					cost1 = true;
				}
				if(!cost2 && rebornMob.cost == 7){
					p.callKid(rebornMob, pos, ownplay);
					str += rebornMob.nameCN + " ";
					cost2 = true;
				}
				if(!cost3 && rebornMob.cost == 9){
					p.callKid(rebornMob, pos, ownplay);
					str += rebornMob.nameCN + " ";
					cost3 = true;
				}
			}
			//Helpfunctions.Instance.ErrorLog(str);
		}	
	}
}
