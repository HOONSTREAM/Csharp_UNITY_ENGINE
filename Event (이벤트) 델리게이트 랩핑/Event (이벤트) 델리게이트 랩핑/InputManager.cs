using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event__이벤트__델리게이트_랩핑
{
    //옵저버패턴
    class InputManager
    {

        public delegate void OninputKey();
        public event OninputKey inputkey; 

        public void Update()
        {
            if (Console.KeyAvailable == false)
                return;

            ConsoleKeyInfo info = Console.ReadKey();
            if(info.Key == ConsoleKey.A)
            {
                //모두에게 알려준다!
                inputkey();

            }


            

            
        }
    }
}
