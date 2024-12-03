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
    abstract public class Pokemon
    {
        public abstract string name { get; set; }
        public abstract string type { get; set; } // 타입
        public int Level { get; set; }
        public float experience { get; set; } //경험치 
        public abstract float baseExperience { get; set; } //포켓몬의 경우 승리 시 획득 경험치
        public abstract int MaxHP { get; set; }
        public int CurrentHP { get; set; }
        public abstract int attack { get; set; }
        public abstract int spAttack { get; set; } // 특수 공격
        public abstract int defense { get; set; }
        public abstract int spDefense { get; set; } // 특수 방어
        public abstract int speed { get; set; }
        public string status { get; set; } //상태 이상
        public List<ISkill> CurrentSkills { get; set; } //현재 선택한 스킬
        public List<ISkill> Skills { get; set; } //배우고 있는 스킬

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
            CurrentSkills = new List<ISkill>(); 
            Skills = new List<ISkill>(4); //현재 포켓몬 interface 스킬 목록
        }

        public void LearnSkill(ISkill skill)
        {
            Skills.Add(skill);
        }

        public void Information()
        {
            Console.WriteLine("Name: " + name + " Type: " + type + " Level: " + Level + " Experience: " + experience + " BaseExperience: " + baseExperience + " MaxHP:  " + MaxHP + " Attack:  " + attack + " SpAttack:  " + spAttack + " Defense:  " + defense + " CurrentHP: " + CurrentHP + " SpDefense: " + spDefense + " Speed: " + speed);
        }

        public void ShowState()
        {
            Console.WriteLine(CurrentHP + " / " + MaxHP);
            Console.WriteLine("상태: " + status);
            Console.WriteLine("능력치");

            Console.WriteLine("MaxHp: " + MaxHP);
            Console.WriteLine("Attack: " + attack);
            Console.WriteLine("SpAttack: " + spAttack);
            Console.WriteLine("Defense: " + defense);
            Console.WriteLine("SpDefense: " + spDefense);
            Console.WriteLine("Speed: " + speed);
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
}
