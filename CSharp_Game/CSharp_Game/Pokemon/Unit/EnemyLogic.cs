using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Game.Pokemon
{
    internal class EnemyLogic
    {
        public Pokemon enemyPokemon = null;

        public void CurrentEnemyPokemon(Pokemon enemyPokemon)
        {
            this.enemyPokemon = enemyPokemon;
        }

        public void ChooseAttack()
        {
            //if (this.enemyPokemon.CurrentHP < this.enemyPokemon.MaxHP / 2)
            //{
            //    //보류
            //}

            //효과가 굉장한 기술을 찾아 그 기술 사용
            for (int i = 0; i < enemyPokemon.Skills.Count; i++)
            {
                float num = PokemonTypeManager.Instance.CalculateEffectiveness(enemyPokemon.Skills[i], GameManager.Instance.playerPokemon);

                if (num > 1)
                {
                    enemyPokemon.CurrentSkills = enemyPokemon.Skills[i];
                }
                else
                {
                    enemyPokemon.CurrentSkills = enemyPokemon.Skills[0];
                }
            }

            //Console.WriteLine(enemyPokemon.name + "은" + enemyPokemon.CurrentSkills.skillName + "사용");
        }

    }
}
