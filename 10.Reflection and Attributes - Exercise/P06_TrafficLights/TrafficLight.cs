namespace P06_TrafficLights
{
    using System;

    public class TrafficLight
    {
        private TrafficLightColors currentColor;

        public TrafficLight(string currentColor)
        {
            this.currentColor = Enum.Parse<TrafficLightColors>(currentColor);
        }

        public void Update()
        {
            int lastColor = (int)currentColor;
            currentColor = (TrafficLightColors)(++lastColor % Enum.GetNames(typeof(TrafficLightColors)).Length);
        }
    }
}
