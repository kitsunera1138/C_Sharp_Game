using CSharp_Game.Pokemon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Game
{
    internal class GameManager
    {
        private static GameManager instance;
        public static GameManager Instance
        {
            get //외부에서 접근 가능
            {
                if (instance == null)
                {
                    instance = new GameManager();
                }
                return instance;
            }
        }

        public void ChooseMainPokemon()
        {
            PokemonFactory pokemonFactory = new PokemonFactory();
            EnemyLogic enemyAI = new EnemyLogic();
            MapManager.Instance.setPokemonFactory(pokemonFactory);
            

            //팩토리에서 포켓몬 생성
            Pokemon.Pokemon playerPokemon = pokemonFactory.CreatePlayerPokemon();
            UIManager.ClearConsoleBuffer();
            Pokemon.Pokemon enemyPokemon = new Pokemon.Squirtle(); //Squirtle
            GameManager.Instance.PlayerPokemon(playerPokemon);
            GameManager.Instance.CurrentEnemyPokemon(enemyPokemon);
            enemyAI.CurrentEnemyPokemon(GameManager.Instance.enemyPokemon);

            //Console.WriteLine(playerPokemon.CurrentHP + "/" + playerPokemon.MaxHP);

            //싸움
            BattleTurnManager.Instance.PlayerPokemon(playerPokemon);
            BattleTurnManager.Instance.CurrentEnemyPokemon(enemyPokemon);

            playerPokemon.Level = 20;
            PermanentStatsManager.Instance.SetStats(playerPokemon);
            playerPokemon.CurrentHP = playerPokemon.MaxHP;

            while (playerPokemon.CurrentHP > 0 && enemyPokemon.CurrentHP > 0)
            {
                BattleTurnManager.Instance.ShowHealth();
                ChooseSkill();
                Console.WriteLine();
                enemyAI.ChooseAttack();

                BattleTurnManager.Instance.BattleTurn();
                UIManager.WaitForEnterBar(); 
                UIManager.ClearConsoleBuffer();
            }

            enemyAI.CurrentEnemyPokemon(GameManager.Instance.enemyPokemon);

            while (playerPokemon.CurrentHP > 0 && GameManager.Instance.enemyPokemon.CurrentHP > 0)
            {
                BattleTurnManager.Instance.CurrentEnemyPokemon(GameManager.Instance.enemyPokemon);
                //GameManager.Instance.enemyPokemon.ShowHealth();
                BattleTurnManager.Instance.ShowHealth();

                ChooseSkill();
                Console.WriteLine();
                enemyAI.ChooseAttack();
                BattleTurnManager.Instance.BattleTurn();
                UIManager.WaitForEnterBar(); 
                UIManager.ClearConsoleBuffer();
            }
        }

        void ChooseSkill()
        {
            Console.WriteLine("스킬을 선택하세요");
            playerPokemon.ShowCurrentSkill();

            int skillChoice = 0;

            // 선택할 수 있는 스킬의 개수 //예외처리
            int skillCount = playerPokemon.Skills.Count;

            while (skillChoice < 1 || skillChoice > skillCount)
            {
                if (int.TryParse(Console.ReadLine(), out skillChoice) && skillChoice >= 1 && skillChoice <= skillCount)
                {
                    playerPokemon.CurrentSkills = playerPokemon.Skills[skillChoice - 1];  // 선택한 스킬 할당
                }
                else
                {
                    Console.WriteLine("다시 선택하시오");
                }
            }
            UIManager.ClearConsoleBuffer();
        }

        private GameManager()
        {
        }

        public int CurrentMap =1;
        public Pokemon.Pokemon playerPokemon = null;
        public Pokemon.Pokemon enemyPokemon = null;
        //public A(Pokemon.Pokemon pokemon) => currentPokemon;

        public void PlayerPokemon(Pokemon.Pokemon playerPokemon)
        {
            this.playerPokemon = playerPokemon;
        }

        public void CurrentEnemyPokemon(Pokemon.Pokemon enemyPokemon)
        {
            this.enemyPokemon = enemyPokemon;
        }
        public void RandLevel(int i)
        {
            playerPokemon.Level += i;
        }
        public void EventMapRecovery() //전체 회복을 한다.
        {
            playerPokemon.CurrentHP = playerPokemon.MaxHP;

           foreach (var skill in playerPokemon.Skills)
            {
                skill.RecoveryPP();
            }
        }

        public void Win()
        {
            //승리시 다음 맵 카운트
            CurrentMap++;
        }

        public void GameOver()
        {
            Console.WriteLine();
            ConsoleColors.ChangeColor(COLORS.Red);
            Console.WriteLine("남은 체력이 0이 되었습니다.");
            Console.WriteLine(playerPokemon.name + "가(이)" + " 쓰러졌습니다");
            Console.WriteLine();
            Console.WriteLine("GameOver");
        }

        public void GameWin()
        {
            if(CurrentMap <= 10)
            {
                ConsoleColors.ChangeColor(COLORS.Cyan);
                Console.WriteLine();
                Console.WriteLine("승리하셨습니다. 다음 맵으로 넘어갑니다.");
                ConsoleColors.ResetColor();
                UIManager.WaitForEnterBar();
                UIManager.ClearConsoleBuffer();
                Win();
                MapManager.Instance.RandMap();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("모든 라운드에서 승리하셨습니다.");
                GameEnd();
            }

        }

        public void GameEnd()
        {
            ConsoleColors.ChangeColor(COLORS.Green);
            Console.WriteLine("모든 라운드에서 승리하셨습니다.");
        }

        //이름, 배틀 현황
        public void Attack( Pokemon.Pokemon AttackPokemon, Pokemon.Pokemon DamagePokemon) //c#은 클래스에 ref 필요 없어서 뺌
        {
            Console.WriteLine(AttackPokemon.name + " Attack : " + AttackPokemon.CurrentSkills + " ");
            Console.WriteLine(DamagePokemon.name +" Damage");
            
                //SkillDamage(ref AttackPokemon,ref DamagePokemon);

        } 

        //public void Heal(ref Pokemon.Pokemon HealPokemon)
        //{
        //    //힐 스킬 //스킬 클래스에서 
        //    int healAmount = HealPokemon.MaxHP * 60 / 100; //치유량
        //    HealPokemon.CurrentHP += healAmount;
        //    //최대 체력 초과하지 않도록
        //    HealPokemon.CurrentHP = Math.Min(HealPokemon.CurrentHP + healAmount, HealPokemon.MaxHP);

        //    //if (HealPokemon.CurrentHP > HealPokemon.MaxHP)
        //    //    HealPokemon.CurrentHP = HealPokemon.MaxHP;
        //}

        ////승리 시 경험치 획득 옵저버 패턴 사용
        //public void GetExperience(Pokemon.Pokemon getExperience, Pokemon.Pokemon knockedDownPokemon) //getExperience 경험치 획득하는 포켓몬
        //{
        //    getExperience.experience += (knockedDownPokemon.baseExperience * knockedDownPokemon.Level) / 5.0f;
        //}
        
        //public void LevelUp(ref Pokemon.Pokemon LevelUpPokemon)
        //{
        //    LevelUpPokemon.Level += 1;
        //}

        //레벨업에 따른 능력치 상승량
    }
}
