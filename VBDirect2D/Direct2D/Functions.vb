Imports System.Runtime.InteropServices
Namespace Direct2D
    Public Module Functions

        'template<class Factory>
        'COM_DECLSPEC_NOTHROW
        'HRESULT
        'D2D1CreateFactory(
        '    _In_ D2D1_FACTORY_TYPE factoryType,
        '    _Out_ Factory **factory
        '    )
        '{
        '    Return
        '        D2D1CreateFactory(
        '            factoryType,
        '            __uuidof(Factory),
        '            reinterpret_cast<void **>(factory));
        '}

        <DllImport("d2d1.dll", SetLastError:=True)>
        Public Function D2D1CreateFactory(<[In]()> ByVal factoryType As D2D1_FACTORY_TYPE,
                                          <MarshalAs(UnmanagedType.LPStruct)> ByVal iid As Guid,
                                          <[In](), MarshalAs(UnmanagedType.Struct)> ByRef pFactoryOptions As D2D1_FACTORY_OPTIONS,
                                          <Out(), MarshalAs(UnmanagedType.Interface)> ByRef Factory As ID2D1Factory) As HRESULT

        End Function

        ' EXTERN_C HRESULT DWRITE_EXPORT DWriteCreateFactory(
        '_In_ DWRITE_FACTORY_TYPE factoryType,
        '_In_ REFIID iid,
        '_COM_Outptr_ IUnknown **factory
        ');
        <DllImport("dwrite.dll", SetLastError:=True)>
        Public Function DWriteCreateFactory(<[In]()> ByVal factoryType As DWRITE_FACTORY_TYPE,
                                          <MarshalAs(UnmanagedType.LPStruct)> ByVal iid As Guid,
                                          <Out(), MarshalAs(UnmanagedType.Interface)> ByRef Factory As IDWriteFactory) As HRESULT

        End Function

        'void WINAPI
        'D2D1MakeRotateMatrix(
        '    _In_ FLOAT angle,
        '    _In_ D2D1_POINT_2F center,
        '    _Out_ D2D1_MATRIX_3X2_F *matrix
        '    );
        <DllImport("d2d1.dll", SetLastError:=True)>
        Public Sub D2D1MakeRotateMatrix(<[In]()> ByVal angle As Single,
                                        <[In](), MarshalAs(UnmanagedType.Struct)> ByVal center As D2D1_POINT_2F,
                                        <Out(), MarshalAs(UnmanagedType.Struct)> ByRef matrix As D2D1_MATRIX_3X2_F)

        End Sub

        ''' <summary>
        ''' Returns the Identity Matrix
        ''' </summary>
        Public ReadOnly Property IdentityMatrix() As D2D1_MATRIX_3X2_F
            Get
                Dim Identity As D2D1_MATRIX_3X2_F

                With Identity
                    .m11 = 1.0F
                    .m12 = 0.0F
                    .m21 = 0.0F
                    .m22 = 1.0F
                    .m31 = 0.0F
                    .m32 = 0.0F
                End With

                Return Identity
            End Get
        End Property

        Public Function RotatationMatrix(ByVal angle As Single,
                                         ByVal center As D2D1_POINT_2F) As D2D1_MATRIX_3X2_F
            Dim FinalMatrix As New D2D1_MATRIX_3X2_F

            D2D1MakeRotateMatrix(angle, center, FinalMatrix)

            Return FinalMatrix
        End Function
    End Module
End Namespace

