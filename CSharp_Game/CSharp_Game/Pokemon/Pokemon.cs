using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Game.Pokemon
{
    internal class Pokemon
    {
        public string Name { get; set; }
        public string Type { get; set; } // 타입
        public int Level { get; set; }
        public int Experience { get; set; } //경험치
        public int MaxHP { get; set; }
        public int CurrentHP { get; set; }
        public int Attack { get; set; }
        public int SpAttack { get; set; } // 특수 공격
        public int Defense { get; set; }
        public int SpDefense { get; set; } // 특수 방어
        public string Status { get; set; } //상태
        public int Speed { get; set; }
        //public string Ability { get; set; } //특성
        public List<string> CurrentSkills { get; set; } //현재 기술 목록
        public List<string> Skills { get; set; } //배울수 있는 기술 목록
        //public string HeldItem { get; set; } // 소지한 아이템

        public Pokemon(string name, string type, int hp, int attack, int defense, int spAttack, int spDefense, int speed, int level)
        {
            Name = name;
            Type = type;
            Level = level;
            Experience = 0;

            MaxHP = hp;
            CurrentHP = hp;
            Attack = attack;
            SpAttack = spAttack;
            Defense = defense;
            SpDefense = spDefense;
            Speed = speed;

            Status = "Normal";
            CurrentSkills = new List<string>();
            Skills = new List<string>();
        }

    }
}
