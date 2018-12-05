namespace P09_Linked_List_Traversal
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var info = Console.ReadLine().Split();

                int num = int.Parse(info[1]);

                switch (info[0])
                {
                    case "Add":
                        list.Add(num);
                        break;
                    case "Remove":
                        list.Remove(num);
                        break;
                }
            }

            Console.WriteLine(list.Count);
            Console.WriteLine(string.Join(' ', list));
        }
    }
}
