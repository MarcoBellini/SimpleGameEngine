Imports System.Runtime.InteropServices

Namespace Direct2D
#Disable Warning IDE0049
    Public Module StructAndEnums

        ''' <summary>
        ''' Specifies the type of DirectWrite factory object.
        ''' DirectWrite factory contains internal state such as font loader registration And cached font data.
        ''' In most cases it Is recommended to use the shared factory object, because it allows multiple components
        ''' that use DirectWrite to share internal DirectWrite state And reduce memory usage.
        ''' However, there are cases when it Is desirable to reduce the impact of a component,
        ''' such as a plug-in from an untrusted source, on the rest of the process by sandboxing And isolating it
        ''' from the rest of the process components. In such cases, it Is recommended to use an isolated factory for the sandboxed
        ''' component.
        ''' </summary>
        Public Enum DWRITE_FACTORY_TYPE

            ''' <summary>
            ''' Shared factory allow for re-use of cached font data across multiple in process components.
            ''' Such factories also take advantage of cross process font caching components for better performance.
            ''' </summary>
            DWRITE_FACTORY_TYPE_SHARED

            ''' <summary>
            ''' Objects created from the isolated factory do Not interact with internal DirectWrite state from other components.
            ''' </summary>
            DWRITE_FACTORY_TYPE_ISOLATED
        End Enum

        Public Enum WICDecodeOptions
            WICDecodeMetadataCacheOnDemand = 0
            WICDecodeMetadataCacheOnLoad = &H1
            WICMETADATACACHEOPTION_FORCE_DWORD = &H7FFFFFFF
        End Enum


        ''' <summary>
        ''' The font weight Public Enumeration describes common values for degree of blackness Or thickness of strokes of characters in a font.
        ''' Font weight values less than 1 Or greater than 999 are considered to be invalid  And they are rejected by font API functions.
        ''' </summary>
        Public Enum DWRITE_FONT_WEIGHT

            ''' <summary>
            ''' Predefined font weight : Thin (100).
            ''' </summary>
            DWRITE_FONT_WEIGHT_THIN = 100

            ''' <summary>
            ''' Predefined font weight : Extra-light (200).
            ''' </summary>
            DWRITE_FONT_WEIGHT_EXTRA_LIGHT = 200

            ''' <summary>
            ''' Predefined font weight : Ultra-light (200).
            ''' </summary>
            DWRITE_FONT_WEIGHT_ULTRA_LIGHT = 200

            ''' <summary>
            ''' Predefined font weight : Light (300).
            ''' </summary>
            DWRITE_FONT_WEIGHT_LIGHT = 300

            ''' <summary>
            ''' Predefined font weight : Semi-light (350).
            ''' </summary>
            DWRITE_FONT_WEIGHT_SEMI_LIGHT = 350

            ''' <summary>
            ''' Predefined font weight : Normal (400).
            ''' </summary>
            DWRITE_FONT_WEIGHT_NORMAL = 400

            ''' <summary>
            ''' Predefined font weight : Regular (400).
            ''' </summary>
            DWRITE_FONT_WEIGHT_REGULAR = 400

            ''' <summary>
            ''' Predefined font weight : Medium (500).
            ''' </summary>
            DWRITE_FONT_WEIGHT_MEDIUM = 500

            ''' <summary>
            ''' Predefined font weight : Demi-bold (600).
            ''' </summary>
            DWRITE_FONT_WEIGHT_DEMI_BOLD = 600

            ''' <summary>
            ''' Predefined font weight : Semi-bold (600).
            ''' </summary>
            DWRITE_FONT_WEIGHT_SEMI_BOLD = 600

            ''' <summary>
            ''' Predefined font weight : Bold (700).
            ''' </summary>
            DWRITE_FONT_WEIGHT_BOLD = 700

            ''' <summary>
            ''' Predefined font weight : Extra-bold (800).
            ''' </summary>
            DWRITE_FONT_WEIGHT_EXTRA_BOLD = 800

            ''' <summary>
            ''' Predefined font weight : Ultra-bold (800).
            ''' </summary>
            DWRITE_FONT_WEIGHT_ULTRA_BOLD = 800

            ''' <summary>
            ''' Predefined font weight : Black (900).
            ''' </summary>
            DWRITE_FONT_WEIGHT_BLACK = 900

            ''' <summary>
            ''' Predefined font weight : Heavy (900).
            ''' </summary>
            DWRITE_FONT_WEIGHT_HEAVY = 900

            ''' <summary>
            ''' Predefined font weight : Extra-black (950).
            ''' </summary>
            DWRITE_FONT_WEIGHT_EXTRA_BLACK = 950

            ''' <summary>
            ''' Predefined font weight : Ultra-black (950).
            ''' </summary>
            DWRITE_FONT_WEIGHT_ULTRA_BLACK = 950
        End Enum

        ''' <summary>
        ''' The font stretch Public Enumeration describes relative change from the normal aspect ratio
        ''' as specified by a font designer for the glyphs in a font.
        ''' Values less than 1 Or greater than 9 are considered to be invalid  And they are rejected by font API functions.
        ''' </summary>
        Public Enum DWRITE_FONT_STRETCH

            ''' <summary>
            ''' Predefined font stretch : Not known (0).
            ''' </summary>
            DWRITE_FONT_STRETCH_UNDEFINED = 0

            ''' <summary>
            ''' Predefined font stretch : Ultra-condensed (1).
            ''' </summary>
            DWRITE_FONT_STRETCH_ULTRA_CONDENSED = 1

            ''' <summary>
            ''' Predefined font stretch : Extra-condensed (2).
            ''' </summary>
            DWRITE_FONT_STRETCH_EXTRA_CONDENSED = 2

            ''' <summary>
            ''' Predefined font stretch : Condensed (3).
            ''' </summary>
            DWRITE_FONT_STRETCH_CONDENSED = 3

            ''' <summary>
            ''' Predefined font stretch : Semi-condensed (4).
            ''' </summary>
            DWRITE_FONT_STRETCH_SEMI_CONDENSED = 4

            ''' <summary>
            ''' Predefined font stretch : Normal (5).
            ''' </summary>
            DWRITE_FONT_STRETCH_NORMAL = 5

            ''' <summary>
            ''' Predefined font stretch : Medium (5).
            ''' </summary>
            DWRITE_FONT_STRETCH_MEDIUM = 5

            ''' <summary>
            ''' Predefined font stretch : Semi-expanded (6).
            ''' </summary>
            DWRITE_FONT_STRETCH_SEMI_EXPANDED = 6

            ''' <summary>
            ''' Predefined font stretch : Expanded (7).
            ''' </summary>
            DWRITE_FONT_STRETCH_EXPANDED = 7

            ''' <summary>
            ''' Predefined font stretch : Extra-expanded (8).
            ''' </summary>
            DWRITE_FONT_STRETCH_EXTRA_EXPANDED = 8

            ''' <summary>
            ''' Predefined font stretch : Ultra-expanded (9).
            ''' </summary>
            DWRITE_FONT_STRETCH_ULTRA_EXPANDED = 9
        End Enum

        ''' <summary>
        ''' The font style Public Enumeration describes the slope style of a font face  such as Normal  Italic Or Oblique.
        ''' Values other than the ones defined in the Public Enumeration are considered to be invalid  And they are rejected by font API functions.
        ''' </summary>
        Public Enum DWRITE_FONT_STYLE

            ''' <summary>
            ''' Font slope style : Normal.
            ''' </summary>
            DWRITE_FONT_STYLE_NORMAL

            ''' <summary>
            ''' Font slope style : Oblique.
            ''' </summary>
            DWRITE_FONT_STYLE_OBLIQUE

            ''' <summary>
            ''' Font slope style : Italic.
            ''' </summary>
            DWRITE_FONT_STYLE_ITALIC

        End Enum

        Public Enum WICBitmapDitherType
            WICBitmapDitherTypeNone = 0
            WICBitmapDitherTypeSolid = 0
            WICBitmapDitherTypeOrdered4x4 = &H1
            WICBitmapDitherTypeOrdered8x8 = &H2
            WICBitmapDitherTypeOrdered16x16 = &H3
            WICBitmapDitherTypeSpiral4x4 = &H4
            WICBitmapDitherTypeSpiral8x8 = &H5
            WICBitmapDitherTypeDualSpiral4x4 = &H6
            WICBitmapDitherTypeDualSpiral8x8 = &H7
            WICBitmapDitherTypeErrorDiffusion = &H8
            WICBITMAPDITHERTYPE_FORCE_DWORD = &H7FFFFFFF
        End Enum

        Public Enum WICBitmapPaletteType
            WICBitmapPaletteTypeCustom = 0
            WICBitmapPaletteTypeMedianCut = &H1
            WICBitmapPaletteTypeFixedBW = &H2
            WICBitmapPaletteTypeFixedHalftone8 = &H3
            WICBitmapPaletteTypeFixedHalftone27 = &H4
            WICBitmapPaletteTypeFixedHalftone64 = &H5
            WICBitmapPaletteTypeFixedHalftone125 = &H6
            WICBitmapPaletteTypeFixedHalftone216 = &H7
            WICBitmapPaletteTypeFixedWebPalette = WICBitmapPaletteTypeFixedHalftone216
            WICBitmapPaletteTypeFixedHalftone252 = &H8
            WICBitmapPaletteTypeFixedHalftone256 = &H9
            WICBitmapPaletteTypeFixedGray4 = &HA
            WICBitmapPaletteTypeFixedGray16 = &HB
            WICBitmapPaletteTypeFixedGray256 = &HC
            WICBITMAPPALETTETYPE_FORCE_DWORD = &H7FFFFFFF
        End Enum


        ''' <summary>
        ''' The measuring method used for text layout.
        ''' </summary>
        Public Enum DWRITE_MEASURING_MODE

            ''' <summary>
            ''' Text Is measured using glyph ideal metrics whose values are independent to the current display resolution.
            ''' </summary>
            DWRITE_MEASURING_MODE_NATURAL

            ''' <summary>
            ''' Text Is measured using glyph display compatible metrics whose values tuned for the current display resolution.
            ''' </summary>
            DWRITE_MEASURING_MODE_GDI_CLASSIC

            ''' <summary>
            ''' Text Is measured using the same glyph display metrics as text measured by GDI using a font
            ''' created with CLEARTYPE_NATURAL_QUALITY.
            ''' </summary>
            DWRITE_MEASURING_MODE_GDI_NATURAL

        End Enum



        ''' <summary>
        ''' /// This defines the superset of interpolation mode supported by D2D APIs
        ''' And built-in effects
        ''' </summary>
        Public Enum D2D1_INTERPOLATION_MODE
            D2D1_INTERPOLATION_MODE_DEFINITION_NEAREST_NEIGHBOR = 0
            D2D1_INTERPOLATION_MODE_DEFINITION_LINEAR = 1
            D2D1_INTERPOLATION_MODE_DEFINITION_CUBIC = 2
            D2D1_INTERPOLATION_MODE_DEFINITION_MULTI_SAMPLE_LINEAR = 3
            D2D1_INTERPOLATION_MODE_DEFINITION_ANISOTROPIC = 4
            D2D1_INTERPOLATION_MODE_DEFINITION_HIGH_QUALITY_CUBIC = 5
            D2D1_INTERPOLATION_MODE_DEFINITION_FANT = 6
            D2D1_INTERPOLATION_MODE_DEFINITION_MIPMAP_LINEAR = 7
        End Enum

        '''<summary>
        ''' This determines what gamma Is used for interpolation/blending.
        ''' </summary>
        Public Enum D2D1_GAMMA
            ''' <summary>
            ''' Colors are manipulated in 2.2 gamma color space.
            ''' </summary>
            D2D1_GAMMA_2_2 = 0

            ''' <summary>
            ''' Colors are manipulated in 1.0 gamma color space.
            ''' </summary>
            D2D1_GAMMA_1_0 = 1
            D2D1_GAMMA_FORCE_DWORD = &HFFFFFFFF
        End Enum

        ''' <summary>
        ''' Specifies what the contents are of an opacity mask.
        ''' </summary>
        Public Enum D2D1_OPACITY_MASK_CONTENT

            ''' <summary>
            ''' The mask contains geometries Or bitmaps.
            ''' </summary>
            D2D1_OPACITY_MASK_CONTENT_GRAPHICS = 0

            ''' <summary>
            ''' The mask contains text rendered using one of the natural text modes.
            ''' </summary>
            D2D1_OPACITY_MASK_CONTENT_TEXT_NATURAL = 1

            ''' <summary>
            ''' The mask contains text rendered using one of the GDI compatible text modes.
            ''' </summary>
            D2D1_OPACITY_MASK_CONTENT_TEXT_GDI_COMPATIBLE = 2
            D2D1_OPACITY_MASK_CONTENT_FORCE_DWORD = &HFFFFFFFF
        End Enum


        ''' <summary>
        ''' Enum which describes how to sample from a source outside its base tile.
        ''' </summary>
        Public Enum D2D1_EXTEND_MODE

            ''' <summary>
            ''' Extend the edges of the source out by clamping sample points outside the source
            ''' to the edges.
            ''' </summary>
            D2D1_EXTEND_MODE_CLAMP = 0

            ''' <summary>
            ''' The base tile Is drawn untransformed And the remainder are filled by repeating
            ''' the base tile.
            ''' </summary>
            D2D1_EXTEND_MODE_WRAP = 1

            ''' <summary>
            ''' The same as wrap, but alternate tiles are flipped  The base tile Is drawn
            ''' untransformed.
            ''' </summary>
            D2D1_EXTEND_MODE_MIRROR = 2
            D2D1_EXTEND_MODE_FORCE_DWORD = &HFFFFFFFF

        End Enum


        ''' <summary>
        ''' Enum which describes the manner in which we render edges of non-text primitives.
        ''' </summary>
        Public Enum D2D1_ANTIALIAS_MODE


            ''' <summary>
            ''' The edges of each primitive are antialiased sequentially.
            ''' </summary>
            D2D1_ANTIALIAS_MODE_PER_PRIMITIVE = 0

            ''' <summary>
            ''' Each pixel Is rendered if its pixel center Is contained by the geometry.
            ''' </summary>
            D2D1_ANTIALIAS_MODE_ALIASED = 1
            D2D1_ANTIALIAS_MODE_FORCE_DWORD = &HFFFFFFFF

        End Enum


        ''' <summary>
        ''' Describes the antialiasing mode used for drawing text.
        ''' </summary>
        Public Enum D2D1_TEXT_ANTIALIAS_MODE


            ''' <summary>
            ''' Render text using the current system setting.
            ''' </summary>
            D2D1_TEXT_ANTIALIAS_MODE_DEFAULT = 0

            ''' <summary>
            ''' Render text using ClearType.
            ''' </summary>
            D2D1_TEXT_ANTIALIAS_MODE_CLEARTYPE = 1

            ''' <summary>
            ''' Render text using gray-scale.
            ''' </summary>
            D2D1_TEXT_ANTIALIAS_MODE_GRAYSCALE = 2

            ''' <summary>
            ''' Render text aliased.
            ''' </summary>
            D2D1_TEXT_ANTIALIAS_MODE_ALIASED = 3
            D2D1_TEXT_ANTIALIAS_MODE_FORCE_DWORD = &HFFFFFFFF

        End Enum


        ''' <summary>
        ''' Specifies the algorithm that Is used when images are scaled Or rotated. Note
        ''' Starting in Windows 8, more interpolations modes are available. See
        ''' D2D1_INTERPOLATION_MODE for more info.
        ''' </summary>
        Public Enum D2D1_BITMAP_INTERPOLATION_MODE


            ''' <summary>
            ''' Nearest Neighbor filtering. Also known as nearest pixel Or nearest point
            ''' sampling.
            ''' </summary>
            D2D1_BITMAP_INTERPOLATION_MODE_NEAREST_NEIGHBOR = 0

            ''' <summary>
            ''' Linear filtering.
            ''' </summary>
            D2D1_BITMAP_INTERPOLATION_MODE_LINEAR = 1
            D2D1_BITMAP_INTERPOLATION_MODE_FORCE_DWORD = &HFFFFFFFF

        End Enum


        ''' <summary>
        ''' Modifications made to the draw text call that influence how the text Is
        ''' rendered.
        ''' </summary>
        Public Enum D2D1_DRAW_TEXT_OPTIONS


            ''' <summary>
            ''' Do Not snap the baseline of the text vertically.
            ''' </summary>
            D2D1_DRAW_TEXT_OPTIONS_NO_SNAP = &H1

            ''' <summary>
            ''' Clip the text to the content bounds.
            ''' </summary>
            D2D1_DRAW_TEXT_OPTIONS_CLIP = &H2

            ''' <summary>
            ''' Render color versions of glyphs if defined by the font.
            ''' </summary>
            D2D1_DRAW_TEXT_OPTIONS_ENABLE_COLOR_FONT = &H4

            ''' <summary>
            ''' Bitmap origins of color glyph bitmaps are Not snapped.
            ''' </summary>
            D2D1_DRAW_TEXT_OPTIONS_DISABLE_COLOR_BITMAP_SNAPPING = &H8
            D2D1_DRAW_TEXT_OPTIONS_NONE = &H0
            D2D1_DRAW_TEXT_OPTIONS_FORCE_DWORD = &HFFFFFFFF

        End Enum

        Public Enum DXGI_FORMAT
            DXGI_FORMAT_UNKNOWN = 0
            DXGI_FORMAT_R32G32B32A32_TYPELESS = 1
            DXGI_FORMAT_R32G32B32A32_FLOAT = 2
            DXGI_FORMAT_R32G32B32A32_UINT = 3
            DXGI_FORMAT_R32G32B32A32_SINT = 4
            DXGI_FORMAT_R32G32B32_TYPELESS = 5
            DXGI_FORMAT_R32G32B32_FLOAT = 6
            DXGI_FORMAT_R32G32B32_UINT = 7
            DXGI_FORMAT_R32G32B32_SINT = 8
            DXGI_FORMAT_R16G16B16A16_TYPELESS = 9
            DXGI_FORMAT_R16G16B16A16_FLOAT = 10
            DXGI_FORMAT_R16G16B16A16_UNORM = 11
            DXGI_FORMAT_R16G16B16A16_UINT = 12
            DXGI_FORMAT_R16G16B16A16_SNORM = 13
            DXGI_FORMAT_R16G16B16A16_SINT = 14
            DXGI_FORMAT_R32G32_TYPELESS = 15
            DXGI_FORMAT_R32G32_FLOAT = 16
            DXGI_FORMAT_R32G32_UINT = 17
            DXGI_FORMAT_R32G32_SINT = 18
            DXGI_FORMAT_R32G8X24_TYPELESS = 19
            DXGI_FORMAT_D32_FLOAT_S8X24_UINT = 20
            DXGI_FORMAT_R32_FLOAT_X8X24_TYPELESS = 21
            DXGI_FORMAT_X32_TYPELESS_G8X24_UINT = 22
            DXGI_FORMAT_R10G10B10A2_TYPELESS = 23
            DXGI_FORMAT_R10G10B10A2_UNORM = 24
            DXGI_FORMAT_R10G10B10A2_UINT = 25
            DXGI_FORMAT_R11G11B10_FLOAT = 26
            DXGI_FORMAT_R8G8B8A8_TYPELESS = 27
            DXGI_FORMAT_R8G8B8A8_UNORM = 28
            DXGI_FORMAT_R8G8B8A8_UNORM_SRGB = 29
            DXGI_FORMAT_R8G8B8A8_UINT = 30
            DXGI_FORMAT_R8G8B8A8_SNORM = 31
            DXGI_FORMAT_R8G8B8A8_SINT = 32
            DXGI_FORMAT_R16G16_TYPELESS = 33
            DXGI_FORMAT_R16G16_FLOAT = 34
            DXGI_FORMAT_R16G16_UNORM = 35
            DXGI_FORMAT_R16G16_UINT = 36
            DXGI_FORMAT_R16G16_SNORM = 37
            DXGI_FORMAT_R16G16_SINT = 38
            DXGI_FORMAT_R32_TYPELESS = 39
            DXGI_FORMAT_D32_FLOAT = 40
            DXGI_FORMAT_R32_FLOAT = 41
            DXGI_FORMAT_R32_UINT = 42
            DXGI_FORMAT_R32_SINT = 43
            DXGI_FORMAT_R24G8_TYPELESS = 44
            DXGI_FORMAT_D24_UNORM_S8_UINT = 45
            DXGI_FORMAT_R24_UNORM_X8_TYPELESS = 46
            DXGI_FORMAT_X24_TYPELESS_G8_UINT = 47
            DXGI_FORMAT_R8G8_TYPELESS = 48
            DXGI_FORMAT_R8G8_UNORM = 49
            DXGI_FORMAT_R8G8_UINT = 50
            DXGI_FORMAT_R8G8_SNORM = 51
            DXGI_FORMAT_R8G8_SINT = 52
            DXGI_FORMAT_R16_TYPELESS = 53
            DXGI_FORMAT_R16_FLOAT = 54
            DXGI_FORMAT_D16_UNORM = 55
            DXGI_FORMAT_R16_UNORM = 56
            DXGI_FORMAT_R16_UINT = 57
            DXGI_FORMAT_R16_SNORM = 58
            DXGI_FORMAT_R16_SINT = 59
            DXGI_FORMAT_R8_TYPELESS = 60
            DXGI_FORMAT_R8_UNORM = 61
            DXGI_FORMAT_R8_UINT = 62
            DXGI_FORMAT_R8_SNORM = 63
            DXGI_FORMAT_R8_SINT = 64
            DXGI_FORMAT_A8_UNORM = 65
            DXGI_FORMAT_R1_UNORM = 66
            DXGI_FORMAT_R9G9B9E5_SHAREDEXP = 67
            DXGI_FORMAT_R8G8_B8G8_UNORM = 68
            DXGI_FORMAT_G8R8_G8B8_UNORM = 69
            DXGI_FORMAT_BC1_TYPELESS = 70
            DXGI_FORMAT_BC1_UNORM = 71
            DXGI_FORMAT_BC1_UNORM_SRGB = 72
            DXGI_FORMAT_BC2_TYPELESS = 73
            DXGI_FORMAT_BC2_UNORM = 74
            DXGI_FORMAT_BC2_UNORM_SRGB = 75
            DXGI_FORMAT_BC3_TYPELESS = 76
            DXGI_FORMAT_BC3_UNORM = 77
            DXGI_FORMAT_BC3_UNORM_SRGB = 78
            DXGI_FORMAT_BC4_TYPELESS = 79
            DXGI_FORMAT_BC4_UNORM = 80
            DXGI_FORMAT_BC4_SNORM = 81
            DXGI_FORMAT_BC5_TYPELESS = 82
            DXGI_FORMAT_BC5_UNORM = 83
            DXGI_FORMAT_BC5_SNORM = 84
            DXGI_FORMAT_B5G6R5_UNORM = 85
            DXGI_FORMAT_B5G5R5A1_UNORM = 86
            DXGI_FORMAT_B8G8R8A8_UNORM = 87
            DXGI_FORMAT_B8G8R8X8_UNORM = 88
            DXGI_FORMAT_R10G10B10_XR_BIAS_A2_UNORM = 89
            DXGI_FORMAT_B8G8R8A8_TYPELESS = 90
            DXGI_FORMAT_B8G8R8A8_UNORM_SRGB = 91
            DXGI_FORMAT_B8G8R8X8_TYPELESS = 92
            DXGI_FORMAT_B8G8R8X8_UNORM_SRGB = 93
            DXGI_FORMAT_BC6H_TYPELESS = 94
            DXGI_FORMAT_BC6H_UF16 = 95
            DXGI_FORMAT_BC6H_SF16 = 96
            DXGI_FORMAT_BC7_TYPELESS = 97
            DXGI_FORMAT_BC7_UNORM = 98
            DXGI_FORMAT_BC7_UNORM_SRGB = 99
            DXGI_FORMAT_AYUV = 100
            DXGI_FORMAT_Y410 = 101
            DXGI_FORMAT_Y416 = 102
            DXGI_FORMAT_NV12 = 103
            DXGI_FORMAT_P010 = 104
            DXGI_FORMAT_P016 = 105
            DXGI_FORMAT_420_OPAQUE = 106
            DXGI_FORMAT_YUY2 = 107
            DXGI_FORMAT_Y210 = 108
            DXGI_FORMAT_Y216 = 109
            DXGI_FORMAT_NV11 = 110
            DXGI_FORMAT_AI44 = 111
            DXGI_FORMAT_IA44 = 112
            DXGI_FORMAT_P8 = 113
            DXGI_FORMAT_A8P8 = 114
            DXGI_FORMAT_B4G4R4A4_UNORM = 115
            DXGI_FORMAT_P208 = 130
            DXGI_FORMAT_V208 = 131
            DXGI_FORMAT_V408 = 132
            DXGI_FORMAT_FORCE_UINT = &HFFFFFFFF
        End Enum

        Public Enum D2D1_ALPHA_MODE

            ''' <summary>
            ''' Alpha mode should be determined implicitly. Some target surfaces do Not supply
            ''' Or imply this information in which case alpha must be specified.
            ''' </summary>
            D2D1_ALPHA_MODE_UNKNOWN = 0

            ''' <summary>
            ''' Treat the alpha as premultipled.
            ''' </summary>
            D2D1_ALPHA_MODE_PREMULTIPLIED = 1

            ''' <summary>
            ''' Opacity Is in the 'A' component only.
            ''' </summary>
            D2D1_ALPHA_MODE_STRAIGHT = 2

            ''' <summary>
            ''' Ignore any alpha channel information.
            ''' </summary>
            D2D1_ALPHA_MODE_IGNORE = 3

            D2D1_ALPHA_MODE_FORCE_DWORD = &HFFFFFFFF

        End Enum

        ''' <summary>
        '''Description of a pixel format.
        ''' </summary>
        <StructLayout(LayoutKind.Sequential)>
        Public Structure D2D1_PIXEL_FORMAT
            Public Format As DXGI_FORMAT
            Public AlphaMode As D2D1_ALPHA_MODE
        End Structure

        ''' <summary>
        ''' Describes the pixel format And dpi of a bitmap.
        ''' </summary>
        <StructLayout(LayoutKind.Sequential)>
        Public Structure D2D1_BITMAP_PROPERTIES
            <MarshalAs(UnmanagedType.Struct)>
            Public PixelFormat As D2D1_PIXEL_FORMAT
            Public DpiX As Single
            Public DpiY As Single
        End Structure


        ''' <summary>
        ''' Represents an x-coordinate And y-coordinate pair in two-dimensional space.
        ''' </summary>
        <StructLayout(LayoutKind.Sequential)>
        Public Structure D2D1_POINT_2U
            Public x As UInt32
            Public y As UInt32
        End Structure

        ''' <summary>
        ''' A vector of 2 FLOAT values (x, y).
        '''</summary>
        <StructLayout(LayoutKind.Sequential)>
        Public Structure D2D1_VECTOR_2F
            Public x As Single
            Public y As Single
        End Structure

        ''' <summary>
        ''' A point of 2 FLOAT values (x, y).
        '''</summary>
        <StructLayout(LayoutKind.Sequential)>
        Public Structure D2D1_POINT_2F
            Public x As Single
            Public y As Single
        End Structure

        ''' <summary>
        ''' D3D Color structure
        ''' </summary>
        <StructLayout(LayoutKind.Sequential)>
        Public Structure D2D1_COLOR_F
            Public r As Single
            Public g As Single
            Public b As Single
            Public a As Single
        End Structure

        ''' <summary>
        ''' Contains the position And color of a gradient stop.
        ''' </summary>
        <StructLayout(LayoutKind.Sequential)>
        Public Structure D2D1_GRADIENT_STOP
            Public position As Single
            <MarshalAs(UnmanagedType.Struct)>
            Public color As D2D1_COLOR_F
        End Structure

        <StructLayout(LayoutKind.Sequential)>
        Public Structure D2D1_MATRIX_3X2_F
            ''' <summary>
            ''' Horizontal scaling / cosine of rotation
            ''' </summary>
            Public m11 As Single

            ''' <summary>
            ''' Vertical shear / sine of rotation
            ''' </summary>
            Public m12 As Single

            ''' <summary>
            ''' Horizontal shear / negative sine of rotation
            ''' </summary>
            Public m21 As Single

            ''' <summary>
            ''' Vertical scaling / cosine of rotation
            ''' </summary>
            Public m22 As Single

            ''' <summary>
            ''' Horizontal shift (always orthogonal regardless of rotation)
            ''' </summary>
            Public m31 As Single

            ''' <summary>
            ''' Vertical shift (always orthogonal regardless of rotation)
            ''' </summary>
            Public m32 As Single
        End Structure

        ''' <summary>
        ''' Describes the opacity and transformation of a brush.
        ''' </summary>
        <StructLayout(LayoutKind.Sequential)>
        Public Structure D2D1_BRUSH_PROPERTIES
            Public opacity As Single

            <MarshalAs(UnmanagedType.Struct)>
            Public transform As D2D1_MATRIX_3X2_F
        End Structure


        ''' <summary>
        ''' Describes the extend modes and the interpolation mode of an ID2D1BitmapBrush.
        ''' </summary>
        <StructLayout(LayoutKind.Sequential)>
        Public Structure D2D1_BITMAP_BRUSH_PROPERTIES
            Public extendModeX As D2D1_EXTEND_MODE
            Public extendModeY As D2D1_EXTEND_MODE
            Public interpolationMode As D2D1_BITMAP_INTERPOLATION_MODE
        End Structure


        ''' <summary>
        ''' Contains the starting point and endpoint of the gradient axis for an
        ''' ID2D1LinearGradientBrush.
        ''' </summary>
        <StructLayout(LayoutKind.Sequential)>
        Public Structure D2D1_LINEAR_GRADIENT_BRUSH_PROPERTIES
            <MarshalAs(UnmanagedType.Struct)>
            Public startPoint As D2D1_POINT_2F

            <MarshalAs(UnmanagedType.Struct)>
            Public endPoint As D2D1_POINT_2F
        End Structure


        ''' <summary>
        ''' Contains the gradient origin offset and the size and position of the gradient
        ''' ellipse for an ID2D1RadialGradientBrush.
        ''' </summary>
        <StructLayout(LayoutKind.Sequential)>
        Public Structure D2D1_RADIAL_GRADIENT_BRUSH_PROPERTIES
            <MarshalAs(UnmanagedType.Struct)>
            Public center As D2D1_POINT_2F
            <MarshalAs(UnmanagedType.Struct)>
            Public gradientOriginOffset As D2D1_POINT_2F
            Public radiusX As Single
            Public radiusY As Single
        End Structure


        ''' <summary>
        ''' Differentiates which of the two possible arcs could match the given arc
        ''' parameters.
        ''' </summary>
        Public Enum D2D1_ARC_SIZE

            D2D1_ARC_SIZE_SMALL = 0
            D2D1_ARC_SIZE_LARGE = 1
            D2D1_ARC_SIZE_FORCE_DWORD = &HFFFFFFFF

        End Enum


        ''' <summary>
        ''' Enum which describes the drawing of the ends of a line.
        ''' </summary>
        Public Enum D2D1_CAP_STYLE


            ''' <summary>
            ''' Flat line cap.
            ''' </summary>
            D2D1_CAP_STYLE_FLAT = 0

            ''' <summary>
            ''' Square line cap.
            ''' </summary>
            D2D1_CAP_STYLE_SQUARE = 1

            ''' <summary>
            ''' Round line cap.
            ''' </summary>
            D2D1_CAP_STYLE_ROUND = 2

            ''' <summary>
            ''' Triangle line cap.
            ''' </summary>
            D2D1_CAP_STYLE_TRIANGLE = 3
            D2D1_CAP_STYLE_FORCE_DWORD = &HFFFFFFFF

        End Enum


        ''' <summary>
        ''' Describes the sequence of dashes and gaps in a stroke.
        ''' </summary>
        Public Enum D2D1_DASH_STYLE

            D2D1_DASH_STYLE_SOLID = 0
            D2D1_DASH_STYLE_DASH = 1
            D2D1_DASH_STYLE_DOT = 2
            D2D1_DASH_STYLE_DASH_DOT = 3
            D2D1_DASH_STYLE_DASH_DOT_DOT = 4
            D2D1_DASH_STYLE_CUSTOM = 5
            D2D1_DASH_STYLE_FORCE_DWORD = &HFFFFFFFF

        End Enum


        ''' <summary>
        ''' Enum which describes the drawing of the corners on the line.
        ''' </summary>
        Public Enum D2D1_LINE_JOIN


            ''' <summary>
            ''' Miter join.
            ''' </summary>
            D2D1_LINE_JOIN_MITER = 0

            ''' <summary>
            ''' Bevel join.
            ''' </summary>
            D2D1_LINE_JOIN_BEVEL = 1

            ''' <summary>
            ''' Round join.
            ''' </summary>
            D2D1_LINE_JOIN_ROUND = 2

            ''' <summary>
            ''' Miter/Bevel join.
            ''' </summary>
            D2D1_LINE_JOIN_MITER_OR_BEVEL = 3
            D2D1_LINE_JOIN_FORCE_DWORD = &HFFFFFFFF

        End Enum


        ''' <summary>
        ''' This enumeration describes the type of combine operation to be performed.
        ''' </summary>
        Public Enum D2D1_COMBINE_MODE

            ''' <summary>
            ''' Produce a geometry representing the set of points contained in either the first
            ''' or the second geometry.
            ''' </summary>
            D2D1_COMBINE_MODE_UNION = 0

            ''' <summary>
            ''' Produce a geometry representing the set of points common to the first and the
            ''' second geometries.
            ''' </summary>
            D2D1_COMBINE_MODE_INTERSECT = 1

            ''' <summary>
            ''' Produce a geometry representing the set of points contained in the first
            ''' geometry or the second geometry  but not both.
            ''' </summary>
            D2D1_COMBINE_MODE_XOR = 2

            ''' <summary>
            ''' Produce a geometry representing the set of points contained in the first
            ''' geometry but not the second geometry.
            ''' </summary>
            D2D1_COMBINE_MODE_EXCLUDE = 3
            D2D1_COMBINE_MODE_FORCE_DWORD = &HFFFFFFFF
        End Enum


        ''' <summary>
        ''' Describes how one geometry object is spatially related to another geometry
        ''' object.
        ''' </summary>
        Public Enum D2D1_GEOMETRY_RELATION

            ''' <summary>
            ''' The relation between the geometries couldn't be determined. This value is never
            ''' returned by any D2D method.
            ''' </summary>
            D2D1_GEOMETRY_RELATION_UNKNOWN = 0

            ''' <summary>
            ''' The two geometries do not intersect at all.
            ''' </summary>
            D2D1_GEOMETRY_RELATION_DISJOINT = 1

            ''' <summary>
            ''' The passed in geometry is entirely contained by the object.
            ''' </summary>
            D2D1_GEOMETRY_RELATION_IS_CONTAINED = 2

            ''' <summary>
            ''' The object entirely contains the passed in geometry.
            ''' </summary>
            D2D1_GEOMETRY_RELATION_CONTAINS = 3

            ''' <summary>
            ''' The two geometries overlap but neither completely contains the other.
            ''' </summary>
            D2D1_GEOMETRY_RELATION_OVERLAP = 4
            D2D1_GEOMETRY_RELATION_FORCE_DWORD = &HFFFFFFFF
        End Enum


        ''' <summary>
        ''' Specifies how simple the output of a simplified geometry sink should be.
        ''' </summary>
        Public Enum D2D1_GEOMETRY_SIMPLIFICATION_OPTION
            D2D1_GEOMETRY_SIMPLIFICATION_OPTION_CUBICS_AND_LINES = 0
            D2D1_GEOMETRY_SIMPLIFICATION_OPTION_LINES = 1
            D2D1_GEOMETRY_SIMPLIFICATION_OPTION_FORCE_DWORD = &HFFFFFFFF
        End Enum


        ''' <summary>
        ''' Indicates whether the given figure is filled or hollow.
        ''' </summary>
        Public Enum D2D1_FIGURE_BEGIN
            D2D1_FIGURE_BEGIN_FILLED = 0
            D2D1_FIGURE_BEGIN_HOLLOW = 1
            D2D1_FIGURE_BEGIN_FORCE_DWORD = &HFFFFFFFF
        End Enum


        ''' <summary>
        ''' Indicates whether the figure is open or closed on its end point.
        ''' </summary>
        Public Enum D2D1_FIGURE_END

            D2D1_FIGURE_END_OPEN = 0
            D2D1_FIGURE_END_CLOSED = 1
            D2D1_FIGURE_END_FORCE_DWORD = &HFFFFFFFF

        End Enum


        ''' <summary>
        ''' Describes a cubic bezier in a path.
        ''' </summary>
        <StructLayout(LayoutKind.Sequential)>
        Public Structure D2D1_BEZIER_SEGMENT
            <MarshalAs(UnmanagedType.Struct)>
            Public point1 As D2D1_POINT_2F
            <MarshalAs(UnmanagedType.Struct)>
            Public point2 As D2D1_POINT_2F
            <MarshalAs(UnmanagedType.Struct)>
            Public point3 As D2D1_POINT_2F
        End Structure


        ''' <summary>
        ''' Describes a triangle.
        ''' </summary>
        <StructLayout(LayoutKind.Sequential)>
        Public Structure D2D1_TRIANGLE
            <MarshalAs(UnmanagedType.Struct)>
            Public point1 As D2D1_POINT_2F
            <MarshalAs(UnmanagedType.Struct)>
            Public point2 As D2D1_POINT_2F
            <MarshalAs(UnmanagedType.Struct)>
            Public point3 As D2D1_POINT_2F
        End Structure


        ''' <summary>
        ''' Indicates whether the given segment should be stroked  or  if the join between
        ''' this segment and the previous one should be smooth.
        ''' </summary>
        Public Enum D2D1_PATH_SEGMENT
            D2D1_PATH_SEGMENT_NONE = &H0
            D2D1_PATH_SEGMENT_FORCE_UNSTROKED = &H1
            D2D1_PATH_SEGMENT_FORCE_ROUND_LINE_JOIN = &H2
            D2D1_PATH_SEGMENT_FORCE_DWORD = &HFFFFFFFF
        End Enum




        ''' <summary>
        ''' Defines the direction that an elliptical arc is drawn.
        ''' </summary>
        Public Enum D2D1_SWEEP_DIRECTION
            D2D1_SWEEP_DIRECTION_COUNTER_CLOCKWISE = 0
            D2D1_SWEEP_DIRECTION_CLOCKWISE = 1
            D2D1_SWEEP_DIRECTION_FORCE_DWORD = &HFFFFFFFF
        End Enum


        ''' <summary>
        ''' Specifies how the intersecting areas of geometries or figures are combined to
        ''' form the area of the composite geometry.
        ''' </summary>
        Public Enum D2D1_FILL_MODE
            D2D1_FILL_MODE_ALTERNATE = 0
            D2D1_FILL_MODE_WINDING = 1
            D2D1_FILL_MODE_FORCE_DWORD = &HFFFFFFFF
        End Enum

        <StructLayout(LayoutKind.Sequential)>
        Public Structure D2D1_SIZE_F
            Public width As Single
            Public height As Single
        End Structure

        <StructLayout(LayoutKind.Sequential)>
        Public Structure D2D1_SIZE_U
            Public width As UInt32
            Public height As UInt32
        End Structure


        ''' <summary>
        ''' Describes an arc that is defined as part of a path.
        ''' </summary>
        <StructLayout(LayoutKind.Sequential)>
        Public Structure D2D1_ARC_SEGMENT
            <MarshalAs(UnmanagedType.Struct)>
            Public point As D2D1_POINT_2F
            <MarshalAs(UnmanagedType.Struct)>
            Public size As D2D1_SIZE_F
            Public rotationAngle As Single
            Public sweepDirection As D2D1_SWEEP_DIRECTION
            Public arcSize As D2D1_ARC_SIZE
        End Structure


        ''' <summary>
        ''' Contains the control point and end point for a quadratic Bezier segment.
        ''' </summary>
        <StructLayout(LayoutKind.Sequential)>
        Public Structure D2D1_QUADRATIC_BEZIER_SEGMENT
            <MarshalAs(UnmanagedType.Struct)>
            Public point1 As D2D1_POINT_2F
            <MarshalAs(UnmanagedType.Struct)>
            Public point2 As D2D1_POINT_2F
        End Structure


        ''' <summary>
        ''' Contains the center point  x-radius  and y-radius of an ellipse.
        ''' </summary>
        <StructLayout(LayoutKind.Sequential)>
        Public Structure D2D1_ELLIPSE
            <MarshalAs(UnmanagedType.Struct)>
            Public point As D2D1_POINT_2F
            Public radiusX As Single
            Public radiusY As Single
        End Structure

        <StructLayout(LayoutKind.Sequential)>
        Public Structure D2D1_RECT_F
            Public left As Single
            Public top As Single
            Public right As Single
            Public bottom As Single
        End Structure


        <StructLayout(LayoutKind.Sequential)>
        Public Structure D2D1_RECT_U
            Public left As UInt32
            Public top As UInt32
            Public right As UInt32
            Public bottom As UInt32
        End Structure


        ''' <summary>
        ''' Contains the dimensions and corner radii of a rounded rectangle.
        ''' </summary>
        <StructLayout(LayoutKind.Sequential)>
        Public Structure D2D1_ROUNDED_RECT
            <MarshalAs(UnmanagedType.Struct)>
            Public rect As D2D1_RECT_F
            Public radiusX As Single
            Public radiusY As Single
        End Structure


        ''' <summary>
        ''' Properties  aside from the width  that allow geometric penning to be specified.
        ''' </summary>
        <StructLayout(LayoutKind.Sequential)>
        Public Structure D2D1_STROKE_STYLE_PROPERTIES
            Public startCap As D2D1_CAP_STYLE
            Public endCap As D2D1_CAP_STYLE
            Public dashCap As D2D1_CAP_STYLE
            Public lineJoin As D2D1_LINE_JOIN
            Public miterLimit As Single
            Public dashStyle As D2D1_DASH_STYLE
            Public dashOffset As Single
        End Structure


        ''' <summary>
        ''' Specified options that can be applied when a layer resource is applied to create
        ''' a layer.
        ''' </summary>
        Public Enum D2D1_LAYER_OPTIONS

            D2D1_LAYER_OPTIONS_NONE = &H0

            ''' <summary>
            ''' The layer will render correctly for ClearType text. If the render target was set
            ''' to ClearType previously  the layer will continue to render ClearType. If the
            ''' render target was set to ClearType and this option is not specified  the render
            ''' target will be set to render gray-scale until the layer is popped. The caller
            ''' can override this default by calling SetTextAntialiasMode while within the
            ''' layer. This flag is slightly slower than the default.
            ''' </summary>
            D2D1_LAYER_OPTIONS_INITIALIZE_FOR_CLEARTYPE = &H1
            D2D1_LAYER_OPTIONS_FORCE_DWORD = &HFFFFFFFF
        End Enum

        ''' <summary>
        ''' Contains the content bounds  mask information  opacity settings  and other
        ''' options for a layer resource.
        ''' </summary>
        <StructLayout(LayoutKind.Sequential)>
        Public Structure D2D1_LAYER_PARAMETERS


            ''' <summary>
            ''' The rectangular clip that will be applied to the layer. The clip is affected by
            ''' the world transform. Content outside of the content bounds will not render.
            ''' </summary>
            <MarshalAs(UnmanagedType.Struct)>
            Public contentBounds As D2D1_RECT_F


            ''' <summary>
            ''' A general mask that can be optionally applied to the content. Content not inside
            ''' the fill of the mask will not be rendered.
            ''' </summary>
            Public geometricMask As IntPtr
 _

            ''' <summary>
            ''' Specifies whether the mask should be aliased or antialiased.
            ''' </summary>
            Public maskAntialiasMode As D2D1_ANTIALIAS_MODE

            ''' <summary>
            ''' An additional transform that may be applied to the mask in addition to the
            ''' current world transform.
            ''' </summary>
            <MarshalAs(UnmanagedType.Struct)>
            Public maskTransform As D2D1_MATRIX_3X2_F


            ''' <summary>
            ''' The opacity with which all of the content in the layer will be blended back to
            ''' the target when the layer is popped.
            ''' </summary>
            Public opacity As Single

            ''' <summary>
            ''' An additional brush that can be applied to the layer. Only the opacity channel
            ''' is sampled from this brush and multiplied both with the layer content and the
            ''' over-all layer opacity.
            ''' </summary>
            Public opacityBrush As IntPtr   ' ID2D1Brush
            ''' <summary>
            ''' Specifies if ClearType will be rendered into the layer.
            ''' </summary>
            Public layerOptions As D2D1_LAYER_OPTIONS

        End Structure


        ''' <summary>
        ''' Describes whether a window is occluded.
        ''' </summary>
        Public Enum D2D1_WINDOW_STATE
            D2D1_WINDOW_STATE_NONE = &H0
            D2D1_WINDOW_STATE_OCCLUDED = &H1
            D2D1_WINDOW_STATE_FORCE_DWORD = &HFFFFFFFF
        End Enum

        ''' <summary>
        ''' Describes whether a render target uses hardware or software rendering  or if
        ''' Direct2D should select the rendering mode.
        ''' </summary>
        Public Enum D2D1_RENDER_TARGET_TYPE

            ''' <summary>
            ''' D2D is free to choose the render target type for the caller.
            ''' </summary>
            D2D1_RENDER_TARGET_TYPE_DEFAULT = 0

            ''' <summary>
            ''' The render target will render using the CPU.
            ''' </summary>
            D2D1_RENDER_TARGET_TYPE_SOFTWARE = 1

            ''' <summary>
            ''' The render target will render using the GPU.
            ''' </summary>
            D2D1_RENDER_TARGET_TYPE_HARDWARE = 2
            D2D1_RENDER_TARGET_TYPE_FORCE_DWORD = &HFFFFFFFF
        End Enum


        ''' <summary>
        ''' Describes the minimum DirectX support required for hardware rendering by a
        ''' render target.
        ''' </summary>
        Public Enum D2D1_FEATURE_LEVEL

            ''' <summary>
            ''' The caller does not require a particular underlying D3D device level.
            ''' </summary>
            D2D1_FEATURE_LEVEL_DEFAULT = 0

            ''' <summary>
            ''' The D3D device level is DX9 compatible.
            ''' </summary>
            D2D1_FEATURE_LEVEL_9 = &H9100

            ''' <summary>
            ''' The D3D device level is DX10 compatible.
            ''' </summary>
            D2D1_FEATURE_LEVEL_10 = &HA000
            D2D1_FEATURE_LEVEL_FORCE_DWORD = &HFFFFFFFF
        End Enum


        ''' <summary>
        ''' Describes how a render target is remoted and whether it should be
        ''' GDI-compatible. This enumeration allows a bitwise combination of its member
        ''' values.
        ''' </summary>
        <Flags()>
        Public Enum D2D1_RENDER_TARGET_USAGE

            D2D1_RENDER_TARGET_USAGE_NONE = &H0

            ''' <summary>
            ''' Rendering will occur locally  if a terminal-services session is established  the
            ''' bitmap updates will be sent to the terminal services client.
            ''' </summary>
            D2D1_RENDER_TARGET_USAGE_FORCE_BITMAP_REMOTING = &H1

            ''' <summary>
            ''' The render target will allow a call to GetDC on the ID2D1GdiInteropRenderTarget
            ''' interface. Rendering will also occur locally.
            ''' </summary>
            D2D1_RENDER_TARGET_USAGE_GDI_COMPATIBLE = &H2
            D2D1_RENDER_TARGET_USAGE_FORCE_DWORD = &HFFFFFFFF

        End Enum


        ''' <summary>
        ''' Describes how present should behave.
        ''' </summary>
        <Flags()>
        Public Enum D2D1_PRESENT_OPTIONS

            D2D1_PRESENT_OPTIONS_NONE = &H0

            ''' <summary>
            ''' Keep the target contents intact through present.
            ''' </summary>
            D2D1_PRESENT_OPTIONS_RETAIN_CONTENTS = &H1

            ''' <summary>
            ''' Do not wait for display refresh to commit changes to display.
            ''' </summary>
            D2D1_PRESENT_OPTIONS_IMMEDIATELY = &H2
            D2D1_PRESENT_OPTIONS_FORCE_DWORD = &HFFFFFFFF
        End Enum


        ''' <summary>
        ''' Contains rendering options (hardware or software)  pixel format  DPI
        ''' information  remoting options  and Direct3D support requirements for a render
        ''' target.
        ''' </summary>
        <StructLayout(LayoutKind.Sequential)>
        Public Structure D2D1_RENDER_TARGET_PROPERTIES
            Public type As D2D1_RENDER_TARGET_TYPE

            <MarshalAs(UnmanagedType.Struct)>
            Public pixelFormat As D2D1_PIXEL_FORMAT

            Public dpiX As Single
            Public dpiY As Single
            Public usage As D2D1_RENDER_TARGET_USAGE
            Public minLevel As D2D1_FEATURE_LEVEL
        End Structure


        ''' <summary>
        ''' Contains the HWND  pixel size  and presentation options for an
        ''' ID2D1HwndRenderTarget.
        ''' </summary>
        <StructLayout(LayoutKind.Sequential)>
        Public Structure D2D1_HWND_RENDER_TARGET_PROPERTIES
            Public hwnd As IntPtr

            <MarshalAs(UnmanagedType.Struct)>
            Public pixelSize As D2D1_SIZE_U

            Public presentOptions As D2D1_PRESENT_OPTIONS
        End Structure


        ''' <summary>
        ''' Specifies additional features supportable by a compatible render target when it
        ''' is created. This enumeration allows a bitwise combination of its member values.
        ''' </summary>
        <Flags()>
        Public Enum D2D1_COMPATIBLE_RENDER_TARGET_OPTIONS

            D2D1_COMPATIBLE_RENDER_TARGET_OPTIONS_NONE = &H0

            ''' <summary>
            ''' The compatible render target will allow a call to GetDC on the
            ''' ID2D1GdiInteropRenderTarget interface. This can be specified even if the parent
            ''' render target is not GDI compatible.
            ''' </summary>
            D2D1_COMPATIBLE_RENDER_TARGET_OPTIONS_GDI_COMPATIBLE = &H1
            D2D1_COMPATIBLE_RENDER_TARGET_OPTIONS_FORCE_DWORD = &HFFFFFFFF
        End Enum




        ''' <summary>
        ''' Allows the drawing state to be atomically created. This also specifies the
        ''' drawing state that is saved into an IDrawingStateBlock object.
        ''' </summary>
        <StructLayout(LayoutKind.Sequential)>
        Public Structure D2D1_DRAWING_STATE_DESCRIPTION
            Public antialiasMode As D2D1_ANTIALIAS_MODE
            Public textAntialiasMode As D2D1_TEXT_ANTIALIAS_MODE
            Public tag1 As UInt64
            Public tag2 As UInt64
            <MarshalAs(UnmanagedType.Struct)>
            Public transform As D2D1_MATRIX_3X2_F
        End Structure


        ''' <summary>
        ''' Specifies how a device context is initialized for GDI rendering when it is
        ''' retrieved from the render target.
        ''' </summary>
        Public Enum D2D1_DC_INITIALIZE_MODE
            ''' <summary>
            ''' The contents of the D2D render target will be copied to the DC.
            ''' </summary>
            D2D1_DC_INITIALIZE_MODE_COPY = 0

            ''' <summary>
            ''' The contents of the DC will be cleared.
            ''' </summary>
            D2D1_DC_INITIALIZE_MODE_CLEAR = 1
            D2D1_DC_INITIALIZE_MODE_FORCE_DWORD = &HFFFFFFFF
        End Enum


        ''' <summary>
        ''' Indicates the debug level to be output by the debug layer.
        ''' </summary>
        Public Enum D2D1_DEBUG_LEVEL
            D2D1_DEBUG_LEVEL_NONE = 0
            D2D1_DEBUG_LEVEL_ERROR = 1
            D2D1_DEBUG_LEVEL_WARNING = 2
            D2D1_DEBUG_LEVEL_INFORMATION = 3
            D2D1_DEBUG_LEVEL_FORCE_DWORD = &HFFFFFFFF
        End Enum

        ''' <summary>
        ''' Specifies the threading model of the created factory and all of its derived
        ''' resources.
        ''' </summary>
        Public Enum D2D1_FACTORY_TYPE
            ''' <summary>
            ''' The resulting factory and derived resources may only be invoked serially.
            ''' Reference counts on resources are interlocked  however  resource and render
            ''' target state is not protected from multi-threaded access.
            ''' </summary>
            D2D1_FACTORY_TYPE_SINGLE_THREADED = 0

            ''' <summary>
            ''' The resulting factory may be invoked from multiple threads. Returned resources
            ''' use interlocked reference counting and their state is protected.
            ''' </summary>
            D2D1_FACTORY_TYPE_MULTI_THREADED = 1
            D2D1_FACTORY_TYPE_FORCE_DWORD = &HFFFFFFFF

        End Enum


        ''' <summary>
        ''' Allows additional parameters for factory creation.
        ''' </summary>
        <StructLayout(LayoutKind.Sequential)>
        Public Structure D2D1_FACTORY_OPTIONS
            ''' <summary>
            ''' Requests a certain level of debugging information from the debug layer. This
            ''' parameter is ignored if the debug layer DLL is not present.
            ''' </summary>
            Public debugLevel As D2D1_DEBUG_LEVEL
        End Structure


        ''' <summary>
        ''' The RECT structure defines a rectangle by the coordinates of its upper-left and lower-right corners.
        ''' </summary>
        <StructLayout(LayoutKind.Sequential)>
        Public Structure RECT
            Public Left As Integer
            Public Top As Integer
            Public Right As Integer
            Public Bottom As Integer
        End Structure


    End Module

#Enable Warning IDE0049

End Namespace