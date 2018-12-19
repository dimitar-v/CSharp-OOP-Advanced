namespace TheTankGame.Entities.Parts.Factories
{
    using Contracts;
    using System;
    using System.Linq;
    using System.Reflection;
    using TheTankGame.Entities.Parts.Contracts;

    public class PartFactory : IPartFactory
    {
        public IPart CreatePart(string partType, string model, double weight, decimal price, int additionalParameter)
        {
            Type type = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == partType + "Part");

            IPart part = (IPart)Activator.CreateInstance(type, new Object[] { model, weight, price, additionalParameter});

            return part;
        }
    }
}
