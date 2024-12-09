using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Game.Pokemon
{
    internal class ExperienceManager
    {
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

        public void LevelUp()
        {
            //레벨 업에 따른 포켓몬 스탯 갱신
            playerPokemon.Level += 1;
            PermanentStatsManager.Instance.SetStats(playerPokemon);
            Console.WriteLine("레벨업: " + playerPokemon.Level);
        }
        void A(Pokemon playerPokemon)
        {
            playerPokemon.Level = 50;
        }


    }
}
