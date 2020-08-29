Imports System.Runtime.InteropServices
Namespace Direct2D

    ''' <summary>
    '''  A bitmap brush allows a bitmap to be used to fill a geometry.
    ''' </summary>
    <ComImport(), Guid("2cd906aa-12e2-11dc-9fed-001143a055f9"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)>
    Public Interface ID2D1BitmapBrush
        Inherits ID2D1Brush
        Overloads Sub GetFactory(<Out(), MarshalAs(UnmanagedType.Interface)> ByRef factory As ID2D1Factory)
        Overloads Sub SetOpacity(ByVal opacity As Single)
        Overloads Sub SetTransform(<[In](), MarshalAs(UnmanagedType.Struct)> ByRef transform As D2D1_MATRIX_3X2_F)
        Overloads Function GetOpacity() As Single
        Overloads Sub GetTransform(<[In](), MarshalAs(UnmanagedType.Struct)> ByRef transform As D2D1_MATRIX_3X2_F)


        'STDMETHOD_(void, SetExtendModeX)(
        '    D2D1_EXTEND_MODE extendModeX
        '    ) PURE;
        ''' <summary>
        ''' Sets how the bitmap Is to be treated outside of its natural extent on the X
        ''' axis.
        ''' </summary>
        Sub SetExtendModeX(ByVal extendModeX As D2D1_EXTEND_MODE)

        'STDMETHOD_(void, SetExtendModeY)(
        '    D2D1_EXTEND_MODE extendModeY
        '    ) PURE;
        ''' <summary>
        ''' Sets how the bitmap Is to be treated outside of its natural extent on the X
        ''' axis.
        ''' </summary>
        Sub SetExtendModeY(ByVal extendModeY As D2D1_EXTEND_MODE)

        'STDMETHOD_(void, SetInterpolationMode)(
        '    D2D1_BITMAP_INTERPOLATION_MODE interpolationMode
        '    ) PURE;
        ''' <summary>
        ''' Sets the interpolation mode used when this brush Is used.
        ''' </summary>
        Sub SetInterpolationMode(ByVal interpolationMode As D2D1_BITMAP_INTERPOLATION_MODE)


        'STDMETHOD_(void, SetBitmap)(
        '    _In_opt_ ID2D1Bitmap *bitmap 
        '    ) PURE;
        ''' <summary>
        ''' Sets the bitmap associated as the source of this brush.
        ''' </summary>
        Sub SetBitmap(<[In](), MarshalAs(UnmanagedType.Interface)> ByVal bitmap As ID2D1Bitmap)


        'STDMETHOD_(D2D1_EXTEND_MODE, GetExtendModeX)(
        '    ) CONST PURE;
        Function GetExtendModeX() As D2D1_EXTEND_MODE

        'STDMETHOD_(D2D1_EXTEND_MODE, GetExtendModeY)(
        '    ) CONST PURE;
        Function GetExtendModeY() As D2D1_EXTEND_MODE

        'STDMETHOD_(D2D1_BITMAP_INTERPOLATION_MODE, GetInterpolationMode)(
        '    ) CONST PURE;
        Function GetInterpolationMode() As D2D1_BITMAP_INTERPOLATION_MODE

        'STDMETHOD_(void, GetBitmap)(
        '    _Outptr_result_maybenull_ ID2D1Bitmap **bitmap 
        '    ) CONST PURE;
        Sub GetBitmap(<Out(), MarshalAs(UnmanagedType.Interface)> ByRef bitmap As ID2D1Bitmap)

    End Interface
End Namespace

