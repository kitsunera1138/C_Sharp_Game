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
    internal class Pikachu : Pokemon //수정예정 이렇게 굳이 하나하나 포켓몬마다 할 필요없이 생성시 세팅하는게 나을수도// 스킬은 스킬매니저에서 이 포켓이 aa다 알려주고
    {
        //나중에 종족값에 자동으로 능력치 계산해주는 클래스로 빼야할듯

        //+ 알아서 원하는 포켓몬 생성 시 스탯 자동으로 해줘야
        public override POKEMONTYPE primaryType { get; set; } // 첫번째타입
        public override POKEMONTYPE secondaryType { get; set; } // 두번째타입
        public override int MaxHP { get; set ; }

        public override float baseExperience { get; set; }
        public override string name { get; set; }
        public Pikachu()
        {
            Initialize();
        }

        public Pikachu(string name,int level)
        {
            Initialize();

            this.Level = level;
            PermanentStatsManager.Instance.SetStats(this);
        }
        protected override void Initialize()
        {
            name = "피카츄";
            //PokemonTypeManager typeManager = new PokemonTypeManager();
            //타입 클래스로 받아와서 상성표 개별로? 전기클래스는 공격타입으로  뭐에약함 강함등 방어타입으로 ....
            primaryType = POKEMONTYPE.ELECTRIC;
            secondaryType = POKEMONTYPE.NONE;
            //Type = type;
            Level = 5;
            experience = 0;
            baseExperience = 112;

            SetBaseStats(35, 55, 40, 50, 50, 90);
            PermanentStatsManager.Instance.SetStats(this); //능력치 세팅
            
            CurrentHP = MaxHP;

            Skill thunderShock = new ThunderShock(this);
            this.BasicSkill(thunderShock);
            Skill thunder = new Thunder(this);
            this.BasicSkill(thunder);
            Skill surf = new Surf(this);
            this.BasicSkill(surf);

        }
    }
}
