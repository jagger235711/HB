namespace HREngine.Bots
{

    public class SimTemplate
    {
        /// <summary>
        /// 获取卡牌的PlayRequirement
        /// </summary>
        /// <returns></returns>
        public virtual PlayReq[] GetPlayReqs()
        {
            return new PlayReq[] { };
        }

        /// <summary>
        /// 荣耀击杀效果(随从)
        /// </summary>
        /// <param name="p">场面</param>
        /// <param name="w">随从</param>
        public virtual void OnHonorableKill(Playfield p, Minion attacker, Minion target)
        {
            return;
        }

        /// <summary>
        /// 荣耀击杀效果（武器）
        /// </summary>
        /// <param name="p">场面</param>
        /// <param name="w">武器</param>
        public virtual void OnHonorableKill(Playfield p, Weapon w, Minion target)
        {
            return;
        }

        /// <summary>
        /// 荣耀击杀效果（卡牌）
        /// </summary>
        /// <param name="p">场面</param>
        /// <param name="m">具有荣耀击杀效果的卡牌</param>
        public virtual void OnHonorableKill(Playfield p, Handmanager.Handcard hc, Minion target)
        {
            return;
        }

        /// <summary>
        /// 超杀效果（武器）
        /// </summary>
        /// <param name="p">场面</param>
        /// <param name="w">武器</param>
        public virtual void OnOverkill(Playfield p, Weapon w)
        {
            return;
        }

        /// <summary>
        /// 超杀效果（随从）
        /// </summary>
        /// <param name="p">场面</param>
        /// <param name="m">具有超杀效果的随从</param>
        public virtual void OnOverkill(Playfield p, Minion m)
        {
            return;
        }

        /// <summary>
        /// 法术迸发效果
        /// </summary>
        /// <param name="p">场面</param>
        /// <param name="m">具有法术迸发的随从</param>
        /// <param name="hc">触发法术迸发的法术牌</param>
        public virtual void OnSpellburst(Playfield p, Minion m, Handmanager.Handcard hc)
        {
            return;
        }

        /// <summary>
        /// 法术迸发（武器）
        /// </summary>
        /// <param name="p">场面</param>
        /// <param name="w">武器</param>
        /// <param name="hc">触发法术迸发的法术牌</param>
        public virtual void OnSpellburst(Playfield p, Weapon w, Handmanager.Handcard hc)
        {
            return;
        }
		public virtual void onOverkill(Playfield p, Minion attacker, Minion target)
		{
			return;
		}

        /// <summary>
        /// 奥秘的效果，暂时只在猜奥秘时猜崇高牺牲和误导时触发，其他卡牌暂无效果
        /// 请尽量不要使用这个方法，以便重构
        /// </summary>
        /// <param name="p">场面</param>
        /// <param name="ownplay">是否自己打出</param>
        /// <param name="attacker">攻击方</param>
        /// <param name="target">被攻击的目标</param>
        /// <param name="number">新的目标</param>
        public virtual void onSecretPlay(Playfield p, bool ownplay, Minion attacker, Minion target, out int number)
        {
            number = 0;
        }

        /// <summary>
        /// 奥秘的效果，暂时只在猜奥秘时猜冰冻陷阱、寒冰屏障、忏悔、审判、狙击时触发，其他卡牌暂无效果
        /// 请尽量不要使用这个方法，以便重构
        /// </summary>
        /// <param name="p">场面</param>
        /// <param name="ownplay">是否自己打出</param>
        /// <param name="target">被攻击的目标</param>
        /// <param name="number">仅在猜寒冰屏障时有效，值为受到的攻击</param>
        public virtual void onSecretPlay(Playfield p, bool ownplay, Minion target, int number)
        {
            return;
        }

        /// <summary>
        /// 奥秘的效果，暂时只在猜奥秘时猜爆炸陷阱、捕熊陷阱、毒蛇陷阱、以眼还眼、豹子戏法、救赎、复仇、毒镖陷阱时触发，其他卡牌暂无效果
        /// 请尽量不要使用这个方法，以便重构
        /// </summary>
        /// <param name="p">场面</param>
        /// <param name="ownplay">是否自己打出</param>
        /// <param name="number">仅在猜以眼还眼时有效，值为受到的攻击</param>
        public virtual void onSecretPlay(Playfield p, bool ownplay, int number)
        {
            return;
        }


        /// <summary>
        /// 打出卡牌时的效果
        /// </summary>
        /// <param name="p">场面</param>
        /// <param name="ownplay">是否自己打出</param>
        /// <param name="target">选定目标</param>
        /// <param name="choice">选项（抉择、发现等）</param>
        public virtual void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            return;
        }

        public virtual void onCardPlay(Playfield p, bool ownplay, Minion target, int choice, Handmanager.Handcard hc)
        {
            return;
        }

        /// <summary>
        /// 流放效果（法术牌）
        /// </summary>
        /// <param name="p">场面</param>
        /// <param name="own">是否自己打出</param>
        public virtual void onCardPlay(Playfield p, bool ownplay, Minion target, int choice, bool outcast)
        {
            return;
        }
        /// <summary>
        /// 流放效果（随从牌）
        /// </summary>
        /// <param name="p">场面</param>
        /// <param name="m">随从</param>
        public virtual void onCardPlay(Playfield p, Minion own, bool ownplay, Minion target, int choice, bool outcast)
        {
            return;
        }


        /// <summary>
        /// 弃牌时触发
        /// </summary>
        /// <param name="p">场面</param>
        /// <param name="hc">被弃掉的手牌</param>
        /// <param name="own">仅当当前随从为玛克扎尔的小鬼时生效，值为当前随从（玛克扎尔的小鬼）</param>
        /// <param name="num">仅当当前随从为玛克扎尔的小鬼时生效，值为弃牌数量</param>
        /// <param name="checkBonus">是否检查额外效果。实际影响不明</param>
        /// <returns></returns>
        public virtual bool onCardDicscard(Playfield p, Handmanager.Handcard hc, Minion own, int num, bool checkBonus = false) 
        {
            return false;
        }


        /// <summary>
        /// 被弃时触发
        /// </summary>
        /// <param name="p">场面</param>
        /// <param name="hc">被弃掉的手牌</param>
        /// <returns></returns>
        public virtual void onHandCardRemoved(Playfield p, Handmanager.Handcard hc) 
        {
            return;
        }

        /// <summary>
        /// 战吼效果
        /// </summary>
        /// <param name="p">场面</param>
        /// <param name="own">随从</param>
        /// <param name="target">选定目标</param>
        /// <param name="choice">选项（抉择、发现等）</param>
        public virtual void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            return;
        }

        /// <summary>
        /// 光环类效果进场时触发
        /// </summary>
        /// <param name="p">场面</param>
        /// <param name="m">随从</param>
        public virtual void onAuraStarts(Playfield p, Minion m)
        {
            return;
        }

        /// <summary>
        /// 光环类效果离场时触发
        /// </summary>
        /// <param name="p">场面</param>
        /// <param name="m">随从</param>
        public virtual void onAuraEnds(Playfield p, Minion m)
        {
            return;
        }

        /// <summary>
        /// 流放效果（法术牌）
        /// </summary>
        /// <param name="p">场面</param>
        /// <param name="own">是否自己打出</param>
        public virtual void onOutcast(Playfield p, bool own)
        {
            return;
        }
        /// <summary>
        /// 流放效果（随从牌）
        /// </summary>
        /// <param name="p">场面</param>
        /// <param name="m">随从</param>
        public virtual void onOutcast(Playfield p, Minion m)
        {
            return;
        }

        /// <summary>
        /// 休眠结束起床效果
        /// </summary>
        /// <param name="p">场面</param>
        /// <param name="m">随从</param>
        public virtual void onDormantEndsTrigger(Playfield p, Minion m)
        {
            return;
        }

        /// <summary>
        /// 激怒效果
        /// </summary>
        /// <param name="p">场面</param>
        /// <param name="m">随从</param>
        public virtual void onEnrageStart(Playfield p, Minion m)
        {
            return;
        }

        /// <summary>
        /// 失去激怒效果
        /// </summary>
        /// <param name="p">场面</param>
        /// <param name="m">随从</param>
        public virtual void onEnrageStop(Playfield p, Minion m)
        {
            return;
        }

        /// <summary>
        /// 随从受到治疗效果效果，只在北郡牧师和法力晶簇上触发
        /// </summary>
        /// <param name="p">场面</param>
        /// <param name="triggerEffectMinion">特效随从（不是被治疗的随从）</param>
        /// <param name="minionsGotHealed">被治疗的随从的数量</param>
        public virtual void onAMinionGotHealedTrigger(Playfield p, Minion triggerEffectMinion, int minionsGotHealed)
        {
            return;
        }

        /// <summary>
        /// 英雄受到治疗效果，不会被触发，因此没有任何用
        /// </summary>
        /// <param name="p">场面</param>
        /// <param name="triggerEffectMinion">特效随从（不是被治疗的随从）</param>
        /// <param name="ownerOfHeroGotHealed">是否自己被治疗</param>
        public virtual void onAHeroGotHealedTrigger(Playfield p, Minion triggerEffectMinion, bool ownerOfHeroGotHealed)
        {
            return;
        }

        /// <summary>
        /// 任意角色受到治疗的效果，只在几个随从身上触发
        /// </summary>
        /// <param name="p">场面</param>
        /// <param name="triggerEffectMinion"></param>
        /// <param name="charsGotHealed"></param>
        public virtual void onACharGotHealed(Playfield p, Minion triggerEffectMinion, int charsGotHealed)
        {
            return;
        }

        /// <summary>
        /// 回合结束效果
        /// </summary>
        /// <param name="p">场面</param>
        /// <param name="triggerEffectMinion">有回合结束效果的随从</param>
        /// <param name="turnEndOfOwner">是否己方回合结束</param>
        public virtual void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            return;
        }

        /// <summary>
        /// 回合开始效果
        /// </summary>
        /// <param name="p">场面</param>
        /// <param name="triggerEffectMinion">有回合开始效果的随从</param>
        /// <param name="turnStartOfOwner">是否己方回合开始</param>
        public virtual void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            return;
        }

        public virtual void onMinionGotDmgTrigger(Playfield p, Minion triggerEffectMinion, int anzOwnMinionsGotDmg, int anzEnemyMinionsGotDmg, int anzOwnHeroGotDmg, int anzEnemyHeroGotDmg)
        {
            return;
        }

        public virtual void onMinionDiedTrigger(Playfield p, Minion triggerEffectMinion, Minion diedMinion)
        {
            return;
        }

        public virtual void onMinionIsSummoned(Playfield p, Minion triggerEffectMinion, Minion summonedMinion)
        {
            return;
        }

        public virtual void onMinionWasSummoned(Playfield p, Minion triggerEffectMinion, Minion summonedMinion)
        {
            return;
        }

        public virtual void onDeathrattle(Playfield p, Minion m)
        {
            return;
        }

        public virtual void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            return;
        }

        public virtual void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Handmanager.Handcard triggerhc)
        {
            return;
        }

        public virtual void onCardWasPlayed(Playfield p, CardDB.Card c, bool wasOwnCard, Minion triggerEffectMinion)
        {
            return;
        }

        public virtual void onInspire(Playfield p, Minion m, bool ownerOfInspire)
        {
            return;
        }

        public virtual void onMinionLosesDivineShield(Playfield p, Minion m, int num)
        {
            return;
        }

        public virtual void onHeroattack(Playfield p, Minion own, Minion target)//英雄攻击
        {
            return;
        }

        public virtual void onHeroattack(Playfield p, Minion triggerMinion, Minion target, Minion hero)
        {
            return;
        }

        /// <summary>
        /// 任务完成的效果
        /// </summary>
        /// <param name="p">场面</param>
        /// <param name="own">是否自己打出</param>
        public virtual void onQuestCompleteTrigger(Playfield p, bool own)
        {
            return;
        }

        public virtual int getDiscoverScore(Playfield p)
        {
            return 0;
        }


    }

}