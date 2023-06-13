using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG_OOP_ver0._1
{
    public enum ClassType
    {
        None = 0,
        Knight = 1,
        Archor = 2,
        Mage = 3
    }
    class Player : Creature
    {
        protected ClassType Type;

        //Player 생성자를 protected로 접근한정자를 지정함으로써 직접적으로 Player를 생성할수는 없고, 직업을 통해서 간접적으로 생성하게끔 하였다. (은닉성)
        protected Player(ClassType type) :base(CreatureType.Player)  //부모 디폴트생성자는 이제 더이상 사용불가능. (명시적으로 정의하였기때문에)
        {
            this.Type = type;
        }

        public ClassType GetClassType() { return Type; }

    }

    class Knight :Player {

        
       public Knight() :base(ClassType.Knight)//생성자 접근한정자를 public으로 함으로써 외부에서 직접적으로 생성이 가능하다.
        {

            SetInfo(100, 10);
            
        } //생성자, 부모생성자 호출(base함수)
    }

    class Archor : Player {

       public Archor():base(ClassType.Archor) {

            SetInfo(75, 12);

        }
    }

    class Mage : Player { 
    
       public Mage():base(ClassType.Mage) {

            SetInfo(50, 15);

        }

    }

}
