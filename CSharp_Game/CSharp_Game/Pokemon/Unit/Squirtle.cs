﻿using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_Game;
using static CSharp_Game.Skill;

namespace CSharp_Game.Pokemon
{
    internal class Squirtle : Pokemon 
    {
        public override POKEMONTYPE primaryType { get; set; } // 첫번째타입
        public override POKEMONTYPE secondaryType { get; set; } // 두번째타입
        public override int MaxHP { get; set; }

        public override float baseExperience { get; set; }
        public override string name { get; set; }
        public Squirtle()
        {
            Initialize();
        }

        protected override void Initialize()
        {
            name = "꼬부기";

            primaryType = POKEMONTYPE.WATER;
            secondaryType = POKEMONTYPE.NONE;

            Level = 5;
            experience = 0;
            baseExperience = 63;

            SetBaseStats(44, 48, 65, 50, 64, 43);
            PermanentStatsManager.Instance.SetStats(this); //능력치 세팅

            CurrentHP = MaxHP;

            Skill waterGun = new WaterGun(this);
            this.BasicSkill(waterGun);
            Skill surf = new Surf(this);
            this.BasicSkill(surf);
        }
    }
}
