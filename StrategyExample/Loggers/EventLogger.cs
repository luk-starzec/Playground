namespace StrategyExample.Loggers
{
    public class EventLogger : ICustomLogger
    {
        public EnumLoggerType Logger => EnumLoggerType.Event;

        public string Write()
        {
            return "Event logger";
        }
    }
}
