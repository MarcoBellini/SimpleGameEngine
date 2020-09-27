Public Class BaseObject

    Public Enum ObjectType
        Player = 0
        EnemyEasy
        EnemyMedium
        EnemyHard
        Asteroid
        Life
        EnemyBullet
        PlayerBullet
    End Enum

    Property Position As Vector2f
    Property Velocity As Vector2f
    Property Radius As Single
    Property Type As ObjectType
    Property VisibleStartTime As Single

    Property DeleteObject As Boolean
    Property ObjectVisible As Boolean

    Property ObjectLife As Integer

    Private CurrentTimeCounter As Single
    Private CurrentShootTimeCounter As Single

    Public Sub New(position As Vector2f, velocity As Vector2f, radius As Single, type As ObjectType, visibleStartTime As Single)
        Me.Position = position
        Me.Velocity = velocity
        Me.Radius = radius
        Me.Type = type
        Me.VisibleStartTime = visibleStartTime
        DeleteObject = False
        CurrentTimeCounter = 0.0F
        CurrentShootTimeCounter = 0.0F
        ObjectVisible = False
        ObjectLife = 100
    End Sub

    Public Sub Move(ByVal fElapsed As Single)
        Position.X += Velocity.X * fElapsed
        Position.Y += Velocity.Y * fElapsed
    End Sub

    Public Function ThisVsCircle(ByRef pos As Vector2f, ByVal rad As Single) As Boolean
        Dim DistanceSquare As Single
        Dim RadiusSquare As Single

        DistanceSquare = (Position.X - pos.X) * (Position.X - pos.X) + (Position.Y - pos.Y) * (Position.Y - pos.Y)
        RadiusSquare = (Radius + rad) * (Radius + rad)

        Return (DistanceSquare < RadiusSquare)
    End Function

    Public Function MakeVisible(ByVal fElapsed As Single) As Boolean
        CurrentTimeCounter += fElapsed

        Return (CurrentTimeCounter >= VisibleStartTime)
    End Function

    Public Function TimeToShoot(ByVal fElapsed As Single) As Boolean
        CurrentShootTimeCounter += fElapsed

        Select Case Type
            Case ObjectType.EnemyEasy
                Return CurrentShootTimeCounter Mod 15.0F = 0
            Case ObjectType.EnemyMedium
                Return CurrentShootTimeCounter Mod 10.0F = 0
            Case ObjectType.EnemyHard
                Return CurrentShootTimeCounter Mod 5.0F = 0
            Case Else
                Return False
        End Select
    End Function
End Class
