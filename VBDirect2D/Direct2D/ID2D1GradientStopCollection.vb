Imports System.Runtime.InteropServices

Namespace Direct2D

    ''' <summary>
    ''' Represents an collection of gradient stops that can then be the source resource
    ''' for either a linear Or radial gradient brush.
    ''' </summary>
    <ComImport(), Guid("2cd906a7-12e2-11dc-9fed-001143a055f9"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)>
    Public Interface ID2D1GradientStopCollection
        Inherits ID2D1Resource

        Overloads Sub GetFactory(<Out(), MarshalAs(UnmanagedType.Interface)> ByRef factory As ID2D1Factory)

        'STDMETHOD_(UINT32, GetGradientStopCount)(
        '    ) CONST PURE;
        ''' <summary>
        ''' Returns the number of stops in the gradient.
        ''' </summary>
        Function GetGradientStopCount() As UInt32


        'STDMETHOD_(void, GetGradientStops)(
        '    _Out_writes_to_(gradientStopsCount, _Inexpressible_("Retrieved through GetGradientStopCount()") ) D2D1_GRADIENT_STOP *gradientStops,
        '    UINT32 gradientStopsCount
        '    ) CONST PURE;
        ''' <summary>
        ''' Copies the gradient stops from the collection into the caller's interface.  The
        ''' returned colors have straight alpha.
        ''' </summary>
        Sub GetGradientStops(<Out(), MarshalAs(UnmanagedType.LPArray)> ByVal gradientStops() As D2D1_GRADIENT_STOP,
                             ByVal gradientStopsCount As UInt32)


        'STDMETHOD_(D2D1_GAMMA, GetColorInterpolationGamma)(
        '    ) CONST PURE;
        ''' <summary>
        ''' Returns whether the interpolation occurs with 1.0 Or 2.2 gamma.
        ''' </summary>
        Function GetColorInterpolationGamma() As <MarshalAs(UnmanagedType.Struct)> D2D1_GAMMA

        'STDMETHOD_(D2D1_EXTEND_MODE, GetExtendMode)(
        '    ) CONST PURE;
        Function GetExtendMode() As <MarshalAs(UnmanagedType.Struct)> D2D1_EXTEND_MODE
    End Interface
End Namespace

