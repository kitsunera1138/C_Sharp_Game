using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_Game.Pokemon;

namespace CSharp_Game
{
    enum CURRENTMAP
    {

    }

    internal class MapManager
    {
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
        //맵에 따라 야생 포켓몬 레벨 + 종류를PokemonFactory에서
        //이 매니저는 맵 종류 구현

        // 현재 맵은 GameManager의 CurrentMap을 직접 참조
        public int CurrentMap => GameManager.Instance.CurrentMap;
        Dictionary<int, CURRENTMAP> MapName = new Dictionary<int, CURRENTMAP>();
        private int wildPLevel = 5;
        public int WildPLevel {  get { return wildPLevel; } }

        public MapManager()
        {
        }

        //맵 이동을 이벤트로 받았으면
        void MapChanged()
        {
            wildPLevel++;
        }
    }
}
