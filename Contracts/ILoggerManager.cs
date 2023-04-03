namespace Contracts
{
    public interface ILoggerManager
    {
        #region Methods

        void LogInfo(string message);

        void LogWarn(string message);

        void LogDebug(string message);

        void LogError(string message);

        #endregion Methods
    }
}