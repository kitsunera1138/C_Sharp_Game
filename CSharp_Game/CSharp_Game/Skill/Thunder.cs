using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CSharp_Game.Skill.Skill;

namespace CSharp_Game.Skill
{
    public class Thunder : Skill, ISkill  //스킬에 전략 패턴?
    {
        Pokemon.Pokemon learnPokemon = null;

        public Thunder(Pokemon.Pokemon pokemon) //기술을 배운 포켓몬의 타입을 가져옴
        {
            learnPokemon = pokemon;
            skillName = "Thunder";
            //타입 매니저로 수정 예정
            skillType = "Electric";
            attackType = "Special Attack";
            power = 110;
            PP = 10;
            accuracy = 70; //명중률

            // 타입이 같으면 1.2배 확인 
            if (skillType == learnPokemon.type)
                power *= 1.2f;
        }

        public void Use(Pokemon.Pokemon enemyPokemon)
        {
            Accuracy(enemyPokemon);
            power *= TypeCalculation(enemyPokemon);

            //타입 계산
            //learnPokemon.type
            //enemyPokemon.type 

            //명중률에 따른 정확도
        }

        public int TypeCalculation(Pokemon.Pokemon enemyPokemon)
        {
            int resultpower = 1;
            //skillType의 타입과  enemyPokemon.type적의 타입에 따라 power 배력
            return resultpower;
        }

        public void Accuracy(Pokemon.Pokemon enemyPokemon)
        {
            //적의 회피율과 나의 명중률 계산
            //enemyPokemon.Evasion


        }
    }
}
