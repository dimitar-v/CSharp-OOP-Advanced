using System;
using System.Linq;
using System.Reflection;
using System.Text;


public class Spy
{

    public string StealFieldInfo(string className, params string[] fieldsNames)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Class under investigation: {className}");

        var type = Type.GetType(className);

        var fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);

        var classInstance = Activator.CreateInstance(type, new object[] { });

        foreach (var field in fields.Where(f => fieldsNames.Contains(f.Name)))
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return sb.ToString().Trim();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        StringBuilder sb = new StringBuilder();

        var type = Type.GetType(className);

        type //var fields = 
            .GetFields() // BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public
            .ToList()
            .ForEach(f => sb.AppendLine($"{f.Name} must be private!"));

        type //var getters = 
            .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
            .Where(m => m.Name.StartsWith("get"))
            .ToList()
            .ForEach(g => sb.AppendLine($"{g.Name} have to be public!"));

        type //var setters = 
            .GetMethods() // BindingFlags.Instance | BindingFlags.Public
            .Where(m => m.Name.StartsWith("set"))
            .ToList()
            .ForEach(s => sb.AppendLine($"{s.Name} have to be private!"));

        //foreach (var field in fields)
        //{
        //    sb.AppendLine($"{field.Name} must be private!");
        //}

        //foreach (var getter in getters)
        //{
        //    sb.AppendLine($"{getter.Name} have to be public!");
        //}

        //foreach (var setter in setters)
        //{
        //    sb.AppendLine($"{setter.Name} have to be private!");
        //}

        return sb.ToString().Trim();
    }
}

