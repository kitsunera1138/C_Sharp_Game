using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Game.Pokemon
{
    //팩토리 패턴을 사용
    //포켓몬 생성 클래스
    //메인말고 객체 생성을 여기서 해줌

    internal class PokemonFactory
    {
        private static readonly Random random = new Random(); //private static으로 난수 고정 값 해결

        public PokemonFactory()
        {
        }

        private static readonly string[] availablePokemon = { "파이리", "이상해씨", "꼬부기", "피카츄" };

        public Pokemon CreatePlayerPokemon()
        {
            Console.WriteLine("1. 파이리");
            Console.WriteLine("2. 이상해씨");
            Console.WriteLine("3. 꼬부기");
            Console.WriteLine("4. 피카츄");
            Console.WriteLine("원하는 포켓몬을 선택하세요 (1~4):");

            int choice = -1;
            while (choice < 1 || choice > 4)
            {
                if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 4)
                {
                    // 선택된 번호에 맞는 포켓몬을 반환
                    return CreatePokemon(availablePokemon[choice - 1]);
                }
                else
                {
                    Console.WriteLine("다시 선택하세요");
                }
            }
            return null;
        }
        private Pokemon CreatePokemon(string pokemonType)
        {
            switch (pokemonType)
            {
                case "파이리":
                    return new Charmander();
                case "이상해씨":
                    return new Bulbasaur();
                case "꼬부기":
                    return new Squirtle();
                case "피카츄":
                    return new Pikachu();
                default:
                    throw new ArgumentException("오류");
            }
        }

        const int PokemonCount = 3;

        void CreateRandomPokemon(int ranNum)
        {
            ranNum = random.Next(0, PokemonCount + 1); //0~3
        }
        public void EventMap(EVENTMAP map)
        {
            switch (map)
            {
                case EVENTMAP.HealingSpring:
                    GameManager.Instance.EventMapRecovery();
                    break;
                case EVENTMAP.LevelUpChest:
                    GameManager.Instance.RandLevel(3);
                    break;
                case EVENTMAP.EeveeSwarm:      // 이브이 무리를 만났다
                    break;
                default:
                    break;
            }
        }
        // 랜덤 포켓몬 생성
        public void CreateRandomPokemon(CURRENTMAP map)
        {
            //Console.WriteLine(map);
            Pokemon wildPokemon;

            // 맵에 따라 다른 포켓몬 생성
            switch (map)
            {
                case CURRENTMAP.SunnyLand:
                    wildPokemon = new Charmander();
                    break;
                case CURRENTMAP.ThunderMountain:
                    wildPokemon = new Pikachu();
                    break;
                case CURRENTMAP.ShallowForest:
                    wildPokemon = new Bulbasaur();
                    break;
                case CURRENTMAP.RainyForest:
                    wildPokemon = new Squirtle();
                    break;                
                
                case CURRENTMAP.DeepForest: //벌레
                    wildPokemon = new Caterpie();
                    break;                
                case CURRENTMAP.PsychicMountain: //에스퍼
                    wildPokemon = new Caterpie();
                    break;
                default:
                    wildPokemon = new Abra(); // 기본값
                    break;
            }

            // 레벨 설정
            wildPokemon.Level = GameManager.Instance.CurrentMap + 4;
            PermanentStatsManager.Instance.SetStats(wildPokemon);
            wildPokemon.CurrentHP = wildPokemon.MaxHP;

            Console.WriteLine("현재 층: "+ GameManager.Instance.CurrentMap);
            Console.WriteLine("현재 맵: "+ map);
            Console.WriteLine($"야생 포켓몬: {wildPokemon.name}의 등장");
            GameManager.Instance.CurrentEnemyPokemon(wildPokemon);
            //BattleTurnManager.Instance.CurrentEnemyPokemon(wildPokemon);
        }



        public void LegendaryPokemon(LEGENDARYMAP map)
        {
            //Console.WriteLine(map);
            Pokemon wildPokemon;

            // 맵에 따라 다른 포켓몬 생성
            switch (map)
            {
                case LEGENDARYMAP.LavaField:
                    wildPokemon = new Groudon();
                    break;
                default:
                    wildPokemon = new Groudon(); // 기본값
                    break;
            }

            // 레벨 설정
            wildPokemon.Level = GameManager.Instance.CurrentMap + 4;
            PermanentStatsManager.Instance.SetStats(wildPokemon);
            wildPokemon.CurrentHP = wildPokemon.MaxHP;

            Console.WriteLine("현재 층: " + GameManager.Instance.CurrentMap);
            Console.WriteLine("현재 맵: " + map);
            Console.WriteLine($"야생 포켓몬: {wildPokemon.name}의 등장");
            GameManager.Instance.CurrentEnemyPokemon(wildPokemon);
            //BattleTurnManager.Instance.CurrentEnemyPokemon(wildPokemon);
        }
    }
}
