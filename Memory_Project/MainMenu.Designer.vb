<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainMenu
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.grpDifficulty = New System.Windows.Forms.GroupBox()
        Me.radMedium = New System.Windows.Forms.RadioButton()
        Me.radEasy = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblHighScore = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkColor = New System.Windows.Forms.CheckBox()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.Help = New System.Windows.Forms.Button()
        Me.grpDifficulty.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpDifficulty
        '
        Me.grpDifficulty.Controls.Add(Me.radMedium)
        Me.grpDifficulty.Controls.Add(Me.radEasy)
        Me.grpDifficulty.Location = New System.Drawing.Point(12, 27)
        Me.grpDifficulty.Name = "grpDifficulty"
        Me.grpDifficulty.Size = New System.Drawing.Size(140, 118)
        Me.grpDifficulty.TabIndex = 0
        Me.grpDifficulty.TabStop = False
        Me.grpDifficulty.Text = "Difficulty"
        '
        'radMedium
        '
        Me.radMedium.Location = New System.Drawing.Point(9, 70)
        Me.radMedium.Margin = New System.Windows.Forms.Padding(6)
        Me.radMedium.Name = "radMedium"
        Me.radMedium.Size = New System.Drawing.Size(122, 36)
        Me.radMedium.TabIndex = 1
        Me.radMedium.TabStop = True
        Me.radMedium.Text = "&Medium"
        Me.radMedium.UseVisualStyleBackColor = True
        '
        'radEasy
        '
        Me.radEasy.Location = New System.Drawing.Point(9, 22)
        Me.radEasy.Margin = New System.Windows.Forms.Padding(6)
        Me.radEasy.Name = "radEasy"
        Me.radEasy.Size = New System.Drawing.Size(122, 36)
        Me.radEasy.TabIndex = 0
        Me.radEasy.TabStop = True
        Me.radEasy.Text = "&Easy"
        Me.radEasy.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(158, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(172, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Match Color?"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblHighScore
        '
        Me.lblHighScore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHighScore.Location = New System.Drawing.Point(158, 117)
        Me.lblHighScore.Name = "lblHighScore"
        Me.lblHighScore.Size = New System.Drawing.Size(172, 23)
        Me.lblHighScore.TabIndex = 4
        Me.lblHighScore.Text = "0"
        Me.lblHighScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(158, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(172, 23)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "High Score (Time in Milliseconds):"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkColor
        '
        Me.chkColor.Location = New System.Drawing.Point(158, 57)
        Me.chkColor.Name = "chkColor"
        Me.chkColor.Size = New System.Drawing.Size(172, 23)
        Me.chkColor.TabIndex = 5
        Me.chkColor.Text = "Check to Match &Color"
        Me.chkColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkColor.UseVisualStyleBackColor = True
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(12, 162)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(95, 41)
        Me.btnStart.TabIndex = 7
        Me.btnStart.Text = "&Start Game"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(123, 162)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(95, 41)
        Me.btnExit.TabIndex = 8
        Me.btnExit.Text = "E&xit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'Help
        '
        Me.Help.Location = New System.Drawing.Point(235, 162)
        Me.Help.Name = "Help"
        Me.Help.Size = New System.Drawing.Size(95, 41)
        Me.Help.TabIndex = 9
        Me.Help.Text = "&Help"
        Me.Help.UseVisualStyleBackColor = True
        '
        'MainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(342, 228)
        Me.Controls.Add(Me.Help)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.chkColor)
        Me.Controls.Add(Me.lblHighScore)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.grpDifficulty)
        Me.Name = "MainMenu"
        Me.Text = "Memory - Main Menu"
        Me.grpDifficulty.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grpDifficulty As GroupBox
    Friend WithEvents radEasy As RadioButton
    Friend WithEvents radMedium As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents lblHighScore As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents chkColor As CheckBox
    Friend WithEvents btnStart As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents Help As Button
End Class
