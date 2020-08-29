Imports System.Runtime.InteropServices

Namespace Direct2D

    ''' <summary>
    ''' Store HResult value
    ''' </summary>
    <StructLayout(LayoutKind.Explicit)>
    Public Structure HRESULT

        <FieldOffset(0)>
        Public value As Integer

        Public Function Succeded() As Boolean
            Return value = 0 Or value = 1
        End Function

        Public Function ErrorMessage() As String
            Return Marshal.GetExceptionForHR(value).Message
        End Function
    End Structure

End Namespace

