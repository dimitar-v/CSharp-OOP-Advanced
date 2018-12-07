using System;
using System.Reflection;
using System.Text;
using System.Linq;


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

}

