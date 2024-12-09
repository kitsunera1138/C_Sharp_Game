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
    internal class Pidgey : Pokemon
    {
        public override POKEMONTYPE primaryType { get; set; } // 첫번째타입
        public override POKEMONTYPE secondaryType { get; set; } // 두번째타입
        public override int MaxHP { get; set; }

        public override float baseExperience { get; set; }
        public override string name { get; set; }
        public Pidgey()
        {
            Initialize();
        }

        protected override void Initialize()
        {
            name = "구구";

            primaryType = POKEMONTYPE.NORMAL;
            secondaryType = POKEMONTYPE.FLYING;

            Level = 5;
            experience = 0;
            baseExperience = 63; //

            SetBaseStats(40, 45, 40, 35, 35, 56);
            PermanentStatsManager.Instance.SetStats(this); //능력치 세팅

            CurrentHP = MaxHP;

            Skill peck = new Peck(this);
            this.BasicSkill(peck);
            Skill wingAttack = new WingAttack(this);
            this.BasicSkill(wingAttack);
        }
    }
}
