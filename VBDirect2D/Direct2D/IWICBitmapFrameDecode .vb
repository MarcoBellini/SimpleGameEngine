Imports System.Runtime.InteropServices
Namespace Direct2D

    <ComImport(), Guid("3B16811B-6A43-4ec9-A813-3D930C13B940"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)>
    Public Interface IWICBitmapFrameDecode
        Inherits IWICBitmapSource
        ' virtual HRESULT STDMETHODCALLTYPE GetSize( 
        '    /* [out] */ __RPC__out UINT *puiWidth,
        '    /* [out] */ __RPC__out UINT *puiHeight) = 0;
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


        'virtual HRESULT STDMETHODCALLTYPE GetMetadataQueryReader( 
        '    /* [out] */ __RPC__deref_out_opt IWICMetadataQueryReader **ppIMetadataQueryReader) = 0;
        <Obsolete("Function not implemented!")>
        Function GetMetadataQueryReader() As HRESULT

        'virtual HRESULT STDMETHODCALLTYPE GetColorContexts( 
        '    /* [in] */ UINT cCount,
        '    /* [size_is][unique][out][in] */ __RPC__inout_ecount_full_opt(cCount) IWICColorContext **ppIColorContexts,
        '    /* [out] */ __RPC__out UINT *pcActualCount) = 0;
        <Obsolete("Function not implemented!")>
        Function GetColorContexts() As HRESULT

        'virtual HRESULT STDMETHODCALLTYPE GetThumbnail( 
        '    /* [out] */ __RPC__deref_out_opt IWICBitmapSource **ppIThumbnail) = 0;
        <Obsolete("Function not implemented!")>
        Function GetThumbnail() As HRESULT

    End Interface

End Namespace

