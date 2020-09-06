Public Class SnakeGameTest
    Inherits SimpleGameEngine

    ' World Size and Block size (40*10) = Form of 400x400 pixels size
    Private Const WORLD_HEIGHT As Integer = 40
    Private Const WORLD_WIDTH As Integer = 40
    Private Const BLOCK_SIZE As Integer = 10

    ' Snake Velocity(less time=faster ; more time=slower)
    Private Const REFRESH_INTERVAL_MS As Single = 50.0F

    ''' <summary>
    ''' Handle Snake Movments
    ''' </summary>
    Private Enum SnakeDirection
        Up
        Down
        Left
        Right
        None
    End Enum

    ''' <summary>
    ''' Used to store and Edit Snake Locations in the Queue
    ''' </summary>
    Private Class CustomPoint
        Public X As Integer
        Public Y As Integer

        Public Sub New(ByVal xt As Integer, ByVal yt As Integer)
            X = xt
            Y = yt
        End Sub
    End Class

    ' Program Vars
    Private SnakeColorBrush As SimpleSolidColorBrush
    Private FoodColorBrush As SimpleSolidColorBrush

    Private SnakeBlockQueue As Queue(Of CustomPoint)

    Private nFoodPositionIndex As CustomPoint
    Private nOldFoodPositionIndex As CustomPoint
    Private bEnqueueFood As Boolean
    Private bLastBlockReachedFood As Boolean
    Private nScore As Integer

    Private CurrentSnakeDirection As SnakeDirection
    Private NextSnakeDirection As SnakeDirection

    Private fCurrentTimeElapsedMove As Single
    Private fCurrentTimeElapsedDirection As Single

    Private ManagedFont As Font
    Private FontObject As SimpleFontResource
    Private ScoreColorBrush As SimpleSolidColorBrush

    Private Sub StartGame()
        CurrentSnakeDirection = SnakeDirection.Right
        NextSnakeDirection = SnakeDirection.None

        ' Reset positions and score
        nScore = 0
        nFoodPositionIndex = New CustomPoint(0, 0)
        nOldFoodPositionIndex = New CustomPoint(0, 0)
        fCurrentTimeElapsedMove = 0.0F
        fCurrentTimeElapsedDirection = 0.0F
        bEnqueueFood = False
        bLastBlockReachedFood = False


        ' Reset Snake queue
        SnakeBlockQueue.Clear()
        SnakeBlockQueue.Enqueue(New CustomPoint(20, 20))
        SnakeBlockQueue.Enqueue(New CustomPoint(19, 20))
        SnakeBlockQueue.Enqueue(New CustomPoint(18, 20))

        ' Create food position
        ChangeFoodPosition()
    End Sub

    Private Sub MoveSnake(ByVal direction As SnakeDirection, ByVal fElapsed As Single)
        Dim ListOfBlocks As New List(Of CustomPoint)

        ' Increment Time Counter
        fCurrentTimeElapsedMove += fElapsed

        ' Move snake every REFRESH_INTERVAL_MS ms
        If fCurrentTimeElapsedMove >= REFRESH_INTERVAL_MS Then

            ' Reset timer
            fCurrentTimeElapsedMove = 0.0F

            ' Store old points
            For i As Integer = 0 To SnakeBlockQueue.Count - 1
                ListOfBlocks.Add(New CustomPoint(SnakeBlockQueue(i).X, SnakeBlockQueue(i).Y))
            Next

            ' Move head block
            Select Case direction
                Case SnakeDirection.Up
                    SnakeBlockQueue(0).Y -= 1
                Case SnakeDirection.Down
                    SnakeBlockQueue(0).Y += 1
                Case SnakeDirection.Left
                    SnakeBlockQueue(0).X -= 1
                Case SnakeDirection.Right
                    SnakeBlockQueue(0).X += 1
            End Select

            ' Check World Boundaries
            If SnakeBlockQueue(0).Y < 0 Then
                SnakeBlockQueue(0).Y = WORLD_HEIGHT - 1
            End If

            If SnakeBlockQueue(0).Y > WORLD_HEIGHT - 1 Then
                SnakeBlockQueue(0).Y = 0
            End If

            If SnakeBlockQueue(0).X < 0 Then
                SnakeBlockQueue(0).X = WORLD_WIDTH - 1
            End If

            If SnakeBlockQueue(0).X > WORLD_WIDTH - 1 Then
                SnakeBlockQueue(0).X = 0
            End If


            ' Change direction of body blocks
            If direction <> SnakeDirection.None Then

                ' Move all body blocks to follow head
                For i As Integer = 1 To SnakeBlockQueue.Count - 1
                    SnakeBlockQueue(i).X = ListOfBlocks(i - 1).X
                    SnakeBlockQueue(i).Y = ListOfBlocks(i - 1).Y
                Next

                ' If last block reached food position enqueue food
                If bLastBlockReachedFood = True Then
                    bLastBlockReachedFood = False
                    SnakeBlockQueue.Enqueue(New CustomPoint(nOldFoodPositionIndex.X, nOldFoodPositionIndex.Y))
                End If

                ' Test food position with last snake body block position
                If bEnqueueFood = True Then
                    If (SnakeBlockQueue.Last.X = nOldFoodPositionIndex.X) And
                       (SnakeBlockQueue.Last.Y = nOldFoodPositionIndex.Y) Then
                        bLastBlockReachedFood = True
                        bEnqueueFood = False
                    End If
                End If

                ' Free resources
                ListOfBlocks.Clear()
                ListOfBlocks = Nothing
            End If

        End If
    End Sub

    Public Function SnakeHasCollided() As Boolean
        Dim SnakeHeadPosition As CustomPoint
        Dim bCollided As Boolean = False

        ' Store snake head position
        SnakeHeadPosition = SnakeBlockQueue(0)

        ' Test head position with snake body positions
        For i As Integer = 1 To SnakeBlockQueue.Count - 1
            If (SnakeHeadPosition.X = SnakeBlockQueue(i).X) And
               (SnakeHeadPosition.Y = SnakeBlockQueue(i).Y) Then
                bCollided = True
            End If
        Next

        Return bCollided
    End Function

    Private Sub ChangeSnakePosition(ByVal direction As SnakeDirection)

        ' Change direction only if there isn't any pending change
        If NextSnakeDirection = SnakeDirection.None Then

            ' Right, Left -> Up, or Down
            If (CurrentSnakeDirection = SnakeDirection.Left) Or
                (CurrentSnakeDirection = SnakeDirection.Right) Then
                If (direction = SnakeDirection.Up) Or
                   (direction = SnakeDirection.Down) Then
                    NextSnakeDirection = direction
                End If
            End If

            ' Up , Down -> Left or Right
            If (CurrentSnakeDirection = SnakeDirection.Up) Or
                (CurrentSnakeDirection = SnakeDirection.Down) Then
                If (direction = SnakeDirection.Left) Or
                   (direction = SnakeDirection.Right) Then
                    NextSnakeDirection = direction
                End If
            End If

        End If
    End Sub

    Public Sub ChangeFoodPosition()
        Dim Rand As New Random
        Dim RandX, RandY As Integer
        Dim bCorrect As Boolean = False

        Do
            For i As Integer = 0 To SnakeBlockQueue.Count - 1

                ' Generate new random numbers
                bCorrect = True
                RandX = Rand.Next(0, WORLD_WIDTH)
                RandY = Rand.Next(0, WORLD_HEIGHT)

                ' Test if positions are corrects
                If (RandX = SnakeBlockQueue(i).X) And
                   (RandY = SnakeBlockQueue(i).Y) Then
                    bCorrect = False
                    Exit For
                End If
            Next

        Loop While bCorrect = False

        ' Store old values
        nOldFoodPositionIndex.X = nFoodPositionIndex.X
        nOldFoodPositionIndex.Y = nFoodPositionIndex.Y

        ' Store new values
        nFoodPositionIndex.X = RandX
        nFoodPositionIndex.Y = RandY
    End Sub

    Public Function CheckSnakeFoodCollision() As Boolean
        Dim bCollided As Boolean = False

        ' Test head position with food position
        If (nFoodPositionIndex.X = SnakeBlockQueue(0).X) And
           (nFoodPositionIndex.Y = SnakeBlockQueue(0).Y) Then
            bCollided = True
        End If

        Return bCollided
    End Function


    Protected Overrides Sub OnSessionCreate()

        ' Create resources
        SnakeBlockQueue = New Queue(Of CustomPoint)
        SnakeColorBrush = New SimpleSolidColorBrush(Color.Cyan, Target.SafeObject)
        FoodColorBrush = New SimpleSolidColorBrush(Color.Yellow, Target.SafeObject)
        ScoreColorBrush = New SimpleSolidColorBrush(Color.White, Target.SafeObject)

        'Create font
        ManagedFont = New Font("Arial", 12, FontStyle.Bold)
        FontObject = New SimpleFontResource(ManagedFont)

        ' Start
        StartGame()

        MyBase.OnSessionCreate()
    End Sub

    Protected Overrides Sub OnFrameUpdate(fElapsed As Single)
        Dim SnakeBlockRect, FoodBlockRect As RectangleF

        ' Handle keyboard events
        If IsKeyPressed(Keys.Up) And (NextSnakeDirection = SnakeDirection.None) Then
            ChangeSnakePosition(SnakeDirection.Up)
        ElseIf IsKeyPressed(Keys.Down) And (NextSnakeDirection = SnakeDirection.None) Then
            ChangeSnakePosition(SnakeDirection.Down)
        ElseIf IsKeyPressed(Keys.Left) And (NextSnakeDirection = SnakeDirection.None) Then
            ChangeSnakePosition(SnakeDirection.Left)
        ElseIf IsKeyPressed(Keys.Right) And (NextSnakeDirection = SnakeDirection.None) Then
            ChangeSnakePosition(SnakeDirection.Right)
        End If


        ' Check if need to change snake position
        If NextSnakeDirection <> SnakeDirection.None Then
            fCurrentTimeElapsedDirection += fElapsed

            ' Change direction after REFRESH_INTERVAL_MS ms
            If fCurrentTimeElapsedDirection >= REFRESH_INTERVAL_MS Then

                ' Reset timer
                fCurrentTimeElapsedDirection = 0.0F

                'Change direciton and reset
                CurrentSnakeDirection = NextSnakeDirection
                NextSnakeDirection = SnakeDirection.None
            End If

        End If

        ' Test collision and Move snake
        MoveSnake(CurrentSnakeDirection, fElapsed)

        ' Check Snake collision with food
        If CheckSnakeFoodCollision() Then
            ChangeFoodPosition()
            bEnqueueFood = True
            nScore += 10
        End If

        ' Check snake collision with itself
        If SnakeHasCollided() Then
            MsgBox("End Game! - Your score:" & nScore.ToString)
            StartGame()
        End If

        ' Clear screen
        Clear(Color.MidnightBlue)

        ' Draw Snake
        For i As Integer = 0 To SnakeBlockQueue.Count - 1

            SnakeBlockRect.X = SnakeBlockQueue(i).X * BLOCK_SIZE
            SnakeBlockRect.Y = SnakeBlockQueue(i).Y * BLOCK_SIZE
            SnakeBlockRect.Height = BLOCK_SIZE
            SnakeBlockRect.Width = BLOCK_SIZE

            FillRectangle(SnakeBlockRect, SnakeColorBrush.CurrentColor.SafeObject)
        Next

        ' Draw Food
        FoodBlockRect.X = nFoodPositionIndex.X * BLOCK_SIZE
        FoodBlockRect.Y = nFoodPositionIndex.Y * BLOCK_SIZE
        FoodBlockRect.Height = BLOCK_SIZE
        FoodBlockRect.Width = BLOCK_SIZE
        FillRectangle(FoodBlockRect, FoodColorBrush.CurrentColor.SafeObject)

        ' Draw Score
        DrawText("Score: " & nScore.ToString,
                 New RectangleF(5, 5, 100, 15),
                 ScoreColorBrush.CurrentColor.SafeObject,
                 FontObject.CurrentFont.SafeObject)


        MyBase.OnFrameUpdate(fElapsed)
    End Sub
End Class
