# SimpleGameEngine 🚀
First Draft version of Direct2D porting to Visual Basic .NET and First Try to create a Simple Game Engine with Snake test game. It is very early release.

### Use GPU Accelleration
Thanks to Direct2D instead of GDI, it uses GPU power to render each frame. It uses a multi-thread approach for rendering.

## How to use
1) Include VBDirect2D and SimpleGameEngine class in your project.
2) Create new class and inherit SimpleGameEngine class
3) Override OnSessionCreate(), OnSessionDelete() and OnFrameUpdate(ByVal fElapsed As Single) subs

```
Public Class TestClass
  Inherits SimpleGameEngine
  
   Protected Overrides Sub OnSessionCreate()
        ' Create resources
        MyBase.OnSessionCreate()
    End Sub

    Protected Overrides Sub OnFrameUpdate(fElapsed As Single)
        ' Clear screen
        Clear(Color.MidnightBlue)

        MyBase.OnFrameUpdate(fElapsed)
    End Sub
    
End Class

```

### Example: Snake 2D
