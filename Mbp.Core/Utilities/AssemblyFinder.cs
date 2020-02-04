#region using

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

#endregion

namespace Mbp.Core.Utilities
{
    public static class AssemblyFinder
    {
        #region Methods

        public static IEnumerable<Assembly> FindAssemblies()
        {
            var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly()
                .CodeBase);
            var dllFiles = Directory.EnumerateFiles(directory, "*.dll", SearchOption.AllDirectories);
            var exeFiles = Directory.EnumerateFiles(directory, "*.exe", SearchOption.AllDirectories);
            var files = dllFiles.Concat(exeFiles);

            foreach (var file in files)
            {
                var name = Path.GetFileNameWithoutExtension(file);
                Assembly assembly = null;

                try
                {
                    assembly = Assembly.Load(new AssemblyName(name));
                }
                catch (Exception)
                {
                    // ignore unable scan assemblies
                }

                if (assembly != null)
                {
                    yield return assembly;
                }
            }
        }

        #endregion
    }
}
