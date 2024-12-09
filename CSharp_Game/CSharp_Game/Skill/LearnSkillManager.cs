using CSharp_Game.Pokemon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Game
{
    internal class LearnSkillManager
    {
        public Pokemon.Pokemon target;
        public Skill skill;

        //전체 스킬 목록
        public List<Skill> skills;

        //배울수 있는 스킬 (메서드 매개변수로 선택)

        Dictionary<Skill, int> skillMap = new Dictionary<Skill, int>(); //필요레벨
        int skilllevel;
        int nextlevel;

        #region 보류

        //모든 스킬목록 여기에

        //포켓몬 aa에서 알아서 리스트 뽑아가도록 함

        //public static void SetSkills(Pokemon.Pokemon pokemon)
        //{
        //    pokemon.LearnSkill(new Skill.Thunder());

        //    // 예시: Pikachu는 'Thunderbolt', 'Quick Attack'을 배운다
        //    if (pokemon is Pikachu)
        //    {
        //        pokemon.AddSkill(new Skill(Thu));
        //        pokemon.AddSkill(new Skill("Quick Attack"));
        //    }
        //    // 다른 포켓몬의 스킬도 이와 유사하게 설정
        //}

        //포켓몬 리스트에 return해줌
        //그렇게 되면 포켓몬 learnSkill 딕셔너리에 넣어줌

        //이제 포켓몬은 레벨업 시 딕셔너리에 맞는 Dictionary<Skill.Skill, int> learnSkill 값을 찾아서 int형을 찾아서 배울 것인지 선택하게 한 후에  
        //포켓몬의 public List<ISkill> Skills { get; set; } //배우고 있는 스킬
        //갱신
        #endregion




    }
}
