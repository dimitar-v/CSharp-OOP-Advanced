namespace Travel.Entities.Airplanes
{
	public class LightAirplane : Airplane
	{
        private const int Seats = 5;
        private const int BaggageCompartments = 8;

		public LightAirplane()
			: base(Seats, BaggageCompartments)
		{
		}
	}
}