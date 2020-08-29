Imports System.Runtime.InteropServices

Namespace Direct2D

    ''' <summary>
    ''' Represents a producer of pixels that can fill an arbitrary 2D plane.
    ''' </summary>
    <ComImport(), Guid("65019f75-8da2-497c-b32c-dfa34e48ede6"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)>
    Public Interface ID2D1Image
        Inherits ID2D1Resource

        Overloads Sub GetFactory(<Out(), MarshalAs(UnmanagedType.Interface)> ByRef factory As ID2D1Factory)
    End Interface

End Namespace