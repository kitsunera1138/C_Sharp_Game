using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp_Game.Pokemon;

namespace CSharp_Game.Pokemon
{
    //전략 패턴으로 바꿀지 생각

    internal class PokemonTypeManager
    {
        private static PokemonTypeManager instance;
        public static PokemonTypeManager Instance
        {
            get //외부에서 접근 가능
            {
                if (instance == null)
                {
                    instance = new PokemonTypeManager();
                }
                return instance;
            }
        }
        #region 타입 상성 테이블 - Dictionary<(string, string), double> 나중에 수정 필요
        // 타입 상성 테이블 (string 키 사용) enum형으로 skilltype과 pokemontype을 따로 해서 string으로 비교 함 
        //보류 -혹은 전략 패턴으로 타입별 인터페이스 클래스 다 나누기 가능 //이걸로 바꿔야 될듯..;;
        private static readonly Dictionary<(string, string), double> EffectivenessTable = new()
        {
            { ("NORMAL", "ROCK"), 0.5 }, { ("NORMAL", "GHOST"), 0.0 },
            { ("FIRE", "GRASS"), 2.0 }, { ("FIRE", "BUG"), 2.0 }, { ("FIRE", "STEEL"), 2.0 },
            { ("FIRE", "WATER"), 0.5 }, { ("FIRE", "ROCK"), 0.5 }, { ("FIRE", "FIRE"), 0.5 },
            { ("WATER", "FIRE"), 2.0 }, { ("WATER", "GROUND"), 2.0 }, { ("WATER", "ROCK"), 2.0 },
            { ("WATER", "WATER"), 0.5 }, { ("WATER", "GRASS"), 0.5 },
            { ("GRASS", "WATER"), 2.0 }, { ("GRASS", "GROUND"), 2.0 }, { ("GRASS", "ROCK"), 2.0 },
            { ("GRASS", "FIRE"), 0.5 }, { ("GRASS", "STEEL"), 0.5 }, { ("GRASS", "GRASS"), 0.5 },
            { ("GRASS", "FLYING"), 0.5 }, { ("GRASS", "BUG"), 0.5 },
            { ("ELECTRIC", "WATER"), 2.0 }, { ("ELECTRIC", "FLYING"), 2.0 },
            { ("ELECTRIC", "ELECTRIC"), 0.5 }, { ("ELECTRIC", "GRASS"), 0.5 }, { ("ELECTRIC", "GROUND"), 0.0 },
            { ("ICE", "GRASS"), 2.0 }, { ("ICE", "GROUND"), 2.0 }, { ("ICE", "FLYING"), 2.0 }, { ("ICE", "DRAGON"), 2.0 },
            { ("ICE", "FIRE"), 0.5 }, { ("ICE", "WATER"), 0.5 }, { ("ICE", "STEEL"), 0.5 },
            { ("FIGHTING", "NORMAL"), 2.0 }, { ("FIGHTING", "ROCK"), 2.0 }, { ("FIGHTING", "STEEL"), 2.0 },
            { ("FIGHTING", "ICE"), 2.0 }, { ("FIGHTING", "DARK"), 2.0 },
            { ("FIGHTING", "POISON"), 0.5 }, { ("FIGHTING", "FLYING"), 0.5 },
            { ("FIGHTING", "PSYCHIC"), 0.5 }, { ("FIGHTING", "BUG"), 0.5 }, { ("FIGHTING", "GHOST"), 0.0 },
            { ("POISON", "GRASS"), 2.0 }, { ("POISON", "FAIRY"), 2.0 },
            { ("POISON", "POISON"), 0.5 }, { ("POISON", "GROUND"), 0.5 }, { ("POISON", "ROCK"), 0.5 }, { ("POISON", "GHOST"), 0.5 },
            { ("POISON", "STEEL"), 0.0 },
            { ("GROUND", "FIRE"), 2.0 }, { ("GROUND", "ELECTRIC"), 2.0 }, { ("GROUND", "POISON"), 2.0 },
            { ("GROUND", "ROCK"), 2.0 }, { ("GROUND", "STEEL"), 2.0 },
            { ("GROUND", "GRASS"), 0.5 }, { ("GROUND", "BUG"), 0.5 }, { ("GROUND", "FLYING"), 0.0 },
            { ("FLYING", "GRASS"), 2.0 }, { ("FLYING", "FIGHTING"), 2.0 }, { ("FLYING", "BUG"), 2.0 },
            { ("FLYING", "ELECTRIC"), 0.5 }, { ("FLYING", "ROCK"), 0.5 }, { ("FLYING", "STEEL"), 0.5 },
            { ("PSYCHIC", "FIGHTING"), 2.0 }, { ("PSYCHIC", "POISON"), 2.0 },
            { ("PSYCHIC", "PSYCHIC"), 0.5 }, { ("PSYCHIC", "DARK"), 0.0 }, { ("PSYCHIC", "STEEL"), 0.5 },
            { ("BUG", "GRASS"), 2.0 }, { ("BUG", "PSYCHIC"), 2.0 }, { ("BUG", "DARK"), 2.0 },
            { ("BUG", "FIRE"), 0.5 }, { ("BUG", "FIGHTING"), 0.5 }, { ("BUG", "POISON"), 0.5 },
            { ("BUG", "FLYING"), 0.5 }, { ("BUG", "ROCK"), 0.5 }, { ("BUG", "STEEL"), 0.5 },
            { ("ROCK", "FIRE"), 2.0 }, { ("ROCK", "ICE"), 2.0 }, { ("ROCK", "FLYING"), 2.0 }, { ("ROCK", "BUG"), 2.0 },
            { ("ROCK", "FIGHTING"), 0.5 }, { ("ROCK", "GROUND"), 0.5 }, { ("ROCK", "STEEL"), 0.5 },
            { ("GHOST", "GHOST"), 2.0 }, { ("GHOST", "PSYCHIC"), 2.0 }, { ("GHOST", "NORMAL"), 0.0 },
            { ("DRAGON", "DRAGON"), 2.0 }, { ("DRAGON", "STEEL"), 0.5 }, { ("DRAGON", "FAIRY"), 0.0 },
            { ("DARK", "PSYCHIC"), 2.0 }, { ("DARK", "GHOST"), 2.0 },
            { ("DARK", "FIGHTING"), 0.5 }, { ("DARK", "DARK"), 0.5 }, { ("DARK", "FAIRY"), 0.5 },
            { ("STEEL", "ROCK"), 2.0 }, { ("STEEL", "ICE"), 2.0 }, { ("STEEL", "FAIRY"), 2.0 },
            { ("STEEL", "FIRE"), 0.5 }, { ("STEEL", "WATER"), 0.5 }, { ("STEEL", "ELECTRIC"), 0.5 }, { ("STEEL", "STEEL"), 0.5 },
            { ("FAIRY", "FIGHTING"), 2.0 }, { ("FAIRY", "DRAGON"), 2.0 }, { ("FAIRY", "DARK"), 2.0 },
            { ("FAIRY", "POISON"), 0.5 }, { ("FAIRY", "STEEL"), 0.5 }, { ("FAIRY", "FIRE"), 0.5 }
        };
        #endregion

        public float CalculateEffectiveness(Skill skill, Pokemon damagedPokemon)
        {
            float effectiveness = 1.0f;

            // 스킬 타입과 포켓몬의 첫 번째 타입 비교
            if (EffectivenessTable.TryGetValue((skill.skillType.ToString(), damagedPokemon.primaryType.ToString()), out double primaryEffect))
            {
                effectiveness *= (float)primaryEffect;
            }

            // 스킬 타입과 포켓몬의 두 번째 타입 비교
            if (EffectivenessTable.TryGetValue((skill.skillType.ToString(), damagedPokemon.secondaryType.ToString()), out double secondaryEffect))
            {
                effectiveness *= (float)secondaryEffect;
            }

            return effectiveness;
        }

    }

}

//보류
public interface IType //인터페이스 사용
{
    float GetEffectivenessAgainst(IType targetType); // 상성 계산 메서드
    float GetDefenseEffectiveness(IType targetType); //방어 상성 메서드
    string GetTypeName(); // 타입 이름 반환
}

public class FIRE : IType
{
    //상성표 //공격타입에는 뭐가 강함, 방어타입에는 뭐가 강함등
    public float GetEffectivenessAgainst(IType targetType)
    {
        return targetType.GetTypeName() switch
        {
            "GRASS" => 2.0f,
            "ICE" => 2.0f,
            "BUG" => 2.0f,
            "STEEL" => 2.0f,
            "FIRE" => 0.5f,
            "WATER" => 0.5f,
            "ROCK" => 0.5f,
            "DRAGON" => 0.5f,
            _ => 1.0f, //default 기본 처리 방식
        };
    }

    public float GetDefenseEffectiveness(IType attackingType)
    {
        return attackingType.GetTypeName() switch
        {
            "WATER" => 2.0f,
            "ROCK" => 2.0f,
            "GROUND" => 2.0f,
            "GRASS" => 0.5f,
            "ICE" => 0.5f,
            "BUG" => 0.5f,
            "STEEL" => 0.5f,
            "FIRE" => 0.5f,
            _=> 1.0f,
        };
    }

    public string GetTypeName() => "FIRE";
}

public class WATER
{

}