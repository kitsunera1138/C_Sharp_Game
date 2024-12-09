using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Game.Pokemon
{
    public enum EXGROWTHRATE
    {
        Fast,
        MediumFast,
        MediumSlow,
        Slow
    }

    internal class ExperienceManager : IObserver
    {
        //그냥 옵저버로?
        //public event Action<Pokemon> OnLevelUp;

        //경험치 매니저
        //옵저버 패턴으로 구현예정
        //레벨업에 따른 다른 클래스 참조
        private static ExperienceManager instance;
        public static ExperienceManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ExperienceManager();
                }
                return instance;
            }
        }

    
       // private List<ILevelUpObserver> observers = new List<ILevelUpObserver>();


        //한 클래스 객체에서 참조 객체 받아 올 수도 있지만 커플링 방지로 따로 받음
        public Pokemon playerPokemon = null;
        public void PlayerPokemon(Pokemon playerPokemon)
        {
            this.playerPokemon = playerPokemon;
        }

        EXGROWTHRATE exGrowThrate;

        public static int GetExperienceForLevel(int level, EXGROWTHRATE growthRate) //레벨업에 필요한 경험치
        {
            switch (growthRate)
            {
                case EXGROWTHRATE.Fast:
                    return (int)(4 * Math.Pow(level, 3) / 5);
                case EXGROWTHRATE.MediumFast:
                    return (int)Math.Pow(level, 3);
                case EXGROWTHRATE.MediumSlow:
                    return (int)(1.2 * Math.Pow(level, 3) - 15 * Math.Pow(level, 2) + 100 * level - 140);
                case EXGROWTHRATE.Slow:
                    return (int)(5 * Math.Pow(level, 3) / 4);
                default:
                    throw new ArgumentException("Invalid growth rate");
            }
        }

        public void GainExperience(Pokemon target, int gainedExperience)
        {
            target.experience += gainedExperience;
            Console.WriteLine("현재 경험치: " + target.experience + " 필요 경험치: " + GetExperienceForLevel(target.Level + 1, target.eXGROWTHRATE));
            // 레벨업 체크
            while (target.experience >= GetExperienceForLevel(target.Level + 1, target.eXGROWTHRATE))
            {
                target.Level++;
                Console.WriteLine($"{target.name} has leveled up to Level {target.Level}!");

                Console.WriteLine("레벨업을 했다");
                // 레벨업 이벤트 발생
                //OnLevelUp?.Invoke(target);
            }
        }

        public void LevelUp()
        {
            //레벨 업에 따른 포켓몬 스탯 갱신
            playerPokemon.Level += 1;
            PermanentStatsManager.Instance.SetStats(playerPokemon);
            Console.WriteLine("레벨업: " + playerPokemon.Level);

            if(playerPokemon.experience > playerPokemon.nextExperience)
            {

            }
        }

        public void Update(string message)
        {
            if (message == "PlayerWin1")
            {
                Console.WriteLine("Player의 승리 Ex" +(int)GameManager.Instance.GetExperienceforTarget(playerPokemon, GameManager.Instance.enemyPokemon));
                //경험치

                GainExperience(playerPokemon, (int)GameManager.Instance.GetExperienceforTarget(playerPokemon, GameManager.Instance.enemyPokemon));
            }
        }

    }
}
