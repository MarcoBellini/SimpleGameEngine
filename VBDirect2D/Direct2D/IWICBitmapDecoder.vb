Imports System.Runtime.InteropServices

Namespace Direct2D

    <ComImport(), Guid("9EDDE9E7-8DEE-47ea-99DF-E6FAF2ED44BF"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)>
    Public Interface IWICBitmapDecoder
        ' virtual HRESULT STDMETHODCALLTYPE QueryCapability( 
        '    /* [in] */ __RPC__in_opt IStream *pIStream,
        '    /* [out] */ __RPC__out DWORD *pdwCapability) = 0;
        <Obsolete("Function not implemented!")>
        Function QueryCapability() As HRESULT

        'virtual HRESULT STDMETHODCALLTYPE Initialize( 
        '    /* [in] */ __RPC__in_opt IStream *pIStream,
        '    /* [in] */ WICDecodeOptions cacheOptions) = 0;
        <Obsolete("Function not implemented!")>
        Function Initialize() As HRESULT

        'virtual HRESULT STDMETHODCALLTYPE GetContainerFormat( 
        '    /* [out] */ __RPC__out GUID *pguidContainerFormat) = 0;
        <Obsolete("Function not implemented!")>
        Function GetContainerFormat() As HRESULT

        'virtual HRESULT STDMETHODCALLTYPE GetDecoderInfo( 
        '    /* [out] */ __RPC__deref_out_opt IWICBitmapDecoderInfo **ppIDecoderInfo) = 0;
        <Obsolete("Function not implemented!")>
        Function GetDecoderInfo() As HRESULT

        'virtual HRESULT STDMETHODCALLTYPE CopyPalette( 
        '    /* [in] */ __RPC__in_opt IWICPalette *pIPalette) = 0;
        <Obsolete("Function not implemented!")>
        Function CopyPalette() As HRESULT

        'virtual HRESULT STDMETHODCALLTYPE GetMetadataQueryReader( 
        '    /* [out] */ __RPC__deref_out_opt IWICMetadataQueryReader **ppIMetadataQueryReader) = 0;
        <Obsolete("Function not implemented!")>
        Function GetMetadataQueryReader() As HRESULT

        'virtual HRESULT STDMETHODCALLTYPE GetPreview( 
        '    /* [out] */ __RPC__deref_out_opt IWICBitmapSource **ppIBitmapSource) = 0;
        <Obsolete("Function not implemented!")>
        Function GetPreview() As HRESULT

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

        'virtual HRESULT STDMETHODCALLTYPE GetFrameCount( 
        '    /* [out] */ __RPC__out UINT *pCount) = 0;
        <Obsolete("Function not implemented!")>
        Function GetFrameCount() As HRESULT

        'virtual HRESULT STDMETHODCALLTYPE GetFrame( 
        '    /* [in] */ UINT index,
        '    /* [out] */ __RPC__deref_out_opt IWICBitmapFrameDecode **ppIBitmapFrame) = 0;
        Function GetFrame(<[In]()> ByVal index As UInteger,
                          <Out(), MarshalAs(UnmanagedType.Interface)> ByRef ppIBitmapFrame As IWICBitmapFrameDecode) As HRESULT
    End Interface
End Namespace
