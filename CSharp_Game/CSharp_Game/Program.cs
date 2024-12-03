using CSharp_Game.Pokemon;
using CSharp_Game.Skill;
using static CSharp_Game.Skill.Skill;

namespace CSharp_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Pokemon.Pokemon pikachu = new Pokemon.Pikachu();
            pikachu.Information();
            Console.WriteLine();
            pikachu.ShowState();
            pikachu.LearnSkill(new Skill.Thunder(pikachu));
            
            GameManager.Instance.Attack(pikachu,pikachu);
        }
    }
}
