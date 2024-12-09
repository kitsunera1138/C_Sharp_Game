using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using CSharp_Game;
using static CSharp_Game.Skill;

namespace CSharp_Game.Pokemon
{
    public enum BASESTATS
    {
        BaseHp,
        BaseAttack,
        BaseSpAttack,
        BaseDefense,
        BaseSpDefense,
        BaseSpeed
    }

    //추상 클래스로 구현
    abstract public class Pokemon
    {
        //기본 능력치
        public Dictionary<BASESTATS, int> pokemonBaseStats { get; set; }
        public abstract string name { get; set; }
        //배틀 구현에 쉽도록 타입 따로따로 뺌
        public abstract POKEMONTYPE primaryType { get; set; } // 첫번째타입
        public abstract POKEMONTYPE secondaryType { get; set; } // 두번째타입
        public int Level { get; set; }
        public int staticLevel
        {
            get
            {
                return this.Level;  // this를 통해 인스턴스 속성에 접근
            }
        }
        public EXGROWTHRATE eXGROWTHRATE { get; set; }
        public float experience { get; set; } //경험치 
        public float nextExperience { get; set; } //다음 레벨까지의 경험치 
        public abstract float baseExperience { get; set; } //야생 포켓몬이 가진 기본 경험치 (승리 시 받을 수 있는 경험치)와 경험치 계산에 들어가는 기본 경험치
        public int CurrentHP { get; set; }
        public abstract int MaxHP { get; set; }
        public int attack { get; set; }
        public int defense { get; set; }
        public int spAttack { get; set; } // 특수 공격
        public int spDefense { get; set; } // 특수 방어
        public int speed { get; set; }
        public string status { get; set; } //상태 이상
        public List<Skill> Skills { get; set; } //배우고 있는 스킬
        public Skill CurrentSkills;//현재 선택한 스킬

        //레벨에 따른 배울수 있는 기술
        Dictionary<Skill, int> learnSkill = new Dictionary<Skill, int>();

        //보류
        public int Accuracy;//명중률
        public int Evasion;//회피율

        //배울 수 있는 스킬은 클래스 빼야할듯

        //public string Ability { get; set; } //특성
        //public string HeldItem { get; set; } // 소지한 아이템
        public List<int> IV = new List<int>();


        public Pokemon()
        {
            IV.Capacity = 6;
            Level = 5;
            experience = 0;
            status = "Normal"; //기본 상태이상

            Skills = new List<Skill>(4);
            Skills.Capacity = 4;

            //모든 포켓몬은 기본 몸통박치기를 가지고 있음
            Skill tackle = new Tackle(this);
            this.LearnSkill(tackle);

            CurrentSkills = Skills[0];
            eXGROWTHRATE = EXGROWTHRATE.Slow;
        }

        //추상 메서드 자식에서 필수적으로 구현해야되는 것들을 포함한다. SetBaseStats 기본 능력치 설정,Level,experience,baseExperience,primaryType 타입들
        protected abstract void Initialize(); //초기화 함수

        //자식 클래스에서 필수 호출
        public void SetBaseStats(int hp, int attack, int defense, int spAttack, int spDefense, int speed)
        {
            //기본 능력치 설정
            pokemonBaseStats = new Dictionary<BASESTATS, int>
            {
                { BASESTATS.BaseHp, hp },
                { BASESTATS.BaseAttack, attack },
                { BASESTATS.BaseDefense, defense },
                { BASESTATS.BaseSpAttack, spAttack },
                { BASESTATS.BaseSpDefense, spDefense },
                { BASESTATS.BaseSpeed, speed }
            };
        }

        public void LearnSkill(Skill skill)
        {
            if (Skills.Count < 4) 
            { 
                Skills.Add(skill);
                if(skill.skillName.ToString() != "몸통박치기")
                {
                    Console.WriteLine(this.name + "는(은) " + skill.skillName + " 배웠다");
                } 
            }
            else
            {
                ConsoleColors.ResetColor();
                ConsoleColors.ChangeColor(COLORS.Red);
                Console.WriteLine("스킬 목록이 가득 찼습니다");
                Console.WriteLine("스킬 하나를 지워야합니다.");
                Console.WriteLine();
                ConsoleColors.ResetColor();
                Console.WriteLine("현재 스킬 목록");
                ShowCurrentSkill();

                //선택지
                OverSkill(skill);
                ShowCurrentSkill();
            }
        }

        public void BasicSkill(Skill skill)
        {
            if (Skills.Count < 4)
            {
                Skills.Add(skill);
            }
        }
        public void OverSkill(Skill skill)
        {
            ConsoleColors.ChangeColor(COLORS.Yellow);
            Console.WriteLine("새로운 스킬을 배우기 위해서는 기존 스킬을 지워야 합니다.");
            Console.WriteLine("대체하고 싶은 스킬를 입력하세요 (1~4). 지우지 않을려면 0을 입력하세요");

            int selectedIndex;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out selectedIndex) && selectedIndex >= 0 && selectedIndex <= Skills.Count)
                {
                    break;
                }

                Console.WriteLine("유효하지 않은 입력입니다. 다시 입력하세요:");
            }

            if (selectedIndex == 0)
            {
                Console.WriteLine("새로운 스킬을 배우지 않았다.");
            }
            else
            {
                Console.WriteLine("스킬 " + Skills[selectedIndex-1].skillName + "을(를)" + skill.skillName + "(으)로 대체했다.");
                Skills[selectedIndex - 1] = skill;
            }
            ConsoleColors.ResetColor();
        }

        public void ShowCurrentSkill()
        {
            ConsoleColors.ChangeColor(COLORS.Yellow);
            Console.WriteLine();

            for (int i = 0; i < Skills.Count; i++)
            {
                Console.WriteLine(i+1 + "번째 스킬 " + Skills[i].skillName);
            }
            Console.WriteLine();
            ConsoleColors.ResetColor();
        }

        public void ShowHealth()
        {
            Console.WriteLine(this.name + ": " + this.CurrentHP + "/" + this.MaxHP);
        }

        #region 확인용 나중에 지우기 이대로 쓰면 클래스마다 생성되어서 UIManager로 뺌

        public void Information()
        {
            Console.WriteLine("Name: " + name + " primaryType: " + primaryType + " secondaryType: " + secondaryType + " Level: " + Level + " Experience: " + experience + " BaseExperience: " + baseExperience + " MaxHP:  " + MaxHP + " CurrentHP: " + CurrentHP + " Attack:  " + attack + " Defense:  " + defense + " SpAttack:  " + spAttack + " SpDefense: " + spDefense + " Speed: " + speed);
        }



        public void IVInformation() //개체값 확인 매서드 1~31
        {
            Console.WriteLine(this.name + "의 개체값");

            foreach (var iv in IV)
            {
                Console.Write(iv + " ");
            }
        }


        #region 버림

        //public Dictionary<BATTLESTATS, int> pokemonBaseStats { get; set; }를 써서 편하게 관리?

        //public enum BATTLESTATS
        //{
        //    Level,
        //    experience,
        //    baseExperience,
        //    MaxHP,
        //    CurrentHP,
        //    attack,
        //    defense,
        //    spAttack,
        //    spDefense,
        //    speed,
        //}

        //public void ShowExperience() //경험치 - 현재 경험치, 다음 레벨까지
        //{
        //    Console.WriteLine("현재 경험치: " + experience);
        //    Console.WriteLine("다음 경험치: " + nextExperience);
        //    Console.WriteLine("다음 경험치까지: " + (nextExperience - experience));
        //}

        //public void ShowState() //능력치
        //{
        //    Console.WriteLine(name + ":  " + CurrentHP + " / " + MaxHP);
        //    //Console.WriteLine("상태: " + status);
        //    Console.WriteLine();
        //    Console.WriteLine(name + "능력치");

        //    Console.WriteLine("Hp: " + MaxHP);
        //    Console.WriteLine("Attack: " + attack);
        //    Console.WriteLine("Defense: " + defense);
        //    Console.WriteLine("SpAttack: " + spAttack);
        //    Console.WriteLine("SpDefense: " + spDefense);
        //    Console.WriteLine("Speed: " + speed);
        //}

        //public void ShowSkill()//보유 스킬
        //{
        //    Console.WriteLine("스킬");

        //    foreach (List<ISkill> f in Skills)
        //    {
        //        if(f != null) Console.WriteLine(f);
        //    }
        //}

        ////name을 입력하면 해당하는 클래스 생성 기능 추가예정
        //public Pokemon(string name, string type, int hp, int attack, int defense, int spAttack, int spDefense, int speed, int level)
        //{

        //    this.name = name;
        //    this.primaryType = type;
        //    this.Level = level;
        //    experience = 0;
        //    baseExperience = 100;

        //    MaxHP = hp;
        //    CurrentHP = hp;
        //    Attack = attack;
        //    SpAttack = spAttack;
        //    Defense = defense;
        //    SpDefense = spDefense;
        //    Speed = speed;

        //}
        //public void ShowCurrentSkill()
        //{
        //    foreach (var skill in Skills)
        //    {
        //        Console.WriteLine(skill);
        //    }
        //}
        #endregion


        #endregion
    }
}
