using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Game.Pokemon
{
    //레벨업에 따른 능력치 세팅
    public class PermanentStatsManager
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

        //개체값은 랜덤 노력치는 1로 세팅
        int IV = 1; //개체값 0~31 .. 6v
        int Ev = 1; //노력치는 한 스탯에 252 최대 종합 510
        int A = 1; //성격보정 1로세팅

        //경험치 매니저에서 레벨업 시 갱신 - 옵저버


        //생성자와 레벨업 이벤트시 호출
        public void SetStats(Pokemon target)
        {
            SetPermanentStats(target);
        }

        void SetHpStats(Pokemon target, int IVRandom)
        {
            IV = IVRandom; target.IV.Add(IV);
            //pokemonBaseStats의 경우 딕셔너리
            target.MaxHP =
            (int)(target.pokemonBaseStats[BASESTATS.BaseHp] * 2 + IV + (Ev / 4)) * target.Level / 100 + 10 + target.Level;
        }

        void SetOtherStats(Pokemon target, int IVRandom, BASESTATS stats)
        {
            IV = IVRandom; target.IV.Add(IV);
            int baseStats = target.pokemonBaseStats[stats];
            int result = (int)((baseStats * 2 + IV + (Ev / 4)) * target.Level / 100 + 5) * A;

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

        void SetPermanentStats(Pokemon target)
        {
            SetHpStats(target, IVRandom());
            //체력외에 다른 스탯은 같은 계산 공식을 사용
            //SetOtherStats();
            SetOtherStats(target, IVRandom(), BASESTATS.BaseAttack);
            SetOtherStats(target, IVRandom(), BASESTATS.BaseDefense);
            SetOtherStats(target, IVRandom(), BASESTATS.BaseSpAttack);
            SetOtherStats(target, IVRandom(), BASESTATS.BaseSpDefense);
            SetOtherStats(target, IVRandom(), BASESTATS.BaseSpeed);
        }

        int IVRandom() //개체값 랜덤 세팅
        {
            Random random = new Random();
            return random.Next(1, 32); //0~31
        }
    }
}
