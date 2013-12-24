using System;

namespace FluentTypeScanner
{
    /// <summary>
    /// Scanning strategy.
    /// </summary>
    public class ScanningStrategy
    {
        private readonly TypeConfiguration _typeConfiguration;

        /// <summary>
        /// Creates a new <see cref="ScanningStrategy"/>
        /// </summary>
        /// <param name="typeConfiguration">Type configuration.</param>
        public ScanningStrategy( TypeConfiguration typeConfiguration )
        {
            _typeConfiguration = typeConfiguration;
        }

        /// <summary>
        /// Scans for types that are decorated with a particular attribute.
        /// </summary>
        /// <returns></returns>
        public TypeConfiguration ScanForTypesThatAreDecoratedWithThisAttribute()
        {
            if ( _typeConfiguration.Type.IsSubclassOf( typeof( Attribute ) ) == false )
            {
                throw new Exception( "The following type is not an attribute: " + _typeConfiguration.Type );
            }

            _typeConfiguration.ScanningStrategy = ScanFor.TypesThatAreDecoratedWithThisAttribute;

            return _typeConfiguration;
        }

        /// <summary>
        /// Scans for types that implement a particular interface.
        /// </summary>
        /// <returns></returns>
        public TypeConfiguration ScanForTypesThatImplementThisInterface()
        {
            if ( _typeConfiguration.Type.IsInterface == false )
            {
                throw new Exception( "The following type is not an interface: " + _typeConfiguration.Type );
            }

            _typeConfiguration.ScanningStrategy = ScanFor.TypesThatImplementThisInterface;

            return _typeConfiguration;
        }

        /// <summary>
        /// Scans for types that inherit from a particular class.
        /// </summary>
        /// <returns></returns>
        public TypeConfiguration ScanForTypesThatInheritFromThisClass()
        {
            if ( _typeConfiguration.Type.IsClass == false )
            {
                throw new Exception( "The following type is not a class: " + _typeConfiguration.Type );
            }

            _typeConfiguration.ScanningStrategy = ScanFor.TypesThatInheritFromThisClass;

            return _typeConfiguration;
        }

        /// <summary>
        /// Scans for types that inherit from an abstract class.
        /// </summary>
        /// <returns></returns>
        public TypeConfiguration ScanForTypesThatInheritFromThisAbstractClass()
        {
            if ( _typeConfiguration.Type.IsAbstract == false )
            {
                throw new Exception( "The following type is not an abstract class: " + _typeConfiguration.Type );
            }

            _typeConfiguration.ScanningStrategy = ScanFor.TypesThatInheritFromThisAbstractClass;

            return _typeConfiguration;
        }

        /// <summary>
        /// Specifies the scanning option.
        /// </summary>
        /// <param name="scanFor">Scanning option.</param>
        /// <returns>The current <see cref="TypeConfiguration"/>.</returns>
        public TypeConfiguration WithScanningStrategy( ScanFor scanFor )
        {
            switch ( scanFor )
            {
                case ScanFor.TypesThatAreDecoratedWithThisAttribute:
                    ScanForTypesThatAreDecoratedWithThisAttribute();
                    break;
                case ScanFor.TypesThatImplementThisInterface:
                    ScanForTypesThatImplementThisInterface();
                    break;
                case ScanFor.TypesThatInheritFromThisClass:
                    ScanForTypesThatInheritFromThisClass();
                    break;
                case ScanFor.TypesThatInheritFromThisAbstractClass:
                    ScanForTypesThatInheritFromThisAbstractClass();
                    break;
                default:
                    _typeConfiguration.ScanningStrategy = ScanFor.AllTypes;
                    break;
            }

            return _typeConfiguration;
        }
    }
}