Imports System.Runtime.InteropServices

Namespace Direct2D

    ''' <summary>
    ''' The format of text used for text layout.
    ''' </summary>
    ''' <remarks>
    ''' This object may Not be thread-safe And it may carry the state of text format change.
    ''' </remarks>
    <ComImport(), Guid("9c906818-31d7-4fd3-a151-7c5e225db55a"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)>
    Public Interface IDWriteTextFormat

        '/// <summary>
        '/// Set alignment option of text relative to layout box's leading and trailing edge.
        '/// </summary>
        '/// <param name="textAlignment">Text alignment option</param>
        '/// <returns>
        '/// Standard HRESULT error code.
        '/// </returns>
        'STDMETHOD(SetTextAlignment)(
        '    DWRITE_TEXT_ALIGNMENT textAlignment
        '    ) PURE;
        <Obsolete("Function not implemented!")>
        Function SetTextAlignment() As HRESULT

        '/// <summary>
        '/// Set alignment option of paragraph relative to layout box's top and bottom edge.
        '/// </summary>
        '/// <param name="paragraphAlignment">Paragraph alignment option</param>
        '/// <returns>
        '/// Standard HRESULT error code.
        '/// </returns>
        'STDMETHOD(SetParagraphAlignment)(
        '    DWRITE_PARAGRAPH_ALIGNMENT paragraphAlignment
        '    ) PURE;
        <Obsolete("Function not implemented!")>
        Function SetParagraphAlignment() As HRESULT

        '/// <summary>
        '/// Set word wrapping option.
        '/// </summary>
        '/// <param name="wordWrapping">Word wrapping option</param>
        '/// <returns>
        '/// Standard HRESULT error code.
        '/// </returns>
        'STDMETHOD(SetWordWrapping)(
        '    DWRITE_WORD_WRAPPING wordWrapping
        '    ) PURE;
        <Obsolete("Function not implemented!")>
        Function SetWordWrapping() As HRESULT

        '/// <summary>
        '/// Set paragraph reading direction.
        '/// </summary>
        '/// <param name="readingDirection">Text reading direction</param>
        '/// <returns>
        '/// Standard HRESULT error code.
        '/// </returns>
        '/// <remarks>
        '/// The flow direction must be perpendicular to the reading direction.
        '/// Setting both to a vertical direction Or both to horizontal yields
        '/// DWRITE_E_FLOWDIRECTIONCONFLICTS when calling GetMetrics Or Draw.
        '/// </remark>
        'STDMETHOD(SetReadingDirection)(
        '    DWRITE_READING_DIRECTION readingDirection
        '    ) PURE;
        <Obsolete("Function not implemented!")>
        Function SetReadingDirection() As HRESULT

        '/// <summary>
        '/// Set paragraph flow direction.
        '/// </summary>
        '/// <param name="flowDirection">Paragraph flow direction</param>
        '/// <returns>
        '/// Standard HRESULT error code.
        '/// </returns>
        '/// <remarks>
        '/// The flow direction must be perpendicular to the reading direction.
        '/// Setting both to a vertical direction Or both to horizontal yields
        '/// DWRITE_E_FLOWDIRECTIONCONFLICTS when calling GetMetrics Or Draw.
        '/// </remark>
        'STDMETHOD(SetFlowDirection)(
        '    DWRITE_FLOW_DIRECTION flowDirection
        '    ) PURE;
        <Obsolete("Function not implemented!")>
        Function SetFlowDirection() As HRESULT

        '/// <summary>
        '/// Set incremental tab stop position.
        '/// </summary>
        '/// <param name="incrementalTabStop">The incremental tab stop value</param>
        '/// <returns>
        '/// Standard HRESULT error code.
        '/// </returns>
        'STDMETHOD(SetIncrementalTabStop)(
        '    FLOAT incrementalTabStop
        '    ) PURE;
        <Obsolete("Function not implemented!")>
        Function SetIncrementalTabStop() As HRESULT

        '/// <summary>
        '/// Set trimming options for any trailing text exceeding the layout width
        '/// Or for any far text exceeding the layout height.
        '/// </summary>
        '/// <param name="trimmingOptions">Text trimming options.</param>
        '/// <param name="trimmingSign">Application-defined omission sign. This parameter may be NULL if no trimming sign Is desired.</param>
        '/// <remarks>
        '/// Any inline object can be used for the trimming sign, but CreateEllipsisTrimmingSign
        '/// provides a typical ellipsis symbol. Trimming Is also useful vertically for hiding
        '/// partial lines.
        '/// </remarks>
        '/// <returns>
        '/// Standard HRESULT error code.
        '/// </returns>
        'STDMETHOD(SetTrimming)(
        '    _In_ DWRITE_TRIMMING Const* trimmingOptions,
        '    _In_opt_ IDWriteInlineObject* trimmingSign
        '    ) PURE;
        <Obsolete("Function not implemented!")>
        Function SetTrimming() As HRESULT

        '/// <summary>
        '/// Set line spacing.
        '/// </summary>
        '/// <param name="lineSpacingMethod">How to determine line height.</param>
        '/// <param name="lineSpacing">The line height, Or rather distance between one baseline to another.</param>
        '/// <param name="baseline">Distance from top of line to baseline. A reasonable ratio to lineSpacing Is 80%.</param>
        '/// <remarks>
        '/// For the default method, spacing depends solely on the content.
        '/// For uniform spacing, the given line height will override the content.
        '/// </remarks>
        '/// <returns>
        '/// Standard HRESULT error code.
        '/// </returns>
        'STDMETHOD(SetLineSpacing)(
        '    DWRITE_LINE_SPACING_METHOD lineSpacingMethod,
        '    FLOAT lineSpacing,
        '    FLOAT baseline
        '    ) PURE;
        <Obsolete("Function not implemented!")>
        Function SetLineSpacing() As HRESULT

        '/// <summary>
        '/// Get alignment option of text relative to layout box's leading and trailing edge.
        '/// </summary>
        'STDMETHOD_(DWRITE_TEXT_ALIGNMENT, GetTextAlignment)() PURE;
        <Obsolete("Function not implemented!")>
        Function GetTextAlignment() As HRESULT

        '/// <summary>
        '/// Get alignment option of paragraph relative to layout box's top and bottom edge.
        '/// </summary>
        'STDMETHOD_(DWRITE_PARAGRAPH_ALIGNMENT, GetParagraphAlignment)() PURE;
        <Obsolete("Function not implemented!")>
        Function GetParagraphAlignment() As HRESULT

        '/// <summary>
        '/// Get word wrapping option.
        '/// </summary>
        'STDMETHOD_(DWRITE_WORD_WRAPPING, GetWordWrapping)() PURE;
        <Obsolete("Function not implemented!")>
        Function GetWordWrapping() As HRESULT

        '/// <summary>
        '/// Get paragraph reading direction.
        '/// </summary>
        'STDMETHOD_(DWRITE_READING_DIRECTION, GetReadingDirection)() PURE;
        <Obsolete("Function not implemented!")>
        Function GetReadingDirection() As HRESULT

        '/// <summary>
        '/// Get paragraph flow direction.
        '/// </summary>
        'STDMETHOD_(DWRITE_FLOW_DIRECTION, GetFlowDirection)() PURE;
        <Obsolete("Function not implemented!")>
        Function GetFlowDirection() As HRESULT

        '/// <summary>
        '/// Get incremental tab stop position.
        '/// </summary>
        'STDMETHOD_(FLOAT, GetIncrementalTabStop)() PURE;
        <Obsolete("Function not implemented!")>
        Function GetIncrementalTabStop() As HRESULT

        '/// <summary>
        '/// Get trimming options for text overflowing the layout width.
        '/// </summary>
        '/// <param name="trimmingOptions">Text trimming options.</param>
        '/// <param name="trimmingSign">Trimming omission sign. This parameter may be NULL.</param>
        '/// <returns>
        '/// Standard HRESULT error code.
        '/// </returns>
        'STDMETHOD(GetTrimming)(
        '    _Out_ DWRITE_TRIMMING* trimmingOptions,
        '    _COM_Outptr_ IDWriteInlineObject** trimmingSign
        '    ) PURE;
        <Obsolete("Function not implemented!")>
        Function GetTrimming() As HRESULT

        '/// <summary>
        '/// Get line spacing.
        '/// </summary>
        '/// <param name="lineSpacingMethod">How line height Is determined.</param>
        '/// <param name="lineSpacing">The line height, Or rather distance between one baseline to another.</param>
        '/// <param name="baseline">Distance from top of line to baseline.</param>
        '/// <returns>
        '/// Standard HRESULT error code.
        '/// </returns>
        'STDMETHOD(GetLineSpacing)(
        '    _Out_ DWRITE_LINE_SPACING_METHOD* lineSpacingMethod,
        '    _Out_ FLOAT* lineSpacing,
        '    _Out_ FLOAT* baseline
        '    ) PURE;
        <Obsolete("Function not implemented!")>
        Function GetLineSpacing() As HRESULT

        '/// <summary>
        '/// Get the font collection.
        '/// </summary>
        '/// <param name="fontCollection">The current font collection.</param>
        '/// <returns>
        '/// Standard HRESULT error code.
        '/// </returns>
        'STDMETHOD(GetFontCollection)(
        '    _COM_Outptr_ IDWriteFontCollection** fontCollection
        '    ) PURE;
        <Obsolete("Function not implemented!")>
        Function GetFontCollection() As HRESULT

        '/// <summary>
        '/// Get the length of the font family name, in characters, Not including the terminating NULL character.
        '/// </summary>
        'STDMETHOD_(UINT32, GetFontFamilyNameLength)() PURE;
        <Obsolete("Function not implemented!")>
        Function GetFontFamilyNameLength() As HRESULT

        '/// <summary>
        '/// Get a copy of the font family name.
        '/// </summary>
        '/// <param name="fontFamilyName">Character array that receives the current font family name</param>
        '/// <param name="nameSize">Size of the character array in character count including the terminated NULL character.</param>
        '/// <returns>
        '/// Standard HRESULT error code.
        '/// </returns>
        'STDMETHOD(GetFontFamilyName)(
        '    _Out_writes_z_(nameSize) WCHAR* fontFamilyName,
        '    UINT32 nameSize
        '    ) PURE;
        <Obsolete("Function not implemented!")>
        Function GetFontFamilyName() As HRESULT

        '/// <summary>
        '/// Get the font weight.
        '/// </summary>
        'STDMETHOD_(DWRITE_FONT_WEIGHT, GetFontWeight)() PURE;
        <Obsolete("Function not implemented!")>
        Function GetFontWeight() As HRESULT

        '/// <summary>
        '/// Get the font style.
        '/// </summary>
        'STDMETHOD_(DWRITE_FONT_STYLE, GetFontStyle)() PURE;
        <Obsolete("Function not implemented!")>
        Function GetFontStyle() As HRESULT

        '/// <summary>
        '/// Get the font stretch.
        '/// </summary>
        'STDMETHOD_(DWRITE_FONT_STRETCH, GetFontStretch)() PURE;
        <Obsolete("Function not implemented!")>
        Function GetFontStretch() As HRESULT

        '/// <summary>
        '/// Get the font em height.
        '/// </summary>
        'STDMETHOD_(FLOAT, GetFontSize)() PURE;
        <Obsolete("Function not implemented!")>
        Function GetFontSize() As HRESULT

        '/// <summary>
        '/// Get the length of the locale name, in characters, Not including the terminating NULL character.
        '/// </summary>
        'STDMETHOD_(UINT32, GetLocaleNameLength)() PURE;
        <Obsolete("Function not implemented!")>
        Function GetLocaleNameLength() As HRESULT

        '/// <summary>
        '/// Get a copy of the locale name.
        '/// </summary>
        '/// <param name="localeName">Character array that receives the current locale name</param>
        '/// <param name="nameSize">Size of the character array in character count including the terminated NULL character.</param>
        '/// <returns>
        '/// Standard HRESULT error code.
        '/// </returns>
        'STDMETHOD(GetLocaleName)(
        '    _Out_writes_z_(nameSize) WCHAR* localeName,
        '    UINT32 nameSize
        '    ) PURE;
        <Obsolete("Function not implemented!")>
        Function GetLocaleName() As HRESULT
    End Interface
End Namespace
