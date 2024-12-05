using System;
using System.Buffers.Text;
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

        public override float baseExperience { get; set; }
        public override string name { get; set; }
        public Pikachu()
        {
            RequiredSettings();
            


            //speed = pokemonBaseStats[5];
            //MaxHP = hp;
            //CurrentHP = hp;
            //Attack = attack;
            //SpAttack = spAttack;
            //Defense = defense;
            //SpDefense = spDefense;
            //Speed = speed;

            //Status = "Normal";
            //CurrentSkills = new List<string>();
            //Skills = new List<string>();
        }

        protected override void RequiredSettings()
        {
            name = "Pikachu";
            PokemonTypeManager typeManager = new PokemonTypeManager();
            //타입 클래스로 받아와서 상성표 개별로? 전기클래스는 공격타입으로  뭐에약함 강함등 방어타입으로 ....
            primaryType = "ELECTRIC";
            secondaryType = "None";
            //Type = type;
            Level = 5;
            experience = 0;
            baseExperience = 100;

            SetBaseStats(35, 55, 40, 50, 50, 90);
            PermanentStatsManager.Instance.SetStats(this);
            
            CurrentHP = MaxHP;
        }



        //public Pikachu(string name, string type, int hp, int attack, int defense, int spAttack, int spDefense, int speed, int level) : base(name, type, hp, attack, defense, spAttack, spDefense, speed, level)
        //{
        //}

    }
}
