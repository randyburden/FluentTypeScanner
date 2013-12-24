using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FluentTypeScanner
{
    /// <summary>
    /// Scans for assemblies and types.
    /// </summary>
    public class AssemblyScanner : IAssemblyScanner
    {
        #region Implementation of IAssemblyScanner

        /// <summary>
        /// Gets all of the assemblies in the current AppDomain.
        /// </summary>
        /// <returns>List of assemblies.</returns>
        public virtual IEnumerable<Assembly> GetAssemblies()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .Where( x => x.FullName.StartsWith( "System." ) == false ||
                             x.FullName.StartsWith( "Microsoft." ) == false );
        }

        /// <summary>
        /// Gets all loadable types in a given assembly.
        /// </summary>
        /// <param name="assembly">Assembly to scan for types.</param>
        /// <returns>List of types.</returns>
        public virtual IEnumerable<Type> GetTypes( Assembly assembly )
        {
            if ( assembly == null ) throw new ArgumentNullException( "assembly" );

            try
            {
                return assembly.GetTypes().OrderBy( x => x.FullName );
            }
            catch ( ReflectionTypeLoadException e )
            {
                return e.Types.Where( t => t != null ).OrderBy( x => x.FullName );
            }
        }

        #endregion Implementation of IAssemblyScanner
    }
}