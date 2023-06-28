 using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace 프레임_관리
{

    class MyLinkedListNode<T>
    {
        public T Data;
        public MyLinkedListNode<T> Next; //본체가 아닌 참조형식으로 주소를 저장하고 있다.
        public MyLinkedListNode<T> Prev; //상동

    }

    class MyLinkedList<T>
    {
        public MyLinkedListNode<T> Head = null; //첫번째
        public MyLinkedListNode<T> Tail = null; //마지막

        public int count = 0;

        
        //상수시간복잡도
        public MyLinkedListNode<T> AddLast(T data)
        {
            MyLinkedListNode<T> newRoom = new MyLinkedListNode<T>();
            newRoom.Data = data;

            if (Head == null) //만약 아직 방이 아예 없었다면 새로 추가한 것이 곧 첫번째 방이다.
                Head = newRoom;

            //기존의 마지막 방과 새로 추가되는 방을 연결시켜준다.
            if (Tail != null)
            {
                Tail.Next = newRoom;
                newRoom.Prev = Tail;

            }
            //새로 추가되는 방을 마지막 방으로 인정한다.
            Tail = newRoom;
            count++;

            return newRoom;

        }
        //상수시간복잡도
        public void Remove(MyLinkedListNode<T> room)
        {
            if (Head == room) // 지우려는 원소가 첫번째 원소이면
                Head = Head.Next; // 두번째 방을 첫번째 방으로 변경

            if(Tail==room) // 지우려는 원소가 마지막 원소이면
                Tail= Tail.Prev; // 마지막 이전 원소를 마지막 원소로 변경

            // 101 102 103 104 105
            if (room.Prev != null) // 지우려는 원소의 이전 원소가 null이 아니라면
                room.Prev.Next = room.Next; // 지우려는 원소의 [이전원소의 다음방]은 [지우려는 원소의 다음방]이 되어야 한다. 즉 
                                            // 지우려는 원소가 103이라면 102의 다음 원소는 104가 되어야 한다.
            if (room.Next!=null) //지우려는 원소의 다음 원소가 null이 아니라면
                room.Next.Prev = room.Prev;  //지우려는 원소의 [다음원소의 이전방]은 나의 이전원소가 되어야한다. 즉 103이라면 104가 102랑 연결되어야 한다.

            count--;

        }

    }
   
    internal class Board
    {

       // public int[] _data = new int[25]; // 배열 :맵을 그릴때는 가장 사용하기 좋음. (삽입,삭제가 일어나지않음)
       //public List<int>_data2 = new List<int>(); //동적배열
        public LinkedList<int> _data3 = new LinkedList<int>(); //연결리스트  

        public void initialize()
        {
            _data3.AddLast(101);
            _data3.AddLast(102);
           LinkedListNode<int> node =  _data3.AddLast(103);
            _data3.AddLast(104);
            _data3.AddLast(105);

            _data3.Remove(node);

        }
    }
}
