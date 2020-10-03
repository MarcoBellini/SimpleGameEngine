Imports VBDirect2D.Direct2D
Imports System.Runtime.InteropServices
Imports System.Threading
Imports Microsoft.Win32.SafeHandles

#Region "Game Engine"
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

    ''' <summary>
    ''' Start new Rendering Loop
    ''' </summary>
    ''' <param name="Frm">Form where Draw</param>
    ''' <param name="Width">Width of Render scene</param>
    ''' <param name="Height">Height of render scende</param>
    ''' <returns></returns>
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

    ''' <summary>
    ''' Close opened rendering loop
    ''' </summary>
    ''' <returns>True if successful</returns>
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

        ' Free
        UpdateThread = Nothing

        Return True
    End Function

    ''' <summary>
    ''' Resize rendering area
    ''' </summary>
    ''' <param name="Width">New Width</param>
    ''' <param name="Height">New Height</param>
    Public Sub Resize(ByVal Width As Integer, ByVal Height As Integer)

        ' Change render size
        NewSize.width = Width
        NewSize.height = Height
    End Sub

    ''' <summary>
    ''' Check if a key is pressed
    ''' </summary>
    ''' <param name="key">Key to check</param>
    ''' <returns>True if key is pressed otherwise false</returns>
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

    Protected Sub DrawLine(ByRef StartPoint As PointF, ByRef EndPoint As PointF, ByRef Brush As ID2D1Brush)
        If Brush IsNot Nothing Then
            If Target.SafeObject IsNot Nothing Then
                Target.SafeObject.DrawLine(Point2Unmanaged(StartPoint),
                                           Point2Unmanaged(EndPoint),
                                           Brush)
            End If
        End If
    End Sub

    Protected Sub DrawTriangle(ByRef Point0 As PointF, ByRef Point1 As PointF, ByRef Point2 As PointF, ByRef Brush As ID2D1Brush)
        If Brush IsNot Nothing Then
            If Target.SafeObject IsNot Nothing Then

                ' Sort by distance from origin (0,0) - Use Lambda
                Dim d0, d1, d2 As Single

                d0 = (Point0.X * Point0.X) + (Point0.Y * Point0.Y)
                d1 = (Point1.X * Point1.X) + (Point1.Y * Point1.Y)
                d2 = (Point2.X * Point2.X) + (Point2.Y * Point2.Y)

                Dim SwapPoints = Sub(ByRef p0 As PointF, ByRef p1 As PointF)
                                     Dim TempPoint As New PointF

                                     TempPoint.X = p0.X
                                     TempPoint.Y = p0.Y

                                     p0 = p1
                                     p1 = TempPoint
                                 End Sub


                If d1 < d0 Then

                    If d1 < d2 Then
                        SwapPoints(Point0, Point1)
#If DEBUG Then
                        Debug.WriteLine("Swap p0 <-> p1")
#End If
                    Else
                        SwapPoints(Point0, Point2)

#If DEBUG Then
                        Debug.WriteLine("Swap p0 <-> p2")
#End If
                    End If
                Else
                    If d2 < d0 Then
                        SwapPoints(Point0, Point2)

#If DEBUG Then
                        Debug.WriteLine("Swap p0 <-> p2")
#End If
                    Else
                        If d2 < d1 Then
                            SwapPoints(Point1, Point2)

#If DEBUG Then
                            Debug.WriteLine("Swap p1 <-> p2")
#End If
                        End If
                    End If
                End If


                ' Draw triangle
                Target.SafeObject.DrawLine(Point2Unmanaged(Point0),
                                           Point2Unmanaged(Point1),
                                           Brush)
                Target.SafeObject.DrawLine(Point2Unmanaged(Point1),
                                           Point2Unmanaged(Point2),
                                           Brush)
                Target.SafeObject.DrawLine(Point2Unmanaged(Point2),
                                           Point2Unmanaged(Point0),
                                           Brush)
            End If
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

    Protected Sub DrawCircle(ByRef Location As PointF, ByVal Radius As Single, ByRef Brush As ID2D1Brush)
        If Brush IsNot Nothing Then
            If Target.SafeObject IsNot Nothing Then
                Dim Ellipse As D2D1_ELLIPSE
                Dim CurrentLocation As D2D1_POINT_2F

                ' Convert to Direct2D Location
                With CurrentLocation
                    .x = Location.X
                    .y = Location.Y
                End With

                ' Fill Ellipse struct
                With Ellipse
                    .point = CurrentLocation
                    .radiusX = Radius
                    .radiusY = Radius
                End With

                ' Draw Ellipse
                Target.SafeObject.DrawEllipse(Ellipse, Brush)
            End If
        End If
    End Sub

    Protected Sub FillCircle(ByRef Location As PointF, ByVal Radius As Single, ByRef Brush As ID2D1Brush)
        If Brush IsNot Nothing Then
            If Target.SafeObject IsNot Nothing Then
                Dim Ellipse As D2D1_ELLIPSE

                ' Fill Ellipse struct
                With Ellipse
                    .point = Point2Unmanaged(Location)
                    .radiusX = Radius
                    .radiusY = Radius
                End With

                ' Draw Ellipse
                Target.SafeObject.FillEllipse(Ellipse, Brush)
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

    Protected Sub DrawImage(ByRef Image As ID2D1Bitmap,
                            ByRef SourceRect As RectangleF,
                            ByRef DestRect As RectangleF)
        If Target.SafeObject IsNot Nothing Then
            If Image IsNot Nothing Then
                Target.SafeObject.DrawBitmap(Image,
                                             Rect2Unmanaged(DestRect),
                                             1.0F,
                                             D2D1_BITMAP_INTERPOLATION_MODE.D2D1_BITMAP_INTERPOLATION_MODE_LINEAR,
                                             Rect2Unmanaged(SourceRect))
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

    Private Function Point2Unmanaged(ByRef ManagedPoint As PointF) As D2D1_POINT_2F
        ' Convert managed PointF to Direct2D Point

        Dim UnmanagedPoint As D2D1_POINT_2F

        UnmanagedPoint.x = ManagedPoint.X
        UnmanagedPoint.y = ManagedPoint.Y


        Return UnmanagedPoint
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

                    ' Reset trasforms
                    Target.SafeObject.SetTransform(IdentityMatrix)

                    ' Call overridable function
                    OnFrameUpdate(fElapsed)

                    ' End Draw
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
                Close()
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
#End Region
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
#Region "Audio Engine"

''' <summary>
''' Audio Engine, Create Object in OnSessionCreate() function
''' </summary>
Public Class SimpleAudioEngine
    Implements IDisposable

#Region "SafeWaveOutHandle"
    Public Class SafeWaveOutHandle
        Inherits SafeHandleZeroOrMinusOneIsInvalid

        Public Sub New()
            MyBase.New(True)
        End Sub

        Public Sub New(ByVal device As IntPtr)
            MyBase.New(True)
            handle = device
        End Sub

        Protected Overrides Function ReleaseHandle() As Boolean
#If DEBUG Then
            Debug.WriteLine("SafeWaveOutHandle: " & "Handle correctrly Closed")
#End If
            Return waveOutClose(handle) = 0
        End Function
    End Class
#End Region
#Region "WaveOut Native Declaration"

    <StructLayout(LayoutKind.Sequential)>
    Public Class WaveHdr
        Public lpData As IntPtr 'pointer To locked data buffer
        Public dwBufferLength As Int32 'length Of data buffer
        Public dwBytesRecorded As Int32 'used For input only
        Public dwUser As IntPtr 'For client's use
        Public dwFlags As Int32 'assorted flags (see defines)
        Public dwLoops As Int32 'Loop control counter
        Public lpNext As IntPtr ' PWaveHdr, reserved For driver
        Public reserved As Int32 'reserved For driver
    End Class

    Public Enum WaveFormats As Short
        Unknown = 0
        PCM = 1
        Adpcm = 2
        Float = 3
        alaw = 6
        mulaw = 7
    End Enum

    <StructLayoutAttribute(LayoutKind.Sequential)>
    Public Structure WaveFormat
        Public wFormatTag As Int16
        Public nChannels As Int16
        Public nSamplesPerSec As Int32
        Public nAvgBytesPerSec As Int32
        Public nBlockAlign As Int16
        Public wBitsPerSample As Int16
        Public cbSize As Int16
    End Structure

    <StructLayout(LayoutKind.Explicit)>
    Public Structure MMTIME
        <FieldOffset(0)> Public wType As TimeType
        <FieldOffset(4)> Public ms As UInteger
        <FieldOffset(4)> Public sample As UInteger
        <FieldOffset(4)> Public cb As UInteger
        <FieldOffset(4)> Public ticks As UInteger
        <FieldOffset(4)> Public smtpeHour As Byte
        <FieldOffset(5)> Public smpteMin As Byte
        <FieldOffset(6)> Public smpteSec As Byte
        <FieldOffset(7)> Public smpteFrame As Byte
        <FieldOffset(8)> Public smpteFps As Byte
        <FieldOffset(9)> Public smpteDummy As Byte
        <FieldOffset(10)> Public smptePad0 As Byte
        <FieldOffset(11)> Public smptePad1 As Byte
        <FieldOffset(4)> Public midiSongPtrPos As UInteger
    End Structure

    Public Enum TimeType As UInteger
        TIME_MS = &H1
        TIME_SAMPLES = &H2
        TIME_BYTES = &H4
        TIME_SMPTE = &H8
        TIME_MIDI = &H10
        TIME_TICKS = &H20
    End Enum

    <DllImport("winmm.dll")>
    Public Shared Function waveOutOpen(ByRef hWaveOut As IntPtr, ByVal uDeviceID As Int32, ByRef lpFormat As WaveFormat, ByVal dwCallback As WaveOutProc, ByVal dwInstance As IntPtr, ByVal dwFlags As Int32) As Int32
    End Function
    <DllImport("winmm.dll")>
    Public Shared Function waveOutReset(ByVal hWaveOut As SafeWaveOutHandle) As Int32
    End Function
    <DllImport("winmm.dll")>
    Public Shared Function waveOutRestart(ByVal hWaveOut As SafeWaveOutHandle) As Int32
    End Function
    <DllImport("winmm.dll")>
    Public Shared Function waveOutPause(ByVal hWaveOut As SafeWaveOutHandle) As Int32
    End Function
    <DllImport("winmm.dll")>
    Public Shared Function waveOutPrepareHeader(ByVal hWaveOut As SafeWaveOutHandle, ByVal lpWaveOutHdr As IntPtr, ByVal uSize As Int32) As Int32
    End Function
    <DllImport("winmm.dll")>
    Public Shared Function waveOutUnprepareHeader(ByVal hWaveOut As SafeWaveOutHandle, ByVal lpWaveOutHdr As IntPtr, ByVal uSize As Int32) As Int32
    End Function
    <DllImport("winmm.dll")>
    Public Shared Function waveOutWrite(ByVal hWaveOut As SafeWaveOutHandle, ByVal lpWaveOutHdr As IntPtr, ByVal uSize As Int32) As Int32
    End Function
    <DllImport("winmm.dll")>
    Public Shared Function waveOutClose(ByVal hWaveOut As IntPtr) As Int32
    End Function
    <DllImport("winmm.dll")>
    Public Shared Function waveOutSetVolume(ByVal hWaveOut As SafeWaveOutHandle, ByVal dwVolume As UInt32) As Int32
    End Function
    <DllImport("winmm.dll")>
    Public Shared Function waveOutGetVolume(ByVal hWaveOut As SafeWaveOutHandle, ByRef dwVolume As UInt32) As Int32
    End Function
    <DllImport("winmm.dll")>
    Public Shared Function waveOutGetNumDevs() As Int32
    End Function
    <DllImport("winmm.dll")>
    Public Shared Function waveOutGetPosition(ByVal hWaveOut As SafeWaveOutHandle, ByRef pmmt As MMTIME, ByVal cbmmt As Integer) As Int32
    End Function

    Public Delegate Sub WaveOutProc(ByVal dev As IntPtr, ByVal uMsg As Integer, ByVal dwUser As Integer, ByVal dwParam1 As IntPtr, ByVal dwParam2 As Integer)

    Public Const CALLBACK_FUNCTION As Integer = &H30000
    Public Const WAVE_FORMAT_DIRECT As Integer = &H8
    Public Const CALLBACK_NULL As Integer = &H0
    Public Const BUFFER_DONE As Integer = &H3BD

#End Region

    Private pHandle As SafeWaveOutHandle
    Private woDone As WaveOutProc = New WaveOutProc(AddressOf WaveOutDone)
    Private disposedValue As Boolean
    Private ptrDataQueue As New Queue(Of IntPtr)
    Private ptrStructureQueue As New Queue(Of IntPtr)


    Private DeletePacketThread As Thread
    Private DeleteEvent As AutoResetEvent
    Private bAllowThread As Boolean


    Public Sub New()
        Dim sWaveFormat As New WaveFormat
        Dim TempHandle As IntPtr

        ' Setup waveformat
        With sWaveFormat
            .nAvgBytesPerSec = 176400
            .nBlockAlign = 4
            .nChannels = 2
            .nSamplesPerSec = 44100
            .wBitsPerSample = 16
            .wFormatTag = WaveFormats.PCM
            .cbSize = 0
        End With

        'Check if system has audio device
        If waveOutGetNumDevs() = 0 Then
            Throw New Exception("No Audio Device Found")
        End If

        ' Create New wave format object(-1 = WAVE_MAPPER)
        waveOutOpen(TempHandle,
                    -1,
                    sWaveFormat,
                    woDone,
                    IntPtr.Zero,
                    CALLBACK_FUNCTION Or WAVE_FORMAT_DIRECT)

        ' Create new safe handle
        pHandle = New SafeWaveOutHandle(TempHandle)

        DeleteEvent = New AutoResetEvent(False)
        bAllowThread = True

        ' Start new thread
        DeletePacketThread = New Thread(AddressOf DeleteThreadProc)
        DeletePacketThread.IsBackground = True
        DeletePacketThread.Start()
    End Sub

    ' Callback of waveOutOpen(important to flush old buffer and 
    ' write the new one)
    Private Sub WaveOutDone(ByVal dev As IntPtr, ByVal uMsg As Integer, ByVal dwUser As Integer, ByVal dwParam1 As IntPtr, ByVal dwParam2 As Integer)
        If uMsg = BUFFER_DONE Then
            DeleteEvent.Set()
        End If
    End Sub

    Private Sub DeleteThreadProc()
        Dim pWaveHdrOld As IntPtr
        Dim Index As Integer

        While bAllowThread
            ' Wait to delete object
            Index = WaitHandle.WaitAny({DeleteEvent}, 25)

            If Index <> WaitHandle.WaitTimeout Then
                If ptrStructureQueue.Count > 0 Then
                    pWaveHdrOld = ptrStructureQueue.Dequeue

#If DEBUG Then
                    Debug.WriteLine("Free WaveOut Header: " & ptrStructureQueue.Count.ToString)
#End If


                    waveOutUnprepareHeader(pHandle, pWaveHdrOld, Marshal.SizeOf(GetType(WaveHdr)))

                    Marshal.FreeHGlobal(ptrDataQueue.Dequeue)
                    Marshal.FreeHGlobal(pWaveHdrOld)
                End If
            End If

        End While
    End Sub


    Public Sub PlaySound(ByRef data As SimpleAudioResource)
        Dim pBuffer, pWaveHdr As IntPtr
        Dim sWaveHdr As New WaveHdr
        Dim Buffer() As Byte
        Dim BufferLen As Integer

        ' Get buffer details
        Buffer = data.GetBuffer()
        BufferLen = data.GetBufferLen()

        ' Copy byte to unmanaged memory
        pBuffer = New IntPtr
        pBuffer = Marshal.AllocHGlobal(BufferLen)
        Marshal.Copy(Buffer, 0, pBuffer, BufferLen)

        ' Fill wave hdr struct
        sWaveHdr.lpData = pBuffer
        sWaveHdr.dwBufferLength = BufferLen
        sWaveHdr.dwUser = IntPtr.Zero
        sWaveHdr.dwFlags = 0
        sWaveHdr.dwLoops = 0

        ' Alloc unmanaged memory for struct
        pWaveHdr = New IntPtr
        pWaveHdr = Marshal.AllocHGlobal(Marshal.SizeOf(sWaveHdr))
        Marshal.StructureToPtr(sWaveHdr, pWaveHdr, True)

        ' Add pointers to queues
        ptrDataQueue.Enqueue(pBuffer)
        ptrStructureQueue.Enqueue(pWaveHdr)

        ' Prepare data for playing
        waveOutPrepareHeader(pHandle, pWaveHdr, Marshal.SizeOf(sWaveHdr))
        waveOutWrite(pHandle, pWaveHdr, Marshal.SizeOf(sWaveHdr))
    End Sub

    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then

            ' Close thread
            bAllowThread = False

            ' TODO: Don't work??
            'If DeletePacketThread.IsAlive Then
            ' DeletePacketThread.Abort()
            'End If


            ' Free waveout
            pHandle.Dispose()
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

Public Class SimpleAudioResource
    Implements IDisposable

    Private AudioBuffer() As Byte
    Private BufferLen As Integer
    Private disposedValue As Boolean

    Public Sub New(ByVal Path As String)
        Dim IOStream As IO.FileStream
        Dim Reader As IO.BinaryReader

        Dim buffer(3) As Byte
        Dim AudioFormat As Short
        Dim ChunkSize, Subchunk1Size, Subchunk2Size As Integer
        Dim nHeaderOffset As Long = 0

        Dim Samplerate, AvgBytesPerSec As Integer
        Dim BitsPerSample, Channels, BlockAlign As Short

        If Not My.Computer.FileSystem.FileExists(Path) Then
            Throw New IO.FileNotFoundException(Path)
        End If

        ' Create new instances of main classes
        IOStream = New IO.FileStream(Path, IO.FileMode.Open)
        Reader = New IO.BinaryReader(IOStream)


        ' Start reading to 0
        Reader.BaseStream.Seek(0, IO.SeekOrigin.Begin)

        ' (1) Read ChunkID
        '     -> Offset: 0 , Size: 4 byte
        Reader.Read(buffer, 0, 4)

        ' Check if contains Ascii code 0x52494646 - "R" "I" "F" "F" 
        ' NB: big-endian form
        If (buffer(0) = &H52) And (buffer(1) = &H49) And
           (buffer(2) = &H46) And (buffer(3) = &H46) Then

            ' (2) Read ChunkSize 
            '     -> Offset 4, Size: 4
            ChunkSize = Reader.ReadInt32()
            'ChunkSize= 36 + SubChunk2Size, or more precisely:
            '4 + (8 + SubChunk1Size) + (8 + SubChunk2Size)
            'This Is the size of the rest of the chunk 
            'following this number.  This Is the size of the 
            'entire File in bytes minus 8 bytes for the
            'two fields Not included in this count
            'ChunkID And ChunkSize (little endian)

            ' (3) Read Format 
            '     -> Offset 8, Size: 4
            Reader.Read(buffer, 0, 4)

            'Check if contains Ascii code 0x57415645 "W" "A" "V" "E"
            ' NB: big-endian form
            If (buffer(0) = &H57) And (buffer(1) = &H41) And
                   (buffer(2) = &H56) And (buffer(3) = &H45) Then

                ' (4) Subchunk1ID
                '     -> Offset 12, Size: 4
                Reader.Read(buffer, 0, 4)

                'Check if contains Ascii code  0x666d7420  "f""m""t"
                ' NB: big-endian form
                If (buffer(0) = &H66) And (buffer(1) = &H6D) And
                       (buffer(2) = &H74) And (buffer(3) = &H20) Then

                    ' 16 for PCM. This is the size of the
                    ' rest of the Subchunk which follows this number
                    Subchunk1Size = Reader.ReadInt32()

                    ' Check if the format is PCM 
                    If Subchunk1Size = 16 Then

                        ' PCM=1 if PCM without compression
                        AudioFormat = Reader.ReadInt16()

                        ' Check again if the format is PCM 
                        If AudioFormat = 1 Then

                            ' Read channel 16 bit
                            Channels = Reader.ReadInt16()

                            ' Read Samplerate 32 bit
                            Samplerate = Reader.ReadInt32()

                            ' Read ByteRate 32 bit
                            AvgBytesPerSec = Reader.ReadInt32()

                            ' Read block align 16 bit
                            BlockAlign = Reader.ReadInt16()

                            ' Read Bits per sample 16 bit
                            BitsPerSample = Reader.ReadInt16()

                            If (Channels <> 2) Or (Samplerate <> 44100) Or (BitsPerSample <> 16) Then
                                Throw New NotSupportedException("WaveFormat not supported")
                            End If

                            ' (5) Subchunk2ID
                            '     -> Offset 36, Size: 4
                            Reader.Read(buffer, 0, 4)

                            'Check if contains Ascii code 0x64617461   "D""A""T""A"
                            ' NB: big-endian form
                            If (buffer(0) = &H64) And (buffer(1) = &H61) And
                                   (buffer(2) = &H74) And (buffer(3) = &H61) Then

                                ' Data size 
                                Subchunk2Size = Reader.ReadInt32()

                                ' Current header size
                                ' 44 byte is the offset from the origin where
                                ' start to read PCM byte samples
                                nHeaderOffset = Reader.BaseStream.Position()

                                ' Align variables
                                BufferLen = Reader.BaseStream.Length - nHeaderOffset

                                ' Read Entire buffer
                                ReDim AudioBuffer(BufferLen - 1)
                                Reader.BaseStream.Seek(nHeaderOffset, IO.SeekOrigin.Begin)
                                AudioBuffer = Reader.ReadBytes(BufferLen)
                            Else
                                Throw New NotSupportedException("WaveFormat not supported")
                            End If
                        Else
                            Throw New NotSupportedException("WaveFormat not supported")
                        End If
                    Else
                        Throw New NotSupportedException("WaveFormat not supported")
                    End If
                Else
                    Throw New NotSupportedException("WaveFormat not supported")
                End If
            Else
                Throw New NotSupportedException("WaveFormat not supported")
            End If
        Else
            Throw New NotSupportedException("WaveFormat not supported")
        End If

        Reader.Dispose()
        IOStream.Dispose()
    End Sub

    Public Function GetBuffer() As Byte()
        Return AudioBuffer
    End Function

    Public Function GetBufferLen() As Integer
        Return BufferLen
    End Function

    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            AudioBuffer = Nothing
            BufferLen = 0

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

