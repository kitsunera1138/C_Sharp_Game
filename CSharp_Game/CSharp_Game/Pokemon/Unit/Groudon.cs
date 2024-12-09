using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Game.Pokemon
{
    internal class Groudon : Pokemon //수정예정 이렇게 굳이 하나하나 포켓몬마다 할 필요없이 생성시 세팅하는게 나을수도// 스킬은 스킬매니저에서 이 포켓이 aa다 알려주고
    {
        //나중에 종족값에 자동으로 능력치 계산해주는 클래스로 빼야할듯

        //+ 알아서 원하는 포켓몬 생성 시 스탯 자동으로 해줘야
        public override POKEMONTYPE primaryType { get; set; } // 첫번째타입
        public override POKEMONTYPE secondaryType { get; set; } // 두번째타입
        public override int MaxHP { get; set; }

        public override float baseExperience { get; set; }
        public override string name { get; set; }
        public Groudon()
        {
            Initialize();
        }

        public Groudon(string name, int level)
        {
            Initialize();

            this.Level = level;
            PermanentStatsManager.Instance.SetStats(this);
        }
        protected override void Initialize()
        {
            name = "그란돈";

            primaryType = POKEMONTYPE.FIRE;
            secondaryType = POKEMONTYPE.NONE;
            //Type = type;
            Level = 10;
            experience = 0;
            baseExperience = 302;

            SetBaseStats(100, 150, 140, 100, 90, 90);
            PermanentStatsManager.Instance.SetStats(this); //능력치 세팅

            CurrentHP = MaxHP;
        }
    }
}
