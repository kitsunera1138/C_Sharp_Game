using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CSharp_Game.Pokemon;
using CSharp_Game;
using static CSharp_Game.Skill;



public interface ISkill
{
    void Use(Pokemon target);
}

namespace CSharp_Game
{
    abstract public class Skill : ISkill
    {
        public abstract string skillName { get; set; }
        public abstract ATTACKTYPE AttackType { get; set; } //물리 특공 방어 회복 능력치 증가 기술중 무슨 타입인가 //나중에 클래스로 나누기
        public abstract SKILLTYPE skillType { get; set; }  //스킬 타입

        public int accuracy;//명중률
        public int evasion;//회피율

        public float power { get; set; } //위력
        public float typeBonus = 1; //포켓몬 타입과 기술 타입이 같을 경우
        public float TypeEffectiveness =1; //상대 포켓몬과의 상성
        public abstract int maxPP { get; set; } //최대 pp
        public abstract int currentPP { get; set; } //현재 pp

        public int Priority = 1; //기술 우선도.. 방어의 경우 4
        public string skill_Information = "skill 입니다.";

        protected Pokemon.Pokemon pokemon; //이 기술을 배운 포켓몬

        //필요 레벨
        //public abstract int Requiredlevel { get; set; }
        // 현재 맵은 GameManager의 CurrentMap을 직접 참조
        //public Pokemon.Pokemon target = null;
        //public int Level => target.Level;
        public void RecoveryPP() //pp 회복
        {
            currentPP = maxPP;
        }

        public abstract void Use(Pokemon.Pokemon target);
    }
}
