 using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace 프레임_관리
{
    class MyList<T>
    {
        const int Default_size = 1;

        T[] data = new T[Default_size];
        public int Count; // 실제로 사용중인 데이터 갯수
        public int capacity { get { return data.Length; } } // 예약된 데이터 갯수

        public void Add(T item)
        {
            // 1.공간이 충분한지 확인한다.
            // 2. 공간이 확보됐으면 데이터를 넣어준다.
            // 시간복잡도 : 상수시간복잡도 O(1) 이다. -> if문은 제외 (연산이 안된다고 가정한다.)
            if (Count >= capacity)
            {
                //공간을 다시 늘려서 확보한다.
                T[] newArray = new T[Count * 2];
                for (int i = 0; i < Count; i++)
                    newArray[i] = data[i];
                data = newArray; // 임시로 확보한 newArray를 data와 최종적인 바꿔치기.

            }
            data[Count] = item;
            Count++;


        }

        // 인덱서 시간복잡도 O(1)
        public T this[int index]
        {

            get { return data[index]; }
            set { data[index] = value; }
        }

        // RemoveAt 시간복잡도 최악의 경우 O(N) for문
        public void RemoveAt(int index)
        {
            for(int i = index; i< Count-1; i++)
            {
                data[i] = data[i + 1];
                data[Count-1] = default(T); // int 형이면 0 , 클래스타입이면 null로 초기화
                Count--;

            }
        }


    }
    internal class Board
    {

        public int[] _data = new int[25]; // 배열 :맵을 그릴때는 가장 사용하기 좋음. (삽입,삭제가 일어나지않음)
        public List<int>_data2 = new List<int>(); //동적배열
        public LinkedList<int> _data3 = new LinkedList<int>(); //연결리스트  

        public void initialize()
        {
            _data2.Add(101);
            _data2.Add(102);
            _data2.Add(103);
            _data2.Add(104);
            _data2.Add(105);

            int temp = _data2[2];

            _data2.RemoveAt(2);



        }
    }
}
