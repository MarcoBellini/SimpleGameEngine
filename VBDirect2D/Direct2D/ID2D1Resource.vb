Imports System.Runtime.InteropServices

Namespace Direct2D

    '''<summary>
    ''' The root interface for all resources in D2D.
    ''' </summary>
    <ComImport(), Guid("2cd90691-12e2-11dc-9fed-001143a055f9"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)>
    Public Interface ID2D1Resource


        'STDMETHOD_(void, GetFactory)(
        '    _Outptr_ ID2D1Factory **factory 
        '    ) CONST PURE;
        ''' <summary>
        ''' Retrieve the factory associated with this resource.
        ''' </summary>
        Sub GetFactory(<Out(), MarshalAs(UnmanagedType.Interface)> ByRef factory As ID2D1Factory)

    End Interface
End Namespace

