using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Game.Pokemon
{
    //레벨업에 따른 능력치 세팅
    public class PermanentStatsManager //포켓몬 마다 사용할 예정으로 싱글톤 패턴 사용
    {
        private static PermanentStatsManager instance;
        public static PermanentStatsManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PermanentStatsManager();
                }
                return instance;
            }
        }

        //노력치 최대값
        private const int MaxEV = 252;
        private const int TotalMaxEV = 510;
        private const int MaxIV = 31;

        //개체값은 랜덤 노력치는 1로 세팅
        private int IV = 1; //개체값 0~31 .. 6v
        private int Ev = 1; //노력치는 한 스탯에 252 최대 종합 510
        private int pokemonNature = 1; //성격보정 1로세팅
        //성격 구현 가능하다면 어느 한 가지 스탯을 1.1배 상승시키고, 다른 한 가지 스탯을 0.9배 하락 기능

        private readonly Random random = new Random();

        //경험치 매니저에서 레벨업 시 갱신 - 옵저버
        //경험치 매니저? 구현해서 거기서 옵저버 패턴

        //생성자와 레벨업 이벤트시 호출
        public void SetStats(Pokemon target)
        {
            SetPermanentStats(target);
        }

        void SetHpStats(Pokemon target, int IVRandom)
        {
            IV = IVRandom; target.IV.Add(IV);
            //pokemonBaseStats의 경우 딕셔너리로 구현 Dictionary<BASESTATS, int> 
            target.MaxHP =
            (int)(target.pokemonBaseStats[BASESTATS.BaseHp] * 2 + IV + (Ev / 4)) * target.Level / 100 + 10 + target.Level;
        }

        void SetOtherStats(Pokemon target, int IVRandom, BASESTATS stats)
        {
            IV = IVRandom; target.IV.Add(IV);
            int baseStats = target.pokemonBaseStats[stats];
            int result = (int)((baseStats * 2 + IV + (Ev / 4)) * target.Level / 100 + 5) * pokemonNature;

            switch (stats)
            {
                case BASESTATS.BaseAttack:
                    target.attack = result;
                    break;
                case BASESTATS.BaseDefense:
                    target.defense = result;
                    break;
                case BASESTATS.BaseSpAttack:
                    target.spAttack = result;
                    break;
                case BASESTATS.BaseSpDefense:
                    target.spDefense = result;
                    break;
                case BASESTATS.BaseSpeed:
                    target.speed = result;
                    break;
            }
        }

        int IVRandom() //개체값 랜덤 세팅
        {
            return random.Next(1, MaxIV +1); //0~31
        }

        void SetPermanentStats(Pokemon target)
        {
            //Hp
            SetHpStats(target, IVRandom());

            //체력외에 다른 스탯은 같은 계산 공식을 사용
            SetOtherStats(target, IVRandom(), BASESTATS.BaseAttack);
            SetOtherStats(target, IVRandom(), BASESTATS.BaseDefense);
            SetOtherStats(target, IVRandom(), BASESTATS.BaseSpAttack);
            SetOtherStats(target, IVRandom(), BASESTATS.BaseSpDefense);
            SetOtherStats(target, IVRandom(), BASESTATS.BaseSpeed);
        }
    }
}
