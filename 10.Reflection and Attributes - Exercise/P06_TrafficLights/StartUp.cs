namespace P06_TrafficLights
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            List<TrafficLight> lights = new List<TrafficLight>();

            int count = int.Parse(Console.ReadLine());

            Type type = typeof(TrafficLight);

            for (int i = 0; i < input.Length; i++)
            {
                TrafficLight execute = (TrafficLight)Activator.CreateInstance(type, new object[] { input[i] });
                lights.Add(execute);
            }

            var field = type.GetField("currentColor", BindingFlags.NonPublic | BindingFlags.Instance);

            for (int i = 0; i < count; i++)
            {
                StringBuilder sb = new StringBuilder();
                foreach (var light in lights)
                {
                    light.Update();
                    sb.Append($"{field.GetValue(light)} ");
                }

                Console.WriteLine(sb.ToString().Trim());
            }
        }
    }
}
