Imports System.Runtime.InteropServices

Namespace Direct2D

    <ComImport(), Guid("ec5ec8a9-c395-4314-9c77-54d7a935ff70"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown)>
    Public Interface IWICImagingFactory
        'virtual HRESULT STDMETHODCALLTYPE CreateDecoderFromFilename( 
        '    /* [in] */ __RPC__in LPCWSTR wzFilename,
        '    /* [unique][in] */ __RPC__in_opt const GUID *pguidVendor,
        '    /* [in] */ DWORD dwDesiredAccess,
        '    /* [in] */ WICDecodeOptions metadataOptions,
        '    /* [retval][out] */ __RPC__deref_out_opt IWICBitmapDecoder **ppIDecoder) = 0;
        Function CreateDecoderFromFilename(<[In](), MarshalAs(UnmanagedType.LPWStr)> ByVal wzFilename As String,
                                           <[In](), MarshalAs(UnmanagedType.Struct)> ByRef pguidVendor As Guid,
                                           <[In]()> ByVal dwDesiredAccess As Integer,
                                           <[In]()> ByVal metadataOptions As WICDecodeOptions,
                                           <Out(), MarshalAs(UnmanagedType.Interface)> ByRef ppIDecoder As IWICBitmapDecoder) As HRESULT

        'virtual HRESULT STDMETHODCALLTYPE CreateDecoderFromStream( 
        '    /* [in] */ __RPC__in_opt IStream *pIStream,
        '    /* [unique][in] */ __RPC__in_opt const GUID *pguidVendor,
        '    /* [in] */ WICDecodeOptions metadataOptions,
        '    /* [retval][out] */ __RPC__deref_out_opt IWICBitmapDecoder **ppIDecoder) = 0;
        <Obsolete("Function not implemented!")>
        Function CreateDecoderFromStream() As HRESULT

        'virtual HRESULT STDMETHODCALLTYPE CreateDecoderFromFileHandle( 
        '    /* [in] */ ULONG_PTR hFile,
        '    /* [unique][in] */ __RPC__in_opt const GUID *pguidVendor,
        '    /* [in] */ WICDecodeOptions metadataOptions,
        '    /* [retval][out] */ __RPC__deref_out_opt IWICBitmapDecoder **ppIDecoder) = 0;
        <Obsolete("Function not implemented!")>
        Function CreateDecoderFromFileHandle() As HRESULT

        'virtual HRESULT STDMETHODCALLTYPE CreateComponentInfo( 
        '    /* [in] */ __RPC__in REFCLSID clsidComponent,
        '    /* [out] */ __RPC__deref_out_opt IWICComponentInfo **ppIInfo) = 0;
        <Obsolete("Function not implemented!")>
        Function CreateComponentInfo() As HRESULT

        'virtual HRESULT STDMETHODCALLTYPE CreateDecoder( 
        '    /* [in] */ __RPC__in REFGUID guidContainerFormat,
        '    /* [unique][in] */ __RPC__in_opt const GUID *pguidVendor,
        '    /* [retval][out] */ __RPC__deref_out_opt IWICBitmapDecoder **ppIDecoder) = 0;
        <Obsolete("Function not implemented!")>
        Function CreateDecoder() As HRESULT

        'virtual HRESULT STDMETHODCALLTYPE CreateEncoder( 
        '    /* [in] */ __RPC__in REFGUID guidContainerFormat,
        '    /* [unique][in] */ __RPC__in_opt const GUID *pguidVendor,
        '    /* [retval][out] */ __RPC__deref_out_opt IWICBitmapEncoder **ppIEncoder) = 0;
        <Obsolete("Function not implemented!")>
        Function CreateEncoder() As HRESULT

        'virtual HRESULT STDMETHODCALLTYPE CreatePalette( 
        '    /* [out] */ __RPC__deref_out_opt IWICPalette **ppIPalette) = 0;
        <Obsolete("Function not implemented!")>
        Function CreatePalette() As HRESULT

        'virtual HRESULT STDMETHODCALLTYPE CreateFormatConverter( 
        '    /* [out] */ __RPC__deref_out_opt IWICFormatConverter **ppIFormatConverter) = 0;
        Function CreateFormatConverter(<Out(), MarshalAs(UnmanagedType.Interface)> ByRef ppIFormatConverter As IWICFormatConverter) As HRESULT

        'virtual HRESULT STDMETHODCALLTYPE CreateBitmapScaler( 
        '    /* [out] */ __RPC__deref_out_opt IWICBitmapScaler **ppIBitmapScaler) = 0;
        <Obsolete("Function not implemented!")>
        Function CreateBitmapScaler() As HRESULT

        'virtual HRESULT STDMETHODCALLTYPE CreateBitmapClipper( 
        '    /* [out] */ __RPC__deref_out_opt IWICBitmapClipper **ppIBitmapClipper) = 0;
        <Obsolete("Function not implemented!")>
        Function CreateBitmapClipper() As HRESULT

        'virtual HRESULT STDMETHODCALLTYPE CreateBitmapFlipRotator( 
        '    /* [out] */ __RPC__deref_out_opt IWICBitmapFlipRotator **ppIBitmapFlipRotator) = 0;
        <Obsolete("Function not implemented!")>
        Function CreateBitmapFlipRotator() As HRESULT

        'virtual HRESULT STDMETHODCALLTYPE CreateStream( 
        '    /* [out] */ __RPC__deref_out_opt IWICStream **ppIWICStream) = 0;
        <Obsolete("Function not implemented!")>
        Function CreateStream() As HRESULT

        'virtual HRESULT STDMETHODCALLTYPE CreateColorContext( 
        '    /* [out] */ __RPC__deref_out_opt IWICColorContext **ppIWICColorContext) = 0;
        <Obsolete("Function not implemented!")>
        Function CreateColorContext() As HRESULT

        'virtual HRESULT STDMETHODCALLTYPE CreateColorTransformer( 
        '    /* [out] */ __RPC__deref_out_opt IWICColorTransform **ppIWICColorTransform) = 0;
        <Obsolete("Function not implemented!")>
        Function CreateColorTransformer() As HRESULT

        'virtual HRESULT STDMETHODCALLTYPE CreateBitmap( 
        '    /* [in] */ UINT uiWidth,
        '    /* [in] */ UINT uiHeight,
        '    /* [in] */ __RPC__in REFWICPixelFormatGUID pixelFormat,
        '    /* [in] */ WICBitmapCreateCacheOption option,
        '    /* [out] */ __RPC__deref_out_opt IWICBitmap **ppIBitmap) = 0;
        <Obsolete("Function not implemented!")>
        Function CreateBitmap() As HRESULT

        'virtual HRESULT STDMETHODCALLTYPE CreateBitmapFromSource( 
        '    /* [in] */ __RPC__in_opt IWICBitmapSource *pIBitmapSource,
        '    /* [in] */ WICBitmapCreateCacheOption option,
        '    /* [out] */ __RPC__deref_out_opt IWICBitmap **ppIBitmap) = 0;
        <Obsolete("Function not implemented!")>
        Function CreateBitmapFromSource() As HRESULT

        'virtual HRESULT STDMETHODCALLTYPE CreateBitmapFromSourceRect( 
        '    /* [in] */ __RPC__in_opt IWICBitmapSource *pIBitmapSource,
        '    /* [in] */ UINT x,
        '    /* [in] */ UINT y,
        '    /* [in] */ UINT width,
        '    /* [in] */ UINT height,
        '    /* [out] */ __RPC__deref_out_opt IWICBitmap **ppIBitmap) = 0;
        <Obsolete("Function not implemented!")>
        Function CreateBitmapFromSourceRect() As HRESULT

        'virtual HRESULT STDMETHODCALLTYPE CreateBitmapFromMemory( 
        '    /* [in] */ UINT uiWidth,
        '    /* [in] */ UINT uiHeight,
        '    /* [in] */ __RPC__in REFWICPixelFormatGUID pixelFormat,
        '    /* [in] */ UINT cbStride,
        '    /* [in] */ UINT cbBufferSize,
        '    /* [size_is][in] */ __RPC__in_ecount_full(cbBufferSize) BYTE *pbBuffer,
        '    /* [out] */ __RPC__deref_out_opt IWICBitmap **ppIBitmap) = 0;
        <Obsolete("Function not implemented!")>
        Function CreateBitmapFromMemory() As HRESULT

        'virtual HRESULT STDMETHODCALLTYPE CreateBitmapFromHBITMAP( 
        '    /* [in] */ __RPC__in HBITMAP hBitmap,
        '    /* [unique][in] */ __RPC__in_opt HPALETTE hPalette,
        '    /* [in] */ WICBitmapAlphaChannelOption options,
        '    /* [out] */ __RPC__deref_out_opt IWICBitmap **ppIBitmap) = 0;
        <Obsolete("Function not implemented!")>
        Function CreateBitmapFromHBITMAP() As HRESULT

        'virtual HRESULT STDMETHODCALLTYPE CreateBitmapFromHICON( 
        '    /* [in] */ __RPC__in HICON hIcon,
        '    /* [out] */ __RPC__deref_out_opt IWICBitmap **ppIBitmap) = 0;
        <Obsolete("Function not implemented!")>
        Function CreateBitmapFromHICON() As HRESULT

        'virtual HRESULT STDMETHODCALLTYPE CreateComponentEnumerator( 
        '    /* [in] */ DWORD componentTypes,
        '    /* [in] */ DWORD options,
        '    /* [out] */ __RPC__deref_out_opt IEnumUnknown **ppIEnumUnknown) = 0;
        <Obsolete("Function not implemented!")>
        Function CreateComponentEnumerator() As HRESULT

        'virtual HRESULT STDMETHODCALLTYPE CreateFastMetadataEncoderFromDecoder( 
        '    /* [in] */ __RPC__in_opt IWICBitmapDecoder *pIDecoder,
        '    /* [out] */ __RPC__deref_out_opt IWICFastMetadataEncoder **ppIFastEncoder) = 0;
        <Obsolete("Function not implemented!")>
        Function CreateFastMetadataEncoderFromDecoder() As HRESULT

        'virtual HRESULT STDMETHODCALLTYPE CreateFastMetadataEncoderFromFrameDecode( 
        '    /* [in] */ __RPC__in_opt IWICBitmapFrameDecode *pIFrameDecoder,
        '    /* [out] */ __RPC__deref_out_opt IWICFastMetadataEncoder **ppIFastEncoder) = 0;
        <Obsolete("Function not implemented!")>
        Function CreateFastMetadataEncoderFromFrameDecode() As HRESULT

        'virtual HRESULT STDMETHODCALLTYPE CreateQueryWriter( 
        '    /* [in] */ __RPC__in REFGUID guidMetadataFormat,
        '    /* [unique][in] */ __RPC__in_opt const GUID *pguidVendor,
        '    /* [out] */ __RPC__deref_out_opt IWICMetadataQueryWriter **ppIQueryWriter) = 0;
        <Obsolete("Function not implemented!")>
        Function CreateQueryWriter() As HRESULT

        'virtual HRESULT STDMETHODCALLTYPE CreateQueryWriterFromReader( 
        '    /* [in] */ __RPC__in_opt IWICMetadataQueryReader *pIQueryReader,
        '    /* [unique][in] */ __RPC__in_opt const GUID *pguidVendor,
        '    /* [out] */ __RPC__deref_out_opt IWICMetadataQueryWriter **ppIQueryWriter) = 0;
        <Obsolete("Function not implemented!")>
        Function CreateQueryWriterFromReader() As HRESULT


    End Interface
End Namespace
