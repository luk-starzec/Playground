namespace StrategyExample.Loggers
{
    public class DbLogger : ICustomLogger
    {
        public EnumLoggerType Logger => EnumLoggerType.Db;

        public string Write()
        {
            return "DB logger";
        }
    }
}
