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

        void A(Pokemon playerPokemon)
        {
            playerPokemon.Level = 50;
        }
    }
}
