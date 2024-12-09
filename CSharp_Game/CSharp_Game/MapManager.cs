using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_Game.Pokemon;

namespace CSharp_Game
{
    enum CURRENTMAP //기본 맵 라운드 1,2,4,5,7,8에 랜덤으로 등장
    {
        SunnyLand,        // 햇빛이 강하다 (불, 땅)
        ThunderMountain,  // 번개가 친다 (전기)
        ShallowForest,    // 풀들이 살랑거린다 (풀)
        RainyForest,      // 풀숲에 비가 내린다 (물)
        DeepForest,       // 숲이 울창하다 (풀, 벌레)
        PsychicMountain,  // 염력의 산 (에스퍼)
    }

    enum EVENTMAP{ //맵 라운드 3,6,9에 랜덤으로 등장
        HealingSpring,    // 회복의 샘물
        LevelUpChest,     // 상자를 찾았다
        EeveeSwarm        // 이브이 무리를 만났다
    }

    enum LEGENDARYMAP // 맵 라운드 10에 랜덤으로 하나 등장
    {
        LavaField,        // 용암 지대 (그란돈)
        DeepSea,          // 깊은 바다 (가이오가)
        SkyRuins,         // 깊은 하늘 (레쿠쟈)
    }

    //맵 종류
    //햇빛이 강하다(따뜻한 대지) 불, 땅
    //번개가 친다.(거친 산) 전기
    //풀들이 살랑거린다(얕은 숲) 풀
    //풀숲에 비가 내린다.(얕은 숲:비) 물
    //숲이 울창하다(깊은 숲)풀, 벌레
    //주변의 사물이 떠오른다(염력의 산)에스퍼 ..메탕..

    //붉은 글씨로
    //전설 타입 10라운드에 무조건 나오는 전설 포켓몬 - 도망 불가능
    //용암이 들끓고 땅이 갈라진다(용암 지대 - 그란돈)
    //물이 차오르고 바다가 집어 삼킨다(깊은바다? - 가이오가)
    //하늘이 요동치며 주변을 집어 삼킨다 (깊은 하늘 - 레쿠쟈)

    //이벤트 맵
    //회복의 샘물 : 포켓몬의 체력을 모두 회복한다

    //상자를 찾았다 : 레벨업을 한다 (레벨은 이제 3개중에 올라서 1,2,3까지)

    //이브이 무리를 만났다 - 능력치 상승.. 상승스탯은 따로 변수를 뒤서 능력치 계산후에 마지막에 더해줌
    //이브이가 선물을 건네준다.
    //1. 불의 돌: 공격과 특수 공격이 상승했다. (+5)
    //2. 물의 돌: 방어력과 특수 방어가 상승했다 (+5)
    //3. 천둥의 돌: 체력이 상승했다 (+5)

    //인터페이스 써서 사용
    //상태패턴써서 

    internal class MapManager : IObserver
    {
        //싱글톤 패턴
        private static MapManager instance;
        public static MapManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MapManager();
                }
                return instance;
            }
        }

        private readonly Random random = new Random();

        //맵에 따라 야생 포켓몬 레벨 + 종류를PokemonFactory에서
        //이 매니저는 맵 종류 구현

        // 현재 맵은 GameManager의 CurrentMap을 직접 참조
        public int CurrentMap => GameManager.Instance.CurrentMap;

        Dictionary<int, CURRENTMAP> MapName = new Dictionary<int, CURRENTMAP>(); //현재 층수, 현재 맵
        public CURRENTMAP currentMap;
        public LEGENDARYMAP legendMap;
        private int wildPLevel = 5; //야생 포켓몬은 기본 5레벨이었다가 층수에 따라 1씩 증가
        public int WildPLevel {  get { return wildPLevel; } }
        private PokemonFactory pokemonFactory;

        private MapManager() //싱글톤으로 구현했기에 private로 설정
        {
            
        }

        public void setPokemonFactory(PokemonFactory pokemonFactory)
        {
            this.pokemonFactory = pokemonFactory;
        }
        public void Initialize() //초기화 작업
        {
            //포켓몬 팩토리 생성
            //pokemonFactory = new PokemonFactory();

            // 팩토리 생성
            //var pokemonFactory = new PokemonFactory();
        }



        //맵 이동을 이벤트로 받았으면 야생 포켓몬 레벨을 올려줌
        public void MapChanged()
        {
            wildPLevel++;
        }

        //private CURRENTMAP previousMap;

        public CURRENTMAP GetRandomMap()
        {
            Array mapValues = Enum.GetValues(typeof(CURRENTMAP));
            // Random으로 하나 선택
            return (CURRENTMAP)mapValues.GetValue(random.Next(mapValues.Length));
        }

        public void RandMap()
        {
            if(CurrentMap < 10)
            {
                CURRENTMAP randomMap = GetRandomMap();
                pokemonFactory.CreateRandomPokemon(randomMap);
            }

            if (CurrentMap == 10)
            {
                LegendaryMap();
            }

            if (CurrentMap > 10)
            {
                GameManager.Instance.GameEnd();
            }
        }

        void EventMap()
        {
            CURRENTMAP randomMap = GetRandomMap();
            pokemonFactory.CreateRandomPokemon(randomMap);
        }

        public void LegendaryMap()
        {
            legendMap = LEGENDARYMAP.LavaField;
            pokemonFactory.LegendaryPokemon(legendMap);

            { //보류
                //전설의 포켓몬이 등장

                //전설 타입 10라운드에 무조건 나오는 전설 포켓몬 - 도망 불가능

                //용암이 들끓고 땅이 갈라진다(용암 지대 - 그란돈)
                //물이 차오르고 바다가 집어 삼킨다(깊은바다? - 가이오가)
                //하늘이 요동치며 주변을 집어 삼킨다 (깊은 하늘 - 레쿠쟈)

                //저 3개중에 등장
            }

        }

        //옵저버
        public void Update(string message) 
        {
            if (message == "MapChange")
            {
                HandleMapChange();
            }

            if(message == "End")
            {
                Console.WriteLine("게임이 종료되었습니다.");
                //GameManager.Instance.Unsubscribe(this);
            }
        }

        private void HandleMapChange()
        {
            //옵저버 받음
            Console.WriteLine("맵이 변경되었습니다!");
            // 새로운 맵 로직 추가
            RandMap();
        }
    }
}
