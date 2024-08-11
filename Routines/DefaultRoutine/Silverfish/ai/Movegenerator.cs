namespace HREngine.Bots
{
    using System.Collections.Generic;

    public class Movegenerator
    {
        PenalityManager pen = PenalityManager.Instance;

        private static Movegenerator instance;

        public static Movegenerator Instance
        {
            get
            {
                return instance ?? (instance = new Movegenerator());
            }
        }

        private Movegenerator()
        {
        }

        public List<Action> getMoveList(Playfield p, bool usePenalityManager, bool useCutingTargets, bool own) //得到潜在的动作列表,并给每个动作打分
        {
            //generates only own moves
            List<Action> ret = new List<Action>();
            List<Minion> trgts = new List<Minion>();

            if (p.complete || p.ownHero.Hp <= 0)
            {
                return ret;
            }

            //play cards:
            if (own)
            {
                List<string> playedcards = new List<string>();
                System.Text.StringBuilder cardNcost = new System.Text.StringBuilder();

                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.nameEN == CardDB.cardNameEN.unknown) // 有一些sim比如耶比托·乔巴斯会抽出unknown的卡，会导致后面出异常
                        continue;
                    int cardCost = hc.card.getManaCost(p, hc.manacost);
                    if ((p.nextSpellThisTurnCostHealth && hc.card.type == CardDB.cardtype.SPELL) || (p.nextMurlocThisTurnCostHealth && (TAG_RACE)hc.card.race == TAG_RACE.MURLOC))
                    {
                        if (p.ownHero.Hp > cardCost || p.ownHero.immune) { }
                        else continue; // if not enough Hp
                    }
                    else if (p.mana < cardCost) continue; // if not enough manna

                    CardDB.Card c = hc.card;
                    cardNcost.Clear();
                    cardNcost.Append(c.cardIDenum).Append(hc.manacost);
                    if (playedcards.Contains(cardNcost.ToString()) && !c.Outcast && hc.enchs.Count == 0) continue; // dont play the same card in one loop
                    playedcards.Add(cardNcost.ToString());

                    int isChoice = (c.choice) ? 1 : 0;  //是不是抉择卡
                    bool choiceDamageFound = false;
                    for (int choice = 0 + 1 * isChoice; choice < 1 + 2 * isChoice; choice++)
                    {
                        if (isChoice == 1)
                        {
                            c = pen.getChooseCard(hc.card, choice); // do all choice
                            if (p.ownFandralStaghelm > 0)
                            {
                                if (choiceDamageFound) break;
                                for (int i = 1; i < 3; i++)
                                {
                                    CardDB.Card cTmp = pen.getChooseCard(hc.card, i); // do all choice
                                    if (pen.DamageTargetDatabase.ContainsKey(cTmp.nameEN) || (p.anzOwnAuchenaiSoulpriest > 0 && pen.HealTargetDatabase.ContainsKey(cTmp.nameEN)))
                                    {
                                        choice = i;
                                        choiceDamageFound = true;
                                        c = cTmp;
                                        break;
                                    }
                                    //- Draw a card must be at end in the Sim_xxx - then it will selected!
                                }
                            }
                        }
                        //如果场上随从满了，就无法继续出随从牌了
                        if (p.ownMinions.Count > 6 && (c.type == CardDB.cardtype.MOB || hc.card.type == CardDB.cardtype.MOB)) continue;
                        trgts = c.getTargetsForCard(p, p.isLethalCheck, true);
                        if (trgts.Count == 0) continue;

                        int cardplayPenality = 0;
                        // TODO 找到最优站位
                        int bestplace = p.getBestPlace(c.type == CardDB.cardtype.MOB ? c : hc.card, p.isLethalCheck);
                        foreach (Minion trgt in trgts)
                        {
                            // TODO 如果是灵界抽上来的，无视惩罚
                            if (usePenalityManager) cardplayPenality = pen.getPlayCardPenality(c, trgt, p, hc);  //得到打出每张牌的惩罚值
                            if (cardplayPenality <= 499) // 这步可以去掉一些惩罚值过高的动作
                            {
                                Action a = new Action(actionEnum.playcard, hc, null, bestplace, trgt, cardplayPenality, choice);
                                ret.Add(a);
                            }
                        }
                    }
                }

                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.nameEN == CardDB.cardNameEN.unknown) // 有一些sim比如耶比托·乔巴斯会抽出unknown的卡，会导致后面出异常
                        continue;
                    if (hc.card.Tradeable && p.mana >= hc.card.TradeCost && p.ownDeckSize > 0)//交易要求
                    {
                        Action a = new Action(actionEnum.trade, hc, null, 0, null, 0, 0);
                        ret.Add(a);
                    }
                }
            }

            //get targets for Hero weapon and Minions  ###################################################################################

            // TODO 找到攻击目标
            trgts = p.getAttackTargets(own, p.isLethalCheck);
            if (!p.isLethalCheck) trgts = this.cutAttackList(trgts);

            // attack with minions
            List<Minion> attackingMinions = new List<Minion>(8);

            for (int ii = 0; ii < p.ownMinions.Count; ii++)
            {
                Minion m = p.ownMinions[ii];
                if (m.numAttacksThisTurn == 1 && !m.frozen && !m.cantAttack)
                {
                    if (m.windfury && !m.silenced) m.Ready = true;
                    else if (ii > 0 && p.ownMinions[ii - 1].handcard.card.nameCN == CardDB.cardNameCN.战场军官 && !p.ownMinions[ii - 1].silenced) m.Ready = true;
                    else if (ii < p.ownMinions.Count - 1 && p.ownMinions[ii + 1].handcard.card.nameCN == CardDB.cardNameCN.战场军官 && !p.ownMinions[ii + 1].silenced) m.Ready = true;
                    else m.Ready = false;
                }
            }
            foreach (Minion m in (own ? p.ownMinions : p.enemyMinions))
            {
                if (m.Ready && m.Angr >= 1 && !m.frozen) attackingMinions.Add(m); //* add non-attacing minions
            }
            attackingMinions = this.cutAttackList(attackingMinions);
            // 随从攻击惩罚
            foreach (Minion m in attackingMinions)
            {
                int attackPenality = 0;
                foreach (Minion trgt in trgts)
                {
                    if (trgt != null && trgt.untouchable) continue;
                    if (m.cantAttackHeroes && trgt.isHero) continue;
                    if (usePenalityManager) attackPenality = pen.getAttackWithMininonPenality(m, p, trgt);
                    if (attackPenality <= 499)
                    {
                        Action a = new Action(actionEnum.attackWithMinion, null, m, 0, trgt, attackPenality, 0);
                        ret.Add(a);
                    }
                }
            }

            // attack with hero (weapon)
            if ((own && p.ownHero.Ready && p.ownHero.Angr >= 1) || (!own && p.enemyHero.Ready && p.enemyHero.Angr >= 1))
            {
                int heroAttackPen = 0;
                foreach (Minion trgt in trgts)
                {
                    if ((own ? p.ownWeapon.cantAttackHeroes : p.enemyWeapon.cantAttackHeroes) && trgt.isHero) continue;
                    if (usePenalityManager) heroAttackPen = pen.getAttackWithHeroPenality(trgt, p);
                    if (heroAttackPen <= 499)
                    {
                        Action a = new Action(actionEnum.attackWithHero, null, (own ? p.ownHero : p.enemyHero), 0, trgt, heroAttackPen, 0);
                        ret.Add(a);
                    }
                }
            }

            //#############################################################################################################

            // use own ability
            if (own)
            {
                if (p.ownAbilityReady && p.mana >= p.ownHeroAblility.card.getManaCost(p, p.ownHeroAblility.manacost)) // if ready and enough manna
                {
                    CardDB.Card c = p.ownHeroAblility.card;
                    int isChoice = (c.choice) ? 1 : 0;
                    for (int choice = 0 + 1 * isChoice; choice < 1 + 2 * isChoice; choice++)
                    {
                        if (isChoice == 1)
                        {
                            c = pen.getChooseCard(p.ownHeroAblility.card, choice); // do all choice
                        }
                        int cardplayPenality = 0;
                        int bestplace = p.ownMinions.Count + 1; //we can not manage it
                        trgts = p.ownHeroAblility.card.getTargetsForHeroPower(p, true);
                        foreach (Minion trgt in trgts)
                        {
                            if (p.ownHeroAblility.card.nameCN == CardDB.cardNameCN.未知 && p.ownHeroName == HeroEnum.thief)
                                p.ownHeroAblility.card.nameCN = CardDB.cardNameCN.匕首精通;
                            if (usePenalityManager) cardplayPenality = pen.getPlayCardPenality(p.ownHeroAblility.card, trgt, p, new Handmanager.Handcard());
                            if (cardplayPenality <= 499)
                            {
                                Action a = new Action(actionEnum.useHeroPower, p.ownHeroAblility, null, bestplace, trgt, cardplayPenality, choice);
                                ret.Add(a);
                            }
                        }
                    }
                }
            }

            return ret;
        }
        // 剪枝，排除相同的目标
        public List<Minion> cutAttackList(List<Minion> oldlist)
        {
            List<Minion> retvalues = new List<Minion>(oldlist.Count);
            List<Minion> addedmins = new List<Minion>(oldlist.Count);

            foreach (Minion m in oldlist)
            {
                if (m.isHero)
                {
                    retvalues.Add(m);
                    continue;
                }

                bool goingtoadd = true;
                bool isSpecial = m.handcard.card.isSpecialMinion;
                foreach (Minion mnn in addedmins)
                {
                    //help.logg(mnn.silenced + " " + m.silenced + " " + mnn.name + " " + m.name + " " + penman.specialMinions.ContainsKey(m.name));

                    bool otherisSpecial = mnn.handcard.card.isSpecialMinion;
                    bool onlySpecial = isSpecial && otherisSpecial && !m.silenced && !mnn.silenced;
                    bool onlyNotSpecial = (!isSpecial || (isSpecial && m.silenced)) && (!otherisSpecial || (otherisSpecial && mnn.silenced));

                    if (onlySpecial && (m.name != mnn.name)) continue; // different name -> take it
                    if ((onlySpecial || onlyNotSpecial) && (mnn.Angr == m.Angr && mnn.Hp == m.Hp && mnn.divineshild == m.divineshild && mnn.taunt == m.taunt && mnn.poisonous == m.poisonous && mnn.lifesteal == m.lifesteal && m.handcard.card.isToken == mnn.handcard.card.isToken && mnn.handcard.card.race == m.handcard.card.race && mnn.Spellburst == m.Spellburst && mnn.cantAttackHeroes == m.cantAttackHeroes))
                    {
                        goingtoadd = false;
                        break;
                    }
                }

                if (goingtoadd)
                {
                    addedmins.Add(m);
                    retvalues.Add(m);
                    //help.logg(m.name + " " + m.id +" is added to targetlist");
                }
                else
                {
                    //help.logg(m.name + " is not needed to attack");
                    continue;
                }
            }
            //help.logg("end targetcutting");

            return retvalues;
        }


        public bool didAttackOrderMatters(Playfield p)
        {
            //return true;
            if (p.isOwnTurn)
            {
                if (p.enemySecretCount >= 1) return true;
                if (p.enemyHero.immune) return true;

            }
            else
            {
                if (p.ownHero.immune) return true;
            }
            List<Minion> enemym = (p.isOwnTurn) ? p.enemyMinions : p.ownMinions;
            List<Minion> ownm = (p.isOwnTurn) ? p.ownMinions : p.enemyMinions;

            int strongestAttack = 0;
            foreach (Minion m in enemym)
            {
                if (m.Angr > strongestAttack) strongestAttack = m.Angr;
                if (m.taunt) return true;
                if (m.name == CardDB.cardNameEN.dancingswords || m.name == CardDB.cardNameEN.deathlord) return true;
            }

            int haspets = 0;
            bool hashyena = false;
            bool hasJuggler = false;
            bool spawnminions = false;
            foreach (Minion m in ownm)
            {
                if (m.name == CardDB.cardNameEN.cultmaster) return true;
                if (m.name == CardDB.cardNameEN.knifejuggler) hasJuggler = true;
                if (m.Ready && m.Angr >= 1)
                {
                    if (m.AdjacentAngr >= 1) return true;//wolphalfa or flametongue is in play
                    if (m.name == CardDB.cardNameEN.northshirecleric) return true;
                    if (m.name == CardDB.cardNameEN.armorsmith) return true;
                    if (m.name == CardDB.cardNameEN.loothoarder) return true;
                    //if (m.name == CardDB.cardName.madscientist) return true; // dont change the tactic
                    if (m.name == CardDB.cardNameEN.sylvanaswindrunner) return true;
                    if (m.name == CardDB.cardNameEN.darkcultist) return true;
                    if (m.ownBlessingOfWisdom >= 1) return true;
                    if (m.ownPowerWordGlory >= 1) return true;
                    if (m.name == CardDB.cardNameEN.acolyteofpain) return true;
                    if (m.name == CardDB.cardNameEN.frothingberserker) return true;
                    if (m.name == CardDB.cardNameEN.flesheatingghoul) return true;
                    if (m.name == CardDB.cardNameEN.bloodmagethalnos) return true;
                    if (m.name == CardDB.cardNameEN.webspinner) return true;
                    if (m.name == CardDB.cardNameEN.tirionfordring) return true;
                    if (m.name == CardDB.cardNameEN.baronrivendare) return true;


                    //if (m.name == CardDB.cardName.manawraith) return true;
                    //buffing minions (attack with them last)
                    if (m.name == CardDB.cardNameEN.raidleader || m.name == CardDB.cardNameEN.stormwindchampion || m.name == CardDB.cardNameEN.timberwolf || m.name == CardDB.cardNameEN.southseacaptain || m.name == CardDB.cardNameEN.murlocwarleader || m.name == CardDB.cardNameEN.grimscaleoracle || m.name == CardDB.cardNameEN.leokk || m.name == CardDB.cardNameEN.fallenhero || m.name == CardDB.cardNameEN.warhorsetrainer) return true;


                    if (m.name == CardDB.cardNameEN.scavenginghyena) hashyena = true;
                    if (m.handcard.card.race == CardDB.Race.BEAST) haspets++;
                    if (m.name == CardDB.cardNameEN.harvestgolem || m.name == CardDB.cardNameEN.hauntedcreeper || m.souloftheforest >= 1 || m.stegodon >= 1 || m.livingspores >= 1 || m.infest >= 1 || m.ancestralspirit >= 1 || m.desperatestand >= 1 || m.explorershat >= 1 || m.returnToHand >= 1 || m.name == CardDB.cardNameEN.nerubianegg || m.name == CardDB.cardNameEN.savannahhighmane || m.name == CardDB.cardNameEN.sludgebelcher || m.name == CardDB.cardNameEN.cairnebloodhoof || m.name == CardDB.cardNameEN.feugen || m.name == CardDB.cardNameEN.stalagg || m.name == CardDB.cardNameEN.thebeast) spawnminions = true;

                }
            }

            if (haspets >= 1 && hashyena) return true;
            if (hasJuggler && spawnminions) return true;




            return false;
        }
    }

}