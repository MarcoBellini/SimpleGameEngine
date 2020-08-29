Imports System.Runtime.InteropServices

Namespace Direct2D

    '''<summary>
    ''' Root bitmap resource, linearly scaled on a draw call.
    ''' </summary>
    <ComImport(), Guid("a2296057-ea42-4099-983b-539fb6505426"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)>
    Public Interface ID2D1Bitmap
        Inherits ID2D1Image

        Overloads Sub GetFactory(<Out(), MarshalAs(UnmanagedType.Interface)> ByRef factory As ID2D1Factory)


        'STDMETHOD_(D2D1_SIZE_F, GetSize)(
        '    ) CONST PURE;
        ''' <summary>
        ''' Returns the size of the bitmap in resolution independent units.
        ''' </summary>
        Function GetSize() As <MarshalAs(UnmanagedType.Struct)> D2D1_SIZE_F


        'STDMETHOD_(D2D1_SIZE_U, GetPixelSize)(
        '    ) CONST PURE;
        ''' <summary>
        ''' Returns the size of the bitmap in resolution dependent units, (pixels).
        ''' </summary>
        Function GetPixelSize() As <MarshalAs(UnmanagedType.Struct)> D2D1_SIZE_U

        'STDMETHOD_(D2D1_PIXEL_FORMAT, GetPixelFormat)(
        '    ) CONST PURE;
        ''' <summary>
        ''' Retrieve the format of the bitmap.
        ''' </summary>
        Function GetPixelFormat() As <MarshalAs(UnmanagedType.Struct)> D2D1_PIXEL_FORMAT


        'STDMETHOD_(void, GetDpi)(
        '    _Out_ FLOAT *dpiX,
        '    _Out_ FLOAT *dpiY 
        '    ) CONST PURE;
        ''' <summary>
        ''' Return the DPI of the bitmap.
        ''' </summary>
        Sub GetDpi(ByRef dpiX As Single,
                   ByRef dpiY As Single)

        'STDMETHOD(CopyFromBitmap)(
        '    _In_opt_ Const D2D1_POINT_2U *destPoint,
        '    _In_ ID2D1Bitmap *bitmap,
        '    _In_opt_ Const D2D1_RECT_U *srcRect 
        '    ) PURE;
        Sub CopyFromBitmap(<[In](), MarshalAs(UnmanagedType.Struct)> ByRef destPoint As D2D1_POINT_2U,
                           <[In](), MarshalAs(UnmanagedType.Interface)> ByRef bitmap As ID2D1Bitmap,
                           <[In](), MarshalAs(UnmanagedType.Struct)> ByVal srcRect As D2D1_RECT_U)

        'STDMETHOD(CopyFromRenderTarget)(
        '    _In_opt_ Const D2D1_POINT_2U *destPoint,
        '    _In_ ID2D1RenderTarget *renderTarget,
        '    _In_opt_ Const D2D1_RECT_U *srcRect 
        '    ) PURE;
        Sub CopyFromRenderTarget(<[In](), MarshalAs(UnmanagedType.Struct)> ByRef destPoint As D2D1_POINT_2U,
                           <[In](), MarshalAs(UnmanagedType.Interface)> ByRef renderTarget As ID2D1RenderTarget,
                           <[In](), MarshalAs(UnmanagedType.Struct)> ByVal srcRect As D2D1_RECT_U)


        'STDMETHOD(CopyFromMemory)(
        '    _In_opt_ Const D2D1_RECT_U *dstRect,
        '    _In_ Const void *srcData,
        '    UINT32 pitch
        '    ) PURE;
        Sub CopyFromMemory(<[In](), MarshalAs(UnmanagedType.Struct)> ByRef dstRect As D2D1_RECT_U,
                           <[In]()> ByVal srcData As IntPtr,
                           ByVal pitch As UInt32)

    End Interface
End Namespace
