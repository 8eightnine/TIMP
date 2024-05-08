namespace laba7
{
    internal class Client
    {
        public void SetClockTime(IClock clock, int hours, int minutes)
        {
            clock.SetTime(hours, minutes);
        }
    }
}