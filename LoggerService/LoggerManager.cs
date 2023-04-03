using Contracts;
using NLog;

namespace LoggerService
{
    public class LoggerManager : ILoggerManager
    {
        #region Fields

        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();

        #endregion Fields

        #region Constructors

        public LoggerManager()
        {
        }

        #endregion Constructors

        #region Methods

        public void LogDebug(string message) => logger.Debug(message);

        public void LogError(string message) => logger.Error(message);

        public void LogInfo(string message) => logger.Info(message);

        public void LogWarn(string message) => logger.Warn(message);

        #endregion Methods
    }
}