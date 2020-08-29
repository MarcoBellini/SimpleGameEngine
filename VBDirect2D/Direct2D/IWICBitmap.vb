Imports System.Runtime.InteropServices

Namespace Direct2D



    <ComImport(), Guid("00000121-a8f2-4877-ba0a-fd2b6645fb94"),
     InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Obsolete("This function is not implemented!")>
    Public Interface IWICBitmap
        Inherits IWICBitmapSource

        ' virtual HRESULT STDMETHODCALLTYPE Lock( 
        '    /* [unique][in] */ __RPC__in_opt const WICRect *prcLock,
        '    /* [in] */ DWORD flags,
        '    /* [out] */ __RPC__deref_out_opt IWICBitmapLock **ppILock) = 0;

        'virtual HRESULT STDMETHODCALLTYPE SetPalette( 
        '    /* [in] */ __RPC__in_opt IWICPalette *pIPalette) = 0;

        'virtual HRESULT STDMETHODCALLTYPE SetResolution( 
        '    /* [in] */ double dpiX,
        '    /* [in] */ double dpiY) = 0;

    End Interface
End Namespace