namespace priorityQueue_우선순위큐_구현
{
    internal class Program
    {

        class PriorityQueue
        {
            List<int> _heap = new List<int>();
            public int Pop() 
            {
                //반환할 데이터를 따로 저장한다.

                int ret = _heap[0];
                
                // 마지막 데이터의 루트로 이동

                int lastindex = _heap.Count - 1;
                _heap[0] = _heap[lastindex];
                _heap.RemoveAt(lastindex);
                lastindex--;

                //역으로 내려가기
                int now = 0; // 첫위치는 루트노드이므로

                while (true)
                {
                    int left = 2 * now + 1; //공식
                    int right = 2 * now + 2; //공식

                    int next = now;
                    //왼쪽값이 현재 값보다 크면 왼쪽으로 이동
                    if (left <= lastindex && _heap[next] < _heap[left])
                        next = left;
                    //오른쪽 값이 현재 값보다 크면 오른쪽으로 이동
                    if(right <= lastindex && _heap[next] < _heap[right])
                        next = right;
                    //왼쪽,오른쪽 모두 현재값보다 작으면 종료
                    if (next == now)
                        break;

                    //두 값을 교체
                    int temp = _heap[now];
                    _heap[now] = _heap[next];
                    _heap[next] = temp;

                    //검사위치 이동
                    now = next;


                }

                return ret;

            }
            public void Push(int data)
            {
                //힙의 맨 끝에 새로운 데이터를 삽입한다.
                _heap.Add(data);

                int now = _heap.Count - 1; // 현재 인덱스

                while (now > 0) //도장깨기 시작 (힙정렬 시작)
                {
                    int next = (now-1) / 2; //부모 인덱스
                    if (_heap[now] < _heap[next]) // 부모가 자식보다 크면 중지
                        break;
                    //두 값을 교체
                    int temp = _heap[now];
                    _heap[now] = _heap[next];
                    _heap[next] = temp;

                    //검사위치를 이동한다.

                    now = next;


                }

            }
            public int count()
            {
                return _heap.Count();
            }
        }

        static void Main(string[] args)
        {
            PriorityQueue queue = new PriorityQueue();

            queue.Push(15);
            queue.Push(231);
            queue.Push(134);
            queue.Push(123);
            queue.Push(13);

            while (queue.count() > 0)
            {
                Console.WriteLine(queue.Pop());
            }

        }
    }
}