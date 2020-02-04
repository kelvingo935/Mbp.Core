#region using

using System;

#endregion

namespace Mbp.Core.Interfaces
{
    public interface ILogReporter
    {
        #region Methods

        void ReportException(string tag,
            Exception ex);

        void ReportException(string tag,
            Exception ex,
            string message);

        #endregion
    }
}
