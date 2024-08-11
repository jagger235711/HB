
//cardids of duplicate + avenge
//nozdormu (for computing time :D)
//faehrtenlesen (tracking)
// lehrensucher cho
//scharmuetzel kills all :D
namespace HREngine.Bots
{
    using System;
    using System.Text;

    public enum actionEnum
    {
        endturn = 0, // 结束此回合
        playcard, // 出一张牌，出的牌在card中
        attackWithHero, // 英雄进行攻击，target作为目标，own通常是我方英雄
        useHeroPower,
        // 使用英雄技能，target作为目标
        // (英雄技能无攻击目标的英雄则为null，如Mage)
        attackWithMinion, // 随从进行攻击，target作为目标，own是用于攻击的随从
        trade//交易
    }
    
    public class Action
    {

        public actionEnum actionType; // 用于记录操作的类型。
        public Handmanager.Handcard card;
        // 记录出的牌，在attackWithHero和attackWithMinion操作中为null
        public int place;
        // 用于记录位置，如actionType为playcard时就会有内容，
        // 比如出一个随从就会标记出放置的位置（最左边为0），
        // 如果是出一张法术牌的话，具体内容没有研究，应该是有赋值的

        public Minion own;
        public Minion target;
        // 这两个成员，顾名思义一个是 我方随从（英雄），另一个是攻击目标。

        public int druidchoice;
        // 用于抉择牌选择
        // 如果是未修改过的兄弟，抉择牌的编号分别是（0：中间 1：左边 2：右边）
        public int penalty;
        // 惩罚值，对于这个操作给出多少的惩罚
        // 值越大越不推荐这样下，如果值为负数则是非常推荐。
        public int turn = -1;
        // 记录的应该是此回合中的第几步操作，初始值为-1 (不确定)
        public int prevHpOwn = -1; // 不确定
        public int prevHpTarget = -1; // 不确定

        public Action(actionEnum type, Handmanager.Handcard hc, Minion ownM, int place, Minion targetM, int pen, int choice)
        {
            this.actionType = type;
            this.card = hc;
            this.own = ownM;
            this.place = place;
            this.target = targetM;
            this.penalty = pen;
            this.druidchoice = choice;
            if (ownM != null) prevHpOwn = ownM.Hp;
            if (targetM != null) prevHpTarget = targetM.Hp;
        }
        
        public Action(Action a)
        {
            this.actionType = a.actionType;
            this.card = a.card;
            this.place = a.place;
            this.own = a.own;
            this.target = a.target;
            this.druidchoice = a.druidchoice;
            this.penalty = a.penalty;
            this.prevHpOwn = a.prevHpOwn;
            this.prevHpTarget = a.prevHpTarget;
        }

        public void print(bool tobuffer = false)
        {
            if (printUtils.printNextMove && this.penalty != 0 && !(this.penalty == - printUtils.enfaceReward && this.actionType == actionEnum.attackWithMinion) )
            {
                StringBuilder str = new StringBuilder("", 100);
                switch (this.actionType)
                {
                    case actionEnum.endturn:
                        str.Append("回合结束");
                        break;
                    case actionEnum.playcard:
                        str.Append("打出");
                        str.Append(this.card == null ? "无" : this.card.card.nameCN.ToString());
                        str.Append("，目标 ");
                        str.Append(this.target == null ? "无" : this.target.handcard.card.nameCN.ToString());
                        break;
                    case actionEnum.attackWithHero:
                        str.Append("让英雄攻击 ");
                        str.Append(this.target == null ? "无" : this.target.handcard.card.nameCN.ToString());
                        break;
                    case actionEnum.useHeroPower:
                        str.Append("使用英雄技能");
                        str.Append("，目标 ");
                        str.Append(this.target == null ? "无" : this.target.handcard.card.nameCN.ToString());
                        break;
                    case actionEnum.attackWithMinion:
                        str.Append("使用随从 ");
                        str.Append(this.own == null ? "无" : this.own.handcard.card.nameCN.ToString());
                        str.Append(" 攻击 ");
                        str.Append(this.target == null ? "无" : this.target.handcard.card.nameCN.ToString());
                        break;
                }
                str.Append("，当前受到 " + this.penalty + " 点惩罚！");
                Helpfunctions.Instance.ErrorLog(str.ToString());
            }
            Helpfunctions help = Helpfunctions.Instance;
            if (tobuffer)
            {
                if (this.actionType == actionEnum.playcard)
                {
                    string playaction = "play ";

                    //playaction += "id " + this.card.entity;
                    playaction += "id " + this.card.card.chnInfo(); // 打出名字和身材，更方便查阅动作，更可读
                    if (this.target != null)
                    {
                        playaction += " target " + this.target.info();
                    }

                    if (this.place >= 0)
                    {
                        playaction += " pos " + this.place;
                    }

                    if (this.druidchoice >= 1) playaction += " choice " + this.druidchoice;

                    help.writeToBuffer(playaction);
                }
                if (this.actionType == actionEnum.attackWithMinion)
                {
                    help.writeToBuffer("attack " + this.own.info() + " enemy " + this.target.info());
                }
                if (this.actionType == actionEnum.attackWithHero)
                {
                    help.writeToBuffer("heroattack " + this.target.info());
                }
                if (this.actionType == actionEnum.useHeroPower)
                {
                    help.writeToBuffer("交易 " + this.card.card.nameCN);
                }
                if (this.actionType == actionEnum.trade)
                {

                    if (this.target != null)
                    {
                        help.writeToBuffer("英雄技能 on target " + this.target.info());
                    }
                    else
                    {
                        help.writeToBuffer("英雄技能");
                    }
                }
                return;
            }
            if (this.actionType == actionEnum.playcard)
            {
                string playaction = "play ";

                //playaction += "id " + this.card.entity;
                playaction += "id " + this.card.card.chnInfo(); // 打出名字和身材，更方便查阅动作，更可读
                if (this.target != null)
                {
                    playaction += " target " + this.target.info();
                }

                if (this.place >= 0)
                {
                    playaction += " pos " + this.place;
                }

                if (this.druidchoice >= 1) playaction += " choice " + this.druidchoice;

                help.logg(playaction);
            }
            if (this.actionType == actionEnum.attackWithMinion)
            {
                help.logg("随从攻击: " + this.own.info() + " enemy: " + this.target.info());
            }
            if (this.actionType == actionEnum.attackWithHero)
            {
                help.logg("attack with hero, enemy: " + this.target.info());
            }
            if (this.actionType == actionEnum.useHeroPower)
            {
                if (this.target != null)
                {
                    help.logg("英雄技能 on enemy: " + this.target.info());
                }
                else
                    help.logg("英雄技能 目标:空");
            }
        }
        
        public string printString()
        {
            string retval = "";

            if (this.actionType == actionEnum.playcard)
            {
                retval += "play ";

                //retval += "id " + this.card.entity;
                retval += "id " + this.card.card.chnInfo(); // 打出名字和身材，更方便查阅动作，更可读
                if (this.target != null)
                {
                    retval += " target " + this.target.info();
                }

                if (this.place >= 0)
                {
                    retval += " pos " + this.place;
                }
                if (this.druidchoice >= 1) retval += " choice " + this.druidchoice;
            }
            if (this.actionType == actionEnum.attackWithMinion)
            {
                retval += ("attacker: " + this.own.info() + " enemy: " + this.target.info());
            }
            if (this.actionType == actionEnum.attackWithHero)
            {
                retval += ("attack with hero, enemy: " + this.target.info());
            }
            if (this.actionType == actionEnum.useHeroPower)
            {
                retval += ("英雄技能 ");
                if (this.target != null)
                {
                    retval += ("on target: " + this.target.info());
                }
            }

            return retval;
        }

    }

    
}