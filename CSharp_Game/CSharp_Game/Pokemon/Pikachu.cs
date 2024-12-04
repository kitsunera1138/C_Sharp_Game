﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_Game.Skill;
using static CSharp_Game.Skill.Skill;

namespace CSharp_Game.Pokemon
{
    internal class Pikachu : Pokemon //수정예정 이렇게 굳이 하나하나 포켓몬마다 할 필요없이 생성시 세팅하는게 나을수도// 스킬은 스킬매니저에서 이 포켓이 aa다 알려주고
    {
        //나중에 종족값에 자동으로 능력치 계산해주는 클래스로 빼야할듯

        //+ 알아서 원하는 포켓몬 생성 시 스탯 자동으로 해줘야
        public override string primaryType { get; set; } // 첫번째타입
        public override string secondaryType { get; set; } // 두번째타입
        public override int MaxHP { get; set ; }
        public override int baseAttack { get; set; }
        public override int baseSpAttack { get ; set; }
        public override int baseDefense { get ; set ; }
        public override int baseSpDefense { get; set; }
        public override int baseSpeed { get; set; }
        public override float baseExperience { get; set; }
        public override string name { get; set; }

        public Pikachu()
        {
            name = "Pikachu";
            PokemonTypeManager typeManager = new PokemonTypeManager();
            primaryType = "ELECTRIC";
            secondaryType = "None";
            //Type = type;
            Level = 5;
            experience = 0;
            baseExperience = 100;
            MaxHP = 100;

            CurrentHP = MaxHP;
            baseAttack = 5;
            baseSpAttack = 5;
            baseDefense = 5;
            baseSpDefense = 5;
            baseSpeed = 10;
            //삭제예정
            speed = baseSpeed;

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
