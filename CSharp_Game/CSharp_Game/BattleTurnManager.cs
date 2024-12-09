using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Game
{
    internal class BattleTurnManager
    {
        private static readonly Random random = new Random();

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

        public void PlayerPokemon(Pokemon.Pokemon playerPokemon)
        {
            this.playerPokemon = playerPokemon;
        }
        public void CurrentEnemyPokemon(Pokemon.Pokemon enemyPokemon)
        {
            this.enemyPokemon = enemyPokemon;
        }

        public void BattleTurn()
        {
            //한 턴은 서로 공격을 주고 받았을 경우
            Speed();
            ShowHealth();
        }
        public void ShowHealth()
        {
            Console.WriteLine();
            Console.WriteLine(playerPokemon.name + "   LV."+playerPokemon.Level + ": " + playerPokemon.CurrentHP + "/" + playerPokemon.MaxHP);
            if(enemyPokemon.CurrentHP > 0)
            Console.WriteLine(enemyPokemon.name + "   LV." + enemyPokemon.Level + ": " + enemyPokemon.CurrentHP + "/" + enemyPokemon.MaxHP);
            Console.WriteLine();
        }
        //선제 포켓몬 //포켓몬의 스피드 비교
        //우선도 비교? Priority

        public void Speed()
        {
            if (playerPokemon.speed > enemyPokemon.speed)
            {
                PlayerAttack();
                //수정 필요 버그 생겨서
                if (enemyPokemon.CurrentHP > 0) 
                {
                    EnemyAttack();
                }
                else
                {
                    return;
                }
            }
            else if (playerPokemon.speed < enemyPokemon.speed)
            {
                EnemyAttack();
                //수정 필요 버그 생겨서
                if (playerPokemon.CurrentHP > 0)
                {
                    PlayerAttack();
                }
                else
                {
                    return;
                }
            }
            else //speed 동일 시 랜덤으로 공격
            {
                RandomAttack();
            }
        }
        void PlayerAttack()
        {
            playerPokemon.CurrentSkills.Use(enemyPokemon);

            if (enemyPokemon.CurrentHP <= 0)
            {
                Console.WriteLine(enemyPokemon.name + "을(를) 쓰러뜨렸다");
                GameManager.Instance.GameWin();
                return;
            }
        }
        void EnemyAttack()
        {
            enemyPokemon.CurrentSkills.Use(playerPokemon);

            if (playerPokemon.CurrentHP <= 0)
            {
                GameManager.Instance.GameOver();
                return;
            }
        }

        void RandomAttack()
        {
            int randomNum = random.Next(0, 2); //0,1
            if (randomNum == 0)
            {
                PlayerAttack();
                EnemyAttack();
            }
            else
            {
                EnemyAttack();
                PlayerAttack();
            }
        }
    }
}
