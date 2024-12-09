using CSharp_Game.Pokemon;
using CSharp_Game;
using static CSharp_Game.Skill;

namespace CSharp_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {

            UIManager.MainMenuScene();

            //PokemonFactory pokemonFactory = new PokemonFactory();
            //MapManager.Instance.setPokemonFactory(pokemonFactory);
            //AI enemyAI = new AI();

            ////팩토리에서 포켓몬 생성
            //Pokemon.Pokemon playerPokemon =  pokemonFactory.CreatePlayerPokemon();

            ////Pokemon.Pokemon playerPokemon = new Pokemon.Pikachu(); //Pikachu
            //Pokemon.Pokemon enemyPokemon = new Pokemon.Squirtle(); //Squirtle

            //Skill thunder = new Thunder(playerPokemon);
            //Skill thunderShock = new ThunderShock(enemyPokemon);

            //playerPokemon.LearnSkill(thunder);
            //playerPokemon.EnemySkill(thunderShock);

            
            //enemyAI.CurrentEnemyPokemon(enemyPokemon);


            //Console.WriteLine(playerPokemon.CurrentHP +"/"+ playerPokemon.MaxHP);
            //GameManager.Instance.PlayerPokemon(playerPokemon);
            //GameManager.Instance.CurrentEnemyPokemon(enemyPokemon);
            //BattleTurnManager.Instance.PlayerPokemon(playerPokemon);
            //BattleTurnManager.Instance.CurrentEnemyPokemon(enemyPokemon);

            //playerPokemon.Level = 50;
            //PermanentStatsManager.Instance.SetStats(playerPokemon);
            //playerPokemon.CurrentHP = playerPokemon.MaxHP;

            //while (playerPokemon.CurrentHP >0 && enemyPokemon.CurrentHP >0) {

            //    Console.WriteLine();

            //    playerPokemon.CurrentSkills = playerPokemon.Skills[1];
            //    enemyAI.ChooseAttack();

            //    //playerPokemon.CurrentSkills.Use(enemyPokemon);
                
            //    BattleTurnManager.Instance.BattleTurn();
            //}

            //enemyAI.CurrentEnemyPokemon(GameManager.Instance.enemyPokemon);

            //while (playerPokemon.CurrentHP > 0 && GameManager.Instance.enemyPokemon.CurrentHP > 0)
            //{

            //    Console.WriteLine();

            //    playerPokemon.CurrentSkills = playerPokemon.Skills[1];
            //    enemyAI.ChooseAttack();

            //    //playerPokemon.CurrentSkills.Use(enemyPokemon);

            //    BattleTurnManager.Instance.BattleTurn();
            //}

            //BattleTurnManager.Instance.BattleTurn();


            //enemyPokemon.CurrentSkills = enemyPokemon.Skills[0];


            //UIManager.MainMenuScene();

            //MapManager.Instance.Initialize();
            //MapManager.Instance.MapChanged();
            //Console.WriteLine(MapManager.Instance.WildPLevel);

            //필요없PermanentStatsManager statsManager = new PermanentStatsManager();

            //Pokemon.Pokemon playerPokemon = new Pokemon.Pikachu();
            //Pokemon.Pokemon enemyPokemon = new Pokemon.Jigglypuff();

            //playerPokemon.Level = 50;
            //변화가 일어나며  PermanentStatsManager.Instance.SetStats(playerPokemon);
            //이거 수정
            //playerPokemon.CurrentHP = playerPokemon.MaxHP;


            //uimanager 에서 참조
            //GameManager.Instance.PlayerPokemon(playerPokemon);
            //GameManager.Instance.CurrentEnemyPokemon(enemyPokemon);

            {
                //BattleTurnManager.Instance.SetPokemons(playerPokemon, enemyPokemon);
                //GameManager.Instance.PlayerPokemon(playerPokemon, enemyPokemon);

                //UIManager.MainMenuScene();
                //UIManager.GameScene();
                //ExperienceManager.Instance.PlayerPokemon(playerPokemon);
                ////만약 ExperienceManager에서 플레이어 참조 별로 안쓰면 LevelUp(playerPokemon)에서 참조받도록 수정
                //ExperienceManager.Instance.LevelUp();
                //ExperienceManager.Instance.LevelUp();
                //ExperienceManager.Instance.LevelUp();
            }


            //Console.WriteLine(playerPokemon.Level);

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
