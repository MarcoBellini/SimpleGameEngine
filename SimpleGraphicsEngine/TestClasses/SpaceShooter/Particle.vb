Public Class Particle

    Private Shared ReadOnly Property PARTICLE_SPEED As Single = 0.4F

    Public Property X As Single
    Public Property Y As Single

    Public Property VelX As Single
    Public Property VelY As Single

    Public Property Radius As Single

    Public Property Lifetime As Single

    Private fCurrentLifeTime As Single

    Public Sub New(x As Single, y As Single, radius As Single, lifetime As Single)
        Me.X = x
        Me.Y = y
        Me.Radius = radius
        Me.Lifetime = lifetime
        fCurrentLifeTime = 0.0F
    End Sub

    Public Sub Move(ByVal fElapsed As Single)
        X += VelX * PARTICLE_SPEED * fElapsed
        Y += VelY * PARTICLE_SPEED * fElapsed
    End Sub

    Public Function TimeToDelete(ByVal fElapsed As Single) As Boolean
        fCurrentLifeTime += fElapsed

        Return fCurrentLifeTime >= Lifetime
    End Function
End Class
