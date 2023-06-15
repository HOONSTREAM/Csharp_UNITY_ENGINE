using System.Xml.Schema;

namespace 연습문제_2강
{
    class Program
    {
      
        static int GetHighestScore(int[] scores)
        {
            int i = 0;
            int HighestValue = scores[0];


            foreach (var score in scores)
            {
                if (scores[i] > HighestValue)
                  
                HighestValue = scores[i];

                i++;
            }

            return HighestValue;
            
         }

         

        static int GetAvarageScore(int[] scores)
        {
            int TotalValue = 0;

            for (int i = 0; i < scores.Length; i++)
            {
                TotalValue += scores[i];
            }

            int AverageValue = TotalValue/ scores.Length;


            return AverageValue;
        }

        static int GetIndexOf(int[] scores,int value)
        {
            int i = 0;

            while (true) {

                i++;

                if(scores[i] == value) 
                break;

            }

            return i+1;
        }

        static void bubble_sort(int[] scores, int count)    // 매개변수로 정렬할 배열과 요소의 개수를 받음
        {
            int temp;

            for (int i = 0; i < count; i++)    // 요소의 개수만큼 반복
            {
                for (int j = 0; j < count - 1; j++)   // 요소의 개수 - 1만큼 반복
                {
                    if (scores[j] > scores[j + 1])          // 현재 요소의 값과 다음 요소의 값을 비교하여
                    {                                 // 큰 값을
                        temp = scores[j];
                        scores[j] = scores[j + 1];
                        scores[j + 1] = temp;            // 다음 요소로 보냄
                    }
                }
            }
        }


        static void Main(string[] args)
        {
            int[] score = new int[5] { 10, 30, 40, 20, 50 };
            int HighestValue = GetHighestScore(score);

            Console.WriteLine(HighestValue);

            int AverageValue = GetAvarageScore(score);
            Console.WriteLine(AverageValue);

            int SearchValue = GetIndexOf(score,40);

            Console.WriteLine($"찾는 값은 {SearchValue} 번째에 있습니다.");

            bubble_sort(score, 5);

            for(int i = 0; i < score.Length; i++)
            {
                Console.Write(score[i]);
                Console.Write(" ");
                
            }



        }
    }
}