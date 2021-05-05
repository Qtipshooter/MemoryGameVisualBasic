' MemoryMedium
' Quinton Graham
' Runs the Medium difficulty of the game Memory

Option Strict On
Option Explicit On
Public Class MemoryMedium
    'array for all images used in this difficulty
    Private arrMedium() As Bitmap

    'array of images used for reference
    Private arrReference(39) As Bitmap

    'array of all pictureboxes for addresses
    Private arrPictureBoxes() As PictureBox

    'store the picture for a card back
    Dim imgCardBack As Image = My.Resources.Backface_Blue

    'stores the current card that is flipped - card back when there is no current image
    Dim imgCurrentCard As Image = imgCardBack
    Dim picCurrentCard As PictureBox

    Dim timer As New Stopwatch

    Dim intMatches As Integer = 0

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub MemoryMedium_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'fills the arrays with the addresses needed for comparisons and addressing
        FillArrays()

        'shuffle the set of cards
        ShuffleCards(arrMedium)

        'sets the address of each picture box image to the card back image
        For intIndex As Integer = 0 To arrPictureBoxes.Count - 1
            arrPictureBoxes(intIndex).Image = imgCardBack
        Next

        'start a stopwatch for a timer for scoring
        timer.Start()

    End Sub

    Private Sub picCard_Click(sender As Object, e As EventArgs) Handles picCard1.Click, picCard2.Click, picCard3.Click, picCard4.Click,
            picCard5.Click, picCard6.Click, picCard7.Click, picCard8.Click, picCard9.Click, picCard10.Click, picCard11.Click, picCard12.Click,
            picCard13.Click, picCard14.Click, picCard15.Click, picCard16.Click, picCard17.Click, picCard18.Click, picCard19.Click, picCard20.Click,
            picCard21.Click, picCard22.Click, picCard23.Click, picCard24.Click, picCard25.Click, picCard26.Click, picCard27.Click, picCard28.Click,
            picCard29.Click, picCard30.Click, picCard31.Click, picCard32.Click, picCard33.Click, picCard34.Click, picCard35.Click, picCard36.Click,
            picCard37.Click, picCard38.Click, picCard39.Click, picCard40.Click

        'determine index for use later
        Dim intIndex As Integer = DetermineIndex(CType(sender, PictureBox))

        If CType(sender, PictureBox).Image Is imgCardBack Then
            'flip card, then pause so user can see each card
            CType(sender, PictureBox).Image = arrMedium(intIndex)
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
                If MainMenu.chkColor.Checked Then
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
        If intMatches >= 20 Then
            timer.Stop()
            Dim lngTime As Long = timer.ElapsedMilliseconds

            MessageBox.Show("Game Over!  You win!" + vbCrLf + "You took " + CStr(lngTime) + " Milliseconds", "Congratulations!")
            If CLng(MainMenu.lblHighScore.Text) > lngTime Or CLng(MainMenu.lblHighScore.Text) = 0 Then
                MainMenu.lblHighScore.Text = CStr(lngTime)
            End If
            Me.Close()
        End If


    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click

        'show all cards
        For intIndex As Integer = 0 To arrPictureBoxes.Count - 1
            arrPictureBoxes(intIndex).Show()
        Next

        'rerandomize arrays
        FillArrays()
        ShuffleCards(arrMedium)

        'hide all cards
        For intIndex As Integer = 0 To arrPictureBoxes.Count - 1
            arrPictureBoxes(intIndex).Image = imgCardBack
        Next

        'reset the number of matches found
        intMatches = 0

        'reset the timer
        timer.Restart()
    End Sub

    'Internal Functions'

    'shuffle the cards so that they are random each game
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

    'determines if the cards are red
    Private Function IsRed(ByRef picCard As PictureBox) As Boolean
        If DetermineIndex(picCard) Mod 2 = 1 Then
            Return True
        Else
            Return False
        End If
    End Function

    'determines if the number matches
    Private Function CheckForMatch(ByRef picCardA As PictureBox, ByRef picCardB As PictureBox) As Boolean
        'error
        If picCardA Is picCardB Then
            Return False
        End If

        'indexes of the pictures in the reference array
        Dim intCardA As Integer = 0
        Dim intCardB As Integer = 0

        'Find the indexes of the cards' pictures in the reference array
        For intIndex As Integer = 0 To 39
            If picCardA.Image Is arrReference(intIndex) Then
                intCardA = intIndex
            ElseIf picCardB.Image Is arrReference(intIndex) Then
                intCardB = intIndex
            End If
        Next

        'compare indexes to see if card numbers match
        Return (intCardA \ 4) = (intCardB \ 4)


    End Function

    'determines the index of the picturebox sent
    Private Function DetermineIndex(ByVal picCard As PictureBox) As Integer
        For intIndex = 0 To 39
            If picCard Is arrPictureBoxes(intIndex) Then
                Return intIndex
            End If
        Next

        'error, out of bounds
        Return -1
    End Function

    'Fills the picture box array
    Private Sub FillArrays()
        arrMedium =
        {
            My.Resources._2_Clubs,
            My.Resources._2_Diamonds,
            My.Resources._2_Spades,
            My.Resources._2_Hearts,
            My.Resources._3_Clubs,
            My.Resources._3_Diamonds,
            My.Resources._3_Spades,
            My.Resources._3_Hearts,
            My.Resources._4_Clubs,
            My.Resources._4_Diamonds,
            My.Resources._4_Spades,
            My.Resources._4_Hearts,
            My.Resources._5_Clubs,
            My.Resources._5_Diamonds,
            My.Resources._5_Spades,
            My.Resources._5_Hearts,
            My.Resources._6_Clubs,
            My.Resources._6_Diamonds,
            My.Resources._6_Spades,
            My.Resources._6_Hearts,
            My.Resources._7_Clubs,
            My.Resources._7_Diamonds,
            My.Resources._7_Spades,
            My.Resources._7_Hearts,
            My.Resources._8_Clubs,
            My.Resources._8_Diamonds,
            My.Resources._8_Spades,
            My.Resources._8_Hearts,
            My.Resources._9_Clubs,
            My.Resources._9_Diamonds,
            My.Resources._9_Spades,
            My.Resources._9_Hearts,
            My.Resources._10_Clubs,
            My.Resources._10_Diamonds,
            My.Resources._10_Spades,
            My.Resources._10_Hearts,
            My.Resources.Ace_Clubs,
            My.Resources.Ace_Diamonds,
            My.Resources.Ace_Spades,
            My.Resources.Ace_Hearts
        }

        For intIndex As Integer = 0 To 39
            arrReference(intIndex) = arrMedium(intIndex)
        Next

        arrPictureBoxes =
        {
            picCard1, picCard2, picCard3, picCard4, picCard5, picCard6, picCard7, picCard8,
            picCard9, picCard10, picCard11, picCard12, picCard13, picCard14, picCard15, picCard16,
            picCard17, picCard18, picCard19, picCard20, picCard21, picCard22, picCard23, picCard24,
            picCard25, picCard26, picCard27, picCard28, picCard29, picCard30, picCard31, picCard32,
            picCard33, picCard34, picCard35, picCard36, picCard37, picCard38, picCard39, picCard40
        }
    End Sub


End Class