using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Game
{
    internal class BattleTurnManager
    {
        //참조 변수
        private Pokemon.Pokemon playerPokemon;
        private Pokemon.Pokemon enemyPokemon;

        private static BattleTurnManager instance;
        public static BattleTurnManager Instance
        {
            get //외부에서 접근 가능
            {
                if (instance == null)
                {
                    instance = new BattleTurnManager();
                }
                return instance;
            }
        }

        public void SetPokemons(Pokemon.Pokemon player, Pokemon.Pokemon enemy)
        {
            this.playerPokemon = player;
            this.enemyPokemon = enemy;
        }

        public void BattleTurn()
        {
            //한 턴은 서로 공격을 주고 받았을 경우
            Speed();
        }
        void ShowHealth()
        {
            Console.WriteLine();
            Console.WriteLine(playerPokemon.name + ": " + playerPokemon.CurrentHP + "/" + playerPokemon.MaxHP);
            Console.WriteLine(enemyPokemon.name + ": " + enemyPokemon.CurrentHP + "/" + enemyPokemon.MaxHP);
            Console.WriteLine();
        }
        //선제 포켓몬 //포켓몬의 스피드 비교
        public void Speed()
        {
            ShowHealth();

            if (playerPokemon.speed > enemyPokemon.speed)
            {
                PlayerAttack();
                EnemeyAttack();
            }
            else if (playerPokemon.speed < enemyPokemon.speed)
            {
                EnemeyAttack();
                PlayerAttack();
            }
            else //speed 동일 시 랜덤으로 공격
            {
                RandomAttack();
            }
        }

        void PlayerAttack()
        {
            //대충 다른 클래스에서 들고옴
            Console.WriteLine("Player " + playerPokemon.name + "의 공격");
            enemyPokemon.CurrentHP -= 10;
            Console.WriteLine("Enemy " + enemyPokemon.name + "의 남은 체력:" + enemyPokemon.CurrentHP);
            Console.WriteLine();
        }
        void EnemeyAttack()
        {
            //대충 다른 클래스에서 들고옴
            Console.WriteLine("Enemy " + enemyPokemon.name + "의 공격");
            playerPokemon.CurrentHP -= 10;
            Console.WriteLine("Player " + playerPokemon.name + "의 남은 체력:" + playerPokemon.CurrentHP);
            Console.WriteLine();
        }

        void RandomAttack()
        {
            Random random = new Random();
            int randomNum = random.Next(0, 2); //0,1
            if (randomNum == 0)
            {
                PlayerAttack();
                EnemeyAttack();
            }
            else
            {
                EnemeyAttack();
                PlayerAttack();
            }
        }
    }
}
