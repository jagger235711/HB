namespace HREngine.Bots
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public struct triggerCounter
    {
        public int minionsGotHealed;

        public int charsGotHealed;

        public int ownMinionsGotDmg;
        public int enemyMinionsGotDmg;

        public int ownHeroGotDmg;
        public int enemyHeroGotDmg;

        public int ownMinionsDied;
        public int enemyMinionsDied;
        public int ownBeastSummoned;
        public int ownBeastDied;
        public int enemyBeastDied;
        public int ownMechanicDied;
        public int enemyMechanicDied;
        public int ownMurlocDied;
        public int enemyMurlocDied;
        public int ownMinionLosesDivineShield;
        public int enemyMinionLosesDivineShield;

        public bool ownMinionsChanged;
        public bool enemyMininsChanged;
    }

    public struct IDEnumOwner
    {
        public CardDB.cardIDEnum IDEnum;
        public bool own;
    }

    //todo save "started" variables outside (they doesnt change)
    //记录战场数据 标记
    public class Playfield
    {
        //Todo: delete all new list<minion> 删除所有新随从列表
        //TODO: graveyard change (list <card,owner>) 墓地改变
        //Todo: vanish clear all auras/buffs (NEW1_004) 消失清除所有buff
        public string name = "";
        public string enemyGuessDeck = "";
        public bool logging = false;
        public bool complete = false;
        public int bestBoard = 0;
        public bool dirtyTwoTurnSim = false;
        public bool checkLostAct = false;
        // 场攻
        public int totalAngr = -1;
        public int enemyTotalAngr = -1;

        // 可能有帕奇斯
        public bool patchesInDeck = true;
        public int ownMinionsDied = 0;
        public bool anzSolor = false;
        public int enemyMinionStartCount = 0;

        /// <summary>
        /// 本回合治疗或受伤次数，巨人用
        /// </summary>
        public int healOrDamageTimes = 0;
        public int healTimes = 0;

        public bool setMankrik = false;

        public int deckAngrBuff = 0;
        public int deckHpBuff = 0;

        public int nextEntity = 70;
        public int pID = 0;
        public bool isLethalCheck = false;
        public int enemyTurnsCount = 0;

        public triggerCounter tempTrigger = new triggerCounter();
        public Hrtprozis prozis = Hrtprozis.Instance;//对局信息
        public int gTurn = 0;
        public int gTurnStep = 0;

        // 灵魂残片
        public int AnzSoulFragments = 0;

        //aura minions########################## 光环随从
        //todo reduce buffing vars 减少buff效果
        //anz开头的都是某某随从的数量
        public int anzOwnRaidleader = 0;//团队领袖
        public int anzEnemyRaidleader = 0;
        public int anzOwnVessina = 0;
        public int anzEnemyVessina = 0;
        public int anzOwnStormwindChamps = 0;
        public int anzEnemyStormwindChamps = 0;
        public int anzOwnWarhorseTrainer = 0;
        public int anzEnemyWarhorseTrainer = 0;
        public int anzOwnTundrarhino = 0;
        public int anzEnemyTundrarhino = 0;
        //重拳先生
        public int anzOwnMrSmite =0;
        public int anzEnemyMrSmite = 0;
        //重拳先生
        public int anzOwnTimberWolfs = 0;
        public int anzEnemyTimberWolfs = 0;
        public int anzOwnMurlocWarleader = 0;
        public int anzEnemyMurlocWarleader = 0;
        public int anzAcidmaw = 0;
        public int anzOwnGrimscaleOracle = 0;
        public int anzEnemyGrimscaleOracle = 0;
        public int anzOwnShadowfiend = 0;
        public int anzOwnAuchenaiSoulpriest = 0;
        public int anzEnemyAuchenaiSoulpriest = 0;
        public int anzOwnSouthseacaptain = 0;
        public int anzEnemySouthseacaptain = 0;
        public int anzOwnMalGanis = 0;
        public int anzEnemyMalGanis = 0;
        public int anzOwnPiratesStarted = 0;
        public int anzOwnMurlocStarted = 0;
        public int anzOwnChromaggus = 0;
        public int anzEnemyChromaggus = 0;
        public int anzOwnDragonConsort = 0;
        public int anzOwnMurlocConsort = 0;     //酸小明
        public int anzOwnDragonConsortStarted = 0;

        //火光元素
        public int ownElementCost = 0;
        public int ownElementCostStarted = 0;
        //雷矛军用山羊
        public int ownBeastCostLessOnce = 0;
        public int ownBeastCostLessOnceStarted = 0;
        public int anzOwnBolfRamshield = 0;
        public int anzEnemyBolfRamshield = 0;
        public int anzOwnHorsemen = 0;
        public int anzEnemyHorsemen = 0;
        public int anzOwnAnimatedArmor = 0;
        public int anzEnemyAnimatedArmor = 0;
        public int anzMoorabi = 0;
        // 黑眼
        public int anzDark = 0;
        // 塔姆辛罗姆
        public int anzTamsinroame = 0;
        // 虚触侍从
        public int anzOldWoman = 0;
		
		//不死盟军
		public int usedUndeadAllies = 0;

        /// <summary>
        /// 坟场，已死亡随从，不包括弃牌
        /// </summary>
        public Dictionary<CardDB.cardIDEnum, int> ownGraveyard = new Dictionary<CardDB.cardIDEnum, int>();

        public bool anzTamsin = false;

        public int ownAbilityFreezesTarget = 0;
        public int enemyAbilityFreezesTarget = 0;
        public int ownHeroPowerCostLessOnce = 0;//英雄技能消耗更小一次
        public int ownHeroPowerCostLessTwice = 0;//英雄技能消耗更小两次
        public int ownDemonCostLessOnce = 0;
        public int enemyHeroPowerCostLessOnce = 0;
        public int ownHeroPowerExtraDamage = 0;
        public int enemyHeroPowerExtraDamage = 0;
        public int ownHeroPowerAllowedQuantity = 1;
        public int enemyHeroPowerAllowedQuantity = 1;
        public int anzUsedOwnHeroPower = 0;
        public int anzUsedEnemyHeroPower = 0;
        public int anzOwnExtraAngrHp = 0;
        public int anzEnemyExtraAngrHp = 0;

        public int anzOwnMechwarper = 0;
        public int anzOwnMechwarperStarted = 0;
        public int anzEnemyMechwarper = 0;
        public int anzEnemyMechwarperStarted = 0;

        public int anzOgOwnCThun = 0;
        public int anzOgOwnCThunHpBonus = 0;
        public int anzOgOwnCThunAngrBonus = 0;
        public int anzOgOwnCThunTaunt = 0;
        public int anzOwnJadeGolem = 0;
        public int anzEnemyJadeGolem = 0;
        public int anzOwnElementalsThisTurn = 0;
        public int anzOwnElementalsLastTurn = 0;  //上回合使用过元素
        public int useNature = 0;                  //特定牌在手中时触发是否使用过自然法术

        public int blackwaterpirate = 0;
        public int blackwaterpirateStarted = 0;
        public int embracetheshadow = 0;
        public int ownCrystalCore = 0;
        public bool ownMinionsInDeckCost0 = false;

        public bool LothraxionsPower = false;//使白银之手新兵获得圣盾标志位


        public int anzEnemyTaunt = 0;
        public int anzOwnTaunt = 0;
        public int ownMinionsDiedTurn = 0;
        public int enemyMinionsDiedTurn = 0;

        public bool feugenDead = false;
        public bool stalaggDead = false;

        public bool weHavePlayedMillhouseManastorm = false;
        public bool weHaveSteamwheedleSniper = false;
        public bool enemyHaveSteamwheedleSniper = false;
        public bool ownSpiritclaws = false;
        public bool enemySpiritclaws = false;

        public bool needGraveyard = false;


        public int doublepriest = 0;
        public int enemydoublepriest = 0;
        public int ownMistcaller = 0;

        public int lockandload = 0;
        public int stampede = 0;

        public int ownBaronRivendare = 0;
        public int enemyBaronRivendare = 0;
        public int ownBrannBronzebeard = 0;
        public int enemyBrannBronzebeard = 0;
        public int ownTurnEndEffectsTriggerTwice = 0;
        public int enemyTurnEndEffectsTriggerTwice = 0;
        public int ownFandralStaghelm = 0;
        //#########################################

        public int tempanzOwnCards = 0; // for Goblin Sapper
        public int tempanzEnemyCards = 0;// for Goblin Sapper

        public bool isOwnTurn = true; // its your turn?
        public int turnCounter = 0;

        public bool attacked = false;
        public int attackFaceHP = 15;

        public int ownController = 0;
        public int evaluatePenality = 0;
        public int ruleWeight = 0;
        public string rulesUsed = "";

        public bool useSecretsPlayAround = true;
        public bool print = false;

        public Int64 hashcode = 0;
        public float value = Int32.MinValue;
        public int guessingHeroHP = 30;
        public float doDirtyTts = 100000;

        public int mana = 0;
        public int manaTurnEnd = 0;

        public List<CardDB.cardIDEnum> ownSecretsIDList = new List<CardDB.cardIDEnum>();
        public List<SecretItem> enemySecretList = new List<SecretItem>();
        public Dictionary<CardDB.cardIDEnum, int> enemyCardsOut = null;

        public List<Playfield> nextPlayfields = new List<Playfield>();

        public int enemySecretCount = 0;

        public Minion ownHero;
        public Minion enemyHero;
        public HeroEnum ownHeroName = HeroEnum.None;
        public HeroEnum enemyHeroName = HeroEnum.None;
        public TAG_CLASS ownHeroStartClass = TAG_CLASS.INVALID;
        public TAG_CLASS enemyHeroStartClass = TAG_CLASS.INVALID;

        public Weapon ownWeapon = new Weapon();
        public Weapon enemyWeapon = new Weapon();

        public List<Minion> ownMinions = new List<Minion>();
        public List<Minion> enemyMinions = new List<Minion>();
        public List<GraveYardItem> diedMinions = null;
        public Dictionary<int, IDEnumOwner> LurkersDB = new Dictionary<int, IDEnumOwner>();
        public Questmanager.QuestItem ownQuest = new Questmanager.QuestItem();
        public Questmanager.QuestItem enemyQuest = new Questmanager.QuestItem();
        public Questmanager.QuestItem sideQuest = new Questmanager.QuestItem();


        public List<Handmanager.Handcard> owncards = new List<Handmanager.Handcard>();
        public int owncarddraw = 0;

        public List<Action> playactions = new List<Action>();
        public List<int> pIdHistory = new List<int>();

        public int enemycarddraw = 0;
        public int enemyAnzCards = 0;

        public int libram = 0;//圣契指示物
        public int spellpower = 0;
        public int spellpowerStarted = 0;
        public int enemyspellpower = 0;
        public int enemyspellpowerStarted = 0;
        public int wehaveCounterspell = 0;
        public int lethlMissing = 1000;

        public bool nextSecretThisTurnCost0 = false;
        public bool playedPreparation = false;
        public bool nextSpellThisTurnCost0 = false;
        public bool nextMurlocThisTurnCostHealth = false;
        public bool nextSpellThisTurnCostHealth = false;

        public bool loatheb = false;
        public int winzigebeschwoererin = 0;
        public int startedWithWinzigebeschwoererin = 0;
        // 钢鬃卫兵
        public int winRazormaneBattleguard = 0;
        public int startedRazormaneBattleguard = 0;
        public int managespenst = 0;
        public int startedWithManagespenst = 0;

        public int ownMinionsCostMore = 0;
        public int ownMinionsCostMoreAtStart = 0;
        public int ownSpelsCostMore = 0;
        public int ownSpelsCostMoreAtStart = 0;
        public int ownDRcardsCostMore = 0;
        public int ownDRcardsCostMoreAtStart = 0;



        public int beschwoerungsportal = 0;
        public int startedWithbeschwoerungsportal = 0;
        public int myCardsCostLess = 0;
        public int startedWithmyCardsCostLess = 0;
        public int anzOwnAviana = 0;
        public int anzOwnScargil = 0;
        public int anzOwnCloakedHuntress = 0;
        public int nerubarweblord = 0;
        public int startedWithnerubarweblord = 0;

        public bool startedWithDamagedMinions = false; // needed for manacalculation of the spell "Crush"

        public int ownWeaponAttackStarted = 0;
        public int ownMobsCountStarted = 0;
        public int ownCardsCountStarted = 0;
        public int enemyMobsCountStarted = 0;
        public int enemyCardsCountStarted = 0;
        public int ownHeroHpStarted = 30;
        public int enemyHeroHpStarted = 30;


        public int mobsplayedThisTurn = 0;
        public int startedWithMobsPlayedThisTurn = 0;
        public int spellsplayedSinceRecalc = 0;
        public int secretsplayedSinceRecalc = 0;

        public int optionsPlayedThisTurn = 0;
        public int cardsPlayedThisTurn = 0;
        public int ueberladung = 0;
        public int lockedMana = 0;

        public int enemyOptionsDoneThisTurn = 0;

        public int ownMaxMana = 0;
        public int enemyMaxMana = 0;

        public int lostDamage = 0;
        public int lostHeal = 0;
        public int lostWeaponDamage = 0;

        public int ownDeckSize = 30;
        public int enemyDeckSize = 30;
        public int ownHeroFatigue = 0;
        public int enemyHeroFatigue = 0;

        public bool ownAbilityReady = false;
        public Handmanager.Handcard ownHeroAblility;

        public bool enemyAbilityReady = false;
        public Handmanager.Handcard enemyHeroAblility;
        public Playfield bestEnemyPlay = null;
        public Playfield endTurnState = null;

        // just for saving which minion to revive with secrets (=the first one that died);
        public CardDB.cardIDEnum revivingOwnMinion = CardDB.cardIDEnum.None;
        public CardDB.cardIDEnum revivingEnemyMinion = CardDB.cardIDEnum.None;
        public CardDB.cardIDEnum OwnLastDiedMinion = CardDB.cardIDEnum.None;

        public int shadowmadnessed = 0; //minions has switched controllers this turn.

        public int enemyHeroTurnStartedHp = 0;
        public int ownHeroTurnStartedHp = 0;

        public void addCorpses(int count)
        {
            if (!this.ownGraveyard.ContainsKey(CardDB.cardIDEnum.CS2_122))
                this.ownGraveyard.Add(CardDB.cardIDEnum.CS2_122, count);
            else
                this.ownGraveyard[CardDB.cardIDEnum.CS2_122] += count;
        }

        public void corpseConsumption(int count)
        {
            Dictionary<CardDB.cardIDEnum, int> tempOwnGraveyard = new Dictionary<CardDB.cardIDEnum, int>();
            foreach (var item in this.ownGraveyard)
            {
                if (CardDB.Instance.getCardDataFromID(item.Key).type == CardDB.cardtype.MOB)
                {
                    if (item.Value > count)
                    {
                        int temp = item.Value - count;
                        this.ownGraveyard[item.Key] = temp;
                        break;
                    }
                    else if (item.Value == count)
                    {
                        count = count - item.Value;
                        tempOwnGraveyard.Add(item.Key, item.Value);
                        break;
                    }
                    else
                    {
                        count = count - item.Value;
                        tempOwnGraveyard.Add(item.Key, item.Value);
                    }
                }
            }

            foreach (var item in tempOwnGraveyard)
            {
                this.ownGraveyard.Remove(item.Key);
            }

        }
        //获取尸体数量
        public int getCorpseCount()
        {
            int retCount = 0;
            foreach (var item in this.ownGraveyard)
            {
                if (CardDB.Instance.getCardDataFromID(item.Key).type == CardDB.cardtype.MOB)
                {
                    retCount += item.Value;
                }
            }
            return retCount;
        }


        private void addMinionsReal(List<Minion> source, List<Minion> trgt)
        {
            foreach (Minion m in source)
            {
                trgt.Add(new Minion(m));
            }

        }

        private void addCardsReal(List<Handmanager.Handcard> source)
        {

            foreach (Handmanager.Handcard hc in source)
            {
                this.owncards.Add(new Handmanager.Handcard(hc));
            }

        }

        /// <summary>
        /// 当前回合第0步操作或重新计算时会读取场面获得初始的 p，光环效果要初始化
        /// </summary>
        public Playfield()
        {//初始化 
            this.value = int.MinValue;

            this.deckAngrBuff = 0;
            this.deckHpBuff = 0;
            this.patchesInDeck = true;

            this.healOrDamageTimes = 0;
            this.healTimes = 0;
            this.totalAngr = -1;
            this.enemyTotalAngr = -1;
            this.ownMinionsDied = 0;

            this.setMankrik = false;
            this.anzSolor = false;
            this.enemyMinionStartCount = 0;
            this.pID = prozis.getPid();
            if (this.print)
            {
                this.pIdHistory.Add(pID);
            }
            this.nextEntity = 1000;
            this.isLethalCheck = false;
            this.ownController = prozis.getOwnController();

            this.libram = 0;
            this.gTurn = (prozis.gTurn + 1) / 2;
            this.gTurnStep = prozis.gTurnStep;
            this.mana = prozis.currentMana;
            this.manaTurnEnd = this.mana;
            this.ownMaxMana = prozis.ownMaxMana;
            this.enemyMaxMana = prozis.enemyMaxMana;
            this.evaluatePenality = 0;
            this.ruleWeight = 0;
            this.rulesUsed = "";
            this.ownSecretsIDList.AddRange(prozis.ownSecretList);
            this.enemySecretCount = prozis.enemySecretCount;

            this.anzOgOwnCThunAngrBonus = prozis.anzOgOwnCThunAngrBonus;
            this.anzOgOwnCThunHpBonus = prozis.anzOgOwnCThunHpBonus;
            this.anzOgOwnCThunTaunt = prozis.anzOgOwnCThunTaunt;
            this.anzOwnJadeGolem = prozis.anzOwnJadeGolem;
            this.anzEnemyJadeGolem = prozis.anzEnemyJadeGolem;
            this.OwnLastDiedMinion = prozis.OwnLastDiedMinion;
            this.anzOwnElementalsThisTurn = prozis.anzOwnElementalsThisTurn;
            this.anzOwnElementalsLastTurn = prozis.anzOwnElementalsLastTurn;
            this.useNature = prozis.useNature;

            this.attackFaceHP = prozis.attackFaceHp;

            this.complete = false;

            this.ownHero = new Minion(prozis.ownHero);
            this.enemyHero = new Minion(prozis.enemyHero);
            this.ownWeapon = new Weapon(prozis.ownWeapon);
            this.enemyWeapon = new Weapon(prozis.enemyWeapon);

            AnzSoulFragments = prozis.turnDeck.ContainsKey(CardDB.cardIDEnum.SCH_307t) ? prozis.turnDeck[CardDB.cardIDEnum.SCH_307t] : 0;

            this.anzTamsin = prozis.anzTamsin;

            foreach(var item in Probabilitymaker.Instance.ownGraveyard)
            {
                if (!this.ownGraveyard.ContainsKey(item.Key) && CardDB.Instance.getCardDataFromID(item.Key).type == CardDB.cardtype.MOB)
                {
                    this.ownGraveyard.Add(item.Key, item.Value);
                }
            }

            addMinionsReal(prozis.ownMinions, ownMinions);
            addMinionsReal(prozis.enemyMinions, enemyMinions);
            addCardsReal(Handmanager.Instance.handCards);
            this.LurkersDB = new Dictionary<int, IDEnumOwner>(prozis.LurkersDB);

            this.enemySecretList.Clear();
            this.useSecretsPlayAround = true;
            foreach (SecretItem si in Probabilitymaker.Instance.enemySecrets) // 敌方可能的奥秘
            {
                this.enemySecretList.Add(new SecretItem(si));
            }

            this.ownHeroName = prozis.heroname;
            this.enemyHeroName = prozis.enemyHeroname;
            this.ownHeroStartClass = prozis.ownHeroStartClass;
            this.enemyHeroStartClass = prozis.enemyHeroStartClass;
            //####buffs#############################

            this.anzOwnRaidleader = 0;
            this.anzEnemyRaidleader = 0;
            this.anzOwnVessina = 0;
            this.anzEnemyVessina = 0;
            this.anzOwnStormwindChamps = 0;
            this.anzEnemyStormwindChamps = 0;
            this.anzOwnAnimatedArmor = 0;
            this.anzEnemyAnimatedArmor = 0;
            this.anzMoorabi = 0;
            this.anzDark = 0;
            this.anzTamsinroame = 0;
            this.anzOldWoman = 0;
			this.usedUndeadAllies = 0;
            this.anzOwnExtraAngrHp = 0;
            this.anzEnemyExtraAngrHp = 0;
            this.anzOwnWarhorseTrainer = 0;
            this.anzEnemyWarhorseTrainer = 0;
            this.anzOwnTundrarhino = 0;
            this.anzEnemyTundrarhino = 0;
            //重拳先生
            this.anzOwnMrSmite = 0;
            this.anzEnemyMrSmite = 0;
            //重拳先生
            this.anzOwnTimberWolfs = 0;
            this.anzEnemyTimberWolfs = 0;
            this.anzOwnMurlocWarleader = 0;
            this.anzEnemyMurlocWarleader = 0;
            this.anzAcidmaw = 0;
            this.anzOwnGrimscaleOracle = 0;
            this.anzEnemyGrimscaleOracle = 0;
            this.anzOwnShadowfiend = 0;
            this.anzOwnAuchenaiSoulpriest = 0;
            this.anzEnemyAuchenaiSoulpriest = 0;
            this.anzOwnSouthseacaptain = 0;
            this.anzEnemySouthseacaptain = 0;
            this.anzOwnDragonConsortStarted = 0;
            //火光元素
            this.ownElementCostStarted = 0;
            //雷矛军用山羊
            this.ownBeastCostLessOnceStarted = 0;
            this.anzOwnPiratesStarted = 0;
            this.anzOwnMurlocStarted = 0;

            this.ownAbilityFreezesTarget = 0;
            this.enemyAbilityFreezesTarget = 0;
            this.ownDemonCostLessOnce = 0;
            this.ownHeroPowerCostLessOnce = 0;
            this.ownHeroPowerCostLessTwice = 0;
            this.enemyHeroPowerCostLessOnce = 0;
            this.ownHeroPowerExtraDamage = 0;
            this.enemyHeroPowerExtraDamage = 0;
            this.ownHeroPowerAllowedQuantity = 1;
            this.enemyHeroPowerAllowedQuantity = 1;
            this.anzUsedOwnHeroPower = 0;
            this.anzUsedEnemyHeroPower = 0;

            this.anzEnemyTaunt = 0;
            this.anzOwnTaunt = 0;
            this.ownMinionsDiedTurn = 0;
            this.enemyMinionsDiedTurn = 0;

            this.feugenDead = Probabilitymaker.Instance.feugenDead;
            this.stalaggDead = Probabilitymaker.Instance.stalaggDead;

            this.weHavePlayedMillhouseManastorm = false;

            this.doublepriest = 0;
            this.enemydoublepriest = 0;
            this.ownMistcaller = 0;

            this.lockandload = 0;
            this.stampede = 0;

            this.ownBaronRivendare = 0;
            this.enemyBaronRivendare = 0;
            this.ownBrannBronzebeard = 0;
            this.enemyBrannBronzebeard = 0;
            this.ownTurnEndEffectsTriggerTwice = 0;
            this.enemyTurnEndEffectsTriggerTwice = 0;
            this.ownFandralStaghelm = 0;
            //#########################################

            this.enemycarddraw = 0;
            this.owncarddraw = 0;

            this.enemyAnzCards = Handmanager.Instance.enemyAnzCards;

            this.ownAbilityReady = prozis.ownAbilityisReady;
            this.ownHeroAblility = new Handmanager.Handcard { card = prozis.heroAbility, manacost = prozis.ownHeroPowerCost };
            this.enemyHeroAblility = new Handmanager.Handcard { card = prozis.enemyAbility, manacost = prozis.enemyHeroPowerCost };
            this.enemyAbilityReady = false;
            this.bestEnemyPlay = null;

            this.ownQuest.Copy(Questmanager.Instance.ownQuest);
            this.enemyQuest.Copy(Questmanager.Instance.enemyQuest);
            this.sideQuest.Copy(Questmanager.Instance.sideQuest);

            this.mobsplayedThisTurn = prozis.numMinionsPlayedThisTurn;
            this.startedWithMobsPlayedThisTurn = prozis.numMinionsPlayedThisTurn;// only change mobsplayedthisturm
            this.cardsPlayedThisTurn = prozis.cardsPlayedThisTurn;
            this.spellsplayedSinceRecalc = 0;
            this.secretsplayedSinceRecalc = 0;
            this.optionsPlayedThisTurn = prozis.numOptionsPlayedThisTurn;

            this.ueberladung = prozis.ueberladung;
            this.lockedMana = prozis.lockedMana;

            this.ownHeroFatigue = prozis.ownHeroFatigue;
            this.enemyHeroFatigue = prozis.enemyHeroFatigue;
            this.ownDeckSize = prozis.ownDeckSize;
            this.enemyDeckSize = prozis.enemyDeckSize;

            //need the following for manacost-calculation
            this.ownHeroHpStarted = this.ownHero.Hp;
            this.enemyHeroHpStarted = this.enemyHero.Hp;
            this.ownWeaponAttackStarted = this.ownWeapon.Angr;
            this.ownCardsCountStarted = this.owncards.Count;
            this.enemyCardsCountStarted = this.enemyAnzCards;
            this.ownMobsCountStarted = this.ownMinions.Count;
            this.enemyMobsCountStarted = this.enemyMinions.Count;

            this.nextSecretThisTurnCost0 = false;
            this.playedPreparation = false;
            this.nextSpellThisTurnCost0 = false;
            this.nextMurlocThisTurnCostHealth = false;
            this.nextSpellThisTurnCostHealth = false;
            this.winzigebeschwoererin = 0;
            this.winRazormaneBattleguard = 0;
            this.managespenst = 0;
            this.beschwoerungsportal = 0;
            this.anzOwnAviana = 0;
            this.anzOwnScargil = 0;
            this.anzOwnCloakedHuntress = 0;
            this.nerubarweblord = 0;
            this.myCardsCostLess = 0;

            this.startedWithmyCardsCostLess = 0;
            this.startedWithnerubarweblord = 0;
            this.startedWithbeschwoerungsportal = 0;
            this.startedWithManagespenst = 0;
            this.startedWithWinzigebeschwoererin = 0;
            this.startedRazormaneBattleguard = 0;

            this.blackwaterpirate = 0;
            this.blackwaterpirateStarted = 0;
            this.embracetheshadow = 0;
            this.ownCrystalCore = prozis.ownCrystalCore;
            this.ownMinionsInDeckCost0 = prozis.ownMinionsInDeckCost0;
            this.LothraxionsPower = prozis.LothraxionsPower;


            needGraveyard = true;
            this.loatheb = false;
            this.spellpower = 0;
            this.spellpowerStarted = 0;
            this.enemyspellpower = 0;
            this.enemyspellpowerStarted = 0;

            this.startedWithDamagedMinions = false;

            this.enemyHeroTurnStartedHp = this.enemyHero.Hp;
            this.ownHeroTurnStartedHp = this.ownHero.Hp;
            

            //我方特殊随从的效果标志位 站场效果
            foreach (Minion m in this.ownMinions)
            {
                // 计算鱼人恩典
                if (!m.untouchable && (m.handcard.card.race == CardDB.Race.MURLOC || m.handcard.card.race == CardDB.Race.ALL)) this.anzOwnMurlocStarted++;
                if (!m.untouchable && (m.handcard.card.race == CardDB.Race.PIRATE || m.handcard.card.race == CardDB.Race.ALL)) this.anzOwnPiratesStarted++;//Pirates海盗

                if (m.Hp < m.maxHp && m.Hp >= 1) this.startedWithDamagedMinions = true;

                this.spellpowerStarted += m.spellpower;//法强
                if (m.silenced) continue;
                this.spellpowerStarted += m.handcard.card.spellpowervalue;
                this.spellpower = this.spellpowerStarted;
                if (m.taunt) anzOwnTaunt++;

                switch (m.name)
                {//用来写 触发标记的随从
                    case CardDB.cardNameEN.blackwaterpirate://黑水海盗
                        this.blackwaterpirate++;
                        this.blackwaterpirateStarted++;
                        continue;
                    case CardDB.cardNameEN.chogall://古加尔
                        if (m.playedThisTurn && this.cardsPlayedThisTurn == this.mobsplayedThisTurn) this.nextSpellThisTurnCostHealth = true;
                        continue;
                    //case CardDB.cardName.seadevilstinger://海魔钉刺者
                    //    if (m.playedThisTurn && this.cardsPlayedThisTurn == this.mobsplayedThisTurn) this.nextMurlocThisTurnCostHealth = true; 
                    //    continue;
                    case CardDB.cardNameEN.prophetvelen://先知维纶
                        this.doublepriest++;//双倍牧师
                        continue;
                    case CardDB.cardNameEN.themistcaller:
                        this.ownMistcaller++;//随从+1+1
                        continue;
                    case CardDB.cardNameEN.pintsizedsummoner://小个子召唤师
                        this.winzigebeschwoererin++;
                        this.startedWithWinzigebeschwoererin++;
                        continue;
                    case CardDB.cardNameEN.razormanebattleguard://卫兵
                        this.winRazormaneBattleguard++;
                        this.startedRazormaneBattleguard++;
                        continue;
                    case CardDB.cardNameEN.manawraith:
                        this.managespenst++;//法力怨魂
                        this.startedWithManagespenst++;
                        continue;
                    case CardDB.cardNameEN.nerubarweblord://尼鲁巴蛛网领主
                        this.nerubarweblord++;
                        this.startedWithnerubarweblord++;
                        continue;
                    case CardDB.cardNameEN.venturecomercenary:  //风险投资公司雇佣兵                      
                        this.ownMinionsCostMore += 3;
                        this.ownMinionsCostMoreAtStart += 3;
                        continue;
                    case CardDB.cardNameEN.corpsewidow://巨型尸蛛
                        this.ownDRcardsCostMore -= 2;
                        this.ownDRcardsCostMoreAtStart -= 2;
                        continue;
                    case CardDB.cardNameEN.summoningportal://召唤传送门
                        this.beschwoerungsportal++;
                        this.startedWithbeschwoerungsportal++;
                        continue;
                    case CardDB.cardNameEN.vaelastrasz://瓦拉斯塔兹
                        this.myCardsCostLess += 3;//卡牌法力值消耗减少3
                        this.startedWithmyCardsCostLess += 3;
                        continue;
                    case CardDB.cardNameEN.scargil: // 斯卡基尔
                        this.anzOwnScargil++;
                        continue;
                    case CardDB.cardNameEN.aviana://艾维娜
                        this.anzOwnAviana++;
                        continue;
                    case CardDB.cardNameEN.cloakedhuntress://神秘女猎手
                        this.anzOwnCloakedHuntress++;
                        continue;
                    case CardDB.cardNameEN.baronrivendare://瑞文戴尔男爵
                        this.ownBaronRivendare++;
                        continue;
                    case CardDB.cardNameEN.brannbronzebeard://布莱恩·铜须
                        this.ownBrannBronzebeard++;
                        continue;
                    case CardDB.cardNameEN.drakkarienchanter://达卡莱附魔师
                        this.ownTurnEndEffectsTriggerTwice++;
                        continue;
                    case CardDB.cardNameEN.fandralstaghelm://范达尔·鹿盔
                        this.ownFandralStaghelm++;
                        continue;
                    case CardDB.cardNameEN.loatheb://洛欧塞布
                        if (m.playedThisTurn) this.loatheb = true;
                        continue;
                    case CardDB.cardNameEN.kelthuzad://克尔苏加德
                        this.needGraveyard = true;
                        continue;
                    case CardDB.cardNameEN.leokk://雷欧克
                        this.anzOwnRaidleader++;
                        continue;
                    case CardDB.cardNameEN.raidleader://团队领袖
                        this.anzOwnRaidleader++;
                        continue;
                    case CardDB.cardNameEN.vessina://维西纳
                        this.anzOwnVessina++;
                        continue;
                    case CardDB.cardNameEN.warhorsetrainer://战马训练师
                        this.anzOwnWarhorseTrainer++;
                        continue;
                    case CardDB.cardNameEN.fallenhero://英雄之魂
                        this.ownHeroPowerExtraDamage++;
                        continue;
                    case CardDB.cardNameEN.garrisoncommander://要塞指挥官
                        bool another = false;
                        foreach (Minion mnn in this.ownMinions)
                        {
                            if (mnn.name == CardDB.cardNameEN.garrisoncommander && mnn.entitiyID != m.entitiyID) another = true;
                        }
                        if (!another) this.ownHeroPowerAllowedQuantity++;
                        continue;
                    case CardDB.cardNameEN.coldarradrake://考达拉幼龙
                        this.ownHeroPowerAllowedQuantity += 100;
                        continue;
                    case CardDB.cardNameEN.mindbreaker://摧心者
                        this.ownHeroAblility.manacost = 100;
                        this.enemyHeroAblility.manacost = 100;
                        this.ownAbilityReady = false;
                        this.ownAbilityReady = false;
                        continue;
                    case CardDB.cardNameEN.malganis://玛尔加尼斯
                        this.anzOwnMalGanis++;
                        continue;
                    case CardDB.cardNameEN.bolframshield://博尔夫·碎盾
                        this.anzOwnBolfRamshield++;
                        continue;
                    case CardDB.cardNameEN.ladyblaumeux://女公爵布劳缪克丝 冒险卡
                        this.anzOwnHorsemen++;
                        continue;
                    case CardDB.cardNameEN.thanekorthazz://库尔塔兹领主 冒险
                        this.anzOwnHorsemen++;
                        continue;
                    case CardDB.cardNameEN.sirzeliek://瑟里耶克爵士 冒险
                        this.anzOwnHorsemen++;
                        continue;
                    case CardDB.cardNameEN.stormwindchampion://暴风城勇士
                        this.anzOwnStormwindChamps++;
                        continue;
                    case CardDB.cardNameEN.animatedarmor://复活的铠甲
                        this.anzOwnAnimatedArmor++;
                        continue;
                    case CardDB.cardNameEN.moorabi://莫拉比
                        this.anzMoorabi++;
                        continue;
                    case CardDB.cardNameEN.darkglare://黑眼
                        this.anzDark++;
                        continue;
                    case CardDB.cardNameEN.tamsinroame: //塔姆辛罗姆
                        this.anzTamsinroame++;
                        continue;
                    case CardDB.cardNameEN.voidtouchedattendant: //虚触侍从
                        this.anzOldWoman++;
                        continue;
                    case CardDB.cardNameEN.tundrarhino://苔原犀牛
                        this.anzOwnTundrarhino++;
                        continue;
                    case CardDB.cardNameEN.mrsmite://重拳先生
                        this.anzOwnMrSmite ++;
                        continue;
                    case CardDB.cardNameEN.timberwolf://森林狼
                        this.anzOwnTimberWolfs++;
                        continue;
                    case CardDB.cardNameEN.murlocwarleader://鱼人领军
                        this.anzOwnMurlocWarleader++;
                        continue;
                    case CardDB.cardNameEN.acidmaw://酸喉
                        this.anzAcidmaw++;
                        continue;
                    case CardDB.cardNameEN.grimscaleoracle://暗鳞先知
                        this.anzOwnGrimscaleOracle++;
                        continue;
                    case CardDB.cardNameEN.shadowfiend://暗影魔
                        this.anzOwnShadowfiend++;
                        continue;
                    case CardDB.cardNameEN.auchenaisoulpriest://奥金尼灵魂祭司
                        this.anzOwnAuchenaiSoulpriest++;
                        continue;
                    case CardDB.cardNameEN.radiantelemental: goto case CardDB.cardNameEN.sorcerersapprentice;//光照元素
                    case CardDB.cardNameEN.sorcerersapprentice://巫师学徒
                        this.ownSpelsCostMore--;
                        this.ownSpelsCostMoreAtStart--;
                        continue;
                    case CardDB.cardNameEN.nerubianunraveler:  //     蛛魔拆解者                 
                        this.ownSpelsCostMore += 2;
                        this.ownSpelsCostMoreAtStart += 2;
                        continue;
                    case CardDB.cardNameEN.electron://电荷金刚
                        this.ownSpelsCostMore -= 3;
                        this.ownSpelsCostMoreAtStart -= 3;
                        continue;
                    case CardDB.cardNameEN.icewalker://寒冰行者
                        this.ownAbilityFreezesTarget++;
                        continue;
                    case CardDB.cardNameEN.southseacaptain://南海船长
                        this.anzOwnSouthseacaptain++;
                        continue;
                    case CardDB.cardNameEN.chromaggus://克洛玛古斯
                        this.anzOwnChromaggus++;
                        continue;
                    case CardDB.cardNameEN.mechwarper://机械跃迁者
                        this.anzOwnMechwarper++;
                        this.anzOwnMechwarperStarted++;
                        continue;
                    case CardDB.cardNameEN.steamwheedlesniper://热砂港狙击手
                        this.weHaveSteamwheedleSniper = true;
                        continue;
                    default:
                        break;
                }


            }

            foreach (Handmanager.Handcard hc in this.owncards)
            {

                if (hc.card.nameEN == CardDB.cardNameEN.kelthuzad)//克总
                {
                    this.needGraveyard = true;
                }
            }

            foreach (Minion m in this.enemyMinions)
            {//敌方特殊随从的效果标志位
                this.enemyMinionStartCount++;
                this.enemyspellpowerStarted += m.spellpower;
                if (m.silenced) continue;
                this.enemyspellpowerStarted += m.handcard.card.spellpowervalue;
                this.enemyspellpower = this.enemyspellpowerStarted;
                if (m.taunt) anzEnemyTaunt++;

                switch (m.name)
                {
                    case CardDB.cardNameEN.voidtouchedattendant:
                        this.anzOldWoman++;
                        continue;
                    case CardDB.cardNameEN.baronrivendare:
                        this.enemyBaronRivendare++;
                        continue;
                    case CardDB.cardNameEN.brannbronzebeard:
                        this.enemyBrannBronzebeard++;
                        continue;
                    case CardDB.cardNameEN.drakkarienchanter:
                        this.enemyTurnEndEffectsTriggerTwice++;
                        continue;
                    case CardDB.cardNameEN.kelthuzad:
                        this.needGraveyard = true;
                        continue;
                    case CardDB.cardNameEN.prophetvelen:
                        this.enemydoublepriest++;
                        continue;
                    case CardDB.cardNameEN.manawraith:
                        this.managespenst++;
                        this.startedWithManagespenst++;
                        continue;
                    case CardDB.cardNameEN.electron:
                        this.ownSpelsCostMore -= 3;
                        this.ownSpelsCostMoreAtStart -= 3;
                        continue;
                    case CardDB.cardNameEN.doomedapprentice:
                        this.ownSpelsCostMore++;
                        this.ownSpelsCostMoreAtStart++;
                        continue;
                    case CardDB.cardNameEN.nerubarweblord:
                        this.nerubarweblord++;
                        this.startedWithnerubarweblord++;
                        continue;
                    case CardDB.cardNameEN.garrisoncommander:
                        bool another = false;
                        foreach (Minion mnn in this.enemyMinions)
                        {
                            if (mnn.name == CardDB.cardNameEN.garrisoncommander && mnn.entitiyID != m.entitiyID) another = true;
                        }
                        if (!another) this.enemyHeroPowerAllowedQuantity++;
                        continue;
                    case CardDB.cardNameEN.coldarradrake:
                        this.enemyHeroPowerAllowedQuantity += 100;
                        continue;
                    case CardDB.cardNameEN.mindbreaker:
                        this.ownHeroAblility.manacost = 100;
                        this.enemyHeroAblility.manacost = 100;
                        this.ownAbilityReady = false;
                        this.ownAbilityReady = false;
                        continue;
                    case CardDB.cardNameEN.fallenhero:
                        this.enemyHeroPowerExtraDamage++;
                        continue;
                    case CardDB.cardNameEN.leokk:
                        this.anzEnemyRaidleader++;
                        continue;
                    case CardDB.cardNameEN.raidleader:
                        this.anzEnemyRaidleader++;
                        continue;
                    case CardDB.cardNameEN.vessina:
                        this.anzEnemyVessina++;
                        continue;
                    case CardDB.cardNameEN.warhorsetrainer:
                        this.anzEnemyWarhorseTrainer++;
                        continue;
                    case CardDB.cardNameEN.malganis:
                        this.anzEnemyMalGanis++;
                        continue;
                    case CardDB.cardNameEN.bolframshield:
                        this.anzEnemyBolfRamshield++;
                        continue;
                    case CardDB.cardNameEN.ladyblaumeux:
                        this.anzEnemyHorsemen++;
                        continue;
                    case CardDB.cardNameEN.thanekorthazz:
                        this.anzEnemyHorsemen++;
                        continue;
                    case CardDB.cardNameEN.sirzeliek:
                        this.anzEnemyHorsemen++;
                        continue;
                    case CardDB.cardNameEN.stormwindchampion:
                        this.anzEnemyStormwindChamps++;
                        continue;
                    case CardDB.cardNameEN.animatedarmor:
                        this.anzEnemyAnimatedArmor++;
                        continue;
                    case CardDB.cardNameEN.moorabi:
                        this.anzMoorabi++;
                        continue;
                    case CardDB.cardNameEN.tundrarhino:
                        this.anzEnemyTundrarhino++;
                        continue;
                    case CardDB.cardNameEN.mrsmite:
                        this.anzEnemyMrSmite++;
                        continue;
                    case CardDB.cardNameEN.timberwolf:
                        this.anzEnemyTimberWolfs++;
                        continue;
                    case CardDB.cardNameEN.murlocwarleader:
                        this.anzEnemyMurlocWarleader++;
                        continue;
                    case CardDB.cardNameEN.acidmaw:
                        this.anzAcidmaw++;
                        continue;
                    case CardDB.cardNameEN.grimscaleoracle:
                        this.anzEnemyGrimscaleOracle++;
                        continue;
                    case CardDB.cardNameEN.auchenaisoulpriest:
                        this.anzEnemyAuchenaiSoulpriest++;
                        continue;
                    case CardDB.cardNameEN.steamwheedlesniper:
                        this.enemyHaveSteamwheedleSniper = true;
                        continue;

                    case CardDB.cardNameEN.icewalker:
                        this.enemyAbilityFreezesTarget++;
                        continue;
                    case CardDB.cardNameEN.southseacaptain:
                        this.anzEnemySouthseacaptain++;
                        continue;
                    case CardDB.cardNameEN.chromaggus:
                        this.anzEnemyChromaggus++;
                        continue;
                    case CardDB.cardNameEN.mechwarper:
                        this.anzEnemyMechwarper++;
                        this.anzEnemyMechwarperStarted++;
                        continue;
                }
            }

            if (this.spellpowerStarted > 0) this.ownSpiritclaws = true;//幽灵爪加攻
            if (this.enemyspellpowerStarted > 0) this.enemySpiritclaws = true;

            if (this.enemySecretCount >= 1) this.needGraveyard = true;
            if (this.needGraveyard) this.diedMinions = new List<GraveYardItem>(Probabilitymaker.Instance.turngraveyard);//墓地

            this.tempanzOwnCards = this.owncards.Count;//手牌数
            this.tempanzEnemyCards = this.enemyAnzCards;


            this.value = int.MinValue;
            deckGuess.guessEnemyDeck(this);
            this.enemyGuessDeck = Hrtprozis.Instance.enemyDeckName;
        }

        /// <summary>
        /// 后续计算从之前的 p 继承数据，光环效果从之前继承，因此 sim 中需要对光环做相应处理
        /// </summary>
        /// <param name="p"></param>
        /// <param name="transToEnemy">改为用对手的视角来看</param>
        public Playfield(Playfield p, bool transToEnemy = false)
        {
            this.value = int.MinValue;
            this.enemyGuessDeck = p.enemyGuessDeck;

            this.enemyHeroTurnStartedHp = p.enemyHeroTurnStartedHp;
            this.ownHeroTurnStartedHp = p.ownHeroTurnStartedHp;
            this.pID = prozis.getPid();
            if (p.print)
            {
                this.print = true;
                this.pIdHistory.AddRange(p.pIdHistory);
                this.pIdHistory.Add(pID);
                this.doDirtyTts = p.doDirtyTts;
                this.dirtyTwoTurnSim = p.dirtyTwoTurnSim;
                this.checkLostAct = p.checkLostAct;
                this.enemyTurnsCount = p.enemyTurnsCount;
            }
            this.isLethalCheck = p.isLethalCheck;
            this.nextEntity = p.nextEntity;
            this.patchesInDeck = p.patchesInDeck;
            this.anzDark = p.anzDark;
            this.anzTamsinroame = p.anzTamsinroame;
            this.healOrDamageTimes = p.healOrDamageTimes;
            this.healTimes = p.healTimes;
            this.totalAngr = -1;
            this.enemyTotalAngr = -1;
            this.ownMinionsDied = p.ownMinionsDied;
            this.setMankrik = p.setMankrik;
            this.anzSolor = p.anzSolor;
            this.enemyMinionStartCount = p.enemyMinionStartCount;
            this.deckAngrBuff = p.deckAngrBuff;
            this.deckHpBuff = p.deckHpBuff;

            this.isOwnTurn = p.isOwnTurn;
            this.turnCounter = p.turnCounter;
            this.gTurn = p.gTurn;
            this.gTurnStep = p.gTurnStep;

            this.AnzSoulFragments = p.AnzSoulFragments;
            this.anzOldWoman = p.anzOldWoman;
			this.usedUndeadAllies = p.usedUndeadAllies;

            this.anzTamsin = p.anzTamsin;

            foreach (var item in p.ownGraveyard)
            {
                if (!this.ownGraveyard.ContainsKey(item.Key) && CardDB.Instance.getCardDataFromID(item.Key).type == CardDB.cardtype.MOB)
                {
                    this.ownGraveyard.Add(item.Key, item.Value);
                }
            }

            this.anzOgOwnCThunAngrBonus = p.anzOgOwnCThunAngrBonus;
            this.anzOgOwnCThunHpBonus = p.anzOgOwnCThunHpBonus;
            this.anzOgOwnCThunTaunt = p.anzOgOwnCThunTaunt;
            this.anzOwnJadeGolem = p.anzOwnJadeGolem;
            this.anzEnemyJadeGolem = p.anzEnemyJadeGolem;
            this.anzOwnElementalsThisTurn = p.anzOwnElementalsThisTurn;
            this.anzOwnElementalsLastTurn = p.anzOwnElementalsLastTurn;
            this.attacked = p.attacked;
            this.ownController = p.ownController;
            this.bestEnemyPlay = p.bestEnemyPlay;
            this.endTurnState = p.endTurnState;

            this.ownSecretsIDList.AddRange(p.ownSecretsIDList);
            this.evaluatePenality = p.evaluatePenality;
            this.ruleWeight = p.ruleWeight;
            this.rulesUsed = p.rulesUsed;


            this.enemySecretList.Clear();
            if (p.useSecretsPlayAround)
            {
                this.useSecretsPlayAround = true;
                foreach (SecretItem si in p.enemySecretList)
                {
                    this.enemySecretList.Add(new SecretItem(si));
                }
            }

            this.mana = p.mana;
            this.manaTurnEnd = p.manaTurnEnd;
            
            if (p.LurkersDB.Count > 0) this.LurkersDB = new Dictionary<int, IDEnumOwner>(p.LurkersDB);

            if (transToEnemy)
            {
                this.enemyMaxMana = p.ownMaxMana;
                this.ownMaxMana = p.enemyMaxMana;
                this.mana = p.enemyMaxMana;

                addMinionsReal(prozis.ownMinions, enemyMinions);
                addMinionsReal(prozis.enemyMinions, ownMinions);

                this.ownHero = new Minion(prozis.enemyHero);
                this.enemyHero = new Minion(prozis.ownHero);
                this.ownWeapon = new Weapon(prozis.enemyWeapon);
                this.enemyWeapon = new Weapon(prozis.ownWeapon);

                this.ownHeroName = prozis.enemyHeroname;
                this.enemyHeroName = prozis.heroname;
                this.ownHeroStartClass = prozis.enemyHeroStartClass;
                this.enemyHeroStartClass = prozis.ownHeroStartClass;

                this.anzTamsin = this.ownHero.enchs.IndexOf("SW_091t5") > 0;

                this.enemyAnzCards = Handmanager.Instance.anzcards;
                this.owncarddraw = p.enemycarddraw;
                this.enemycarddraw = p.owncarddraw;

                this.ownAbilityReady = true;
                this.enemyHeroAblility = new Handmanager.Handcard { card = prozis.heroAbility, manacost = prozis.ownHeroPowerCost };
                this.ownHeroAblility = new Handmanager.Handcard { card = prozis.enemyAbility, manacost = prozis.enemyHeroPowerCost };
                this.enemyAbilityReady = false;
                this.bestEnemyPlay = null;
                
                this.enemyQuest.Copy(p.ownQuest);
                this.ownQuest.Copy(p.enemyQuest);

                this.anzOwnTaunt = p.anzEnemyTaunt;
                this.anzEnemyTaunt = p.anzOwnTaunt;

                this.enemyspellpower = p.spellpower;
                this.enemyspellpowerStarted = p.spellpowerStarted;
                this.spellpower = p.enemyspellpower;
                this.spellpowerStarted = p.enemyspellpowerStarted;

                if(this.ownHero.enchs.IndexOf("SW_450t4e") > 0)
                {
                    this.spellpower += 3;
                }

                // TODO 对手的光环随从
                this.anzDark = 0;
                this.anzTamsinroame = 0;
                this.ownHeroPowerExtraDamage = 0;
                this.ownHero.numAttacksThisTurn = 0;

                this.enemySecretCount = p.ownSecretsIDList.Count;

                foreach(Minion m in p.ownMinions)
                {
                    switch (m.handcard.card.nameCN)
                    {
                        case CardDB.cardNameCN.黑眼:
                            anzDark++;
                            break;
                        case CardDB.cardNameCN.塔姆辛罗姆:
                            anzTamsinroame ++;
                            break;
                    }
                }

            }
            else
            {
                this.ownMaxMana = p.ownMaxMana;
                this.enemyMaxMana = p.enemyMaxMana;

                addMinionsReal(p.ownMinions, ownMinions);
                addMinionsReal(p.enemyMinions, enemyMinions);
                addCardsReal(p.owncards);

                this.ownHero = new Minion(p.ownHero);
                this.enemyHero = new Minion(p.enemyHero);
                this.ownWeapon = new Weapon(p.ownWeapon);
                this.enemyWeapon = new Weapon(p.enemyWeapon);
                this.ownHeroName = p.ownHeroName;
                this.enemyHeroName = p.enemyHeroName;

                this.ownHeroStartClass = p.ownHeroStartClass;
                this.enemyHeroStartClass = p.enemyHeroStartClass;

                this.owncarddraw = p.owncarddraw;
                this.enemycarddraw = p.enemycarddraw;
                this.enemyAnzCards = p.enemyAnzCards;

                this.ownAbilityReady = p.ownAbilityReady;
                this.enemyAbilityReady = p.enemyAbilityReady;
                this.ownHeroAblility = new Handmanager.Handcard(p.ownHeroAblility);
                this.enemyHeroAblility = new Handmanager.Handcard(p.enemyHeroAblility);

                this.ownQuest.Copy(p.ownQuest);
                this.enemyQuest.Copy(p.enemyQuest);
                this.sideQuest.Copy(p.sideQuest);

                this.anzEnemyTaunt = p.anzEnemyTaunt;
                this.anzOwnTaunt = p.anzOwnTaunt;

                this.spellpower = p.spellpower;
                this.spellpowerStarted = p.spellpowerStarted;
                this.enemyspellpower = p.enemyspellpower;
                this.enemyspellpowerStarted = p.enemyspellpowerStarted;

                this.anzDark = p.anzDark;
                this.anzTamsinroame = p.anzTamsinroame;
                this.ownHeroPowerExtraDamage = p.ownHeroPowerExtraDamage;
                this.enemySecretCount = p.enemySecretCount;

            }

            this.playactions.AddRange(p.playactions);
            this.complete = false;

            this.attackFaceHP = p.attackFaceHP;


            this.lostDamage = p.lostDamage;
            this.lostWeaponDamage = p.lostWeaponDamage;
            this.lostHeal = p.lostHeal;

            this.mobsplayedThisTurn = p.mobsplayedThisTurn;
            this.startedWithMobsPlayedThisTurn = p.startedWithMobsPlayedThisTurn;
            this.spellsplayedSinceRecalc = p.spellsplayedSinceRecalc;
            this.secretsplayedSinceRecalc = p.secretsplayedSinceRecalc;
            this.optionsPlayedThisTurn = p.optionsPlayedThisTurn;
            this.cardsPlayedThisTurn = p.cardsPlayedThisTurn;
            this.enemyOptionsDoneThisTurn = p.enemyOptionsDoneThisTurn;
            this.ueberladung = p.ueberladung;
            this.lockedMana = p.lockedMana;
            //圣契
            this.libram = p.libram;
            this.ownDeckSize = p.ownDeckSize;
            this.enemyDeckSize = p.enemyDeckSize;
            this.ownHeroFatigue = p.ownHeroFatigue;
            this.enemyHeroFatigue = p.enemyHeroFatigue;

            //白银之手新兵
            this.LothraxionsPower = p.LothraxionsPower;

            //need the following for manacost-calculation
            this.ownHeroHpStarted = p.ownHeroHpStarted;
            this.ownWeaponAttackStarted = p.ownWeaponAttackStarted;
            this.ownCardsCountStarted = p.ownCardsCountStarted;
            this.enemyCardsCountStarted = p.enemyCardsCountStarted;
            this.ownMobsCountStarted = p.ownMobsCountStarted;
            this.enemyMobsCountStarted = p.enemyMobsCountStarted;
            this.nextSecretThisTurnCost0 = p.nextSecretThisTurnCost0;
            this.nextSpellThisTurnCost0 = p.nextSpellThisTurnCost0;
            this.nextMurlocThisTurnCostHealth = p.nextMurlocThisTurnCostHealth;

            this.blackwaterpirate = p.blackwaterpirate;
            this.blackwaterpirateStarted = p.blackwaterpirateStarted;
            this.nextSpellThisTurnCostHealth = p.nextSpellThisTurnCostHealth;
            this.embracetheshadow = p.embracetheshadow;
            this.ownCrystalCore = p.ownCrystalCore;
            this.ownMinionsInDeckCost0 = p.ownMinionsInDeckCost0;

            this.playedPreparation = p.playedPreparation;

            this.winzigebeschwoererin = p.winzigebeschwoererin;
            this.startedWithWinzigebeschwoererin = p.startedWithWinzigebeschwoererin;
            //
            this.winRazormaneBattleguard = p.winRazormaneBattleguard;
            this.startedRazormaneBattleguard = p.startedRazormaneBattleguard;
            this.managespenst = p.managespenst;
            this.startedWithManagespenst = p.startedWithManagespenst;


            this.ownSpelsCostMore = p.ownSpelsCostMore;
            this.ownSpelsCostMoreAtStart = p.ownSpelsCostMoreAtStart;
            this.ownMinionsCostMore = p.ownMinionsCostMore;
            this.ownMinionsCostMoreAtStart = p.ownMinionsCostMoreAtStart;
            this.ownDRcardsCostMore = p.ownDRcardsCostMore;
            this.ownDRcardsCostMoreAtStart = p.ownDRcardsCostMoreAtStart;

            this.beschwoerungsportal = p.beschwoerungsportal;
            this.startedWithbeschwoerungsportal = p.startedWithbeschwoerungsportal;
            this.myCardsCostLess = p.myCardsCostLess;
            this.startedWithmyCardsCostLess = p.startedWithmyCardsCostLess;
            this.anzOwnScargil = p.anzOwnScargil;
            this.anzOwnAviana = p.anzOwnAviana;
            this.anzOwnCloakedHuntress = p.anzOwnCloakedHuntress;
            this.nerubarweblord = p.nerubarweblord;
            this.startedWithnerubarweblord = p.startedWithnerubarweblord;

            this.startedWithDamagedMinions = p.startedWithDamagedMinions;

            this.loatheb = p.loatheb;


            this.needGraveyard = p.needGraveyard;
            if (p.needGraveyard) this.diedMinions = new List<GraveYardItem>(p.diedMinions);
            this.OwnLastDiedMinion = p.OwnLastDiedMinion;

            //####buffs#############################

            this.anzOwnRaidleader = p.anzOwnRaidleader;
            this.anzEnemyRaidleader = p.anzEnemyRaidleader;
            this.anzOwnVessina = p.anzOwnVessina;
            this.anzEnemyVessina = p.anzEnemyVessina;
            this.anzOwnWarhorseTrainer = p.anzOwnWarhorseTrainer;
            this.anzEnemyWarhorseTrainer = p.anzEnemyWarhorseTrainer;
            this.anzOwnMalGanis = p.anzOwnMalGanis;
            this.anzEnemyMalGanis = p.anzEnemyMalGanis;
            this.anzOwnBolfRamshield = p.anzOwnBolfRamshield;
            this.anzEnemyBolfRamshield = p.anzEnemyBolfRamshield;
            this.anzOwnHorsemen = p.anzOwnHorsemen;
            this.anzEnemyHorsemen = p.anzEnemyHorsemen;
            this.anzOwnAnimatedArmor = p.anzOwnAnimatedArmor;
            this.anzOwnExtraAngrHp = p.anzOwnExtraAngrHp;
            this.anzEnemyExtraAngrHp = p.anzEnemyExtraAngrHp;
            this.anzEnemyAnimatedArmor = p.anzEnemyAnimatedArmor;
            this.anzMoorabi = p.anzMoorabi;
            this.anzOwnPiratesStarted = p.anzOwnPiratesStarted;
            this.anzOwnMurlocStarted = p.anzOwnMurlocStarted;
            this.anzOwnStormwindChamps = p.anzOwnStormwindChamps;
            this.anzEnemyStormwindChamps = p.anzEnemyStormwindChamps;
            this.anzOwnTundrarhino = p.anzOwnTundrarhino;
            this.anzEnemyTundrarhino = p.anzEnemyTundrarhino;
            //重拳先生
            this.anzOwnMrSmite = p.anzOwnMrSmite;
            this.anzEnemyMrSmite = p.anzEnemyMrSmite;
            //重拳先生
            this.anzOwnTimberWolfs = p.anzOwnTimberWolfs;
            this.anzEnemyTimberWolfs = p.anzEnemyTimberWolfs;
            this.anzOwnMurlocWarleader = p.anzOwnMurlocWarleader;
            this.anzEnemyMurlocWarleader = p.anzEnemyMurlocWarleader;
            this.anzAcidmaw = p.anzAcidmaw;
            this.anzOwnGrimscaleOracle = p.anzOwnGrimscaleOracle;
            this.anzEnemyGrimscaleOracle = p.anzEnemyGrimscaleOracle;
            this.anzOwnShadowfiend = p.anzOwnShadowfiend;
            this.anzOwnAuchenaiSoulpriest = p.anzOwnAuchenaiSoulpriest;
            this.anzEnemyAuchenaiSoulpriest = p.anzEnemyAuchenaiSoulpriest;
            this.anzOwnSouthseacaptain = p.anzOwnSouthseacaptain;
            this.anzEnemySouthseacaptain = p.anzEnemySouthseacaptain;
            this.anzOwnMechwarper = p.anzOwnMechwarper;
            this.anzOwnMechwarperStarted = p.anzOwnMechwarperStarted;
            this.anzEnemyMechwarper = p.anzEnemyMechwarper;
            this.anzEnemyMechwarperStarted = p.anzEnemyMechwarperStarted;
            this.anzOwnChromaggus = p.anzOwnChromaggus;
            this.anzEnemyChromaggus = p.anzEnemyChromaggus;
            this.anzOwnDragonConsort = p.anzOwnDragonConsort; 
            this.anzOwnMurlocConsort = p.anzOwnMurlocConsort;   //酸小明
            this.anzOwnDragonConsortStarted = p.anzOwnDragonConsortStarted;
            //火光元素
            this.ownElementCost = p.ownElementCost;
            this.ownElementCostStarted = p.ownElementCostStarted;
            //雷矛军用山羊
            this.ownBeastCostLessOnce = p.ownBeastCostLessOnce;
            this.ownBeastCostLessOnceStarted = p.ownBeastCostLessOnceStarted;

            this.ownAbilityFreezesTarget = p.ownAbilityFreezesTarget;
            this.enemyAbilityFreezesTarget = p.enemyAbilityFreezesTarget;
            this.ownDemonCostLessOnce = p.ownDemonCostLessOnce;
            this.ownHeroPowerCostLessOnce = p.ownHeroPowerCostLessOnce;
            this.ownHeroPowerCostLessTwice = p.ownHeroPowerCostLessTwice;
            this.enemyHeroPowerCostLessOnce = p.enemyHeroPowerCostLessOnce;
            this.enemyHeroPowerExtraDamage = p.enemyHeroPowerExtraDamage;
            this.ownHeroPowerAllowedQuantity = p.ownHeroPowerAllowedQuantity;
            this.enemyHeroPowerAllowedQuantity = p.enemyHeroPowerAllowedQuantity;
            this.anzUsedOwnHeroPower = p.anzUsedOwnHeroPower;
            this.anzUsedEnemyHeroPower = p.anzUsedEnemyHeroPower;

            this.ownMinionsDiedTurn = p.ownMinionsDiedTurn;
            this.enemyMinionsDiedTurn = p.enemyMinionsDiedTurn;

            this.feugenDead = p.feugenDead;
            this.stalaggDead = p.stalaggDead;

            this.weHavePlayedMillhouseManastorm = p.weHavePlayedMillhouseManastorm;
            this.ownSpiritclaws = p.ownSpiritclaws;
            this.enemySpiritclaws = p.enemySpiritclaws;

            this.doublepriest = p.doublepriest;
            this.enemydoublepriest = p.enemydoublepriest;
            this.ownMistcaller = p.ownMistcaller;

            this.lockandload = p.lockandload;
            this.stampede = p.stampede;

            this.ownBaronRivendare = p.ownBaronRivendare;
            this.enemyBaronRivendare = p.enemyBaronRivendare;
            this.ownBrannBronzebeard = p.ownBrannBronzebeard;
            this.enemyBrannBronzebeard = p.enemyBrannBronzebeard;
            this.ownTurnEndEffectsTriggerTwice = p.ownTurnEndEffectsTriggerTwice;
            this.enemyTurnEndEffectsTriggerTwice = p.enemyTurnEndEffectsTriggerTwice;
            this.ownFandralStaghelm = p.ownFandralStaghelm;

            this.weHaveSteamwheedleSniper = p.weHaveSteamwheedleSniper;
            this.enemyHaveSteamwheedleSniper = p.enemyHaveSteamwheedleSniper;
            //#########################################


            this.tempanzOwnCards = this.owncards.Count;
            this.tempanzEnemyCards = this.enemyAnzCards;
            this.value = int.MinValue;


            
        }

        public void copyValuesFrom(Playfield p)
        {

        }

        public bool isEqual(Playfield p, bool logg)
        {
            if (logg)
            {
                if (this.value != p.value) return false;
            }
            if (this.enemySecretCount != p.enemySecretCount)
            {

                // if (logg) Helpfunctions.Instance.logg("enemy secrets changed ");
                if (logg) Helpfunctions.Instance.logg("敌方奥秘改变 ");
                return false;
            }

            if (this.enemySecretCount >= 1)
            {
                for (int i = 0; i < this.enemySecretList.Count; i++)
                {
                    if (!this.enemySecretList[i].isEqual(p.enemySecretList[i]))
                    {
                        // if (logg) Helpfunctions.Instance.logg("enemy secrets changed! ");
                        if (logg) Helpfunctions.Instance.logg("敌方奥秘改变 ");
                        return false;
                    }
                }
            }

            if (this.mana != p.mana || this.enemyMaxMana != p.enemyMaxMana || this.ownMaxMana != p.ownMaxMana)
            {
                // if (logg) Helpfunctions.Instance.logg("mana changed " + this.mana + " " + p.mana + " " + this.enemyMaxMana + " " + p.enemyMaxMana + " " + this.ownMaxMana + " " + p.ownMaxMana);
                if (logg) Helpfunctions.Instance.logg("法力水晶改变 " + this.mana + " " + p.mana + " " + this.enemyMaxMana + " " + p.enemyMaxMana + " " + this.ownMaxMana + " " + p.ownMaxMana);
                return false;
            }

            if (this.ownDeckSize != p.ownDeckSize || this.enemyDeckSize != p.enemyDeckSize || this.ownHeroFatigue != p.ownHeroFatigue || this.enemyHeroFatigue != p.enemyHeroFatigue)
            {
                // if (logg) Helpfunctions.Instance.logg("deck/fatigue changed " + this.ownDeckSize + " " + p.ownDeckSize + " " + this.enemyDeckSize + " " + p.enemyDeckSize + " " + this.ownHeroFatigue + " " + p.ownHeroFatigue + " " + this.enemyHeroFatigue + " " + p.enemyHeroFatigue);
                if (logg) Helpfunctions.Instance.logg("卡组/疲劳改变" + this.ownDeckSize + " " + p.ownDeckSize + " " + this.enemyDeckSize + " " + p.enemyDeckSize + " " + this.ownHeroFatigue + " " + p.ownHeroFatigue + " " + this.enemyHeroFatigue + " " + p.enemyHeroFatigue);
            }

            if (this.cardsPlayedThisTurn != p.cardsPlayedThisTurn || this.mobsplayedThisTurn != p.mobsplayedThisTurn || this.ueberladung != p.ueberladung || this.lockedMana != p.lockedMana || this.ownAbilityReady != p.ownAbilityReady || this.ownQuest.questProgress != p.ownQuest.questProgress)
            {
                // if (logg) Helpfunctions.Instance.logg("stuff changed " + this.cardsPlayedThisTurn + " " + p.cardsPlayedThisTurn + " " + this.mobsplayedThisTurn + " " + p.mobsplayedThisTurn + " " + this.ueberladung + " " + p.ueberladung + " " + this.lockedMana + " " + p.lockedMana + " " + this.ownAbilityReady + " " + p.ownAbilityReady + " " + this.ownQuest.questProgress + " " + p.ownQuest.questProgress);
                if (logg) Helpfunctions.Instance.logg("资料改变 " + this.cardsPlayedThisTurn + " " + p.cardsPlayedThisTurn + " " + this.mobsplayedThisTurn + " " + p.mobsplayedThisTurn + " " + this.ueberladung + " " + p.ueberladung + " " + this.lockedMana + " " + p.lockedMana + " " + this.ownAbilityReady + " " + p.ownAbilityReady + " " + this.ownQuest.questProgress + " " + p.ownQuest.questProgress);
                return false;
            }

            if (this.ownHeroName != p.ownHeroName || this.enemyHeroName != p.enemyHeroName)
            {
                // if (logg) Helpfunctions.Instance.logg("hero name changed ");
                if (logg) Helpfunctions.Instance.logg("英雄名字改变 ");
                return false;
            }

            if (this.ownHero.Hp != p.ownHero.Hp || this.ownHero.Angr != p.ownHero.Angr || this.ownHero.armor != p.ownHero.armor || this.ownHero.frozen != p.ownHero.frozen || this.ownHero.immuneWhileAttacking != p.ownHero.immuneWhileAttacking || this.ownHero.immune != p.ownHero.immune)
            {
                if (logg) Helpfunctions.Instance.logg("ownhero changed " + this.ownHero.Hp + " " + p.ownHero.Hp + " " + this.ownHero.Angr + " " + p.ownHero.Angr + " " + this.ownHero.armor + " " + p.ownHero.armor + " " + this.ownHero.frozen + " " + p.ownHero.frozen + " " + this.ownHero.immuneWhileAttacking + " " + p.ownHero.immuneWhileAttacking + " " + this.ownHero.immune + " " + p.ownHero.immune);
                return false;
            }
            if (this.ownHero.Ready != p.ownHero.Ready || !this.ownWeapon.isEqual(p.ownWeapon) || this.ownHero.numAttacksThisTurn != p.ownHero.numAttacksThisTurn || this.ownHero.windfury != p.ownHero.windfury)
            {
                if (logg) Helpfunctions.Instance.logg("weapon changed " + this.ownHero.Ready + " " + p.ownHero.Ready + " " + this.ownWeapon.Angr + " " + p.ownWeapon.Angr + " " + this.ownWeapon.Durability + " " + p.ownWeapon.Durability + " " + this.ownHero.numAttacksThisTurn + " " + p.ownHero.numAttacksThisTurn + " " + this.ownHero.windfury + " " + p.ownHero.windfury + " " + this.ownWeapon.poisonous + " " + p.ownWeapon.poisonous + " " + this.ownWeapon.lifesteal + " " + p.ownWeapon.lifesteal);
                return false;
            }
            if (this.enemyHero.Hp != p.enemyHero.Hp || !this.enemyWeapon.isEqual(p.enemyWeapon) || this.enemyHero.armor != p.enemyHero.armor || this.enemyHero.frozen != p.enemyHero.frozen || this.enemyHero.immune != p.enemyHero.immune)
            {
                if (logg) Helpfunctions.Instance.logg("enemyhero changed " + this.enemyHero.Hp + " " + p.enemyHero.Hp + " " + this.enemyWeapon.Angr + " " + p.enemyWeapon.Angr + " " + this.enemyHero.armor + " " + p.enemyHero.armor + " " + this.enemyWeapon.Durability + " " + p.enemyWeapon.Durability + " " + this.enemyHero.frozen + " " + p.enemyHero.frozen + " " + this.enemyHero.immune + " " + p.enemyHero.immune + " " + this.enemyWeapon.poisonous + " " + p.enemyWeapon.poisonous + " " + this.enemyWeapon.lifesteal + " " + p.enemyWeapon.lifesteal);
                return false;
            }



            if (this.ownHeroAblility.card.nameEN != p.ownHeroAblility.card.nameEN)
            {
                if (logg) Helpfunctions.Instance.logg("hero ability changed ");
                return false;
            }

            if (this.spellpower != p.spellpower)
            {
                if (logg) Helpfunctions.Instance.logg("spellpower changed");
                return false;
            }

            if (this.ownMinions.Count != p.ownMinions.Count || this.enemyMinions.Count != p.enemyMinions.Count || this.owncards.Count != p.owncards.Count)
            {
                if (logg) Helpfunctions.Instance.logg("minions count or hand changed");
                return false;
            }

            bool minionbool = true;
            for (int i = 0; i < this.ownMinions.Count; i++)
            {
                Minion dis = this.ownMinions[i]; Minion pis = p.ownMinions[i];

                if (dis.name != pis.name) minionbool = false;
                if (dis.Angr != pis.Angr || dis.Hp != pis.Hp || dis.maxHp != pis.maxHp || dis.numAttacksThisTurn != pis.numAttacksThisTurn) minionbool = false;
                if (dis.Ready != pis.Ready) minionbool = false; // includes frozen, exhaunted
                if (dis.playedThisTurn != pis.playedThisTurn) minionbool = false;
                if (dis.silenced != pis.silenced || dis.stealth != pis.stealth || dis.taunt != pis.taunt || dis.windfury != pis.windfury || dis.zonepos != pis.zonepos) minionbool = false;
                if (dis.divineshild != pis.divineshild || dis.cantLowerHPbelowONE != pis.cantLowerHPbelowONE || dis.immune != pis.immune) minionbool = false;
                if (dis.ownBlessingOfWisdom != pis.ownBlessingOfWisdom || dis.enemyBlessingOfWisdom != pis.enemyBlessingOfWisdom) minionbool = false;
                if (dis.ownPowerWordGlory != pis.ownPowerWordGlory || dis.enemyPowerWordGlory != pis.enemyPowerWordGlory) minionbool = false;
                if (dis.destroyOnEnemyTurnStart != pis.destroyOnEnemyTurnStart || dis.destroyOnEnemyTurnEnd != pis.destroyOnEnemyTurnEnd || dis.destroyOnOwnTurnEnd != pis.destroyOnOwnTurnEnd || dis.destroyOnOwnTurnStart != pis.destroyOnOwnTurnStart) minionbool = false;
                if (dis.ancestralspirit != pis.ancestralspirit || dis.desperatestand != pis.desperatestand || dis.souloftheforest != pis.souloftheforest || dis.stegodon != pis.stegodon || dis.livingspores != pis.livingspores) minionbool = false;
                if (dis.explorershat != pis.explorershat || dis.returnToHand != pis.returnToHand || dis.infest != pis.infest || dis.deathrattle2 != pis.deathrattle2) minionbool = false;
                if (dis.hChoice != pis.hChoice || dis.cantBeTargetedBySpellsOrHeroPowers != pis.cantBeTargetedBySpellsOrHeroPowers || dis.poisonous != pis.poisonous || dis.lifesteal != pis.lifesteal) minionbool = false;
            }
            if (minionbool == false)
            {
                if (logg) Helpfunctions.Instance.logg("ownminions changed");
                return false;
            }

            for (int i = 0; i < this.enemyMinions.Count; i++)
            {
                Minion dis = this.enemyMinions[i]; Minion pis = p.enemyMinions[i];

                if (dis.name != pis.name) minionbool = false;
                if (dis.Angr != pis.Angr || dis.Hp != pis.Hp || dis.maxHp != pis.maxHp || dis.numAttacksThisTurn != pis.numAttacksThisTurn) minionbool = false;
                if (dis.Ready != pis.Ready) minionbool = false; // includes frozen, exhaunted
                if (dis.playedThisTurn != pis.playedThisTurn) minionbool = false;
                if (dis.silenced != pis.silenced || dis.stealth != pis.stealth || dis.taunt != pis.taunt || dis.windfury != pis.windfury || dis.zonepos != pis.zonepos) minionbool = false;
                if (dis.divineshild != pis.divineshild || dis.cantLowerHPbelowONE != pis.cantLowerHPbelowONE || dis.immune != pis.immune) minionbool = false;
                if (dis.ownBlessingOfWisdom != pis.ownBlessingOfWisdom || dis.enemyBlessingOfWisdom != pis.enemyBlessingOfWisdom) minionbool = false;
                if (dis.ownPowerWordGlory != pis.ownPowerWordGlory || dis.enemyPowerWordGlory != pis.enemyPowerWordGlory) minionbool = false;
                if (dis.destroyOnEnemyTurnStart != pis.destroyOnEnemyTurnStart || dis.destroyOnEnemyTurnEnd != pis.destroyOnEnemyTurnEnd || dis.destroyOnOwnTurnEnd != pis.destroyOnOwnTurnEnd || dis.destroyOnOwnTurnStart != pis.destroyOnOwnTurnStart) minionbool = false;
                if (dis.ancestralspirit != pis.ancestralspirit || dis.desperatestand != pis.desperatestand || dis.souloftheforest != pis.souloftheforest || dis.stegodon != pis.stegodon || dis.livingspores != pis.livingspores) minionbool = false;
                if (dis.explorershat != pis.explorershat || dis.returnToHand != pis.returnToHand || dis.infest != pis.infest || dis.deathrattle2 != pis.deathrattle2) minionbool = false;
                if (dis.hChoice != pis.hChoice || dis.cantBeTargetedBySpellsOrHeroPowers != pis.cantBeTargetedBySpellsOrHeroPowers || dis.poisonous != pis.poisonous || dis.lifesteal != pis.lifesteal) minionbool = false;
            }
            if (minionbool == false)
            {
                if (logg) Helpfunctions.Instance.logg("enemyminions changed");
                return false;
            }

            for (int i = 0; i < this.owncards.Count; i++)
            {
                Handmanager.Handcard dishc = this.owncards[i]; Handmanager.Handcard pishc = p.owncards[i];
                if (dishc.position != pishc.position || dishc.entity != pishc.entity || dishc.getManaCost(this) != pishc.getManaCost(p))
                {
                    if (logg) Helpfunctions.Instance.logg("handcard changed: " + dishc.card.nameEN);
                    return false;
                }
            }

            for (int i = 0; i < this.ownMinions.Count; i++)
            {
                Minion dis = this.ownMinions[i]; Minion pis = p.ownMinions[i];
                if (dis.entitiyID != pis.entitiyID) Ai.Instance.updateEntitiy(pis.entitiyID, dis.entitiyID);

            }

            for (int i = 0; i < this.enemyMinions.Count; i++)
            {
                Minion dis = this.enemyMinions[i]; Minion pis = p.enemyMinions[i];
                if (dis.entitiyID != pis.entitiyID) Ai.Instance.updateEntitiy(pis.entitiyID, dis.entitiyID);

            }
            if (this.ownSecretsIDList.Count != p.ownSecretsIDList.Count)
            {
                if (logg) Helpfunctions.Instance.logg("secretsCount changed");
                return false;
            }
            for (int i = 0; i < this.ownSecretsIDList.Count; i++)
            {
                if (this.ownSecretsIDList[i] != p.ownSecretsIDList[i])
                {
                    if (logg) Helpfunctions.Instance.logg("secrets changed");
                    return false;
                }
            }
            return true;
        }

        public bool isEqualf(Playfield p)
        {
            if (this.value != p.value) return false;

            if (this.ownMinions.Count != p.ownMinions.Count || this.enemyMinions.Count != p.enemyMinions.Count || this.owncards.Count != p.owncards.Count) return false;

            if (this.cardsPlayedThisTurn != p.cardsPlayedThisTurn || this.mobsplayedThisTurn != p.mobsplayedThisTurn || this.ueberladung != p.ueberladung || this.lockedMana != p.lockedMana || this.ownAbilityReady != p.ownAbilityReady) return false;

            if (this.mana != p.mana || this.enemyMaxMana != p.enemyMaxMana || this.ownMaxMana != p.ownMaxMana || this.ownQuest.questProgress != p.ownQuest.questProgress) return false;

            if (this.ownHeroName != p.ownHeroName || this.enemyHeroName != p.enemyHeroName || this.enemySecretCount != p.enemySecretCount) return false;

            if (this.ownHero.Hp != p.ownHero.Hp || this.ownHero.Angr != p.ownHero.Angr || this.ownHero.armor != p.ownHero.armor || this.ownHero.frozen != p.ownHero.frozen || this.ownHero.immuneWhileAttacking != p.ownHero.immuneWhileAttacking || this.ownHero.immune != p.ownHero.immune) return false;

            if (this.ownHero.Ready != p.ownHero.Ready || !this.ownWeapon.isEqual(p.ownWeapon) || this.ownHero.numAttacksThisTurn != p.ownHero.numAttacksThisTurn || this.ownHero.windfury != p.ownHero.windfury) return false;

            if (this.enemyHero.Hp != p.enemyHero.Hp || !this.enemyWeapon.isEqual(p.enemyWeapon) || this.enemyHero.armor != p.enemyHero.armor || this.enemyHero.frozen != p.enemyHero.frozen || this.enemyHero.immune != p.enemyHero.immune) return false;





            if (this.ownHeroAblility.card.nameEN != p.ownHeroAblility.card.nameEN || this.spellpower != p.spellpower) return false;

            bool minionbool = true;
            for (int i = 0; i < this.ownMinions.Count; i++)
            {
                Minion dis = this.ownMinions[i]; Minion pis = p.ownMinions[i];
                //if (dis.entitiyID == 0) dis.entitiyID = pis.entitiyID;
                //if (pis.entitiyID == 0) pis.entitiyID = dis.entitiyID;
                if (dis.entitiyID != pis.entitiyID) minionbool = false;
                if (dis.Angr != pis.Angr || dis.Hp != pis.Hp || dis.maxHp != pis.maxHp || dis.numAttacksThisTurn != pis.numAttacksThisTurn) minionbool = false;
                if (dis.Ready != pis.Ready) minionbool = false; // includes frozen, exhaunted
                if (dis.playedThisTurn != pis.playedThisTurn) minionbool = false;
                if (dis.silenced != pis.silenced || dis.stealth != pis.stealth || dis.taunt != pis.taunt || dis.windfury != pis.windfury || dis.zonepos != pis.zonepos) minionbool = false;
                if (dis.divineshild != pis.divineshild || dis.cantLowerHPbelowONE != pis.cantLowerHPbelowONE || dis.immune != pis.immune) minionbool = false;
                if (dis.ownBlessingOfWisdom != pis.ownBlessingOfWisdom || dis.enemyBlessingOfWisdom != pis.enemyBlessingOfWisdom) minionbool = false;
                if (dis.ownPowerWordGlory != pis.ownPowerWordGlory || dis.enemyPowerWordGlory != pis.enemyPowerWordGlory) minionbool = false;
                if (dis.destroyOnEnemyTurnStart != pis.destroyOnEnemyTurnStart || dis.destroyOnEnemyTurnEnd != pis.destroyOnEnemyTurnEnd || dis.destroyOnOwnTurnEnd != pis.destroyOnOwnTurnEnd || dis.destroyOnOwnTurnStart != pis.destroyOnOwnTurnStart) minionbool = false;
                if (dis.ancestralspirit != pis.ancestralspirit || dis.desperatestand != pis.desperatestand || dis.souloftheforest != pis.souloftheforest || dis.stegodon != pis.stegodon || dis.livingspores != pis.livingspores) minionbool = false;
                if (dis.explorershat != pis.explorershat || dis.returnToHand != pis.returnToHand || dis.infest != pis.infest || dis.deathrattle2 != pis.deathrattle2) minionbool = false;
                if (dis.hChoice != pis.hChoice || dis.cantBeTargetedBySpellsOrHeroPowers != pis.cantBeTargetedBySpellsOrHeroPowers || dis.poisonous != pis.poisonous || dis.lifesteal != pis.lifesteal) minionbool = false;
                if (minionbool == false) break;
            }
            if (minionbool == false)
            {

                return false;
            }

            for (int i = 0; i < this.enemyMinions.Count; i++)
            {
                Minion dis = this.enemyMinions[i]; Minion pis = p.enemyMinions[i];
                //if (dis.entitiyID == 0) dis.entitiyID = pis.entitiyID;
                //if (pis.entitiyID == 0) pis.entitiyID = dis.entitiyID;
                if (dis.entitiyID != pis.entitiyID) minionbool = false;
                if (dis.Angr != pis.Angr || dis.Hp != pis.Hp || dis.maxHp != pis.maxHp || dis.numAttacksThisTurn != pis.numAttacksThisTurn) minionbool = false;
                if (dis.Ready != pis.Ready) minionbool = false; // includes frozen, exhaunted
                if (dis.playedThisTurn != pis.playedThisTurn) minionbool = false;
                if (dis.silenced != pis.silenced || dis.stealth != pis.stealth || dis.taunt != pis.taunt || dis.windfury != pis.windfury || dis.zonepos != pis.zonepos) minionbool = false;
                if (dis.divineshild != pis.divineshild || dis.cantLowerHPbelowONE != pis.cantLowerHPbelowONE || dis.immune != pis.immune) minionbool = false;
                if (dis.ownBlessingOfWisdom != pis.ownBlessingOfWisdom || dis.enemyBlessingOfWisdom != pis.enemyBlessingOfWisdom) minionbool = false;
                if (dis.ownPowerWordGlory != pis.ownPowerWordGlory || dis.enemyPowerWordGlory != pis.enemyPowerWordGlory) minionbool = false;
                if (dis.destroyOnEnemyTurnStart != pis.destroyOnEnemyTurnStart || dis.destroyOnEnemyTurnEnd != pis.destroyOnEnemyTurnEnd || dis.destroyOnOwnTurnEnd != pis.destroyOnOwnTurnEnd || dis.destroyOnOwnTurnStart != pis.destroyOnOwnTurnStart) minionbool = false;
                if (dis.ancestralspirit != pis.ancestralspirit || dis.desperatestand != pis.desperatestand || dis.souloftheforest != pis.souloftheforest || dis.stegodon != pis.stegodon || dis.livingspores != pis.livingspores) minionbool = false;
                if (dis.explorershat != pis.explorershat || dis.returnToHand != pis.returnToHand || dis.infest != pis.infest || dis.deathrattle2 != pis.deathrattle2) minionbool = false;
                if (dis.hChoice != pis.hChoice || dis.cantBeTargetedBySpellsOrHeroPowers != pis.cantBeTargetedBySpellsOrHeroPowers || dis.poisonous != pis.poisonous || dis.lifesteal != pis.lifesteal) minionbool = false;
                if (minionbool == false) break;
            }
            if (minionbool == false)
            {
                return false;
            }

            for (int i = 0; i < this.owncards.Count; i++)
            {
                Handmanager.Handcard dishc = this.owncards[i]; Handmanager.Handcard pishc = p.owncards[i];
                if (dishc.position != pishc.position || dishc.entity != pishc.entity || dishc.manacost != pishc.manacost)
                {
                    return false;
                }
            }

            if (this.enemySecretCount >= 1)
            {
                for (int i = 0; i < this.enemySecretList.Count; i++)
                {
                    if (!this.enemySecretList[i].isEqual(p.enemySecretList[i]))
                    {
                        return false;
                    }
                }
            }

            if (this.ownSecretsIDList.Count != p.ownSecretsIDList.Count)
            {
                return false;
            }
            for (int i = 0; i < this.ownSecretsIDList.Count; i++)
            {
                if (this.ownSecretsIDList[i] != p.ownSecretsIDList[i])
                {
                    return false;
                }
            }

            return true;
        }

        public Int64 GetPHash()
        {//获取hash值
            Int64 retval = 0;
            // ImprovedCalculations  = 0,会有hash冲突问题，强制改为1
            if (this.playactions.Count > 0)
            {
                foreach (Action a in this.playactions)
                {
                    switch (a.actionType)
                    {
                        case actionEnum.playcard:
                            retval += a.card.entity;
                            if (a.target != null)
                            {
                                retval += a.target.entitiyID;
                            }
                            retval += a.druidchoice;
                            continue;
                        case actionEnum.attackWithMinion:
                            retval += a.own.entitiyID + a.target.entitiyID;
                            continue;
                        case actionEnum.attackWithHero:
                            retval += a.target.entitiyID;
                            continue;
                        case actionEnum.useHeroPower:
                            retval += 100;
                            if (a.target != null)
                            {
                                retval += a.target.entitiyID;
                            }
                            retval += a.druidchoice;
                            continue;
                    }
                }
                if (this.playactions[this.playactions.Count - 1].card != null && this.playactions[this.playactions.Count - 1].card.card.type == CardDB.cardtype.MOB) retval++;
                retval += this.manaTurnEnd;
            }

            retval += this.anzOgOwnCThunAngrBonus + this.anzOwnJadeGolem + this.anzOwnElementalsLastTurn;
            retval *= 1000;

            foreach (Minion m in this.ownMinions)
            {
                retval += m.entitiyID + m.Angr + m.Hp + (m.taunt ? 1 : 0) + (m.divineshild ? 1 : 0) + (m.wounded ? 0 : 1);
            }
            retval *= 10000000;
            retval += 10000 * this.ownMinions.Count + 100 * this.enemyMinions.Count + 1000 * this.mana + 100000 * (this.ownHero.Hp + this.enemyHero.Hp) + this.owncards.Count + this.enemycarddraw + this.cardsPlayedThisTurn + this.mobsplayedThisTurn + this.ownHero.Angr + this.ownHero.armor + this.ownWeapon.Angr + this.enemyWeapon.Durability + this.spellpower + this.enemyspellpower + this.ownQuest.questProgress;
            return retval;
        }


        //stuff for playing around enemy aoes
        public void enemyPlaysAoe(int pprob, int pprob2)
        {
            if (!this.loatheb)
            {
                Playfield p = new Playfield(this);
                float oldval = Ai.Instance.botBase.getPlayfieldValue(p);
                p.value = int.MinValue;
                p.EnemyCardPlaying(p.enemyHeroStartClass, p.mana, p.enemyAnzCards, pprob, pprob2);
                float newval = Ai.Instance.botBase.getPlayfieldValue(p);
                p.value = int.MinValue;
                if (oldval > newval) // new board is better for enemy (value is smaller)
                {
                    this.copyValuesFrom(p);
                }
            }
        }

        public int EnemyCardPlaying(TAG_CLASS enemyHeroStrtClass, int currmana, int cardcount, int playAroundProb, int pap2)
        {
            int mana = currmana;
            if (cardcount == 0) return currmana;

            bool useAOE = false;
            int mobscount = 0;
            foreach (Minion min in this.ownMinions)
            {
                if (min.maxHp >= 2 && min.Angr >= 2) mobscount++;
            }

            if (mobscount >= 3) useAOE = true;

            if (enemyHeroStrtClass == TAG_CLASS.WARRIOR)
            {
                bool usewhirlwind = true;
                foreach (Minion m in this.enemyMinions)
                {
                    if (m.Hp == 1) usewhirlwind = false;
                }
                if (this.ownMinions.Count <= 3) usewhirlwind = false;

                if (usewhirlwind)
                {
                    mana = EnemyPlaysACard(CardDB.cardNameEN.whirlwind, mana, playAroundProb, pap2);//旋风斩
                }
            }

            if (!useAOE) return mana;

            switch (enemyHeroStrtClass)
            {//各职业会使用的aoe
                case TAG_CLASS.MAGE:
                    mana = EnemyPlaysACard(CardDB.cardNameEN.flamestrike, mana, playAroundProb, pap2);
                    mana = EnemyPlaysACard(CardDB.cardNameEN.blizzard, mana, playAroundProb, pap2);
                    break;
                case TAG_CLASS.HUNTER:
                    mana = EnemyPlaysACard(CardDB.cardNameEN.unleashthehounds, mana, playAroundProb, pap2);
                    break;
                case TAG_CLASS.PRIEST:
                    mana = EnemyPlaysACard(CardDB.cardNameEN.holynova, mana, playAroundProb, pap2);
                    break;
                case TAG_CLASS.SHAMAN:
                    mana = EnemyPlaysACard(CardDB.cardNameEN.lightningstorm, mana, playAroundProb, pap2);
                    mana = EnemyPlaysACard(CardDB.cardNameEN.maelstromportal, mana, playAroundProb, pap2);
                    break;
                case TAG_CLASS.PALADIN:
                    mana = EnemyPlaysACard(CardDB.cardNameEN.consecration, mana, playAroundProb, pap2);
                    break;
                case TAG_CLASS.DRUID:
                    mana = EnemyPlaysACard(CardDB.cardNameEN.swipe, mana, playAroundProb, pap2);
                    break;
            }

            return mana;
        }

        public int EnemyPlaysACard(CardDB.cardNameEN cardname, int currmana, int playAroundProb, int pap2)
        {
            //todo manacosts

            switch (cardname)
            {
                case CardDB.cardNameEN.flamestrike:
                    if (currmana >= 7)
                    {
                        if (wehaveCounterspell == 0)
                        {
                            bool dontkill = false;
                            int prob = Probabilitymaker.Instance.getProbOfEnemyHavingCardInHand(CardDB.cardIDEnum.CS2_032, this.enemyAnzCards, this.enemyDeckSize);
                            if (playAroundProb > prob) return currmana;
                            if (pap2 > prob) dontkill = true;

                            List<Minion> temp = this.ownMinions;
                            int damage = getEnemySpellDamageDamage(4);
                            foreach (Minion enemy in temp)
                            {
                                enemy.cantLowerHPbelowONE = dontkill;
                                this.minionGetDamageOrHeal(enemy, damage);
                                enemy.cantLowerHPbelowONE = false;
                            }
                        }
                        else wehaveCounterspell++;
                        currmana -= 7;
                    }
                    break;

                case CardDB.cardNameEN.blizzard:
                    if (currmana >= 6)
                    {
                        if (wehaveCounterspell == 0)
                        {
                            bool dontkill = false;
                            int prob = Probabilitymaker.Instance.getProbOfEnemyHavingCardInHand(CardDB.cardIDEnum.CS2_028, this.enemyAnzCards, this.enemyDeckSize);
                            if (playAroundProb > prob) return currmana;
                            if (pap2 > prob) dontkill = true;

                            List<Minion> temp = this.ownMinions;
                            int damage = getEnemySpellDamageDamage(2);
                            foreach (Minion enemy in temp)
                            {
                                minionGetFrozen(enemy);
                                enemy.cantLowerHPbelowONE = dontkill;
                                this.minionGetDamageOrHeal(enemy, damage);
                                enemy.cantLowerHPbelowONE = false;
                            }
                        }
                        else wehaveCounterspell++;
                        currmana -= 6;
                    }
                    break;

                case CardDB.cardNameEN.unleashthehounds:
                    if (currmana >= 4)//3
                    {
                        if (wehaveCounterspell == 0)
                        {
                            bool dontkill = false;
                            int prob = Probabilitymaker.Instance.getProbOfEnemyHavingCardInHand(CardDB.cardIDEnum.EX1_538, this.enemyAnzCards, this.enemyDeckSize);
                            if (playAroundProb > prob) return currmana;
                            if (pap2 > prob) dontkill = true;

                            int anz = this.ownMinions.Count;
                            int posi = this.enemyMinions.Count - 1;
                            CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_538t);//hound
                            for (int i = 0; i < anz; i++)
                            {
                                callKid(kid, posi, false);
                            }
                        }
                        else wehaveCounterspell++;
                        currmana -= 3;
                    }
                    break;

                case CardDB.cardNameEN.holynova:
                    if (currmana >= 5)
                    {
                        if (wehaveCounterspell == 0)
                        {
                            bool dontkill = false;
                            int prob = Probabilitymaker.Instance.getProbOfEnemyHavingCardInHand(CardDB.cardIDEnum.CS1_112, this.enemyAnzCards, this.enemyDeckSize);
                            if (playAroundProb > prob) return currmana;
                            if (pap2 > prob) dontkill = true;

                            List<Minion> temp = this.enemyMinions;
                            int heal = getEnemySpellHeal(2);
                            int damage = getEnemySpellDamageDamage(2);
                            foreach (Minion enemy in temp)
                            {
                                this.minionGetDamageOrHeal(enemy, -heal);
                            }
                            this.minionGetDamageOrHeal(this.enemyHero, -heal);
                            temp = this.ownMinions;
                            foreach (Minion enemy in temp)
                            {
                                enemy.cantLowerHPbelowONE = dontkill;
                                this.minionGetDamageOrHeal(enemy, damage);
                                enemy.cantLowerHPbelowONE = false;
                            }
                            this.minionGetDamageOrHeal(this.ownHero, damage);
                        }
                        else wehaveCounterspell++;
                        currmana -= 5;
                    }
                    break;

                case CardDB.cardNameEN.lightningstorm:
                    if (currmana >= 4)//3
                    {
                        if (wehaveCounterspell == 0)
                        {
                            bool dontkill = false;
                            int prob = Probabilitymaker.Instance.getProbOfEnemyHavingCardInHand(CardDB.cardIDEnum.EX1_259, this.enemyAnzCards, this.enemyDeckSize);
                            if (playAroundProb > prob) return currmana;
                            if (pap2 > prob) dontkill = true;

                            List<Minion> temp = this.ownMinions;
                            int damage = getEnemySpellDamageDamage(3);
                            foreach (Minion enemy in temp)
                            {
                                enemy.cantLowerHPbelowONE = dontkill;
                                this.minionGetDamageOrHeal(enemy, damage);
                                enemy.cantLowerHPbelowONE = false;
                            }
                        }
                        else wehaveCounterspell++;
                        currmana -= 3;
                    }
                    break;

                case CardDB.cardNameEN.maelstromportal:
                    if (currmana >= 3)//2
                    {
                        if (wehaveCounterspell == 0)
                        {
                            bool dontkill = false;
                            int prob = Probabilitymaker.Instance.getProbOfEnemyHavingCardInHand(CardDB.cardIDEnum.KAR_073, this.enemyAnzCards, this.enemyDeckSize);
                            if (playAroundProb > prob) return currmana;
                            if (pap2 > prob) dontkill = true;

                            List<Minion> temp = this.ownMinions;
                            int damage = getEnemySpellDamageDamage(1);
                            foreach (Minion enemy in temp)
                            {
                                enemy.cantLowerHPbelowONE = dontkill;
                                this.minionGetDamageOrHeal(enemy, damage);
                                enemy.cantLowerHPbelowONE = false;
                            }
                        }
                        else wehaveCounterspell++;
                        currmana -= 2;
                    }
                    break;

                case CardDB.cardNameEN.whirlwind:
                    if (currmana >= 3)//1
                    {
                        if (wehaveCounterspell == 0)
                        {
                            bool dontkill = false;
                            int prob = Probabilitymaker.Instance.getProbOfEnemyHavingCardInHand(CardDB.cardIDEnum.EX1_400, this.enemyAnzCards, this.enemyDeckSize);
                            if (playAroundProb > prob) return currmana;
                            if (pap2 > prob) dontkill = true;

                            List<Minion> temp = this.enemyMinions;
                            int damage = getEnemySpellDamageDamage(1);
                            foreach (Minion enemy in temp)
                            {
                                this.minionGetDamageOrHeal(enemy, damage);
                            }
                            temp = this.ownMinions;
                            foreach (Minion enemy in temp)
                            {
                                enemy.cantLowerHPbelowONE = dontkill;
                                this.minionGetDamageOrHeal(enemy, damage);
                                enemy.cantLowerHPbelowONE = false;
                            }
                        }
                        else wehaveCounterspell++;
                        currmana -= 1;
                    }
                    break;

                case CardDB.cardNameEN.consecration:
                    if (currmana >= 4)
                    {
                        if (wehaveCounterspell == 0)
                        {
                            bool dontkill = false;
                            int prob = Probabilitymaker.Instance.getProbOfEnemyHavingCardInHand(CardDB.cardIDEnum.CS2_093, this.enemyAnzCards, this.enemyDeckSize);
                            if (playAroundProb > prob) return currmana;
                            if (pap2 > prob) dontkill = true;

                            List<Minion> temp = this.ownMinions;
                            int damage = getEnemySpellDamageDamage(2);
                            foreach (Minion enemy in temp)
                            {
                                enemy.cantLowerHPbelowONE = dontkill;
                                this.minionGetDamageOrHeal(enemy, damage);
                                enemy.cantLowerHPbelowONE = false;
                            }

                            this.minionGetDamageOrHeal(this.ownHero, damage);
                        }
                        else wehaveCounterspell++;
                        currmana -= 4;
                    }
                    break;

                case CardDB.cardNameEN.swipe:
                    if (currmana >= 4)
                    {
                        if (wehaveCounterspell == 0)
                        {
                            bool dontkill = false;
                            int prob = Probabilitymaker.Instance.getProbOfEnemyHavingCardInHand(CardDB.cardIDEnum.CS2_012, this.enemyAnzCards, this.enemyDeckSize);
                            if (playAroundProb > prob) return currmana;
                            if (pap2 > prob) dontkill = true;

                            int damage4 = getEnemySpellDamageDamage(4);
                            // all others get 1 spelldamage
                            int damage1 = getEnemySpellDamageDamage(1);

                            List<Minion> temp = this.ownMinions;
                            Minion target = null;
                            foreach (Minion mnn in temp)
                            {
                                if (mnn.Hp <= damage4 || mnn.handcard.card.isSpecialMinion || target == null)
                                {
                                    target = mnn;
                                }
                            }
                            foreach (Minion mnn in temp.ToArray())
                            {
                                mnn.cantLowerHPbelowONE = dontkill;
                                this.minionGetDamageOrHeal(mnn, mnn.entitiyID == target.entitiyID ? damage4 : damage1);
                                mnn.cantLowerHPbelowONE = false;
                            }
                        }
                        else wehaveCounterspell++;
                        currmana -= 4;
                    }
                    break;
            }
            return currmana;
        }

        public int getNextEntity()
        {
            //i dont trust return this.nextEntity++; !!!
            int retval = this.nextEntity;
            this.nextEntity++;
            return retval;
        }


        // get all minions which are attackable
        public List<Minion> getAttackTargets(bool own, bool isLethalCheck)
        {
            List<Minion> trgts = new List<Minion>();
            List<Minion> trgts2 = new List<Minion>();

            List<Minion> temp = (own) ? this.enemyMinions : this.ownMinions;
            bool hasTaunts = false;
            foreach (Minion m in temp)
            {
                if (m.untouchable) continue;
                if (m.stealth) continue; // cant target stealth

                if (m.taunt)
                {
                    hasTaunts = true;
                    trgts.Add(m);
                }
                else
                {
                    trgts2.Add(m);
                }
            }
            if (hasTaunts) return trgts;

            if (isLethalCheck) trgts2.Clear(); // only target enemy hero during Lethal check!

            if (own && !(this.enemyHero.immune || this.enemyHero.stealth)) trgts2.Add(this.enemyHero);//免疫 潜行
            else if (!own && !(this.ownHero.immune || this.ownHero.stealth)) trgts2.Add(this.ownHero);
            return trgts2;
        }

        public int getBestPlace(CardDB.Card card, bool lethal)
        {
            //we return the zonepos!
            if (card.type != CardDB.cardtype.MOB) return 1;
            if (this.ownMinions.Count == 0) return 1;
            if (this.ownMinions.Count == 1)
            {
                if (this.ownMinions[0].Angr < card.Attack) return 1;
                else if (this.ownMinions[0].handcard.card.nameEN == CardDB.cardNameEN.flametonguetotem || this.ownMinions[0].handcard.card.nameEN == CardDB.cardNameEN.direwolfalpha) return 1;
                else if (card.nameEN == CardDB.cardNameEN.tuskarrtotemic) return 1;
                else if (this.ownMinions[0].handcard.card.nameCN == CardDB.cardNameCN.战场军官
                    || this.ownMinions[0].handcard.card.nameCN == CardDB.cardNameCN.恐狼前锋
                    || this.ownMinions[0].handcard.card.nameCN == CardDB.cardNameCN.火舌图腾) return 1;
                else return 2;
            }

            // 战场军官特别判定,随从至少两只
            if (card.nameCN == CardDB.cardNameCN.战场军官)
            {
                int place = 1;
                int maxAngr = 0;
                for (int ii = 1; ii < this.ownMinions.Count; ii++)
                {
                    int angr = (this.ownMinions[ii - 1].windfury || this.ownMinions[ii - 1].frozen || this.ownMinions[ii - 1].cantAttack ? 0 : this.ownMinions[ii - 1].Angr) + (this.ownMinions[ii].windfury || this.ownMinions[ii].frozen || this.ownMinions[ii].cantAttack ? 0 : this.ownMinions[ii].Angr);
                    if (angr > maxAngr)
                    {
                        place = ii + 1;
                        maxAngr = angr;
                    }
                }
                return place;
            }

            for (int ii = 0; ii < this.ownMinions.Count; ii++)
            {
                if (this.ownMinions[ii].handcard.card.nameCN == CardDB.cardNameCN.战场军官 || this.ownMinions[ii].handcard.card.nameCN == CardDB.cardNameCN.恐狼前锋 || this.ownMinions[ii].handcard.card.nameCN == CardDB.cardNameCN.战场军官)
                {
                    // 冲锋怪放在战场军官左边
                    if (card.Charge || card.Rush)
                    {
                        return ii + 1;
                    }
                    else
                    {
                        // 右边没有怪或者左边有两只怪
                        if (this.ownMinions.Count - ii <= 1 || ii >= 2) return this.ownMinions.Count + 1;
                        else return 1;
                    }
                }
            }

            // buff 怪
            if (card.nameCN == CardDB.cardNameCN.暴风城卫兵 || card.nameCN == CardDB.cardNameCN.阿古斯防御者 || card.nameCN == CardDB.cardNameCN.年迈的法师
                || card.nameCN == CardDB.cardNameCN.阳焰瓦格里 || card.nameCN == CardDB.cardNameCN.菌菇术士 || card.nameCN == CardDB.cardNameCN.蠕动的恐魔 || card.nameCN == CardDB.cardNameCN.污手街守护者)
            {
                int place = 1;
                int maxVal = 0;
                for (int ii = 1; ii < this.ownMinions.Count; ii++)
                {
                    int val = 0;
                    if (this.ownMinions[ii - 1].Ready)
                    {
                        val++;
                        if (this.ownMinions[ii - 1].windfury) val++;
                    }
                    if (this.ownMinions[ii].Ready)
                    {
                        val++;
                        if (this.ownMinions[ii].windfury) val++;
                    }
                    if (val > maxVal)
                    {
                        place = ii + 1;
                        maxVal = val;
                    }
                }
                return place;
            }

            // 为军官准备
            if (Ai.Instance.botBase.BehaviorName() == "骑士" || Ai.Instance.botBase.BehaviorName() == "黑眼任务术")
            {
                int nowAngr = card.Attack;
                for (int ii = 0; ii < this.ownMinions.Count; ii++)
                {
                    if (this.ownMinions[ii].Angr < nowAngr)
                    {
                        return ii + 1;
                    }
                }
                return this.ownMinions.Count + 1;
            }


            int omCount = this.ownMinions.Count;
            int[] places = new int[omCount];
            int[] buffplaces = new int[omCount];
            int i = 0;
            int tempval = 0;
            if (lethal)
            {
                bool givesBuff = false;
                switch (card.nameEN)
                {
                    case CardDB.cardNameEN.grimestreetprotector: givesBuff = true; break;
                    case CardDB.cardNameEN.defenderofargus: givesBuff = true; break;
                    case CardDB.cardNameEN.flametonguetotem: givesBuff = true; break;
                    case CardDB.cardNameEN.direwolfalpha: givesBuff = true; break;
                    case CardDB.cardNameEN.ancientmage: givesBuff = true; break;
                    case CardDB.cardNameEN.tuskarrtotemic: givesBuff = true; break;
                    case CardDB.cardNameEN.battlegroundbattlemaster: givesBuff = true; break;
                }
                if (givesBuff)
                {
                    if (this.ownMinions.Count == 2) return 2;
                    i = 0;
                    foreach (Minion m in this.ownMinions)
                    {

                        places[i] = 0;
                        tempval = 0;
                        if (m.Ready)
                        {
                            tempval -= m.Angr - 1;
                            if (m.windfury) tempval -= m.Angr - 1;
                        }
                        else tempval = 1000;
                        places[i] = tempval;

                        i++;
                    }

                    i = 0;
                    int bestpl = 7;
                    int bestval = 10000;
                    foreach (Minion m in this.ownMinions)
                    {
                        int prev = 0;
                        int next = 0;
                        if (i >= 1) prev = places[i - 1];
                        next = places[i];
                        if (bestval >= prev + next)
                        {
                            bestval = prev + next;
                            bestpl = i;
                        }
                        i++;
                    }
                    return bestpl + 1;
                }
                else return this.ownMinions.Count + 1;
            }
            if (card.nameEN == CardDB.cardNameEN.sunfuryprotector || card.nameEN == CardDB.cardNameEN.defenderofargus) // bestplace, if right and left minions have no taunt + lots of hp, dont make priority-minions to taunt
            {//日怒
                if (lethal) return 1;
                if (this.ownMinions.Count == 2)
                {
                    int val1 = prozis.penman.getValueOfUsefulNeedKeepPriority(this.ownMinions[0].handcard.card.nameEN);
                    int val2 = prozis.penman.getValueOfUsefulNeedKeepPriority(this.ownMinions[1].handcard.card.nameEN);
                    if (val1 == 0 && val2 == 0) return 2;
                    else if (val1 > val2) return 3;
                    else return 1;
                }

                i = 0;
                foreach (Minion m in this.ownMinions)
                {

                    places[i] = 0;
                    tempval = 0;
                    if (!m.taunt)
                    {
                        tempval -= m.Hp;
                    }
                    else
                    {
                        tempval -= m.Hp - 2;
                    }

                    if (m.windfury)
                    {
                        tempval += 2;
                    }

                    tempval += prozis.penman.getValueOfUsefulNeedKeepPriority(m.handcard.card.nameEN);
                    places[i] = tempval;
                    i++;
                }


                i = 0;
                int bestpl = 7;
                int bestval = 10000;
                foreach (Minion m in this.ownMinions)
                {
                    int prev = 0;
                    int next = 0;
                    if (i >= 1) prev = places[i - 1];
                    next = places[i];
                    if (bestval > prev + next)
                    {
                        bestval = prev + next;
                        bestpl = i;
                    }
                    i++;
                }
                return bestpl + 1;
            }

            int cardIsBuffer = 0;
            bool placebuff = false;
            if (card.nameEN == CardDB.cardNameEN.flametonguetotem || card.nameEN == CardDB.cardNameEN.direwolfalpha || card.nameEN == CardDB.cardNameEN.tuskarrtotemic || card.nameEN == CardDB.cardNameEN.battlegroundbattlemaster)
            {
                placebuff = true;
                if (card.nameEN == CardDB.cardNameEN.flametonguetotem || card.nameEN == CardDB.cardNameEN.tuskarrtotemic) cardIsBuffer = 2;
                if (card.nameEN == CardDB.cardNameEN.direwolfalpha) cardIsBuffer = 1;
            }
            bool tundrarhino = false;
            foreach (Minion m in this.ownMinions)
            {
                if (m.handcard.card.nameEN == CardDB.cardNameEN.tundrarhino) tundrarhino = true;
                if (m.handcard.card.nameEN == CardDB.cardNameEN.flametonguetotem || m.handcard.card.nameEN == CardDB.cardNameEN.direwolfalpha || card.nameEN == CardDB.cardNameEN.battlegroundbattlemaster) placebuff = true;
            }
            //max attack this turn
            if (placebuff)
            {


                int cval = 0;
                if (card.Charge || (card.race == CardDB.Race.BEAST && tundrarhino))
                {
                    cval = card.Attack;
                    if (card.windfury) cval = card.Attack;
                }
                if (card.nameEN == CardDB.cardNameEN.nerubianegg)
                {
                    cval += 1;
                }
                i = 0;
                int[] whirlwindplaces = new int[this.ownMinions.Count];
                int gesval = 0;
                int minionsBefore = -1;
                int minionsAfter = -1;
                foreach (Minion m in this.ownMinions)
                {
                    buffplaces[i] = 0;
                    whirlwindplaces[i] = 1;
                    places[i] = 0;
                    tempval = -1;

                    if (m.Ready)
                    {
                        tempval = m.Angr;
                        if (m.windfury && m.numAttacksThisTurn == 0)
                        {
                            tempval += m.Angr;
                            whirlwindplaces[i] = 2;
                        }
                    }
                    else whirlwindplaces[i] = 0;

                    switch (m.handcard.card.nameEN)
                    {
                        case CardDB.cardNameEN.flametonguetotem:
                            buffplaces[i] = 2;
                            goto case CardDB.cardNameEN.aiextra1;
                        case CardDB.cardNameEN.direwolfalpha:
                            buffplaces[i] = 1;
                            goto case CardDB.cardNameEN.aiextra1;
                        case CardDB.cardNameEN.aiextra1:
                            if (minionsBefore == -1) minionsBefore = i;
                            minionsAfter = omCount - i - 1;
                            break;
                    }
                    tempval++;
                    places[i] = tempval;
                    gesval += tempval;
                    i++;
                }
                //gesval = whole possible damage
                int bplace = 0;
                int bvale = 0;
                bool needbefore = false;
                int middle = (omCount + 1) / 2;
                int middleProximity = 1000;
                int tmp = 0;
                if (minionsBefore > -1 && minionsBefore <= minionsAfter) needbefore = true;
                tempval = 0;
                for (i = 0; i <= omCount; i++)
                {
                    tempval = gesval;
                    int current = cval;
                    int prev = 0;
                    int next = 0;
                    if (i >= 1)
                    {
                        tempval -= places[i - 1];
                        prev = places[i - 1];
                        if (prev >= 0) prev += whirlwindplaces[i - 1] * cardIsBuffer;
                        if (i < omCount)
                        {
                            prev -= whirlwindplaces[i - 1] * buffplaces[i];
                        }
                        if (current > 0) current += buffplaces[i - 1];
                    }
                    if (i < omCount)
                    {
                        tempval -= places[i];
                        next = places[i];
                        if (next >= 0) next += whirlwindplaces[i] * cardIsBuffer;
                        if (i >= 1)
                        {
                            next -= whirlwindplaces[i] * buffplaces[i - 1];
                        }
                        if (current > 0) current += buffplaces[i];
                    }
                    tempval += current + prev + next;

                    bool setVal = false;
                    if (tempval > bvale) setVal = true;
                    else if (tempval == bvale)
                    {
                        if (needbefore)
                        {
                            if (i <= minionsBefore) setVal = true;
                        }
                        else
                        {
                            if (minionsBefore > -1)
                            {
                                if (i >= omCount - minionsAfter) setVal = true;
                            }
                            else
                            {
                                tmp = middle - i;
                                if (tmp < 0) tmp *= -1;
                                if (tmp <= middleProximity)
                                {
                                    middleProximity = tmp;
                                    setVal = true;
                                }
                            }
                        }
                    }
                    if (setVal)
                    {
                        bplace = i;
                        bvale = tempval;
                    }
                }
                return bplace + 1;
            }

            // normal placement
            int bestplace = 0;
            int bestvale = 0;
            if (prozis.settings.placement == 1)
            {
                int cardvalue = card.Health * 2 + card.Attack;
                if (card.Shield) cardvalue = cardvalue * 3 / 2;
                cardvalue += prozis.penman.getValueOfUsefulNeedKeepPriority(card.nameEN);

                i = 0;
                foreach (Minion m in this.ownMinions)
                {
                    places[i] = 0;
                    tempval = m.maxHp * 2 + m.Angr;
                    if (m.divineshild) tempval = tempval * 3 / 2;
                    if (!m.silenced) tempval += prozis.penman.getValueOfUsefulNeedKeepPriority(m.handcard.card.nameEN);
                    places[i] = tempval;
                    i++;
                }

                tempval = 0;
                for (i = 0; i <= omCount; i++)
                {
                    if (i >= omCount - i)
                    {
                        bestplace = i;
                        break;
                    }
                    if (cardvalue >= places[i])
                    {
                        if (cardvalue < places[omCount - i - 1])
                        {
                            bestplace = i;
                            break;
                        }
                        else
                        {
                            if (places[i] > places[omCount - i - 1]) bestplace = omCount - i;
                            else bestplace = i;
                            break;
                        }
                    }
                    else
                    {
                        if (cardvalue >= places[omCount - i - 1])
                        {
                            bestplace = omCount - i;
                            break;
                        }
                    }
                }
            }
            else
            {
                int cardvalue = card.Attack * 2 + card.Health;
                if (card.tank)
                {
                    cardvalue += 5;
                    cardvalue += card.Health;
                }

                cardvalue += prozis.penman.getValueOfUsefulNeedKeepPriority(card.nameEN);
                cardvalue += 1;

                i = 0;
                foreach (Minion m in this.ownMinions)
                {
                    places[i] = 0;
                    tempval = m.Angr * 2 + m.maxHp;
                    if (m.taunt)
                    {
                        tempval += 6;
                        tempval += m.maxHp;
                    }
                    if (!m.silenced)
                    {
                        tempval += prozis.penman.getValueOfUsefulNeedKeepPriority(m.handcard.card.nameEN);
                        if (m.stealth) tempval += 40;
                    }
                    places[i] = tempval;

                    i++;
                }

                //bigminion if >=10
                tempval = 0;
                for (i = 0; i <= omCount; i++)
                {
                    int prev = cardvalue;
                    int next = cardvalue;
                    if (i >= 1) prev = places[i - 1];
                    if (i < omCount) next = places[i];


                    if (cardvalue >= prev && cardvalue >= next)
                    {
                        tempval = 2 * cardvalue - prev - next;
                        if (tempval > bestvale)
                        {
                            bestplace = i;
                            bestvale = tempval;
                        }
                    }
                    if (cardvalue <= prev && cardvalue <= next)
                    {
                        tempval = -2 * cardvalue + prev + next;
                        if (tempval > bestvale)
                        {
                            bestplace = i;
                            bestvale = tempval;
                        }
                    }
                }

            }

            return bestplace + 1;
        }

        public int getBestAdapt(Minion m) //1-+1/+1, 2-angr, 3-hp, 4-taunt, 5-divine, 6-poison
        {
            bool ownLethal = this.ownHeroHasDirectLethal();
            bool needTaunt = false;
            if (ownLethal) needTaunt = true;
            else if (m.Ready)
            {
                if (guessEnemyHeroLethalMissing() <= 3) { this.minionGetBuffed(m, 3, 0); return 2; }
                else if (ownLethal) needTaunt = true;
                else
                {
                    if (m.Hp > 3) { this.minionGetBuffed(m, 0, 3); return 3; }
                    else { m.poisonous = true; return 6; }
                }
            }
            else { this.minionGetBuffed(m, 1, 1); return 1; }

            if (needTaunt)
            {
                if (!m.taunt)
                {
                    m.taunt = true;
                    if (m.own) this.anzOwnTaunt++;
                    else this.anzEnemyTaunt++;
                    return 4;
                }
                else if (!m.divineshild) { m.divineshild = true; return 5; }
                else if (!m.poisonous) { m.poisonous = true; return 6; }
                else { this.minionGetBuffed(m, 0, 3); return 3; }
            }
            return 0;
        }

        public int guessEnemyHeroLethalMissing()
        {//猜测敌方英雄血量丢失
            int lethalMissing = this.enemyHero.armor + this.enemyHero.Hp;
            if (this.anzEnemyTaunt == 0)
            {
                foreach (Minion m in this.ownMinions)
                {
                    if (m.Ready)
                    {
                        lethalMissing -= m.Angr;
                        if (m.windfury && m.numAttacksThisTurn == 0) lethalMissing -= m.Angr;
                    }
                }
            }
            return lethalMissing;
        }

        public void guessHeroDamage()
        {//随机伤害
            int ghd = 0;
            int ablilityDmg = 0;
            switch (this.enemyHeroAblility.card.cardIDenum)
            {
                //direct damage直伤
                case CardDB.cardIDEnum.HERO_05bp: ablilityDmg += 2; break;//猎人技能
                // case CardDB.cardIDEnum.HERO_11fbp: ablilityDmg += 2; break;//dk技能
                case CardDB.cardIDEnum.DS1h_292_H1: ablilityDmg += 2; break;
                case CardDB.cardIDEnum.HERO_05bp2: ablilityDmg += 3; break;
                case CardDB.cardIDEnum.DS1h_292_H1_AT_132: ablilityDmg += 3; break;
                case CardDB.cardIDEnum.NAX15_02: ablilityDmg += 2; break;
                case CardDB.cardIDEnum.NAX15_02H: ablilityDmg += 2; break;
                case CardDB.cardIDEnum.NAX6_02: ablilityDmg += 3; break;
                case CardDB.cardIDEnum.NAX6_02H: ablilityDmg += 3; break;
                case CardDB.cardIDEnum.HERO_08bp: ablilityDmg += 1; break;
                case CardDB.cardIDEnum.CS2_034_H1: ablilityDmg += 1; break;
                case CardDB.cardIDEnum.CS2_034_H2: ablilityDmg += 1; break;
                case CardDB.cardIDEnum.AT_050t: ablilityDmg += 2; break;
                case CardDB.cardIDEnum.HERO_08bp2: ablilityDmg += 2; break;
                case CardDB.cardIDEnum.CS2_034_H1_AT_132: ablilityDmg += 2; break;
                case CardDB.cardIDEnum.CS2_034_H2_AT_132: ablilityDmg += 2; break;
                case CardDB.cardIDEnum.EX1_625t: ablilityDmg += 2; break;
                case CardDB.cardIDEnum.EX1_625t2: ablilityDmg += 3; break;
                case CardDB.cardIDEnum.TU4d_003: ablilityDmg += 1; break;
                case CardDB.cardIDEnum.NAX7_03: ablilityDmg += 3; break;
                case CardDB.cardIDEnum.NAX7_03H: ablilityDmg += 4; break;
                case CardDB.cardIDEnum.ICC_830p: ablilityDmg += 2; break;//牧师dk技能
                case CardDB.cardIDEnum.ICC_831p: ablilityDmg += 3; break;//术士dk 技能
                case CardDB.cardIDEnum.ICC_833h: ablilityDmg += 1; break;//法师 dk技能
                //condition 有条件的
                case CardDB.cardIDEnum.BRMA05_2H: if (this.mana > 0) ablilityDmg += 10; break;
                case CardDB.cardIDEnum.BRMA05_2: if (this.mana > 0) ablilityDmg += 5; break;
                case CardDB.cardIDEnum.BRM_027p: if (this.ownMinions.Count < 1) ablilityDmg += 8; break;
                case CardDB.cardIDEnum.BRM_027pH: if (this.ownMinions.Count < 2) ablilityDmg += 8; break;
                case CardDB.cardIDEnum.TB_MechWar_Boss2_HeroPower: if (this.ownMinions.Count < 2) ablilityDmg += 1; break;
                //equip weapon 装备武器
                case CardDB.cardIDEnum.LOEA09_2: if (this.enemyWeapon.Durability < 1 && !this.enemyHero.frozen) ghd += 2; break;
                case CardDB.cardIDEnum.LOEA09_2H: if (this.enemyWeapon.Durability < 1 && !this.enemyHero.frozen) ghd += 5; break;
                case CardDB.cardIDEnum.HERO_03bp: if (this.enemyWeapon.Durability < 1 && !this.enemyHero.frozen) ghd += 1; break;
                case CardDB.cardIDEnum.CS2_083b_H1: if (this.enemyWeapon.Durability < 1 && !this.enemyHero.frozen) ghd += 1; break;
                case CardDB.cardIDEnum.HERO_03bp2: if (this.enemyWeapon.Durability < 1 && !this.enemyHero.frozen) ghd += 2; break;
                case CardDB.cardIDEnum.HERO_06bp: if (!this.enemyHero.frozen) ghd += 1; break;
                case CardDB.cardIDEnum.HERO_06bp2: if (!this.enemyHero.frozen) ghd += 2; break;
                case CardDB.cardIDEnum.ICC_832p: if (!this.enemyHero.frozen) ghd += 3; break;
            }

            ghd += ablilityDmg;
            foreach (Minion m in this.enemyMinions)
            {
                if (m.frozen) continue;
                switch (m.name)
                {
                    case CardDB.cardNameEN.ancientwatcher: if (!m.silenced) continue; break;
                    case CardDB.cardNameEN.blackknight: if (!m.silenced) continue; break;
                    case CardDB.cardNameEN.whiteknight: if (!m.silenced) continue; break;
                    case CardDB.cardNameEN.humongousrazorleaf: if (!m.silenced) continue; break;
                }
                ghd += m.Angr;//总伤害
                if (m.windfury) ghd += m.Angr;
            }

            if (this.enemyWeapon.Durability > 0 && !this.enemyHero.frozen)
            {
                ghd += this.enemyWeapon.Angr;
                if (this.enemyHero.windfury && this.enemyWeapon.Durability > 1) ghd += this.enemyWeapon.Angr;
            }

            foreach (Minion m in this.ownMinions)
            {
                if (m.taunt) ghd -= m.Hp;
                if (m.taunt && m.divineshild) ghd -= 1;
            }

            int guessingHeroDamage = Math.Max(0, ghd);
            if (this.ownHero.immune) guessingHeroDamage = 0;
            this.guessingHeroHP = this.ownHero.Hp + this.ownHero.armor - guessingHeroDamage;

            bool haveImmune = false;
            if (this.guessingHeroHP < 1 && this.ownSecretsIDList.Count > 0)//场面伤害我死了的时候,有奥秘,计算能挡的伤害
            {
                foreach (CardDB.cardIDEnum secretID in this.ownSecretsIDList)
                {
                    switch (secretID)
                    {//能抗上伤害的奥秘
                        case CardDB.cardIDEnum.EX1_130: //Noble Sacrifice
                            if (this.enemyMinions.Count > 0)
                            {
                                int mAngr = 1000;
                                foreach (Minion m in this.enemyMinions)
                                {
                                    if (!m.frozen && m.Angr < mAngr && m.Angr > 0) mAngr = m.Angr; //take the weakest
                                }
                                if (mAngr != 1000) this.guessingHeroHP += mAngr;
                            }
                            continue;
                        case CardDB.cardIDEnum.EX1_533: //Misdirection误导
                            if (this.enemyMinions.Count > 0)
                            {
                                int mAngr = 1000;
                                foreach (Minion m in this.enemyMinions)
                                {
                                    if (!m.frozen && m.Angr < mAngr && m.Angr > 0) mAngr = m.Angr; //take the weakest
                                }
                                if (mAngr != 1000) this.guessingHeroHP += mAngr;
                            }
                            continue;
                        case CardDB.cardIDEnum.AT_060: //Bear Trap
                            if (this.enemyMinions.Count > 1) this.guessingHeroHP += 3;
                            continue;
                        case CardDB.cardIDEnum.EX1_611: //Freezing Trap
                            if (this.enemyMinions.Count > 0)
                            {
                                int mAngr = 1000;
                                int mCharge = 0;
                                foreach (Minion m in this.enemyMinions)
                                {
                                    if (!m.frozen && m.Angr < mAngr && m.Angr > 0)
                                    {
                                        mAngr = m.Angr; //take the weakest
                                        mCharge = m.charge;
                                    }
                                }
                                if (mAngr < 1000 && mCharge < 1) this.guessingHeroHP += mAngr;
                            }
                            continue;
                        case CardDB.cardIDEnum.EX1_289: //Ice Barrier 寒冰护体
                            this.guessingHeroHP += 8;
                            continue;
                        case CardDB.cardIDEnum.EX1_295: //Ice Block
                            haveImmune = true;
                            break;
                        case CardDB.cardIDEnum.EX1_594: //Vaporize
                            if (this.enemyMinions.Count > 0)
                            {
                                int mAngr = 1000;
                                foreach (Minion m in this.enemyMinions)
                                {
                                    if (!m.frozen && m.Angr < mAngr && m.Angr > 0) mAngr = m.Angr; //take the weakest
                                }
                                if (mAngr != 1000) this.guessingHeroHP += mAngr;
                            }
                            continue;
                        case CardDB.cardIDEnum.CORE_EX1_610: //Explosive Trap
                        case CardDB.cardIDEnum.VAN_EX1_610: //Explosive Trap
                        case CardDB.cardIDEnum.EX1_610: //Explosive Trap
                            if (this.enemyMinions.Count > 0)
                            {
                                int losshd = 0;
                                foreach (Minion m in this.enemyMinions)
                                {
                                    if (m.frozen) continue;
                                    switch (m.name)
                                    {
                                        case CardDB.cardNameEN.ancientwatcher: if (!m.silenced) continue; break;
                                        case CardDB.cardNameEN.blackknight: if (!m.silenced) continue; break;
                                        case CardDB.cardNameEN.whiteknight: if (!m.silenced) continue; break;
                                        case CardDB.cardNameEN.humongousrazorleaf: if (!m.silenced) continue; break;
                                    }
                                    if (m.Hp < 3)
                                    {
                                        losshd += m.Angr;
                                        if (m.windfury) losshd += m.Angr;
                                    }
                                }
                                this.guessingHeroHP += losshd;
                            }
                            continue;
                        //此处可加火焰陷阱
                        case CardDB.cardIDEnum.ULD_239: //Explosive Trap
                            if (this.enemyMinions.Count > 0)
                            {
                                int losshd = 0;
                                int maxAngr = 0;
                                foreach (Minion m in this.enemyMinions)
                                {
                                    if (m.frozen) continue;
                                    switch (m.name)
                                    {
                                        case CardDB.cardNameEN.ancientwatcher: if (!m.silenced) continue; break;
                                        case CardDB.cardNameEN.blackknight: if (!m.silenced) continue; break;
                                        case CardDB.cardNameEN.whiteknight: if (!m.silenced) continue; break;
                                        case CardDB.cardNameEN.humongousrazorleaf: if (!m.silenced) continue; break;
                                    }
                                    if (m.Hp < 4)
                                    {
                                        losshd += m.Angr;
                                        if (maxAngr < m.Angr) maxAngr = m.Angr;
                                        if (m.windfury) losshd += m.Angr;
                                    }
                                }
                                this.guessingHeroHP += losshd - maxAngr;
                            }
                            continue;
                    }
                }
                if (haveImmune && this.guessingHeroHP < 2) this.guessingHeroHP = 2;
            }
            if (this.ownHero.Hp + this.ownHero.armor <= ablilityDmg && !haveImmune) this.guessingHeroHP = this.ownHero.Hp + this.ownHero.armor - ablilityDmg;
        }



        public bool ownHeroHasDirectLethal()
        {//我方被斩杀的可能性
            //fastLethalCheck
            if (this.anzOwnTaunt != 0) return false;
            if (this.ownHero.immune) return false;
            int totalEnemyDamage = 0;
            foreach (Minion m in this.enemyMinions)
            {
                if (!m.frozen && !m.cantAttack)
                {
                    switch (m.name)
                    {
                        case CardDB.cardNameEN.icehowl: if (!m.silenced) continue; break;
                    }
                    totalEnemyDamage += m.Angr;
                    if (m.windfury) totalEnemyDamage += m.Angr;
                }
            }

            if (this.enemyAbilityReady)
            {
                switch (this.enemyHeroAblility.card.cardIDenum)
                {
                    //direct damage
                    case CardDB.cardIDEnum.HERO_05bp: totalEnemyDamage += 2; break;
                    case CardDB.cardIDEnum.DS1h_292_H1: totalEnemyDamage += 2; break;
                    case CardDB.cardIDEnum.HERO_05bp2: totalEnemyDamage += 3; break;
                    case CardDB.cardIDEnum.DS1h_292_H1_AT_132: totalEnemyDamage += 3; break;
                    case CardDB.cardIDEnum.NAX15_02: totalEnemyDamage += 2; break;
                    case CardDB.cardIDEnum.NAX15_02H: totalEnemyDamage += 2; break;
                    case CardDB.cardIDEnum.NAX6_02: totalEnemyDamage += 3; break;
                    case CardDB.cardIDEnum.NAX6_02H: totalEnemyDamage += 3; break;
                    case CardDB.cardIDEnum.HERO_08bp: totalEnemyDamage += 1; break;
                    case CardDB.cardIDEnum.CS2_034_H1: totalEnemyDamage += 1; break;
                    case CardDB.cardIDEnum.CS2_034_H2: totalEnemyDamage += 1; break;
                    case CardDB.cardIDEnum.AT_050t: totalEnemyDamage += 2; break;
                    case CardDB.cardIDEnum.HERO_08bp2: totalEnemyDamage += 2; break;
                    case CardDB.cardIDEnum.CS2_034_H1_AT_132: totalEnemyDamage += 2; break;
                    case CardDB.cardIDEnum.CS2_034_H2_AT_132: totalEnemyDamage += 2; break;
                    case CardDB.cardIDEnum.EX1_625t: totalEnemyDamage += 2; break;
                    case CardDB.cardIDEnum.EX1_625t2: totalEnemyDamage += 3; break;
                    case CardDB.cardIDEnum.TU4d_003: totalEnemyDamage += 1; break;
                    case CardDB.cardIDEnum.NAX7_03: totalEnemyDamage += 3; break;
                    case CardDB.cardIDEnum.NAX7_03H: totalEnemyDamage += 4; break;
                    //condition
                    case CardDB.cardIDEnum.BRMA05_2H: if (this.mana > 0) totalEnemyDamage += 10; break;
                    case CardDB.cardIDEnum.BRMA05_2: if (this.mana > 0) totalEnemyDamage += 5; break;
                    case CardDB.cardIDEnum.BRM_027p: if (this.ownMinions.Count < 1) totalEnemyDamage += 8; break;
                    case CardDB.cardIDEnum.BRM_027pH: if (this.ownMinions.Count < 2) totalEnemyDamage += 8; break;
                    case CardDB.cardIDEnum.TB_MechWar_Boss2_HeroPower: if (this.ownMinions.Count < 2) totalEnemyDamage += 1; break;
                    //equip weapon
                    case CardDB.cardIDEnum.LOEA09_2: if (this.enemyWeapon.Durability < 1 && !this.enemyHero.frozen) totalEnemyDamage += 2; break;
                    case CardDB.cardIDEnum.LOEA09_2H: if (this.enemyWeapon.Durability < 1 && !this.enemyHero.frozen) totalEnemyDamage += 5; break;
                    case CardDB.cardIDEnum.HERO_06bp: if (this.enemyWeapon.Durability < 1 && !this.enemyHero.frozen) totalEnemyDamage += 1; break;
                    case CardDB.cardIDEnum.HERO_03bp: if (this.enemyWeapon.Durability < 1 && !this.enemyHero.frozen) totalEnemyDamage += 1; break;
                    case CardDB.cardIDEnum.CS2_083b_H1: if (this.enemyWeapon.Durability < 1 && !this.enemyHero.frozen) totalEnemyDamage += 1; break;
                    case CardDB.cardIDEnum.HERO_03bp2: if (this.enemyWeapon.Durability < 1 && !this.enemyHero.frozen) totalEnemyDamage += 2; break;
                    case CardDB.cardIDEnum.HERO_06bp2: if (this.enemyWeapon.Durability < 1 && !this.enemyHero.frozen) totalEnemyDamage += 2; break;
                }
            }
            if (this.enemyWeapon.Durability > 0 && this.enemyHero.Ready && !this.enemyHero.frozen)
            {
                totalEnemyDamage += this.enemyWeapon.Angr;
                if (this.enemyHero.windfury && this.enemyWeapon.Durability > 1) totalEnemyDamage += this.enemyWeapon.Angr;
            }

            if (totalEnemyDamage < this.ownHero.Hp + this.ownHero.armor) return false;
            if (this.ownSecretsIDList.Count > 0)
            {
                foreach (CardDB.cardIDEnum secretID in this.ownSecretsIDList)
                {
                    switch (secretID)
                    {
                        case CardDB.cardIDEnum.EX1_289: //Ice Barrier 寒冰护体
                            totalEnemyDamage -= 8;
                            continue;
                        case CardDB.cardIDEnum.EX1_295: //Ice Block
                            return false;
                        case CardDB.cardIDEnum.EX1_130: //Noble Sacrifice
                            return false;
                        case CardDB.cardIDEnum.EX1_533: //Misdirection
                            return false;
                        case CardDB.cardIDEnum.EX1_594: //Vaporize
                            return false;
                        case CardDB.cardIDEnum.EX1_611: //Freezing Trap
                            return false;
                        case CardDB.cardIDEnum.EX1_610: //Explosive Trap
                            return false;
                        case CardDB.cardIDEnum.AT_060: //Bear Trap
                            return false;
                        case CardDB.cardIDEnum.EX1_132: //Eye for an Eye
                            if ((this.enemyHero.Hp + this.enemyHero.armor) <= (this.ownHero.Hp + this.ownHero.armor) && !this.enemyHero.immune) return false;
                            continue;
                        case CardDB.cardIDEnum.LOE_021: //Dart Trap
                            if ((this.enemyHero.Hp + this.enemyHero.armor) < 6 && !this.enemyHero.immune) return false;
                            continue;
                    }
                }
            }
            if (totalEnemyDamage < this.ownHero.Hp + this.ownHero.armor) return false;
            return true;
        }

        public void simulateTrapsStartEnemyTurn() //在敌方回合开始时模拟触发我方奥秘
        {
            // DONT KILL ENEMY HERO (cause its only guessing)

            List<CardDB.cardIDEnum> tmpSecretsIDList = new List<CardDB.cardIDEnum>();
            List<Minion> temp;
            int pos;

            foreach (CardDB.cardIDEnum secretID in this.ownSecretsIDList)
            {
                switch (secretID)
                {
                    // 火焰结界：如果敌方怪兽属性值总和大于我方，则破坏我方场上所有怪兽，对敌方场上所有怪兽造成 3 点伤害

                    case CardDB.cardIDEnum.EX1_554: //snaketrap

                        pos = this.ownMinions.Count;
                        if (pos == 0) continue;
                        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_554t);//snake
                        callKid(kid, pos, true, false);
                        callKid(kid, pos, true);
                        callKid(kid, pos, true);
                        continue;
                    case CardDB.cardIDEnum.EX1_610: //explosive trap

                        temp = new List<Minion>(this.enemyMinions);
                        int damage = getSpellDamageDamage(2);
                        foreach (Minion m in temp)
                        {
                            minionGetDamageOrHeal(m, damage);
                        }
                        attackEnemyHeroWithoutKill(damage);
                        continue;
                    case CardDB.cardIDEnum.EX1_611: //freezing trap
                        {

                            int count = this.enemyMinions.Count;
                            if (count == 0) continue;
                            Minion mnn = this.enemyMinions[0];
                            for (int i = 1; i < count; i++)
                            {
                                if (this.enemyMinions[i].Angr < mnn.Angr) mnn = this.enemyMinions[i]; //take the weakest
                            }
                            minionReturnToHand(mnn, false, 0);
                            continue;
                        }
                    case CardDB.cardIDEnum.AT_060: //beartrap

                        if (this.enemyMinions.Count == 0 && ((this.enemyWeapon.Angr == 0 && !prozis.penman.HeroPowerEquipWeapon.ContainsKey(this.enemyHeroAblility.card.nameEN)) || this.enemyHero.frozen)) continue;
                        pos = this.ownMinions.Count;
                        callKid(CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_125), pos, true, false);
                        continue;
                    case CardDB.cardIDEnum.LOE_021: //Dart Trap

                        minionGetDamageOrHeal(this.enemyHero, getSpellDamageDamage(5), true);
                        continue;
                    case CardDB.cardIDEnum.EX1_533: // misdirection
                        {


                            int count = this.enemyMinions.Count;
                            if (count == 0 && ((this.enemyWeapon.Angr == 0 && !prozis.penman.HeroPowerEquipWeapon.ContainsKey(this.enemyHeroAblility.card.nameEN)) || this.enemyHero.frozen)) continue;
                            Minion mnn = this.enemyMinions[0];
                            for (int i = 1; i < count; i++)
                            {
                                if (this.enemyMinions[i].Angr > mnn.Angr) mnn = this.enemyMinions[i]; //take the strongest
                            }
                            mnn.Angr = 0;
                            //this.evaluatePenality -= this.enemyMinions.Count;// Todo: 不在这里引入打分 the more the enemy minions has on board, the more the posibility to destroy something other :D
                            continue;
                        }
                    case CardDB.cardIDEnum.KAR_004: //cattrick

                        pos = this.ownMinions.Count;
                        callKid(CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_017), pos, true, false);
                        continue;


                    case CardDB.cardIDEnum.EX1_287: //counterspell

                        wehaveCounterspell++;
                        continue;
                    case CardDB.cardIDEnum.EX1_289: //ice barrier  寒冰护体

                        if (this.enemyMinions.Count == 0 && ((this.enemyWeapon.Angr == 0 && !prozis.penman.HeroPowerEquipWeapon.ContainsKey(this.enemyHeroAblility.card.nameEN)) || this.enemyHero.frozen)) continue;
                        this.ownHero.armor += 8;
                        continue;
                    case CardDB.cardIDEnum.EX1_295: //ice block

                        guessHeroDamage();
                        if (guessingHeroHP < 11) this.ownHero.immune = true;
                        continue;
                    case CardDB.cardIDEnum.EX1_294: //mirror entity

                        if (this.ownMinions.Count < 7)
                        {
                            pos = this.ownMinions.Count - 1;
                            callKid(CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.TU4f_007), pos, true, false);
                        }
                        else goto default;
                        continue;
                    case CardDB.cardIDEnum.AT_002: //effigy

                        if (this.ownMinions.Count == 0) continue;
                        pos = this.ownMinions.Count - 1;
                        callKid(CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.TU4f_007), pos, true);
                        continue;
                    case CardDB.cardIDEnum.tt_010: //spellbender

                        //this.evaluatePenality -= 4;
                        continue;
                    case CardDB.cardIDEnum.EX1_594: // vaporize
                        {

                            int count = this.enemyMinions.Count;
                            if (count == 0) continue;
                            Minion mnn = this.enemyMinions[0];
                            for (int i = 1; i < count; i++)
                            {
                                if (this.enemyMinions[i].Angr < mnn.Angr) mnn = this.enemyMinions[i]; //take the weakest
                            }
                            minionGetDestroyed(mnn);
                            continue;
                        }
                    case CardDB.cardIDEnum.FP1_018: // duplicate
                        {

                            int count = this.ownMinions.Count;
                            if (count == 0) continue;
                            Minion mnn = this.ownMinions[0];
                            for (int i = 1; i < count; i++)
                            {
                                if (this.ownMinions[i].Angr < mnn.Angr) mnn = this.ownMinions[i]; //take the weakest
                            }
                            drawACard(mnn.name, true);
                            drawACard(mnn.name, true);
                            continue;
                        }




                    case CardDB.cardIDEnum.EX1_132: // eye for an eye
                        {

                            // todo for mage and hunter
                            if (this.enemyHero.frozen && this.enemyMinions.Count == 0) continue;
                            int dmg = 0;
                            int dmgW = 0;

                            int count = this.enemyMinions.Count;
                            if (count != 0)
                            {
                                Minion mnn = this.enemyMinions[0];
                                for (int i = 1; i < count; i++)
                                {
                                    if (this.enemyMinions[i].Angr < mnn.Angr) mnn = this.enemyMinions[i]; //take the weakest
                                }
                                dmg = mnn.Angr;
                            }
                            if (this.enemyWeapon.Angr != 0) dmgW = this.enemyWeapon.Angr;
                            else if (prozis.penman.HeroPowerEquipWeapon.ContainsKey(this.enemyHeroAblility.card.nameEN)) dmgW = prozis.penman.HeroPowerEquipWeapon[this.enemyHeroAblility.card.nameEN];
                            if (dmgW != 0)
                            {
                                if (dmg != 0)
                                {
                                    if (dmgW < dmg) dmg = dmgW;
                                }
                                else dmg = dmgW;
                            }
                            dmg = getSpellDamageDamage(dmg);
                            if (dmg != 0) attackEnemyHeroWithoutKill(dmg);
                            continue;
                        }
                    case CardDB.cardIDEnum.EX1_130: // noble sacrifice

                        if (this.enemyMinions.Count == 0 && ((this.enemyWeapon.Angr == 0 && !prozis.penman.HeroPowerEquipWeapon.ContainsKey(this.enemyHeroAblility.card.nameEN)) || this.enemyHero.frozen)) continue;
                        if (this.ownMinions.Count == 7) continue;
                        pos = this.ownMinions.Count - 1;
                        callKid(CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_097), pos, true, false);
                        continue;
                    case CardDB.cardIDEnum.EX1_136: // redemption


                        if (this.ownMinions.Count == 0) continue;
                        temp = new List<Minion>(this.ownMinions);
                        temp.Sort((a, b) => a.Hp.CompareTo(b.Hp));
                        foreach (Minion m in temp)
                        {
                            if (m.divineshild) continue;
                            m.divineshild = true;
                            break;
                        }
                        continue;
                    case CardDB.cardIDEnum.FP1_020: // avenge


                        if (this.ownMinions.Count < 2 || (this.ownMinions.Count == 1 && !this.ownSecretsIDList.Contains(CardDB.cardIDEnum.EX1_130))) continue;
                        temp = new List<Minion>(this.ownMinions);
                        temp.Sort((a, b) => a.Hp.CompareTo(b.Hp));
                        minionGetBuffed(temp[0], 3, 2);
                        continue;
                    default:
                        tmpSecretsIDList.Add(secretID);
                        continue;
                }
            }
            this.ownSecretsIDList.Clear();
            this.ownSecretsIDList.AddRange(tmpSecretsIDList);

            this.doDmgTriggers();
        }

        public void simulateTrapsEndEnemyTurn()
        {
            // DONT KILL ENEMY HERO (cause its only guessing)

            List<CardDB.cardIDEnum> tmpSecretsIDList = new List<CardDB.cardIDEnum>();
            List<Minion> temp;

            bool activate = false;
            foreach (CardDB.cardIDEnum secretID in this.ownSecretsIDList)
            {
                switch (secretID)
                {








                    case CardDB.cardIDEnum.EX1_609: //snipe

                        activate = false;
                        if (this.enemyMinions.Count > 0)
                        {
                            temp = new List<Minion>(this.enemyMinions);
                            int damage = getSpellDamageDamage(4);
                            foreach (Minion m in temp)
                            {
                                if (m.playedThisTurn)
                                {
                                    minionGetDamageOrHeal(m, damage);
                                    activate = true;
                                    break;
                                }
                            }
                        }
                        if (!activate) tmpSecretsIDList.Add(secretID);
                        continue;
















                    case CardDB.cardIDEnum.EX1_379: // repentance

                        activate = false;
                        if (this.enemyMinions.Count > 0)
                        {
                            temp = new List<Minion>(this.enemyMinions);
                            foreach (Minion m in temp)
                            {
                                if (m.playedThisTurn)
                                {
                                    m.Hp = 1;
                                    m.maxHp = 1;
                                    activate = true;
                                    break;
                                }
                            }
                        }
                        if (!activate) tmpSecretsIDList.Add(secretID);
                        continue;
                    case CardDB.cardIDEnum.LOE_027: // Sacred Trial

                        activate = false;
                        if (this.enemyMinions.Count > 3)
                        {
                            temp = new List<Minion>(this.enemyMinions);
                            foreach (Minion m in temp)
                            {
                                if (m.playedThisTurn)
                                {
                                    this.minionGetDestroyed(m);
                                    activate = true;
                                    break;
                                }
                            }
                        }
                        if (!activate) tmpSecretsIDList.Add(secretID);
                        continue;
                    case CardDB.cardIDEnum.AT_073: // competitivespirit

                        if (this.enemyMinions.Count == 0) continue;
                        foreach (Minion m in this.ownMinions)
                        {
                            minionGetBuffed(m, 1, 1);
                        }
                        continue;
                    default:
                        tmpSecretsIDList.Add(secretID);
                        continue;
                }
            }
            this.ownSecretsIDList.Clear();
            this.ownSecretsIDList.AddRange(tmpSecretsIDList);

            this.doDmgTriggers();
        }

        public void endTurn()           //回合结束时
        {
            if (this.turnCounter == 0) this.manaTurnEnd = this.mana;
            this.turnCounter++;
            this.pIdHistory.Add(0);

            if (isOwnTurn)
            {
                this.value = int.MinValue;
                //penalty for destroying combo
                this.evaluatePenality += ComboBreaker.Instance.checkIfComboWasPlayed(this);
                if (this.complete) return;
                
                this.anzOwnElementalsLastTurn = this.anzOwnElementalsThisTurn;      //令上回合使用元素等于本回合使用元素
                this.anzOwnElementalsThisTurn = 0;                                  //令本回合使用元素为0
            }
            else
            {
                simulateTrapsEndEnemyTurn();
            }

            this.triggerEndTurn(this.isOwnTurn);
            this.isOwnTurn = !this.isOwnTurn;
        }

        public void startTurn()
        {
            this.triggerStartTurn(this.isOwnTurn);
            if (!this.isOwnTurn)
            {
                simulateTrapsStartEnemyTurn();
                guessHeroDamage();
            }
            else
            {

                this.enemyHeroPowerCostLessOnce = 0;
            }
        }

        public void unlockMana()
        {
            this.ueberladung = 0;
            this.mana += lockedMana;
            this.lockedMana = 0;
        }

        //HeroPowerDamage calculation---------------------------------------------------
        public int getHeroPowerDamage(int dmg)
        {
            dmg += this.ownHeroPowerExtraDamage;
            if (this.doublepriest >= 1) dmg *= (2 * this.doublepriest);
            return dmg;
        }

        public int getEnemyHeroPowerDamage(int dmg)
        {
            dmg += this.enemyHeroPowerExtraDamage;
            if (this.enemydoublepriest >= 1) dmg *= (2 * this.enemydoublepriest);
            return dmg;
        }


        //spelldamage calculation---------------------------------------------------
        public int getSpellDamageDamage(int dmg)
        {
            int retval = dmg;
            retval += this.spellpower;
            if (this.doublepriest >= 1) retval *= (2 * this.doublepriest);
            return retval;
        }

        public int getSpellHeal(int heal)
        {
            int retval = heal;
            if (this.anzOwnAuchenaiSoulpriest > 0 || this.embracetheshadow > 0)
            {
                retval *= -1;
                retval -= this.spellpower;
            }
            if (this.doublepriest >= 1) retval *= (2 * this.doublepriest);
            return retval;
        }

        public void applySpellLifesteal(int heal, bool own)
        {
            bool minus = own ? (this.anzOwnAuchenaiSoulpriest > 0 || this.embracetheshadow > 0) : (this.anzEnemyAuchenaiSoulpriest > 0);
            this.minionGetDamageOrHeal(own ? ownHero : enemyHero, -heal * (minus ? -1 : 1));
        }

        public int getMinionHeal(int heal)
        {
            return (this.anzOwnAuchenaiSoulpriest > 0 || this.embracetheshadow > 0) ? -heal : heal;
        }

        public int getEnemySpellDamageDamage(int dmg)
        {
            int retval = dmg;
            retval += this.enemyspellpower;
            if (this.enemydoublepriest >= 1) retval *= (2 * this.enemydoublepriest);
            return retval;
        }

        public int getEnemySpellHeal(int heal)
        {
            int retval = heal;
            if (this.anzEnemyAuchenaiSoulpriest >= 1)
            {
                retval *= -1;
                retval -= this.enemyspellpower;
            }
            if (this.doublepriest >= 1) retval *= (2 * this.doublepriest);
            return retval;
        }

        public int getEnemyMinionHeal(int heal)
        {
            return (this.anzEnemyAuchenaiSoulpriest >= 1) ? -heal : heal;
        }


        // do the action--------------------------------------------------------------

        public void doAction(Action aa)  //执行一个操作,在这里面会更新场面的evaluatePenality值
        {
            //CREATE NEW MINIONS (cant use a.target or a.own) (dont belong to this board)
            Minion trgt = null;
            Minion o = null;
            Handmanager.Handcard ha = null;
            if (aa.target != null)
            {
                if (aa.target.own)
                {
                    if (aa.target.entitiyID == this.ownHero.entitiyID) trgt = this.ownHero;
                    else
                    {
                        foreach (Minion m in this.ownMinions)
                        {
                            if (aa.target.entitiyID == m.entitiyID)
                            {
                                trgt = m;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    if (aa.target.entitiyID == this.enemyHero.entitiyID) trgt = this.enemyHero;
                    else
                    {
                        foreach (Minion m in this.enemyMinions)
                        {
                            if (aa.target.entitiyID == m.entitiyID)
                            {
                                trgt = m;
                                break;
                            }
                        }
                    }
                }
                if (trgt == null)
                {
                    if (!aa.target.own)
                    {
                        if (aa.target.entitiyID == this.ownHero.entitiyID) trgt = this.ownHero;
                        else
                        {
                            foreach (Minion m in this.ownMinions)
                            {
                                if (aa.target.entitiyID == m.entitiyID)
                                {
                                    trgt = m;
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (aa.target.entitiyID == this.enemyHero.entitiyID) trgt = this.enemyHero;
                        else
                        {
                            foreach (Minion m in this.enemyMinions)
                            {
                                if (aa.target.entitiyID == m.entitiyID)
                                {
                                    trgt = m;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            if (aa.own != null)
            {
                if (aa.own.own)
                {
                    if (aa.own.entitiyID == this.ownHero.entitiyID) o = this.ownHero;
                    else
                    {
                        foreach (Minion m in this.ownMinions)
                        {
                            if (aa.own.entitiyID == m.entitiyID)
                            {
                                o = m;
                                break;
                            }
                        }
                        if (o == null)
                        {
                            foreach (Minion m in this.enemyMinions)
                            {
                                if (aa.own.entitiyID == m.entitiyID)
                                {
                                    o = m;
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (aa.own.entitiyID == this.enemyHero.entitiyID) o = this.enemyHero;
                    else
                    {
                        foreach (Minion m in this.enemyMinions)
                        {
                            if (aa.own.entitiyID == m.entitiyID)
                            {
                                o = m;
                                break;
                            }
                        }
                        if (o == null)
                        {
                            foreach (Minion m in this.ownMinions)
                            {
                                if (aa.own.entitiyID == m.entitiyID)
                                {
                                    o = m;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            if (aa.card != null)
            {
                foreach (Handmanager.Handcard hh in this.owncards)
                {
                    if (hh.entity == aa.card.entity)
                    {
                        ha = hh;
                        break;
                    }
                }
                if (aa.actionType == actionEnum.useHeroPower)
                {
                    ha = this.isOwnTurn ? this.ownHeroAblility : this.enemyHeroAblility;
                }
            }
            // create and execute the action------------------------------------------------------------------------
            Action a = new Action(aa.actionType, ha, o, aa.place, trgt, aa.penalty, aa.druidchoice);

            //save the action if its our first turn

            if (this.isOwnTurn) this.playactions.Add(a); //first turn is in the top level

            // its a minion attack 随从攻击--------------------------------
            if (a.actionType == actionEnum.attackWithMinion)
            {
                this.evaluatePenality += a.penalty;
                Minion target = a.target;
                //secret stuff
                int newTarget = this.secretTrigger_CharIsAttacked(a.own, target);

                if (newTarget >= 1)
                {
                    //search new target!
                    foreach (Minion m in this.ownMinions)
                    {
                        if (m.entitiyID == newTarget)
                        {
                            target = m;
                            break;
                        }
                    }
                    foreach (Minion m in this.enemyMinions)
                    {
                        if (m.entitiyID == newTarget)
                        {
                            target = m;
                            break;
                        }
                    }
                    if (this.ownHero.entitiyID == newTarget) target = this.ownHero;
                    if (this.enemyHero.entitiyID == newTarget) target = this.enemyHero;
                }
                if (a.own != null)
                    if (a.own.Hp >= 1) minionAttacksMinion(a.own, target);
            }
            else
            {
                // its an hero attack--------------------------------
                if (a.actionType == actionEnum.attackWithHero)
                {
                    //secret trigger is inside
                    attackWithWeapon(a.own, a.target, a.penalty);
                }
                else
                {
                    // its an playing-card--------------------------------
                    if (a.actionType == actionEnum.playcard)   // 执行操作，打一张牌
                    {
                        if (this.isOwnTurn)
                        {
                            playACard(a.card, a.target, a.place, a.druidchoice, a.penalty);
                            // 塔姆辛罗姆特效
                            if(this.anzTamsinroame > 0 && a.card.card.SpellSchool == CardDB.SpellSchool.SHADOW && a.card.card.getManaCost(this, a.card.getManaCost(this)) > 0)
                            {
                                for(int i =0;i < this.anzTamsinroame; i++)
                                {
                                    this.drawACard(a.card.card.cardIDenum, true, true);
                                    this.owncards[this.owncards.Count - 1].manacost = 0;
                                    this.evaluatePenality -= 10;
                                }
                            }

                            // TODO 召唤帕奇斯
                            if (patchesInDeck && a.card.card.race == CardDB.Race.PIRATE || a.card.card.race == CardDB.Race.ALL)
                            {
                                foreach (Minion m in this.ownMinions)
                                {
                                    if (m.handcard.card.nameCN == CardDB.cardNameCN.海盗帕奇斯)
                                    {
                                        this.patchesInDeck = false;
                                        break;
                                    }
                                }
                                foreach (Handmanager.Handcard hc in this.owncards)
                                {
                                    if (hc.card.nameCN == CardDB.cardNameCN.海盗帕奇斯)
                                    {
                                        this.patchesInDeck = false;
                                        break;
                                    }
                                }
                                // 遍历卡组
                                if (this.patchesInDeck)
                                    foreach (KeyValuePair<CardDB.cardIDEnum, int> kvp in this.prozis.turnDeck)
                                    {
                                        // ID 转卡
                                        CardDB.cardIDEnum deckCard = kvp.Key;
                                        if (deckCard == CardDB.cardIDEnum.CFM_637)
                                        {
                                            this.callKid(CardDB.Instance.getCardDataFromID(deckCard), this.ownMinions.Count, true);
                                            if (this.deckAngrBuff > 0)
                                            {
                                                this.minionGetBuffed(this.ownMinions[this.ownMinions.Count - 1], this.deckAngrBuff, this.deckHpBuff);
                                            }
                                            // 模拟时会失效
                                            // this.prozis.turnDeck.Remove(deckCard);
                                            break;
                                        }
                                    }
                                this.patchesInDeck = false;
                            }

                            if (ownQuest.questProgress == ownQuest.maxProgress && ownQuest.Id != CardDB.cardIDEnum.None)
                            {
                                this.drawACard(ownQuest.Reward(), true);
                                ownQuest.Reset();
                            }
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        // its using the hero power--------------------------------
                        if (a.actionType == actionEnum.useHeroPower)
                        {
                            playHeroPower(a.target, a.penalty, this.isOwnTurn, a.druidchoice);
                        }

                        if (a.actionType == actionEnum.trade)
                        {
                            this.mana -= a.card.card.TradeCost;
                            this.drawACard(CardDB.cardIDEnum.None, true);
                            removeCard(a.card);
                            if (this.prozis.turnDeck.ContainsKey(a.card.card.cardIDenum))
                                this.prozis.turnDeck[a.card.card.cardIDenum]++;
                            else this.prozis.turnDeck.Add(a.card.card.cardIDenum, 1);
                        }
                    }
                }
            }

            if (this.isOwnTurn)
            {
                this.optionsPlayedThisTurn++;
            }
            else
            {
                this.enemyOptionsDoneThisTurn++;
            }

        }

        //minion attacks a minion

        //dontcount = betrayal effect! 随从攻击
        public void minionAttacksMinion(Minion attacker, Minion defender, bool dontcount = false)
        {
            if (attacker.Hp <= 0 || attacker.untouchable || defender.untouchable) return;
            int oldHp = defender.Hp;
            if (attacker.isHero)
            {
                if (defender.isHero)
                {
                    int dmg = attacker.Angr;
                    switch ((attacker.own ? this.ownWeapon.name : this.enemyWeapon.name))
                    {
                        case CardDB.cardNameEN.massiveruneblade:
                            dmg *= 2;
                            break;
                    }
                    switch ((attacker.own ? this.enemyWeapon.name : this.ownWeapon.name))
                    {
                        case CardDB.cardNameEN.bulwarkofazzinoth:
                            dmg = 1;
                            if (attacker.own)
                            {
                                this.enemyWeapon.Durability--;
                            }
                            else
                            {
                                this.ownWeapon.Durability--;
                            }
                            break;
                    }
                    defender.getDamageOrHeal(dmg, this, true, false);

                    switch ((attacker.own ? this.ownWeapon.name : this.enemyWeapon.name))
                    {
                        case CardDB.cardNameEN.gravevengeance:
                            if (oldHp > defender.Hp) this.triggerAMinionDealedDmg(attacker, oldHp - defender.Hp, true);
                            break;
                    }
                }
                else
                {
                    int dmg = attacker.Angr;
                    switch ((attacker.own ? this.enemyWeapon.name : this.ownWeapon.name))
                    {
                        case CardDB.cardNameEN.bulwarkofazzinoth:
                            dmg = 1;
                            if (attacker.own)
                            {
                                this.enemyWeapon.Durability--;
                            }
                            else
                            {
                                this.ownWeapon.Durability--;
                            }
                            break;
                    }
                    defender.getDamageOrHeal(dmg, this, true, false);
                    if (oldHp > defender.Hp)
                    {
                        if (attacker.poisonous) minionGetDestroyed(defender);
                        else
                        {
                            switch ((attacker.own ? this.ownWeapon.name : this.enemyWeapon.name))
                            {
                                case CardDB.cardNameEN.icebreaker:
                                    if (defender.frozen) minionGetDestroyed(defender);
                                    break;
                                case CardDB.cardNameEN.gravevengeance:
                                    this.triggerAMinionDealedDmg(attacker, oldHp - defender.Hp, true);
                                    break;
                            }
                        }
                    }

                    int enem_attack = defender.Angr;
                    if (!this.ownHero.immuneWhileAttacking)
                    {
                        oldHp = attacker.Hp;
                        attacker.getDamageOrHeal(enem_attack, this, true, false);
                        if (!defender.silenced && oldHp > attacker.Hp)
                        {
                            switch (defender.handcard.card.nameEN)
                            {
                                case CardDB.cardNameEN.voodoohexxer: goto case CardDB.cardNameEN.waterelemental;
                                case CardDB.cardNameEN.snowchugger: goto case CardDB.cardNameEN.waterelemental;
                                case CardDB.cardNameEN.waterelemental: minionGetFrozen(attacker); break;
                            }
                            this.triggerAMinionDealedDmg(defender, oldHp - attacker.Hp, false);
                        }
                    }
                }
                if (defender.GotDmgValue > 0) this.triggerAMinionDealedDmg(attacker, defender.GotDmgValue, true);
                // 添加武器的攻击效果
                if (this.ownWeapon != null && this.ownWeapon.card.sim_card != null)
                {
                    this.ownWeapon.card.sim_card.onHeroattack(this, new Minion(), defender);
                    this.ownWeapon.card.sim_card.onHeroattack(this, new Minion(), defender, this.ownHero);
                }
                foreach (Minion m in this.ownMinions.ToArray())
                {
                    if (!m.silenced && !dontcount)
                    {
                        m.handcard.card.sim_card.onHeroattack(this, m, defender);
                    }
                }
                doDmgTriggers();
                return;
            }
            //else if(!defender.isHero)
            //{
            //    switch (attacker.handcard.card.name)
            //    {
            //        // 狂踏的犀牛超杀
            //        case CardDB.cardName.tramplingrhino:
            //            if(attacker.Angr > defender.Hp && !defender.divineshild)
            //            {
            //                this.minionGetDamageOrHeal(this.enemyHero, attacker.Angr - defender.Hp);
            //            }
            //            break;
            //    }
            //}

            if (!dontcount)
            {
                attacker.numAttacksThisTurn++;
                attacker.stealth = false;
                if ((attacker.windfury && attacker.numAttacksThisTurn == 2) || !attacker.windfury)
                {
                    attacker.Ready = false;
                }

            }


            if (logging) Helpfunctions.Instance.logg(".attck with" + attacker.name + " A " + attacker.Angr + " H " + attacker.Hp);

            int attackerAngr = attacker.Angr;
            int defAngr = defender.Angr;

            //trigger attack ---------------------------
            this.triggerAMinionIsGoingToAttack(attacker, defender);

            int dmg1 = attacker.Angr;
            switch ((attacker.own ? this.enemyWeapon.name : this.ownWeapon.name))
            {
                case CardDB.cardNameEN.bulwarkofazzinoth:
                    if (this.enemyWeapon.Durability > 0)
                        dmg1 = 1;
                    if (attacker.own)
                    {
                        this.enemyWeapon.Durability--;
                    }
                    else
                    {
                        this.ownWeapon.Durability--;
                    }
                    break;
            }

            //defender gets dmg
            bool defenderHasDivineshild = defender.divineshild;//攻击前，被攻击随从是否具有圣盾
            oldHp = defender.Hp;
            defender.getDamageOrHeal(dmg1, this, true, false);
            //defender.getDamageOrHeal(attackerAngr, this, true, false);
            bool defenderGotDmg = oldHp > defender.Hp;
            if (defenderGotDmg)
            {
                switch (attacker.handcard.card.nameEN)
                {
                    case CardDB.cardNameEN.voodoohexxer: goto case CardDB.cardNameEN.waterelemental;
                    case CardDB.cardNameEN.snowchugger: goto case CardDB.cardNameEN.waterelemental;
                    case CardDB.cardNameEN.waterelemental:
                        if (!attacker.silenced) minionGetFrozen(defender);
                        break;
                }
                this.triggerAMinionDealedDmg(attacker, defender.GotDmgValue, true); // attacker did dmg
                // 处理吸血效果
                if (attacker.lifesteal)
                {
                    if (attacker.own)
                    {
                        this.minionGetDamageOrHeal(this.ownHero, -(oldHp - defender.Hp));
                    }
                    else
                    {
                        this.minionGetDamageOrHeal(this.enemyHero, -(oldHp - defender.Hp));
                    }
                }
                // 犀牛超杀效果
                if (!attacker.silenced && attacker.handcard.card.nameEN == CardDB.cardNameEN.tramplingrhino)
                {
                    if (attacker.own)
                    {
                        this.minionGetDamageOrHeal(this.enemyHero, -defender.Hp);
                        this.evaluatePenality += defender.Hp * 4;
                    }
                }
                // 血缚小鬼
                if (!attacker.silenced && attacker.handcard.card.nameCN == CardDB.cardNameCN.血缚小鬼)
                {
                    if (attacker.own)
                    {
                        this.minionGetDamageOrHeal(this.ownHero, 2);
                    }
                }
            }
            if (defender.isHero)//target is enemy hero
            {
                doDmgTriggers();
                return;
            }

            #region 随从或武器攻击后触发超杀效果
            if (oldHp < attackerAngr && !defenderHasDivineshild)
            {
                if (!attacker.isHero)
                {
                    attacker.handcard.card.sim_card.OnOverkill(this, attacker);
                }
                else
                {
                    Weapon weapon = attacker.own ? this.ownWeapon : this.enemyWeapon;
                    weapon.card.sim_card.OnOverkill(this, weapon);
                }
            }
            #endregion

            #region 随从或武器攻击后触发荣耀击杀效果
            if (oldHp == attackerAngr && !defenderHasDivineshild)
            {
                if (!attacker.isHero)
                {
                    attacker.handcard.card.sim_card.OnHonorableKill(this, attacker, defender);
                }
                else
                {
                    Weapon weapon = attacker.own ? this.ownWeapon : this.enemyWeapon;
                    weapon.card.sim_card.OnHonorableKill(this, weapon, defender);
                }
            }
            #endregion

            //attacker gets dmg 攻击者受伤害
            bool attackerGotDmg = false;
            if (!dontcount)//betrayal effect :D
            {
                oldHp = attacker.Hp;
                attacker.getDamageOrHeal(defAngr, this, true, false);
                attackerGotDmg = oldHp > attacker.Hp;
                if (attackerGotDmg)
                {
                    switch (defender.handcard.card.nameEN)
                    {
                        case CardDB.cardNameEN.voodoohexxer: goto case CardDB.cardNameEN.waterelemental;
                        case CardDB.cardNameEN.snowchugger: goto case CardDB.cardNameEN.waterelemental;
                        case CardDB.cardNameEN.waterelemental:
                            if (!defender.silenced) minionGetFrozen(attacker);
                            break;
                    }
                    // 处理吸血效果
                    if (defender.lifesteal)
                    {
                        if (defender.own)
                        {
                            this.minionGetDamageOrHeal(this.ownHero, -(oldHp - attacker.Hp));
                        }
                        else
                        {
                            this.minionGetDamageOrHeal(this.enemyHero, -(oldHp - attacker.Hp));
                        }
                    }
                    this.triggerAMinionDealedDmg(defender, attacker.GotDmgValue, false); // defender did dmg
                }
            }


            //trigger poisonous effect of attacker + defender (even if they died due to attacking/defending)

            if (defenderGotDmg && attacker.poisonous && !defender.isHero)
            {
                minionGetDestroyed(defender);
            }

            if (attackerGotDmg && defender.poisonous && !attacker.isHero)
            {
                minionGetDestroyed(attacker);
            }

            switch (attacker.name)
            {
                case CardDB.cardNameEN.parkpanther:
                    if (attacker.own)
                    {
                        this.minionGetTempBuff(this.ownHero, 3, 0);
                    }
                    break;
                case CardDB.cardNameEN.theboogeymonster:
                    if (!defender.isHero && defender.Hp < 1 && attacker.Hp > 0) this.minionGetBuffed(attacker, 2, 2);
                    break;
                case CardDB.cardNameEN.overlordrunthak:
                    foreach (Handmanager.Handcard hc in this.owncards)
                    {
                        if (hc.card.type == CardDB.cardtype.MOB)
                        {
                            hc.addattack++;
                            hc.addHp++;
                            this.anzOwnExtraAngrHp += 2;
                        }
                    }
                    break;
                case CardDB.cardNameEN.windupburglebot:
                    if (!defender.isHero && attacker.Hp > 0) this.drawACard(CardDB.cardNameEN.unknown, attacker.own);
                    break;
                case CardDB.cardNameEN.lotusassassin:
                    if (!defender.isHero && defender.Hp < 1 && attacker.Hp > 0) attacker.stealth = true;
                    break;
                case CardDB.cardNameEN.lotusillusionist:
                    if (defender.isHero) this.minionTransform(attacker, this.getRandomCardForManaMinion(6));
                    break;
                case CardDB.cardNameEN.viciousfledgling:
                    if (defender.isHero) this.getBestAdapt(attacker);
                    break;
                case CardDB.cardNameEN.knuckles:
                    if (!defender.isHero && attacker.Hp > 0) this.minionAttacksMinion(attacker, attacker.own ? this.enemyHero : this.ownHero, true);
                    break;
                case CardDB.cardNameEN.finjatheflyingstar:
                    if (!defender.isHero && defender.Hp < 1)
                    {
                        if (attacker.own)
                        {
                            CardDB.Card c;
                            int count = 7 - this.ownMinions.Count;
                            if (count > 0)
                            {
                                if (count > 2) count = 2;
                                foreach (KeyValuePair<CardDB.cardIDEnum, int> cid in this.prozis.turnDeck)
                                {
                                    c = CardDB.Instance.getCardDataFromID(cid.Key);
                                    if ((TAG_RACE)c.race == TAG_RACE.MURLOC)
                                    {
                                        for (int i = 0; i < cid.Value; i++)
                                        {
                                            this.callKid(c, this.ownMinions.Count, true);
                                            count--;
                                            if (count < 1) break;
                                        }
                                        if (count < 1) break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            this.callKid(CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_168), this.enemyMinions.Count, false);
                            this.callKid(CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_168), this.enemyMinions.Count, false);
                        }
                    }
                    break;
                case CardDB.cardNameEN.giantsandworm:
                    if (!defender.isHero && defender.Hp < 1 && attacker.Hp > 0)
                    {
                        attacker.numAttacksThisTurn = 0;
                        attacker.Ready = true;
                    }
                    break;
                case CardDB.cardNameEN.drakonidslayer: goto case CardDB.cardNameEN.foereaper4000;
                case CardDB.cardNameEN.magnatauralpha: goto case CardDB.cardNameEN.foereaper4000;
                case CardDB.cardNameEN.lakethresher: goto case CardDB.cardNameEN.foereaper4000;
                case CardDB.cardNameEN.darkmoonrabbit: goto case CardDB.cardNameEN.foereaper4000;
                case CardDB.cardNameEN.foereaper4000:
                    if (!attacker.silenced && !dontcount)
                    {
                        List<Minion> temp = (attacker.own) ? this.enemyMinions : this.ownMinions;
                        foreach (Minion mnn in temp)
                        {
                            if (mnn.zonepos + 1 == defender.zonepos || mnn.zonepos - 1 == defender.zonepos)
                            {
                                this.minionAttacksMinion(attacker, mnn, true);
                            }
                        }
                    }
                    break;
            }

            this.doDmgTriggers();
        }

        //a hero attacks a minion 武器英雄攻击
        public void attackWithWeapon(Minion hero, Minion target, int penality)
        {
            bool own = hero.own;
            Weapon weapon = own ? this.ownWeapon : this.enemyWeapon;
            this.attacked = true;
            this.evaluatePenality += penality;
            hero.numAttacksThisTurn++;

            //hero will end his readyness
            hero.updateReadyness();
            if (weapon.name == CardDB.cardNameEN.foolsbane && !hero.frozen) hero.Ready = true;
            if (weapon.card.nameCN == CardDB.cardNameCN.铁刃护手 && target.isHero) this.evaluatePenality += 1000;
            // 简单处理武器吸血效果
            if (weapon.lifesteal)
            {
                this.minionGetDamageOrHeal(hero, -weapon.Angr);
            }
            
            // 处理保护甲板支线任务
            if(this.sideQuest.maxProgress != 1000 && this.sideQuest.Id == CardDB.cardIDEnum.DRG_317)
            {
                this.sideQuest.questProgress++;
                if(this.sideQuest.questProgress >= this.sideQuest.maxProgress)
                {
                    this.drawACard(CardDB.cardIDEnum.CS2_005, true, true);
                    this.drawACard(CardDB.cardIDEnum.CS2_005, true, true);
                    this.drawACard(CardDB.cardIDEnum.CS2_005, true, true);
                    this.sideQuest.Reset();
                }
            }

            //heal whether truesilverchampion equipped
            switch (weapon.name)
            {
                case CardDB.cardNameEN.truesilverchampion:
                    int heal = own ? this.getMinionHeal(2) : this.getEnemyMinionHeal(2);
                    this.minionGetDamageOrHeal(hero, -heal);
                    doDmgTriggers();
                    break;
                case CardDB.cardNameEN.piranhalauncher:
                    int pos = (own) ? this.ownMinions.Count : this.enemyMinions.Count;
                    this.callKid(CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_337t), pos, own);
                    break;
                case CardDB.cardNameEN.vinecleaver:
                    int pos2 = (own) ? this.ownMinions.Count : this.enemyMinions.Count;
                    this.callKid(CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_101t), pos2, own);
                    this.callKid(CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_101t), pos2, own);
                    break;
                case CardDB.cardNameEN.foolsbane:
                    if (!hero.frozen) hero.Ready = true;
                    break;
                case CardDB.cardNameEN.brassknuckles:
                    if (own)
                    {
                        Handmanager.Handcard hc = this.searchRandomMinionInHand(this.owncards, searchmode.searchLowestCost, GAME_TAGs.Mob);
                        if (hc != null)
                        {
                            hc.addattack++;
                            hc.addHp++;
                            this.anzOwnExtraAngrHp += 2;
                        }
                    }
                    else
                    {
                        if (this.enemyAnzCards > 0) this.anzEnemyExtraAngrHp += this.enemyAnzCards * 2 - 1;
                    }
                    break;
            }

            if (logging) Helpfunctions.Instance.logg("attck with weapon trgt: " + target.entitiyID);

            // hero attacks enemy----------------------------------------------------------------------------------

            if (target.isHero)// trigger secret and change target if necessary
            {
                int newTarget = this.secretTrigger_CharIsAttacked(hero, target);
                if (newTarget >= 1)
                {
                    //search new target!
                    foreach (Minion m in this.ownMinions)
                    {
                        if (m.entitiyID == newTarget)
                        {
                            target = m;
                            break;
                        }
                    }
                    foreach (Minion m in this.enemyMinions)
                    {
                        if (m.entitiyID == newTarget)
                        {
                            target = m;
                            break;
                        }
                    }
                    if (this.ownHero.entitiyID == newTarget) target = this.ownHero;
                    if (this.enemyHero.entitiyID == newTarget) target = this.enemyHero;
                }

            }
            this.minionAttacksMinion(hero, target);


            //gorehowl is not killed if he attacks minions
            if (own)
            {
                if (this.ownWeapon.name == CardDB.cardNameEN.gorehowl && !target.isHero)
                {
                    this.ownWeapon.Angr--;
                    hero.Angr--;
                }
                else
                {
                    this.lowerWeaponDurability(1, true);
                }
            }
            else
            {
                if (enemyWeapon.card.nameEN == CardDB.cardNameEN.gorehowl && !target.isHero)
                {
                    this.enemyWeapon.Angr--;
                    hero.Angr--;
                }
                else
                {
                    this.lowerWeaponDurability(1, false);
                }
            }

        }

        //play a minion trigger stuff:
        // 1 whenever you play a card whatever triggers
        // 2 Auras
        // 5 whenever you summon a minion triggers (like starving buzzard) 比如饥饿的秃鹫（出一张野兽，抽一张牌）
        // 3 battlecry  战吼
        // 3.1 place minion
        // 3.2 dmg/died/dthrttl triggers
        // 4 secret: minion is played
        // 4.1 dmg/died/dthrttl triggers
        // 5 after you summon a minion triggers
        // 5.1 dmg/died/dthrttl triggers
        public void playACard(Handmanager.Handcard hc, Minion target, int position, int choice, int penality)
        {
            if (null == hc) hc = new Handmanager.Handcard();
            CardDB.Card c = hc.card;
            this.evaluatePenality += penality;
            if (this.nextSpellThisTurnCostHealth && hc.card.type == CardDB.cardtype.SPELL)//下一张卡牌消耗血量
            {
                this.minionGetDamageOrHeal(this.ownHero, hc.card.getManaCost(this, hc.manacost));
                doDmgTriggers();
                this.nextSpellThisTurnCostHealth = false;
            }
            else if (this.nextMurlocThisTurnCostHealth && (hc.card.race == CardDB.Race.MURLOC || hc.card.race == CardDB.Race.ALL))
            {
                this.minionGetDamageOrHeal(this.ownHero, hc.card.getManaCost(this, hc.manacost));
                doDmgTriggers();
                this.nextMurlocThisTurnCostHealth = false;
            }
            else if (this.ownDemonCostLessOnce > 0 && (hc.card.race == CardDB.Race.DEMON || hc.card.race == CardDB.Race.ALL))
            {
                this.ownDemonCostLessOnce = 0;
            }
            else this.mana = this.mana - hc.getManaCost(this);

            // 删除其他发现选项
            if (hc.discovered)
            {
                foreach(Handmanager.Handcard hcc in this.owncards.ToArray())
                {
                    if(hcc.discovered && hcc.entity != hc.entity)
                        removeCard(hcc);
                }
            }
            if(hc != null)
                removeCard(hc);// remove card from hand

            this.triggerCardsChanged(true);

            //elm.handcard.card.type == CardDB.type.旱地风暴 || elm.handcard.card.nameCN == CardDB.cardNameCN.破霰元素 || elm.handcard.card.nameCN == CardDB.cardNameCN.花岗岩熔铸体 || elm.handcard.card.nameCN == CardDB.cardNameCN.哀嚎蒸汽 || elm.handcard.card.nameCN == CardDB.cardNameCN.火光元素 || elm.handcard.card.nameCN == CardDB.cardNameCN.冰雪亡魂 || elm.handcard.card.nameCN == CardDB.cardNameCN.笼斗管理员)

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



            foreach (Minion elm in this.ownMinions)
            {
                if ((TAG_RACE)elm.handcard.card.race == TAG_RACE.ELEMENTAL)
                {
                    this.anzOwnElementalsThisTurn = 1;                                                      //本回合使用元素
                    this.anzOwnElementalsLastTurn = this.anzOwnElementalsThisTurn;  
                    break;
                }
                //if (hc.card.SpellSchool == CardDB.SpellSchool.NATURE)
                //{


                //    //Handmanager.Handcard hc = CardDB.cardNameCN.自然使徒;
                //    //if (hc != null)
                //    //{
                //    //    hc.addattack++;
                //    //    hc.addHp++;
                //    //    p.anzOwnExtraAngrHp += 2;
                //    //}


                //    //if (elm.handcard.card.nameCN == CardDB.cardNameCN.自然使徒)
                //    //{
                //    if(this.useNature == -1) this.useNature = 1;                                                    //使用过自然
                //    break;
                //    //}
                //}
            }
            if (c.SpellSchool == CardDB.SpellSchool.NATURE)     //使用自然法术时遍历手牌，有自然使徒时
            {
                foreach (Handmanager.Handcard ohc in this.owncards)
                {
                    if (ohc.card.nameCN == CardDB.cardNameCN.自然使徒)
                    {
                        this.useNature = 1;
                        prozis.useNature = 1;
                    }
                    else
                    {
                        this.useNature = 0;
                        prozis.useNature = 0;
                    }
                    break;
                }
            }

            this.anzOwnElementalsThisTurn = 0;
            //Helpfunctions.Instance.logg("play crd anzOwnElementalsLastTurn" + Convert.ToString(this.ownMinions.Count) + " " + Convert.ToString(this.anzOwnElementalsLastTurn));

            if (c.type == CardDB.cardtype.SPELL)
            {
                this.playedPreparation = false;//伺机待发标志位清除
                this.spellsplayedSinceRecalc++;
                //useNature = 1;


                if (this.ownWeapon != null && this.ownWeapon.Durability > 0 && this.ownWeapon.card.nameCN == CardDB.cardNameCN.暗影布缝针 && c.SpellSchool == CardDB.SpellSchool.SHADOW)
                {
                    this.allCharsOfASideGetDamage(false, 1);
                    this.evaluatePenality -= (this.enemyMinions.Count + 1) * 4;
                    this.ownWeapon.Durability--;
                }
                if (target != null)
                {
                    hc.extraParam2 = choice;
                    if (target.own)
                    {
                        switch (target.name)  //法术->目标 产生特殊效果的几个target随从
                        {
                            case CardDB.cardNameEN.dragonkinsorcerer: //龙人巫师
                                this.minionGetBuffed(target, 1, 1);
                                break;
                            case CardDB.cardNameEN.eydisdarkbane:
                                Minion mTarget = this.getEnemyCharTargetForRandomSingleDamage(3);
                                this.minionGetDamageOrHeal(mTarget, 3, true);
                                break;
                            case CardDB.cardNameEN.fjolalightbane://光明邪使菲奥拉
                                target.divineshild = true;
                                break;
                            default:
                                break;
                        }
                    }
                }

                if (c.Secret)
                {
                    this.ownSecretsIDList.Add(c.cardIDenum);
                    this.nextSecretThisTurnCost0 = false;//下一张奥秘本回合0
                    this.secretsplayedSinceRecalc++;
                }
            }

            if (logging) Helpfunctions.Instance.logg("play crd " + c.nameEN + " entitiy# " + hc.entity + " mana " + hc.getManaCost(this) + " trgt " + target);

            hc.target = target;
            this.triggerACardWillBePlayed(hc, true);
            int newTarget = secretTrigger_SpellIsPlayed(target, c);  //奥秘触发
            if (newTarget >= 1)
            {
                //search new target!
                foreach (Minion m in this.ownMinions)
                {
                    if (m.entitiyID == newTarget)
                    {
                        target = m;
                        break;
                    }
                }
                foreach (Minion m in this.enemyMinions)
                {
                    if (m.entitiyID == newTarget)
                    {
                        target = m;
                        break;
                    }
                }
                if (this.ownHero.entitiyID == newTarget) target = this.ownHero;
                if (this.enemyHero.entitiyID == newTarget) target = this.enemyHero;
                if (this.ownQuest.Id != CardDB.cardIDEnum.None && c.type == CardDB.cardtype.SPELL) this.ownQuest.trigger_SpellWasPlayed(target, hc.entity);
                hc.target = target;
            }
            if (newTarget != -2) // trigger spell-secrets!
            {

                if (c.type == CardDB.cardtype.MOB)
                {//随从
                    if (this.ownMinions.Count < 7)
                    {
                        this.placeAmobSomewhere(hc, choice, position);
                        this.mobsplayedThisTurn++;
                    }
                    if (this.stampede > 0 && (TAG_RACE)c.race == TAG_RACE.PET)
                    {
                        for (int i = 1; i <= stampede; i++)
                        {
                            this.drawACard(CardDB.cardNameEN.unknown, true, true);
                        }
                    }
                    if (hc.card.Outcast)
                    {
                        bool outcast = false;
                        if (hc.position == 1 || hc.position == this.owncards.Count + 1)
                        {
                            outcast = true;
                            if (hc.position == this.owncards.Count + 1)
                            {
                                this.evaluatePenality--;
                            }
                        }
                        c.sim_card.onCardPlay(this, true, target, choice, outcast);
                    }
                    if (c.race == CardDB.Race.MURLOC || c.race == CardDB.Race.ALL)
                    {
                        this.nextMurlocThisTurnCostHealth = false;
                    }
                }
                else
                {
                    if (this.lockandload > 0 && c.type == CardDB.cardtype.SPELL)
                    {
                        for (int i = 1; i <= lockandload; i++)
                        {
                            this.drawACard(CardDB.cardNameEN.unknown, true, true);
                        }
                    }
                    if (hc.card.Outcast)
                    {
                        bool outcast = false;
                        if (hc.position == 1 || hc.position == this.owncards.Count + 1)
                        {
                            outcast = true;
                            if (hc.position == this.owncards.Count + 1)
                            {
                                // 优先打出右手边的流放
                                this.evaluatePenality--;
                            }
                        }
                        c.sim_card.onCardPlay(this, true, target, choice, outcast);
                    }
                    if (this.anzSolor && c.type == CardDB.cardtype.SPELL)
                    {
                        if (c.nameCN == CardDB.cardNameCN.日蚀) this.evaluatePenality += 1000;
                        c.sim_card.onCardPlay(this, true, target, choice);
                        this.anzSolor = false;
                    }
                    c.sim_card.onCardPlay(this, true, target, choice);
                    //position从1开始，可以自行测试 流放
                    if (hc.position == 1 || hc.position == this.owncards.Count)
                    {
                        c.sim_card.onOutcast(this, true);
                    }
                    //法术迸发效果的实现
                    if (c.type == CardDB.cardtype.SPELL)
                    {
                        foreach (Minion m in this.ownMinions.ToArray())
                        {
                            if (m.Spellburst && !m.silenced)
                            {
                                m.handcard.card.sim_card.OnSpellburst(this, m, hc);
                                m.Spellburst = false;
                            }
                        }
                        if (this.ownWeapon.Spellburst)
                        {
                            this.ownWeapon.card.sim_card.OnSpellburst(this, this.ownWeapon, hc);
                            this.ownWeapon.Spellburst = false;
                        }
                    }
                    //
                    if (this.ownQuest.Id != CardDB.cardIDEnum.None && c.type == CardDB.cardtype.SPELL) this.ownQuest.trigger_SpellWasPlayed(target, hc.entity);
                    else if (c.type == CardDB.cardtype.WEAPON)
                    {
                        this.ownWeapon.Angr += hc.addattack;
                        this.ownWeapon.Durability += hc.addHp;
                        this.ownHero.Angr += hc.addattack;
                    }
                    this.doDmgTriggers();


                }
            }
            if (newTarget != 0) //if it canBe_counterspell/spellbender  如果有可能是法反或者扰咒术
            {
                if (target != null)
                {
                    if (!target.own && (prozis.penman.attackBuffDatabase.ContainsKey(c.nameEN) || prozis.penman.healthBuffDatabase.ContainsKey(c.nameEN)))
                    {
                        //this.evaluatePenality += 75; 不引入打分
                    }
                    //c.sim_card.onCardPlay(this, this.isOwnTurn, target, choice);  // Todo: 待解决，重点关注，不确定对，fix 火球术打完后，不扣血的问题
                    //这是假设遇到了法反，所以不触发火球术，原来修改不对
                }
            }

            if (hc.target != null)
            {
                if (prozis.penman.healthBuffDatabase.ContainsKey(hc.card.nameEN)) target.justBuffed += prozis.penman.healthBuffDatabase[hc.card.nameEN];
            }



            this.cardsPlayedThisTurn++;

        }

        public void enemyplaysACard(CardDB.Card c, Minion target, int position, int choice, int penality)
        {

            Handmanager.Handcard hc = new Handmanager.Handcard(c);
            hc.entity = this.getNextEntity();
            if (logging) Helpfunctions.Instance.logg("enemy play crd " + c.nameEN + " trgt " + target);

            this.enemyAnzCards--;//might be deleted if he got a real hand

            hc.target = target;
            this.triggerACardWillBePlayed(hc, false);
            this.triggerCardsChanged(false);

            int newTarget = secretTrigger_SpellIsPlayed(target, c);
            if (newTarget >= 1)
            {
                //search new target!
                foreach (Minion m in this.ownMinions)
                {
                    if (m.entitiyID == newTarget)
                    {
                        target = m;
                        break;
                    }
                }
                foreach (Minion m in this.enemyMinions)
                {
                    if (m.entitiyID == newTarget)
                    {
                        target = m;
                        break;
                    }
                }
                if (this.ownHero.entitiyID == newTarget) target = this.ownHero;
                if (this.enemyHero.entitiyID == newTarget) target = this.enemyHero;
            }
            if (newTarget != -2) // trigger spell-secrets!
            {
                if (c.type == CardDB.cardtype.MOB)
                {
                    //todo mob playing
                    //this.placeAmobSomewhere(hc, target, choice, position);

                }
                else
                {
                    c.sim_card.onCardPlay(this, false, target, choice);
                    //lockandload
                    this.doDmgTriggers();



                }
            }
        }

        //使用我的英雄技能
        public void playHeroPower(Minion target, int penality, bool ownturn, int choice)
        {

            CardDB.Card c = (ownturn) ? this.ownHeroAblility.card : this.enemyHeroAblility.card;

            if (ownturn)
            {
                this.anzUsedOwnHeroPower++;//使用我的英雄技能
                // TODO 考达拉幼龙
                if (this.anzUsedOwnHeroPower >= this.ownHeroPowerAllowedQuantity) this.ownAbilityReady = false;//超过使用限制 状态改为没准备好
            }
            else
            {
                this.anzUsedEnemyHeroPower++;
                if (this.anzUsedEnemyHeroPower >= this.enemyHeroPowerAllowedQuantity) this.enemyAbilityReady = false;
            }

            this.evaluatePenality += penality;
            if (this.ownHeroPowerCostLessOnce <= -2 && Ai.Instance.botBase.BehaviorName() == "黑眼任务术")
            {
                this.evaluatePenality -= 20;
            }
            this.mana = this.mana - (this.ownHeroAblility.manacost + this.ownHeroPowerCostLessOnce > 0 ? this.ownHeroAblility.manacost + this.ownHeroPowerCostLessOnce : 0);

            if (logging) Helpfunctions.Instance.logg("play crd " + c.nameEN + " trgt " + target);

            c.sim_card.onCardPlay(this, ownturn, target, choice);
            this.ownHeroPowerCostLessOnce = 0;
            if (target != null && (ownturn ? this.ownAbilityFreezesTarget > 0 : this.enemyAbilityFreezesTarget > 0)) minionGetFrozen(target);
            this.triggerInspire(ownturn);
            this.secretTrigger_HeroPowerUsed();
            this.doDmgTriggers();
        }


        //lower durability of weapon + destroy them (deathrattle) 
        public void lowerWeaponDurability(int value, bool own)
        {
            if (own)
            {
                if (this.ownWeapon.Durability <= 0 || this.ownWeapon.immune) return;
                this.ownWeapon.Durability -= value;
                if (this.ownWeapon.Durability <= 0)
                {
                    if (this.ownWeapon.card.deathrattle)
                    {
                        Minion m = new Minion { own = true };
                        ownWeapon.card.sim_card.onDeathrattle(this, m);
                    }

                    this.ownHero.Angr = Math.Max(0, this.ownHero.Angr - this.ownWeapon.Angr);
                    this.ownWeapon = new Weapon();
                    this.ownHero.windfury = false;

                    foreach (Minion m in this.ownMinions)
                    {
                        switch (m.name)
                        {
                            case CardDB.cardNameEN.southseadeckhand:
                                if (m.playedThisTurn)
                                {
                                    m.charge--;
                                    m.updateReadyness();
                                }
                                break;
                            case CardDB.cardNameEN.smalltimebuccaneer:
                                this.minionGetBuffed(m, -2, 0);
                                break;
                            case CardDB.cardNameEN.graveshambler:
                                if (!m.silenced) minionGetBuffed(m, 1, 1);
                                break;
                        }
                    }
                    this.ownHero.updateReadyness();
                }
            }
            else
            {
                if (this.enemyWeapon.Durability <= 0 || this.enemyWeapon.immune) return;
                this.enemyWeapon.Durability -= value;
                if (this.enemyWeapon.Durability <= 0)
                {
                    if (this.enemyWeapon.card.deathrattle)
                    {
                        Minion m = new Minion { own = false };
                        enemyWeapon.card.sim_card.onDeathrattle(this, m);
                    }

                    this.enemyHero.Angr = Math.Max(0, this.enemyHero.Angr - this.enemyWeapon.Angr);
                    this.enemyWeapon = new Weapon();
                    this.enemyHero.windfury = false;

                    foreach (Minion m in this.enemyMinions)
                    {
                        switch (m.name)
                        {
                            case CardDB.cardNameEN.smalltimebuccaneer:
                                this.minionGetBuffed(m, -2, 0);
                                break;
                            case CardDB.cardNameEN.graveshambler:
                                if (!m.silenced) minionGetBuffed(m, 1, 1);
                                break;
                        }
                    }

                    this.enemyHero.updateReadyness();
                }
            }
        }



        public void doDmgTriggers()
        {
            //we do the these trigger manualy (to less minions) (we could trigger them with m.handcard.card.sim_card.ontrigger...)
            if (this.tempTrigger.charsGotHealed >= 1)
            {
                triggerACharGotHealed();//possible effects: gain attack
            }

            if (this.tempTrigger.minionsGotHealed >= 1)
            {
                triggerAMinionGotHealed();//possible effects: draw card
            }


            if (this.tempTrigger.ownMinionsGotDmg + this.tempTrigger.enemyMinionsGotDmg >= 1)
            {
                triggerAMinionGotDmg(); //possible effects: draw card, gain armor, gain attack
            }

            if (this.tempTrigger.ownMinionsDied + this.tempTrigger.enemyMinionsDied >= 1)
            {
                triggerAMinionDied(); //possible effects: draw card, gain attack + hp, callKid.
                if (this.tempTrigger.ownMinionsDied >= 1) this.tempTrigger.ownMinionsChanged = true;
                if (this.tempTrigger.enemyMinionsDied >= 1) this.tempTrigger.enemyMininsChanged = true;
                this.tempTrigger.ownMinionsDied = 0;
                this.tempTrigger.enemyMinionsDied = 0;
                this.tempTrigger.ownBeastDied = 0;
                this.tempTrigger.enemyBeastDied = 0;
                this.tempTrigger.ownMurlocDied = 0;
                this.tempTrigger.enemyMurlocDied = 0;
                this.tempTrigger.ownMechanicDied = 0;
                this.tempTrigger.enemyMechanicDied = 0;
            }

            if (this.tempTrigger.ownMinionLosesDivineShield + this.tempTrigger.enemyMinionLosesDivineShield >= 1)
            {
                triggerAMinionLosesDivineShield(); //possible effects: draw card, gain armor, gain attack
            }

            updateBoards();
            if (this.tempTrigger.charsGotHealed + this.tempTrigger.minionsGotHealed + this.tempTrigger.ownMinionsGotDmg + this.tempTrigger.enemyMinionsGotDmg + this.tempTrigger.ownMinionsDied + this.tempTrigger.enemyMinionsDied >= 1)
            {
                doDmgTriggers();
            }
        }

        public void triggerACharGotHealed()
        {
            int anz = this.tempTrigger.charsGotHealed;
            this.tempTrigger.charsGotHealed = 0;

            foreach (Minion mnn in this.ownMinions)
            {
                if (mnn.silenced) continue;
                switch (mnn.handcard.card.nameEN)
                {
                    case CardDB.cardNameEN.lightwarden: goto case CardDB.cardNameEN.aiextra1;
                    case CardDB.cardNameEN.holychampion: goto case CardDB.cardNameEN.aiextra1;
                    case CardDB.cardNameEN.shadowboxer: goto case CardDB.cardNameEN.aiextra1;
                    case CardDB.cardNameEN.hoodedacolyte: goto case CardDB.cardNameEN.aiextra1;
                    case CardDB.cardNameEN.aiextra1:
                        mnn.handcard.card.sim_card.onACharGotHealed(this, mnn, anz);
                        break;
                    case CardDB.cardNameEN.blackguard:
                        if (ownHero.GotHealedValue > 0) mnn.handcard.card.sim_card.onACharGotHealed(this, mnn, ownHero.GotHealedValue);
                        break;
                }
            }
            foreach (Minion mnn in this.enemyMinions)
            {
                if (mnn.silenced) continue;
                switch (mnn.handcard.card.nameEN)
                {
                    case CardDB.cardNameEN.lightwarden: goto case CardDB.cardNameEN.aiextra1;
                    case CardDB.cardNameEN.holychampion: goto case CardDB.cardNameEN.aiextra1;
                    case CardDB.cardNameEN.shadowboxer: goto case CardDB.cardNameEN.aiextra1;
                    case CardDB.cardNameEN.hoodedacolyte: goto case CardDB.cardNameEN.aiextra1;
                    case CardDB.cardNameEN.aiextra1:
                        mnn.handcard.card.sim_card.onACharGotHealed(this, mnn, anz);
                        break;
                    case CardDB.cardNameEN.blackguard:
                        if (enemyHero.GotHealedValue > 0) mnn.handcard.card.sim_card.onACharGotHealed(this, mnn, enemyHero.GotHealedValue);
                        break;
                }
            }
        }

        public void triggerAMinionGotHealed()
        {
            //also dead minions trigger this
            int anz = this.tempTrigger.minionsGotHealed;
            this.tempTrigger.minionsGotHealed = 0;

            foreach (Minion mnn in this.ownMinions.ToArray())
            {
                if (mnn.silenced) continue;
                switch (mnn.handcard.card.nameEN)
                {
                    case CardDB.cardNameEN.northshirecleric: goto case CardDB.cardNameEN.aiextra1;
                    case CardDB.cardNameEN.manageode: goto case CardDB.cardNameEN.aiextra1;
                    case CardDB.cardNameEN.aiextra1:
                        mnn.handcard.card.sim_card.onAMinionGotHealedTrigger(this, mnn, anz);
                        break;
                }
            }

            foreach (Minion mnn in this.enemyMinions.ToArray())
            {
                if (mnn.silenced) continue;
                switch (mnn.handcard.card.nameEN)
                {
                    case CardDB.cardNameEN.northshirecleric: goto case CardDB.cardNameEN.aiextra1;
                    case CardDB.cardNameEN.manageode: goto case CardDB.cardNameEN.aiextra1;
                    case CardDB.cardNameEN.aiextra1:
                        mnn.handcard.card.sim_card.onAMinionGotHealedTrigger(this, mnn, anz);
                        break;
                }
            }
        }

        public void triggerAMinionGotDmg()
        {
            int anzOwnMinionsGotDmg = this.tempTrigger.ownMinionsGotDmg;
            int anzEnemyMinionsGotDmg = this.tempTrigger.enemyMinionsGotDmg;
            this.tempTrigger.ownMinionsGotDmg = 0;
            this.tempTrigger.enemyMinionsGotDmg = 0;

            int anzOwnHeroGotDmg = this.tempTrigger.ownHeroGotDmg;
            int anzEnemyHeroGotDmg = this.tempTrigger.enemyHeroGotDmg;
            this.tempTrigger.ownHeroGotDmg = 0;
            this.tempTrigger.enemyHeroGotDmg = 0;

            foreach (Minion m in this.ownMinions.ToArray())
            {
                if (m.silenced) { m.anzGotDmg = 0; continue; }
                m.handcard.card.sim_card.onMinionGotDmgTrigger(this, m, anzOwnMinionsGotDmg, anzEnemyMinionsGotDmg, anzOwnHeroGotDmg, anzEnemyHeroGotDmg);
                m.anzGotDmg = 0;
                m.GotDmgValue = 0;
            }

            foreach (Minion m in this.enemyMinions.ToArray())
            {
                if (m.silenced) { m.anzGotDmg = 0; continue; }
                m.handcard.card.sim_card.onMinionGotDmgTrigger(this, m, anzOwnMinionsGotDmg, anzEnemyMinionsGotDmg, anzOwnHeroGotDmg, anzEnemyHeroGotDmg);
                m.anzGotDmg = 0;
                m.GotDmgValue = 0;
            }
            this.ownHero.anzGotDmg = 0;
            this.enemyHero.anzGotDmg = 0;
        }

        public void triggerAMinionLosesDivineShield()
        {
            int anzOwn = this.tempTrigger.ownMinionLosesDivineShield;
            int anzEnemy = this.tempTrigger.enemyMinionLosesDivineShield;
            this.tempTrigger.ownMinionLosesDivineShield = 0;
            this.tempTrigger.enemyMinionLosesDivineShield = 0;

            if (anzOwn > 0)
            {
                foreach (Minion m in this.ownMinions.ToArray())
                {
                    if (m.silenced) continue;
                    m.handcard.card.sim_card.onMinionLosesDivineShield(this, m, anzOwn);
                }

                if (this.ownWeapon.name == CardDB.cardNameEN.lightssorrow) this.ownWeapon.Angr += anzOwn;
                if (this.ownWeapon.name == CardDB.cardNameEN.prismaticjewelkit) this.ownWeapon.card.sim_card.onMinionLosesDivineShield(this, new Minion(), anzOwn);
            }

            if (anzEnemy > 0)
            {
                foreach (Minion m in this.enemyMinions.ToArray())
                {
                    if (m.silenced) continue;
                    m.handcard.card.sim_card.onMinionLosesDivineShield(this, m, anzEnemy);
                }

                if (this.enemyWeapon.name == CardDB.cardNameEN.lightssorrow) this.enemyWeapon.Angr += anzEnemy;
            }
        }

        public void triggerAMinionDied()
        {
            this.ownMinionsDiedTurn += this.tempTrigger.ownMinionsDied;
            this.enemyMinionsDiedTurn += this.tempTrigger.enemyMinionsDied;

            foreach (Minion m in this.ownMinions.ToArray())
            {
                if (m.silenced) continue;
                if (m.Hp <= 0) continue;
                m.handcard.card.sim_card.onMinionDiedTrigger(this, m, m);
            }
            foreach (Minion m in this.enemyMinions.ToArray())
            {
                if (m.silenced) continue;
                if (m.Hp <= 0) continue;
                m.handcard.card.sim_card.onMinionDiedTrigger(this, m, m);
            }

            foreach (Handmanager.Handcard hc in this.owncards)
            {
                if (hc.card.nameEN == CardDB.cardNameEN.bolvarfordragon) hc.addattack += this.tempTrigger.ownMinionsDied;
            }


            if (this.ownWeapon.name == CardDB.cardNameEN.jaws)
            {
                int bonus = 0;
                foreach (Minion m in this.ownMinions) if (m.Hp < 1 && m.handcard.card.deathrattle && !m.silenced) bonus++;
                foreach (Minion m in this.enemyMinions) if (m.Hp < 1 && m.handcard.card.deathrattle && !m.silenced) bonus++;
                this.ownWeapon.Angr += bonus * 2;
            }
            if (this.enemyWeapon.name == CardDB.cardNameEN.jaws)
            {
                int bonus = 0;
                foreach (Minion m in this.ownMinions) if (m.Hp < 1 && m.handcard.card.deathrattle && !m.silenced) bonus++;
                foreach (Minion m in this.enemyMinions) if (m.Hp < 1 && m.handcard.card.deathrattle && !m.silenced) bonus++;
                this.enemyWeapon.Angr += bonus * 2;
            }


            if (this.ownHeroAblility.card.nameEN == CardDB.cardNameEN.raisedead)
            {
                if (this.tempTrigger.enemyMinionsDied > 0)
                {
                    CardDB.Card kid = CardDB.Instance.getCardDataFromID((this.ownHeroAblility.card.cardIDenum == CardDB.cardIDEnum.NAX4_04H) ? CardDB.cardIDEnum.NAX4_03H : CardDB.cardIDEnum.NAX4_03);
                    for (int i = 0; i < this.tempTrigger.enemyMinionsDied; i++)
                    {
                        this.callKid(kid, this.ownMinions.Count, true);
                    }
                }
            }
            if (this.enemyHeroAblility.card.nameEN == CardDB.cardNameEN.raisedead)
            {
                if (this.tempTrigger.ownMinionsDied > 0)
                {
                    CardDB.Card kid = CardDB.Instance.getCardDataFromID((this.enemyHeroAblility.card.cardIDenum == CardDB.cardIDEnum.NAX4_04H) ? CardDB.cardIDEnum.NAX4_03H : CardDB.cardIDEnum.NAX4_03);
                    for (int i = 0; i < this.tempTrigger.ownMinionsDied; i++)
                    {
                        this.callKid(kid, this.enemyMinions.Count, false);
                    }
                }
            }
        }

        // 随从攻击前触发效果
        public void triggerAMinionIsGoingToAttack(Minion attacker, Minion target)
        {
            switch (attacker.name)
            {
                case CardDB.cardNameEN.cutpurse:
                    if (target.isHero) this.drawACard(CardDB.cardNameEN.thecoin, attacker.own, true);
                    break;
                case CardDB.cardNameEN.wretchedtiller:
                    if (target.isHero) minionGetDamageOrHeal(attacker.own ? this.enemyHero : this.ownHero, 2);
                    break;
                case CardDB.cardNameEN.shakuthecollector:
                    this.drawACard(CardDB.cardNameEN.unknown, attacker.own, true);
                    break;
                case CardDB.cardNameEN.genzotheshark:
                    while (this.owncards.Count < 3 && this.ownDeckSize > 0)
                    {
                        this.drawACard(CardDB.cardNameEN.unknown, true, true);
                    }
                    while (this.enemyAnzCards < 3 && this.enemyDeckSize > 0)
                    {
                        this.drawACard(CardDB.cardNameEN.unknown, false, true);
                    }
                    break;
                // 罗姆减费神圣法术
                case CardDB.cardNameEN.carielroame:
                    foreach (Handmanager.Handcard hc in this.owncards)
                    {
                        if (hc.card.SpellSchool == CardDB.SpellSchool.HOLY)
                        {
                            hc.manacost--;
                            //this.evaluatePenality -= 5; Todo:不引入打分
                        }
                    }
                    break;
            }

            if (attacker.ownBlessingOfWisdom >= 1)
            {
                for (int i = 0; i < attacker.ownBlessingOfWisdom; i++)
                {
                    this.drawACard(CardDB.cardNameEN.unknown, true);
                }
            }
            if (attacker.enemyBlessingOfWisdom >= 1)
            {
                for (int i = 0; i < attacker.enemyBlessingOfWisdom; i++)
                {
                    this.drawACard(CardDB.cardNameEN.unknown, false);
                }
            }

            if (attacker.ownPowerWordGlory >= 1)
            {
                int heal = this.getMinionHeal(4);
                for (int i = 0; i < attacker.ownPowerWordGlory; i++)
                {
                    this.minionGetDamageOrHeal(this.ownHero, -heal);
                }
            }
            if (attacker.enemyPowerWordGlory >= 1)
            {
                int heal = this.getEnemyMinionHeal(4);
                for (int i = 0; i < attacker.enemyPowerWordGlory; i++)
                {
                    this.minionGetDamageOrHeal(this.enemyHero, -heal);
                }
            }
        }

        public void triggerAMinionDealedDmg(Minion m, int dmgDone, bool isAttacker)
        {
            //3 cards only has such trigger
            switch (m.name)
            {
                case CardDB.cardNameEN.alleyarmorsmith:
                    if (!m.silenced) this.minionGetArmor(m.own ? this.ownHero : this.enemyHero, m.Angr);
                    break;
            }
            if (m.lifesteal && isAttacker && dmgDone > 0)
            {
                if (m.own)
                {
                    if (this.anzOwnAuchenaiSoulpriest > 0 || this.embracetheshadow > 0) dmgDone *= -1;
                    this.minionGetDamageOrHeal(this.ownHero, -dmgDone);
                }
                else
                {
                    if (this.anzEnemyAuchenaiSoulpriest > 1) dmgDone *= -1;
                    this.minionGetDamageOrHeal(this.enemyHero, -dmgDone);
                }
            }
        }

        // 出牌事件
        public void triggerACardWillBePlayed(Handmanager.Handcard hc, bool own)
        {
            if (own)
            {

                if (anzOwnDragonConsort > 0 && (TAG_RACE)hc.card.race == TAG_RACE.DRAGON) anzOwnDragonConsort = 0;
                //雷矛军用山羊
                if (ownBeastCostLessOnce > 0 && (TAG_RACE)hc.card.race == TAG_RACE.PET) ownBeastCostLessOnce = 0;
                //火光元素
                if (ownElementCost > 0 && (TAG_RACE)hc.card.race == TAG_RACE.ELEMENTAL) ownElementCost = 0;
                int burly = 0;
                int ssm = 0;
                foreach (Minion m in this.ownMinions.ToArray())
                {
                    if (m.silenced) continue;
                    m.handcard.card.sim_card.onCardIsGoingToBePlayed(this, hc, own, m);
                }

                foreach (Minion m in this.enemyMinions)
                {
                    if (m.name == CardDB.cardNameEN.troggzortheearthinator)
                    {
                        burly++;
                    }
                    if (m.name == CardDB.cardNameEN.felreaver)
                    {
                        m.handcard.card.sim_card.onCardIsGoingToBePlayed(this, hc, own, m);
                    }
                    // 似乎会引起不出牌 bug
                    switch (m.handcard.card.nameCN)
                    {
                        case CardDB.cardNameCN.食人魔巫术师:
                            if (hc.card.type == CardDB.cardtype.SPELL)
                            {
                                ssm++;
                            }
                            break;
                    }
                }
                List<Handmanager.Handcard> afterCorrput = new List<Handmanager.Handcard>();

                // 遍历手牌中的腐蚀卡
                foreach (Handmanager.Handcard ohc in this.owncards)
                {
                    switch (ohc.card.nameEN)
                    {
                        case CardDB.cardNameEN.shadowreflection:
                            ohc.card.sim_card.onCardIsGoingToBePlayed(this, hc, own, ohc);
                            break;
                        case CardDB.cardNameEN.blubberbaron:
                            ohc.card.sim_card.onCardIsGoingToBePlayed(this, hc, own, ohc);
                            break;
                    }
                    // 找到腐蚀卡
                    if (ohc.card.Corrupt && hc.manacost > ohc.manacost)
                    {
                        // 最好输出一下 ohc.card.cardIDenum.ToString() + "t" 看看有没有出错
                        // Helpfunctions.Instance.ErrorLog(ohc.card.cardIDenum.ToString() + "t");

                        // 找到对应的腐蚀后的卡牌
                        // ohc.card=CardDB.Instance.getCardDataFromID((CardDB.cardIDEnum)ohc.card.Corrupted);
                        ohc.card = CardDB.Instance.getCardDataFromID(CardDB.Instance.cardIdstringToEnum(ohc.card.cardIDenum.ToString() + "t"));

                        //Helpfunctions.Instance.ErrorLog("如果打出" + hc.card.chnName + "就可腐化" + ohc.card.chnName);
                        if (ohc.card.nameCN == CardDB.cardNameCN.大力士)
                        {
                            ohc.manacost = 0;
                        }

                        afterCorrput.Add(ohc);

                        this.evaluatePenality -= 5;
                    }
                }
                foreach (Handmanager.Handcard ohc in afterCorrput)
                {
                    this.removeCard(ohc);
                    this.drawACard(ohc.card.cardIDenum, true, true);
                    foreach (Handmanager.Handcard ahc in this.owncards)
                    {
                        if (ahc.card.cardIDenum == ohc.card.cardIDenum)
                        {
                            ahc.manacost = ohc.manacost;
                        }
                    }
                }

                if (this.ownHeroAblility.card.nameEN == CardDB.cardNameEN.voidform) this.ownHeroAblility.card.sim_card.onCardIsGoingToBePlayed(this, hc, own, this.ownHeroAblility);

                if (this.ownWeapon.name == CardDB.cardNameEN.atiesh)
                {
                    this.callKid(this.getRandomCardForManaMinion(hc.manacost), this.ownMinions.Count, own);
                    this.lowerWeaponDurability(1, own);
                }

                for (int i = 0; i < burly; i++)//summon for enemy !
                {
                    int pos = this.enemyMinions.Count;
                    this.callKid(CardDB.Instance.burlyrockjaw, pos, !own);
                }

                for (int i = 0; i < ssm; i++)//summon for enemy !
                {
                    int pos = this.enemyMinions.Count;
                    this.callKid(CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.SCH_710t), pos, !own);
                    foreach (Minion m in this.enemyMinions)
                    {
                        if (m.handcard.card.cardIDenum == CardDB.cardIDEnum.SCH_710t)
                        {
                            m.taunt = true;
                            if (m.own) this.anzOwnTaunt++;
                            else this.anzEnemyTaunt++;
                        }
                    }
                }
            }
            else
            {
                int burly = 0;
                foreach (Minion m in this.enemyMinions.ToArray())
                {
                    if (m.silenced) continue;
                    m.handcard.card.sim_card.onCardIsGoingToBePlayed(this, hc, own, m);
                }
                foreach (Minion m in this.ownMinions)
                {
                    if (m.name == CardDB.cardNameEN.troggzortheearthinator)
                    {
                        burly++;
                    }
                    if (m.name == CardDB.cardNameEN.felreaver)
                    {
                        m.handcard.card.sim_card.onCardIsGoingToBePlayed(this, hc, own, m);
                    }
                }

                if (this.enemyHeroAblility.card.nameEN == CardDB.cardNameEN.voidform) this.enemyHeroAblility.card.sim_card.onCardIsGoingToBePlayed(this, hc, own, this.enemyHeroAblility);

                if (this.enemyWeapon.name == CardDB.cardNameEN.atiesh)
                {
                    this.callKid(this.getRandomCardForManaMinion(hc.manacost), this.enemyMinions.Count, own);
                    this.lowerWeaponDurability(1, own);
                }

                for (int i = 0; i < burly; i++)//summon for us
                {
                    int pos = this.ownMinions.Count;
                    this.callKid(CardDB.Instance.burlyrockjaw, pos, own);
                }
            }

        }

        // public void triggerACardWasPlayed(CardDB.Card c, bool own) {        }

        public void triggerAMinionIsSummoned(Minion m)
        {
            if (m.own)
            {
                foreach (Minion mnn in this.ownMinions.ToArray())
                {
                    if (mnn.silenced) continue;
                    mnn.handcard.card.sim_card.onMinionIsSummoned(this, mnn, m);
                }
            }
            else
            {
                foreach (Minion mnn in this.enemyMinions.ToArray())
                {
                    if (mnn.silenced) continue;
                    mnn.handcard.card.sim_card.onMinionIsSummoned(this, mnn, m);
                }
            }
        }

        public void triggerAMinionWasSummoned(Minion mnn)
        {
            if (mnn.own)
            {
                if (this.ownQuest.Id != CardDB.cardIDEnum.None) this.ownQuest.trigger_MinionWasSummoned(mnn);
                if (mnn.taunt) anzOwnTaunt++;
                if (this.LothraxionsPower && mnn.name == CardDB.cardNameEN.silverhandrecruit) mnn.divineshild = true;
                foreach (Minion m in this.ownMinions.ToArray())
                {
                    if (m.silenced || m.entitiyID == mnn.entitiyID) continue;
                    m.handcard.card.sim_card.onMinionWasSummoned(this, m, mnn);
                }
                switch (this.ownWeapon.name)
                {
                    case CardDB.cardNameEN.swordofjustice:
                        this.minionGetBuffed(mnn, 1, 1);
                        this.lowerWeaponDurability(1, true);
                        break;
                }
            }
            else
            {
                if (this.enemyQuest.Id != CardDB.cardIDEnum.None) this.enemyQuest.trigger_MinionWasSummoned(mnn);
                if (mnn.taunt) anzEnemyTaunt++;
                foreach (Minion m in this.enemyMinions.ToArray())
                {
                    if (m.silenced || m.entitiyID == mnn.entitiyID) continue;
                    m.handcard.card.sim_card.onMinionWasSummoned(this, m, mnn);
                }
                switch (this.enemyWeapon.name)
                {
                    case CardDB.cardNameEN.swordofjustice:
                        this.minionGetBuffed(mnn, 1, 1);
                        this.lowerWeaponDurability(1, false);
                        break;
                }
            }

        }

        public void triggerEndTurn(bool ownturn)
        {
            foreach (Minion m in this.ownMinions.ToArray())
            {
                m.cantAttackHeroes = false;
                if (!m.silenced)
                {
                    m.handcard.card.sim_card.onTurnEndsTrigger(this, m, ownturn);
                    if (this.ownTurnEndEffectsTriggerTwice > 0 && ownturn)
                    {
                        for (int i = 0; i < ownTurnEndEffectsTriggerTwice; i++)
                        {
                            m.handcard.card.sim_card.onTurnEndsTrigger(this, m, ownturn);
                        }
                    }
                }
                if (ownturn && m.destroyOnOwnTurnEnd) this.minionGetDestroyed(m);
            }
            foreach (Minion m in this.enemyMinions.ToArray())
            {
                if (!m.silenced)
                {
                    m.handcard.card.sim_card.onTurnEndsTrigger(this, m, ownturn);
                    if (this.enemyTurnEndEffectsTriggerTwice > 0 && !ownturn)
                    {
                        for (int i = 0; i < enemyTurnEndEffectsTriggerTwice; i++)
                        {
                            m.handcard.card.sim_card.onTurnEndsTrigger(this, m, ownturn);
                        }
                    }
                }
                if (!ownturn && m.destroyOnEnemyTurnEnd) this.minionGetDestroyed(m);
            }



            this.doDmgTriggers();

            //shadowmadness
            if (this.shadowmadnessed >= 1)
            {
                List<Minion> ownm = (ownturn) ? this.ownMinions : this.enemyMinions;
                foreach (Minion m in ownm.ToArray())
                {
                    if (m.shadowmadnessed)
                    {
                        m.shadowmadnessed = false;
                        this.minionGetControlled(m, !m.own, false);
                    }
                }
                this.shadowmadnessed = 0;
                updateBoards();
            }

            this.nextSecretThisTurnCost0 = false;
            this.nextSpellThisTurnCost0 = false;
            this.nextMurlocThisTurnCostHealth = false;
            this.nextSpellThisTurnCostHealth = false;
            this.lockandload = 0;
            this.stampede = 0;
            this.embracetheshadow = 0;
            this.playedPreparation = false;//回合结束触发

            foreach (Minion m in this.ownMinions)
            {
                this.minionGetTempBuff(m, -m.tempAttack, 0);
                m.immune = false;
                m.cantLowerHPbelowONE = false;
            }
            foreach (Minion m in this.enemyMinions)
            {
                this.minionGetTempBuff(m, -m.tempAttack, 0);
                m.immune = false;
                m.cantLowerHPbelowONE = false;
            }
            if (this.anzOwnMalGanis < 1) this.ownHero.immune = false;
            if (this.anzEnemyMalGanis < 1) this.enemyHero.immune = false;
            this.ownWeapon.immune = false;
            this.enemyWeapon.immune = false;
        }


        public void triggerStartTurn(bool ownturn)
        {//回合开始触发
            if (this.diedMinions != null)
            {
                this.ownMinionsDiedTurn = 0;
                this.enemyMinionsDiedTurn = 0;
                if (!this.print) this.diedMinions.Clear(); //contains only the minions that died in this turn!
            }

            List<Minion> ownm = (ownturn) ? this.ownMinions : this.enemyMinions;
            foreach (Minion m in ownm.ToArray())
            {
                m.playedPrevTurn = m.playedThisTurn;
                m.playedThisTurn = false;
                m.numAttacksThisTurn = 0;
                m.justBuffed = 0;
                m.updateReadyness();
                if (m.dormant > 0 && ownturn == m.own) //休眠
                {//苏醒
                    m.dormant--;
                    if (m.dormant == 0)
                    {
                        m.handcard.card.sim_card.onDormantEndsTrigger(this, m);
                    }
                }
                if (m.conceal)
                {
                    m.conceal = false;
                    m.stealth = false;
                }

                if (!m.silenced)
                {
                    m.handcard.card.sim_card.onTurnStartTrigger(this, m, ownturn);
                }
                if (ownturn && m.destroyOnOwnTurnStart) this.minionGetDestroyed(m);
                if (!ownturn && m.destroyOnEnemyTurnStart) this.minionGetDestroyed(m);
            }

            List<Minion> enemm = (ownturn) ? this.enemyMinions : this.ownMinions;
            foreach (Minion m in enemm.ToArray())
            {
                m.frozen = false;
                m.justBuffed = 0;
                if (!m.silenced)
                {
                    if (m.name == CardDB.cardNameEN.micromachine) m.handcard.card.sim_card.onTurnStartTrigger(this, m, ownturn);
                }
                if (ownturn && m.destroyOnOwnTurnStart) this.minionGetDestroyed(m);
                if (!ownturn && m.destroyOnEnemyTurnStart) this.minionGetDestroyed(m);
                if (m.changeOwnerOnTurnStart) this.minionGetControlled(m, ownturn, true);
            }

            Minion hero;
            Handmanager.Handcard ab;
            if (ownturn)
            {
                hero = this.ownHero;
                ab = this.ownHeroAblility;
            }
            else
            {
                hero = this.enemyHero;
                ab = this.enemyHeroAblility;
            }
            if (hero.conceal)
            {
                hero.conceal = false;
                hero.stealth = false;
            }
            if (ab.card.nameEN == CardDB.cardNameEN.deathsshadow) ab.card.sim_card.onTurnStartTrigger(this, null, ownturn);

            this.doDmgTriggers();
            this.drawACard(CardDB.cardNameEN.unknown, ownturn);
            this.doDmgTriggers();


            this.cardsPlayedThisTurn = 0;
            this.mobsplayedThisTurn = 0;
            this.nextSecretThisTurnCost0 = false;
            this.nextSpellThisTurnCost0 = false;
            this.nextMurlocThisTurnCostHealth = false;
            this.nextSpellThisTurnCostHealth = false;
            this.optionsPlayedThisTurn = 0;
            this.enemyOptionsDoneThisTurn = 0;
            this.anzUsedOwnHeroPower = 0;
            this.anzUsedEnemyHeroPower = 0;

            if (ownturn)
            {
                this.ownMaxMana = Math.Min(10, this.ownMaxMana + 1);
                this.mana = this.ownMaxMana - this.ueberladung;
                this.lockedMana = this.ueberladung;
                this.ueberladung = 0;

                this.enemyHero.frozen = false;
                this.ownHero.Angr = this.ownWeapon.Angr;
                this.ownHero.numAttacksThisTurn = 0;
                this.ownAbilityReady = true;
                this.ownHero.updateReadyness();
                this.owncarddraw = 0;
            }
            else
            {
                this.enemyMaxMana = Math.Min(10, this.enemyMaxMana + 1);
                this.mana = this.enemyMaxMana;
                this.ownHero.frozen = false;
                this.enemyHero.Angr = this.enemyWeapon.Angr;
                this.enemyHero.numAttacksThisTurn = 0;
                this.enemyAbilityReady = true;
                this.enemyHero.updateReadyness();
            }


            this.complete = false;
            this.value = int.MinValue;
        }

        public void triggerAHeroGotArmor(bool ownHero)
        {
            foreach (Minion m in ((ownHero) ? this.ownMinions : this.enemyMinions))
            {
                if (m.name == CardDB.cardNameEN.siegeengine && !m.silenced)
                {
                    this.minionGetBuffed(m, 1, 0);
                }
            }            
        }

        public void triggerCardsChanged(bool own)
        {
            if (own)
            {
                if (this.tempanzOwnCards >= 6 && this.owncards.Count <= 5)
                {

                    foreach (Minion m in this.enemyMinions)
                    {
                        if (m.name == CardDB.cardNameEN.goblinsapper && !m.silenced)
                        {
                            this.minionGetBuffed(m, -4, 0);
                        }
                    }
                }
                if (this.owncards.Count >= 6 && this.tempanzOwnCards <= 5)
                {

                    foreach (Minion m in this.enemyMinions)
                    {
                        if (m.name == CardDB.cardNameEN.goblinsapper && !m.silenced)
                        {
                            this.minionGetBuffed(m, 4, 0);
                        }
                    }
                }

                this.tempanzOwnCards = this.owncards.Count;

                if(this.ownWeapon.card.nameCN == CardDB.cardNameCN.符文秘银杖 && this.ownWeapon.scriptNum1 >= 4)
                {
                    foreach(Handmanager.Handcard hc in this.owncards)
                    {
                        hc.manacost--;
                        this.evaluatePenality -= 3;
                    }
                    this.ownWeapon.scriptNum1 = 0;
                }
            }
            else
            {
                if (this.tempanzEnemyCards >= 6 && this.enemyAnzCards <= 5)
                {

                    foreach (Minion m in this.ownMinions)
                    {
                        if (m.name == CardDB.cardNameEN.goblinsapper && !m.silenced)
                        {
                            this.minionGetBuffed(m, -4, 0);
                        }
                    }
                }
                if (this.enemyAnzCards >= 6 && this.tempanzEnemyCards <= 5)
                {

                    foreach (Minion m in this.ownMinions)
                    {
                        if (m.name == CardDB.cardNameEN.goblinsapper && !m.silenced)
                        {
                            this.minionGetBuffed(m, 4, 0);
                        }
                    }
                }

                this.tempanzEnemyCards = this.enemyAnzCards;
            }
        }



        public void triggerInspire(bool ownturn)
        {
            foreach (Minion m in this.ownMinions.ToArray())
            {
                if (m.silenced) continue;
                m.handcard.card.sim_card.onInspire(this, m, ownturn);
            }

            foreach (Minion m in this.enemyMinions.ToArray())
            {
                if (m.silenced) continue;
                m.handcard.card.sim_card.onInspire(this, m, ownturn);
            }
        }

        private SecretItem getMergedSeretItem(List<SecretItem> esl)
        {
            if (esl.Count == 0)
                return null;
            if (esl.Count == 1)
                return esl[0];
            BitArray ret = new BitArray(60, false);
            foreach (SecretItem si in esl)
            {
                ret.Or(SecretItem.secretItemToData(si));
            }
            return SecretItem.dataToSecretItem(ret);
        }
        public int secretTrigger_CharIsAttacked(Minion attacker, Minion defender) // 触发奥秘 重点调试
        {
            int newTarget = 0;
            int triggered = 0;
            if (this.isOwnTurn && this.enemySecretCount >= 1)
            {
                if (enemySecretList.Count == 0)
                {
                    Helpfunctions.Instance.logg("错误：敌方奥秘列表为空，但敌方奥秘数量是" + enemySecretCount);
                    if (enemyHeroName == HeroEnum.mage)  // Todo: 待修复，这里先增加一个防火焰结界
                        enemySecretList.Add(new SecretItem());
                }

                if (defender.isHero && !defender.own) // 攻击敌方英雄
                {
                    foreach (SecretItem si in this.enemySecretList)
                    {
                        // 添加上每个策略自身的惩罚
                        this.evaluatePenality += Ai.Instance.botBase.getSecretPen_CharIsAttacked(this, si, attacker, defender);
                        bool needDamageTrigger = false;

                        if (si.canBe_explosive)  //爆炸
                        {
                            triggered++;
                            //foreach (SecretItem sii in this.enemySecretList)
                            //{
                            //    sii.canBe_explosive = false;
                            //}
                            //CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_610).sim_card.onSecretPlay(this, false, 0);
                            needDamageTrigger = true;
                        }

                        //if (!attacker.isHero && si.canBe_flameward)  //火焰结界，法师全场打3，防奥秘
                        //最新:我们不再模拟全场打3，因为这只是有可能是而已，我们通过得分来防奥秘
                        //{
                        //    triggered++;
                        //    foreach (SecretItem sii in this.enemySecretList)
                        //    {
                        //        sii.canBe_flameward = false;   // 不可能有2个相同奥秘
                        //    }
                        //    CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.ULD_239).sim_card.onSecretPlay(this, false, attacker.Angr);
                        //    //Todo: 这里要和猎人的爆炸陷阱不同，猎人是攻击前就会爆炸没打到脸，而火焰结界是能打到脸
                        //    //应该用攻击值最大的尝试
                        //    needDamageTrigger = true;
                        //}

                        if (si.canBe_beartrap)
                        {
                            triggered++;
                            foreach (SecretItem sii in this.enemySecretList)
                            {
                                sii.canBe_beartrap = false;
                            }
                            CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_060).sim_card.onSecretPlay(this, false, 0);
                            needDamageTrigger = true;
                        }

                        if (attacker != null)
                        {
                            if (!attacker.isHero && si.canBe_vaporize)
                            {
                                triggered++;
                                foreach (SecretItem sii in this.enemySecretList)
                                {
                                    sii.canBe_vaporize = false;
                                }
                                CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_594).sim_card.onSecretPlay(this, false, attacker, 0);
                                needDamageTrigger = true;
                            }
                        }
                        if (si.canBe_missdirection)
                        {
                            if (!(attacker.isHero && this.ownMinions.Count + this.enemyMinions.Count == 0))
                            {
                                triggered++;
                                foreach (SecretItem sii in this.enemySecretList)
                                {
                                    sii.canBe_missdirection = false;
                                }
                                CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_533).sim_card.onSecretPlay(this, false, attacker, defender, out newTarget);
                                //no needDamageTrigger
                            }
                        }

                        if (si.canBe_icebarrier)
                        {
                            triggered++;
                            foreach (SecretItem sii in this.enemySecretList)
                            {
                                sii.canBe_icebarrier = false;
                            }
                            CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_289).sim_card.onSecretPlay(this, false, defender, 0);
                        }

                        if (needDamageTrigger) doDmgTriggers();
                    }
                }

                if (!defender.isHero && !defender.own)
                {
                    foreach (SecretItem si in this.enemySecretList)
                    {
                        if (si.canBe_snaketrap)
                        {
                            triggered++;
                            foreach (SecretItem sii in this.enemySecretList)
                            {
                                sii.canBe_snaketrap = false;
                            }
                            CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_554).sim_card.onSecretPlay(this, false, 0);
                            doDmgTriggers();
                        }
                    }
                }
                if (attacker != null)
                {
                    if (!attacker.isHero && attacker.own) // minion attacks
                    {
                        foreach (SecretItem si in this.enemySecretList)
                        {
                            if (si.canBe_freezing)
                            {
                                triggered++;
                                foreach (SecretItem sii in this.enemySecretList)
                                {
                                    sii.canBe_freezing = false;
                                }
                                CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_611).sim_card.onSecretPlay(this, false, attacker, 0);
                            }
                        }
                    }
                }

                foreach (SecretItem si in this.enemySecretList)
                {
                    if (si.canBe_noblesacrifice)
                    {
                        triggered++;
                        foreach (SecretItem sii in this.enemySecretList)
                        {
                            sii.canBe_noblesacrifice = false;
                        }
                        //bool ishero = defender.isHero;
                        //si.usedTrigger_CharIsAttacked(ishero, attacker.isHero);
                        //CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_130).sim_card.onSecretPlay(this, false, attacker, defender, out newTarget);
                        //no needDamageTrigger
                    }
                }
            }

            if (turnCounter == 0)
            {
                //this.evaluatePenality -= triggered * 50; Todo:不引入打分
            }

            return newTarget;
        }

        public void secretTrigger_HeroGotDmg(bool own, int dmg)
        {
            int triggered = 0;
            if (own != this.isOwnTurn)
            {
                if (this.isOwnTurn && this.enemySecretCount >= 1)
                {
                    SecretItem si = getMergedSeretItem(enemySecretList);
                    // 添加上每个策略自身的惩罚
                    this.evaluatePenality += Ai.Instance.botBase.getSecretPen_HeroGotDmg(this, si, own, dmg);

                    if (si.canBe_eyeforaneye)
                    {
                        triggered++;
                        foreach (SecretItem sii in this.enemySecretList)
                        {
                            sii.canBe_eyeforaneye = false;
                        }
                        CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_132).sim_card.onSecretPlay(this, false, dmg);
                    }

                    // 寒冰屏障
                    if (si.canBe_iceblock && this.enemyHero.Hp <= 0)
                    {
                        triggered++;
                        foreach (SecretItem sii in this.enemySecretList)
                        {
                            sii.canBe_iceblock = false;
                        }
                        //CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_295).sim_card.onSecretPlay(this, false, this.enemyHero, dmg);
                    }
                }
            }

            if (turnCounter == 0)
            {
                //this.evaluatePenality -= triggered * 50; Todo:不引入打分
            }

        }

        public void secretTrigger_MinionIsPlayed(Minion playedMinion)
        {
            int triggered = 0;
            if (this.isOwnTurn && playedMinion.own && this.enemySecretCount >= 1)
            {
                SecretItem si = getMergedSeretItem(enemySecretList);
                // 添加上每个策略自身的惩罚
                this.evaluatePenality += Ai.Instance.botBase.getSecretPen_MinionIsPlayed(this, si, playedMinion);
                bool needDamageTrigger = false;

                if (si.canBe_mirrorentity)
                {
                    triggered++;
                    foreach (SecretItem sii in this.enemySecretList)
                    {
                        sii.canBe_mirrorentity = false;
                    }
                    CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_294).sim_card.onSecretPlay(this, false, playedMinion, 0);
                    needDamageTrigger = true;
                }

                if (si.canBe_repentance)
                {
                    triggered++;
                    foreach (SecretItem sii in this.enemySecretList)
                    {
                        sii.canBe_repentance = false;
                    }
                    CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_379).sim_card.onSecretPlay(this, false, playedMinion, 0);
                }

                if (si.canBe_sacredtrial && this.ownMinions.Count > 3)
                {
                    triggered++;
                    foreach (SecretItem sii in this.enemySecretList)
                    {
                        sii.canBe_sacredtrial = false;
                        sii.canBe_snipe = false;
                    }
                    CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.LOE_027).sim_card.onSecretPlay(this, false, playedMinion, 0);
                    needDamageTrigger = true;
                }
                //else if (si.canBe_snipe)
                //{
                //    triggered++;
                //    foreach (SecretItem sii in this.enemySecretList)
                //    {
                //        sii.canBe_snipe = false;
                //    }
                //    CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_609).sim_card.onSecretPlay(this, false, playedMinion, 0);
                //    needDamageTrigger = true;
                //}

                if (needDamageTrigger) doDmgTriggers();
            }

            if (turnCounter == 0)
            {
                //this.evaluatePenality -= triggered * 50; //Todo: 不引入打分
            }

        }

        public int secretTrigger_SpellIsPlayed(Minion target, CardDB.Card c)
        {
            int triggered = 0;
            int retval = 0;
            bool isSpell = (c.type == CardDB.cardtype.SPELL);
            if (this.isOwnTurn && isSpell && this.enemySecretCount > 0) //actual secrets need a spell played!
            {
                //foreach (SecretItem si in this.enemySecretList)
                //{
                //    // 添加上每个策略自身的惩罚
                //    this.evaluatePenality += Ai.Instance.botBase.getSecretPen_SpellIsPlayed(this, si, target, c);

                //    if (si.canBe_counterspell)
                //    {
                //        triggered++;
                //        // dont use spell!
                //        foreach (SecretItem sii in this.enemySecretList)
                //        {
                //            sii.canBe_counterspell = false;
                //        }

                //        if (target != null && target.own && prozis.penman.maycauseharmDatabase.ContainsKey(c.name)) this.evaluatePenality += 15;

                //        if (turnCounter == 0)
                //        {
                //            this.evaluatePenality -= triggered * 50;
                //        }
                //        return -2;//spellbender will NEVER trigger  扰咒术
                //    }
                //}
                SecretItem si = getMergedSeretItem(enemySecretList);
                // 添加上每个策略自身的惩罚
                this.evaluatePenality += Ai.Instance.botBase.getSecretPen_SpellIsPlayed(this, si, target, c);

                if (si.canBe_cattrick)
                {
                    triggered++;
                    foreach (SecretItem sii in this.enemySecretList)
                    {
                        sii.canBe_cattrick = false;
                    }
                    CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.KAR_004).sim_card.onSecretPlay(this, false, 0);
                    doDmgTriggers();
                }

                if (si.canBe_spellbender && target != null && !target.isHero)
                {
                    triggered++;
                    foreach (SecretItem sii in this.enemySecretList)
                    {
                        sii.canBe_spellbender = false;
                    }
                    if (target.own && prozis.penman.maycauseharmDatabase.ContainsKey(c.nameEN)) { }
                    else CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.tt_010).sim_card.onSecretPlay(this, false, null, target, out retval);
                }
            }

            if (turnCounter == 0)
            {
                //this.evaluatePenality -= triggered * 50; //Todo: 不引入打分
            }

            return retval; // the new target

        }

        public void secretTrigger_MinionDied(bool own)
        {
            int triggered = 0;

            if (this.isOwnTurn && !own && this.enemySecretCount >= 1)
            {
                SecretItem si = getMergedSeretItem(enemySecretList);
                // 添加上每个策略自身的惩罚
                this.evaluatePenality += Ai.Instance.botBase.getSecretPen_MinionDied(this, si, own);

                if (si.canBe_duplicate)
                {
                    triggered++;
                    foreach (SecretItem sii in this.enemySecretList)
                    {
                        sii.canBe_duplicate = false;
                    }
                    CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.FP1_018).sim_card.onSecretPlay(this, false, 0);
                }

                if (si.canBe_redemption)
                {
                    triggered++;
                    foreach (SecretItem sii in this.enemySecretList)
                    {
                        sii.canBe_redemption = false;
                    }
                    CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_136).sim_card.onSecretPlay(this, false, 0);
                }

                if (si.canBe_avenge)
                {
                    triggered++;
                    foreach (SecretItem sii in this.enemySecretList)
                    {
                        sii.canBe_avenge = false;
                    }
                    CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.FP1_020).sim_card.onSecretPlay(this, false, 0);
                }
            }

            if (turnCounter == 0)
            {
                //this.evaluatePenality -= triggered * 50; //触发奥秘惩罚值 50 //Todo: 不引入打分
            }

        }

        public void secretTrigger_HeroPowerUsed()
        {
            int triggered = 0;
            if (this.isOwnTurn && this.enemySecretCount >= 1)
            {
                SecretItem si = getMergedSeretItem(enemySecretList);
                // 添加上每个策略自身的惩罚
                this.evaluatePenality += Ai.Instance.botBase.getSecretPen_HeroPowerUsed(this, si);

                if (si.canBe_darttrap)
                {
                    triggered++;
                    foreach (SecretItem sii in this.enemySecretList)
                    {
                        sii.canBe_darttrap = false;
                    }
                    CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.LOE_021).sim_card.onSecretPlay(this, false, 0);
                    doDmgTriggers();
                }
            }

            if (turnCounter == 0)
            {
                //this.evaluatePenality -= triggered * 50; //Todo: 不引入打分
            }
        }


        public int getSecretTriggersByType(int type, bool actedMinionOwn, bool actedMinionIsHero, Minion target)
        {
            int triggered = 0;
            bool isSpell = false;

            switch (type)
            {
                case 0:
                    if (this.isOwnTurn && actedMinionOwn && this.enemySecretCount >= 1)
                    {
                        bool canBe_mirrorentity = false;
                        bool canBe_repentance = false;
                        bool canBe_sacredtrial = false;
                        bool canBe_snipe = false;
                        foreach (SecretItem si in this.enemySecretList.ToArray())
                        {
                            if (si.canBe_mirrorentity && !canBe_mirrorentity) { canBe_mirrorentity = true; triggered++; }
                            if (si.canBe_repentance && !canBe_repentance) { canBe_repentance = true; triggered++; }
                            if (si.canBe_sacredtrial && this.ownMinions.Count > 3 && !canBe_sacredtrial) { canBe_sacredtrial = true; canBe_snipe = true; triggered++; }
                            else if (si.canBe_snipe && !canBe_snipe) { canBe_snipe = true; triggered++; }
                        }
                    }
                    break;

                case 1:
                    if (this.isOwnTurn && isSpell && this.enemySecretCount >= 1)
                    {
                        bool canBe_counterspell = false;
                        bool canBe_spellbender = false;
                        bool canBe_cattrick = false;
                        foreach (SecretItem si in this.enemySecretList)
                        {
                            if (si.canBe_counterspell && !canBe_counterspell) return 1;
                            if (si.canBe_spellbender && target != null && !target.isHero && !canBe_spellbender) { canBe_spellbender = true; triggered++; }
                            if (si.canBe_cattrick && !canBe_cattrick) { canBe_cattrick = true; triggered++; }
                        }
                    }
                    break;

                case 2:
                    if (this.isOwnTurn && this.enemySecretCount >= 1)
                    {
                        if (target.isHero && !target.own)
                        {
                            bool canBe_explosive = false;
                            bool canBe_flameward = false;
                            bool canBe_beartrap = false;
                            bool canBe_vaporize = false;
                            bool canBe_missdirection = false;
                            bool canBe_icebarrier = false;
                            foreach (SecretItem si in this.enemySecretList)
                            {
                                if (si.canBe_explosive && !canBe_explosive) { canBe_explosive = true; triggered++; }
                                if (si.canBe_flameward && !canBe_flameward) { canBe_flameward = true; triggered++; }
                                if (si.canBe_beartrap && !canBe_beartrap) { canBe_beartrap = true; triggered++; }
                                if (!actedMinionIsHero && si.canBe_vaporize && !canBe_vaporize) { canBe_vaporize = true; triggered++; }
                                if (si.canBe_missdirection && !canBe_missdirection)
                                {
                                    if (!(actedMinionIsHero && this.ownMinions.Count + this.enemyMinions.Count == 0))
                                    {
                                        canBe_missdirection = true;
                                        triggered++;
                                    }
                                }
                                if (si.canBe_icebarrier && !canBe_icebarrier) { canBe_icebarrier = true; triggered++; }
                            }
                        }

                        if (!target.isHero && !target.own)
                        {
                            bool canBe_snaketrap = false;
                            foreach (SecretItem si in this.enemySecretList)
                            {
                                if (si.canBe_snaketrap && !canBe_snaketrap) { canBe_snaketrap = true; triggered++; }
                            }
                        }

                        if (!actedMinionIsHero && actedMinionOwn) // minion attacks
                        {
                            bool canBe_freezing = false;
                            foreach (SecretItem si in this.enemySecretList)
                            {
                                if (si.canBe_freezing && !canBe_freezing) { canBe_freezing = true; triggered++; }
                            }
                        }

                        bool canBe_noblesacrifice = false;
                        foreach (SecretItem si in this.enemySecretList)
                        {
                            if (si.canBe_noblesacrifice && !canBe_noblesacrifice) { canBe_noblesacrifice = true; triggered++; }
                        }
                    }
                    break;

                case 3:
                    if (target.own != this.isOwnTurn)
                    {
                        if (this.isOwnTurn && this.enemySecretCount >= 1)
                        {
                            bool canBe_eyeforaneye = false;
                            bool canBe_iceblock = false;
                            foreach (SecretItem si in this.enemySecretList)
                            {
                                if (si.canBe_eyeforaneye && !canBe_eyeforaneye) { canBe_eyeforaneye = true; triggered++; }
                                if (si.canBe_iceblock && this.enemyHero.Hp <= 0 && !canBe_iceblock) { canBe_iceblock = true; triggered++; }
                            }
                        }
                    }
                    break;

                case 4:
                    if (this.isOwnTurn && !target.own && this.enemySecretCount >= 1)
                    {
                        bool canBe_duplicate = false;
                        bool canBe_redemption = false;
                        bool canBe_avenge = false;
                        foreach (SecretItem si in this.enemySecretList)
                        {
                            if (si.canBe_duplicate && !canBe_duplicate) { canBe_duplicate = true; triggered++; }
                            if (si.canBe_redemption && !canBe_redemption) { canBe_redemption = true; triggered++; }
                            if (si.canBe_avenge && !canBe_avenge) { canBe_avenge = true; triggered++; }
                        }
                    }
                    break;

                case 5:
                    if (this.isOwnTurn && this.enemySecretCount >= 1)
                    {
                        bool canBe_darttrap = false;
                        foreach (SecretItem si in this.enemySecretList)
                        {
                            if (si.canBe_darttrap && !canBe_darttrap) { canBe_darttrap = true; triggered++; }
                        }
                    }
                    break;
            }
            return triggered;
        }

        public void doDeathrattles(List<Minion> deathrattleMinions)
        {
            //todo sort them from oldest to newest (first played, first deathrattle)
            //https://www.youtube.com/watch?v=2WrbqsOSbhc
            foreach (Minion m in deathrattleMinions)
            {
                if (!m.silenced && m.handcard.card.deathrattle) m.handcard.card.sim_card.onDeathrattle(this, m);

                if (m.explorershat > 0)
                {
                    for (int i = 0; i < m.explorershat; i++)
                    {
                        drawACard(CardDB.cardNameEN.explorershat, m.own, true);
                    }
                }

                if (m.returnToHand > 0)
                {
                    drawACard(m.handcard.card.cardIDenum, m.own, true);
                }

                if (m.infest > 0)
                {
                    for (int i = 0; i < m.infest; i++)
                    {
                        drawACard(CardDB.cardNameEN.rivercrocolisk, m.own, true);
                    }
                }

                if (m.ancestralspirit > 0)
                {
                    for (int i = 0; i < m.ancestralspirit; i++)
                    {
                        CardDB.Card kid = m.handcard.card;
                        int pos = (m.own) ? this.ownMinions.Count : this.enemyMinions.Count;
                        callKid(kid, pos, m.own, false, true);
                    }
                }

                if (m.desperatestand > 0)
                {
                    for (int i = 0; i < m.desperatestand; i++)
                    {
                        CardDB.Card kid = m.handcard.card;
                        List<Minion> tmp = (m.own) ? this.ownMinions : this.enemyMinions;
                        int pos = tmp.Count;
                        callKid(kid, pos, m.own, false, true);

                        if (tmp.Count >= 1)
                        {
                            Minion summonedMinion = tmp[pos];
                            if (summonedMinion.handcard.card.cardIDenum == kid.cardIDenum)
                            {
                                summonedMinion.Hp = 1;
                                summonedMinion.wounded = false;
                                if (summonedMinion.Hp < summonedMinion.maxHp) summonedMinion.wounded = true;
                            }
                        }
                    }
                }

                for (int i = 0; i < m.souloftheforest; i++)
                {
                    CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_158t);//Treant
                    int pos = (m.own) ? this.ownMinions.Count : this.enemyMinions.Count;
                    callKid(kid, pos, m.own, false, true);
                }

                for (int i = 0; i < m.stegodon; i++)
                {
                    CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.UNG_810);//Stegodon
                    int pos = (m.own) ? this.ownMinions.Count : this.enemyMinions.Count;
                    callKid(kid, pos, m.own, false, true);
                }

                for (int i = 0; i < m.livingspores; i++)
                {
                    CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.UNG_999t2t1);//Plant
                    int pos = (m.own) ? this.ownMinions.Count : this.enemyMinions.Count;
                    callKid(kid, pos, m.own, false, true);
                    callKid(kid, pos, m.own, false, true);
                }

                if (m.deathrattle2 != null) m.deathrattle2.sim_card.onDeathrattle(this, m);

                //baron rivendare ??
                if ((m.own && this.ownBaronRivendare >= 1) || (!m.own && this.enemyBaronRivendare >= 1))
                {
                    int r = (m.own) ? this.ownBaronRivendare : this.enemyBaronRivendare;
                    for (int j = 0; j < r; j++)
                    {
                        if (!m.silenced && m.handcard.card.deathrattle) m.handcard.card.sim_card.onDeathrattle(this, m);

                        if (m.explorershat > 0)
                        {
                            for (int i = 0; i < m.explorershat; i++)
                            {
                                drawACard(CardDB.cardNameEN.explorershat, m.own, true);
                            }
                        }

                        if (m.returnToHand > 0)
                        {
                            drawACard(m.handcard.card.cardIDenum, m.own, true);
                        }

                        if (m.infest > 0)
                        {
                            for (int i = 0; i < m.infest; i++)
                            {
                                drawACard(CardDB.cardNameEN.rivercrocolisk, m.own, true);
                            }
                        }

                        if (m.ancestralspirit > 0)
                        {
                            for (int i = 0; i < m.ancestralspirit; i++)
                            {
                                CardDB.Card kid = m.handcard.card;
                                int pos = (m.own) ? this.ownMinions.Count : this.enemyMinions.Count;
                                callKid(kid, pos, m.own); //because baron rivendare
                            }
                        }

                        if (m.desperatestand > 0)
                        {
                            for (int i = 0; i < m.desperatestand; i++)
                            {
                                CardDB.Card kid = m.handcard.card;
                                List<Minion> tmp = (m.own) ? this.ownMinions : this.enemyMinions;
                                int pos = tmp.Count;
                                callKid(kid, pos, m.own, false, true);

                                if (tmp.Count >= 1)
                                {
                                    Minion summonedMinion = tmp[pos];
                                    if (summonedMinion.handcard.card.cardIDenum == kid.cardIDenum)
                                    {
                                        summonedMinion.Hp = 1;
                                        summonedMinion.wounded = false;
                                        if (summonedMinion.Hp < summonedMinion.maxHp) summonedMinion.wounded = true;
                                    }
                                }
                            }
                        }

                        for (int i = 0; i < m.souloftheforest; i++)
                        {
                            CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_158t);//Treant
                            int pos = (m.own) ? this.ownMinions.Count : this.enemyMinions.Count;
                            callKid(kid, pos, m.own); //because baron rivendare
                        }

                        for (int i = 0; i < m.stegodon; i++)
                        {
                            CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.UNG_810);//Stegodon
                            int pos = (m.own) ? this.ownMinions.Count : this.enemyMinions.Count;
                            callKid(kid, pos, m.own);  //because baron rivendare
                        }

                        for (int i = 0; i < m.livingspores; i++)
                        {
                            CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.UNG_999t2t1);//Plant
                            int pos = (m.own) ? this.ownMinions.Count : this.enemyMinions.Count;
                            callKid(kid, pos, m.own);
                            callKid(kid, pos, m.own);  //because baron rivendare
                        }

                        if (m.deathrattle2 != null) m.deathrattle2.sim_card.onDeathrattle(this, m);
                    }
                }
            }
        }


        public void updateBoards()
        {
            if (!this.tempTrigger.ownMinionsChanged && !this.tempTrigger.enemyMininsChanged) return;
            List<Minion> deathrattleMinions = new List<Minion>();

            bool minionOwnReviving = false;
            bool minionEnemyReviving = false;

            if (this.tempTrigger.ownMinionsChanged)
            {
                this.tempTrigger.ownMinionsChanged = false;
                List<Minion> temp = new List<Minion>();
                int i = 1;
                foreach (Minion m in this.ownMinions)
                {
                    //delete adjacent buffs
                    this.minionGetAdjacentBuff(m, -m.AdjacentAngr, 0);
                    m.cantBeTargetedBySpellsOrHeroPowers = false;

                    //kill it!
                    if (m.Hp <= 0)
                    {
                        this.OwnLastDiedMinion = m.handcard.card.cardIDenum;
                        if (this.revivingOwnMinion == CardDB.cardIDEnum.None)
                        {
                            this.revivingOwnMinion = m.handcard.card.cardIDenum;
                            minionOwnReviving = true;
                        }

                        if ((!m.silenced && m.handcard.card.deathrattle) || m.ancestralspirit >= 1 || m.desperatestand >= 1 || m.souloftheforest >= 1 || m.stegodon >= 1 || m.livingspores >= 1 || m.infest >= 1 || m.explorershat >= 1 || m.returnToHand >= 1 || m.deathrattle2 != null)
                        {
                            deathrattleMinions.Add(m);
                        }

                        // end aura of minion m
                        if (!m.silenced) m.handcard.card.sim_card.onAuraEnds(this, m);
                    }
                    else
                    {
                        m.zonepos = i;
                        temp.Add(m);
                        i++;
                    }

                }
                this.ownMinions = temp;
                this.updateAdjacentBuffs(true);
            }

            if (this.tempTrigger.enemyMininsChanged)
            {
                this.tempTrigger.enemyMininsChanged = false;
                List<Minion> temp = new List<Minion>();
                int i = 1;
                foreach (Minion m in this.enemyMinions)
                {
                    //delete adjacent buffs
                    this.minionGetAdjacentBuff(m, -m.AdjacentAngr, 0);
                    m.cantBeTargetedBySpellsOrHeroPowers = false;

                    //kill it!
                    if (m.Hp <= 0)
                    {
                        if (this.revivingEnemyMinion == CardDB.cardIDEnum.None)
                        {
                            this.revivingEnemyMinion = m.handcard.card.cardIDenum;
                            minionEnemyReviving = true;
                        }

                        if ((!m.silenced && m.handcard.card.deathrattle) || m.ancestralspirit >= 1 || m.desperatestand >= 1 || m.souloftheforest >= 1 || m.stegodon >= 1 || m.livingspores >= 1 || m.infest >= 1 || m.explorershat >= 1 || m.returnToHand >= 1 || m.deathrattle2 != null)
                        {
                            deathrattleMinions.Add(m);
                        }

                        // end aura of minion m
                        if (!m.silenced) m.handcard.card.sim_card.onAuraEnds(this, m);
                    }
                    else
                    {
                        m.zonepos = i;
                        temp.Add(m);
                        i++;
                    }

                }
                this.enemyMinions = temp;
                this.updateAdjacentBuffs(false);
            }

            if (this.ownWeapon.name == CardDB.cardNameEN.spiritclaws)
            {
                int dif = 0;
                if (this.spellpower > 0) dif += 2;
                if (this.spellpowerStarted > 0) dif -= 2;
                if (dif > 0)
                {
                    if (!this.ownSpiritclaws)
                    {
                        this.minionGetBuffed(this.ownHero, 2, 0);
                        this.ownWeapon.Angr += 2;
                        this.ownSpiritclaws = true;
                    }
                }
                else if (dif < 0)
                {
                    if (this.ownSpiritclaws)
                    {
                        this.minionGetBuffed(this.ownHero, -2, 0);
                        this.ownWeapon.Angr -= 2;
                        this.ownSpiritclaws = false;
                    }
                }
            }
            if (this.enemyWeapon.name == CardDB.cardNameEN.spiritclaws)
            {
                int dif = 0;
                if (this.enemyspellpower > 0) dif += 2;
                if (this.enemyspellpowerStarted > 0) dif -= 2;
                if (dif > 0)
                {
                    if (!this.enemySpiritclaws)
                    {
                        this.minionGetBuffed(this.enemyHero, 2, 0);
                        this.enemyWeapon.Angr += 2;
                        this.enemySpiritclaws = true;
                    }
                }
                else
                {
                    if (this.enemySpiritclaws)
                    {
                        this.minionGetBuffed(this.enemyHero, -2, 0);
                        this.enemyWeapon.Angr -= 2;
                        this.enemySpiritclaws = false;
                    }
                }
            }


            if (deathrattleMinions.Count >= 1) this.doDeathrattles(deathrattleMinions);

            if (minionOwnReviving)
            {
                this.secretTrigger_MinionDied(true);
                this.revivingOwnMinion = CardDB.cardIDEnum.None;
            }

            if (minionEnemyReviving)
            {
                this.secretTrigger_MinionDied(false);
                this.revivingEnemyMinion = CardDB.cardIDEnum.None;
            }
            //update buffs
        }

        public void minionGetOrEraseAllAreaBuffs(Minion m, bool get)
        {//随从加光环buff
            if (m.isHero) return;
            int angr = 0;
            int vert = 0;

            if (!m.silenced) // if they are not silenced, these minions will give a buff, but cant buff themselfes
            {
                switch (m.name)
                {
                    case CardDB.cardNameEN.raidleader: angr--; break;
                    case CardDB.cardNameEN.vessina:
                        if (this.ueberladung > 0 || this.lockedMana > 0)
                            angr--;
                        break;
                    case CardDB.cardNameEN.leokk: angr--; break;
                    case CardDB.cardNameEN.timberwolf: angr--; break;
                    case CardDB.cardNameEN.stormwindchampion:
                        angr--;
                        vert--;
                        break;
                    case CardDB.cardNameEN.southseacaptain:
                        angr--;
                        vert--;
                        break;
                    case CardDB.cardNameEN.grimscaleoracle:
                        angr--;
                        break;
                    case CardDB.cardNameEN.murlocwarleader:
                        if (get)
                        {
                            angr -= 2;
                        }
                        break;
                }
            }

            if (m.handcard.card.race == CardDB.Race.MURLOC)
            {
                if (m.own)
                {
                    angr += 2 * anzOwnMurlocWarleader + anzOwnGrimscaleOracle;
                }
                else
                {
                    angr += 2 * anzEnemyMurlocWarleader + anzEnemyGrimscaleOracle;
                }
            }
            if (m.own)
            {
                angr += anzOwnRaidleader;
                if (this.ueberladung > 0 || this.lockedMana > 0)
                {
                    angr += anzOwnVessina;
                }
                angr += anzOwnStormwindChamps;
                vert += anzOwnStormwindChamps;
                if (m.name == CardDB.cardNameEN.silverhandrecruit) angr += anzOwnWarhorseTrainer;
                if (m.handcard.card.race == CardDB.Race.BEAST)
                {
                    angr += anzOwnTimberWolfs;
                    if (get) m.charge += anzOwnTundrarhino;
                    else m.charge -= anzOwnTundrarhino;
                }
                if (m.handcard.card.race == CardDB.Race.PIRATE)
                {
                    angr += anzOwnSouthseacaptain;
                    vert += anzOwnSouthseacaptain;
                    //重拳先生
                    if (get) m.charge += anzOwnMrSmite;
                    else m.charge -= anzOwnMrSmite;
                }
                if (m.handcard.card.race == CardDB.Race.DEMON)
                {
                    angr += anzOwnMalGanis * 2;
                    vert += anzOwnMalGanis * 2;

                }

            }
            else
            {
                angr += anzEnemyRaidleader;
                if (this.ueberladung > 0 || this.lockedMana > 0)
                {
                    angr += anzEnemyVessina;
                }
                angr += anzEnemyStormwindChamps;
                vert += anzEnemyStormwindChamps;

                if (m.name == CardDB.cardNameEN.silverhandrecruit) angr += anzEnemyWarhorseTrainer;
                if (m.handcard.card.race == CardDB.Race.BEAST)
                {
                    angr += anzEnemyTimberWolfs;
                    if (get) m.charge += anzEnemyTundrarhino;
                    else m.charge -= anzEnemyTundrarhino;
                }
                if (m.handcard.card.race == CardDB.Race.PIRATE)
                {
                    angr += anzEnemySouthseacaptain;
                    vert += anzEnemySouthseacaptain;
                    if (get) m.charge += anzEnemyMrSmite;
                    else m.charge -= anzEnemyMrSmite;
                }
                if (m.handcard.card.race == CardDB.Race.DEMON)
                {
                    angr += anzEnemyMalGanis * 2;
                    vert += anzEnemyMalGanis * 2;

                }
            }

            if (get) this.minionGetBuffed(m, angr, vert);
            else this.minionGetBuffed(m, -angr, -vert);

        }

        public void updateAdjacentBuffs(bool own)
        {
            //only call this after update board
            List<Minion> temp = own ? this.ownMinions : this.enemyMinions;

            int anz = temp.Count;
            for (int i = 0; i < anz; i++)
            {
                Minion m = temp[i];
                if (!m.silenced)
                {
                    switch (m.name)
                    {
                        case CardDB.cardNameEN.faeriedragon: m.cantBeTargetedBySpellsOrHeroPowers = true; continue;
                        case CardDB.cardNameEN.spectralknight: m.cantBeTargetedBySpellsOrHeroPowers = true; continue;
                        case CardDB.cardNameEN.laughingsister: m.cantBeTargetedBySpellsOrHeroPowers = true; continue;
                        case CardDB.cardNameEN.soggoththeslitherer: m.cantBeTargetedBySpellsOrHeroPowers = true; continue;
                        case CardDB.cardNameEN.arcanenullifierx21: m.cantBeTargetedBySpellsOrHeroPowers = true; continue;
                        case CardDB.cardNameEN.weespellstopper:
                            if (i > 0) temp[i - 1].cantBeTargetedBySpellsOrHeroPowers = true;
                            if (i < anz - 1) temp[i + 1].cantBeTargetedBySpellsOrHeroPowers = true;
                            continue;
                        case CardDB.cardNameEN.direwolfalpha:
                            if (i > 0) this.minionGetAdjacentBuff(temp[i - 1], 1, 0);
                            if (i < anz - 1) this.minionGetAdjacentBuff(temp[i + 1], 1, 0);
                            continue;
                        case CardDB.cardNameEN.flametonguetotem:
                            if (i > 0) this.minionGetAdjacentBuff(temp[i - 1], 2, 0);
                            if (i < anz - 1) this.minionGetAdjacentBuff(temp[i + 1], 2, 0);
                            continue;
                    }
                }
            }
        }

        public Minion createNewMinion(Handmanager.Handcard hc, int zonepos, bool own)
        {
            Minion m = new Minion();
            Handmanager.Handcard handc = new Handmanager.Handcard(hc);
            m.handcard = handc;
            m.own = own;
            m.isHero = false;
            m.entitiyID = hc.entity;
            if (this.ownCrystalCore > 0)
            {
                m.Angr = ownCrystalCore;
                m.Hp = ownCrystalCore;
                m.maxHp = ownCrystalCore;
            }
            else
            {
                m.Angr = hc.card.Attack + hc.addattack;
                m.Hp = hc.card.Health + hc.addHp;
                m.maxHp = hc.card.Health;
            }

            hc.addattack = 0;
            hc.addHp = 0;

            m.name = hc.card.nameEN;
            m.playedThisTurn = true;
            m.numAttacksThisTurn = 0;
            m.zonepos = zonepos;
            m.reborn = hc.card.reborn;
            m.windfury = hc.card.windfury;
            m.taunt = hc.card.tank;
            m.charge = (hc.card.Charge) ? 1 : 0;
            m.Spellburst = hc.card.Spellburst;//法术迸发
            m.dormant = hc.card.dormant;
            m.untouchable = m.dormant > 0;


            m.rush = (hc.card.Rush) ? 1 : 0;
            m.divineshild = hc.card.Shield;
            m.poisonous = hc.card.poisonous;
            m.lifesteal = hc.card.lifesteal;
            if (this.prozis.ownElementalsHaveLifesteal > 0 && (TAG_RACE)m.handcard.card.race == TAG_RACE.ELEMENTAL) m.lifesteal = true;
            m.stealth = hc.card.Stealth;
            m.untouchable = m.untouchable || hc.card.untouchable;

            switch (m.name)
            {
                case CardDB.cardNameEN.lightspawn:
                    m.Angr = m.Hp;
                    break;
            }
            m.updateReadyness();

            if (m.name == CardDB.cardNameEN.lightspawn)
            {
                m.Angr = m.Hp;
            }

            if (own) m.synergy = prozis.penman.getClassRacePriorityPenality(this.ownHeroStartClass, (TAG_RACE)m.handcard.card.race);
            else m.synergy = prozis.penman.getClassRacePriorityPenality(this.enemyHeroStartClass, (TAG_RACE)m.handcard.card.race);
            if (m.synergy > 0 && hc.card.Stealth) m.synergy++;

            //trigger on summon effect!
            this.triggerAMinionIsSummoned(m);
            //activate onAura effect
            m.handcard.card.sim_card.onAuraStarts(this, m);
            //buffs minion
            this.minionGetOrEraseAllAreaBuffs(m, true);
            return m;
        }

        public void placeAmobSomewhere(Handmanager.Handcard hc, int choice, int zonepos)
        {
            int mobplace = zonepos;


            Minion m = createNewMinion(hc, mobplace, true);
            m.playedFromHand = true;

            //空降歹徒
            CardDB.Card parachuteBrigand = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.DRG_056);
            if ((TAG_RACE)hc.card.race == TAG_RACE.PIRATE)
            {
                List<Handmanager.Handcard> tmp = this.owncards;
                for (int i = 0; i < this.owncards.Count; i++)
                {
                    Handmanager.Handcard handcard = tmp[i];
                    if (handcard.card.cardIDenum == CardDB.cardIDEnum.DRG_056 && this.ownMinions.Count < 7)
                    {
                        this.callKid(parachuteBrigand, zonepos, true);
                        this.removeCard(handcard);
                    }
                }
            }


            //海盗帕奇斯
            CardDB.Card patches = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_637);
            if ((TAG_RACE)hc.card.race == TAG_RACE.PIRATE && this.prozis.patchesInDeck && this.ownMinions.Count < 7)
            {
                this.callKid(patches, zonepos, true);
                this.prozis.patchesInDeck = false;
                foreach (KeyValuePair<CardDB.cardIDEnum, int> dc in this.prozis.turnDeck)
                {
                    if (dc.Key == CardDB.cardIDEnum.CFM_637) this.prozis.turnDeck.Remove(dc.Key);
                    this.ownDeckSize--;
                    break;
                }
            }

            addMinionToBattlefield(m);

            //trigger the battlecry!
            m.handcard.card.sim_card.getBattlecryEffect(this, m, hc.target, choice);
            //随从战吼的流放效果触发
            if (hc.position == 1 || hc.position == this.owncards.Count)
            {
                m.handcard.card.sim_card.onOutcast(this, m);
            }
            if (this.ownBrannBronzebeard > 0)
            {
                for (int i = 0; i < this.ownBrannBronzebeard; i++)
                {
                    m.handcard.card.sim_card.getBattlecryEffect(this, m, hc.target, choice);
                }
            }
            doDmgTriggers();

            secretTrigger_MinionIsPlayed(m);
            if (this.ownQuest.Id != CardDB.cardIDEnum.None)
            {
                ownQuest.trigger_MinionWasPlayed(m);
                // 任务完成奖励
                if(ownQuest.maxProgress <= ownQuest.questProgress)
                {
                    switch (this.ownQuest.Id)
                    {
                        case CardDB.cardIDEnum.SW_028:
                            foreach (KeyValuePair<CardDB.cardIDEnum, int> kvp in this.prozis.turnDeck)
                            {
                                // ID 转卡
                                CardDB.cardIDEnum deckCard = kvp.Key;
                                CardDB.Card card = CardDB.Instance.getCardDataFromID(deckCard);
                                if (card.type == CardDB.cardtype.WEAPON)
                                {
                                    this.drawACard(deckCard, true, true);
                                    break;
                                }
                            }
                            ownQuest = new Questmanager.QuestItem() { Id = CardDB.cardIDEnum.SW_028t, questProgress = 0, maxProgress = 2 };
                            break;
                        case CardDB.cardIDEnum.SW_028t:
                            minionGetDamageOrHeal(getEnemyCharTargetForRandomSingleDamage(2), 2, true);
                            ownQuest = new Questmanager.QuestItem() { Id = CardDB.cardIDEnum.SW_028t2, questProgress = 0, maxProgress = 2 };
                            break;
                        case CardDB.cardIDEnum.SW_028t2:
                            drawACard(CardDB.cardIDEnum.SW_028t5, true, true);
                            if (this.ownMaxMana == 4) evaluatePenality -= 20;
                            ownQuest.Reset();
                            break;
                    }
                }
            }


            if (logging) Helpfunctions.Instance.logg("added " + m.handcard.card.nameEN);
        }

        public void addMinionToBattlefield(Minion m, bool isSummon = true)
        {
            List<Minion> temp = (m.own) ? this.ownMinions : this.enemyMinions;
            if (temp.Count >= m.zonepos && m.zonepos >= 1)
            {
                temp.Insert(m.zonepos - 1, m);
            }
            else
            {
                temp.Add(m);
            }
            if (m.own)
            {
                this.tempTrigger.ownMinionsChanged = true;
                if (m.handcard.card.race == CardDB.Race.BEAST) this.tempTrigger.ownBeastSummoned++;
            }
            else this.tempTrigger.enemyMininsChanged = true;

            //minion was played secrets? trigger here---- (+ do triggers)

            //trigger a minion was summoned
            triggerAMinionWasSummoned(m);
            doDmgTriggers();

            m.updateReadyness();
        }

        public void equipWeapon(CardDB.Card c, bool own)
        {
            Minion hero = (own) ? this.ownHero : this.enemyHero;
            if (own)
            {
                if (this.ownWeapon.Durability > 0)
                {
                    bool calcLostWeaponDamage = true;
                    switch (c.nameEN)
                    {
                        case CardDB.cardNameEN.rustyhook: goto case CardDB.cardNameEN.wickedknife;
                        case CardDB.cardNameEN.poisoneddagger: goto case CardDB.cardNameEN.wickedknife;
                        case CardDB.cardNameEN.wickedknife:
                            if (this.ownWeapon.Angr <= c.Attack && this.ownWeapon.Durability < this.ownWeapon.card.Durability) calcLostWeaponDamage = false;
                            break;
                    }
                    foreach(Minion m in this.ownMinions)
                    {
                        if (m.handcard.card.nameCN == CardDB.cardNameCN.毁灭战舰)
                        {
                            calcLostWeaponDamage = false;
                        }
                    }
                    if (calcLostWeaponDamage)
                    {
                        if (this.ownWeapon.card.cardIDenum == c.cardIDenum) this.lostDamage += 100;
                        if (this.ownWeapon.card.nameCN == CardDB.cardNameCN.海盗之锚) this.lostWeaponDamage += 10;
                        // 刀耐久还是满的
                        if (this.ownWeapon.card.Durability > 0 && this.ownWeapon.Durability >= this.ownWeapon.card.Durability) this.lostWeaponDamage += 10;
                        if (this.ownWeapon.card.nameCN == CardDB.cardNameCN.逝者之剑) this.lostWeaponDamage += 10;
                        this.lostWeaponDamage += this.ownWeapon.Durability * this.ownWeapon.Angr;
                        // 换了把更菜的刀
                        if (this.ownWeapon.Angr >= c.Attack) this.lostWeaponDamage += 10;
                    }
                    this.lowerWeaponDurability(1000, true);
                }
                // TODO 武器亡语？
                this.ownWeapon.equip(c);
            }
            else
            {
                this.lowerWeaponDurability(1000, false);
                this.enemyWeapon.equip(c);
            }

            hero.Angr += c.Attack;
            hero.windfury = c.windfury;
            hero.updateReadyness();
            hero.immuneWhileAttacking = (c.nameEN == CardDB.cardNameEN.gladiatorslongbow);

            List<Minion> temp = (own) ? this.ownMinions : this.enemyMinions;
            foreach (Minion m in temp)
            {
                switch (m.name)
                {
                    case CardDB.cardNameEN.southseadeckhand:
                        if (m.playedThisTurn) minionGetCharge(m);
                        break;
                    case CardDB.cardNameEN.buccaneer:
                        if (own) this.ownWeapon.Angr++;
                        else this.enemyWeapon.Angr++;
                        break;
                    case CardDB.cardNameEN.smalltimebuccaneer:
                        this.minionGetBuffed(m, 2, 0);
                        break;
                }
            }

        }



        public void callKid(CardDB.Card c, int zonepos, bool own, bool spawnKid = true, bool oneMoreIsAllowed = false)
        {

            int allowed = 7;
            allowed += (oneMoreIsAllowed) ? 1 : 0;

            if (own)
            {
                if (this.ownMinions.Count >= allowed)
                {
                    //if (spawnKid) this.evaluatePenality += 10;
                    //else this.evaluatePenality += 20;
                    //Todo: 不引入打分
                    return;
                }
            }
            else
            {
                if (this.enemyMinions.Count >= allowed)
                {
                    //if (spawnKid) this.evaluatePenality -= 10;
                    //else this.evaluatePenality -= 20;
                    //Todo: 不引入打分
                    return;
                }
            }
            int mobplace = zonepos + 1;

            //create minion (+triggers)
            Handmanager.Handcard hc = new Handmanager.Handcard(c) { entity = this.getNextEntity() };
            Minion m = createNewMinion(hc, mobplace, own);
            //put it on battle field (+triggers)
            addMinionToBattlefield(m);

        }

        public void minionGetFrozen(Minion target)
        {
            target.frozen = true;
            if (target.isHero) return;
            if (this.anzMoorabi > 1)
            {
                foreach (Minion m in this.ownMinions)
                {
                    switch (m.name)
                    {
                        case CardDB.cardNameEN.moorabi:
                            if (m.silenced) continue;
                            this.drawACard(target.handcard.card.nameEN, m.own, true);
                            break;
                    }
                }
                foreach (Minion m in this.enemyMinions)
                {
                    switch (m.name)
                    {
                        case CardDB.cardNameEN.moorabi:
                            if (m.silenced) continue;
                            this.drawACard(target.handcard.card.nameEN, m.own, true);
                            break;
                    }
                }
            }
        }

        public void minionGetSilenced(Minion m)
        {
            //minion cant die due to silencing!
            m.becomeSilence(this);

        }

        public void allMinionsGetSilenced(bool own)
        {
            List<Minion> temp = (own) ? this.ownMinions : this.enemyMinions;
            foreach (Minion m in temp)
            {
                m.becomeSilence(this);
            }
        }

        public void drawACard(CardDB.cardNameEN ss, bool own, bool nopen = false)
        {
            CardDB.cardNameEN s = ss;

            // cant hold more than 10 cards
            if (own)
            {

                if (s == CardDB.cardNameEN.unknown && !nopen)
                {
                    if (ownDeckSize == 0)
                    {
                        this.ownHeroFatigue++;
                        this.ownHero.getDamageOrHeal(this.ownHeroFatigue, this, false, true);
                        return;
                    }
                    else
                    {
                        this.ownDeckSize--;
                        if (this.owncards.Count >= 10)
                        {
                            //this.evaluatePenality += 15; //Todo: 不引入打分
                            return;
                        }
                        this.owncarddraw++;
                    }

                }
                else
                {
                    if (this.owncards.Count >= 10)
                    {
                        //this.evaluatePenality += 5; //Todo: 不引入打分
                        return;
                    }
                    this.owncarddraw++;

                }


            }
            else
            {
                if (s == CardDB.cardNameEN.unknown && !nopen)
                {
                    if (enemyDeckSize == 0)
                    {
                        this.enemyHeroFatigue++;
                        this.enemyHero.getDamageOrHeal(this.enemyHeroFatigue, this, false, true);
                        return;
                    }
                    else
                    {
                        this.enemyDeckSize--;
                        if (this.enemyAnzCards >= 10)
                        {
                            //this.evaluatePenality -= (this.turnCounter > 2) ? 20 : 50; //Todo: 不引入打分
                            return;
                        }
                        this.enemycarddraw++;
                        this.enemyAnzCards++;
                    }

                }
                else
                {
                    if (this.enemyAnzCards >= 10)
                    {
                        // this.evaluatePenality -= (this.turnCounter > 2) ? 20 : 50; //Todo: 不引入打分
                        return;
                    }
                    this.enemycarddraw++;
                    this.enemyAnzCards++;
                }
                this.triggerCardsChanged(false);

                if (anzEnemyChromaggus > 0 && s == CardDB.cardNameEN.unknown && !nopen)
                {
                    for (int i = 1; i <= anzEnemyChromaggus; i++)
                    {
                        if (this.enemyAnzCards >= 10)
                        {
                            //this.evaluatePenality -= (this.turnCounter > 2) ? 20 : 50; //Todo: 不引入打分
                            return;
                        }
                        this.enemycarddraw++;
                        this.enemyAnzCards++;
                        this.triggerCardsChanged(false);

                    }
                }
                return;
            }

            if (s == CardDB.cardNameEN.unknown)
            {
                CardDB.Card c = CardDB.Instance.getCardData(s);
                Handmanager.Handcard hc = new Handmanager.Handcard { card = c, position = this.owncards.Count + 1, manacost = 1000, entity = this.getNextEntity() };
                this.owncards.Add(hc);
                this.triggerCardsChanged(true);
            }
            else
            {
                CardDB.Card c = CardDB.Instance.getCardData(s);
                Handmanager.Handcard hc = new Handmanager.Handcard { card = c, position = this.owncards.Count + 1, manacost = c.calculateManaCost(this), entity = this.getNextEntity() };
                this.owncards.Add(hc);
                this.triggerCardsChanged(true);
            }

            if (anzOwnChromaggus > 0 && s == CardDB.cardNameEN.unknown && !nopen)
            {
                CardDB.Card c = CardDB.Instance.getCardData(s);
                for (int i = 1; i <= anzOwnChromaggus; i++)
                {
                    if (this.owncards.Count >= 10)
                    {
                        //this.evaluatePenality += 15; //Todo: 不引入打分
                        return;
                    }
                    this.owncarddraw++;

                    Handmanager.Handcard hc = new Handmanager.Handcard { card = c, position = this.owncards.Count + 1, manacost = 1000, entity = this.getNextEntity() };
                    this.owncards.Add(hc);
                    this.triggerCardsChanged(true);
                }
            }

        }

        public void drawACard(CardDB.cardIDEnum ss, bool own, bool nopen = false)
        {
            CardDB.cardIDEnum s = ss;

            // cant hold more than 10 cards

            if (own)
            {
                if (s == CardDB.cardIDEnum.None && !nopen)
                {
                    if (ownDeckSize == 0)
                    {
                        this.ownHeroFatigue++;
                        this.ownHero.getDamageOrHeal(this.ownHeroFatigue, this, false, true);
                        return;
                    }
                    else
                    {
                        this.ownDeckSize--;
                        if (this.owncards.Count >= 10)
                        {
                            //this.evaluatePenality += 15; //Todo: 不引入打分
                            return;
                        }
                        this.owncarddraw++;
                    }
                    // 符文秘银杖
                    if (this.ownWeapon != null && this.ownWeapon.card.nameCN == CardDB.cardNameCN.符文秘银杖)
                    {
                        this.ownWeapon.scriptNum1++;
                    }

                }
                else
                {
                    if (this.owncards.Count >= 10)
                    {
                        //this.evaluatePenality += 5; //Todo: 不引入打分
                        return;
                    }
                    this.owncarddraw++;
                }
            }
            else
            {
                if (s == CardDB.cardIDEnum.None && !nopen)
                {
                    if (enemyDeckSize == 0)
                    {
                        this.enemyHeroFatigue++;
                        this.enemyHero.getDamageOrHeal(this.enemyHeroFatigue, this, false, true);
                        return;
                    }
                    else
                    {
                        this.enemyDeckSize--;
                        if (this.enemyAnzCards >= 10)
                        {
                            //this.evaluatePenality -= (this.turnCounter > 2) ? 20 : 50; //Todo: 不引入打分
                            return;
                        }
                        this.enemycarddraw++;
                        this.enemyAnzCards++;
                    }
                }
                else
                {
                    if (this.enemyAnzCards >= 10)
                    {
                        //this.evaluatePenality -= (this.turnCounter > 2) ? 20 : 50; //Todo: 不引入打分
                        return;
                    }
                    this.enemycarddraw++;
                    this.enemyAnzCards++;

                }
                this.triggerCardsChanged(false);

                if (anzEnemyChromaggus > 0 && s == CardDB.cardIDEnum.None && !nopen)
                {
                    for (int i = 1; i <= anzEnemyChromaggus; i++)
                    {
                        if (this.enemyAnzCards >= 10)
                        {
                            //this.evaluatePenality -= (this.turnCounter > 2) ? 20 : 50; //Todo: 不引入打分
                            return;
                        }
                        this.enemycarddraw++;
                        this.enemyAnzCards++;
                        this.triggerCardsChanged(false);
                    }
                }
                return;
            }

            if (s == CardDB.cardIDEnum.None)
            {
                CardDB.Card c = CardDB.Instance.getCardDataFromID(s);
                Handmanager.Handcard hc = new Handmanager.Handcard { card = c, position = this.owncards.Count + 1, manacost = 1000, entity = this.getNextEntity() };
                this.owncards.Add(hc);
                this.triggerCardsChanged(true);
            }
            else
            {
                CardDB.Card c = CardDB.Instance.getCardDataFromID(s);
                Handmanager.Handcard hc = new Handmanager.Handcard { card = c, position = this.owncards.Count + 1, manacost = c.calculateManaCost(this), entity = this.getNextEntity() };
                this.owncards.Add(hc);
                this.triggerCardsChanged(true);
            }

            if (anzOwnChromaggus > 0 && s == CardDB.cardIDEnum.None && !nopen)
            {
                CardDB.Card c = CardDB.Instance.getCardDataFromID(s);
                for (int i = 1; i <= anzOwnChromaggus; i++)
                {
                    if (this.owncards.Count >= 10)
                    {
                        //this.evaluatePenality += 15; //Todo: 不引入打分
                        return;
                    }
                    this.owncarddraw++;

                    Handmanager.Handcard hc = new Handmanager.Handcard { card = c, position = this.owncards.Count + 1, manacost = 1000, entity = this.getNextEntity() };
                    this.owncards.Add(hc);
                    this.triggerCardsChanged(true);
                }
            }

        }


        public void removeCard(Handmanager.Handcard hcc)
        {
            int cardPos = 1;
            int cardNum = 0;
            Handmanager.Handcard hcTmp = null;
            foreach (Handmanager.Handcard hc in this.owncards)
            {
                if (hc.entity == hcc.entity)
                {
                    hcTmp = hc;
                    cardNum++;
                    continue;
                }
                this.owncards[cardNum].position = cardPos;
                cardNum++;
                cardPos++;
            }
            if (hcTmp != null) this.owncards.Remove(hcTmp);
        }

        public void renumHandCards(List<Handmanager.Handcard> list)
        {
            int count = list.Count;
            for (int i = 0; i < count; i++) list[0].position = i + 1;
        }


        public void attackEnemyHeroWithoutKill(int dmg)
        {
            this.enemyHero.cantLowerHPbelowONE = true;
            this.minionGetDamageOrHeal(this.enemyHero, dmg);
            this.enemyHero.cantLowerHPbelowONE = false;
        }

        public void minionGetDestroyed(Minion m)
        {
            if (m.own)
            {
                if (m.playedThisTurn && m.charge == 0) this.lostDamage += m.Hp * 2 + m.Angr * 2 + (m.windfury ? m.Angr : 0) + ((m.handcard.card.isSpecialMinion && !m.taunt) ? 20 : 0);
            }

            if (m.Hp > 0)
            {
                m.Hp = 0;
                m.minionDied(this);
            }

        }

        public void allMinionsGetDestroyed()
        {
            foreach (Minion m in this.ownMinions)
            {
                minionGetDestroyed(m);
            }
            foreach (Minion m in this.enemyMinions)
            {
                minionGetDestroyed(m);
            }
        }


        public void minionGetArmor(Minion m, int armor)
        {
            m.armor += armor;
            foreach (Handmanager.Handcard hc in this.owncards.ToArray())
            {
                if (hc.card.nameCN == CardDB.cardNameCN.小型法术玉石)
                {
                    hc.SCRIPT_DATA_NUM_1 += armor;
                    if(hc.SCRIPT_DATA_NUM_1 >= 3)
                    {
                        hc.SCRIPT_DATA_NUM_1 = 0;
                        hc.card = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.LOOT_051t1);
                    }
                }
                if (hc.card.nameCN == CardDB.cardNameCN.法术玉石)
                {
                    hc.SCRIPT_DATA_NUM_1 += armor;
                    if (hc.SCRIPT_DATA_NUM_1 >= 3)
                    {
                        hc.SCRIPT_DATA_NUM_1 = 0;
                        hc.card = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.LOOT_051t2);
                    }
                }
            }
            this.triggerAHeroGotArmor(m.own);
        }

        public void minionReturnToHand(Minion m, bool own, int manachange)
        {
            List<Minion> temp = (m.own) ? this.ownMinions : this.enemyMinions;
            m.handcard.card.sim_card.onAuraEnds(this, m);
            temp.Remove(m);

            if (own)
            {
                CardDB.Card c = m.handcard.card;
                Handmanager.Handcard hc = new Handmanager.Handcard { card = c, position = this.owncards.Count + 1, entity = m.entitiyID, manacost = c.calculateManaCost(this) + manachange };
                if (this.owncards.Count < 10)
                {
                    this.owncards.Add(hc);
                    this.triggerCardsChanged(true);
                }
                else this.drawACard(CardDB.cardNameEN.unknown, true);
            }
            else this.drawACard(CardDB.cardNameEN.unknown, false);

            if (m.own) this.tempTrigger.ownMinionsChanged = true;
            else this.tempTrigger.enemyMininsChanged = true;
        }

        public void minionReturnToDeck(Minion m, bool own)
        {
            List<Minion> temp = (m.own) ? this.ownMinions : this.enemyMinions;
            m.handcard.card.sim_card.onAuraEnds(this, m);
            temp.Remove(m);

            if (m.own) this.tempTrigger.ownMinionsChanged = true;
            else this.tempTrigger.enemyMininsChanged = true;

            if (own) this.ownDeckSize++;
            else this.enemyDeckSize++;
        }

        public void minionTransform(Minion m, CardDB.Card c)
        {
            m.handcard.card.sim_card.onAuraEnds(this, m);//end aura of the minion

            Handmanager.Handcard hc = new Handmanager.Handcard(c) { entity = m.entitiyID };
            if ((m.ancestralspirit >= 1 || m.desperatestand >= 1) && !m.own)
            {
                //this.evaluatePenality -= Ai.Instance.botBase.getEnemyMinionValue(m, this) - 1; //Todo: 不引入打分
            }

            if (m.taunt)
            {
                if (m.own) this.anzOwnTaunt--;
                else this.anzEnemyTaunt--;
            }
            m.setMinionToMinion(createNewMinion(hc, m.zonepos, m.own));
            if (m.taunt)
            {
                if (m.own) this.anzOwnTaunt++;
                else this.anzEnemyTaunt++;
            }

            m.handcard.card.sim_card.onAuraStarts(this, m);
            this.minionGetOrEraseAllAreaBuffs(m, true);

            if (m.own)
            {
                this.tempTrigger.ownMinionsChanged = true;
            }
            else
            {
                this.tempTrigger.enemyMininsChanged = true;
            }

            if (logging) Helpfunctions.Instance.logg("minion got sheep" + m.name + " " + m.Angr);
        }

        public CardDB.Card getRandomCardForManaMinion(int manaCost)
        {
            CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_231);
            if (manaCost > 0)
            {
                if (manaCost > 10) manaCost = 10;
                switch (manaCost)
                {
                    case 1: kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_011); break;
                    case 2: kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_131); break;
                    case 3: kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_134); break;
                    case 4: kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.GVG_074); break;
                    case 5: kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.DS1_055); break;
                    case 6: kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_283); break;
                    case 7: kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CS2_088); break;
                    case 8: kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.NEW1_038); break;
                    case 9: kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_573); break;
                    case 10: kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.AT_120); break;
                }
            }
            return kid;
        }

        public Minion getEnemyCharTargetForRandomSingleDamage(int damage, bool onlyMinions = false)
        {
            Minion target = null;
            int tmp = this.guessingHeroHP;
            this.guessHeroDamage();
            if (this.guessingHeroHP < 0)
            {
                target = this.searchRandomMinionByMaxHP(this.enemyMinions, searchmode.searchHighestAttack, damage); //the last chance (optimistic)
                if ((target == null || this.enemyHero.Hp <= damage) && !onlyMinions) target = this.enemyHero;
            }
            else
            {
                target = this.searchRandomMinion(this.enemyMinions, damage > 3 ? searchmode.searchLowestHP : searchmode.searchHighestHP); //damage the lowest (pessimistic)
                if (target == null && !onlyMinions) target = this.enemyHero;
            }
            this.guessingHeroHP = tmp;
            return target;
        }

        public void minionGetControlled(Minion m, bool newOwner, bool canAttack, bool forced = false)
        {
            List<Minion> newOwnerList = (newOwner) ? this.ownMinions : this.enemyMinions;
            List<Minion> oldOwnerList = (newOwner) ? this.enemyMinions : this.ownMinions;
            bool isFreeSpace = true;

            if (newOwnerList.Count >= 7)
            {
                if (!forced) return;
                else isFreeSpace = false;
            }

            this.tempTrigger.ownMinionsChanged = true;
            this.tempTrigger.enemyMininsChanged = true;
            if (m.taunt)
            {
                if (newOwner)
                {
                    this.anzEnemyTaunt--;
                    if (isFreeSpace) this.anzOwnTaunt++;
                }
                else
                {
                    if (isFreeSpace) this.anzEnemyTaunt++;
                    this.anzOwnTaunt--;
                }
            }

            //end buffs/aura
            m.handcard.card.sim_card.onAuraEnds(this, m);
            this.minionGetOrEraseAllAreaBuffs(m, false);

            //remove minion from list
            oldOwnerList.Remove(m);

            if (isFreeSpace)
            {
                //change site (and minion is played in this turn)
                m.playedThisTurn = true;
                m.own = !m.own;

                // add minion to new list + new buffs
                newOwnerList.Add(m);
                m.handcard.card.sim_card.onAuraStarts(this, m);
                this.minionGetOrEraseAllAreaBuffs(m, true);

                if (m.charge >= 1 || canAttack) // minion can attack if its shadowmadnessed (canAttack = true) or it has charge
                {
                    this.minionGetCharge(m);
                }
                else m.updateReadyness();
            }

        }

        public void Magnetic(Minion mOwn)
        {
            List<Minion> temp = (mOwn.own) ? this.ownMinions : this.enemyMinions;
            foreach (Minion m in temp)
            {
                if (((TAG_RACE)m.handcard.card.race == TAG_RACE.MECHANICAL) && m.zonepos == mOwn.zonepos + 1)
                {
                    this.minionGetBuffed(m, mOwn.Angr, mOwn.Hp);
                    if (mOwn.taunt) m.taunt = true;
                    if (mOwn.divineshild) m.divineshild = true;
                    if (mOwn.lifesteal) m.lifesteal = true;
                    if (mOwn.poisonous) m.poisonous = true;
                    if (mOwn.rush != 0) this.minionGetRush(m);
                    m.updateReadyness();
                    this.minionGetSilenced(mOwn);
                    this.minionGetDestroyed(mOwn);
                    //if (m.Ready) this.evaluatePenality -= 35; //Todo: 不引入打分
                    break;
                }
            }
        }

        public void minionGetWindfurry(Minion m)
        {
            if (m.windfury) return;
            m.windfury = true;
            m.updateReadyness();
        }

        public void minionGetCharge(Minion m)
        {
            m.charge++;
            m.updateReadyness();
        }
        public void minionGetRush(Minion m)
        {
            if (m.cantAttack) return;
            m.rush = 1;
            m.updateReadyness();
            if (m.charge == 0 && m.playedThisTurn)
            {
                // Helpfunctions.Instance.ErrorLog("将赋予" + m.handcard.card.chnName + "突袭，因为不具备冲锋，本回合无法攻击！");
                m.cantAttackHeroes = true;
            }
        }
        public void minionLostCharge(Minion m)
        {
            m.charge--;
            m.updateReadyness();
        }



        public void minionGetTempBuff(Minion m, int tempAttack, int tempHp)
        {
            if (!m.silenced && m.name == CardDB.cardNameEN.lightspawn) return;
            if (tempAttack < 0 && -tempAttack > m.Angr)
            {
                tempAttack = -m.Angr;
            }
            m.tempAttack += tempAttack;
            m.Angr += tempAttack;
            if (m.isHero)
            {
                // 处理德鲁伊任务线
                switch (this.ownQuest.Id)
                {
                    case CardDB.cardIDEnum.SW_428:
                        this.ownQuest.questProgress += tempAttack;
                        if (this.ownQuest.questProgress >= this.ownQuest.maxProgress)
                        {
                            this.evaluatePenality += (this.ownQuest.questProgress - this.ownQuest.maxProgress) * 5;
                            this.ownQuest = new Questmanager.QuestItem() { Id = CardDB.cardIDEnum.SW_428t, questProgress = 0, maxProgress = 5 };
                            minionGetArmor(this.ownHero, 5);
                        }
                        break;
                    case CardDB.cardIDEnum.SW_428t:
                        this.ownQuest.questProgress += tempAttack;
                        if (this.ownQuest.questProgress >= this.ownQuest.maxProgress)
                        {
                            this.evaluatePenality += (this.ownQuest.questProgress - this.ownQuest.maxProgress) * 5;
                            this.ownQuest = new Questmanager.QuestItem() { Id = CardDB.cardIDEnum.SW_428t2, questProgress = 0, maxProgress = 6 };
                            drawACard(CardDB.cardIDEnum.None, true, false);
                            minionGetArmor(this.ownHero, 5);
                        }
                        break;
                    case CardDB.cardIDEnum.SW_428t2:
                        this.ownQuest.questProgress += tempAttack;
                        if (this.ownQuest.questProgress >= this.ownQuest.maxProgress)
                        {
                            drawACard(CardDB.cardIDEnum.SW_428t4, true, true);
                            this.ownQuest.Reset();
                        }
                        break;
                }
            }
            m.updateReadyness();
        }

        public void minionGetAdjacentBuff(Minion m, int angr, int vert)
        {
            if (!m.silenced && m.name == CardDB.cardNameEN.lightspawn) return;
            m.Angr += angr;
            m.AdjacentAngr += angr;
        }

        public void allMinionOfASideGetBuffed(bool own, int attackbuff, int hpbuff)
        {
            List<Minion> temp = (own) ? this.ownMinions : this.enemyMinions;
            foreach (Minion m in temp)
            {
                minionGetBuffed(m, attackbuff, hpbuff);
            }
        }

        public void minionGetBuffed(Minion m, int attackbuff, int hpbuff)
        {
            if (m.untouchable) return;
            if (attackbuff != 0) m.Angr = Math.Max(0, m.Angr + attackbuff);

            if (hpbuff != 0)
            {
                if (hpbuff >= 1)
                {
                    m.Hp = m.Hp + hpbuff;
                    m.maxHp = m.maxHp + hpbuff;
                }
                else
                {
                    //debuffing hp, lower only maxhp (unless maxhp < hp)
                    m.maxHp = m.maxHp + hpbuff;
                    if (m.maxHp < m.Hp)
                    {
                        m.Hp = m.maxHp;
                    }
                }
                m.wounded = (m.maxHp != m.Hp);
            }

            if (m.name == CardDB.cardNameEN.lightspawn && !m.silenced)//光耀之子
            {
                m.Angr = m.Hp;
            }
            if (m.name == CardDB.cardNameEN.saidanthescarlet && !m.silenced) //血色骑士赛丹
            {
                m.Angr += attackbuff * 2;
                m.Hp += hpbuff * 2;
            }
        }

        public void cthunGetBuffed(int attackbuff, int hpbuff, int tauntbuff)
        {
            this.anzOgOwnCThunAngrBonus += attackbuff;
            this.anzOgOwnCThunHpBonus += hpbuff;
            this.anzOgOwnCThunTaunt += tauntbuff;

            bool cthunonboard = false;
            foreach (Minion m in this.ownMinions)
            {
                if (m.name == CardDB.cardNameEN.cthun)
                {
                    this.minionGetBuffed(m, attackbuff, hpbuff);
                    if (tauntbuff > 0)
                    {
                        m.taunt = true;
                        this.anzOwnTaunt++;
                    }
                }
            }
        }

        public void minionLosesDivineShield(Minion m)
        {
            m.divineshild = false;
            if (m.own) this.tempTrigger.ownMinionLosesDivineShield++;
            else this.tempTrigger.enemyMinionLosesDivineShield++;
        }

        public void discardCards(int num, bool own)
        {
            if (own)
            {
                int anz = Math.Min(num, this.owncards.Count);
                if (anz < 1) return;
                int numDiscardedCards = anz;

                int cardValue = 0;
                int bestCardValue = -1;
                int bestCardPos = -1;
                int bestSecondCardValue = -1;
                int bestSecondCardPos = -1;
                int ratio = 100;
                List<Handmanager.Handcard> discardedCardsBonusList = new List<Handmanager.Handcard>();
                Handmanager.Handcard hc;
                CardDB.Card c;
                Dictionary<int, int> cardsValDict = new Dictionary<int, int>();
                for (int i = 0; i < this.owncards.Count; i++)
                {
                    hc = this.owncards[i];
                    c = hc.card;
                    switch (c.type)
                    {
                        case CardDB.cardtype.MOB:
                            cardValue = (c.Health + hc.addHp) * 2 + (c.Attack + hc.addattack) * 2 + c.rarity + hc.poweredUp * 2;
                            if (c.windfury) cardValue += c.Attack + hc.addattack;
                            if (c.tank) cardValue += 2;
                            if (c.Shield) cardValue += 2;
                            if (c.Charge) cardValue += 3;
                            if (c.Stealth) cardValue += 1;
                            if (c.isSpecialMinion) cardValue += 10;
                            switch (c.nameEN)
                            {
                                case CardDB.cardNameEN.direwolfalpha: if (this.ownMinions.Count > 2) cardValue += 10; break;
                                case CardDB.cardNameEN.flametonguetotem: if (this.ownMinions.Count > 2) cardValue += 10; break;
                                case CardDB.cardNameEN.stormwindchampion: if (this.ownMinions.Count > 2) cardValue += 10; break;
                                case CardDB.cardNameEN.raidleader: if (this.ownMinions.Count > 2) cardValue += 10; break;
                                case CardDB.cardNameEN.vessina: if (this.ownMinions.Count > 2) cardValue += 10; break;
                                case CardDB.cardNameEN.silverwaregolem: cardValue = (c.Health + hc.addHp) * 2 + c.rarity; break;
                                case CardDB.cardNameEN.clutchmotherzavas: cardValue = (c.Health + hc.addHp) * 2 + c.rarity; break;
                            }
                            break;
                        case CardDB.cardtype.WEAPON:
                            cardValue = c.Attack * c.Durability * 2;
                            if (c.battlecry || c.deathrattle) cardValue += 7;
                            break;
                        case CardDB.cardtype.SPELL:
                            cardValue = 15;
                            break;
                    }
                    if (hc.manacost > 1)
                    {
                        if (hc.manacost == this.mana) ratio = 80;
                        else ratio = 60;
                    }
                    cardsValDict.Add(hc.entity, cardValue * ratio / 100);
                    if (bestCardValue <= cardValue)
                    {
                        bestSecondCardValue = bestCardValue;
                        bestSecondCardPos = bestCardPos;
                        bestCardValue = cardValue;
                        bestCardPos = i;
                    }
                    else if (bestSecondCardValue <= cardValue)
                    {
                        bestSecondCardValue = cardValue;
                        bestSecondCardPos = i;
                    }
                }

                Handmanager.Handcard removedhc;
                int first = bestCardPos;
                int firstVal = bestCardValue;
                int second = bestSecondCardPos;
                int secondVal = bestSecondCardValue;
                int summPen = 0;
                if (bestSecondCardPos > first)
                {
                    first = bestSecondCardPos;
                    firstVal = bestSecondCardValue;
                    second = bestCardPos;
                    secondVal = bestCardValue;
                }
                for (int i = 0; i < numDiscardedCards; i++)
                {
                    if (this.owncards[i].card.sim_card != null)
                    {
                        // 弃牌效果在这里发生
                        this.owncards[i].card.sim_card.onHandCardRemoved(this, this.owncards[i]);
                    }
                }
                for (int i = 0; i < numDiscardedCards; i++)
                {
                    if (i > 1) break;
                    int cPos = first;
                    int cVal = firstVal;
                    if (i > 0)
                    {
                        cPos = second;
                        cVal = secondVal;
                    }
                    removedhc = this.owncards[cPos];
                    this.owncards.RemoveAt(cPos);
                    anz--;

                    if (removedhc.card.sim_card != null && removedhc.card.sim_card.onCardDicscard(this, removedhc, null, 0, true))
                    {
                        discardedCardsBonusList.Add(removedhc);
                        cVal = -6;
                    }
                    else this.owncarddraw--;
                    if (prozis.penman.cardDiscardDatabase.ContainsKey(removedhc.card.nameEN)) cVal = 0;
                    summPen += cVal;
                }

                if (anz > 0)
                {
                    for (int i = 0; i < anz; i++)
                    {
                        removedhc = this.owncards[i];
                        bestCardValue = cardsValDict[this.owncards[i].entity];
                        if (removedhc.card.sim_card.onCardDicscard(this, removedhc, null, 0, true))
                        {
                            discardedCardsBonusList.Add(removedhc);
                            bestCardValue = 0;
                        }
                        else this.owncarddraw--;
                        summPen += bestCardValue;
                    }
                    this.owncards.RemoveRange(0, anz);
                }

                if (this.ownQuest.Id != CardDB.cardIDEnum.None) this.ownQuest.trigger_WasDiscard(numDiscardedCards);


                int malchezaarsimpCount = 0;
                foreach (Minion m in this.ownMinions)
                {
                    if (m.Hp > 0 && !m.silenced)
                    {
                        if (m.name == CardDB.cardNameEN.malchezaarsimp) malchezaarsimpCount++;
                        m.handcard.card.sim_card.onCardDicscard(this, m.handcard, m, numDiscardedCards);
                    }
                }
                if (malchezaarsimpCount > 0) summPen = summPen / 6;
                //this.evaluatePenality += summPen; //Todo: 不引入打分


                foreach (Handmanager.Handcard dc in discardedCardsBonusList)
                {
                    dc.card.sim_card.onCardDicscard(this, dc, null, 0);
                    
                }
            }
            else
            {
                int anz = Math.Min(num, this.enemyAnzCards);
                if (anz < 1) return;
                this.enemycarddraw -= anz;
                this.enemyAnzCards -= anz;
            }
            this.triggerCardsChanged(own);
        }

        public int lethalMissing()
        {
            if (this.lethlMissing < 1000) return lethlMissing;
            lethlMissing = Ai.Instance.lethalMissing;
            if (lethlMissing > 5) return lethlMissing;
            int dmg = 0;
            if (this.anzEnemyTaunt == 0)
            {
                foreach (Minion m in this.ownMinions)
                {
                    if (!m.Ready || m.frozen) continue;
                    dmg += m.Angr;
                    if (m.windfury) dmg += m.Angr;
                }
            }
            else
            {
                List<Minion> om = new List<Minion>(this.ownMinions);
                List<Minion> omn = new List<Minion>();
                Minion bm = null;
                int tmp = 0;
                foreach (Minion d in this.enemyMinions)
                {
                    if (!d.taunt) continue;
                    bm = null;
                    foreach (Minion m in om)
                    {
                        if (!m.Ready || m.frozen) continue;
                        if (m.Angr < d.Hp)
                        {
                            omn.Add(m);
                            continue;
                        }
                        else
                        {
                            if (bm == null)
                            {
                                bm = m;
                                continue;
                            }
                            else
                            {
                                if (m.Angr < bm.Angr)
                                {
                                    omn.Add(bm);
                                    bm = m;
                                    continue;
                                }
                                else
                                {
                                    omn.Add(m);
                                    continue;
                                }
                            }
                        }
                    }
                    if (bm == null)
                    {
                        dmg = 0;
                        tmp = 0;
                        break;
                    }
                    tmp++;
                    om.Clear();
                    om.AddRange(omn);
                    omn.Clear();
                }
                if (tmp >= this.anzEnemyTaunt)
                {
                    foreach (Minion m in om)
                    {
                        dmg += m.Angr;
                        if (m.windfury) dmg += m.Angr;
                    }
                }
            }
            lethlMissing = this.enemyHero.Hp - dmg;
            return lethlMissing;
        }

        public bool nextTurnWin()  //Todo: 待Fix，没有考虑法术影响，比如火球术等 没有考虑敌方嘲讽等随从特效
        {
            return false;
            if (this.anzEnemyTaunt > 0) return false;

            int dmg = 0;
            foreach (Minion m in this.ownMinions)
            {
                if (m.frozen) continue;
                dmg += m.Angr;
                if (m.windfury) dmg += m.Angr;
            }
            if (this.enemyHero.Hp > dmg) return false;
            else return true;
        }

        /// <summary>
        /// 计算直伤伤害
        /// </summary>
        /// <param name="mana"></param>
        /// <param name="force">计算当前回合不考虑对手有嘲讽的情况</param>
        /// <param name="calNextTurn">计算下回合斩杀</param>
        /// <param name="maxCal">出牌上限</param>
        /// <param name="calMax">最多考虑的可能的出牌数量</param>
        /// <returns></returns>
        public int calDirectDmg(int mana, bool force, bool calNextTurn = false, int maxCal = 15, int calMax = 15)
        {
            if (mana < 0) mana = 0;
            if (mana > 10) mana = 10;

            int flag = 0;
            // 手上的幸运币/激活
            foreach(Handmanager.Handcard hc in this.owncards)
            {
                switch (hc.card.nameCN)
                {
                    case CardDB.cardNameCN.幸运币: mana++; break;
                    case CardDB.cardNameCN.激活: { mana++; if (hc.card.cardIDenum == CardDB.cardIDEnum.VAN_EX1_169) { mana++; flag |= 8; } break; }
                    case CardDB.cardNameCN.雷霆绽放: mana+=2; break;
                    case CardDB.cardNameCN.自然之力:
                        flag |= 1;
                        break;
                    case CardDB.cardNameCN.野蛮咆哮:
                        if ((flag & 2) == 1) flag |= 4;
                        flag |= 2;
                        break;
                }
            }

            // 01背包
            int[] cost = new int[100];
            int[] dmg = new int[100];
            int[][] dp = new int[100][];
            for (int i = 0; i < maxCal; i++)
            {
                dp[i] = new int[100];
            }
            int cnt = 1;
            if (this.ownAbilityReady || calNextTurn)
                switch (this.ownHeroAblility.card.nameCN)
                {
                    case CardDB.cardNameCN.恶魔之爪:
                    case CardDB.cardNameCN.变形:
                        if(this.anzEnemyTaunt == 0 && this.ownHero.numAttacksThisTurn == 0)
                        {
                            cost[cnt] = this.ownHeroAblility.getManaCost(this);
                            dmg[cnt] = 1;
                            cnt++;
                        }
                        break;
                    case CardDB.cardNameCN.恶魔之咬:
                    case CardDB.cardNameCN.恐怖变形:
                        if (this.anzEnemyTaunt == 0 && this.ownHero.numAttacksThisTurn == 0)
                        {
                            cost[cnt] = this.ownHeroAblility.getManaCost(this);
                            dmg[cnt] = 2;
                            cnt++;
                        }
                        break;
                    case CardDB.cardNameCN.火焰冲击:
                        cost[cnt] = this.ownHeroAblility.getManaCost(this);
                        dmg[cnt] = 1 + this.ownHeroPowerExtraDamage;
                        cnt++;
                        break;
                    case CardDB.cardNameCN.二级火焰冲击:
                    case CardDB.cardNameCN.心灵尖刺:
                    case CardDB.cardNameCN.稳固射击:
                        cost[cnt] = this.ownHeroAblility.getManaCost(this);
                        dmg[cnt] = 2 + this.ownHeroPowerExtraDamage;
                        cnt++;
                        break;
                    case CardDB.cardNameCN.弩炮射击:
                        cost[cnt] = this.ownHeroAblility.getManaCost(this);
                        dmg[cnt] = 3 + this.ownHeroPowerExtraDamage;
                        cnt++;
                        break;
                    case CardDB.cardNameCN.生命分流:
                        if (this.anzTamsin)
                        {
                            cost[cnt] = this.ownHeroAblility.getManaCost(this);
                            dmg[cnt] = 2 + this.ownHeroPowerExtraDamage;
                            cnt++;
                        }
                        break;
                }
            bool canAttack = false;
            int extra = 0;
            foreach (Minion m in this.ownMinions)
            {
                if (this.anzTamsin && m.handcard.card.nameCN == CardDB.cardNameCN.无证药剂师) extra++;
                if (m.Ready && !m.cantAttackHeroes) canAttack = true;
            }
            foreach (Handmanager.Handcard hc in this.owncards)
            {
                // 冲锋
                if (( (hc.card.Charge) || hc.card.Durability > 0  && this.ownWeapon.Durability == 0 || hc.card.nameCN == CardDB.cardNameCN.利爪德鲁伊) && (this.anzEnemyTaunt == 0 || force) && hc.addattack + hc.card.Attack > 0)
                {
                    cost[cnt] = hc.manacost;
                    dmg[cnt] = hc.addattack + hc.card.Attack;
                }
                // 法术直伤
                switch (hc.card.nameCN)
                {
                    case CardDB.cardNameCN.炎爆术:
                        dmg[cnt] += 10 + this.spellpower;
                        break;
                    case CardDB.cardNameCN.火球术:
                        dmg[cnt] += 6 + this.spellpower;
                        break;
                    case CardDB.cardNameCN.邪火药水:
                    case CardDB.cardNameCN.埃匹希斯冲击:
                    case CardDB.cardNameCN.心灵震爆:
                        dmg[cnt] += 5 + this.spellpower;
                        break;
                    case CardDB.cardNameCN.标记射击:
                    case CardDB.cardNameCN.废铁射击:
                    case CardDB.cardNameCN.深水炸弹:
                    case CardDB.cardNameCN.虚空碎片:
                    case CardDB.cardNameCN.冰枪术:
                    case CardDB.cardNameCN.横扫:
                    case CardDB.cardNameCN.灵魂之火:
                        dmg[cnt] += 4 + this.spellpower;
                        break;
                    case CardDB.cardNameCN.快速射击:
                    case CardDB.cardNameCN.影袭:
                    case CardDB.cardNameCN.诱饵射击:
                    case CardDB.cardNameCN.恶魔来袭:
                    case CardDB.cardNameCN.地狱烈焰:
                    case CardDB.cardNameCN.闪电箭:
                    case CardDB.cardNameCN.毒蛇神殿传送门:
                    case CardDB.cardNameCN.寒冰箭:
                    case CardDB.cardNameCN.杀戮命令:
                        dmg[cnt] += 3 + this.spellpower;
                        break;
                    case CardDB.cardNameCN.奉献:
                    case CardDB.cardNameCN.图腾重击:
                    case CardDB.cardNameCN.符文宝珠:
                    case CardDB.cardNameCN.末日灾祸:
                    case CardDB.cardNameCN.点燃:
                    case CardDB.cardNameCN.奥术射击:
                        dmg[cnt] += 2 + this.spellpower;
                        break;
                    case CardDB.cardNameCN.冰霜震击:
                    case CardDB.cardNameCN.火焰之雨:
                    case CardDB.cardNameCN.急速射击:
                    case CardDB.cardNameCN.击伤猎物:
                        dmg[cnt] += 1 + this.spellpower;
                        break;
                    case CardDB.cardNameCN.关门放狗:
                        dmg[cnt] += this.enemyMinions.Count;
                        break;
                    case CardDB.cardNameCN.瞄准射击:
                        dmg[cnt] += 3 + this.spellpower;
                        break;


                    // 战吼
                    case CardDB.cardNameCN.火眼莫德雷斯:
                        if (hc.poweredUp > 0)
                            dmg[cnt] += 10;
                        break;
                    case CardDB.cardNameCN.生命的缚誓者阿莱克丝塔萨:
                        dmg[cnt] += 8;
                        break;
                    case CardDB.cardNameCN.云雾王子:
                        if (hc.poweredUp > 0)
                            dmg[cnt] += 6;
                        break;
                    case CardDB.cardNameCN.遮天雨云:
                        if (hc.poweredUp > 0)
                            dmg[cnt] += 5;
                        break;
                    case CardDB.cardNameCN.小刀商贩:
                        if(this.ownHero.Hp > 4)
                            dmg[cnt] += 4;
                        break;
                    case CardDB.cardNameCN.马戏团医师:
                        if(hc.card.cardIDenum == CardDB.cardIDEnum.DMF_174t)
                            dmg[cnt] += 4;
                        break;
                    case CardDB.cardNameCN.旋岩虫:
                        if (hc.poweredUp > 0)
                            dmg[cnt] += 3;
                        break;
                    case CardDB.cardNameCN.渊狱惩击者:
                        dmg[cnt] += 3;
                        break;
                    case CardDB.cardNameCN.迦顿男爵:
                    case CardDB.cardNameCN.雾帆劫掠者:
                    case CardDB.cardNameCN.丛林守护者:
                        dmg[cnt] += 2;
                        break;
                    case CardDB.cardNameCN.南海岸酋长:
                        if (hc.poweredUp > 0)
                            dmg[cnt] += 2;
                        break;
                    case CardDB.cardNameCN.精灵弓箭手:
                        dmg[cnt] += 1;
                        break;
                    case CardDB.cardNameCN.暗影投弹手:
                        if (this.ownHero.Hp > 3)
                            dmg[cnt] += 3;
                        break;
                    case CardDB.cardNameCN.力量的代价:
                        if (canAttack)
                        {
                            dmg[cnt] += 4;
                            if (this.anzTamsinroame > 0 && hc.getManaCost(this) > 0)
                            {
                                dmg[cnt] += 4 * this.anzTamsinroame;
                            }
                        }
                        break;
                    case CardDB.cardNameCN.萌物来袭:
                        if (canAttack) dmg[cnt] += 1; 
                        break;
                    case CardDB.cardNameCN.灵魂炸弹:
                        if (this.anzTamsin)
                        {
                            dmg[cnt] += 4;
                            if (this.anzTamsinroame > 0 && hc.getManaCost(this) > 0)
                            {
                                dmg[cnt] += 4 * this.anzTamsinroame;
                            }
                        }
                        break;
                    case CardDB.cardNameCN.亡者复生:
                        if (this.anzTamsin) dmg[cnt] += 3; 
                        break;
                    case CardDB.cardNameCN.晶化师:
                        if (this.anzTamsin) dmg[cnt] += 5; 
                        break;
                    case CardDB.cardNameCN.烈焰小鬼:
                        if (this.anzTamsin) dmg[cnt] += 3; 
                        break;
                    case CardDB.cardNameCN.狗头人图书管理员:
                        if (this.anzTamsin) dmg[cnt] += 2; 
                        break;
                    case CardDB.cardNameCN.粗俗的矮劣魔:
                        if (this.anzTamsin) dmg[cnt] += 2; 
                        break;
                    default:
                        break;
                }
                // 走A模式
                if(this.ownHero.enchs.IndexOf("SCH_617e") > 0)
                {
                    dmg[cnt] += 2;
                }
                int ReadyCount = 0, murlocCount = 0;
                bool foundWind = false;
                foreach(Minion m in this.ownMinions)
                {
                    if( (m.Ready || calNextTurn) && !m.cantAttackHeroes && !m.frozen )
                    {
                        ReadyCount++;
                        if (m.handcard.card.race == CardDB.Race.MURLOC || m.handcard.card.race == CardDB.Race.ALL) murlocCount++;
                        if (m.windfury) foundWind = true;
                    }
                }
                // 加攻法术
                if(this.anzEnemyTaunt == 0 || force)
                {
                    switch (hc.card.nameCN)
                    {
                        case CardDB.cardNameCN.自然之力:
                            if(hc.card.cardIDenum == CardDB.cardIDEnum.VAN_EX1_571)
                            {
                                dmg[cnt] += 6;
                            }
                            break;
                        case CardDB.cardNameCN.铁肤古夫:
                            dmg[cnt] += 8;
                            break;
                        case CardDB.cardNameCN.爪击:
                        case CardDB.cardNameCN.飞扑:
                            dmg[cnt] += 2;
                            break;
                        case CardDB.cardNameCN.风暴打击:
                        case CardDB.cardNameCN.铁齿铜牙:
                            dmg[cnt] += 3;
                            break;
                        case CardDB.cardNameCN.月触项链:
                        case CardDB.cardNameCN.野性之怒:
                        case CardDB.cardNameCN.撕咬:
                            dmg[cnt] += 4;
                            break;
                        default:
                            break;
                    }
                    if (ReadyCount > 0)
                    {
                        switch (hc.card.nameCN)
                        {
                            case CardDB.cardNameCN.王者祝福:
                                dmg[cnt] += 4;
                                if(foundWind) dmg[cnt] += 4;
                                break;
                            case CardDB.cardNameCN.暗鳞先知:
                                dmg[cnt] += murlocCount;
                                break;
                            case CardDB.cardNameCN.鱼人领军:
                            case CardDB.cardNameCN.鱼勇可贾:
                            case CardDB.cardNameCN.鱼人恩典:
                                dmg[cnt] += murlocCount * 2;
                                break;
                            case CardDB.cardNameCN.塞纳留斯:
                                dmg[cnt] += ReadyCount * 2;
                                if (foundWind) dmg[cnt] += 2;
                                break;
                            case CardDB.cardNameCN.野蛮咆哮:
                                dmg[cnt] += (ReadyCount + 1) * 2;
                                if (foundWind) dmg[cnt] += 2;
                                break;
                            case CardDB.cardNameCN.玉莲印记:
                            case CardDB.cardNameCN.野性之力:
                                dmg[cnt] += ReadyCount * 1;
                                if (foundWind) dmg[cnt] += 1;
                                break;
                        }
                    }
                }
                if (extra > 0 && hc.card.type == CardDB.cardtype.MOB)
                {
                    dmg[cnt] += 5 * extra;
                }
                if (dmg[cnt] > 0)
                {
                    cost[cnt] = hc.getManaCost(this);
                    cnt++;
                }
            }
            int nextTurnMana = mana;
            // 虚触侍从
            if(this.anzOldWoman > 0 && !calNextTurn)
            {
                for(int i = 0; i < maxCal; i++)
                {
                    if (dmg[i] > 0) dmg[i] += this.anzOldWoman;
                }
            }

            // 计算对手最多使用 calMax 张牌时的斩杀线，需要用多维背包计算
            if (calMax != 15)
            {
                if (maxCal > 40) maxCal = 40;
                if (maxCal < cnt) maxCal = cnt + 1;

                int[][][] muitiDp = new int[45][][];
                for (int i = 0; i < maxCal ; i++)
                {
                    muitiDp[i] = new int[45][];
                    for (int j = 0; j <= nextTurnMana + 5; j++)
                    {
                        muitiDp[i][j] = new int[45];
                    }
                }
                // i 张牌
                for (int i = 1; i <= cnt; i++)
                    // 费用 j
                    for (int j = 0; j <= nextTurnMana; j++)
                        // 总手牌数
                        for (int k = 0; k <= calMax; k++)
                        {
                            muitiDp[i][j][k] = muitiDp[i - 1][j][k];
                            if (j >= cost[i] && k >= 1)
                            {
                                var tmp = dmg[i] + muitiDp[i - 1][j - cost[i]][k - 1];
                                if (tmp > muitiDp[i][j][k]) muitiDp[i][j][k] = tmp;
                            }
                        }
                int enemyMaxDmg = muitiDp[cnt][nextTurnMana][calMax];
                // 自然之力咆哮
                if ((this.anzEnemyTaunt == 0 || force) && mana >= 9 && flag == 3 && enemyMaxDmg < 14 + this.ownMinions.Count * 2) enemyMaxDmg = 14 + this.ownMinions.Count * 2;
                // 自然之力双咆哮
                if ((this.anzEnemyTaunt == 0 || force) && mana >= 12 && flag == 15 && enemyMaxDmg < 20 + this.ownMinions.Count * 4) enemyMaxDmg = 20 + this.ownMinions.Count * 4;
                return enemyMaxDmg;
            }

            // 第 i 张牌
            for (int i = 1; i <= cnt; i++)
            {
                // 剩余费用
                for (int j = 1; j <= nextTurnMana; j++)
                {
                    // 打不出去
                    if (cost[i] > j)
                    {
                        dp[i][j] = dp[i - 1][j];
                    }
                    else
                    {
                        // 能出牌的情况取其中最大伤害
                        dp[i][j] = Math.Max(dp[i - 1][j - cost[i]] + dmg[i], dp[i - 1][j]);
                    }
                }
            }
            int maxDmg = dp[cnt][nextTurnMana];
            // 自然之力咆哮
            if ((this.anzEnemyTaunt == 0 || force) && mana >= 9 && flag == 3 && maxDmg < 14 + this.ownMinions.Count * 2 ) maxDmg = 14 + this.ownMinions.Count * 2;
            // 自然之力双咆哮
            if ((this.anzEnemyTaunt == 0 || force) && mana >= 12 && flag == 15 && maxDmg < 20 + this.ownMinions.Count * 4) maxDmg = 20 + this.ownMinions.Count * 4;
            return maxDmg;
        }

        public void minionSetAngrToX(Minion m, int newAngr)
        {
            if (!m.silenced && m.name == CardDB.cardNameEN.lightspawn) return;
            m.Angr = newAngr;
            m.tempAttack = 0;
            this.minionGetOrEraseAllAreaBuffs(m, true);
        }
        public void minionSetLifetoX(Minion m, int newHp)
        {
            minionGetOrEraseAllAreaBuffs(m, false);
            m.Hp = newHp;
            m.maxHp = newHp;
            if (m.wounded && !m.silenced) m.handcard.card.sim_card.onEnrageStop(this, m);
            m.wounded = false;
            minionGetOrEraseAllAreaBuffs(m, true);
        }

        public void minionSetAngrToHP(Minion m)
        {
            m.Angr = m.Hp;
            m.tempAttack = 0;
            this.minionGetOrEraseAllAreaBuffs(m, true);

        }
        public void minionSwapAngrAndHP(Minion m)
        {

            bool woundedbef = m.wounded;
            int temp = m.Angr;
            m.Angr = m.Hp;
            m.Hp = temp;
            m.maxHp = temp;
            m.wounded = false;
            if (woundedbef) m.handcard.card.sim_card.onEnrageStop(this, m);
            if (m.Hp <= 0)
            {
                if (m.own) this.tempTrigger.ownMinionsDied++;
                else this.tempTrigger.enemyMinionsDied++;
            }

            this.minionGetOrEraseAllAreaBuffs(m, true);
        }
		// 随从获得伤害或治疗
        public void minionGetDamageOrHeal(Minion m, int dmgOrHeal, bool dontDmgLoss = false)
        {
            if (m.Hp > 0) m.getDamageOrHeal(dmgOrHeal, this, false, dontDmgLoss);
        }


		// 一方所有随从受到伤害
        public void allMinionOfASideGetDamage(bool own, int damages, bool frozen = false)
        {
            List<Minion> temp = (own) ? this.ownMinions : this.enemyMinions;
            foreach (Minion m in temp)
            {
                if (frozen) minionGetFrozen(m);
                minionGetDamageOrHeal(m, damages, true);
            }
            this.updateBoards();
        }
		// 一方的所有角色都会受到伤害
        public void allCharsOfASideGetDamage(bool own, int damages)
        {
            //ALL CHARS get same dmg
            List<Minion> temp = (own) ? this.ownMinions : this.enemyMinions;
            foreach (Minion m in temp)
            {
                minionGetDamageOrHeal(m, damages, true);
            }

            this.minionGetDamageOrHeal(own ? this.ownHero : this.enemyHero, damages);
        }
		// 一方的所有角色都会受到随机伤害
        public void allCharsOfASideGetRandomDamage(bool ownSide, int times)
        {
            //Deal damage randomly split among all enemies.

            if ((!ownSide && this.enemyHero.Hp + this.enemyHero.armor <= times) || (ownSide && this.ownHero.Hp + this.ownHero.armor <= times))
            {
                if (!ownSide)
                {
                    int dmg = this.enemyHero.Hp + this.enemyHero.armor;  //optimistic
                    if (this.enemyMinions.Count > 2) dmg--;
                    times = times - dmg;
                    if (this.anzEnemyAnimatedArmor > 0)
                    {
                        for (; dmg > 0; dmg--) this.minionGetDamageOrHeal(this.enemyHero, 1);
                    }
                    else this.minionGetDamageOrHeal(this.enemyHero, dmg);
                }
                else
                {
                    int dmg = this.ownHero.Hp + this.ownHero.armor - 1;
                    times = times - dmg;
                    if (this.anzOwnAnimatedArmor > 0)
                    {
                        for (; dmg > 0; dmg--) this.minionGetDamageOrHeal(this.ownHero, 1);
                    }
                    else this.minionGetDamageOrHeal(this.ownHero, dmg);
                }
            }

            List<Minion> temp = (ownSide) ? new List<Minion>(this.ownMinions) : new List<Minion>(this.enemyMinions);
            temp.Sort((a, b) => { int tmp = a.Hp.CompareTo(b.Hp); return tmp == 0 ? a.Angr - b.Angr : tmp; });

            int border = 1;
            for (int pos = 0; pos < temp.Count; pos++)
            {
                Minion m = temp[pos];
                if (m.divineshild)
                {
                    m.divineshild = false;
                    times--;
                    if (times < 1) break;
                }
                if (m.Hp > border)
                {
                    int dmg = Math.Min(m.Hp - border, times);
                    times -= dmg;
                    this.minionGetDamageOrHeal(m, dmg);
                }
                if (times < 1) break;
            }
            if (times > 0)
            {
                int dmg = times;
                if (!ownSide)
                {
                    if (this.anzEnemyAnimatedArmor > 0)
                    {
                        for (; dmg > 0; dmg--) this.minionGetDamageOrHeal(this.enemyHero, 1);
                    }
                    else this.minionGetDamageOrHeal(this.enemyHero, dmg);
                }
                else
                {
                    if (this.anzOwnAnimatedArmor > 0)
                    {
                        for (; dmg > 0; dmg--) this.minionGetDamageOrHeal(this.ownHero, 1);
                    }
                    else this.minionGetDamageOrHeal(this.ownHero, dmg);
                }
            }
        }
		// 所有角色都会受到伤害
        public void allCharsGetDamage(int damages, int exceptID = -1)
        {
            foreach (Minion m in this.ownMinions)
            {
                if (m.entitiyID != exceptID) minionGetDamageOrHeal(m, damages, true);
            }
            foreach (Minion m in this.enemyMinions)
            {
                if (m.entitiyID != exceptID) minionGetDamageOrHeal(m, damages, true);
            }
            minionGetDamageOrHeal(this.ownHero, damages);
            minionGetDamageOrHeal(this.enemyHero, damages);
        }
		// 所有随从受到伤害
        public void allMinionsGetDamage(int damages, int exceptID = -1)
        {
            foreach (Minion m in this.ownMinions.ToArray())
            {
                if (m.entitiyID != exceptID) minionGetDamageOrHeal(m, damages, true);
            }
            foreach (Minion m in this.enemyMinions.ToArray())
            {
                if (m.entitiyID != exceptID) minionGetDamageOrHeal(m, damages, true);
            }
        }


        public void setNewHeroPower(CardDB.cardIDEnum newHeroPower, bool own)
        {
            if (own)
            {
                this.ownHeroAblility.card = CardDB.Instance.getCardDataFromID(newHeroPower);
                this.ownAbilityReady = true;
            }
            else
            {
                this.enemyHeroAblility.card = CardDB.Instance.getCardDataFromID(newHeroPower);
                this.enemyAbilityReady = true;
            }
        }


        private void getHandcardsByType(List<Handmanager.Handcard> cards, GAME_TAGs tag, TAG_RACE race = TAG_RACE.INVALID)
        {
            switch (tag)
            {
                case GAME_TAGs.None:
                    foreach (Handmanager.Handcard hc in cards) hc.extraParam3 = true;
                    break;
                case GAME_TAGs.Spell:
                    foreach (Handmanager.Handcard hc in cards) if (hc.card.type == CardDB.cardtype.SPELL) hc.extraParam3 = true;
                    break;
                case GAME_TAGs.SECRET:
                    foreach (Handmanager.Handcard hc in cards) if (hc.card.Secret) hc.extraParam3 = true;
                    break;
                case GAME_TAGs.Mob:
                    foreach (Handmanager.Handcard hc in cards) if (hc.card.type == CardDB.cardtype.MOB) hc.extraParam3 = true;
                    break;
                case GAME_TAGs.CARDRACE:
                    foreach (Handmanager.Handcard hc in cards)
                    {
                        if (hc.card.type == CardDB.cardtype.MOB)
                        {
                            if (race == TAG_RACE.INVALID) hc.extraParam3 = true;
                            else if (hc.card.race == (CardDB.Race)race) hc.extraParam3 = true;
                        }
                    }
                    break;
                case GAME_TAGs.TAUNT:
                    foreach (Handmanager.Handcard hc in cards) if (hc.card.tank) hc.extraParam3 = true;
                    break;
                case GAME_TAGs.COMBO:
                    foreach (Handmanager.Handcard hc in cards) if (hc.card.Combo) hc.extraParam3 = true;
                    break;
                case GAME_TAGs.DIVINE_SHIELD:
                    foreach (Handmanager.Handcard hc in cards) if (hc.card.Shield) hc.extraParam3 = true;
                    break;
                case GAME_TAGs.ENRAGED:
                    foreach (Handmanager.Handcard hc in cards) if (hc.card.Enrage) hc.extraParam3 = true;
                    break;
                case GAME_TAGs.LIFESTEAL:
                    foreach (Handmanager.Handcard hc in cards) if (hc.card.lifesteal) hc.extraParam3 = true;
                    break;
                case GAME_TAGs.OVERLOAD:
                    foreach (Handmanager.Handcard hc in cards) if (hc.card.overload > 0) hc.extraParam3 = true;
                    break;
                case GAME_TAGs.CLASS:
                    foreach (Handmanager.Handcard hc in cards) if (hc.card.Class == (int)ownHeroStartClass) hc.extraParam3 = true;
                    break;
                case GAME_TAGs.Weapon:
                    foreach (Handmanager.Handcard hc in cards) if (hc.card.type == CardDB.cardtype.WEAPON) hc.extraParam3 = true;
                    break;
            }
        }

        public int calTotalAngr()
        {
            if (this.totalAngr == -1)
            {
                this.totalAngr = 0;
                for (int i = 0; i < this.ownMinions.Count; i++)
                {
                    if (this.ownMinions[i].Ready && !this.ownMinions[i].cantAttackHeroes)
                    {
                        this.totalAngr += this.ownMinions[i].Angr;
                        // 判断军官风怒
                        if (this.ownMinions[i].windfury ||( i > 0 && this.ownMinions[i - 1].handcard.card.nameCN == CardDB.cardNameCN.战场军官 && !this.ownMinions[i - 1].silenced || i < this.ownMinions.Count - 1 && this.ownMinions[i + 1].handcard.card.nameCN == CardDB.cardNameCN.战场军官 && !this.ownMinions[i + 1].silenced) )
                        {
                            if(this.ownMinions[i].numAttacksThisTurn == 0)
                                this.totalAngr += this.ownMinions[i].Angr;
                        }
                    }
                }
                if(this.ownHero.Ready)
                    this.totalAngr += this.ownHero.Angr;
            }
            return this.totalAngr;
        }

        public int calEnemyTotalAngr()
        {
            if (this.enemyTotalAngr == -1)
            {
                this.enemyTotalAngr = this.enemyWeapon.Angr;
                for (int i = 0; i < this.enemyMinions.Count; i++)
                {
                    if (this.enemyMinions[i].cantAttack || this.enemyMinions[i].frozen) continue;
                    this.enemyTotalAngr += this.enemyMinions[i].Angr;
                    // 判断军官风怒
                    if (this.enemyMinions[i].windfury || (i > 0 && this.enemyMinions[i - 1].handcard.card.nameCN == CardDB.cardNameCN.战场军官 && !this.enemyMinions[i - 1].silenced || i < this.enemyMinions.Count - 1 && this.enemyMinions[i + 1].handcard.card.nameCN == CardDB.cardNameCN.战场军官 && !this.enemyMinions[i + 1].silenced))
                    {
                        this.enemyTotalAngr += this.enemyMinions[i].Angr;
                    }                    
                }
                for (int i = 0; i < this.ownMinions.Count; i++)
                {
                    if (this.ownMinions[i].taunt) this.enemyTotalAngr -= this.ownMinions[i].Hp;
                }
                this.enemyTotalAngr = this.enemyTotalAngr < 0 ? 0 : this.enemyTotalAngr;
            }
            return this.enemyTotalAngr;
        }

        public Handmanager.Handcard searchRandomMinionInHand(List<Handmanager.Handcard> cards, searchmode mode, GAME_TAGs tag = GAME_TAGs.None, TAG_RACE race = TAG_RACE.INVALID)
        {
            Handmanager.Handcard ret = null;
            double value = 0;
            switch (mode)
            {
                case searchmode.searchLowestHP: value = 1000; break;
                case searchmode.searchHighestHP: value = -1; break;
                case searchmode.searchLowestAttack: value = 1000; break;
                case searchmode.searchHighestAttack: value = -1; break;
                case searchmode.searchHighAttackLowHP: value = -1; break;
                case searchmode.searchHighHPLowAttack: value = -1; break;
                case searchmode.searchLowestCost: value = 1000; break;
                case searchmode.searchHighesCost: value = -1; break;
            }

            getHandcardsByType(cards, tag, race);
            foreach (Handmanager.Handcard hc in cards)
            {
                if (!hc.extraParam3) continue;
                hc.extraParam3 = false;

                switch (mode)
                {
                    case searchmode.searchLowestHP:
                        if ((hc.card.Health + hc.addHp) < value)
                        {
                            ret = hc;
                            value = (hc.card.Health + hc.addHp);
                        }
                        break;
                    case searchmode.searchHighestHP:
                        if ((hc.card.Health + hc.addHp) > value)
                        {
                            ret = hc;
                            value = (hc.card.Health + hc.addHp);
                        }
                        break;
                    case searchmode.searchLowestAttack:
                        if ((hc.card.Attack + hc.addattack) < value)
                        {
                            ret = hc;
                            value = (hc.card.Attack + hc.addattack);
                        }
                        break;
                    case searchmode.searchHighestAttack:
                        if ((hc.card.Attack + hc.addattack) > value)
                        {
                            ret = hc;
                            value = (hc.card.Attack + hc.addattack);
                        }
                        break;
                    case searchmode.searchHighAttackLowHP:
                        if ((hc.card.Attack + hc.addattack) / (hc.card.Health + hc.addHp) > value)
                        {
                            ret = hc;
                            value = (hc.card.Attack + hc.addattack) / (hc.card.Health + hc.addHp);
                        }
                        break;
                    case searchmode.searchHighHPLowAttack:
                        if ((hc.card.Health + hc.addHp) / (hc.card.Attack + hc.addattack) > value)
                        {
                            ret = hc;
                            value = (hc.card.Health + hc.addHp) / (hc.card.Attack + hc.addattack);
                        }
                        break;
                    case searchmode.searchLowestCost:
                        if (hc.manacost < value)
                        {
                            ret = hc;
                            value = hc.manacost;
                        }
                        break;
                    case searchmode.searchHighesCost:
                        if (hc.manacost > value)
                        {
                            ret = hc;
                            value = hc.manacost;
                        }
                        break;
                }
            }
            return ret;
        }

        public Minion searchRandomMinion(List<Minion> minions, searchmode mode)
        {
            if (minions.Count == 0) return null;
            Minion ret = null;
            double value = 0;
            switch (mode)
            {
                case searchmode.searchLowestHP: value = 1000; break;
                case searchmode.searchHighestHP: value = -1; break;
                case searchmode.searchLowestAttack: value = 1000; break;
                case searchmode.searchHighestAttack: value = -1; break;
                case searchmode.searchHighAttackLowHP: value = -1; break;
                case searchmode.searchHighHPLowAttack: value = -1; break;
                case searchmode.searchLowestCost: value = 1000; break;
                case searchmode.searchHighesCost: value = -1; break;
            }

            foreach (Minion m in minions)
            {
                if (m.Hp <= 0) continue;

                switch (mode)
                {
                    case searchmode.searchLowestHP:
                        if (m.Hp < value)
                        {
                            ret = m;
                            value = m.Hp;
                        }
                        continue;
                    case searchmode.searchHighestHP:
                        if (m.Hp > value)
                        {
                            ret = m;
                            value = m.Hp;
                        }
                        continue;
                    case searchmode.searchLowestAttack:
                        if (m.Angr < value)
                        {
                            ret = m;
                            value = m.Angr;
                        }
                        continue;
                    case searchmode.searchHighestAttack:
                        if (m.Angr > value)
                        {
                            ret = m;
                            value = m.Angr;
                        }
                        continue;
                    case searchmode.searchHighAttackLowHP:
                        if (m.Angr / m.Hp > value)
                        {
                            ret = m;
                            value = m.Angr / m.Hp;
                        }
                        continue;
                    case searchmode.searchHighHPLowAttack:
                        if (m.Angr == 0)
                        {
                            if (ret == null) ret = m;
                            continue;
                        }
                        if (m.Hp / m.Angr > value)
                        {
                            ret = m;
                            value = m.Hp / m.Angr;
                        }
                        continue;
                    case searchmode.searchLowestCost:
                        if (m.handcard.card.cost < value)
                        {
                            ret = m;
                            value = m.handcard.card.cost;
                        }
                        continue;
                    case searchmode.searchHighesCost:
                        if (m.handcard.card.cost > value)
                        {
                            ret = m;
                            value = m.handcard.card.cost;
                        }
                        continue;
                }
            }
            return ret;
        }

        public Minion searchRandomMinionByMaxHP(List<Minion> minions, searchmode mode, int maxHP)
        {
            //optimistic search

            if (maxHP < 1) return null;
            if (minions.Count == 0) return null;

            Minion ret = null;

            double value = 0;
            int retVal = 0;
            foreach (Minion m in minions)
            {
                if (m.Hp > maxHP) continue;

                switch (mode)
                {
                    case searchmode.searchHighestHP:
                        if (m.Hp > value)
                        {
                            ret = m;
                            value = m.Hp;
                            retVal = m.Angr;
                        }
                        else if (m.Hp == value && retVal < m.Angr) ret = m;
                        continue;
                    case searchmode.searchLowestAttack:
                        if (m.Angr < value)
                        {
                            ret = m;
                            value = m.Angr;
                            retVal = m.Hp;
                        }
                        else if (m.Angr == value && retVal < m.Hp) ret = m;
                        continue;
                    case searchmode.searchHighestAttack:
                        if (m.Angr > value)
                        {
                            ret = m;
                            value = m.Angr;
                            retVal = m.Hp;
                        }
                        else if (m.Angr == value && retVal < m.Hp) ret = m;
                        continue;
                    case searchmode.searchHighAttackLowHP:
                        if (m.Angr / m.Hp > value)
                        {
                            ret = m;
                            value = m.Angr / m.Hp;
                            retVal = m.Hp;
                        }
                        else if (m.Angr / m.Hp == value && retVal < m.Hp) ret = m;
                        continue;
                    case searchmode.searchHighHPLowAttack:
                        if (m.Angr == 0)
                        {
                            if (ret == null) ret = m;
                            continue;
                        }
                        if (m.Hp / m.Angr > value)
                        {
                            ret = m;
                            value = m.Hp / m.Angr;
                            retVal = m.Hp;
                        }
                        else if (m.Angr / m.Hp == value && retVal < m.Hp) ret = m;
                        continue;
                    default: //==searchHighestHP
                        if (m.Hp > value)
                        {
                            ret = m;
                            value = m.Hp;
                            retVal = m.Angr;
                        }
                        else if (m.Hp == value && retVal < m.Angr) ret = m;
                        continue;
                }
            }
            if (ret != null && ret.Hp <= 0) return null;
            return ret;
        }

        public CardDB.Card getNextJadeGolem(bool own)
        {
            int tmp = 0;
            if (own)
            {
                tmp = 1 + anzOwnJadeGolem;
                anzOwnJadeGolem++;
            }
            else
            {
                tmp = 1 + anzEnemyJadeGolem;
                anzEnemyJadeGolem++;
            }
            switch (tmp)
            {
                case 1: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t01);
                case 2: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t02);
                case 3: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t03);
                case 4: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t04);
                case 5: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t05);
                case 6: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t06);
                case 7: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t07);
                case 8: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t08);
                case 9: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t09);
                case 10: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t10);
                case 11: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t11);
                case 12: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t12);
                case 13: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t13);
                case 14: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t14);
                case 15: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t15);
                case 16: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t16);
                case 17: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t17);
                case 18: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t18);
                case 19: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t19);
                case 20: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t20);
                case 21: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t21);
                case 22: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t22);
                case 23: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t23);
                case 24: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t24);
                case 25: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t25);
                case 26: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t26);
                case 27: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t27);
                case 28: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t28);
                case 29: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t29);
                case 30: return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t30);
            }
            return CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.CFM_712_t01);
        }

        public void debugMinions()
        {
            Helpfunctions.Instance.logg("我方随从################");

            foreach (Minion m in this.ownMinions)
            {
                Helpfunctions.Instance.logg(m.handcard.card.nameCN.ToString() + "(" + m.Angr + "," + m.Hp + "/" + m.maxHp + ")");
            }

            Helpfunctions.Instance.logg("敌方随从############");
            foreach (Minion m in this.enemyMinions)
            {
                Helpfunctions.Instance.logg(m.handcard.card.nameCN.ToString() + "(" + m.Angr + "," + m.Hp + "/" + m.maxHp + ")");
            }
        }

        public void printBoard()
        {
            Helpfunctions.Instance.logg("board/hash/turn: " + value + "  /  " + this.hashcode + "  /  " + this.turnCounter + " ++++++++++++++++++++++");
            Helpfunctions.Instance.logg("惩罚 " + this.evaluatePenality);
            Helpfunctions.Instance.logg("法力水晶 " + this.mana + "/" + this.ownMaxMana);
            Helpfunctions.Instance.logg("已使用手牌数: " + this.cardsPlayedThisTurn + " 剩余手牌: " + this.owncards.Count + " 敌方手牌: " + this.enemyAnzCards);

            Helpfunctions.Instance.logg("我方英雄: ");
            Helpfunctions.Instance.logg("血量: " + this.ownHero.Hp + " + " + this.ownHero.armor);
            Helpfunctions.Instance.logg("攻击力: " + this.ownHero.Angr);
            Helpfunctions.Instance.logg("武器: " + this.ownWeapon.Angr + " " + this.ownWeapon.Durability + " " + this.ownWeapon.card.nameCN.ToString() + " " + this.ownWeapon.card.cardIDenum + " " + (this.ownWeapon.poisonous ? "剧毒" : "无剧毒buff") + " " + (this.ownWeapon.lifesteal ? "吸血" : "无吸血buff"));
            Helpfunctions.Instance.logg("冻结状态: " + this.ownHero.frozen + " ");
            Helpfunctions.Instance.logg("敌方英雄血量: " + this.enemyHero.Hp + " + " + this.enemyHero.armor + ((this.enemyHero.immune) ? " immune" : ""));

            if (this.enemySecretCount >= 1) Helpfunctions.Instance.logg("enemySecrets: " + Probabilitymaker.Instance.getEnemySecretData(this.enemySecretList));
            foreach (Action a in this.playactions)
            {
                a.print();
            }
            Helpfunctions.Instance.logg("我方随从################");

            foreach (Minion m in this.ownMinions)
            {
                Helpfunctions.Instance.logg(m.handcard.card.nameCN.ToString() + "(" + m.Angr + "," + m.Hp + "/" + m.maxHp + ")" + m.zonepos + "号位 ID：" + m.entitiyID);
            }


            if (this.enemyMinions.Count > 0)
            {
                Helpfunctions.Instance.logg("敌方随从################");

                foreach (Minion m in this.enemyMinions)
                {
                    Helpfunctions.Instance.logg(m.handcard.card.nameCN.ToString() + "(" + m.Angr + "," + m.Hp + "/" + m.maxHp + ")" + m.zonepos + "号位 ID：" + m.entitiyID);
                }
            }

            if (this.diedMinions.Count > 0)
            {
                Helpfunctions.Instance.logg("死亡随从############");
                foreach (GraveYardItem m in this.diedMinions)
                {
                    Helpfunctions.Instance.logg("拥有者, entity, cardid: " + m.own + ", " + m.entityId + ", " + m.cardid);
                }
            }

            Helpfunctions.Instance.logg("我方手牌: ");
            foreach (Handmanager.Handcard hc in this.owncards)
            {
                Helpfunctions.Instance.logg("pos " + hc.position + " " + hc.card.nameCN.ToString() + "(费用：" + hc.manacost + "；" + hc.addattack + hc.card.Attack + "/" + +hc.addHp + hc.card.Health + ") elemPoweredUp" + hc.poweredUp + " " + hc.card.cardIDenum);
            }
            Helpfunctions.Instance.logg("+++++++ printBoard end +++++++++");

            Helpfunctions.Instance.logg("");
        }


        public string printBoardString()
        {
            string retval = "Turn : board\t" + this.turnCounter + ":" + ((this.value < -2000000) ? "." : this.value.ToString());
            retval += "\r\n" + "pIdHistory\t";
            foreach (int pId in this.pIdHistory) retval += pId + " ";
            retval += "\r\n" + ("pen\t" + this.evaluatePenality);
            retval += "\r\n" + ("mana\t" + this.mana + "/" + this.ownMaxMana);
            retval += "\r\n" + ("cardsplayed : handsize : enemyhand\t" + this.cardsPlayedThisTurn + ":" + this.owncards.Count + ":" + this.enemyAnzCards);
            retval += "\r\n" + ("Hp : armor : Atk ownhero\t" + this.ownHero.Hp + ":" + this.ownHero.armor + ":" + this.ownHero.Angr + ((this.ownHero.immune) ? ":immune" : ""));
            retval += "\r\n" + ("Atk : Dur : Name : IDe : poison ownWeapon\t" + this.ownWeapon.Angr + " " + this.ownWeapon.Durability + " " + this.ownWeapon.name + " " + this.ownWeapon.card.cardIDenum + " " + (this.ownWeapon.poisonous ? 1 : 0) + " " + (this.ownWeapon.lifesteal ? 1 : 0));
            retval += "\r\n" + ("ownHero.frozen\t" + this.ownHero.frozen);
            retval += "\r\n" + ("Hp : armor enemyhero\t" + this.enemyHero.Hp + ":" + this.enemyHero.armor + ((this.enemyHero.immune) ? ":immune" : ""));
            retval += "\r\n" + ("Atk : Dur : Name : IDe : poison enemyWeapon\t" + this.enemyWeapon.Angr + " " + this.enemyWeapon.Durability + " " + this.enemyWeapon.name + " " + this.enemyWeapon.card.cardIDenum + " " + (this.enemyWeapon.poisonous ? 1 : 0) + " " + (this.enemyWeapon.lifesteal ? 1 : 0));
            retval += "\r\n" + ("carddraw own:enemy\t" + this.owncarddraw + ":" + this.enemycarddraw);

            if (this.enemySecretCount > 0) retval += "\r\n" + ("enemySecrets\t" + Probabilitymaker.Instance.getEnemySecretData(this.enemySecretList));
            if (this.ownSecretsIDList.Count > 0)
            {
                retval += "\r\n" + ("ownSecrets\t");
                foreach (CardDB.cardIDEnum s in this.ownSecretsIDList)
                {
                    retval += " " + CardDB.Instance.getCardDataFromID(s).nameEN;
                }
            }

            for (int i = 0; i < this.playactions.Count; i++) retval += "\r\n" + i + " action\t" + this.playactions[i].printString();
            retval += "\r\n" + ("OWN MINIONS################\t" + this.ownMinions.Count);

            for (int i = 0; i < this.ownMinions.Count; i++)
            {
                Minion m = this.ownMinions[i];
                retval += "\r\n" + (i + 1) + " OWN MINION\t" + m.zonepos + " " + m.entitiyID + ":" + m.name + " " + m.Angr + " " + m.Hp;
            }

            if (this.enemyMinions.Count > 0)
            {
                retval += "\r\n" + ("ENEMY MINIONS############\t" + this.enemyMinions.Count);
                for (int i = 0; i < this.enemyMinions.Count; i++)
                {
                    Minion m = this.enemyMinions[i];
                    retval += "\r\n" + (i + 1) + " ENEMY MINION\t" + m.zonepos + " " + m.entitiyID + ":" + m.name + " " + m.Angr + " " + m.Hp;
                }
            }

            if (this.diedMinions.Count > 0)
            {
                retval += "\r\n" + ("DIED MINIONS############\t");
                for (int i = 0; i < this.diedMinions.Count; i++)
                {
                    GraveYardItem m = this.diedMinions[i];
                    retval += "\r\n" + i + (" own : entity : cardid\t" + (m.own ? "own" : "en") + " " + m.entityId + " " + m.cardid);
                }
            }

            retval += "\r\nOwn Handcards\t\r\n";
            for (int i = 0; i < this.owncards.Count; i++)
            {
                Handmanager.Handcard hc = this.owncards[i];
                retval += "\r\n" + (i + 1) + " CARD\t" + (hc.position + " " + hc.entity + ":" + hc.card.nameEN + " " + hc.manacost + " " + hc.card.cardIDenum + " " + hc.addattack + " " + hc.addHp + " " + hc.poweredUp + "\r\n");
            }
            retval += ("Enemy Handcards count\t" + this.enemyAnzCards + "\r\n");

            return retval;
        }

        public void printBoardDebug()
        {
            Helpfunctions.Instance.logg("hero " + this.ownHero.Hp + " " + this.ownHero.armor + " " + this.ownHero.entitiyID);
            Helpfunctions.Instance.logg("ehero " + this.enemyHero.Hp + " " + this.enemyHero.armor + " " + this.enemyHero.entitiyID);
            foreach (Minion m in ownMinions)
            {
                Helpfunctions.Instance.logg(m.name + " " + m.entitiyID);
            }
            Helpfunctions.Instance.logg("-");
            foreach (Minion m in enemyMinions)
            {
                Helpfunctions.Instance.logg(m.name + " " + m.entitiyID);
            }
            Helpfunctions.Instance.logg("-");
            foreach (Handmanager.Handcard hc in this.owncards)
            {
                Helpfunctions.Instance.logg(hc.position + " " + hc.card.nameEN + " " + hc.entity);
            }
        }

        public Action getNextAction()
        {
            if (this.playactions.Count >= 1) return this.playactions[0];
            return null;
        }

        public CardDB.cardIDEnum CheckTurnDeckExists(TAG_RACE race)
        {
            foreach (KeyValuePair<CardDB.cardIDEnum, int> kvp in this.prozis.turnDeck)
            {
                // ID 转卡
                CardDB.cardIDEnum deckCard = kvp.Key;
                CardDB.Card deckMinion = CardDB.Instance.getCardDataFromID(deckCard);
                // 5费以下野兽
                if ((CardDB.Race)race == deckMinion.race)
                {
                    return deckCard;
                }
            }
            return CardDB.cardIDEnum.None;
        }
        public List<CardDB.cardIDEnum> CheckTurnDeckExists(CardDB.cardtype type, int num)
        {
            List<CardDB.cardIDEnum> list = new List<CardDB.cardIDEnum>();
            int count = 0;
            foreach (KeyValuePair<CardDB.cardIDEnum, int> kvp in this.prozis.turnDeck)
            {
                // ID 转卡
                CardDB.cardIDEnum deckCard = kvp.Key;
                CardDB.Card deckMinion = CardDB.Instance.getCardDataFromID(deckCard);
                if (type == deckMinion.type)
                {
                    count += kvp.Value;
                    for (int i = 0; i < kvp.Value; i++)
                    {
                        list.Add(deckCard);
                    }
                }
                if (count >= num) return list;
            }
            return list;
        }

        public void printActions(bool toBuffer = false)
        {
            int i = 0;
            foreach (Action a in this.playactions)
            {
                i++;
                string tmp = i + ":  ";
                tmp += a.printString();
                Helpfunctions.Instance.logg(tmp);
            }
        }

        public void printActionforDummies(Action a)
        {
            if (a.actionType == actionEnum.playcard)
            {
                Helpfunctions.Instance.ErrorLog("play " + a.card.card.nameEN);
                if (a.druidchoice >= 1)
                {
                    string choose = (a.druidchoice == 1) ? "left card" : "right card";
                    Helpfunctions.Instance.ErrorLog("choose the " + choose);
                }
                if (a.place >= 1)
                {
                    Helpfunctions.Instance.ErrorLog("on position " + a.place);
                }
                if (a.target != null)
                {
                    if (!a.target.own && !a.target.isHero)
                    {
                        string ename = "" + a.target.name;
                        Helpfunctions.Instance.ErrorLog("and target to the enemy " + ename);
                    }

                    if (a.target.own && !a.target.isHero)
                    {
                        string ename = "" + a.target.name;
                        Helpfunctions.Instance.ErrorLog("and target to your own" + ename);
                    }

                    if (a.target.own && a.target.isHero)
                    {
                        Helpfunctions.Instance.ErrorLog("and target your own hero");
                    }

                    if (!a.target.own && a.target.isHero)
                    {
                        Helpfunctions.Instance.ErrorLog("and target to the enemy hero");
                    }
                }

            }
            if (a.actionType == actionEnum.attackWithMinion)
            {
                string name = "" + a.own.name;
                if (a.target.isHero)
                {
                    Helpfunctions.Instance.ErrorLog("attack with: " + name + " the enemy hero");
                }
                else
                {
                    string ename = "" + a.target.name;
                    Helpfunctions.Instance.ErrorLog("attack with: " + name + " the enemy: " + ename);
                }

            }

            if (a.actionType == actionEnum.attackWithHero)
            {
                if (a.target.isHero)
                {
                    Helpfunctions.Instance.ErrorLog("attack with your hero the enemy hero!");
                }
                else
                {
                    string ename = "" + a.target.name;
                    Helpfunctions.Instance.ErrorLog("attack with the hero, and choose the enemy: " + ename);
                }
            }
            if (a.actionType == actionEnum.useHeroPower)
            {
                Helpfunctions.Instance.ErrorLog("use your Heropower ");
                if (a.target != null)
                {
                    if (!a.target.own && !a.target.isHero)
                    {
                        string ename = "" + a.target.name;
                        Helpfunctions.Instance.ErrorLog("on enemy: " + ename);
                    }

                    if (a.target.own && !a.target.isHero)
                    {
                        string ename = "" + a.target.name;
                        Helpfunctions.Instance.ErrorLog("on your own: " + ename);
                    }

                    if (a.target.own && a.target.isHero)
                    {
                        Helpfunctions.Instance.ErrorLog("on your own hero");
                    }

                    if (!a.target.own && a.target.isHero)
                    {
                        Helpfunctions.Instance.ErrorLog("on your the enemy hero");
                    }

                }
            }
            Helpfunctions.Instance.ErrorLog("");

        }


    }



}
