using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Game
{
    internal class BattleManager<T>
    {
        //배틀 데미지
        //참조 변수
        private Skill.Skill currentSkill;

        public void SelectSkill(Skill.Skill currentSkill)
        {
            this.currentSkill = currentSkill;
        }


        public void CurrentStatus(Pokemon.Pokemon target)
        {
            //포켓몬 상태이상 관리 메서드 ... 독상태일 경우 체력을 8/1 깍는다 등
            //target.status = "Normal"
                switch (target.status)
            {
                case "Normal":
                    break;
            }
        }
    }
}
