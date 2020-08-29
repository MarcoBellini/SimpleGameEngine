Imports System.Runtime.InteropServices

Namespace Direct2D

    '''<summary>
    ''' Paints an area with a solid color.
    ''' </summary>
    <ComImport(), Guid("2cd906a9-12e2-11dc-9fed-001143a055f9"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)>
    Public Interface ID2D1SolidColorBrush
        Inherits ID2D1Brush

        Overloads Sub GetFactory(<Out(), MarshalAs(UnmanagedType.Interface)> ByRef factory As ID2D1Factory)
        Overloads Sub SetOpacity(ByVal opacity As Single)
        Overloads Sub SetTransform(<[In](), MarshalAs(UnmanagedType.Struct)> ByRef transform As D2D1_MATRIX_3X2_F)
        Overloads Function GetOpacity() As Single
        Overloads Sub GetTransform(<[In](), MarshalAs(UnmanagedType.Struct)> ByRef transform As D2D1_MATRIX_3X2_F)

        'STDMETHOD_(void, SetColor)(
        '_In_ Const D2D1_COLOR_F *color 
        ') PURE;
        Sub SetColor(<[In](), MarshalAs(UnmanagedType.Struct)> ByRef color As D2D1_COLOR_F)

        'STDMETHOD_(D2D1_COLOR_F, GetColor)(
        ') CONST PURE;
        Function GetColor() As <MarshalAs(UnmanagedType.Struct)> D2D1_COLOR_F


    End Interface
End Namespace


