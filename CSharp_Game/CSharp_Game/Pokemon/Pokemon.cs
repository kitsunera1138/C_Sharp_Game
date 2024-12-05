using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using CSharp_Game.Skill;
using static CSharp_Game.Skill.Skill;

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

    //추상 클래스로 구현
    abstract public class Pokemon
    {
        //기본 능력치
        public Dictionary<BASESTATS, int> pokemonBaseStats { get; set; }
        public abstract string name { get; set; }
        //배틀 구현에 쉽도록 타입 따로따로 뺌
        public abstract string primaryType { get; set; } // 첫번째타입
        public abstract string secondaryType { get; set; } // 두번째타입
        public int Level { get; set; }
        public float experience { get; set; } //경험치 
        public abstract float baseExperience { get; set; } //포켓몬의 경우 승리 시 획득 경험치
        public abstract int MaxHP { get; set; }
        public int CurrentHP { get; set; }

        public int attack { get; set; }
        public int defense { get; set; }
        public int spAttack { get; set; } // 특수 공격
        public int spDefense { get; set; } // 특수 방어
        public int speed { get; set; }
        public string status { get; set; } //상태 이상
        public List<ISkill> Skills { get; set; } //배우고 있는 스킬
        public ISkill CurrentSkills;//현재 선택한 스킬

        //레벨에 따른 배울수 있는 기술
        Dictionary<Skill.Skill, int> learnSkill = new Dictionary<Skill.Skill, int>();

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
            Level = 1;
            experience = 0;
            status = "Normal";
            //CurrentSkills = new List<ISkill>();
            Skills = new List<ISkill>(4);
            Skills.Capacity = 4;

            //현재 포켓몬 interface 스킬 목록
            //List<T> list = new List<T>(4);

        }

        //추상 메서드 자식에서 필수적으로 구현해야되는 것들을 포함한다. SetBaseStats 기본 능력치 설정,Level,experience,baseExperience,primaryType 타입들
        protected abstract void RequiredSettings();

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

        public void StatsSeting()
        {

        }

        public void LearnSkill(ISkill skill)
        {
            if (Skills.Count <= 4) { Skills.Add(skill); }
            else
            {
                Console.WriteLine("스킬 하나를 지워야합니다.");
                //대충 선택 지 함수

            }
        }


        #region 확인용

        public void Information()
        {
            Console.WriteLine("Name: " + name + " primaryType: " + primaryType + " secondaryType: " + secondaryType + " Level: " + Level + " Experience: " + experience + " BaseExperience: " + baseExperience + " MaxHP:  " + MaxHP + " CurrentHP: " + CurrentHP + " Attack:  " + attack + " Defense:  " + defense + " SpAttack:  " + spAttack + " SpDefense: " + spDefense + " Speed: " + speed);
        }

        public void ShowState()
        {
            Console.WriteLine(name + ":  " + CurrentHP + " / " + MaxHP);
            Console.WriteLine("상태: " + status);
            Console.WriteLine("능력치");

            Console.WriteLine("MaxHp: " + MaxHP);
            Console.WriteLine("Attack: " + attack);
            Console.WriteLine("Defense: " + defense);
            Console.WriteLine("SpAttack: " + spAttack);
            Console.WriteLine("SpDefense: " + spDefense);
            Console.WriteLine("Speed: " + speed);
        }

        public void IVInformation() //개체값 확인 매서드
        {
            Console.WriteLine(this.name + "의 개체값");
            
            foreach(var iv in IV)
            {
                Console.Write(iv +" ");
            }
        }

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
        public void ShowCurrentSkill()
        {
            foreach (var skill in Skills)
            {
                Console.WriteLine(skill);
            }
        }

        #endregion



    }


    public class Charmander : Pokemon
    {
        public override string primaryType { get; set; } // 첫번째타입
        public override string secondaryType { get; set; } // 두번째타입
        public override int MaxHP { get; set; }
        public override float baseExperience { get; set; }
        public override string name { get; set; }
        public Charmander()
        {
            RequiredSettings();
        }
        protected override void RequiredSettings()
        {
            SetBaseStats(39,52,43,60,50,65);
            name = "파이리";
            primaryType = "ELECTRIC";
            secondaryType = "None";
            Level = 5;
            experience = 0;
            baseExperience = 100;
            //
            //statsManager.SetStats();

            //PermanentStatsManager.Instance();
            //삭제예정
            //speed = baseSpeed;
            //MaxHP = 100;
            //CurrentHP = MaxHP;
        }
    }
}
