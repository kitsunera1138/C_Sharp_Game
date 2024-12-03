using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_Game.Skill;
using static CSharp_Game.Skill.Skill;

namespace CSharp_Game.Pokemon
{
    internal class Pikachu : Pokemon
    {
        //나중에 종족값에 자동으로 능력치 계산해주는 클래스로 빼야할듯
        public override string type { get ; set; }
        public override int MaxHP { get; set ; }
        public override int attack { get; set; }
        public override int spAttack { get ; set; }
        public override int defense { get ; set ; }
        public override int spDefense { get; set; }
        public override int speed { get; set; }
        public override float baseExperience { get; set; }
        public override string name { get; set; }

        public Pikachu()
        {
            name = "Pikachu";
            PokemonTypeManager typeManager = new PokemonTypeManager();
            type = "A";
            //Type = type;
            Level = 5;
            experience = 0;
            baseExperience = 100;
            MaxHP = 100;

            CurrentHP = MaxHP;
            attack = 5;
            spAttack = 5;
            defense = 5;
            spDefense = 5;
            speed = 5;

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
        }



        //public Pikachu(string name, string type, int hp, int attack, int defense, int spAttack, int spDefense, int speed, int level) : base(name, type, hp, attack, defense, spAttack, spDefense, speed, level)
        //{
        //}
    }
}
