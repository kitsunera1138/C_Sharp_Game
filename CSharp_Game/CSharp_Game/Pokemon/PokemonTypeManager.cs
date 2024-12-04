using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Game.Pokemon
{
    //전략 패턴으로 바꿀지 생각
    enum PokemonType{
        FIRE,
        GRASS,
        WATER,
        ICE,
        DRAGON,
        FLYING,
        POISON,
        ELECTRIC,
        FAIRY,
        NORMAL

    }
    internal class PokemonTypeManager
    {
        public string Type { get; set; } // 타입

        public string primaryType { get; set; } // 첫번째타입
        public string secondaryType { get; set; } // 두번째타입
    }
    public interface IType
    {

    }

    public interface IItem
    {
        void Use();
    }
}
