using System;
using System.Reflection;


public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        var type = typeof(StartUp);

        var methodes = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);


        foreach (var method in methodes)
        {
            var attr = method.GetCustomAttribute<SoftUniAttribute>();

            if (attr != null)
            {
                Console.WriteLine($"{method.Name} is writen by {attr.Name}");
            }

        }
    }
}

