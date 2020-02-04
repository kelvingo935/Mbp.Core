#region using

using Mbp.Core.Security.Cryptography;

#endregion

namespace Mbp.Core.Interfaces
{
    public interface ICurrent
    {
        #region Fields, Properties and Indexers

        string Name { get; }

        EncryptionKey EncryptionKey { get; }

        #endregion
    }
}
