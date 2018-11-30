namespace P09_Custom_List_Iterator
{
    using System;

    class CommandInterpreter
    {
        private ICustomList<string> customList;

        public CommandInterpreter()
        {
            customList = new CustomList<string>();
        }

        public void Action(string[] args)
        {
            string element;
            int index;

            switch (args[0])
            {
                case "Add":
                    element = args[1];
                    customList.Add(element);
                    break;
                case "Remove":
                    index = int.Parse(args[1]);
                    customList.Remove(index);
                    break;
                case "Contains":
                    element = args[1];
                    Print(customList.Contains(element).ToString());
                    break;
                case "Swap":
                    index = int.Parse(args[1]);
                    var index2 = int.Parse(args[2]);
                    customList.Swap(index, index2);
                    break;
                case "Greater":
                    element = args[1];
                    Print(customList.CountGreaterThan(element).ToString());
                    break;
                case "Max":
                    Print(customList.Max.ToString());
                    break;
                case "Min":
                    Print(customList.Min.ToString());
                    break;
                case "Sort":
                    customList.Sort();
                    break;
                case "Print":
                    foreach (var item in customList)
                    {
                        Print(item);
                    }
                    break;
            }
        }

        private void Print(string message)
            => Console.WriteLine(message);
    }
}
