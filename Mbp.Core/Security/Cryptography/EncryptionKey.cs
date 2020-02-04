namespace Mbp.Core.Security.Cryptography
{
    public class EncryptionKey
    {
        #region Fields, Properties and Indexers

        public byte[] PublicKey
        {
            get => _Key;
            set => _Key = value;
        }

        public byte[] Key
        {
            get => _Key;
            set => _Key = value;
        }

        public byte[] PrivateKey
        {
            get => _IV;
            set => _IV = value;
        }

        public byte[] IV
        {
            get => _IV;
            set => _IV = value;
        }

        private byte[] _Key { get; set; }

        private byte[] _IV { get; set; }

        #endregion
    }
}
