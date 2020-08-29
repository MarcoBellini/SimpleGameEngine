Imports VBDirect2D.Direct2D
Imports System.Runtime.InteropServices
Imports System.Threading

''' <summary>
''' Main Engine class
''' </summary>
Public Class SimpleGameEngine
    Implements IDisposable

    ' Protected members 
    Protected Factory As New SmartPointer(Of ID2D1Factory)
    Protected Target As New SmartPointer(Of ID2D1HwndRenderTarget)

    ' Private members
    Private UpdateThread As Thread
    Private Shared bAtomicLoop As Boolean

    Private CurrentSize As New D2D1_SIZE_U
    Private NewSize As New D2D1_SIZE_U

    Private CurrentHandle As IntPtr

    Private CurrentKeysState As List(Of Keys)


#Region "Construct and Main Functions"

    Public Sub New()
        bAtomicLoop = False
        UpdateThread = Nothing
        CurrentHandle = IntPtr.Zero
        CurrentKeysState = New List(Of Keys)
    End Sub

    Public Function Start(ByVal Frm As Form, ByVal Width As Integer, ByVal Height As Integer) As Boolean

        ' Check if Handle is valid
        If Frm.Handle = IntPtr.Zero Then Return False

        ' Check if thread is not initialized
        If UpdateThread IsNot Nothing Then Return False

        ' Set Render size
        CurrentSize.width = Width
        CurrentSize.height = Height
        NewSize = CurrentSize

        ' Store Handle value
        CurrentHandle = Frm.Handle

        ' Subclass Keyboard events
        AddHandler Frm.KeyDown, AddressOf MainForm_KeyDown
        AddHandler Frm.KeyUp, AddressOf MainForm_KeyUp

        ' Permit Thread Loop
        bAtomicLoop = True

        ' Create new rendering thread
        UpdateThread = New Thread(AddressOf UpdateThreadProc)
        UpdateThread.Name = "SimpleGameEngine Thread"
        UpdateThread.IsBackground = True
        UpdateThread.Priority = ThreadPriority.Normal
        UpdateThread.Start()

        Return True
    End Function

    Public Function Close() As Boolean

        ' Check if thread is initialized
        If UpdateThread Is Nothing Then Return False

        ' End main loop 
        bAtomicLoop = False

        ' Wait gently thread termination
        UpdateThread.Join()

        ' If thread is still alive, force close
        If UpdateThread.IsAlive = True Then
            UpdateThread.Abort()
        End If

        Return True
    End Function

    Public Sub Resize(ByVal Width As Integer, ByVal Height As Integer)

        ' Change render size
        NewSize.width = Width
        NewSize.height = Height
    End Sub

    Public Function IsKeyPressed(ByVal key As Keys) As Boolean
        If CurrentKeysState IsNot Nothing Then
            Return CurrentKeysState.Contains(key)
        End If

        Return False
    End Function

#End Region

#Region "Draw Functions"

    Protected Sub Clear(ByRef ClearColor As Color)
        If Target.SafeObject IsNot Nothing Then
            Target.SafeObject.Clear(Color2Unmanaged(ClearColor))
        End If
    End Sub

    Protected Sub FillRectangle(ByRef Rect As RectangleF, ByRef Brush As ID2D1Brush)
        If Brush IsNot Nothing Then
            If Target.SafeObject IsNot Nothing Then
                Target.SafeObject.FillRectangle(Rect2Unmanaged(Rect), Brush)
            End If
        End If
    End Sub

    Protected Sub DrawRectangle(ByRef Rect As RectangleF, ByRef Brush As ID2D1Brush)
        If Brush IsNot Nothing Then
            If Target.SafeObject IsNot Nothing Then
                Target.SafeObject.DrawRectangle(Rect2Unmanaged(Rect), Brush)
            End If
        End If
    End Sub

    Protected Sub DrawText(ByVal Text As String,
                           ByRef Destination As RectangleF,
                           ByRef Brush As ID2D1Brush,
                           ByRef TextFormat As IDWriteTextFormat)

        If Text.Length > 0 Then
            If Brush IsNot Nothing Then
                If TextFormat IsNot Nothing Then
                    If Target.SafeObject IsNot Nothing Then
                        Target.SafeObject.DrawText(Text,
                                                   Text.Length,
                                                   TextFormat,
                                                   Rect2Unmanaged(Destination),
                                                   Brush)
                    End If
                End If
            End If
        End If
    End Sub

    Protected Function ScreenWidth() As Single
        Dim Size As D2D1_SIZE_F

        Size = Target.SafeObject.GetSize()

        Return Size.width
    End Function

    Protected Function ScreenHeight() As Single
        Dim Size As D2D1_SIZE_F

        Size = Target.SafeObject.GetSize()

        Return Size.height
    End Function

#End Region

#Region "Helpers"
    Private Function Rect2Unmanaged(ByRef Rect As RectangleF) As D2D1_RECT_F
        ' Convert managed RectangleF to Direct2D Rectangle

        Dim UnmanagedRect As D2D1_RECT_F

        UnmanagedRect.left = Rect.Left
        UnmanagedRect.top = Rect.Top
        UnmanagedRect.right = Rect.Right
        UnmanagedRect.bottom = Rect.Bottom

        Return UnmanagedRect
    End Function

    Private Function Color2Unmanaged(ByRef ColorToConvert As Color) As D2D1_COLOR_F
        ' Convert managed Color to Direct2D Color

        Dim UnmanagedColor As D2D1_COLOR_F

        UnmanagedColor.r = ColorToConvert.R / 255.0F
        UnmanagedColor.g = ColorToConvert.G / 255.0F
        UnmanagedColor.b = ColorToConvert.B / 255.0F
        UnmanagedColor.a = ColorToConvert.A / 255.0F

        Return UnmanagedColor
    End Function
#End Region

#Region "Render Thread"

    Private Sub UpdateThreadProc()
        Dim Hr As HRESULT
        Dim PixelFormat As New D2D1_PIXEL_FORMAT
        Dim TargetProperies As New D2D1_RENDER_TARGET_PROPERTIES
        Dim HwndTargetProperies As New D2D1_HWND_RENDER_TARGET_PROPERTIES
        Dim nTime1, nTime2 As Integer
        Dim fElapsed As Single

        ' Create new Factory
        Hr =
        D2D1CreateFactory(D2D1_FACTORY_TYPE.D2D1_FACTORY_TYPE_SINGLE_THREADED,
                          ID2D1Factory_UUID,
                          Nothing,
                          Factory.SafeObject)

        ' Create new Render Target
        If Hr.Succeded Then

            ' Set new pixel format
            With PixelFormat
                .AlphaMode = D2D1_ALPHA_MODE.D2D1_ALPHA_MODE_UNKNOWN
                .Format = DXGI_FORMAT.DXGI_FORMAT_UNKNOWN
            End With

            ' Set Render target properties
            With TargetProperies
                .dpiX = 0
                .dpiY = 0
                .minLevel = D2D1_FEATURE_LEVEL.D2D1_FEATURE_LEVEL_DEFAULT
                .usage = D2D1_RENDER_TARGET_USAGE.D2D1_RENDER_TARGET_USAGE_NONE
                .type = D2D1_RENDER_TARGET_TYPE.D2D1_RENDER_TARGET_TYPE_DEFAULT
                .pixelFormat = PixelFormat
            End With

            ' Set Hwnd Render target properties
            With HwndTargetProperies
                .hwnd = CurrentHandle
                .pixelSize = NewSize
                .presentOptions = D2D1_PRESENT_OPTIONS.D2D1_PRESENT_OPTIONS_NONE
            End With

            ' Create New HWND Target
            Hr =
                Factory.SafeObject.CreateHwndRenderTarget(TargetProperies,
                                                          HwndTargetProperies,
                                                          Target.SafeObject)

            ' Create main render loop
            If Hr.Succeded Then

                ' Notify succesfull creation
                OnSessionCreate()

                nTime1 = Environment.TickCount
                nTime2 = Environment.TickCount

                While bAtomicLoop

                    ' Check if need to resize Render Target
                    If (NewSize.height <> CurrentSize.height) Or
                        (NewSize.width <> CurrentSize.width) Then
                        Target.SafeObject.Resize(NewSize)

                        ' Store new value
                        CurrentSize = NewSize
                    End If

                    ' Calculate elapsed time
                    nTime2 = Environment.TickCount
                    fElapsed = CSng(nTime2 - nTime1)
                    nTime1 = nTime2


                    ' Render block
                    Target.SafeObject.BeginDraw()
                    OnFrameUpdate(fElapsed)
                    Target.SafeObject.EndDraw()


                End While

                ' Notify successful delete
                OnSessionDelete()
            End If
        End If

    End Sub

#End Region

#Region "Form Handler events"
    Private Sub MainForm_KeyDown(sender As Object, e As KeyEventArgs)
        If CurrentKeysState IsNot Nothing Then
            If Not CurrentKeysState.Contains(e.KeyCode) Then
                CurrentKeysState.Add(e.KeyCode)
            End If
        End If

    End Sub

    Private Sub MainForm_KeyUp(sender As Object, e As KeyEventArgs)
        If CurrentKeysState IsNot Nothing Then
            If CurrentKeysState.Contains(e.KeyCode) Then
                CurrentKeysState.Remove(e.KeyCode)
            End If
        End If
    End Sub
#End Region

#Region "Overridable Subs"
    Protected Overridable Sub OnSessionCreate()

    End Sub

    Protected Overridable Sub OnSessionDelete()

    End Sub

    Protected Overridable Sub OnFrameUpdate(ByVal fElapsed As Single)

    End Sub
#End Region

#Region "Disposable"
    Private disposedValue As Boolean

    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: eliminare lo stato gestito (oggetti gestiti)
            End If

            ' TODO: liberare risorse non gestite (oggetti non gestiti) ed eseguire l'override del finalizzatore
            ' TODO: impostare campi di grandi dimensioni su Null
            disposedValue = True
        End If
    End Sub

    ' ' TODO: eseguire l'override del finalizzatore solo se 'Dispose(disposing As Boolean)' contiene codice per liberare risorse non gestite
    ' Protected Overrides Sub Finalize()
    '     ' Non modificare questo codice. Inserire il codice di pulizia nel metodo 'Dispose(disposing As Boolean)'
    '     Dispose(disposing:=False)
    '     MyBase.Finalize()
    ' End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        ' Non modificare questo codice. Inserire il codice di pulizia nel metodo 'Dispose(disposing As Boolean)'
        Dispose(disposing:=True)
        GC.SuppressFinalize(Me)
    End Sub

#End Region

#Region "Solid Color Brush Class"

    Protected Class SimpleSolidColorBrush

        ''' <summary>
        ''' Current memory allocated Brush for Target Drawing Functions
        ''' <code>Use: CurrentColor.SafeObject</code>
        ''' </summary>
        Public CurrentColor As New SmartPointer(Of ID2D1SolidColorBrush)
        Private UnmanagedColor As New D2D1_COLOR_F
        Private UnmanagedBrushProperty As New D2D1_BRUSH_PROPERTIES

        ''' <summary>
        ''' Create new Brush resource
        ''' </summary>
        ''' <param name="NewSolidColor">Color to create</param>
        ''' <param name="Target">Current active render Target</param>
        Public Sub New(ByVal NewSolidColor As Color, ByRef Target As ID2D1HwndRenderTarget)
            Dim Hr As HRESULT

            ' Convert managed color to unmanaged
            UnmanagedColor.r = NewSolidColor.R / 255.0F
            UnmanagedColor.g = NewSolidColor.G / 255.0F
            UnmanagedColor.b = NewSolidColor.B / 255.0F
            UnmanagedColor.a = NewSolidColor.A / 255.0F

            ' Fill Brush property structure
            UnmanagedBrushProperty.opacity = 1.0F
            UnmanagedBrushProperty.transform = IdentityMatrix()

            ' Create Direct2D Brush
            Hr =
            Target.CreateSolidColorBrush(UnmanagedColor,
                                     UnmanagedBrushProperty,
                                     CurrentColor.SafeObject)

            ' Notify if error
            If Not Hr.Succeded Then
                Throw New Exception("Cannot create new SimpleSolidColorBrush: " & Hr.ErrorMessage)
            End If

        End Sub

    End Class

#End Region

#Region "Bitmap Image Resource"
    Protected Class SimpleImageResource

        Private pIWICFactory As New SmartPointer(Of IWICImagingFactory)
        Private pDecoder As New SmartPointer(Of IWICBitmapDecoder)
        Private pSource As New SmartPointer(Of IWICBitmapSource)
        Private pConverter As New SmartPointer(Of IWICFormatConverter)

        ''' <summary>
        ''' Memory allocated resource to use in Bitmap brush or DrawBitmap function
        ''' <code>Use: CurrentColor.SafeObject</code>
        ''' </summary>
        Public CurrentImage As New SmartPointer(Of ID2D1Bitmap)

        ''' <summary>
        ''' Create new Image resource
        ''' </summary>
        ''' <param name="Path">Image path</param>
        ''' <param name="Target">Current ref of active Render target</param>
        Public Sub New(ByVal Path As String, ByRef Target As ID2D1HwndRenderTarget)
            Dim tp As Type
            Dim hr As HRESULT

            ' Check if file exist
            If My.Computer.FileSystem.FileExists(Path) = False Then
                Throw New IO.FileNotFoundException
            End If

            ' Get type from CLSID
            tp = Type.GetTypeFromCLSID(CLSID_WICImagingFactory)

            ' Create new COM instance of TP
            pIWICFactory.SafeObject = CType(Activator.CreateInstance(tp), IWICImagingFactory)


            ' Create new decoder for "Path" file
            hr = pIWICFactory.SafeObject.CreateDecoderFromFilename(Path,
                                                        Nothing,
                                                        GENERIC_READ,
                                                        WICDecodeOptions.WICDecodeMetadataCacheOnLoad,
                                                        pDecoder.SafeObject)
            ' Check if successful
            If Not hr.Succeded Then Throw New Exception(hr.ErrorMessage)

            ' Get frame decoder
            hr = pDecoder.SafeObject.GetFrame(0, pSource.SafeObject)

            ' Check if successful
            If Not hr.Succeded Then Throw New Exception(hr.ErrorMessage)

            ' Create Format converter
            hr = pIWICFactory.SafeObject.CreateFormatConverter(pConverter.SafeObject)

            ' Check if successful
            If Not hr.Succeded Then Throw New Exception(hr.ErrorMessage)


            ' Convert to Direct2D supported format
            hr = pConverter.SafeObject.Initialize(pSource.SafeObject,
                                       WICPixelFormat32bppPBGRA_GUID,
                                       WICBitmapDitherType.WICBitmapDitherTypeNone,
                                       Nothing,
                                       0.0#,
                                       WICBitmapPaletteType.WICBitmapPaletteTypeMedianCut)

            ' Check if successful
            If Not hr.Succeded Then Throw New Exception(hr.ErrorMessage)


            ' Create new Image object resource
            hr = Target.CreateBitmapFromWicBitmap(pConverter.SafeObject,
                                                             Nothing,
                                                             CurrentImage.SafeObject)

            ' Check if successful
            If Not hr.Succeded Then Throw New Exception(hr.ErrorMessage)

        End Sub

    End Class
#End Region

#Region "Font Resource"
    Protected Class SimpleFontResource

        Private IDWriteFactory As New SmartPointer(Of IDWriteFactory)

        ''' <summary>
        ''' Memory allocated resource to use Font in DrawText function
        ''' <code>Use: CurrentColor.SafeObject</code>
        ''' </summary>
        Public CurrentFont As New SmartPointer(Of IDWriteTextFormat)


        Public Sub New(ByVal FontName As Font)
            Dim hr As HRESULT

            If FontName Is Nothing Then Throw New Exception("Font is nothing, create new instance of font")

            ' Create new DirectWrite Factory
            hr = DWriteCreateFactory(DWRITE_FACTORY_TYPE.DWRITE_FACTORY_TYPE_SHARED,
                                     IDWriteFactory_UUID,
                                     IDWriteFactory.SafeObject)

            ' Check if successful
            If Not hr.Succeded Then Throw New Exception(hr.ErrorMessage)

            ' Create new Text Format
            hr = IDWriteFactory.SafeObject.CreateTextFormat(FontName.Name,
                                                            IntPtr.Zero,
                                                            IIf(FontName.Bold, DWRITE_FONT_WEIGHT.DWRITE_FONT_WEIGHT_BOLD, DWRITE_FONT_WEIGHT.DWRITE_FONT_WEIGHT_NORMAL),
                                                            IIf(FontName.Italic, DWRITE_FONT_STYLE.DWRITE_FONT_STYLE_ITALIC, DWRITE_FONT_STYLE.DWRITE_FONT_STYLE_NORMAL),
                                                            DWRITE_FONT_STRETCH.DWRITE_FONT_STRETCH_NORMAL,
                                                            FontName.Size,
                                                            String.Empty,
                                                            CurrentFont.SafeObject)

            ' Check if successful
            If Not hr.Succeded Then Throw New Exception(hr.ErrorMessage)
        End Sub

    End Class
#End Region
End Class

#Region "SmartPointer Emulator Class"
Public Class SmartPointer(Of T)
    Implements IDisposable


    Private disposedValue As Boolean = False

    ''' <summary>
    ''' Safe Reference of Current Object
    ''' </summary>
    Public SafeObject As T = Nothing

    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then


            If SafeObject IsNot Nothing Then

                Try

                    ' Release only COM objects
                    If Marshal.IsComObject(SafeObject) = True Then
                        Marshal.ReleaseComObject(SafeObject)

#If DEBUG Then
                        Debug.WriteLine("COM Object successful released!")
#End If

                    End If

                    ' Set object to nothing
                    SafeObject = Nothing

                Catch ex As Exception
#If DEBUG Then
                    Debug.WriteLine("Fail to release COM Object: " & ex.Message)
#End If
                End Try

            End If


            disposedValue = True
        End If
    End Sub

    Protected Overrides Sub Finalize()
        Dispose(disposing:=False)
        MyBase.Finalize()
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(disposing:=True)
        GC.SuppressFinalize(Me)
    End Sub
End Class
#End Region

