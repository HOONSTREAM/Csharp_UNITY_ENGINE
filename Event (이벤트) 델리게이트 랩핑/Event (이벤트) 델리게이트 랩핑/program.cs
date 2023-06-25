namespace Event__이벤트__델리게이트_랩핑
{
    internal class Program
    {
        static void OninputTest()
        {

            Console.WriteLine("input received 구독완료");
        }
        static void Main(string[] args)
        {
            InputManager inputmanager = new InputManager();

            inputmanager.inputkey += OninputTest;

            while (true){

                inputmanager.Update();

            }


        }
    }
}