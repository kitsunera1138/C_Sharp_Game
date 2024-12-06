using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Game.Pokemon
{
    internal class PokemonFactory
    {
        //포켓몬 생성 클래스
        //메인말고 객체 생성을 여기서 해줌

        private static readonly Random random = new Random(); //private static으로 난수 고정 값 해결

        //여기서 이제 능력치 세팅 등 맵매니저에서 참조해서 세팅
        //private MapManager mapManager;

        PokemonFactory()
        {
            //mapManager = new MapManager();
            Pokemon enemyPokemon = new Jigglypuff();
            enemyPokemon.Level = MapManager.Instance.WildPLevel;
        }
        void CreateRandomPokemon()
        {

            switch (MapManager.Instance.CurrentMap)
            {

            }
        }
    }
}
