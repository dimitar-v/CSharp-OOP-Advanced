namespace FestivalManager.Core.Controllers
{
    using Contracts;
    using Entities.Contracts;
    using Entities.Factories.Contracts;
    using FestivalManager.Entities;
    using System;
    using System.Linq;
    using System.Text;

    public class FestivalController : IFestivalController
    {
        private readonly IStage stage;
        private readonly IInstrumentFactory instrumentFactory;
        private readonly ISetFactory setFactory;

        public FestivalController(IStage stage, IInstrumentFactory instrumentFactory, ISetFactory setFactory)
        {
            this.stage = stage;
            this.instrumentFactory = instrumentFactory;
            this.setFactory = setFactory;
        }

        // Done
        public string RegisterSet(string[] args)
        {
            string name = args[0];
            string type = args[1];

            ISet set = setFactory.CreateSet(name, type);
            stage.AddSet(set);

            return $"Registered {type} set";
        }

        // Done
        public string SignUpPerformer(string[] args)
        {
            string name = args[0];
            int age = int.Parse(args[1]);

            Performer performer = new Performer(name, age);

            IInstrument[] insruments = args
                                        .Skip(2)
                                        .Select(i => this.instrumentFactory.CreateInstrument(i))
                                        .ToArray();


            foreach (IInstrument instrument in insruments)
            {
                performer.AddInstrument(instrument);
            }

            this.stage.AddPerformer(performer);

            return $"Registered performer {name}";
        }

        // Done
        public string RegisterSong(string[] args)
        {
            string songName = args[0];

            int[] timeArgs = args[1].Split(':').Select(int.Parse).ToArray();
            TimeSpan duration = new TimeSpan(0, timeArgs[0], timeArgs[1]);

            ISong song = new Song(songName, duration);

            stage.AddSong(song);

            return $"Registered song {songName} ({duration:mm\\:ss})";
        }

        // Done
        public string AddSongToSet(string[] args)
        {
            string songName = args[0];
            string setName = args[1];

            if (!stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            if (!stage.HasSong(songName))
            {
                throw new InvalidOperationException("Invalid song provided");
            }

            ISong song = stage.GetSong(songName);
            ISet set = stage.GetSet(setName);

            set.AddSong(song);

            return $"Added {songName} ({song.Duration:mm\\:ss}) to {setName}";
        }

        // Done
        public string AddPerformerToSet(string[] args)
        {
            var performerName = args[0];
            var setName = args[1];

            if (!this.stage.HasPerformer(performerName))
            {
                throw new InvalidOperationException("Invalid performer provided");
            }

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            var performer = this.stage.GetPerformer(performerName);
            var set = this.stage.GetSet(setName);

            set.AddPerformer(performer);

            return $"Added {performer.Name} to {set.Name}";
        }

        // Done
        public string RepairInstruments(string[] args)
        {
            var instrumentsToRepair = this.stage.Performers
                .SelectMany(p => p.Instruments)
                .Where(i => i.Wear < 100)
                .ToArray();

            foreach (var instrument in instrumentsToRepair)
            {
                instrument.Repair();
            }

            return $"Repaired {instrumentsToRepair.Length} instruments";
        }

        // Done
        public string ProduceReport()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Results:");

            var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));

            sb.AppendLine($"Festival length: {TimeFormatedMMSS(totalFestivalLength)}");

            foreach (var set in this.stage.Sets)
            {
                sb.AppendLine($"--{set.Name} ({TimeFormatedMMSS(set.ActualDuration)}):");

                var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
                foreach (var performer in performersOrderedDescendingByAge)
                {
                    var instruments = string.Join(", ", performer.Instruments
                        .OrderByDescending(i => i.Wear));

                    sb.AppendLine($"---{performer.Name} ({instruments})");
                }

                if (!set.Songs.Any())
                    sb.AppendLine("--No songs played");
                else
                {
                    sb.AppendLine("--Songs played:");
                    foreach (var song in set.Songs)
                    {
                        sb.AppendLine($"----{song.Name} ({TimeFormatedMMSS(song.Duration)})");
                    }
                }
            }

            return sb.ToString().Trim();
        }

        private string TimeFormatedMMSS(TimeSpan time)
        {
            int minutes = time.Hours * 60 + time.Minutes;
            int seconds = time.Seconds;

            return $"{minutes:d2}:{seconds:d2}";
        }
    }
}