Imports System.Runtime.InteropServices

Namespace Direct2D
    <ComImport(), Guid("00000120-a8f2-4877-ba0a-fd2b6645fb94"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)>
    Public Interface IWICFormatConverter
        Inherits IWICBitmapSource
        <Obsolete("Function not implemented!")>
        Overloads Function GetSize() As HRESULT

        'virtual HRESULT STDMETHODCALLTYPE GetPixelFormat( 
        '    /* [out] */ __RPC__out WICPixelFormatGUID *pPixelFormat) = 0;
        <Obsolete("Function not implemented!")>
        Overloads Function GetPixelFormat() As HRESULT

        'virtual HRESULT STDMETHODCALLTYPE GetResolution( 
        '    /* [out] */ __RPC__out double *pDpiX,
        '    /* [out] */ __RPC__out double *pDpiY) = 0;
        <Obsolete("Function not implemented!")>
        Overloads Function GetResolution() As HRESULT

        'virtual HRESULT STDMETHODCALLTYPE CopyPalette( 
        '    /* [in] */ __RPC__in_opt IWICPalette *pIPalette) = 0;
        <Obsolete("Function not implemented!")>
        Overloads Function CopyPalette() As HRESULT

        'virtual HRESULT STDMETHODCALLTYPE CopyPixels( 
        '    /* [unique][in] */ __RPC__in_opt const WICRect *prc,
        '    /* [in] */ UINT cbStride,
        '    /* [in] */ UINT cbBufferSize,
        '    /* [size_is][out] */ __RPC__out_ecount_full(cbBufferSize) BYTE *pbBuffer) = 0;
        <Obsolete("Function not implemented!")>
        Overloads Function CopyPixels() As HRESULT

        ' virtual HRESULT STDMETHODCALLTYPE Initialize( 
        '    /* [in] */ __RPC__in_opt IWICBitmapSource *pISource,
        '    /* [in] */ __RPC__in REFWICPixelFormatGUID dstFormat,
        '    /* [in] */ WICBitmapDitherType dither,
        '    /* [unique][in] */ __RPC__in_opt IWICPalette *pIPalette,
        '    /* [in] */ double alphaThresholdPercent,
        '    /* [in] */ WICBitmapPaletteType paletteTranslate) = 0;
        Function Initialize(<[In](), MarshalAs(UnmanagedType.Interface)> ByVal pISource As IWICBitmapSource,
                            <[In](), MarshalAs(UnmanagedType.Struct)> ByRef dstFormat As Guid,
                            ByVal dither As WICBitmapDitherType,
                            <[In]()> ByVal pIPalette As IntPtr, 'IWICPalette not implemented!!
                            ByVal alphaThresholdPercent As Double,
                            ByVal paletteTranslate As WICBitmapPaletteType) As HRESULT

        'virtual HRESULT STDMETHODCALLTYPE CanConvert( 
        '    /* [in] */ __RPC__in REFWICPixelFormatGUID srcPixelFormat,
        '    /* [in] */ __RPC__in REFWICPixelFormatGUID dstPixelFormat,
        '    /* [out] */ __RPC__out BOOL *pfCanConvert) = 0;
        <Obsolete("Function not implemented!")>
        Function CanConvert() As HRESULT


    End Interface
End Namespace

