﻿#region using

using System.Linq;
using System.Reflection;
using DryIoc;
using Mbp.Core.Utilities;

#endregion

// ReSharper disable once CheckNamespace
public static class IRegistratorExtension
{
    #region Methods

    public static void ScanAssemblies<T>(this IRegistrator registrator,
        IReuse reuse = null,
        Made made = null,
        Setup setup = null,
        IfAlreadyRegistered ifAlreadyRegistered = IfAlreadyRegistered.AppendNotKeyed)
    {
        var serviceTypeOf = typeof(T);
        var scannedTypes = AssemblyFinder.FindAssemblies()
            .Where(assembly =>
            {
                try
                {
                    var definedTypes = assembly.DefinedTypes;
                    return true;
                }
                catch
                {
                    return false;
                }
            })
            .SelectMany(assembly => assembly.DefinedTypes)
            .Where(type => !type.IsAbstract
                           && serviceTypeOf.GetTypeInfo()
                               .IsAssignableFrom(type));

        foreach (var eachScannedType in scannedTypes)
        {
            registrator.Register(eachScannedType.AsType(), reuse, made, setup, ifAlreadyRegistered);

            var interfaces = eachScannedType.ImplementedInterfaces;
            foreach (var eachInterface in interfaces)
            {
                registrator.Register(eachInterface, eachScannedType.AsType(), reuse, made, setup, ifAlreadyRegistered);
            }
        }
    }

    #endregion
}
