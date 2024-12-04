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
    }
}
