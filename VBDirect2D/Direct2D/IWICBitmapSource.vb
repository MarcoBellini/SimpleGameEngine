Imports System.Runtime.InteropServices

Namespace Direct2D

    <ComImport(), Guid("00000120-a8f2-4877-ba0a-fd2b6645fb94"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)>
    Public Interface IWICBitmapSource
        ' virtual HRESULT STDMETHODCALLTYPE GetSize( 
        '    /* [out] */ __RPC__out UINT *puiWidth,
        '    /* [out] */ __RPC__out UINT *puiHeight) = 0;
        <Obsolete("Function not implemented!")>
        Function GetSize() As HRESULT

        'virtual HRESULT STDMETHODCALLTYPE GetPixelFormat( 
        '    /* [out] */ __RPC__out WICPixelFormatGUID *pPixelFormat) = 0;
        <Obsolete("Function not implemented!")>
        Function GetPixelFormat() As HRESULT

        'virtual HRESULT STDMETHODCALLTYPE GetResolution( 
        '    /* [out] */ __RPC__out double *pDpiX,
        '    /* [out] */ __RPC__out double *pDpiY) = 0;
        <Obsolete("Function not implemented!")>
        Function GetResolution() As HRESULT

        'virtual HRESULT STDMETHODCALLTYPE CopyPalette( 
        '    /* [in] */ __RPC__in_opt IWICPalette *pIPalette) = 0;
        <Obsolete("Function not implemented!")>
        Function CopyPalette() As HRESULT

        'virtual HRESULT STDMETHODCALLTYPE CopyPixels( 
        '    /* [unique][in] */ __RPC__in_opt const WICRect *prc,
        '    /* [in] */ UINT cbStride,
        '    /* [in] */ UINT cbBufferSize,
        '    /* [size_is][out] */ __RPC__out_ecount_full(cbBufferSize) BYTE *pbBuffer) = 0;
        <Obsolete("Function not implemented!")>
        Function CopyPixels() As HRESULT
    End Interface
End Namespace