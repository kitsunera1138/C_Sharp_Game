using CSharp_Game.Pokemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CSharp_Game
{
    internal class BattleManager
    {
        private static BattleManager instance;
        public static BattleManager Instance
        {
            get //외부에서 접근 가능
            {
                if (instance == null)
                {
                    instance = new BattleManager();
                }
                return instance;
            }
        }

        private readonly Random random = new Random();
        private bool isBarrier = false; //방어 했는지

        public void BattleReset()
        {
            //한 턴(배틀 턴)이 끝난후 배틀 세팅 리셋
            isBarrier = false;
        }

        void SkillBarriers(Skill skill, Pokemon.Pokemon SkillPokemon, Pokemon.Pokemon target)
        {
            //방어 상태일 경우 //방어 스킬의 경우 우선도가 높아서 먼저 들어옴
            if (skill.AttackType == ATTACKTYPE.Barrier)
            {
                isBarrier = true;
                Console.WriteLine(SkillPokemon + "은 방어하였다");
                return;
            }
        }

        public void Attack(Skill skill, Pokemon.Pokemon SkillPokemon, Pokemon.Pokemon target)
        {
            //방어 상태면 그 턴 동안 공격 못쓰도록 한다.
            if (isBarrier == true)
            {
                return;
            }

            //보류 - 적의 회피율과 나의 명중률 계산 //enemyPokemon.Evasion

            if (IsAttackHit(skill.accuracy)) //명중률에 따라 공격이 맞았는지 확인
            {
                //if(target.skillType, enemyPokemon.primaryType,enemyPokemon.secondaryType)
                SkillUse(skill,SkillPokemon,target);
            }
            else
            {
                Console.WriteLine("공격이 빗나갔다");
                //공격이 빗나감
            }
        }

        public void TypeCalculation(Skill skill, Pokemon.Pokemon damagedPokemon)
        {
            //나의 스킬과 상대 타입에 따른 효과
            float effectiveness = PokemonTypeManager.Instance.CalculateEffectiveness(skill, damagedPokemon);
            skill.TypeEffectiveness = effectiveness;

            if (effectiveness > 1.0)
            {
                ConsoleColors.ChangeColor(COLORS.Red);
                Console.WriteLine("효과가 굉장했다!");
                ConsoleColors.ResetColor();
            }
            else if (effectiveness < 1.0 && effectiveness > 0.0)
            {
                ConsoleColors.ChangeColor(COLORS.Gray);
                Console.WriteLine("효과가 별로인 것 같다.");
                ConsoleColors.ResetColor();
            }
            else if (effectiveness == 0.0)
            {
                Console.WriteLine("효과가 전혀 없다...");
            }
        }

        void SkillUse(Skill skill, Pokemon.Pokemon SkillPokemon, Pokemon.Pokemon damagedPokemon)
        {
            //TypeEffectiveness 게산하는거 타입 매니저에서 구현해줘야함 지금 기본 1
            Console.WriteLine(SkillPokemon.name + "의 " + skill.skillName + " 공격");
            TypeCalculation(skill, damagedPokemon);

            float damage = 1f;
            if (skill.AttackType == ATTACKTYPE.PhysicalAttack) //물리 타입
            {
                damage = ((2 * SkillPokemon.Level / 5 + 2) * skill.power * SkillPokemon.attack / damagedPokemon.defense) / 50 + 2;
                damage *= skill.TypeEffectiveness; //타입 효과 - 기술타입과 적 타입에 따라 효과
                damage *= skill.typeBonus; // 타입 보너스

                //대충 타입 매니저에서 비교해서 TypeEffectiveness 배율 확인 효과가 굉장했다 2, 효과가 별로인것 같다. 0.5, 효과가 전혀없다 0
            }
            else if(skill.AttackType == ATTACKTYPE.SpecialAttack)
            {
                damage = ((2 * SkillPokemon.Level / 5 + 2) * skill.power * SkillPokemon.spAttack / damagedPokemon.spDefense) / 50 + 2;
                damage *= skill.TypeEffectiveness; 
                damage *= skill.typeBonus; 
            }
            Console.WriteLine(damagedPokemon.name + (int)Math.Floor(damage)  + " 데미지");
            damagedPokemon.CurrentHP -= (int)Math.Floor(damage);
        }

        //현재 스킬과 현재 포켓몬 타입을 비교해서 같으면 위력을 1.2배로 올려줌 //Skill 자식 클래스에서 사용
        public float CompareSkillType(Skill skill, Pokemon.Pokemon target) //현재 스킬 타입과 // 스킬을 가지고 있는 포켓몬 타입 비교
        {
            if (target.primaryType.ToString() == skill.skillType.ToString() ||
                target.secondaryType.ToString() == skill.skillType.ToString())
            {
                return 1.2f;
            }
            else
            {
                return 1;
            }
        }

        public bool IsAttackHit(int randNum) //공격이 맞았는가 Accuracy
        {
            int chance = random.Next(0, 101);
            // randNum% 확률로 공격이 맞는지 확인
            return chance < randNum;
        }

        //상태 이상 .. 나와 상대턴 후 영향을 받음
        public void CurrentStatus(Pokemon.Pokemon target)
        {
            //포켓몬 상태이상 관리 메서드 ... 독상태일 경우 체력을 8/1 깍는다 등
            //target.status = "Normal"
            switch (target.status)
            {
                case "Normal":
                    break;
                case "Poison":
                    target.CurrentHP -= (target.CurrentHP / 8);
                    break;
                case "Paralysis":
                    target.speed /= 2;
                    break;
            }
        }
    }
}
