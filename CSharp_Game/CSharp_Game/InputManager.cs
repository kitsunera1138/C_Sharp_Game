using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Game
{
    internal class InputManager
    {
        private static InputManager instance;
        public static InputManager Instance
        {
            get //외부에서 접근 가능
            {
                if (instance == null)
                {
                    instance = new InputManager();
                }
                return instance;
            }
        }

        //인터페이스로 Select()구현?
        interface IInput
        {
            void Select();
        }

        //현재 x,y값을 통해 버튼 위치에서 Enter을 누를 시 선택함을 인식

        //버튼에 따라 공격, 도망가기, 스탯확인, 아이템등 사용 가능함
    }
}
