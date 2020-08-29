Imports System.Runtime.InteropServices

Namespace Direct2D

    ''' <summary>
    '''Renders drawing instructions to a window.
    ''' </summary>
    <ComImport(), Guid("2cd906ab-12e2-11dc-9fed-001143a055f9"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)>
    Public Interface ID2D1LinearGradientBrush
        Inherits ID2D1Brush


        Overloads Sub GetFactory(<Out(), MarshalAs(UnmanagedType.Interface)> ByRef factory As ID2D1Factory)

        'STDMETHOD_(void, SetOpacity)(
        '    FLOAT opacity
        '    ) PURE;
        ''' <summary>
        ''' Sets the opacity for when the brush Is drawn over the entire fill of the brush.
        ''' </summary>
        Overloads Sub SetOpacity(ByVal opacity As Single)

        'STDMETHOD_(void, SetTransform)(
        '    _In_ Const D2D1_MATRIX_3X2_F *transform 
        '    ) PURE;
        '/// <summary>
        '/// Sets the transform that applies to everything drawn by the brush.
        '/// </summary>
        Overloads Sub SetTransform(<[In](), MarshalAs(UnmanagedType.Struct)> ByRef transform As D2D1_MATRIX_3X2_F)

        'STDMETHOD_(FLOAT, GetOpacity)(
        '    ) CONST PURE;
        Overloads Function GetOpacity() As Single

        'STDMETHOD_(void, GetTransform)(
        '    _Out_ D2D1_MATRIX_3X2_F *transform 
        '    ) CONST PURE;
        Overloads Sub GetTransform(<[In](), MarshalAs(UnmanagedType.Struct)> ByRef transform As D2D1_MATRIX_3X2_F)


        'STDMETHOD_(void, SetStartPoint)(
        'D2D1_POINT_2F startPoint
        ') PURE;
        Sub SetStartPoint(<MarshalAs(UnmanagedType.Struct)> ByVal startPoint As D2D1_POINT_2F)


        'STDMETHOD_(void, SetEndPoint)(
        '    D2D1_POINT_2F endPoint
        '    ) PURE;
        ''' <summary>
        ''' Sets the end point of the gradient in local coordinate space. This Is Not
        ''' influenced by the geometry being filled.
        ''' </summary>
        Sub SetEndPoint(<MarshalAs(UnmanagedType.Struct)> ByVal endPoint As D2D1_POINT_2F)

        'STDMETHOD_(D2D1_POINT_2F, GetStartPoint)(
        '    ) CONST PURE;
        Function GetStartPoint() As <MarshalAs(UnmanagedType.Struct)> D2D1_POINT_2F

        'STDMETHOD_(D2D1_POINT_2F, GetEndPoint)(
        '    ) CONST PURE;
        Function GetEndPoint() As <MarshalAs(UnmanagedType.Struct)> D2D1_POINT_2F

        'STDMETHOD_(void, GetGradientStopCollection)(
        '    _Outptr_ ID2D1GradientStopCollection **gradientStopCollection 
        '    ) CONST PURE;
        Sub GetGradientStopCollection(<Out(), MarshalAs(UnmanagedType.Interface)> ByRef gradientStopCollection As ID2D1GradientStopCollection)

    End Interface
End Namespace

