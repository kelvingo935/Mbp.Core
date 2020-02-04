namespace Mbp.Core.Interfaces
{
    public interface ILogAppender
    {
        #region Methods

        void LogTrace(string message);

        void LogDebug(string message);

        void LogInfo(string message);

        void LogWarning(string message);

        void LogError(string message);

        void LogCritical(string message);

        #endregion
    }
}
