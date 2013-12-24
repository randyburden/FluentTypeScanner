using System;
using System.Collections.Generic;
using System.Reflection;

namespace FluentTypeScanner
{
    /// <summary>
    /// Scans for assemblies and types.
    /// </summary>
    public interface IAssemblyScanner
    {
        /// <summary>
        /// Gets assemblies.
        /// </summary>
        /// <returns>List of assemblies.</returns>
        IEnumerable<Assembly> GetAssemblies();

        /// <summary>
        /// Gets types in a given assembly.
        /// </summary>
        /// <param name="assembly">Assembly to scan for types.</param>
        /// <returns>List of types.</returns>
        IEnumerable<Type> GetTypes( Assembly assembly );
    }
}