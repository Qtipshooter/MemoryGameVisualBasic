' Memory Easy
' Quinton Graham
' Runs the Easy difficulty for the game Memory

Option Strict On
Option Explicit On
Public Class MemoryEasy

    'list of all images needed
    Private arrEasy() As Bitmap

    'list of reference images
    Private arrReference() As Bitmap

    'the array that holds the picture box objects
    Private arrPictureBoxes() As PictureBox

    'store the picture for a card back
    Dim imgCardBack As Image = My.Resources.Backface_Blue

    'stores the current card that is flipped - card back when there is no current image
    Dim imgCurrentCard As Image = imgCardBack
    Dim picCurrentCard As PictureBox

    Dim timer As New Stopwatch


    'store the number of matches, when it hits 7, the game ends
    Dim intMatches As Integer = 0

    Private Sub MemoryEasy_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'fills the arrays with the addresses needed for comparisons and addressing
        FillArrays()

        'shuffle the set of cards
        ShuffleCards(arrEasy)

        'sets the address of each picture box image to the card back image
        For intIndex As Integer = 0 To arrPictureBoxes.Count - 1
            arrPictureBoxes(intIndex).Image = imgCardBack
        Next

        'start a stopwatch for a timer for scoring
        timer.Start()

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        'show all cards
        For intIndex As Integer = 0 To arrPictureBoxes.Count - 1
            arrPictureBoxes(intIndex).Show()
        Next

        'rerandomize arrays
        FillArrays()
        ShuffleCards(arrEasy)

        'hide all cards
        For intIndex As Integer = 0 To arrPictureBoxes.Count - 1
            arrPictureBoxes(intIndex).Image = imgCardBack
        Next

        'reset count of matches
        intMatches = 0

        'reset the stopwatch for scoring
        timer.Restart()
    End Sub

    'Card click event handler handles any card that is clicked uniformly
    Private Sub picCard_Click(sender As Object, e As EventArgs) Handles _
            picCard1.Click, picCard2.Click, picCard3.Click, picCard4.Click, picCard5.Click, picCard6.Click, picCard7.Click,
            picCard8.Click, picCard9.Click, picCard10.Click, picCard11.Click, picCard12.Click, picCard13.Click, picCard14.Click

        Dim intIndex As Integer = DetermineIndex(CType(sender, PictureBox))

        If CType(sender, PictureBox).Image Is imgCardBack Then
            'flip card, then pause so user can see each card
            CType(sender, PictureBox).Image = arrEasy(intIndex)
            My.Application.DoEvents()
            System.Threading.Thread.Sleep(500)

            'determine if this is first or second image
            If imgCurrentCard Is imgCardBack Then
                'first card
                imgCurrentCard = CType(sender, PictureBox).Image
                picCurrentCard = CType(sender, PictureBox)
                Return
            End If

            'otherwise, second card, reset current card
            imgCurrentCard = imgCardBack

            'check if symbol is the same
            If CheckForMatch(CType(sender, PictureBox), picCurrentCard) Then
                'check if color is the same if checked and not joker
                If MainMenu.chkColor.Checked And sender IsNot arrReference(12) And sender IsNot arrReference(13) Then
                    'check the color
                    If IsRed(CType(sender, PictureBox)) = IsRed(picCurrentCard) Then
                        'Correct
                        CType(sender, PictureBox).Hide()
                        picCurrentCard.Hide()
                        intMatches += 1
                    Else
                        'Wrong, flip back to card backs
                        arrPictureBoxes(intIndex).Image = imgCardBack
                        arrPictureBoxes(DetermineIndex(picCurrentCard)).Image = imgCardBack
                    End If
                Else
                    'Correct
                    CType(sender, PictureBox).Hide()
                    picCurrentCard.Hide()
                    intMatches += 1
                End If
            Else
                'Wrong, flip back to card backs
                arrPictureBoxes(intIndex).Image = imgCardBack
                arrPictureBoxes(DetermineIndex(picCurrentCard)).Image = imgCardBack
            End If
        End If

        'determine if the game is over
        If intMatches >= 7 Then
            timer.Stop()
            Dim lngTime As Long = timer.ElapsedMilliseconds

            MessageBox.Show("Game Over!  You win!" + vbCrLf + "You took " + CStr(lngTime) + " Milliseconds", "Congratulations!")
            If CLng(MainMenu.lblHighScore.Text) > lngTime Or CLng(MainMenu.lblHighScore.Text) = 0 Then
                MainMenu.lblHighScore.Text = CStr(lngTime)
            End If
            Me.Close()
        End If



    End Sub

    'Internal Procedures'

    'Shuffles the cards to random positions
    Private Sub ShuffleCards(ByRef arrSet() As Bitmap)
        Dim arrShuffleSet(arrSet.Count - 1) As Integer
        Dim rnd As New Random

        'put random numbers into an extra set used to organize the first set
        For intCtr As Integer = 0 To arrShuffleSet.Count - 1
            arrShuffleSet(intCtr) = rnd.Next()
        Next

        'sort the random set, and randomize the first set
        'bubble sort used as I'm lazy right now on complexity
        For intOuterLoop As Integer = 0 To arrShuffleSet.Count - 2
            For intInnerLoop As Integer = 0 To arrShuffleSet.Count - 2 - intOuterLoop
                If arrShuffleSet(intInnerLoop) > arrShuffleSet(intInnerLoop + 1) Then
                    'swap variables to move larger item of random closer to end
                    Dim intTemp As Integer = arrShuffleSet(intInnerLoop)
                    arrShuffleSet(intInnerLoop) = arrShuffleSet(intInnerLoop + 1)
                    arrShuffleSet(intInnerLoop + 1) = intTemp

                    'sort the first list in the same order as the random set, hereby randomizing it
                    Dim bmpTemp = arrSet(intInnerLoop)
                    arrSet(intInnerLoop) = arrSet(intInnerLoop + 1)
                    arrSet(intInnerLoop + 1) = bmpTemp
                End If
            Next
        Next

    End Sub

    'Fills the picture box array
    Private Sub FillArrays()
        arrEasy =
        {
            My.Resources.Jack_Clubs,
            My.Resources.Jack_Diamonds,
            My.Resources.Jack_Hearts,
            My.Resources.Jack_Spades,
            My.Resources.Queen_Clubs,
            My.Resources.Queen_Diamonds,
            My.Resources.Queen_Hearts,
            My.Resources.Queen_Spades,
            My.Resources.King_Clubs,
            My.Resources.King_Diamonds,
            My.Resources.King_Hearts,
            My.Resources.King_Spades,
            My.Resources.Joker_Black,
            My.Resources.Joker_Red
        }

        arrReference =
        {
            arrEasy(0),
            arrEasy(1),
            arrEasy(2),
            arrEasy(3),
            arrEasy(4),
            arrEasy(5),
            arrEasy(6),
            arrEasy(7),
            arrEasy(8),
            arrEasy(9),
            arrEasy(10),
            arrEasy(11),
            arrEasy(12),
            arrEasy(13)
        }

        arrPictureBoxes =
        {
            picCard1,
            picCard2,
            picCard3,
            picCard4,
            picCard5,
            picCard6,
            picCard7,
            picCard8,
            picCard9,
            picCard10,
            picCard11,
            picCard12,
            picCard13,
            picCard14
        }
    End Sub

    'determines index
    Private Function DetermineIndex(ByVal picCard As PictureBox) As Integer
        If picCard Is picCard1 Then
            Return 0
        ElseIf picCard Is picCard2 Then
            Return 1
        ElseIf picCard Is picCard3 Then
            Return 2
        ElseIf picCard Is picCard4 Then
            Return 3
        ElseIf picCard Is picCard5 Then
            Return 4
        ElseIf picCard Is picCard6 Then
            Return 5
        ElseIf picCard Is picCard7 Then
            Return 6
        ElseIf picCard Is picCard8 Then
            Return 7
        ElseIf picCard Is picCard9 Then
            Return 8
        ElseIf picCard Is picCard10 Then
            Return 9
        ElseIf picCard Is picCard11 Then
            Return 10
        ElseIf picCard Is picCard12 Then
            Return 11
        ElseIf picCard Is picCard13 Then
            Return 12
        ElseIf picCard Is picCard14 Then
            Return 13
        Else
            Return -1
        End If
    End Function

    'check if symbol is the same
    Private Function CheckForMatch(ByRef picCardA As PictureBox, ByRef picCardB As PictureBox) As Boolean
        'error
        If picCardA.Image Is picCardB.Image Then
            Return False
        End If

        'check if jacks
        If picCardA.Image Is arrReference(0) Or picCardA.Image Is arrReference(1) Or picCardA.Image Is arrReference(2) Or picCardA.Image Is arrReference(3) Then
            'check if second card is also one of the above
            If picCardB.Image Is arrReference(0) Or picCardB.Image Is arrReference(1) Or picCardB.Image Is arrReference(2) Or picCardB.Image Is arrReference(3) Then
                Return True
            End If
        End If

        'check if queens
        If picCardA.Image Is arrReference(4) Or picCardA.Image Is arrReference(5) Or picCardA.Image Is arrReference(6) Or picCardA.Image Is arrReference(7) Then
            'check if second card is also one of the above
            If picCardB.Image Is arrReference(4) Or picCardB.Image Is arrReference(5) Or picCardB.Image Is arrReference(6) Or picCardB.Image Is arrReference(7) Then
                Return True
            End If
        End If

        'check if kings
        If picCardA.Image Is arrReference(8) Or picCardA.Image Is arrReference(9) Or picCardA.Image Is arrReference(10) Or picCardA.Image Is arrReference(11) Then
            'check if second card is also one of the above
            If picCardB.Image Is arrReference(8) Or picCardB.Image Is arrReference(9) Or picCardB.Image Is arrReference(10) Or picCardB.Image Is arrReference(11) Then
                Return True
            End If
        End If

        'check if kings
        If picCardA.Image Is arrReference(12) Or picCardA.Image Is arrReference(13) Then
            'check if second card is also one of the above
            If picCardB.Image Is arrReference(12) Or picCardB.Image Is arrReference(13) Then
                Return True
            End If
        End If



        Return False
    End Function

    'checks color of card
    Private Function IsRed(picCard As PictureBox) As Boolean
        'comapare to the references of all red cards (excluding joker as they cannot match colors and this should never be checked)
        If picCard.Image Is arrReference(1) Or picCard.Image Is arrReference(2) Or picCard.Image Is arrReference(5) Or
            picCard.Image Is arrReference(6) Or picCard.Image Is arrReference(9) Or picCard.Image Is arrReference(10) Then

            Return True
        End If

        'return false if not any of these
        Return False
    End Function

End Class