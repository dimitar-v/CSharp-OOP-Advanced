namespace Travel.Entities
{
	using System.Collections.Generic;
	using Contracts;

	public class Passenger : IPassenger
	{
		public Passenger(string username)
		{
			this.Username = username;

			this.Bags = new List<IBag>();
		}

		public string Username { get; }

        // TODO: Check set?
		public IList<IBag> Bags { get; }
	}
}