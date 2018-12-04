namespace P02_Collection
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] input = Read().Split().Skip(1).ToArray();
            ListyIterator<string> listyIterator = new ListyIterator<string>(input);

            try
            {
                string command;
                while ((command = Read()) != "END")
                {
                    switch (command)
                    {
                        case "Move":
                            Console.WriteLine(listyIterator.Move());
                            break;
                        case "HasNext":
                            Console.WriteLine(listyIterator.HasNext());
                            break;
                        case "Print":
                            listyIterator.Print();
                            break;
                        case "PrintAll":
                            foreach (var item in listyIterator)
                            {
                                Console.Write($"{item} ");
                            }
                            Console.WriteLine();
                            break;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static string Read()
            => Console.ReadLine();
    }
}
