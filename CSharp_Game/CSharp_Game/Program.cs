using CSharp_Game.Pokemon;
using CSharp_Game.Skill;
using static CSharp_Game.Skill.Skill;

namespace CSharp_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //UIManager.MainMenuScene();
            PermanentStatsManager statsManager = new PermanentStatsManager();

            Pokemon.Pokemon playerPokemon = new Pokemon.Pikachu();
            Pokemon.Pokemon enemyPokemon = new Pokemon.Jigglypuff();

            //playerPokemon.Level = 50;
            //statsManager.SetStats(playerPokemon);
            //이거 수정
            //playerPokemon.CurrentHP = playerPokemon.MaxHP;
            //playerPokemon.ShowState();
            //playerPokemon.IVInformation();


            BattleTurnManager.Instance.SetPokemons(playerPokemon, enemyPokemon); 
            GameManager.Instance.PlayerPokemon(playerPokemon, enemyPokemon);
            UIManager.GameScene();

            {
                //GameManager.Instance.PlayerPokemon(playerPokemon);

                //UIManager.GameScene();
                //playerPokemon.Information();
                //Console.WriteLine();
                //playerPokemon.ShowState();
                //playerPokemon.LearnSkill(new Skill.Thunder(playerPokemon));

                //UIManager.ClearConsoleBuffer();
                //playerPokemon.CurrentSkills = playerPokemon.Skills[0];
                //Pokemon.Pokemon jigglypuff = new Pokemon.Jigglypuff();
                ////현재 배틀중인 포켓몬 세팅
                ////그냥 겜 매니저에 세팅해서 여기서 계속 가져올까..
                //BattleTurnManager.Instance.SetPokemons(playerPokemon, jigglypuff);

                //while (playerPokemon.CurrentHP > 0 && jigglypuff.CurrentHP > 0) //수정예정 //
                //{
                //    //변경
                //    BattleTurnManager.Instance.BattleTurn();
                //}
                //GameManager.Instance.GameWin();
                //    //GameManager.Instance.Attack(pikachu, jigglypuff);
            }
        }
    }
}
