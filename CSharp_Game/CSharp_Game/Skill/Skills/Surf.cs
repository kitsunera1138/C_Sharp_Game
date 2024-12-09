﻿using CSharp_Game.Pokemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CSharp_Game.Skill;

namespace CSharp_Game
{
    public class Surf : Skill
    {
        //
        public override string skillName { get; set; }
        public override int maxPP { get; set; }
        public override int currentPP { get; set; }
        public override ATTACKTYPE AttackType { get; set; }
        public override SKILLTYPE skillType { get; set; }

        public Surf(Pokemon.Pokemon learbpokemon) //기술을 배운 포켓몬의 타입을 가져옴
        {
            this.pokemon = learbpokemon;
            skillName = "파도타기";
            skillType = SKILLTYPE.WATER;
            AttackType = ATTACKTYPE.SpecialAttack;

            power = 90;
            accuracy = 100; //명중률
            maxPP = 15;

            Priority = 1;
            currentPP = maxPP;

            typeBonus = BattleManager.Instance.CompareSkillType(this, learbpokemon);
        }

        public override void Use(Pokemon.Pokemon target)
        {
            //Console.WriteLine(pokemon.name + skillName);
            --currentPP;

            //배틀매니저의 공격
            BattleManager.Instance.Attack(this, pokemon, target);
        }
    }
}
