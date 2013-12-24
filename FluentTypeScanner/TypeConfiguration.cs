using System;

namespace FluentTypeScanner
{
    /// <summary>
    /// Type configuration.
    /// </summary>
    public class TypeConfiguration
    {
        /// <summary>
        /// The configured Type.
        /// </summary>
        internal readonly Type Type;

        /// <summary>
        /// The configured Action.
        /// </summary>
        internal Action<Type> Action;

        /// <summary>
        /// The configured scanning strategy.
        /// </summary>
        internal ScanFor ScanningStrategy;

        /// <summary>
        /// Creates a new <see cref="TypeConfiguration"/>.
        /// </summary>
        /// <param name="type">Type.</param>
        public TypeConfiguration( Type type )
        {
            Type = type;
        }

        /// <summary>
        /// Creates a new <see cref="TypeConfiguration"/>.
        /// </summary>
        /// <param name="type">Type.</param>
        /// <param name="action">Action to perform.</param>
        /// <param name="scanningStrategy">Scanning strategy.</param>
        public TypeConfiguration( Type type, Action<Type> action, ScanFor scanningStrategy )
        {
            Type = type;
            Action = action;
            ScanningStrategy = scanningStrategy;
        }

        /// <summary>
        /// Performs the specified action passing the Type that meets the configurations
        /// scanning strategy.
        /// </summary>
        /// <param name="action">The Type that meets this configuration's scanning strategy.</param>
        public void Do( Action<Type> action )
        {
            Action = action;
        }

        /// <summary>
        /// Handles the specified Type depending on the scanning strategy
        /// of the <see cref="TypeConfiguration"/>.
        /// </summary>
        /// <param name="type">Type to handle.</param>
        internal void Handle( Type type )
        {
            switch ( ScanningStrategy )
            {
                case ScanFor.TypesThatAreDecoratedWithThisAttribute:
                    if ( type.IsDefined( Type, true ) )
                    {
                        Action( type );
                    }
                    break;
                case ScanFor.TypesThatImplementThisInterface:
                    if ( Type.IsAssignableFrom( type ) && type.IsInterface == false )
                    {
                        Action( type );
                    }
                    break;
                case ScanFor.TypesThatInheritFromThisAbstractClass:
                    if ( Type.IsAssignableFrom( type ) && type.IsAbstract == false )
                    {
                        Action( type );
                    }
                    break;
                case ScanFor.TypesThatInheritFromThisClass:
                    if ( Type.IsAssignableFrom( type ) && type != Type )
                    {
                        Action( type );
                    }
                    break;
                default:
                    Action( type );
                    break;
            }
        }
    }
}