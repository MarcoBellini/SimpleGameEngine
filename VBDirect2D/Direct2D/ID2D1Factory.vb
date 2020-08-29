Imports System.Runtime.InteropServices

Namespace Direct2D

    <ComImport(), Guid("06152247-6f50-465a-9245-118bfd3b6007"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)>
    Public Interface ID2D1Factory

        'STDMETHOD(ReloadSystemMetrics)(
        ') PURE;
        ''' <summary>
        ''' Cause the factory to refresh any system metrics that it might have been snapped
        ''' on factory creation.
        ''' </summary>
        <PreserveSig>
        Function ReloadSystemMetrics() As HRESULT


        '[[deprecated("Deprecated. Use DisplayInformation::LogicalDpi for Windows Store Apps or GetDpiForWindow for desktop apps.")]]
        'STDMETHOD_(void, GetDesktopDpi)(
        '    _Out_ FLOAT *dpiX,
        '    _Out_ FLOAT *dpiY 
        '    ) PURE;
        ''' <summary>
        ''' Retrieves the current desktop DPI. To refresh this, call ReloadSystemMetrics.
        ''' </summary>
        <PreserveSig, Obsolete("Deprecated. Use DisplayInformation::LogicalDpi for Windows Store Apps or GetDpiForWindow for desktop apps")>
        Sub GetDesktopDpi(<Out()> ByRef dpiX As Single,
                          <Out()> ByRef dpiY As Single)


        'STDMETHOD(CreateRectangleGeometry)(
        '    _In_ Const D2D1_RECT_F *rectangle,
        '    _COM_Outptr_ ID2D1RectangleGeometry **rectangleGeometry 
        '    ) PURE;
        <PreserveSig>
        Function CreateRectangleGeometry(<[In](), MarshalAs(UnmanagedType.Struct)> ByRef rectangle As D2D1_RECT_F,
                                    <Out(), MarshalAs(UnmanagedType.Interface)> ByRef rectangleGeometry As ID2D1RectangleGeometry) As HRESULT


        'STDMETHOD(CreateRoundedRectangleGeometry)(
        '    _In_ Const D2D1_ROUNDED_RECT *roundedRectangle,
        '    _COM_Outptr_ ID2D1RoundedRectangleGeometry **roundedRectangleGeometry 
        '    ) PURE;
        <PreserveSig>
        Function CreateRoundedRectangleGeometry(<[In](), MarshalAs(UnmanagedType.Struct)> ByRef roundedRectangle As D2D1_ROUNDED_RECT,
                                           <Out(), MarshalAs(UnmanagedType.Interface)> ByRef roundedRectangleGeometry As ID2D1RoundedRectangleGeometry) As HRESULT


        'STDMETHOD(CreateEllipseGeometry)(
        '    _In_ Const D2D1_ELLIPSE *ellipse,
        '    _COM_Outptr_ ID2D1EllipseGeometry **ellipseGeometry 
        '    ) PURE;
        <PreserveSig>
        Function CreateEllipseGeometry(<[In](), MarshalAs(UnmanagedType.Struct)> ByRef ellipse As D2D1_ELLIPSE,
                                  <Out(), MarshalAs(UnmanagedType.Interface)> ByRef ellipseGeometry As ID2D1EllipseGeometry) As HRESULT


        'STDMETHOD(CreateGeometryGroup)(
        '    D2D1_FILL_MODE fillMode,
        '    _In_reads_(geometriesCount) ID2D1Geometry **geometries,
        '    UINT32 geometriesCount,
        '    _COM_Outptr_ ID2D1GeometryGroup **geometryGroup 
        '    ) PURE;
        ''' <summary>
        ''' Create a geometry which holds other geometries.
        ''' </summary>
        <PreserveSig>
        Function CreateGeometryGroup(ByVal fillMode As D2D1_FILL_MODE,
                                <[In](), MarshalAs(UnmanagedType.LPArray)> ByVal geometries() As ID2D1Geometry,
                                ByVal geometriesCount As UInt32,
                                <Out(), MarshalAs(UnmanagedType.Interface)> ByRef geometryGroup As ID2D1GeometryGroup) As HRESULT

        'STDMETHOD(CreateTransformedGeometry)(
        '    _In_ ID2D1Geometry *sourceGeometry,
        '    _In_ Const D2D1_MATRIX_3X2_F *transform,
        '    _COM_Outptr_ ID2D1TransformedGeometry **transformedGeometry 
        '    ) PURE;
        <PreserveSig>
        Function CreateTransformedGeometry(<[In](), MarshalAs(UnmanagedType.Interface)> ByVal sourceGeometry As ID2D1Geometry,
                                      <[In](), MarshalAs(UnmanagedType.LPArray)> ByRef transform As D2D1_MATRIX_3X2_F,
                                      <Out(), MarshalAs(UnmanagedType.Interface)> ByRef transformedGeometry As ID2D1TransformedGeometry) As HRESULT

        'STDMETHOD(CreatePathGeometry)(
        '    _COM_Outptr_ ID2D1PathGeometry **pathGeometry 
        '    ) PURE;
        '''<summary>
        ''' Returns an initially empty path geometry interface. A geometry sink Is created
        ''' off the interface to populate it.
        ''' </summary>
        <PreserveSig>
        Function CreatePathGeometry(<Out(), MarshalAs(UnmanagedType.Interface)> ByRef pathGeometry As ID2D1PathGeometry) As HRESULT



        'STDMETHOD(CreateStrokeStyle)(
        '    _In_ Const D2D1_STROKE_STYLE_PROPERTIES *strokeStyleProperties,
        '    _In_reads_opt_(dashesCount) CONST FLOAT *dashes,
        '    UINT32 dashesCount,
        '    _COM_Outptr_ ID2D1StrokeStyle **strokeStyle 
        '    ) PURE;
        ''' <summary>
        ''' Allows a non-default stroke style to be specified for a given geometry at draw
        ''' time.
        ''' </summary>
        <PreserveSig>
        Function CreateStrokeStyle(<[In](), MarshalAs(UnmanagedType.Struct)> ByRef strokeStyleProperties As D2D1_STROKE_STYLE_PROPERTIES,
                              <[In](), MarshalAs(UnmanagedType.LPArray)> ByVal dashes() As Single,
                              ByVal dashesCount As UInt32,
                              <Out(), MarshalAs(UnmanagedType.Interface)> strokeStyle As ID2D1StrokeStyle) As HRESULT

        'STDMETHOD(CreateDrawingStateBlock)(
        '    _In_opt_ Const D2D1_DRAWING_STATE_DESCRIPTION *drawingStateDescription,
        '    _In_opt_ IDWriteRenderingParams *textRenderingParams,
        '    _COM_Outptr_ ID2D1DrawingStateBlock **drawingStateBlock 
        '    ) PURE;
        '''<summary>
        ''' Creates a New drawing state block, this can be used in subsequent
        ''' SaveDrawingState And RestoreDrawingState operations on the render target.
        ''' </summary>
        <PreserveSig>
        Function CreateDrawingStateBlock(<[In](), MarshalAs(UnmanagedType.Struct)> ByRef drawingStateDescription As D2D1_DRAWING_STATE_DESCRIPTION,
                                    <[In](), MarshalAs(UnmanagedType.Interface)> ByVal textRenderingParams As IDWriteRenderingParams,
                                     <Out(), MarshalAs(UnmanagedType.Interface)> ByRef drawingStateBlock As ID2D1DrawingStateBlock) As HRESULT

        'STDMETHOD(CreateWicBitmapRenderTarget)(
        '    _In_ IWICBitmap *target,
        '    _In_ Const D2D1_RENDER_TARGET_PROPERTIES *renderTargetProperties,
        '    _COM_Outptr_ ID2D1RenderTarget **renderTarget 
        '    ) PURE;
        ''' <summary>
        ''' Creates a render target which Is a source of bitmaps.
        '''</summary>
        <PreserveSig>
        Function CreateWicBitmapRenderTarget(<[In](), MarshalAs(UnmanagedType.Interface)> ByVal target As IWICBitmap,
                                        <[In](), MarshalAs(UnmanagedType.Struct)> ByRef renderTargetProperties As D2D1_RENDER_TARGET_PROPERTIES,
                                        <Out(), MarshalAs(UnmanagedType.Interface)> ByRef renderTarget As ID2D1RenderTarget) As HRESULT



        'STDMETHOD(CreateHwndRenderTarget)(
        '    _In_ Const D2D1_RENDER_TARGET_PROPERTIES *renderTargetProperties,
        '    _In_ Const D2D1_HWND_RENDER_TARGET_PROPERTIES *hwndRenderTargetProperties,
        '    _COM_Outptr_ ID2D1HwndRenderTarget **hwndRenderTarget 
        '    ) PURE;
        '''<summary>
        ''' Creates a render target that appears on the display.
        ''' </summary>
        <PreserveSig>
        Function CreateHwndRenderTarget(<[In](), MarshalAs(UnmanagedType.Struct)> ByRef renderTargetProperties As D2D1_RENDER_TARGET_PROPERTIES,
                                   <[In](), MarshalAs(UnmanagedType.Struct)> ByRef hwndRenderTargetProperties As D2D1_HWND_RENDER_TARGET_PROPERTIES,
                                   <Out(), MarshalAs(UnmanagedType.Interface)> ByRef hwndRenderTarget As ID2D1HwndRenderTarget) As HRESULT


        'STDMETHOD(CreateDxgiSurfaceRenderTarget)(
        '    _In_ IDXGISurface *dxgiSurface,
        '    _In_ Const D2D1_RENDER_TARGET_PROPERTIES *renderTargetProperties,
        '    _COM_Outptr_ ID2D1RenderTarget **renderTarget 
        '    ) PURE;
        ''' <summary>
        ''' Creates a render target that draws to a DXGI Surface. The device that owns the
        ''' surface Is used for rendering.
        ''' </summary>
        <PreserveSig>
        Function CreateDxgiSurfaceRenderTarget(<[In](), MarshalAs(UnmanagedType.Interface)> ByVal dxgiSurface As IDXGISurface,
                                          <[In](), MarshalAs(UnmanagedType.Struct)> ByRef renderTargetProperties As D2D1_RENDER_TARGET_PROPERTIES,
                                          <Out(), MarshalAs(UnmanagedType.Interface)> ByRef renderTarget As ID2D1RenderTarget) As HRESULT


        'STDMETHOD(CreateDCRenderTarget)(
        '    _In_ Const D2D1_RENDER_TARGET_PROPERTIES *renderTargetProperties,
        '    _COM_Outptr_ ID2D1DCRenderTarget **dcRenderTarget 
        '    ) PURE;
        ''' <summary>
        ''' Creates a render target that draws to a GDI device context.
        ''' </summary>
        <PreserveSig>
        Function CreateDCRenderTarget(<[In](), MarshalAs(UnmanagedType.Struct)> ByRef renderTargetProperties As D2D1_RENDER_TARGET_PROPERTIES,
                                 <Out(), MarshalAs(UnmanagedType.Interface)> ByRef dcRenderTarget As ID2D1DCRenderTarget) As HRESULT

    End Interface
End Namespace

