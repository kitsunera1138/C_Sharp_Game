using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_Game;
using static CSharp_Game.Skill;

namespace CSharp_Game.Pokemon
{
    internal class Bellsprout : Pokemon
    {
        public override POKEMONTYPE primaryType { get; set; } // 첫번째타입
        public override POKEMONTYPE secondaryType { get; set; } // 두번째타입
        public override int MaxHP { get; set; }

        public override float baseExperience { get; set; }
        public override string name { get; set; }
        public Bellsprout()
        {
            Initialize();
        }

        protected override void Initialize()
        {
            name = "모다피";

            primaryType = POKEMONTYPE.GRASS;
            secondaryType = POKEMONTYPE.NONE;

            Level = 5;
            experience = 0;
            baseExperience = 63;//

            SetBaseStats(50, 75, 35, 70, 30, 40);
            PermanentStatsManager.Instance.SetStats(this); //능력치 세팅

            CurrentHP = MaxHP;

            Skill vineWhip = new VineWhip(this);
            this.BasicSkill(vineWhip);
        }
    }
}
