FluentTypeScanner
=================

Project Homepage: https://github.com/randyburden/FluentTypeScanner

Available on NuGet as well: http://www.nuget.org/packages/FluentTypeScanner/

###Description:###

FluentTypeScanner is a .NET library used to scan for types using various scanning strategies expressed in a fluent-based declarative syntax.

FluentTypeScanner was originally developed as a tool to assist in creating extensible modular software by allowing software authors to scan
for types implementing their libraries interfaces, classes, attributes, etc. using a fluent-based declarative syntax.

###What is it?###

FluentTypeScanner is a library to assist you in scanning for various types. It's fluent-based declarative syntax allows you to define which
types you wish to scan for, how to scan for them ( the scanning strategy ), and what to do with the types once they are found.

When making modular software with support for third party extensibility, you could expose a class in which the third party library can inherit 
from and then at runtime the application can scan for types that inherit the class and load in the new functionality allowing the core application
to be extended in new ways. FluentTypeScanner provides one way to scan for those types. It doesn't do any kind of crazy magic or new tricks that
you haven't seen before; it simply provides a nice syntax for declaring what to scan for, how to scan, and what to do once a match has been found.

###Example Usage:###

####Example 1 ( Scanning for types that are decorated with a specified attribute ):####

```csharp
FluentTypeScanner.TypeScanner.Configure( x =>
    {
        x.For<MyExtensibilityAttribute>() // Specify the type to scan for
            .ScanForTypesThatAreDecoratedWithThisAttribute() // Specify the scanning strategy
            .Do( type => Trace.WriteLine( type ) ); // Specify what action to perform
                    
        x.Scan(); // Scan for the types
    } );
```

####Example 2 ( Scanning for types that implement a given interface ):####
```csharp
public static List<IModule> ScanForExtensibilityInterfaces()
{
    List<IModule> modules = new List<IModule>();

    FluentTypeScanner.TypeScanner.Configure( x =>
        {
            x.For<IModule>().ScanForTypesThatImplementThisInterface()
                .Do( type =>
                    {
                        try
                        {
                            var instance = Activator.CreateInstance( type ) as IModule;

                            modules.Add( instance );
                        }
                        catch ( Exception e )
                        {
                            string msg = string.Format( "An error occurred instantiating type {0} while scanning for extensibility interfaces.", type.FullName );

                            throw new Exception( msg, e );
                        }
                    } );

            x.Scan();
        } );

    return modules;
}
```

Check out the unit tests for more examples.

###MIT License:###

Copyright (c) 2013, Randy Burden ( http://randyburden.com ) All rights reserved.

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), 
to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, 
and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS 
IN THE SOFTWARE.
