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
    internal class Charmander : Pokemon //수정예정 이렇게 굳이 하나하나 포켓몬마다 할 필요없이 생성시 세팅하는게 나을수도// 스킬은 스킬매니저에서 이 포켓이 aa다 알려주고
    {
        //나중에 종족값에 자동으로 능력치 계산해주는 클래스로 빼야할듯

        //+ 알아서 원하는 포켓몬 생성 시 스탯 자동으로 해줘야
        public override POKEMONTYPE primaryType { get; set; } // 첫번째타입
        public override POKEMONTYPE secondaryType { get; set; } // 두번째타입
        public override int MaxHP { get; set; }

        public override float baseExperience { get; set; }
        public override string name { get; set; }
        public Charmander()
        {
            Initialize();
        }

        public Charmander(string name, int level)
        {
            Initialize();

            this.Level = level;
            PermanentStatsManager.Instance.SetStats(this);
        }
        protected override void Initialize()
        {
            name = "파이리";

            primaryType = POKEMONTYPE.FIRE;
            secondaryType = POKEMONTYPE.NONE;
            //Type = type;
            Level = 5;
            experience = 0;
            baseExperience = 62;

            SetBaseStats(39, 52, 43, 60, 50, 65);
            PermanentStatsManager.Instance.SetStats(this); //능력치 세팅

            CurrentHP = MaxHP;

            Skill ember = new Ember(this);
            this.EnemySkill(ember);
        }
    }
}
