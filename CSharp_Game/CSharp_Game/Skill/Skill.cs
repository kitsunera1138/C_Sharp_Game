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
    void Use(CSharp_Game.Pokemon.Pokemon enemyPokemon);
}

namespace CSharp_Game.Skill
{
    public class Skill
    {
        public int accuracy;//명중률
        public int evasion;//회피율

        public string skillName { get; set; }    
        public string skillType { get; set; }  
        public string attackType { get; set; } //물리인지 특수인지 공격 타입
                                               //Physical Attack 물리공격
                                               //Special Attack 특공
        public float power { get; set; }      
        public int PP { get; set; }


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
