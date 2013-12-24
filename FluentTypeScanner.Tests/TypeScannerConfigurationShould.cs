using System;
using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework;

namespace FluentTypeScanner.Tests
{
    [TestFixture]
    public class TypeScannerConfigurationShould
    {
        [Test]
        public void Be_Able_To_Scan_For_All_Types()
        {
            // Arrange
            bool typeWasFound = false;

            // Act
            var configuration = new TypeScannerConfiguration();

            configuration.ForAllTypes().Do( type =>
                {
                    if ( type == typeof( ClassA ) )
                    {
                        typeWasFound = true;
                    }
                });
            
            configuration.Scan();

            // Assert
            Assert.That( typeWasFound );
        }

        [Test]
        public void Be_Able_To_Scan_For_Inherited_Types()
        {
            // Arrange
            bool typeWasFound = false;

            // Act
            var configuration = new TypeScannerConfiguration();

            configuration.For<ClassA>()
                .ScanForTypesThatInheritFromThisClass()
                .Do( type =>
                    {
                        if ( type == typeof ( ClassB ) )
                        {
                            typeWasFound = true;
                        }
                    } );

            configuration.Scan();

            // Assert
            Assert.That( typeWasFound );
        }

        [Test]
        public void Be_Able_To_Scan_For_Deeply_Nested_Inherited_Types()
        {
            // Arrange
            bool typeWasFound = false;

            // Act
            var configuration = new TypeScannerConfiguration();

            configuration.For<ClassA>()
                .ScanForTypesThatInheritFromThisClass()
                .Do( type =>
                    {
                        if ( type == typeof ( ClassC ) )
                        {
                            typeWasFound = true;
                        }
                    } );

            configuration.Scan();

            // Assert
            Assert.That( typeWasFound );
        }

        [Test]
        public void Be_Able_To_Scan_For_Abstract_Types()
        {
            // Arrange
            bool typeWasFound = false;

            // Act
            var configuration = new TypeScannerConfiguration();

            configuration.For<AbstractClassAa>()
                .ScanForTypesThatInheritFromThisAbstractClass()
                .Do( type =>
                    {
                        if ( type == typeof ( ClassAa ) )
                        {
                            typeWasFound = true;
                        }
                    } );

            configuration.Scan();

            // Assert
            Assert.That( typeWasFound );
        }

        [Test]
        public void Be_Able_To_Scan_For_Deeply_Nested_Abstract_Types()
        {
            // Arrange
            bool typeWasFound = false;

            // Act
            var configuration = new TypeScannerConfiguration();

            configuration.For<AbstractClassAa>()
                .ScanForTypesThatInheritFromThisAbstractClass()
                .Do( type =>
                {
                    if ( type == typeof( ClassBb ) )
                    {
                        typeWasFound = true;
                    }
                } );

            configuration.Scan();

            // Assert
            Assert.That( typeWasFound );
        }

        [Test]
        public void Be_Able_To_Scan_For_Implementations_Of_Interfaces()
        {
            // Arrange
            bool typeWasFound = false;

            // Act
            var configuration = new TypeScannerConfiguration();

            configuration.For<IInterfaceAbc>()
                .ScanForTypesThatImplementThisInterface()
                .Do( type =>
                {
                    if ( type == typeof( ClassAbc ) )
                    {
                        typeWasFound = true;
                    }
                } );

            configuration.Scan();

            // Assert
            Assert.That( typeWasFound );
        }

        [Test]
        public void Be_Able_To_Scan_For_Deeply_Nested_Implementations_Of_Interfaces()
        {
            // Arrange
            bool typeWasFound = false;

            // Act
            var configuration = new TypeScannerConfiguration();

            configuration.For<IInterfaceAbc>()
                .ScanForTypesThatImplementThisInterface()
                .Do( type =>
                {
                    if ( type == typeof( ClassAbcd ) )
                    {
                        typeWasFound = true;
                    }
                } );

            configuration.Scan();

            // Assert
            Assert.That( typeWasFound );
        }

        [Test]
        public void Be_Able_To_Scan_For_Classes_Decorated_With_An_Attribute()
        {
            // Arrange
            bool typeWasFound = false;

            // Act
            var configuration = new TypeScannerConfiguration();

            configuration.For<AttributeXyz>()
                .ScanForTypesThatAreDecoratedWithThisAttribute()
                .Do( type =>
                {
                    if ( type == typeof( ClassXyz ) )
                    {
                        typeWasFound = true;
                    }
                } );

            configuration.Scan();

            // Assert
            Assert.That( typeWasFound );
        }

        [Test]
        public void Be_Able_To_Scan_For_Deeply_Nested_Classes_Decorated_With_An_Attribute()
        {
            // Arrange
            bool typeWasFound = false;

            // Act
            var configuration = new TypeScannerConfiguration();

            configuration.For<AttributeXyz>()
                .ScanForTypesThatAreDecoratedWithThisAttribute()
                .Do( type =>
                {
                    if ( type == typeof( ClassXyzz ) )
                    {
                        typeWasFound = true;
                    }
                } );

            configuration.Scan();

            // Assert
            Assert.That( typeWasFound );
        }

        [Test]
        public void Throw_An_Exception_If_The_Type_Is_Not_An_Interface_When_Scanning_For_Implementation_Of_An_Interface()
        {
            // Act
            TestDelegate action = () =>
                {
                    var configuration = new TypeScannerConfiguration();

                    configuration.For<AttributeXyz>()
                        .ScanForTypesThatImplementThisInterface()
                        .Do( type => { } );

                    configuration.Scan();
                };

            // Assert
            Assert.Throws<Exception>( action );
        }

        [Test]
        public void Throw_An_Exception_If_The_Type_Is_Not_An_Attribute_When_Scanning_For_Classes_Decorated_With_An_Attribute()
        {
            // Act
            TestDelegate action = () =>
            {
                var configuration = new TypeScannerConfiguration();

                configuration.For<IInterfaceAbc>()
                    .ScanForTypesThatAreDecoratedWithThisAttribute()
                    .Do( type => { } );

                configuration.Scan();
            };

            // Assert
            Assert.Throws<Exception>( action );
        }

        [Test]
        public void Throw_An_Exception_If_The_Type_Is_Not_An_Abstract_Class_When_Scanning_For_Classes_That_Inherit_An_Abstract_Class()
        {
            // Act
            TestDelegate action = () =>
            {
                var configuration = new TypeScannerConfiguration();

                configuration.For<AttributeXyz>()
                    .ScanForTypesThatInheritFromThisAbstractClass()
                    .Do( type => { } );

                configuration.Scan();
            };

            // Assert
            Assert.Throws<Exception>( action );
        }

        [Test]
        public void Throw_An_Exception_If_The_Type_Is_Not_A_Class_When_Scanning_For_Classes_That_Inherit_A_Class()
        {
            // Act
            TestDelegate action = () =>
            {
                var configuration = new TypeScannerConfiguration();

                configuration.For<IInterfaceAbc>()
                    .ScanForTypesThatInheritFromThisClass()
                    .Do( type => { } );

                configuration.Scan();
            };

            // Assert
            Assert.Throws<Exception>( action );
        }

        [Test]
        public void Allow_Specifying_A_Custom_IAssemblyScanner()
        {
            // Arrange
            bool typeWasFound = false;

            // Act
            var configuration = new TypeScannerConfiguration();

            configuration.ScanWith( new CustomAssemblyScanner() );

            configuration.ForAllTypes()
                .Do( type =>
                {
                    if ( type == typeof( CustomAssemblyScanner ) )
                    {
                        typeWasFound = true;
                    }
                    else
                    {
                        throw new Exception( "The CustomAssemblyScanner should only return a CustomAssemblyScanner type." );
                    }
                } );

            configuration.Scan();

            // Assert
            Assert.That( typeWasFound );
        }

        public class ClassA
        {}

        public class ClassB : ClassA
        {}

        public class ClassC : ClassB
        {}

        public abstract class AbstractClassAa
        {}

        public class ClassAa : AbstractClassAa
        {}

        public class ClassBb : ClassAa
        {}

        public interface IInterfaceAbc
        {}

        public class ClassAbc : IInterfaceAbc
        {}

        public class ClassAbcd : ClassAbc
        {}

        public class AttributeXyz : Attribute
        {}

        [AttributeXyz]
        public class ClassXyz
        {}

        public class ClassXyzz : ClassXyz
        {}

        public class CustomAssemblyScanner : IAssemblyScanner
        {
            #region Implementation of IAssemblyScanner

            /// <summary>
            /// Gets assemblies.
            /// </summary>
            /// <returns>List of assemblies.</returns>
            public IEnumerable<Assembly> GetAssemblies()
            {
                return new[] { GetType().Assembly };
            }

            /// <summary>
            /// Gets types in a given assembly.
            /// </summary>
            /// <param name="assembly">Assembly to scan for types.</param>
            /// <returns>List of types.</returns>
            public IEnumerable<Type> GetTypes( Assembly assembly )
            {
                return new[] { typeof( CustomAssemblyScanner ) };
            }

            #endregion Implementation of IAssemblyScanner
        }
    }
}