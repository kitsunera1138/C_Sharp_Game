using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_Game.Pokemon;

namespace CSharp_Game.Pokemon
{
    //전략 패턴으로 바꿀지 생각
    enum PokemonType{
        WATER,
        FIRE,
        GRASS,
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

public class FIRE : IType
{
    //상성표 //공격타입에는 뭐가 강함, 방어타입에는 뭐가 강함등

    
} 

public class WATER
{

}