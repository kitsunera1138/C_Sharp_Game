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
    //추상 클래스로 구현
    abstract public class Pokemon
    {
        public abstract string name { get; set; }
        //배틀 구현에 쉽도록 타입 따로따로 뺌
        public abstract string primaryType { get; set; } // 첫번째타입
        public abstract string secondaryType { get; set; } // 두번째타입
        public int Level { get; set; }
        public float experience { get; set; } //경험치 
        public abstract float baseExperience { get; set; } //포켓몬의 경우 승리 시 획득 경험치
        public abstract int MaxHP { get; set; }
        public int CurrentHP { get; set; }
        public abstract int baseAttack { get; set; }
        public abstract int baseSpAttack { get; set; } // 특수 공격
        public abstract int baseDefense { get; set; }
        public abstract int baseSpDefense { get; set; } // 특수 방어
        public abstract int baseSpeed { get; set; }

        public int attack { get; set; }
        public  int spAttack { get; set; } // 특수 공격
        public  int defense { get; set; }
        public  int spDefense { get; set; } // 특수 방어
        public   int speed { get; set; }

        public string status { get; set; } //상태 이상
        //public List<ISkill> CurrentSkills { get; set; } //현재 선택한 스킬
        public List<ISkill> Skills { get; set; } //배우고 있는 스킬
        public ISkill CurrentSkills;

        //레벨에 따른 배울수 있는 기술
        Dictionary<Skill.Skill, int> learnSkill = new Dictionary<Skill.Skill, int>();

        //보류
        public int Accuracy;//명중률
        public int Evasion;//회피율

        //배울 수 있는 스킬은 클래스 빼야할듯

        //public string Ability { get; set; } //특성
        //public string HeldItem { get; set; } // 소지한 아이템

        public Pokemon()
        {
            Level = 1;
            experience = 0;
            status = "Normal";
            //CurrentSkills = new List<ISkill>();
            Skills = new List<ISkill>(4); //현재 포켓몬 interface 스킬 목록
            //List<T> list = new List<T>(5);

        }

        public void LearnSkill(ISkill skill)
        {
            Skills.Add(skill);
        }

        public void Information()
        {
            Console.WriteLine("Name: " + name + " primaryType: " + primaryType + " secondaryType: " + secondaryType + " Level: " + Level + " Experience: " + experience + " BaseExperience: " + baseExperience + " MaxHP:  " + MaxHP + " Attack:  " + baseAttack + " SpAttack:  " + baseSpAttack + " Defense:  " + baseDefense + " CurrentHP: " + CurrentHP + " SpDefense: " + baseSpDefense + " Speed: " + baseSpeed);
        }

        public void ShowState()
        {
            Console.WriteLine(CurrentHP + " / " + MaxHP);
            Console.WriteLine("상태: " + status);
            Console.WriteLine("능력치");

            Console.WriteLine("MaxHp: " + MaxHP);
            Console.WriteLine("Attack: " + baseAttack);
            Console.WriteLine("SpAttack: " + baseSpAttack);
            Console.WriteLine("Defense: " + baseDefense);
            Console.WriteLine("SpDefense: " + baseSpDefense);
            Console.WriteLine("Speed: " + baseSpeed);
        }
        public void ShowCurrentSkill()
        {
            foreach (var skill in Skills)
            {
                Console.WriteLine(skill);
            }
        }

        //public Pokemon(string name, string type, int hp, int attack, int defense, int spAttack, int spDefense, int speed, int level)
        //{
        //    Name = name;
        //    Type = type;
        //    Level = level;
        //    Experience = 0;
        //    BaseExperience = 100;

        //    MaxHP = hp;
        //    CurrentHP = hp;
        //    Attack = attack;
        //    SpAttack = spAttack;
        //    Defense = defense;
        //    SpDefense = spDefense;
        //    Speed = speed;

        //    Status = "Normal";
        //    CurrentSkills = new List<string>();
        //    Skills = new List<string>();
        //}

    }


    public class Charmander: Pokemon
    {
        public override string primaryType { get; set; } // 첫번째타입
        public override string secondaryType { get; set; } // 두번째타입
        public override int MaxHP { get; set; }
        public override int baseAttack { get; set; }
        public override int baseSpAttack { get; set; }
        public override int baseDefense { get; set; }
        public override int baseSpDefense { get; set; }
        public override int baseSpeed { get; set; }
        public override float baseExperience { get; set; }
        public override string name { get; set; }
    }
}
