Imports System.Runtime.InteropServices

Namespace Direct2D

    '''<summary>
    ''' The root factory interface for all DWrite objects.
    ''' </summary>
    <ComImport(), Guid("b859ee5a-d838-4b5b-a2e8-1adc7d93db48"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)>
    Public Interface IDWriteFactory

        '/// <summary>
        '/// Gets a font collection representing the set of installed fonts.
        '/// </summary>
        '/// <param name="fontCollection">Receives a pointer to the system font collection object, Or NULL in case of failure.</param>
        '/// <param name="checkForUpdates">If this parameter Is nonzero, the function performs an immediate check for changes to the set of
        '/// installed fonts. If this parameter Is FALSE, the function will still detect changes if the font cache service Is running, but
        '/// there may be some latency. For example, an application might specify TRUE if it has itself just installed a font And wants to 
        '/// be sure the font collection contains that font.</param>
        '/// <returns>
        '/// Standard HRESULT error code.
        '/// </returns>
        'STDMETHOD(GetSystemFontCollection)(
        '    _COM_Outptr_ IDWriteFontCollection** fontCollection,
        '    BOOL checkForUpdates = False
        '    ) PURE;
        <Obsolete("Function not implemented!")>
        Function GetSystemFontCollection() As HRESULT

        '/// <summary>
        '/// Creates a font collection using a custom font collection loader.
        '/// </summary>
        '/// <param name="collectionLoader">Application-defined font collection loader, which must have been previously
        '/// registered using RegisterFontCollectionLoader.</param>
        '/// <param name="collectionKey">Key used by the loader to identify a collection of font files.</param>
        '/// <param name="collectionKeySize">Size in bytes of the collection key.</param>
        '/// <param name="fontCollection">Receives a pointer to the system font collection object, Or NULL in case of failure.</param>
        '/// <returns>
        '/// Standard HRESULT error code.
        '/// </returns>
        'STDMETHOD(CreateCustomFontCollection)(
        '    _In_ IDWriteFontCollectionLoader* collectionLoader,
        '    _In_reads_bytes_(collectionKeySize) void const* collectionKey,
        '    UINT32 collectionKeySize,
        '    _COM_Outptr_ IDWriteFontCollection** fontCollection
        '    ) PURE;
        <Obsolete("Function not implemented!")>
        Function CreateCustomFontCollection() As HRESULT

        '/// <summary>
        '/// Registers a custom font collection loader with the factory object.
        '/// </summary>
        '/// <param name="fontCollectionLoader">Application-defined font collection loader.</param>
        '/// <returns>
        '/// Standard HRESULT error code.
        '/// </returns>
        'STDMETHOD(RegisterFontCollectionLoader)(
        '    _In_ IDWriteFontCollectionLoader* fontCollectionLoader
        '    ) PURE;
        <Obsolete("Function not implemented!")>
        Function RegisterFontCollectionLoader() As HRESULT

        '/// <summary>
        '/// Unregisters a custom font collection loader that was previously registered using RegisterFontCollectionLoader.
        '/// </summary>
        '/// <param name="fontCollectionLoader">Application-defined font collection loader.</param>
        '/// <returns>
        '/// Standard HRESULT error code.
        '/// </returns>
        'STDMETHOD(UnregisterFontCollectionLoader)(
        '    _In_ IDWriteFontCollectionLoader* fontCollectionLoader
        '    ) PURE;
        <Obsolete("Function not implemented!")>
        Function UnregisterFontCollectionLoader() As HRESULT

        '/// <summary>
        '/// CreateFontFileReference creates a font file reference object from a local font file.
        '/// </summary>
        '/// <param name="filePath">Absolute file path. Subsequent operations on the constructed object may fail
        '/// if the user provided filePath doesn't correspond to a valid file on the disk.</param>
        '/// <param name="lastWriteTime">Last modified time of the input file path. If the parameter Is omitted,
        '/// the function will access the font file to obtain its last write time, so the clients are encouraged to specify this value
        '/// to avoid extra disk access. Subsequent operations on the constructed object may fail
        '/// if the user provided lastWriteTime doesn't match the file on the disk.</param>
        '/// <param name="fontFile">Contains newly created font file reference object, Or NULL in case of failure.</param>
        '/// <returns>
        '/// Standard HRESULT error code.
        '/// </returns>
        'STDMETHOD(CreateFontFileReference)(
        '    _In_z_ WCHAR Const* filePath,
        '    _In_opt_ FILETIME Const* lastWriteTime,
        '    _COM_Outptr_ IDWriteFontFile** fontFile
        '    ) PURE;
        <Obsolete("Function not implemented!")>
        Function CreateFontFileReference() As HRESULT

        '/// <summary>
        '/// CreateCustomFontFileReference creates a reference to an application specific font file resource.
        '/// This function enables an application Or a document to use a font without having to install it on the system.
        '/// The fontFileReferenceKey has to be unique only in the scope of the fontFileLoader used in this call.
        '/// </summary>
        '/// <param name="fontFileReferenceKey">Font file reference key that uniquely identifies the font file resource
        '/// during the lifetime of fontFileLoader.</param>
        '/// <param name="fontFileReferenceKeySize">Size of font file reference key in bytes.</param>
        '/// <param name="fontFileLoader">Font file loader that will be used by the font system to load data from the file identified by
        '/// fontFileReferenceKey.</param>
        '/// <param name="fontFile">Contains the newly created font file object, Or NULL in case of failure.</param>
        '/// <returns>
        '/// Standard HRESULT error code.
        '/// </returns>
        '/// <remarks>
        '/// This function Is provided for cases when an application Or a document needs to use a font
        '/// without having to install it on the system. fontFileReferenceKey has to be unique only in the scope
        '/// of the fontFileLoader used in this call.
        '/// </remarks>
        'STDMETHOD(CreateCustomFontFileReference)(
        '    _In_reads_bytes_(fontFileReferenceKeySize) void const* fontFileReferenceKey,
        '    UINT32 fontFileReferenceKeySize,
        '    _In_ IDWriteFontFileLoader* fontFileLoader,
        '    _COM_Outptr_ IDWriteFontFile** fontFile
        '    ) PURE;
        <Obsolete("Function not implemented!")>
        Function CreateCustomFontFileReference() As HRESULT

        '/// <summary>
        '/// Creates a font face object.
        '/// </summary>
        '/// <param name="fontFaceType">The file format of the font face.</param>
        '/// <param name="numberOfFiles">The number of font files required to represent the font face.</param>
        '/// <param name="fontFiles">Font files representing the font face. Since IDWriteFontFace maintains its own references
        '/// to the input font file objects, it's OK to release them after this call.</param>
        '/// <param name="faceIndex">The zero based index of a font face in cases when the font files contain a collection of font faces.
        '/// If the font files contain a single face, this value should be zero.</param>
        '/// <param name="fontFaceSimulationFlags">Font face simulation flags for algorithmic emboldening And italicization.</param>
        '/// <param name="fontFace">Contains the newly created font face object, Or NULL in case of failure.</param>
        '/// <returns>
        '/// Standard HRESULT error code.
        '/// </returns>
        'STDMETHOD(CreateFontFace)(
        '    DWRITE_FONT_FACE_TYPE fontFaceType,
        '    UINT32 numberOfFiles,
        '    _In_reads_(numberOfFiles) IDWriteFontFile* const* fontFiles,
        '    UINT32 faceIndex,
        '    DWRITE_FONT_SIMULATIONS fontFaceSimulationFlags,
        '    _COM_Outptr_ IDWriteFontFace** fontFace
        '    ) PURE;
        <Obsolete("Function not implemented!")>
        Function CreateFontFace() As HRESULT

        '/// <summary>
        '/// Creates a rendering parameters object with default settings for the primary monitor.
        '/// </summary>
        '/// <param name="renderingParams">Holds the newly created rendering parameters object, Or NULL in case of failure.</param>
        '/// <returns>
        '/// Standard HRESULT error code.
        '/// </returns>
        'STDMETHOD(CreateRenderingParams)(
        '    _COM_Outptr_ IDWriteRenderingParams** renderingParams
        '    ) PURE;
        <Obsolete("Function not implemented!")>
        Function CreateRenderingParams() As HRESULT

        '/// <summary>
        '/// Creates a rendering parameters object with default settings for the specified monitor.
        '/// </summary>
        '/// <param name="monitor">The monitor to read the default values from.</param>
        '/// <param name="renderingParams">Holds the newly created rendering parameters object, Or NULL in case of failure.</param>
        '/// <returns>
        '/// Standard HRESULT error code.
        '/// </returns>
        'STDMETHOD(CreateMonitorRenderingParams)(
        '    HMONITOR monitor,
        '    _COM_Outptr_ IDWriteRenderingParams** renderingParams
        '    ) PURE;
        <Obsolete("Function not implemented!")>
        Function CreateMonitorRenderingParams() As HRESULT

        '/// <summary>
        '/// Creates a rendering parameters object with the specified properties.
        '/// </summary>
        '/// <param name="gamma">The gamma value used for gamma correction, which must be greater than zero And cannot exceed 256.</param>
        '/// <param name="enhancedContrast">The amount of contrast enhancement, zero Or greater.</param>
        '/// <param name="clearTypeLevel">The degree of ClearType level, from 0.0f (no ClearType) to 1.0f (full ClearType).</param>
        '/// <param name="pixelGeometry">The geometry of a device pixel.</param>
        '/// <param name="renderingMode">Method of rendering glyphs. In most cases, this should be DWRITE_RENDERING_MODE_DEFAULT to automatically use an appropriate mode.</param>
        '/// <param name="renderingParams">Holds the newly created rendering parameters object, Or NULL in case of failure.</param>
        '/// <returns>
        '/// Standard HRESULT error code.
        '/// </returns>
        'STDMETHOD(CreateCustomRenderingParams)(
        '    FLOAT gamma,
        '    FLOAT enhancedContrast,
        '    FLOAT clearTypeLevel,
        '    DWRITE_PIXEL_GEOMETRY pixelGeometry,
        '    DWRITE_RENDERING_MODE renderingMode,
        '    _COM_Outptr_ IDWriteRenderingParams** renderingParams
        '    ) PURE;
        <Obsolete("Function not implemented!")>
        Function CreateCustomRenderingParams() As HRESULT

        '/// <summary>
        '/// Registers a font file loader with DirectWrite.
        '/// </summary>
        '/// <param name="fontFileLoader">Pointer to the implementation of the IDWriteFontFileLoader for a particular file resource type.</param>
        '/// <returns>
        '/// Standard HRESULT error code.
        '/// </returns>
        '/// <remarks>
        '/// This function registers a font file loader with DirectWrite.
        '/// Font file loader interface handles loading font file resources of a particular type from a key.
        '/// The font file loader interface Is recommended to be implemented by a singleton object.
        '/// A given instance can only be registered once.
        '/// Succeeding attempts will return an error that it has already been registered.
        '/// IMPORTANT: font file loader implementations must Not register themselves With DirectWrite
        '/// inside their constructors And must Not unregister themselves in their destructors, because
        '/// registration And unregistration operations increment And decrement the object reference count respectively.
        '/// Instead, registration And unregistration of font file loaders with DirectWrite should be performed
        '/// outside of the font file loader implementation as a separate step.
        '/// </remarks>
        'STDMETHOD(RegisterFontFileLoader)(
        '    _In_ IDWriteFontFileLoader* fontFileLoader
        '    ) PURE;
        <Obsolete("Function not implemented!")>
        Function RegisterFontFileLoader() As HRESULT

        '/// <summary>
        '/// Unregisters a font file loader that was previously registered with the DirectWrite font system using RegisterFontFileLoader.
        '/// </summary>
        '/// <param name="fontFileLoader">Pointer to the file loader that was previously registered with the DirectWrite font system using RegisterFontFileLoader.</param>
        '/// <returns>
        '/// This function will succeed if the user loader Is requested to be removed.
        '/// It will fail if the pointer to the file loader identifies a standard DirectWrite loader,
        '/// Or a loader that Is never registered Or has already been unregistered.
        '/// </returns>
        '/// <remarks>
        '/// This function unregisters font file loader callbacks with the DirectWrite font system.
        '/// The font file loader interface Is recommended to be implemented by a singleton object.
        '/// IMPORTANT: font file loader implementations must Not register themselves With DirectWrite
        '/// inside their constructors And must Not unregister themselves in their destructors, because
        '/// registration And unregistration operations increment And decrement the object reference count respectively.
        '/// Instead, registration And unregistration of font file loaders with DirectWrite should be performed
        '/// outside of the font file loader implementation as a separate step.
        '/// </remarks>
        'STDMETHOD(UnregisterFontFileLoader)(
        '    _In_ IDWriteFontFileLoader* fontFileLoader
        '    ) PURE;
        <Obsolete("Function not implemented!")>
        Function UnregisterFontFileLoader() As HRESULT

        '/// <summary>
        '/// Create a text format object used for text layout.
        '/// </summary>
        '/// <param name="fontFamilyName">Name of the font family</param>
        '/// <param name="fontCollection">Font collection. NULL indicates the system font collection.</param>
        '/// <param name="fontWeight">Font weight</param>
        '/// <param name="fontStyle">Font style</param>
        '/// <param name="fontStretch">Font stretch</param>
        '/// <param name="fontSize">Logical size of the font in DIP units. A DIP ("device-independent pixel") equals 1/96 inch.</param>
        '/// <param name="localeName">Locale name</param>
        '/// <param name="textFormat">Contains newly created text format object, Or NULL in case of failure.</param>
        '/// <returns>
        '/// Standard HRESULT error code.
        '/// </returns>
        '/// <remarks>
        '/// If fontCollection Is nullptr, the system font collection Is used, grouped by typographic family name
        '/// (DWRITE_FONT_FAMILY_MODEL_WEIGHT_STRETCH_STYLE) without downloadable fonts.
        '/// </remarks>
        'STDMETHOD(CreateTextFormat)(
        '    _In_z_ WCHAR Const* fontFamilyName,
        '    _In_opt_ IDWriteFontCollection* fontCollection,
        '    DWRITE_FONT_WEIGHT fontWeight,
        '    DWRITE_FONT_STYLE fontStyle,
        '    DWRITE_FONT_STRETCH fontStretch,
        '    FLOAT fontSize,
        '    _In_z_ WCHAR Const* localeName,
        '    _COM_Outptr_ IDWriteTextFormat** textFormat
        '    ) PURE;
        Function CreateTextFormat(<[In](), MarshalAs(UnmanagedType.LPWStr)> ByVal fontFamilyName As String,
                                  <[In]()> ByVal fontCollection As IntPtr,
                                  ByVal fontWeight As DWRITE_FONT_WEIGHT,
                                  ByVal fontStyle As DWRITE_FONT_STYLE,
                                  ByVal fontStretch As DWRITE_FONT_STRETCH,
                                  ByVal fontSize As Single,
                                  <[In](), MarshalAs(UnmanagedType.LPWStr)> ByVal localeName As String,
                                  <Out(), MarshalAs(UnmanagedType.Interface)> ByRef textFormat As IDWriteTextFormat) As HRESULT

        '/// <summary>
        '/// Create a typography object used in conjunction with text format for text layout.
        '/// </summary>
        '/// <param name="typography">Contains newly created typography object, Or NULL in case of failure.</param>
        '/// <returns>
        '/// Standard HRESULT error code.
        '/// </returns>
        'STDMETHOD(CreateTypography)(
        '    _COM_Outptr_ IDWriteTypography** typography
        '    ) PURE;
        <Obsolete("Function not implemented!")>
        Function CreateTypography() As HRESULT

        '/// <summary>
        '/// Create an object used for interoperability with GDI.
        '/// </summary>
        '/// <param name="gdiInterop">Receives the GDI interop object if successful, Or NULL in case of failure.</param>
        '/// <returns>
        '/// Standard HRESULT error code.
        '/// </returns>
        'STDMETHOD(GetGdiInterop)(
        '    _COM_Outptr_ IDWriteGdiInterop** gdiInterop
        '    ) PURE;
        <Obsolete("Function not implemented!")>
        Function GetGdiInterop() As HRESULT

        '/// <summary>
        '/// CreateTextLayout takes a string, format, And associated constraints
        '/// And produces an object representing the fully analyzed
        '/// And formatted result.
        '/// </summary>
        '/// <param name="string">The string to layout.</param>
        '/// <param name="stringLength">The length of the string.</param>
        '/// <param name="textFormat">The format to apply to the string.</param>
        '/// <param name="maxWidth">Width of the layout box.</param>
        '/// <param name="maxHeight">Height of the layout box.</param>
        '/// <param name="textLayout">The resultant object.</param>
        '/// <returns>
        '/// Standard HRESULT error code.
        '/// </returns>
        'STDMETHOD(CreateTextLayout)(
        '    _In_reads_(stringLength) WCHAR const* string,
        '    UINT32 stringLength,
        '    _In_ IDWriteTextFormat* textFormat,
        '    FLOAT maxWidth,
        '    FLOAT maxHeight,
        '    _COM_Outptr_ IDWriteTextLayout** textLayout
        '    ) PURE;
        Function CreateTextLayout(<[In](), MarshalAs(UnmanagedType.LPWStr)> ByVal text As String,
                                  ByVal textlen As UInt32,
                                  <[In]()> ByVal textFormat As IntPtr, ' -> Use Intptr.Zero
                                  ByVal maxWidth As Single,
                                  ByVal maxHeight As Single,
                                  <Out(), MarshalAs(UnmanagedType.Interface)> ByRef textLayout As IDWriteTextLayout) As HRESULT

        '/// <summary>
        '/// CreateGdiCompatibleTextLayout takes a string, format, And associated constraints
        '/// And produces And object representing the result formatted for a particular display resolution
        '/// And measuring mode. The resulting text layout should only be used for the intended resolution,
        '/// And for cases where text scalability Is desired, CreateTextLayout should be used instead.
        '/// </summary>
        '/// <param name="string">The string to layout.</param>
        '/// <param name="stringLength">The length of the string.</param>
        '/// <param name="textFormat">The format to apply to the string.</param>
        '/// <param name="layoutWidth">Width of the layout box.</param>
        '/// <param name="layoutHeight">Height of the layout box.</param>
        '/// <param name="pixelsPerDip">Number of physical pixels per DIP. For example, if rendering onto a 96 DPI device then pixelsPerDip
        '/// Is 1. If rendering onto a 120 DPI device then pixelsPerDip Is 120/96.</param>
        '/// <param name="transform">Optional transform applied to the glyphs And their positions. This transform Is applied after the
        '/// scaling specified the font size And pixelsPerDip.</param>
        '/// <param name="useGdiNatural">
        '/// When set to FALSE, instructs the text layout to use the same metrics as GDI aliased text.
        '/// When set to TRUE, instructs the text layout to use the same metrics as text measured by GDI using a font
        '/// created with CLEARTYPE_NATURAL_QUALITY.
        '/// </param>
        '/// <param name="textLayout">The resultant object.</param>
        '/// <returns>
        '/// Standard HRESULT error code.
        '/// </returns>
        'STDMETHOD(CreateGdiCompatibleTextLayout)(
        '    _In_reads_(stringLength) WCHAR const* string,
        '    UINT32 stringLength,
        '    _In_ IDWriteTextFormat* textFormat,
        '    FLOAT layoutWidth,
        '    FLOAT layoutHeight,
        '    FLOAT pixelsPerDip,
        '    _In_opt_ DWRITE_MATRIX Const* transform,
        '    BOOL useGdiNatural,
        '    _COM_Outptr_ IDWriteTextLayout** textLayout
        '    ) PURE;
        <Obsolete("Function not implemented!")>
        Function CreateGdiCompatibleTextLayout() As HRESULT

        '/// <summary>
        '/// The application may call this function to create an inline object for trimming, using an ellipsis as the omission sign.
        '/// The ellipsis will be created using the current settings of the format, including base font, style, And any effects.
        '/// Alternate omission signs can be created by the application by implementing IDWriteInlineObject.
        '/// </summary>
        '/// <param name="textFormat">Text format used as a template for the omission sign.</param>
        '/// <param name="trimmingSign">Created omission sign.</param>
        '/// <returns>
        '/// Standard HRESULT error code.
        '/// </returns>
        'STDMETHOD(CreateEllipsisTrimmingSign)(
        '    _In_ IDWriteTextFormat* textFormat,
        '    _COM_Outptr_ IDWriteInlineObject** trimmingSign
        '    ) PURE;
        <Obsolete("Function not implemented!")>
        Function CreateEllipsisTrimmingSign() As HRESULT

        '/// <summary>
        '/// Return an interface to perform text analysis with.
        '/// </summary>
        '/// <param name="textAnalyzer">The resultant object.</param>
        '/// <returns>
        '/// Standard HRESULT error code.
        '/// </returns>
        'STDMETHOD(CreateTextAnalyzer)(
        '    _COM_Outptr_ IDWriteTextAnalyzer** textAnalyzer
        '    ) PURE;
        <Obsolete("Function not implemented!")>
        Function CreateTextAnalyzer() As HRESULT

        '/// <summary>
        '/// Creates a number substitution object using a locale name,
        '/// substitution method, And whether to ignore user overrides (uses NLS
        '/// defaults for the given culture instead).
        '/// </summary>
        '/// <param name="substitutionMethod">Method of number substitution to use.</param>
        '/// <param name="localeName">Which locale to obtain the digits from.</param>
        '/// <param name="ignoreUserOverride">Ignore the user's settings and use the locale defaults</param>
        '/// <param name="numberSubstitution">Receives a pointer to the newly created object.</param>
        'STDMETHOD(CreateNumberSubstitution)(
        '    _In_ DWRITE_NUMBER_SUBSTITUTION_METHOD substitutionMethod,
        '    _In_z_ WCHAR Const* localeName,
        '    _In_ BOOL ignoreUserOverride,
        '    _COM_Outptr_ IDWriteNumberSubstitution** numberSubstitution
        '    ) PURE;
        <Obsolete("Function not implemented!")>
        Function CreateNumberSubstitution() As HRESULT

        '/// <summary>
        '/// Creates a glyph run analysis object, which encapsulates information
        '/// used to render a glyph run.
        '/// </summary>
        '/// <param name="glyphRun">Structure specifying the properties of the glyph run.</param>
        '/// <param name="pixelsPerDip">Number of physical pixels per DIP. For example, if rendering onto a 96 DPI bitmap then pixelsPerDip
        '/// Is 1. If rendering onto a 120 DPI bitmap then pixelsPerDip Is 120/96.</param>
        '/// <param name="transform">Optional transform applied to the glyphs And their positions. This transform Is applied after the
        '/// scaling specified by the emSize And pixelsPerDip.</param>
        '/// <param name="renderingMode">Specifies the rendering mode, which must be one of the raster rendering modes (i.e., Not default
        '/// And Not outline).</param>
        '/// <param name="measuringMode">Specifies the method to measure glyphs.</param>
        '/// <param name="baselineOriginX">Horizontal position of the baseline origin, in DIPs.</param>
        '/// <param name="baselineOriginY">Vertical position of the baseline origin, in DIPs.</param>
        '/// <param name="glyphRunAnalysis">Receives a pointer to the newly created object.</param>
        '/// <returns>
        '/// Standard HRESULT error code.
        '/// </returns>
        'STDMETHOD(CreateGlyphRunAnalysis)(
        '    _In_ DWRITE_GLYPH_RUN Const* glyphRun,
        '    FLOAT pixelsPerDip,
        '    _In_opt_ DWRITE_MATRIX Const* transform,
        '    DWRITE_RENDERING_MODE renderingMode,
        '    DWRITE_MEASURING_MODE measuringMode,
        '    FLOAT baselineOriginX,
        '    FLOAT baselineOriginY,
        '    _COM_Outptr_ IDWriteGlyphRunAnalysis** glyphRunAnalysis
        '    ) PURE;
        <Obsolete("Function not implemented!")>
        Function CreateGlyphRunAnalysis() As HRESULT

    End Interface
End Namespace
