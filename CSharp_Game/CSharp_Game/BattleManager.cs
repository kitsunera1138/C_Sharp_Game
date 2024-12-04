using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Game
{
    internal class BattleManager
    {
        //배틀 데미지
        //참조 변수
        private Skill.Skill currentSkill;

        public void SelectSkill(Skill.Skill currentSkill)
        {
            this.currentSkill = currentSkill;
        }



    }
}
