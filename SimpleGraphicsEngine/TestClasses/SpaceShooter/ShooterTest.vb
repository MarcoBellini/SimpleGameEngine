Imports System.Runtime.InteropServices

Public Class ShooterTest
    Inherits SimpleGameEngine

#Const SHOWBOUNDARIES = False

    Private Shared ReadOnly MAP_NAME As String = My.Application.Info.DirectoryPath + "\TestClasses\SpaceShooter\map.ini"
    Private Shared ReadOnly SPRITE_IMAGE As String = My.Application.Info.DirectoryPath + "\TestClasses\SpaceShooter\sprites.png"
    Private Shared ReadOnly EXPLOSION_WAV As String = My.Application.Info.DirectoryPath + "\TestClasses\SpaceShooter\rumble.wav"
    Private Shared ReadOnly LASER_WAV As String = My.Application.Info.DirectoryPath + "\TestClasses\SpaceShooter\laser1.wav"


    Private Shared ReadOnly STARS_NUMBER As Integer = 200
    Private Shared ReadOnly PLAYER_BULLET_RATE As Integer = 100
    Private Shared ReadOnly SPACE_SPEED As Single = 0.1F

    Private Shared ReadOnly PLAYER_RECT As New RectangleF(13, 3, 35, 35)
    Private Shared ReadOnly ENEMYEASY_RECT As New RectangleF(50, 1, 34, 38)
    Private Shared ReadOnly ENEMYMEDIUM_RECT As New RectangleF(87, 3, 43, 36)
    Private Shared ReadOnly ENEMYHARD_RECT As New RectangleF(133, 3, 35, 35)
    Private Shared ReadOnly ASTEROID_RECT As New RectangleF(178, 10, 23, 20)
    Private Shared ReadOnly LIFE_RECT As New RectangleF(213, 7, 19, 26)

    Private SpritesImage As SimpleImageResource
    Private BulletBrush As SimpleSolidColorBrush
    Private StarBrush As SimpleSolidColorBrush
    Private ParticleBrush As SimpleSolidColorBrush
    Private TextBrush As SimpleSolidColorBrush
    Private ManagedFont As Font
    Private FontObject As SimpleFontResource

    Private AudioEngine As SimpleAudioEngine
    Private ExplosionAudioResource As SimpleAudioResource
    Private ShootAudioResource As SimpleAudioResource

    Private fGameTimeLine As Single

    Private StarsList(STARS_NUMBER - 1) As PointF
    Private ObjectList As List(Of BaseObject)

    Private ParticlesList As List(Of Particle)

    Private PlayerObject As BaseObject

    Private Rand As New Random
    Private fPlayerTimer As Single


#Region "Kernel32 API"
    ''' <summary>
    ''' Retrieves a string from the specified section in an initialization file.
    ''' https://docs.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-getprivateprofilestring/
    ''' </summary>
    <DllImport("kernel32.dll", SetLastError:=True, EntryPoint:="GetPrivateProfileStringA", CharSet:=CharSet.Ansi)>
    Private Shared Function GetPrivateProfileString(ByVal lpApplicationName As String,
                                                    ByVal lpKeyName As String,
                                                    ByVal lpDefault As String,
                                                    ByVal lpReturnedString As Text.StringBuilder,
                                                    ByVal nSize As Integer,
                                                    ByVal lpFileName As String) As Integer

    End Function

    <DllImport("kernel32.dll", SetLastError:=True, EntryPoint:="GetPrivateProfileIntA")>
    Private Shared Function GetPrivateProfileInt(ByVal lpApplicationName As String,
                                                 ByVal lpKeyName As String,
                                                 ByVal lpDefault As Integer,
                                                 ByVal lpFileName As String) As Integer

    End Function



#End Region
#Region "INI File Helpers"

    Private Function ReadIniFile(ByRef Section As String,
                                 ByRef Key As String,
                                 ByRef DefaultValue As Integer) As Integer
        Dim Value As Integer

        If Not My.Computer.FileSystem.FileExists(MAP_NAME) Then
            Throw New IO.FileNotFoundException(MAP_NAME + " not found.")
        End If

        Value = GetPrivateProfileInt(Section, Key, DefaultValue, MAP_NAME)

        Return Value
    End Function

    Private Function ReadIniFile(ByRef Section As String,
                                 ByRef Key As String,
                                 ByRef DefaultValue As String) As String
        Dim Len As Integer
        Dim ReturnValue As New Text.StringBuilder(100)

        If Not My.Computer.FileSystem.FileExists(MAP_NAME) Then
            Throw New IO.FileNotFoundException(MAP_NAME + " not found.")
        End If

        Len = GetPrivateProfileString(Section, Key, DefaultValue.ToString, ReturnValue, ReturnValue.Capacity, MAP_NAME)

        If Len <> 0 Then
            Return ReturnValue.ToString
        Else
            Return DefaultValue
        End If
    End Function

#End Region

    Private Sub CreatePlayerShoot(ByVal fElapsed As Single)
        Dim BulletObject As New BaseObject(New Vector2f((PlayerObject.Position.X), PlayerObject.Position.Y),
                                           New Vector2f(0, -5 * SPACE_SPEED),
                                           4.0F,
                                           BaseObject.ObjectType.PlayerBullet,
                                           0.0F)

        BulletObject.ObjectVisible = True
        ObjectList.Add(BulletObject)
        fPlayerTimer += PLAYER_BULLET_RATE

        'My.Computer.Audio.Play(LASER_WAV)
        AudioEngine.PlaySound(ShootAudioResource)
    End Sub

    Private Sub CreateEnemyShoot(ByRef Enemy As BaseObject, ByVal fElapsed As Single)
        Dim BulletObject As BaseObject

        If Enemy.TimeToShoot(fElapsed) = True Then
            BulletObject = New BaseObject(New Vector2f((Enemy.Position.X), Enemy.Position.Y + Enemy.Radius),
                                           New Vector2f(0, 5 * SPACE_SPEED),
                                           4.0F,
                                           BaseObject.ObjectType.EnemyBullet,
                                           0.0F)

            BulletObject.ObjectVisible = True
            ObjectList.Add(BulletObject)

            ' AudioEngine.PlaySound(ShootAudioResource)
        End If


    End Sub

    Public Sub CreateExplosion(ByRef Obj As BaseObject)
        Dim Part As Particle
        Dim fAngle As Single


        For i As Integer = 0 To 360 Step 8
            fAngle = i * Math.PI / 180.0F
            Part = New Particle(Obj.Position.X, Obj.Position.Y, 2.0F, Rand.Next(200, 400))
            Part.VelX = Math.Cos(fAngle)
            Part.VelY = Math.Sin(fAngle)
            ParticlesList.Add(Part)
        Next

        'My.Computer.Audio.Play(EXPLOSION_WAV)
        AudioEngine.PlaySound(ExplosionAudioResource)
    End Sub

    Private Sub LoadMap()
        Dim nNumberOfObjects As Integer
        Dim nObjectTime As Integer
        Dim nObjectPosition As Integer
        Dim nObjectType As Integer
        Dim fScreenDiv As Single = ScreenWidth() / 4.0F

        ' Reset timeline
        fGameTimeLine = 0.0F

        ' Reset list
        ObjectList.Clear()

        ' Read number of entries
        nNumberOfObjects = ReadIniFile("MAP", "count", 0)

        For i As Integer = 0 To nNumberOfObjects - 1
            nObjectTime = ReadIniFile("ENTRY" + i.ToString, "time", 0)
            nObjectPosition = ReadIniFile("ENTRY" + i.ToString, "position", 0)
            nObjectType = ReadIniFile("ENTRY" + i.ToString, "type", 1)


            ' Create object by type
            Select Case nObjectType
                Case BaseObject.ObjectType.Asteroid
                    ObjectList.Add(New BaseObject(New Vector2f(fScreenDiv * nObjectPosition, -ASTEROID_RECT.Height),
                                                New Vector2f(0, 0),
                                                ((ASTEROID_RECT.Width + ASTEROID_RECT.Height) / 4),
                                                nObjectType, CSng(nObjectTime)))
                Case BaseObject.ObjectType.EnemyEasy
                    ObjectList.Add(New BaseObject(New Vector2f(fScreenDiv * nObjectPosition, -ENEMYEASY_RECT.Height),
                                                New Vector2f(0, 0),
                                                ((ENEMYEASY_RECT.Width + ENEMYEASY_RECT.Height) / 4),
                                                nObjectType, CSng(nObjectTime)))
                Case BaseObject.ObjectType.EnemyMedium
                    ObjectList.Add(New BaseObject(New Vector2f(fScreenDiv * nObjectPosition, -ENEMYMEDIUM_RECT.Height),
                                                New Vector2f(0, 0),
                                                ((ENEMYMEDIUM_RECT.Width + ENEMYMEDIUM_RECT.Height) / 4),
                                                nObjectType, CSng(nObjectTime)))
                Case BaseObject.ObjectType.EnemyHard
                    ObjectList.Add(New BaseObject(New Vector2f(fScreenDiv * nObjectPosition, -ENEMYHARD_RECT.Height),
                                                New Vector2f(0, 0),
                                                ((ENEMYHARD_RECT.Width + ENEMYHARD_RECT.Height) / 4),
                                                nObjectType, CSng(nObjectTime)))
                Case BaseObject.ObjectType.Life
                    ObjectList.Add(New BaseObject(New Vector2f(fScreenDiv * nObjectPosition, -LIFE_RECT.Height),
                                                New Vector2f(0, 0),
                                                ((LIFE_RECT.Width + LIFE_RECT.Height) / 4),
                                                nObjectType, CSng(nObjectTime)))

            End Select
        Next


    End Sub

    Protected Overrides Sub OnSessionCreate()

        ' Create resources
        StarBrush = New SimpleSolidColorBrush(Color.White, Target.SafeObject)
        SpritesImage = New SimpleImageResource(SPRITE_IMAGE, Target.SafeObject)
        BulletBrush = New SimpleSolidColorBrush(Color.Red, Target.SafeObject)
        ParticleBrush = New SimpleSolidColorBrush(Color.Yellow, Target.SafeObject)
        TextBrush = New SimpleSolidColorBrush(Color.White, Target.SafeObject)

        ' Create audio resources
        AudioEngine = New SimpleAudioEngine()
        ExplosionAudioResource = New SimpleAudioResource(EXPLOSION_WAV)
        ShootAudioResource = New SimpleAudioResource(LASER_WAV)

        'Create font
        ManagedFont = New Font("Arial", 12, FontStyle.Bold)
        FontObject = New SimpleFontResource(ManagedFont)

        ' Create Stars map
        For i As Integer = 0 To StarsList.Length - 1
            StarsList(i) = New PointF(Rand.Next(1, ScreenWidth()), Rand.Next(1, ScreenHeight()))
        Next

        ' Create Player Object
        PlayerObject = New BaseObject(New Vector2f(ScreenWidth() / 2, ScreenHeight() / 2),
                                      New Vector2f(0, 0),
                                      ((PLAYER_RECT.Width + PLAYER_RECT.Height) / 4),
                                      BaseObject.ObjectType.Player, 0.0F)

        PlayerObject.ObjectLife = 1000

        ' Load Game MAP and start game
        ObjectList = New List(Of BaseObject)
        LoadMap()

        ' Create Explosion Particles List
        ParticlesList = New List(Of Particle)

        MyBase.OnSessionCreate()
    End Sub

    Protected Overrides Sub OnFrameUpdate(fElapsed As Single)
        Dim nObjectToDelete, nIndex, nObjectsCount As Integer

        ' Clear screen
        Clear(Color.Black)

        ' Handle Keyboard events
        PlayerObject.Velocity.X = 0
        PlayerObject.Velocity.Y = 0

        ' Handle Player Movements
        If IsKeyPressed(Keys.Left) Then
            If (PlayerObject.Position.X > 0) Then
                PlayerObject.Velocity.X = -0.2F
            End If
        ElseIf IsKeyPressed(Keys.Right) Then
            If (PlayerObject.Position.X + PlayerObject.Radius < ScreenWidth()) Then
                PlayerObject.Velocity.X = 0.2F
            End If
        End If

        If IsKeyPressed(Keys.Up) Then
            If (PlayerObject.Position.Y > 0) Then
                PlayerObject.Velocity.Y = -3 * SPACE_SPEED
            End If
        ElseIf IsKeyPressed(Keys.Down) Then
            If (PlayerObject.Position.Y + PlayerObject.Radius < ScreenHeight()) Then
                PlayerObject.Velocity.Y = 2 * SPACE_SPEED
            End If
        End If

        If IsKeyPressed(Keys.Space) Then

            ' Limit bullet rate
            If fPlayerTimer <= 0 Then
                CreatePlayerShoot(fElapsed)
            Else
                fPlayerTimer -= fElapsed
            End If

        End If

        ' Move Player
        PlayerObject.Move(fElapsed)


        ' Update stars position
        For i As Integer = 0 To StarsList.Length - 1
            StarsList(i).Y += SPACE_SPEED * fElapsed

            If StarsList(i).Y > ScreenHeight() Then
                StarsList(i).Y = 0.0F
                StarsList(i).X = Rand.Next(1, ScreenWidth())
            End If
        Next

        ' Check Objects visibility
        For i As Integer = 0 To ObjectList.Count - 1
            If ObjectList(i).Type <> BaseObject.ObjectType.PlayerBullet And
               ObjectList(i).Type <> BaseObject.ObjectType.EnemyBullet Then

                If ObjectList(i).MakeVisible(fElapsed) And (ObjectList(i).ObjectVisible = False) Then
                    ObjectList(i).Velocity.Y = SPACE_SPEED
                    ObjectList(i).ObjectVisible = True
                End If
            End If

        Next

        ' Create Enemy Shoots
        For i As Integer = 0 To ObjectList.Count - 1
            If ObjectList(i).Type = BaseObject.ObjectType.EnemyEasy Or
               ObjectList(i).Type = BaseObject.ObjectType.EnemyMedium Or
               ObjectList(i).Type = BaseObject.ObjectType.EnemyHard Then
                If ObjectList(i).ObjectVisible = True Then
                    CreateEnemyShoot(ObjectList(i), fElapsed)
                End If

            End If
        Next

        ' Move Objects 
        For i As Integer = 0 To ObjectList.Count - 1
            ObjectList(i).Move(fElapsed)

            ' Remove only active objects
            If ObjectList(i).ObjectVisible = True Then

                If ObjectList(i).Position.Y < 0 And ObjectList(i).Velocity.Y < 0 Then
                    ObjectList(i).DeleteObject = True
                End If

                If ObjectList(i).Position.Y > ScreenHeight() And ObjectList(i).Velocity.Y > 0 Then
                    ObjectList(i).DeleteObject = True
                End If


            End If

        Next

        ' Check collision
        For i As Integer = 0 To ObjectList.Count - 1

            If PlayerObject.ThisVsCircle(ObjectList(i).Position, ObjectList(i).Radius) Then
                Select Case ObjectList(i).Type
                    Case BaseObject.ObjectType.EnemyBullet
                        PlayerObject.ObjectLife -= 10
                        ObjectList(i).DeleteObject = True
                    Case BaseObject.ObjectType.Asteroid
                        PlayerObject.ObjectLife -= 5
                        ObjectList(i).DeleteObject = True
                        CreateExplosion(ObjectList(i))
                    Case BaseObject.ObjectType.EnemyEasy
                        PlayerObject.ObjectLife -= 2
                        ObjectList(i).DeleteObject = True
                        CreateExplosion(ObjectList(i))
                    Case BaseObject.ObjectType.EnemyMedium
                        PlayerObject.ObjectLife -= 2
                        ObjectList(i).DeleteObject = True
                        CreateExplosion(ObjectList(i))
                    Case BaseObject.ObjectType.EnemyHard
                        PlayerObject.ObjectLife -= 2
                        ObjectList(i).DeleteObject = True
                        CreateExplosion(ObjectList(i))
                    Case BaseObject.ObjectType.Life
                        PlayerObject.ObjectLife += 100
                        ObjectList(i).DeleteObject = True
                End Select

                If PlayerObject.ObjectLife < 0 Then
                    ' End game!
                    MsgBox("End game!")
                    Environment.Exit(0)
                End If
            End If


        Next


        ' player enemy bullet
        For i As Integer = 0 To ObjectList.Count - 1
            For j As Integer = 0 To ObjectList.Count - 1

                If i <> j Then
                    If ObjectList(i).ThisVsCircle(ObjectList(j).Position, ObjectList(j).Radius) Then

                        If ObjectList(i).Type = BaseObject.ObjectType.PlayerBullet Then
                            Select Case ObjectList(j).Type
                                Case BaseObject.ObjectType.Asteroid
                                    ObjectList(i).DeleteObject = True
                                    ObjectList(j).ObjectLife -= 50

                                    If ObjectList(j).ObjectLife <= 0 Then
                                        ObjectList(j).DeleteObject = True
                                        CreateExplosion(ObjectList(j))
                                    End If

                                Case BaseObject.ObjectType.EnemyEasy
                                    ObjectList(i).DeleteObject = True
                                    ObjectList(j).ObjectLife -= 40

                                    If ObjectList(j).ObjectLife <= 0 Then
                                        ObjectList(j).DeleteObject = True
                                        CreateExplosion(ObjectList(j))
                                    End If
                                Case BaseObject.ObjectType.EnemyMedium
                                    ObjectList(i).DeleteObject = True
                                    ObjectList(j).ObjectLife -= 30

                                    If ObjectList(j).ObjectLife <= 0 Then
                                        ObjectList(j).DeleteObject = True
                                        CreateExplosion(ObjectList(j))
                                    End If
                                Case BaseObject.ObjectType.EnemyHard
                                    ObjectList(i).DeleteObject = True
                                    ObjectList(j).ObjectLife -= 20

                                    If ObjectList(j).ObjectLife <= 0 Then
                                        ObjectList(j).DeleteObject = True
                                        CreateExplosion(ObjectList(j))
                                    End If

                            End Select
                        End If
                    End If

                End If

            Next
        Next


        ' Count the number of object to delete
        nObjectToDelete = 0
        nIndex = 0
        nObjectsCount = ObjectList.Count

        For i As Integer = 0 To ObjectList.Count - 1

            If ObjectList(i).DeleteObject = True Then
                nObjectToDelete += 1
            End If

        Next

        ' Delete objects
        While (nObjectToDelete > 0) And (nIndex < nObjectsCount)
            If ObjectList(nIndex).DeleteObject = True Then
                ObjectList.RemoveAt(nIndex)
                nObjectToDelete -= 1
                nObjectsCount -= 1

#If DEBUG Then
                Debug.WriteLine("Deleted 1 objects at index: " + nIndex.ToString)
#End If

            Else
                nIndex += 1
            End If
        End While


        ' Move Particles
        For i As Integer = 0 To ParticlesList.Count - 1
            ParticlesList(i).Move(fElapsed)
        Next


        ' Delete died particles
        nObjectToDelete = 0
        nIndex = 0
        nObjectsCount = ParticlesList.Count

        For i As Integer = 0 To ParticlesList.Count - 1

            If ParticlesList(i).TimeToDelete(fElapsed) = True Then
                nObjectToDelete += 1
            End If

        Next

        ' Delete objects
        While (nObjectToDelete > 0) And (nIndex < nObjectsCount)
            If ParticlesList(nIndex).TimeToDelete(fElapsed) = True Then
                ParticlesList.RemoveAt(nIndex)
                nObjectToDelete -= 1
                nObjectsCount -= 1
#If DEBUG Then
                Debug.WriteLine("Deleted 1 Particle at index: " + nIndex.ToString)
#End If

            Else
                nIndex += 1
            End If
        End While



        ' + -------------- DRAW SECTION -------------- +

        ' Draw stars
        For i As Integer = 0 To StarsList.Length - 1
            FillCircle(StarsList(i), 1, StarBrush.CurrentColor.SafeObject)
        Next

        ' Draw Player life
        DrawText("Life: " + PlayerObject.ObjectLife.ToString,
                 New RectangleF(0, 0, 300, 60),
                 TextBrush.CurrentColor.SafeObject,
                 FontObject.CurrentFont.SafeObject)

        ' Draw Particles
        For i As Integer = 0 To ParticlesList.Count - 1
            FillCircle(New PointF(ParticlesList(i).X, ParticlesList(i).Y), ParticlesList(i).Radius, ParticleBrush.CurrentColor.SafeObject)
        Next

        ' Draw Player
        DrawImage(SpritesImage.CurrentImage.SafeObject,
                   PLAYER_RECT,
                   New RectangleF(PlayerObject.Position.X - PlayerObject.Radius,
                                  PlayerObject.Position.Y - PlayerObject.Radius,
                                  PLAYER_RECT.Width,
                                  PLAYER_RECT.Height)
                   )


#If SHOWBOUNDARIES Then
        DrawCircle(New PointF(PlayerObject.Position.X, PlayerObject.Position.Y), PlayerObject.Radius, BulletBrush.CurrentColor.SafeObject)
#End If


        ' Draw Objects
        For i As Integer = 0 To ObjectList.Count - 1

            ' Check drawable items
            If (ObjectList(i).VisibleStartTime <= fGameTimeLine) And
               (ObjectList(i).ObjectVisible = True) Then

#If SHOWBOUNDARIES Then
                DrawCircle(New PointF(ObjectList(i).Position.X, ObjectList(i).Position.Y), ObjectList(i).Radius, BulletBrush.CurrentColor.SafeObject)
#End If

                Select Case ObjectList(i).Type
                    Case BaseObject.ObjectType.Asteroid
                        DrawImage(SpritesImage.CurrentImage.SafeObject,
                                   ASTEROID_RECT,
                                   New RectangleF(ObjectList(i).Position.X - ObjectList(i).Radius,
                                                  ObjectList(i).Position.Y - ObjectList(i).Radius,
                                                  ASTEROID_RECT.Width,
                                                  ASTEROID_RECT.Height)
                                   )
                    Case BaseObject.ObjectType.EnemyEasy
                        DrawImage(SpritesImage.CurrentImage.SafeObject,
                                   ENEMYEASY_RECT,
                                   New RectangleF(ObjectList(i).Position.X - ObjectList(i).Radius,
                                                  ObjectList(i).Position.Y - ObjectList(i).Radius,
                                                  ENEMYEASY_RECT.Width,
                                                  ENEMYEASY_RECT.Height)
                                   )
                    Case BaseObject.ObjectType.EnemyMedium
                        DrawImage(SpritesImage.CurrentImage.SafeObject,
                                ENEMYMEDIUM_RECT,
                                New RectangleF(ObjectList(i).Position.X - ObjectList(i).Radius,
                                               ObjectList(i).Position.Y - ObjectList(i).Radius,
                                               ENEMYMEDIUM_RECT.Width,
                                               ENEMYMEDIUM_RECT.Height)
                                )
                    Case BaseObject.ObjectType.EnemyHard
                        DrawImage(SpritesImage.CurrentImage.SafeObject,
                                ENEMYHARD_RECT,
                                New RectangleF(ObjectList(i).Position.X - ObjectList(i).Radius,
                                               ObjectList(i).Position.Y - ObjectList(i).Radius,
                                               ENEMYHARD_RECT.Width,
                                               ENEMYHARD_RECT.Height)
                                )
                    Case BaseObject.ObjectType.Life
                        DrawImage(SpritesImage.CurrentImage.SafeObject,
                                LIFE_RECT,
                                New RectangleF(ObjectList(i).Position.X - ObjectList(i).Radius,
                                               ObjectList(i).Position.Y - ObjectList(i).Radius,
                                               LIFE_RECT.Width,
                                               LIFE_RECT.Height)
                                )
                    Case BaseObject.ObjectType.EnemyBullet
                        FillCircle(New PointF(ObjectList(i).Position.X, ObjectList(i).Position.Y),
                                   ObjectList(i).Radius,
                                   BulletBrush.CurrentColor.SafeObject)
                    Case BaseObject.ObjectType.PlayerBullet
                        FillCircle(New PointF(ObjectList(i).Position.X, ObjectList(i).Position.Y),
                                   ObjectList(i).Radius,
                                   BulletBrush.CurrentColor.SafeObject)
                End Select
            End If

        Next


        ' Increment game time
        fGameTimeLine += fElapsed

        MyBase.OnFrameUpdate(fElapsed)
    End Sub
End Class
