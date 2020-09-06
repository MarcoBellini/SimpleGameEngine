Public Class ShooterTest
    Inherits SimpleGameEngine

    Private SpritesImage As SimpleImageResource
    Private BulletBrush As SimpleSolidColorBrush
    Private fVelocityX, fVelocityY As Single
    Private fPositionX, fPositionY As Single



    Protected Overrides Sub OnSessionCreate()
        SpritesImage = New SimpleImageResource("shipsheetparts.png", Target.SafeObject)
        BulletBrush = New SimpleSolidColorBrush(Color.Red, Target.SafeObject)
        fVelocityX = 0
        fVelocityY = 0

        fPositionX = ScreenWidth() / 2
        fPositionY = ScreenHeight() / 2

        MyBase.OnSessionCreate()
    End Sub

    Protected Overrides Sub OnFrameUpdate(fElapsed As Single)
        Dim bShoot As Boolean = False

        Clear(Color.Black)

        fVelocityX = 0
        fVelocityY = 0

        If IsKeyPressed(Keys.Left) Then
            fVelocityX = -0.3
        ElseIf IsKeyPressed(Keys.Right) Then
            fVelocityX = 0.3
        End If

        If IsKeyPressed(Keys.Up) Then
            fVelocityY = -0.4
        ElseIf IsKeyPressed(Keys.Down) Then
            fVelocityY = 0.2
        End If

        If IsKeyPressed(Keys.Space) Then
            bShoot = True
        End If

        fPositionX += fVelocityX * fElapsed
        fPositionY += fVelocityY * fElapsed

        DrawImage(SpritesImage.CurrentImage.SafeObject,
                  New RectangleF(66.5, 310, 36.0F, 36.0F),
                  New RectangleF(fPositionX, fPositionY, 35.0F, 35.0F))


        If bShoot Then
            DrawCircle(New PointF(fPositionX + 17.8F, fPositionY - 10), 3.0F, BulletBrush.CurrentColor.SafeObject)
        End If

        MyBase.OnFrameUpdate(fElapsed)
    End Sub
End Class
