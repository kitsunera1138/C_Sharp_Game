using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Game
{
    //싱글톤 패턴
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

        public GameManager()
        {
            Initialize();
        }

        void Initialize() //초기화 함수
        {
            
        }

        public int CurrentMap =1;
        public Pokemon.Pokemon currentPokemon = null;
        public Pokemon.Pokemon enemyPokemon = null;
        public void PlayerPokemon(Pokemon.Pokemon currentPokemon, Pokemon.Pokemon enemyPokemon)
        {
            this.currentPokemon = currentPokemon;
            this.enemyPokemon = enemyPokemon;
        }

        public void Win()
        {
            //승리시 다음 맵 카운트
            CurrentMap++;
        }

        public void GameOver()
        {
            Console.WriteLine("남은 체력이 0이 되었습니다. GameOver");
        }

        public void GameWin()
        {
            Console.WriteLine("승리하셨습니다. 다음 맵으로 넘어갑니다.");
        }

        public void GameEnd()
        {
            Console.WriteLine("모든 라운드에서 승리하셨습니다.");
        }

        //이름, 배틀 현황
        public void Attack( Pokemon.Pokemon AttackPokemon, Pokemon.Pokemon DamagePokemon) //c#은 클래스에 ref 필요 없어서 뺌
        {
            Console.WriteLine(AttackPokemon.name + " Attack : " + AttackPokemon.CurrentSkills + " ");
            Console.WriteLine(DamagePokemon.name +" Damage");
            
                //SkillDamage(ref AttackPokemon,ref DamagePokemon);

        } 

        public void Heal(ref Pokemon.Pokemon HealPokemon)
        {
            //힐 스킬 //스킬 클래스에서 
            int healAmount = HealPokemon.MaxHP * 60 / 100; //치유량
            HealPokemon.CurrentHP += healAmount;
            //최대 체력 초과하지 않도록
            HealPokemon.CurrentHP = Math.Min(HealPokemon.CurrentHP + healAmount, HealPokemon.MaxHP);

            //if (HealPokemon.CurrentHP > HealPokemon.MaxHP)
            //    HealPokemon.CurrentHP = HealPokemon.MaxHP;
        }

        //승리 시 경험치 획득 옵저버 패턴 사용
        public void GetExperience(Pokemon.Pokemon getExperience, Pokemon.Pokemon knockedDownPokemon) //getExperience 경험치 획득하는 포켓몬
        {
            getExperience.experience += (knockedDownPokemon.baseExperience * knockedDownPokemon.Level) / 5.0f;
        }
        
        public void LevelUp(ref Pokemon.Pokemon LevelUpPokemon)
        {
            LevelUpPokemon.Level += 1;
        }

        //레벨업에 따른 능력치 상승량
    }
}
