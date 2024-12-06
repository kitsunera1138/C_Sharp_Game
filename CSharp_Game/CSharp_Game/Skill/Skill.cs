using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CSharp_Game.Pokemon;
using CSharp_Game.Skill;
using static CSharp_Game.Skill.Skill;

public interface ISkill
{
    void Use(CSharp_Game.Pokemon.Pokemon SkillUsePokemon);
}

namespace CSharp_Game.Skill
{
    abstract public class Skill
    {
        public int accuracy;//명중률
        public int evasion;//회피율

        public string skillName { get; set; }
        public string skillType { get; set; }  //스킬 타입
        public string attackType { get; set; } //물리인지 특수인지 공격 타입
                                               //Physical Attack 물리공격
                                               //Special Attack 특공
                                               //혹은 회복스킬
                                               //능력치 업 스킬
                                               //방어 스킬

        public float power { get; set; }
        public int PP { get; set; }

        //필요 레벨
        public abstract int Requiredlevel { get; set; }
        // 현재 맵은 GameManager의 CurrentMap을 직접 참조


        public Pokemon.Pokemon target = null;
        public int Level => target.Level;
        public Skill() {
            
        }

        //보류
        //ublic int Priority { get; set; } //기술 우선도 

        //public List<string> CurrentSkills { get; set; } //현재 기술 목록
        //public List<string> Skills { get; set; } //배울수 있는 기술 목록

        //스킬 타입
        //PokemonTypeManager  type;
        //Pokemon.PokemonType =;

        //public void SkillDamage(ref Pokemon.Pokemon AttackPokemon, ref Pokemon.Pokemon DamagePokemon)
        //{
        //    //타입 계산
        //}
        //
        //public PokemonSkill(string name, int power, string type)
        //{

        //}
        //public PokemonSkill AttackA()
        //{
        //    return new Skill("AttackA", 50, "Normal");
        //}




    }


}
