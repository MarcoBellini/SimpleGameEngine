Imports System.Runtime.InteropServices

Namespace Direct2D

    '''<summary>
    ''' The root brush interface. All brushes can be used to fill or pen a geometry.
    ''' </summary>
    <ComImport(), Guid("2cd906a8-12e2-11dc-9fed-001143a055f9"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)>
    Public Interface ID2D1Brush
        Inherits ID2D1Resource

        Overloads Sub GetFactory(<Out(), MarshalAs(UnmanagedType.Interface)> ByRef factory As ID2D1Factory)

        'STDMETHOD_(void, SetOpacity)(
        '    FLOAT opacity
        '    ) PURE;
        ''' <summary>
        ''' Sets the opacity for when the brush Is drawn over the entire fill of the brush.
        ''' </summary>
        Sub SetOpacity(ByVal opacity As Single)

        'STDMETHOD_(void, SetTransform)(
        '    _In_ Const D2D1_MATRIX_3X2_F *transform 
        '    ) PURE;
        '/// <summary>
        '/// Sets the transform that applies to everything drawn by the brush.
        '/// </summary>
        Sub SetTransform(<[In](), MarshalAs(UnmanagedType.Struct)> ByRef transform As D2D1_MATRIX_3X2_F)

        'STDMETHOD_(FLOAT, GetOpacity)(
        '    ) CONST PURE;
        Function GetOpacity() As Single

        'STDMETHOD_(void, GetTransform)(
        '    _Out_ D2D1_MATRIX_3X2_F *transform 
        '    ) CONST PURE;
        Sub GetTransform(<[In](), MarshalAs(UnmanagedType.Struct)> ByRef transform As D2D1_MATRIX_3X2_F)
    End Interface

End Namespace