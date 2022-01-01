namespace StrategyExample.Loggers
{
    public class FileLogger : ICustomLogger
    {
        public EnumLoggerType Logger => EnumLoggerType.File;

        public string Write()
        {
            return "File logger";
        }
    }
}
