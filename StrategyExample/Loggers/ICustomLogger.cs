namespace StrategyExample.Loggers
{
    public interface ICustomLogger
    {
        public EnumLoggerType Logger { get; }
        public string Write();
    }
}
