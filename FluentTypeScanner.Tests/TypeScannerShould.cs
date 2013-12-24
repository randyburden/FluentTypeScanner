using NUnit.Framework;

namespace FluentTypeScanner.Tests
{
    [TestFixture]
    public class TypeScannerShould
    {
        [Test]
        public void Provide_A_Static_Method_For_Configuring_The_TypeScanner()
        {
            // Arrange
            bool typeClassAWasFound = false;

            // Act
            TypeScanner.Configure( x =>
                {
                    x.ForAllTypes()
                        .Do( type =>
                            {
                                if ( type == typeof ( ClassA ) )
                                {
                                    typeClassAWasFound = true;
                                }
                            } );

                    x.Scan();
                });

            // Assert
            Assert.That( typeClassAWasFound );
        }

        public class ClassA
        {
        }
    }
}