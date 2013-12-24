namespace FluentTypeScanner
{
    /// <summary>
    /// Scanning strategy.
    /// </summary>
    public enum ScanFor
    {
        /// <summary>
        /// Scans for all types.
        /// </summary>
        AllTypes,

        /// <summary>
        /// Scans for types that are decorated with a particular attribute.
        /// </summary>
        TypesThatAreDecoratedWithThisAttribute,

        /// <summary>
        /// Scans for types that implement a particular interface.
        /// </summary>
        TypesThatImplementThisInterface,

        /// <summary>
        /// Scans for types that inherit from a particular class.
        /// </summary>
        TypesThatInheritFromThisClass,

        /// <summary>
        /// Scans for types that inherit from an abstract class.
        /// </summary>
        TypesThatInheritFromThisAbstractClass
    }
}