 namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            Type type = //typeof(HarvestingFields);
            //Type.GetType(HarvestingFields);
            Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == "HarvestingFields");

            var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance); //(BindingFlags)62

            string input;
            while ((input = Console.ReadLine()) != "HARVEST")
            {
                FieldInfo[] fieldsToPrint = input == "all" ? fields : fields
                                                                        .Where(f => f.Attributes
                                                                            .ToString()
                                                                            .ToLower()
                                                                            .Replace("family", "protected") == input)
                                                                        .ToArray();

                foreach (var field in fieldsToPrint)
                {
                    var attr = field.Attributes
                        .ToString()
                        .ToLower()
                        .Replace("family", "protected");
                     
                    Console.WriteLine($"{attr} {field.FieldType.Name} {field.Name}");
                }
            }
        }
    }
}
