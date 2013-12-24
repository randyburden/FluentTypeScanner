using System;
using System.Collections.Generic;
using System.Reflection;

namespace FluentTypeScanner
{
    /// <summary>
    /// Type scanner configuration providing methods to fluently specify
    /// the configuration of how to scan for types and how to handle them.
    /// </summary>
    public class TypeScannerConfiguration
    {
        /// <summary>
        /// Assembly scanner.
        /// </summary>
        public IAssemblyScanner AssemblyScanner;

        /// <summary>
        /// Type configurations.
        /// </summary>
        public List<TypeConfiguration> TypeConfigurations;

        /// <summary>
        /// Creates a new <see cref="TypeScannerConfiguration"/>.
        /// </summary>
        public TypeScannerConfiguration()
        {
            AssemblyScanner = new AssemblyScanner();

            TypeConfigurations = new List<TypeConfiguration>();
        }

        /// <summary>
        /// Adds a <see cref="TypeConfiguration"/> to the configuration.
        /// </summary>
        /// <param name="typeConfiguration">Type configuration.</param>
        public void Add( TypeConfiguration typeConfiguration )
        {
            TypeConfigurations.Add( typeConfiguration );
        }

        /// <summary>
        /// Scans all assemblies and types specified using the <param name="assemblyScanner" />.
        /// </summary>
        /// <param name="assemblyScanner">Assembly scanner</param>
        public void ScanWith( IAssemblyScanner assemblyScanner )
        {
            AssemblyScanner = assemblyScanner;
        }

        /// <summary>
        /// For the given type.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <returns>Type configuration</returns>
        public ScanningStrategy For<T>()
        {
            var typeConfiguration = new TypeConfiguration( typeof( T ) );

            TypeConfigurations.Add( typeConfiguration );

            return new ScanningStrategy( typeConfiguration );
        }

        /// <summary>
        /// For all types.
        /// </summary>
        /// <returns>Type configuration</returns>
        public TypeConfiguration ForAllTypes()
        {
            var typeConfiguration = new TypeConfiguration( null ) { ScanningStrategy = ScanFor.AllTypes };

            TypeConfigurations.Add( typeConfiguration );

            return typeConfiguration;
        }

        /// <summary>
        /// Scans all assemblies and types using this <see cref="TypeScannerConfiguration"/>'s
        /// <see cref="IAssemblyScanner"/> and passes each type to each configured
        /// <see cref="TypeConfiguration"/>.
        /// </summary>
        public void Scan()
        {
            IEnumerable<Assembly> assemblies = AssemblyScanner.GetAssemblies();

            foreach ( Assembly assembly in assemblies )
            {
                IEnumerable<Type> types = AssemblyScanner.GetTypes( assembly );

                foreach ( Type type in types )
                {
                    foreach ( TypeConfiguration typeConfiguration in TypeConfigurations )
                    {
                        typeConfiguration.Handle( type );
                    }
                }
            }
        }
    }
}