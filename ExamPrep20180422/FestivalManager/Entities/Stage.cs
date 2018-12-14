namespace FestivalManager.Entities
{
    using Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class Stage : IStage
    {
        private readonly List<ISet> sets;
        private readonly List<ISong> songs;
        private readonly List<IPerformer> performers;

        public Stage()
        {
            this.sets = new List<ISet>();
            this.songs = new List<ISong>();
            this.performers = new List<IPerformer>();
        }

        public IReadOnlyCollection<ISet> Sets => sets.AsReadOnly();

        public IReadOnlyCollection<ISong> Songs => songs.AsReadOnly();

        public IReadOnlyCollection<IPerformer> Performers => performers.AsReadOnly();

        public void AddPerformer(IPerformer performer)
            => performers.Add(performer);

        public void AddSet(ISet set)
            => sets.Add(set);

        public void AddSong(ISong song)
            => songs.Add(song);

        public IPerformer GetPerformer(string name)
            => performers.FirstOrDefault(p => p.Name == name);

        public ISet GetSet(string name)
            => sets.FirstOrDefault(s => s.Name == name);

        public ISong GetSong(string name)
            => songs.FirstOrDefault(s => s.Name == name);

        public bool HasPerformer(string name)
            => performers.Any(p => p.Name == name);

        public bool HasSet(string name)
            => sets.Any(s => s.Name == name);

        public bool HasSong(string name)
            => songs.Any(s => s.Name == name);
    }
}
