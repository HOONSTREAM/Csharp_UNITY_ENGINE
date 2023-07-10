namespace Tree_트리_예제
{
    internal class Program
    {
        class TreeNode<T>
        {
            public T Data { get; set; }
           public List<TreeNode<T>> Children { get; set; } = new List<TreeNode<T>>();

        }

        static TreeNode<string> MakeTree()
        {
            TreeNode<string> root = new TreeNode<string>() { Data = "R1 개발실" };
            {
                {
                    TreeNode<string> node = new TreeNode<string>() { Data = "디자인팀" };
                    node.Children.Add(new TreeNode<string>() { Data = "경제" });
                    node.Children.Add(new TreeNode<string>() { Data = "전투" });
                    node.Children.Add(new TreeNode<string>() { Data = "스토리" });
                    root.Children.Add(node);
                }

                {
                    TreeNode<string> node = new TreeNode<string>() { Data = "프로그래밍팀" };
                    node.Children.Add(new TreeNode<string>() { Data = "서버" });
                    node.Children.Add(new TreeNode<string>() { Data = "클라이언트" });
                    node.Children.Add(new TreeNode<string>() { Data = "엔진" });
                    root.Children.Add(node);
                }

                {
                    TreeNode<string> node = new TreeNode<string>() { Data = "아트팀" };
                    node.Children.Add(new TreeNode<string>() { Data = "배경" });
                    node.Children.Add(new TreeNode<string>() { Data = "캐릭터" });
                    root.Children.Add(node);
                }
            }

            return root;

        }
        static void PrintTree(TreeNode<string> root)
        {
            Console.WriteLine(root.Data);
            foreach (TreeNode<string> child in root.Children) //재귀함수를 통해 구현
                PrintTree(child);

        }

        static int GetHeight(TreeNode<string> root)
        {
            int height = 0;
            foreach(TreeNode<string> child in root.Children)
            {
                int newHeight = GetHeight(child) +1 ;
                if(height<newHeight)
                   // height = newHeight; // 새로운 높이로 갱신
                   height = Math.Max(height, newHeight); // 둘중에 큰값을 height에 저장

            }


            return height;
        }





            static void Main(string[] args)
        {

            TreeNode<string> root = MakeTree();

            // PrintTree(root);

            Console.WriteLine(GetHeight(root));

        }
    }
}