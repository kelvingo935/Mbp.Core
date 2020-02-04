#region using

using System.Collections.Generic;
using DryIoc;

#endregion

namespace Mbp.Core.Interfaces
{
    public interface IModule
    {
        #region Fields, Properties and Indexers

        string Name { get; }

        string Version { get; }

        List<string> Dependencies { get; }

        #endregion

        #region Methods

        void ConfigureServices(IRegistrator registrator);

        #endregion
    }
}
