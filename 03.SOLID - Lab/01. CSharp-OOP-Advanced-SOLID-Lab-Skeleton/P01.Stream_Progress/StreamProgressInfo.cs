namespace P01.Stream_Progress
{
    public class StreamProgressInfo
    {
        private IStreambele streamable;

 
        public StreamProgressInfo(IStreambele streamable)
        {
            this.streamable = streamable;
        }

        public int CalculateCurrentPercent()
        {
            return (streamable.BytesSent * 100) / streamable.Length;
        }
    }
}
