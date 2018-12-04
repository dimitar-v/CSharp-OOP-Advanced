namespace P03_Stack
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();

            string input;
            while ((input = Read()) != "END")
            {
                switch (input)
                {
                    case "Pop":
                        try
                        {
                            stack.Pop();
                        }
                        catch (InvalidOperationException e)
                        {
                            Write(e.Message);
                        }
                        break;
                    default:
                        var elements = input.Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                            .Skip(1)
                            .ToArray();

                        stack.Push(elements);
                        break;
                }
            }

            Write(string.Join(Environment.NewLine, stack));
            Write(string.Join(Environment.NewLine, stack));
        }

        private static string Read()
            => Console.ReadLine();

        private static void Write(string message)
            => Console.WriteLine(message);
    }
}
