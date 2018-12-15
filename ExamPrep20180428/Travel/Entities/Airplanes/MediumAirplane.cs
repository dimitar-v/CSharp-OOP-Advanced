namespace Travel.Entities.Airplanes
{
	public class MediumAirplane : Airplane
	{
        private const int Seats = 10;
        private const int BaggageCompartments = 14;

        public MediumAirplane()
			: base(Seats, BaggageCompartments)
		{
		}
	}
}