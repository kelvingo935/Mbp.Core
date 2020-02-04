#region using

using System;
using Mbp.Core.Interfaces;

#endregion

namespace Mbp.Core.Managers
{
    public static class LogManager
    {
        #region Static Fields and Properties

        public static string NewLine { get; set; } = Environment.NewLine;

        public static string Tab { get; set; } = "\t";

        private static ILogAppender _Appender { get; } = Engine.Resolve<ILogAppender>();

        private static ILogReporter _Reporter { get; } = Engine.Resolve<ILogReporter>();

        #endregion

        #region Methods

        public static void Trace(string tag,
            string message)
        {
            _Appender?.LogTrace(FormatLogMessage("TRCE", tag, message));
        }

        public static void Trace(string tag,
            string format,
            params object[] arguments)
        {
            Trace(tag, string.Format(format, arguments));
        }

        public static void Trace(string tag,
            Exception ex)
        {
            _Reporter?.ReportException(tag, ex);
            Trace(tag, StringifyException(ex));
        }

        public static void Trace(string tag,
            Exception ex,
            string message)
        {
            _Reporter?.ReportException(tag, ex, message);
            Trace(tag, message + StringifyException(ex));
        }

        public static void Trace(string tag,
            Exception ex,
            string format,
            params object[] arguments)
        {
            Trace(tag, ex, string.Format(format, arguments));
        }

        public static void Debug(string tag,
            string message)
        {
            _Appender?.LogDebug(FormatLogMessage("DBUG", tag, message));
        }

        public static void Debug(string tag,
            string format,
            params object[] arguments)
        {
            Debug(tag, string.Format(format, arguments));
        }

        public static void Debug(string tag,
            Exception ex)
        {
            _Reporter?.ReportException(tag, ex);
            Debug(tag, StringifyException(ex));
        }

        public static void Debug(string tag,
            Exception ex,
            string message)
        {
            _Reporter?.ReportException(tag, ex, message);
            Debug(tag, message + StringifyException(ex));
        }

        public static void Debug(string tag,
            Exception ex,
            string format,
            params object[] arguments)
        {
            Debug(tag, ex, string.Format(format, arguments));
        }

        public static void Info(string tag,
            string message)
        {
            _Appender?.LogInfo(FormatLogMessage("INFO", tag, message));
        }

        public static void Info(string tag,
            string format,
            params object[] arguments)
        {
            Info(tag, string.Format(format, arguments));
        }

        public static void Info(string tag,
            Exception ex)
        {
            _Reporter?.ReportException(tag, ex);
            Info(tag, StringifyException(ex));
        }

        public static void Info(string tag,
            Exception ex,
            string message)
        {
            _Reporter?.ReportException(tag, ex, message);
            Info(tag, message + StringifyException(ex));
        }

        public static void Info(string tag,
            Exception ex,
            string format,
            params object[] arguments)
        {
            Info(tag, ex, string.Format(format, arguments));
        }

        public static void Warning(string tag,
            string message)
        {
            _Appender?.LogWarning(FormatLogMessage("WARN", tag, message));
        }

        public static void Warning(string tag,
            string format,
            params object[] arguments)
        {
            Warning(tag, string.Format(format, arguments));
        }

        public static void Warning(string tag,
            Exception ex)
        {
            _Reporter?.ReportException(tag, ex);
            Warning(tag, StringifyException(ex));
        }

        public static void Warning(string tag,
            Exception ex,
            string message)
        {
            _Reporter?.ReportException(tag, ex, message);
            Warning(tag, message + StringifyException(ex));
        }

        public static void Warning(string tag,
            Exception ex,
            string format,
            params object[] arguments)
        {
            Warning(tag, ex, string.Format(format, arguments));
        }

        public static void Error(string tag,
            string message)
        {
            _Appender?.LogError(FormatLogMessage("FAIL", tag, message));
        }

        public static void Error(string tag,
            string format,
            params object[] arguments)
        {
            Error(tag, string.Format(format, arguments));
        }

        public static void Error(string tag,
            Exception ex)
        {
            _Reporter?.ReportException(tag, ex);
            Error(tag, StringifyException(ex));
        }

        public static void Error(string tag,
            Exception ex,
            string message)
        {
            _Reporter?.ReportException(tag, ex, message);
            Error(tag, message + StringifyException(ex));
        }

        public static void Error(string tag,
            Exception ex,
            string format,
            params object[] arguments)
        {
            Error(tag, ex, string.Format(format, arguments));
        }

        public static void Critical(string tag,
            string message)
        {
            _Appender?.LogError(FormatLogMessage("CRIT", tag, message));
        }

        public static void Critical(string tag,
            string format,
            params object[] arguments)
        {
            Critical(tag, string.Format(format, arguments));
        }

        public static void Critical(string tag,
            Exception ex)
        {
            _Reporter?.ReportException(tag, ex);
            Critical(tag, StringifyException(ex));
        }

        public static void Critical(string tag,
            Exception ex,
            string message)
        {
            _Reporter?.ReportException(tag, ex, message);
            Critical(tag, message + StringifyException(ex));
        }

        public static void Critical(string tag,
            Exception ex,
            string format,
            params object[] arguments)
        {
            Critical(tag, ex, string.Format(format, arguments));
        }

        private static string FormatLogMessage(string level,
            string tag,
            string message)
        {
            return $"{DateTime.Now:R}{Tab}[{level}]{Tab}[{tag}]{Tab}{message}{NewLine}";
        }

        private static string StringifyException(Exception ex)
        {
            return $"{NewLine}{Tab}ERROR SOURCE"
                   + $"{NewLine}{Tab}{new string('=', 50)}"
                   + $"{NewLine}{Tab}{ex.Source?.Replace(NewLine, NewLine + Tab)}{NewLine}"
                   + $"{NewLine}{Tab}ERROR INFO"
                   + $"{NewLine}{Tab}{new string('=', 50)}"
                   + $"{NewLine}{Tab}{ex.Message.Replace(NewLine, NewLine + Tab)}{NewLine}"
                   + $"{NewLine}{Tab}ERROR TRY/CATCH"
                   + $"{NewLine}{Tab}{new string('=', 50)}"
                   + $"{NewLine}{Tab}{(ex.InnerException != null ? $"{ex.InnerException.Message}{NewLine}{Tab}{ex.InnerException.StackTrace?.Replace(NewLine, NewLine + Tab)}" : "")}{NewLine}"
                   + $"{NewLine}{Tab}STACK TRACE"
                   + $"{NewLine}{Tab}{new string('=', 50)}"
                   + $"{NewLine}{Tab}{ex.StackTrace?.Replace(NewLine, NewLine + Tab)}{NewLine}";
        }

        #endregion
    }
}
