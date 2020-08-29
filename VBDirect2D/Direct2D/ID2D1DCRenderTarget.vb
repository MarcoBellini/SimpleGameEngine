Imports System.Runtime.InteropServices

Namespace Direct2D


    ''' <summary>
    ''' Issues drawing commands to a GDI device context.
    ''' </summary>
    <ComImport(), Guid("1c51bc64-de61-46fd-9899-63a5d8f03950"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)>
    Public Interface ID2D1DCRenderTarget
        Inherits ID2D1RenderTarget

        Overloads Sub GetFactory(<Out(), MarshalAs(UnmanagedType.Interface)> ByRef factory As ID2D1Factory)


        'STDMETHOD(CreateBitmap)(
        '    D2D1_SIZE_U size,
        '    _In_opt_ Const void *srcData,
        '    UINT32 pitch,
        '    _In_ Const D2D1_BITMAP_PROPERTIES *bitmapProperties,
        '    _COM_Outptr_ ID2D1Bitmap **bitmap 
        '    ) PURE;
        ''' <summary>
        ''' Create a D2D bitmap by copying from memory, Or create uninitialized.
        ''' </summary>
        Overloads Function CreateBitmap(<MarshalAs(UnmanagedType.Struct)> ByVal size As D2D1_SIZE_U,
                              <[In]()> ByVal srcData As IntPtr,
                              ByVal pitch As UInt32,
                              <[In](), MarshalAs(UnmanagedType.Struct)> ByRef bitmapProperties As D2D1_BITMAP_PROPERTIES,
                              <Out(), MarshalAs(UnmanagedType.Interface)> ByRef bitmap As ID2D1Bitmap) As HRESULT


        'STDMETHOD(CreateBitmapFromWicBitmap)(
        '    _In_ IWICBitmapSource *wicBitmapSource,
        '    _In_opt_ Const D2D1_BITMAP_PROPERTIES *bitmapProperties,
        '    _COM_Outptr_ ID2D1Bitmap **bitmap 
        '    ) PURE;
        ''' <summary>
        ''' Create a D2D bitmap by copying a WIC bitmap.
        ''' </summary>
        Overloads Function CreateBitmapFromWicBitmap(<[In](), MarshalAs(UnmanagedType.Interface)> ByVal wicBitmapSource As IWICBitmapSource,
                                           <[In](), MarshalAs(UnmanagedType.Struct)> ByRef bitmapProperties As D2D1_BITMAP_PROPERTIES,
                                           <Out(), MarshalAs(UnmanagedType.Interface)> ByRef bitmap As ID2D1Bitmap) As HRESULT


        'STDMETHOD(CreateSharedBitmap)(
        '    _In_ REFIID riid,
        '    _Inout_ void *data,
        '    _In_opt_ Const D2D1_BITMAP_PROPERTIES *bitmapProperties,
        '    _COM_Outptr_ ID2D1Bitmap **bitmap 
        '    ) PURE;
        ''' <summary>
        ''' Create a D2D bitmap by sharing bits from another resource. The bitmap must be
        ''' compatible with the render target for the call to succeed. For example, an
        ''' IWICBitmap can be shared with a software target, Or a DXGI surface can be shared
        ''' with a DXGI render target. 
        ''' </summary>
        Overloads Function CreateSharedBitmap(<[In](), MarshalAs(UnmanagedType.Struct)> ByRef riid As Guid,
                                    <[In](), Out()> ByVal data As IntPtr,
                                    <[In](), MarshalAs(UnmanagedType.Struct)> ByRef bitmapProperties As D2D1_BITMAP_PROPERTIES,
                                    <Out(), MarshalAs(UnmanagedType.Interface)> ByRef bitmap As ID2D1Bitmap) As HRESULT


        'STDMETHOD(CreateBitmapBrush)(
        '    _In_opt_ ID2D1Bitmap *bitmap,
        '    _In_opt_ Const D2D1_BITMAP_BRUSH_PROPERTIES *bitmapBrushProperties,
        '    _In_opt_ Const D2D1_BRUSH_PROPERTIES *brushProperties,
        '    _COM_Outptr_ ID2D1BitmapBrush **bitmapBrush 
        '    ) PURE;
        ''' <summary>
        ''' Creates a bitmap brush. The bitmap Is scaled, rotated, skewed Or tiled to fill
        ''' Or pen a geometry.
        ''' </summary>
        Overloads Function CreateBitmapBrush(<[In](), MarshalAs(UnmanagedType.Interface)> ByRef bitmap As ID2D1Bitmap,
                                   <[In](), MarshalAs(UnmanagedType.Struct)> ByRef bitmapBrushProperties As D2D1_BITMAP_BRUSH_PROPERTIES,
                                   <[In](), MarshalAs(UnmanagedType.Struct)> ByRef brushProperties As D2D1_BRUSH_PROPERTIES,
                                   <Out(), MarshalAs(UnmanagedType.Interface)> ByRef bitmapBrush As ID2D1BitmapBrush) As HRESULT


        'STDMETHOD(CreateSolidColorBrush)(
        '    _In_ Const D2D1_COLOR_F *color,
        '    _In_opt_ Const D2D1_BRUSH_PROPERTIES *brushProperties,
        '    _COM_Outptr_ ID2D1SolidColorBrush **solidColorBrush 
        '    ) PURE;
        Overloads Function CreateSolidColorBrush(<[In](), MarshalAs(UnmanagedType.Struct)> ByRef color As D2D1_COLOR_F,
                                       <[In](), MarshalAs(UnmanagedType.Struct)> ByRef brushProperties As D2D1_BRUSH_PROPERTIES,
                                       <Out(), MarshalAs(UnmanagedType.Interface)> ByRef solidColorBrush As ID2D1SolidColorBrush) As HRESULT


        'STDMETHOD(CreateGradientStopCollection)(
        '    _In_reads_(gradientStopsCount) CONST D2D1_GRADIENT_STOP *gradientStops,
        '    _In_range_(>=,1) UINT32 gradientStopsCount,
        '    D2D1_GAMMA colorInterpolationGamma,
        '    D2D1_EXTEND_MODE extendMode,
        '    _COM_Outptr_ ID2D1GradientStopCollection **gradientStopCollection 
        '    ) PURE;
        ''' <summary>
        ''' A gradient stop collection represents a set of stops in an ideal unit length.
        ''' This Is the source resource for a linear gradient And radial gradient brush.
        ''' </summary>
        ''' <param name="colorInterpolationGamma">Specifies which space the color
        ''' interpolation occurs in.</param>
        ''' <param name="extendMode">Specifies how the gradient will be extended outside of
        ''' the unit length.</param>
        Overloads Function CreateGradientStopCollection(<[In](), MarshalAs(UnmanagedType.LPArray)> ByVal color() As D2D1_GRADIENT_STOP,
                                              <[In]()> ByVal gradientStopsCount As UInt32,
                                              ByVal colorInterpolationGamma As D2D1_GAMMA,
                                              ByVal extendMode As D2D1_EXTEND_MODE,
                                              <Out(), MarshalAs(UnmanagedType.Interface)> ByRef gradientStopCollection As ID2D1GradientStopCollection) As HRESULT


        'STDMETHOD(CreateLinearGradientBrush)(
        '    _In_ Const D2D1_LINEAR_GRADIENT_BRUSH_PROPERTIES *linearGradientBrushProperties,
        '    _In_opt_ Const D2D1_BRUSH_PROPERTIES *brushProperties,
        '    _In_ ID2D1GradientStopCollection *gradientStopCollection,
        '    _COM_Outptr_ ID2D1LinearGradientBrush **linearGradientBrush 
        '    ) PURE;
        Overloads Function CreateLinearGradientBrush(<[In](), MarshalAs(UnmanagedType.Struct)> ByRef linearGradientBrushProperties As D2D1_LINEAR_GRADIENT_BRUSH_PROPERTIES,
                                           <[In](), MarshalAs(UnmanagedType.Struct)> ByRef brushProperties As D2D1_BRUSH_PROPERTIES,
                                           <[In](), MarshalAs(UnmanagedType.Interface)> ByVal gradientStopCollection As ID2D1GradientStopCollection,
                                           <Out(), MarshalAs(UnmanagedType.Interface)> ByRef linearGradientBrush As ID2D1LinearGradientBrush) As HRESULT

        'STDMETHOD(CreateRadialGradientBrush)(
        '    _In_ Const D2D1_RADIAL_GRADIENT_BRUSH_PROPERTIES *radialGradientBrushProperties,
        '    _In_opt_ Const D2D1_BRUSH_PROPERTIES *brushProperties,
        '    _In_ ID2D1GradientStopCollection *gradientStopCollection,
        '    _COM_Outptr_ ID2D1RadialGradientBrush **radialGradientBrush 
        '    ) PURE;
        Overloads Function CreateRadialGradientBrush(<[In](), MarshalAs(UnmanagedType.Struct)> ByRef radialGradientBrushProperties As D2D1_RADIAL_GRADIENT_BRUSH_PROPERTIES,
                                           <[In](), MarshalAs(UnmanagedType.Struct)> ByRef brushProperties As D2D1_BRUSH_PROPERTIES,
                                           <[In](), MarshalAs(UnmanagedType.Interface)> ByVal gradientStopCollection As ID2D1GradientStopCollection,
                                           <Out(), MarshalAs(UnmanagedType.Interface)> ByRef radialGradientBrush As ID2D1RadialGradientBrush) As HRESULT


        'STDMETHOD(CreateCompatibleRenderTarget)(
        '    _In_opt_ Const D2D1_SIZE_F *desiredSize,
        '    _In_opt_ Const D2D1_SIZE_U *desiredPixelSize,
        '    _In_opt_ Const D2D1_PIXEL_FORMAT *desiredFormat,
        '    D2D1_COMPATIBLE_RENDER_TARGET_OPTIONS options,
        '    _COM_Outptr_ ID2D1BitmapRenderTarget **bitmapRenderTarget 
        '    ) PURE;
        ''' <summary>
        ''' Creates a bitmap render target whose bitmap can be used as a source for
        ''' rendering in the API.
        ''' </summary>
        ''' <param name="desiredSize">The requested size of the target in DIPs. If the pixel
        ''' size Is Not specified, the DPI Is inherited from the parent target. However, the
        ''' render target will never contain a fractional number of pixels.</param>
        ''' <param name="desiredPixelSize">The requested size of the render target in
        ''' pixels. If the DIP size Is also specified, the DPI Is calculated from these two
        ''' values. If the desired size Is Not specified, the DPI Is inherited from the
        ''' parent render target. If neither value Is specified, the compatible render
        ''' target will be the same size And have the same DPI as the parent target.</param>
        ''' <param name="desiredFormat">The desired pixel format. The format must be
        ''' compatible with the parent render target type. If the format Is Not specified,
        ''' it will be inherited from the parent render target.</param>
        ''' <param name="options">Allows the caller to retrieve a GDI compatible render
        ''' target.</param>
        ''' <param name="bitmapRenderTarget">The returned bitmap render target.</param>
        Overloads Function CreateCompatibleRenderTarget(<[In](), MarshalAs(UnmanagedType.Struct)> ByRef desiredSize As D2D1_SIZE_F,
                                              <[In](), MarshalAs(UnmanagedType.Struct)> ByRef desiredPixelSize As D2D1_SIZE_U,
                                              <[In](), MarshalAs(UnmanagedType.Struct)> ByRef desiredFormat As D2D1_PIXEL_FORMAT,
                                              ByVal options As D2D1_COMPATIBLE_RENDER_TARGET_OPTIONS,
                                              <Out(), MarshalAs(UnmanagedType.Interface)> ByRef bitmapRenderTarget As ID2D1BitmapRenderTarget) As HRESULT

        'STDMETHOD(CreateLayer)(
        '    _In_opt_ Const D2D1_SIZE_F *size,
        '    _COM_Outptr_ ID2D1Layer **layer 
        '    ) PURE;
        ''' <summary>
        ''' Creates a layer resource that can be used on any target And which will resize
        ''' under the covers if necessary.
        ''' </summary>
        ''' <param name="size">The resolution independent minimum size hint for the layer
        ''' resource. Specify this to prevent unwanted reallocation of the layer backing
        ''' store. The size Is in DIPs, but, it Is unaffected by the current world
        ''' transform. If the size Is unspecified, the returned resource Is a placeholder
        ''' And the backing store will be allocated to be the minimum size that can hold the
        ''' content when the layer Is pushed.</param>
        Overloads Function CreateLayer(<[In](), MarshalAs(UnmanagedType.Struct)> ByRef size As D2D1_SIZE_F,
                             <Out(), MarshalAs(UnmanagedType.Interface)> ByRef layer As ID2D1Layer) As HRESULT


        'STDMETHOD(CreateMesh)(
        '    _COM_Outptr_ ID2D1Mesh **mesh 
        '    ) PURE;
        ''' <summary>
        ''' Create a D2D mesh.
        ''' </summary>
        Overloads Function CreateMesh(<Out(), MarshalAs(UnmanagedType.Interface)> ByRef mesh As ID2D1Mesh) As HRESULT


        'STDMETHOD_(void, DrawLine)(
        '    D2D1_POINT_2F point0,
        '    D2D1_POINT_2F point1,
        '    _In_ ID2D1Brush *brush,
        '    FLOAT strokeWidth = 1.0F,
        '    _In_opt_ ID2D1StrokeStyle *strokeStyle = NULL 
        '    ) PURE;
        Overloads Sub DrawLine(<MarshalAs(UnmanagedType.Struct)> ByVal point0 As D2D1_POINT_2F,
                     <MarshalAs(UnmanagedType.Struct)> ByVal point1 As D2D1_POINT_2F,
                     <[In](), MarshalAs(UnmanagedType.Interface)> ByVal brush As ID2D1Brush,
                     Optional ByVal strokeWidth As Single = 1.0F,
                     <[In](), MarshalAs(UnmanagedType.Interface)> Optional ByVal strokeStyle As ID2D1StrokeStyle = Nothing)

        'STDMETHOD_(void, DrawRectangle)(
        '    _In_ Const D2D1_RECT_F *rect,
        '    _In_ ID2D1Brush *brush,
        '    FLOAT strokeWidth = 1.0F,
        '    _In_opt_ ID2D1StrokeStyle *strokeStyle = NULL 
        '    ) PURE;
        Overloads Sub DrawRectangle(<[In](), MarshalAs(UnmanagedType.Struct)> ByRef rect As D2D1_RECT_F,
                         <[In](), MarshalAs(UnmanagedType.Interface)> ByVal brush As ID2D1Brush,
                         Optional ByVal strokeWidth As Single = 1.0F,
                         <[In](), MarshalAs(UnmanagedType.Interface)> Optional ByVal strokeStyle As ID2D1StrokeStyle = Nothing)


        'STDMETHOD_(void, FillRectangle)(
        '    _In_ Const D2D1_RECT_F *rect,
        '    _In_ ID2D1Brush *brush 
        '    ) PURE;
        Overloads Sub FillRectangle(<[In](), MarshalAs(UnmanagedType.Struct)> ByRef rect As D2D1_RECT_F,
                          <[In](), MarshalAs(UnmanagedType.Interface)> ByVal brush As ID2D1Brush)

        'STDMETHOD_(void, DrawRoundedRectangle)(
        '    _In_ Const D2D1_ROUNDED_RECT *roundedRect,
        '    _In_ ID2D1Brush *brush,
        '    FLOAT strokeWidth = 1.0F,
        '    _In_opt_ ID2D1StrokeStyle *strokeStyle = NULL 
        '    ) PURE;
        Overloads Sub DrawRoundedRectangle(<[In](), MarshalAs(UnmanagedType.Struct)> ByRef roundedRect As D2D1_ROUNDED_RECT,
                                 <[In](), MarshalAs(UnmanagedType.Interface)> ByVal brush As ID2D1Brush,
                                 Optional ByVal strokeWidth As Single = 1.0F,
                                 <[In](), MarshalAs(UnmanagedType.Interface)> Optional ByVal strokeStyle As ID2D1StrokeStyle = Nothing)

        'STDMETHOD_(void, FillRoundedRectangle)(
        '    _In_ Const D2D1_ROUNDED_RECT *roundedRect,
        '    _In_ ID2D1Brush *brush 
        '    ) PURE;
        Overloads Sub FillRoundedRectangle(<[In](), MarshalAs(UnmanagedType.Struct)> ByRef roundedRect As D2D1_ROUNDED_RECT,
                                 <[In](), MarshalAs(UnmanagedType.Interface)> ByVal brush As ID2D1Brush)

        'STDMETHOD_(void, DrawEllipse)(
        '    _In_ Const D2D1_ELLIPSE *ellipse,
        '    _In_ ID2D1Brush *brush,
        '    FLOAT strokeWidth = 1.0F,
        '    _In_opt_ ID2D1StrokeStyle *strokeStyle = NULL 
        '    ) PURE;
        Overloads Sub DrawEllipse(<[In](), MarshalAs(UnmanagedType.Struct)> ByRef ellipse As D2D1_ELLIPSE,
                        <[In](), MarshalAs(UnmanagedType.Interface)> ByVal brush As ID2D1Brush,
                        Optional ByVal strokeWidth As Single = 1.0F,
                        <[In](), MarshalAs(UnmanagedType.Interface)> Optional ByVal strokeStyle As ID2D1StrokeStyle = Nothing)

        'STDMETHOD_(void, FillEllipse)(
        '    _In_ Const D2D1_ELLIPSE *ellipse,
        '    _In_ ID2D1Brush *brush 
        '    ) PURE;
        Overloads Sub FillEllipse(<[In](), MarshalAs(UnmanagedType.Struct)> ByRef ellipse As D2D1_ELLIPSE,
                        <[In](), MarshalAs(UnmanagedType.Interface)> ByVal brush As ID2D1Brush)


        'STDMETHOD_(void, DrawGeometry)(
        '    _In_ ID2D1Geometry *geometry,
        '    _In_ ID2D1Brush *brush,
        '    FLOAT strokeWidth = 1.0F,
        '    _In_opt_ ID2D1StrokeStyle *strokeStyle = NULL 
        '    ) PURE;
        Overloads Sub DrawGeometry(<[In](), MarshalAs(UnmanagedType.Interface)> ByVal geometry As ID2D1Geometry,
                        <[In](), MarshalAs(UnmanagedType.Interface)> ByVal brush As ID2D1Brush,
                        Optional ByVal strokeWidth As Single = 1.0F,
                        <[In](), MarshalAs(UnmanagedType.Interface)> Optional ByVal strokeStyle As ID2D1StrokeStyle = Nothing)


        'STDMETHOD_(void, FillGeometry)(
        '    _In_ ID2D1Geometry *geometry,
        '    _In_ ID2D1Brush *brush,
        '    _In_opt_ ID2D1Brush *opacityBrush = NULL 
        '    ) PURE;
        ''' <param name="opacityBrush">An optionally specified opacity brush. Only the alpha
        ''' channel of the corresponding brush will be sampled And will be applied to the
        ''' entire fill of the geometry. If this brush Is specified, the fill brush must be
        ''' a bitmap brush with an extend mode of D2D1_EXTEND_MODE_CLAMP.</param>
        Overloads Sub FillGeometry(<[In](), MarshalAs(UnmanagedType.Interface)> ByVal geometry As ID2D1Geometry,
                         <[In](), MarshalAs(UnmanagedType.Interface)> ByVal brush As ID2D1Brush,
                         <[In](), MarshalAs(UnmanagedType.Interface)> Optional ByVal opacityBrush As ID2D1Brush = Nothing)


        'STDMETHOD_(void, FillMesh)(
        '    _In_ ID2D1Mesh *mesh,
        '    _In_ ID2D1Brush *brush 
        '    ) PURE;
        ''' <summary>
        ''' Fill a mesh. Since meshes can only render aliased content, the render target
        ''' antialiasing mode must be set to aliased.
        ''' </summary>
        Overloads Sub FillMesh(<[In](), MarshalAs(UnmanagedType.Interface)> ByVal mesh As ID2D1Mesh,
                     <[In](), MarshalAs(UnmanagedType.Interface)> ByVal brush As ID2D1Brush)


        'STDMETHOD_(void, FillOpacityMask)(
        '    _In_ ID2D1Bitmap *opacityMask,
        '    _In_ ID2D1Brush *brush,
        '    D2D1_OPACITY_MASK_CONTENT content,
        '    _In_opt_ Const D2D1_RECT_F *destinationRectangle = NULL,
        '    _In_opt_ Const D2D1_RECT_F *sourceRectangle = NULL 
        '    ) PURE;
        ''' <summary>
        ''' Fill using the alpha channel of the supplied opacity mask bitmap. The brush
        ''' opacity will be modulated by the mask. The render target antialiasing mode must
        ''' be set to aliased.
        ''' </summary>
        Overloads Sub FillOpacityMask(<[In](), MarshalAs(UnmanagedType.Interface)> ByVal opacityMask As ID2D1Bitmap,
                            <[In](), MarshalAs(UnmanagedType.Interface)> ByVal brush As ID2D1Brush,
                            ByVal content As D2D1_OPACITY_MASK_CONTENT,
                            <[In](), MarshalAs(UnmanagedType.Struct)> Optional ByRef destinationRectangle As D2D1_RECT_F = Nothing,
                            <[In](), MarshalAs(UnmanagedType.Struct)> Optional ByRef sourceRectangle As D2D1_RECT_F = Nothing)

        'STDMETHOD_(void, DrawBitmap)(
        '    _In_ ID2D1Bitmap *bitmap,
        '    _In_opt_ Const D2D1_RECT_F *destinationRectangle = NULL,
        '    FLOAT opacity = 1.0F,
        '    D2D1_BITMAP_INTERPOLATION_MODE interpolationMode = D2D1_BITMAP_INTERPOLATION_MODE_LINEAR,
        '    _In_opt_ Const D2D1_RECT_F *sourceRectangle = NULL 
        '    ) PURE;
        Overloads Sub DrawBitmap(<[In](), MarshalAs(UnmanagedType.Interface)> ByVal bitmap As ID2D1Bitmap,
                       <[In](), MarshalAs(UnmanagedType.Struct)> Optional ByRef destinationRectangle As D2D1_RECT_F = Nothing,
                       Optional ByVal opacity As Single = 1.0F,
                       Optional ByVal interpolationMode As D2D1_BITMAP_INTERPOLATION_MODE = D2D1_BITMAP_INTERPOLATION_MODE.D2D1_BITMAP_INTERPOLATION_MODE_LINEAR,
                       <[In](), MarshalAs(UnmanagedType.Struct)> Optional ByRef sourceRectangle As D2D1_RECT_F = Nothing)


        'STDMETHOD_(void, DrawText)(
        '    _In_reads_(stringLength) CONST WCHAR *string,
        '    UINT32 stringLength,
        '    _In_ IDWriteTextFormat *textFormat,
        '    _In_ Const D2D1_RECT_F *layoutRect,
        '    _In_ ID2D1Brush *defaultFillBrush,
        '    D2D1_DRAW_TEXT_OPTIONS options = D2D1_DRAW_TEXT_OPTIONS_NONE,
        '    DWRITE_MEASURING_MODE measuringMode = DWRITE_MEASURING_MODE_NATURAL 
        '    ) PURE;
        ''' <summary>
        ''' Draws the text within the given layout rectangle And by default also performs
        ''' baseline snapping.
        ''' </summary>
        Overloads Sub DrawText(<[In](), MarshalAs(UnmanagedType.LPWStr)> ByVal str As String,
                     ByVal stringLength As UInt32,
                     <[In](), MarshalAs(UnmanagedType.Interface)> ByVal textFormat As IDWriteTextFormat,
                     <[In](), MarshalAs(UnmanagedType.Struct)> ByRef layoutRect As D2D1_RECT_F,
                     <[In](), MarshalAs(UnmanagedType.Interface)> ByVal brush As ID2D1Brush,
                     Optional ByVal options As D2D1_DRAW_TEXT_OPTIONS = D2D1_DRAW_TEXT_OPTIONS.D2D1_DRAW_TEXT_OPTIONS_NONE,
                     Optional ByVal measuringMode As DWRITE_MEASURING_MODE = DWRITE_MEASURING_MODE.DWRITE_MEASURING_MODE_NATURAL)


        'STDMETHOD_(void, DrawTextLayout)(
        '    D2D1_POINT_2F origin,
        '    _In_ IDWriteTextLayout *textLayout,
        '    _In_ ID2D1Brush *defaultFillBrush,
        '    D2D1_DRAW_TEXT_OPTIONS options = D2D1_DRAW_TEXT_OPTIONS_NONE
        '    ) PURE;
        ''' <summary>
        ''' Draw a text layout object. If the layout Is Not Overloads Subsequently changed, this can
        ''' be more efficient than DrawText when drawing the same layout repeatedly.
        ''' </summary>
        ''' <param name="options">The specified text options. If D2D1_DRAW_TEXT_OPTIONS_CLIP
        ''' Is used, the text Is clipped to the layout bounds. These bounds are derived from
        ''' the origin And the layout bounds of the corresponding IDWriteTextLayout object.
        ''' </param>
        Overloads Sub DrawTextLayout(<MarshalAs(UnmanagedType.Struct)> ByVal origin As D2D1_POINT_2F,
                           <[In](), MarshalAs(UnmanagedType.Interface)> ByVal textLayout As IDWriteTextLayout,
                           <[In](), MarshalAs(UnmanagedType.Interface)> ByVal defaultFillBrush As ID2D1Brush,
                           Optional ByVal options As D2D1_DRAW_TEXT_OPTIONS = D2D1_DRAW_TEXT_OPTIONS.D2D1_DRAW_TEXT_OPTIONS_NONE)

        'STDMETHOD_(void, DrawGlyphRun)(
        '    D2D1_POINT_2F baselineOrigin,
        '    _In_ Const DWRITE_GLYPH_RUN *glyphRun,
        '    _In_ ID2D1Brush *foregroundBrush,
        '    DWRITE_MEASURING_MODE measuringMode = DWRITE_MEASURING_MODE_NATURAL
        '    ) PURE;
        <Obsolete("This Overloads Function is not implemented!")>
        Overloads Sub DrawGlyphRun(<MarshalAs(UnmanagedType.Struct)> ByVal baselineOrigin As D2D1_POINT_2F,
                         <[In]()> ByVal glyphRun As IntPtr,
                         <[In](), MarshalAs(UnmanagedType.Interface)> ByVal foregroundBrush As ID2D1Brush,
                         Optional ByVal options As DWRITE_MEASURING_MODE = DWRITE_MEASURING_MODE.DWRITE_MEASURING_MODE_NATURAL)

        'STDMETHOD_(void, SetTransform)(
        '    _In_ Const D2D1_MATRIX_3X2_F *transform 
        '    ) PURE;

        Overloads Sub SetTransform(<[In](), MarshalAs(UnmanagedType.Struct)> ByRef transform As D2D1_MATRIX_3X2_F)

        'STDMETHOD_(void, GetTransform)(
        '    _Out_ D2D1_MATRIX_3X2_F *transform 
        '    ) CONST PURE;       
        Overloads Sub GetTransform(<Out(), MarshalAs(UnmanagedType.Struct)> ByRef transform As D2D1_MATRIX_3X2_F)

        'STDMETHOD_(void, SetAntialiasMode)(
        '    D2D1_ANTIALIAS_MODE antialiasMode
        '    ) PURE;
        Overloads Sub SetAntialiasMode(ByVal antialiasMode As D2D1_ANTIALIAS_MODE)

        'STDMETHOD_(D2D1_ANTIALIAS_MODE, GetAntialiasMode)(
        '    ) CONST PURE;
        Overloads Function GetAntialiasMode() As D2D1_ANTIALIAS_MODE

        'STDMETHOD_(void, SetTextAntialiasMode)(
        '    D2D1_TEXT_ANTIALIAS_MODE textAntialiasMode
        '    ) PURE;
        Overloads Sub SetTextAntialiasMode(ByVal textAntialiasMode As D2D1_TEXT_ANTIALIAS_MODE)

        'STDMETHOD_(D2D1_TEXT_ANTIALIAS_MODE, GetTextAntialiasMode)(
        '    ) CONST PURE;
        Overloads Function GetTextAntialiasMode() As D2D1_TEXT_ANTIALIAS_MODE

        'STDMETHOD_(void, SetTextRenderingParams)(
        '    _In_opt_ IDWriteRenderingParams *textRenderingParams = NULL 
        '    ) PURE;
        Overloads Sub SetTextRenderingParams(<[In](), MarshalAs(UnmanagedType.Interface)> Optional ByVal textRenderingParams As IDWriteRenderingParams = Nothing)


        'STDMETHOD_(void, GetTextRenderingParams)(
        '    _Outptr_result_maybenull_ IDWriteRenderingParams **textRenderingParams 
        '    ) CONST PURE;
        ''' <summary>
        ''' Retrieve the text render parameters. NOTE: If NULL Is specified To
        ''' SetTextRenderingParameters, NULL will be returned.
        ''' </summary>
        Overloads Sub GetTextRenderingParams(<Out(), MarshalAs(UnmanagedType.Interface)> ByVal textRenderingParams As IDWriteRenderingParams)


        'STDMETHOD_(void, SetTags)(
        '    D2D1_TAG tag1,
        '    D2D1_TAG tag2 
        '    ) PURE;
        ''' <summary>
        ''' Set a tag to correspond to the succeeding primitives. If an error occurs
        ''' rendering a primitive, the tags can be returned from the Flush Or EndDraw call.
        ''' </summary>
        Overloads Sub SetTags(ByVal tag1 As UInt64,
                    ByVal tag2 As UInt64)


        'STDMETHOD_(void, GetTags)(
        '    _Out_opt_ D2D1_TAG *tag1 = NULL,
        '    _Out_opt_ D2D1_TAG *tag2 = NULL 
        '    ) CONST PURE;
        ''' <summary>
        ''' Retrieves the currently set tags. This does Not retrieve the tags corresponding
        ''' to any primitive that Is in error.
        ''' </summary>
        Overloads Sub GetTags(Optional ByRef tag1 As UInt64 = Nothing,
                    Optional ByRef tag2 As UInt64 = Nothing)


        'STDMETHOD_(void, PushLayer)(
        '    _In_ Const D2D1_LAYER_PARAMETERS *layerParameters,
        '    _In_opt_ ID2D1Layer *layer 
        '    ) PURE;
        ''' <summary>
        ''' Start a layer of drawing calls. The way in which the layer must be resolved Is
        ''' specified first as well as the logical resource that stores the layer
        ''' parameters. The supplied layer resource might grow if the specified content
        ''' cannot fit inside it. The layer will grow monotonically on each axis.  If a NULL
        ''' ID2D1Layer Is provided, then a layer resource will be allocated automatically.
        ''' </summary>
        Overloads Sub PushLayer(<[In](), MarshalAs(UnmanagedType.Struct)> ByRef layerParameters As D2D1_LAYER_PARAMETERS)


        'STDMETHOD_(void, PopLayer)(
        '    ) PURE;
        ''' <summary>
        ''' Ends a layer that was defined with particular layer resources.
        ''' </summary>
        Overloads Sub PopLayer()

        'STDMETHOD(Flush)(
        '    _Out_opt_ D2D1_TAG *tag1 = NULL,
        '    _Out_opt_ D2D1_TAG *tag2 = NULL 
        '    ) PURE;
        Overloads Sub Flush(Optional ByRef tag1 As UInt64 = Nothing,
                  Optional ByRef tag2 As UInt64 = Nothing)


        'STDMETHOD_(void, SaveDrawingState)(
        '    _Inout_ ID2D1DrawingStateBlock *drawingStateBlock 
        '    ) CONST PURE;
        ''' <summary>
        ''' Gets the current drawing state And saves it into the supplied
        ''' IDrawingStatckBlock.
        ''' </summary>
        Overloads Sub SaveDrawingState(<[In](), Out(), MarshalAs(UnmanagedType.Interface)> ByVal drawingStateBlock As ID2D1DrawingStateBlock)


        'STDMETHOD_(void, RestoreDrawingState)(
        '    _In_ ID2D1DrawingStateBlock *drawingStateBlock 
        '    ) PURE;
        ''' <summary>
        ''' Copies the state stored in the block interface.
        ''' </summary>
        Overloads Sub RestoreDrawingState(<[In](), MarshalAs(UnmanagedType.Interface)> ByVal drawingStateBlock As ID2D1DrawingStateBlock)


        'STDMETHOD_(void, PushAxisAlignedClip)(
        '    _In_ Const D2D1_RECT_F *clipRect,
        '    D2D1_ANTIALIAS_MODE antialiasMode
        '    ) PURE;
        ''' <summary>
        ''' Pushes a clip. The clip can be antialiased. The clip must be axis aligned. If
        ''' the current world transform Is Not axis preserving, then the bounding box of the
        ''' transformed clip rect will be used. The clip will remain in effect until a
        ''' PopAxisAligned clip call Is made.
        ''' </summary>
        Overloads Sub PushAxisAlignedClip(<[In](), MarshalAs(UnmanagedType.Struct)> ByRef clipRect As D2D1_RECT_F,
                                ByVal antialiasMode As D2D1_ANTIALIAS_MODE)


        'STDMETHOD_(void, PopAxisAlignedClip)(
        '    ) PURE;
        Overloads Sub PopAxisAlignedClip()


        'STDMETHOD_(void, Clear)(
        '    _In_opt_ Const D2D1_COLOR_F *clearColor = NULL 
        '    ) PURE;
        Overloads Sub Clear(<[In](), MarshalAs(UnmanagedType.Struct)> ByRef clearColor As D2D1_COLOR_F)



        'STDMETHOD_(void, BeginDraw)(
        '    ) PURE;
        ''' <summary>
        ''' Start drawing on this render target. Draw calls can only be issued between a
        ''' BeginDraw And EndDraw call.
        ''' </summary>
        Overloads Sub BeginDraw()



        'STDMETHOD(EndDraw)(
        '    _Out_opt_ D2D1_TAG *tag1 = NULL,
        '    _Out_opt_ D2D1_TAG *tag2 = NULL 
        '    ) PURE;
        ''' <summary>
        ''' Ends drawing on the render target, error results can be retrieved at this time,
        ''' Or when calling flush.
        ''' </summary>
        Overloads Sub EndDraw(Optional ByRef p1 As UInt64 = Nothing,
                    Optional ByRef p2 As UInt64 = Nothing)


        'STDMETHOD_(D2D1_PIXEL_FORMAT, GetPixelFormat)(
        '    ) CONST PURE;
        Overloads Function GetPixelFormat() As <MarshalAs(UnmanagedType.Struct)> D2D1_PIXEL_FORMAT



        'STDMETHOD_(void, SetDpi)(
        '    FLOAT dpiX,
        '    FLOAT dpiY 
        '    ) PURE;
        ''' <summary>
        ''' Sets the DPI on the render target. This results in the render target being
        ''' interpreted to a different scale. Neither DPI can be negative. If zero Is
        ''' specified for both, the system DPI Is chosen. If one Is zero And the other
        ''' unspecified, the DPI Is Not changed.
        ''' </summary>
        Overloads Sub SetDpi(ByVal dpiX As Single,
                   ByVal dpiY As Single)



        'STDMETHOD_(void, GetDpi)(
        '    _Out_ FLOAT *dpiX,
        '    _Out_ FLOAT *dpiY 
        '    ) CONST PURE;
        ''' <summary>
        ''' Return the current DPI from the target.
        ''' </summary>
        Overloads Sub GetDpi(<Out()> ByRef dpiX As Single,
                   <Out()> ByRef dpiY As Single)



        'STDMETHOD_(D2D1_SIZE_F, GetSize)(
        '    ) CONST PURE;
        ''' <summary>
        ''' Returns the size of the render target in DIPs.
        ''' </summary>
        Overloads Function GetSize() As <MarshalAs(UnmanagedType.Struct)> D2D1_SIZE_F



        'STDMETHOD_(D2D1_SIZE_U, GetPixelSize)(
        '    ) CONST PURE;
        ''' <summary>
        ''' Returns the size of the render target in pixels.
        ''' </summary>
        Overloads Function GetPixelSize() As <MarshalAs(UnmanagedType.Struct)> D2D1_SIZE_U



        'STDMETHOD_(UINT32, GetMaximumBitmapSize)(
        '    ) CONST PURE;
        ''' <summary>
        ''' Returns the maximum bitmap And render target size that Is guaranteed to be
        ''' supported by the render target.
        ''' </summary>
        Overloads Function GetMaximumBitmapSize() As UInt32



        'STDMETHOD_(BOOL, IsSupported)(
        '    _In_ Const D2D1_RENDER_TARGET_PROPERTIES *renderTargetProperties 
        '    ) CONST PURE;
        ''' <summary>
        ''' Returns true if the given properties are supported by this render target. The
        ''' DPI Is ignored. NOTE: If the render target type Is software, Then neither
        ''' D2D1_FEATURE_LEVEL_9 nor D2D1_FEATURE_LEVEL_10 will be considered to be
        ''' supported.
        ''' </summary>
        Overloads Function IsSupported(<[In](), MarshalAs(UnmanagedType.Struct)> ByRef renderTargetProperties As D2D1_RENDER_TARGET_PROPERTIES) As <MarshalAs(UnmanagedType.Bool)> Boolean

        ' STDMETHOD(BindDC)(
        '_In_ Const HDC hDC,
        '_In_ Const RECT *pSubRect 
        ') PURE;
        Function BindDC(<[In]()> ByVal hDC As IntPtr,
                        <[In](), MarshalAs(UnmanagedType.Struct)> ByRef pSubRect As RECT)
    End Interface
End Namespace