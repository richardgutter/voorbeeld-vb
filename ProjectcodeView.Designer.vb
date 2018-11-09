<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProjectcodeView
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
        Me.btnZkprojectcode = New System.Windows.Forms.Button()
        Me.txtProjectcode = New System.Windows.Forms.TextBox()
        Me.cboZkprojectcode = New System.Windows.Forms.ComboBox()
        Me.btnNietOpslaan = New System.Windows.Forms.Button()
        Me.btnOpslaan = New System.Windows.Forms.Button()
        Me.btnLaatste = New System.Windows.Forms.Button()
        Me.btnVolgende = New System.Windows.Forms.Button()
        Me.btnVorige = New System.Windows.Forms.Button()
        Me.btnEerste = New System.Windows.Forms.Button()
        Me.btnNieuw = New System.Windows.Forms.Button()
        Me.btnWijzigen = New System.Windows.Forms.Button()
        Me.btnBekijken = New System.Windows.Forms.Button()
        Me.lblOmschrijving = New System.Windows.Forms.Label()
        Me.lblProjectcode = New System.Windows.Forms.Label()
        Me.txtOmschrijving = New System.Windows.Forms.TextBox()
        Me.lblVolgnummer = New System.Windows.Forms.Label()
        Me.lblOpdrachtgever = New System.Windows.Forms.Label()
        Me.lblOpmerkingen = New System.Windows.Forms.Label()
        Me.txtVolgnummer = New System.Windows.Forms.TextBox()
        Me.txtOpdrachtgever = New System.Windows.Forms.TextBox()
        Me.txtOpmerkingen = New System.Windows.Forms.TextBox()
        Me.chkBegeleidingsbrief = New System.Windows.Forms.CheckBox()
        Me.chkEigenlijst = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'btnZkprojectcode
        '
        Me.btnZkprojectcode.Location = New System.Drawing.Point(192, 39)
        Me.btnZkprojectcode.Name = "btnZkprojectcode"
        Me.btnZkprojectcode.Size = New System.Drawing.Size(27, 23)
        Me.btnZkprojectcode.TabIndex = 30
        Me.btnZkprojectcode.Text = "<>"
        Me.btnZkprojectcode.UseVisualStyleBackColor = True
        '
        'txtProjectcode
        '
        Me.txtProjectcode.Location = New System.Drawing.Point(86, 39)
        Me.txtProjectcode.MaxLength = 3
        Me.txtProjectcode.Name = "txtProjectcode"
        Me.txtProjectcode.Size = New System.Drawing.Size(100, 20)
        Me.txtProjectcode.TabIndex = 0
        '
        'cboZkprojectcode
        '
        Me.cboZkprojectcode.FormattingEnabled = True
        Me.cboZkprojectcode.Location = New System.Drawing.Point(225, 41)
        Me.cboZkprojectcode.MaxLength = 2
        Me.cboZkprojectcode.Name = "cboZkprojectcode"
        Me.cboZkprojectcode.Size = New System.Drawing.Size(149, 21)
        Me.cboZkprojectcode.Sorted = True
        Me.cboZkprojectcode.TabIndex = 28
        '
        'btnNietOpslaan
        '
        Me.btnNietOpslaan.Location = New System.Drawing.Point(269, 271)
        Me.btnNietOpslaan.Name = "btnNietOpslaan"
        Me.btnNietOpslaan.Size = New System.Drawing.Size(79, 23)
        Me.btnNietOpslaan.TabIndex = 27
        Me.btnNietOpslaan.Text = "Niet Opslaan"
        Me.btnNietOpslaan.UseVisualStyleBackColor = True
        '
        'btnOpslaan
        '
        Me.btnOpslaan.Location = New System.Drawing.Point(183, 271)
        Me.btnOpslaan.Name = "btnOpslaan"
        Me.btnOpslaan.Size = New System.Drawing.Size(79, 23)
        Me.btnOpslaan.TabIndex = 26
        Me.btnOpslaan.Text = "Opslaan"
        Me.btnOpslaan.UseVisualStyleBackColor = True
        '
        'btnLaatste
        '
        Me.btnLaatste.Location = New System.Drawing.Point(113, 271)
        Me.btnLaatste.Name = "btnLaatste"
        Me.btnLaatste.Size = New System.Drawing.Size(29, 23)
        Me.btnLaatste.TabIndex = 25
        Me.btnLaatste.Text = ">>"
        Me.btnLaatste.UseVisualStyleBackColor = True
        '
        'btnVolgende
        '
        Me.btnVolgende.Location = New System.Drawing.Point(78, 271)
        Me.btnVolgende.Name = "btnVolgende"
        Me.btnVolgende.Size = New System.Drawing.Size(29, 23)
        Me.btnVolgende.TabIndex = 24
        Me.btnVolgende.Text = ">"
        Me.btnVolgende.UseVisualStyleBackColor = True
        '
        'btnVorige
        '
        Me.btnVorige.Location = New System.Drawing.Point(43, 271)
        Me.btnVorige.Name = "btnVorige"
        Me.btnVorige.Size = New System.Drawing.Size(29, 23)
        Me.btnVorige.TabIndex = 23
        Me.btnVorige.Text = "<"
        Me.btnVorige.UseVisualStyleBackColor = True
        '
        'btnEerste
        '
        Me.btnEerste.Location = New System.Drawing.Point(8, 271)
        Me.btnEerste.Name = "btnEerste"
        Me.btnEerste.Size = New System.Drawing.Size(29, 23)
        Me.btnEerste.TabIndex = 22
        Me.btnEerste.Text = "<<"
        Me.btnEerste.UseVisualStyleBackColor = True
        '
        'btnNieuw
        '
        Me.btnNieuw.Location = New System.Drawing.Point(168, 6)
        Me.btnNieuw.Name = "btnNieuw"
        Me.btnNieuw.Size = New System.Drawing.Size(75, 23)
        Me.btnNieuw.TabIndex = 21
        Me.btnNieuw.Text = "Nieuw"
        Me.btnNieuw.UseVisualStyleBackColor = True
        '
        'btnWijzigen
        '
        Me.btnWijzigen.Location = New System.Drawing.Point(87, 6)
        Me.btnWijzigen.Name = "btnWijzigen"
        Me.btnWijzigen.Size = New System.Drawing.Size(75, 23)
        Me.btnWijzigen.TabIndex = 20
        Me.btnWijzigen.Text = "Wijzigen"
        Me.btnWijzigen.UseVisualStyleBackColor = True
        '
        'btnBekijken
        '
        Me.btnBekijken.Location = New System.Drawing.Point(6, 6)
        Me.btnBekijken.Name = "btnBekijken"
        Me.btnBekijken.Size = New System.Drawing.Size(75, 23)
        Me.btnBekijken.TabIndex = 19
        Me.btnBekijken.Text = "Bekijken"
        Me.btnBekijken.UseVisualStyleBackColor = True
        '
        'lblOmschrijving
        '
        Me.lblOmschrijving.AutoSize = True
        Me.lblOmschrijving.Location = New System.Drawing.Point(3, 72)
        Me.lblOmschrijving.Name = "lblOmschrijving"
        Me.lblOmschrijving.Size = New System.Drawing.Size(67, 13)
        Me.lblOmschrijving.TabIndex = 18
        Me.lblOmschrijving.Text = "Omschrijving"
        '
        'lblProjectcode
        '
        Me.lblProjectcode.AutoSize = True
        Me.lblProjectcode.Location = New System.Drawing.Point(3, 42)
        Me.lblProjectcode.Name = "lblProjectcode"
        Me.lblProjectcode.Size = New System.Drawing.Size(64, 13)
        Me.lblProjectcode.TabIndex = 17
        Me.lblProjectcode.Text = "Projectcode"
        '
        'txtOmschrijving
        '
        Me.txtOmschrijving.Location = New System.Drawing.Point(86, 69)
        Me.txtOmschrijving.MaxLength = 50
        Me.txtOmschrijving.Name = "txtOmschrijving"
        Me.txtOmschrijving.Size = New System.Drawing.Size(262, 20)
        Me.txtOmschrijving.TabIndex = 1
        '
        'lblVolgnummer
        '
        Me.lblVolgnummer.AutoSize = True
        Me.lblVolgnummer.Location = New System.Drawing.Point(2, 102)
        Me.lblVolgnummer.Name = "lblVolgnummer"
        Me.lblVolgnummer.Size = New System.Drawing.Size(65, 13)
        Me.lblVolgnummer.TabIndex = 31
        Me.lblVolgnummer.Text = "Volgnummer"
        '
        'lblOpdrachtgever
        '
        Me.lblOpdrachtgever.AutoSize = True
        Me.lblOpdrachtgever.Location = New System.Drawing.Point(2, 130)
        Me.lblOpdrachtgever.Name = "lblOpdrachtgever"
        Me.lblOpdrachtgever.Size = New System.Drawing.Size(78, 13)
        Me.lblOpdrachtgever.TabIndex = 32
        Me.lblOpdrachtgever.Text = "Opdrachtgever"
        '
        'lblOpmerkingen
        '
        Me.lblOpmerkingen.AutoSize = True
        Me.lblOpmerkingen.Location = New System.Drawing.Point(3, 202)
        Me.lblOpmerkingen.Name = "lblOpmerkingen"
        Me.lblOpmerkingen.Size = New System.Drawing.Size(70, 13)
        Me.lblOpmerkingen.TabIndex = 35
        Me.lblOpmerkingen.Text = "Opmerkingen"
        '
        'txtVolgnummer
        '
        Me.txtVolgnummer.Location = New System.Drawing.Point(86, 99)
        Me.txtVolgnummer.Name = "txtVolgnummer"
        Me.txtVolgnummer.ReadOnly = True
        Me.txtVolgnummer.Size = New System.Drawing.Size(56, 20)
        Me.txtVolgnummer.TabIndex = 36
        '
        'txtOpdrachtgever
        '
        Me.txtOpdrachtgever.Location = New System.Drawing.Point(87, 127)
        Me.txtOpdrachtgever.MaxLength = 50
        Me.txtOpdrachtgever.Name = "txtOpdrachtgever"
        Me.txtOpdrachtgever.Size = New System.Drawing.Size(261, 20)
        Me.txtOpdrachtgever.TabIndex = 2
        '
        'txtOpmerkingen
        '
        Me.txtOpmerkingen.Location = New System.Drawing.Point(86, 199)
        Me.txtOpmerkingen.MaxLength = 255
        Me.txtOpmerkingen.Multiline = True
        Me.txtOpmerkingen.Name = "txtOpmerkingen"
        Me.txtOpmerkingen.Size = New System.Drawing.Size(262, 66)
        Me.txtOpmerkingen.TabIndex = 5
        '
        'chkBegeleidingsbrief
        '
        Me.chkBegeleidingsbrief.AutoSize = True
        Me.chkBegeleidingsbrief.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkBegeleidingsbrief.Location = New System.Drawing.Point(0, 153)
        Me.chkBegeleidingsbrief.Name = "chkBegeleidingsbrief"
        Me.chkBegeleidingsbrief.Size = New System.Drawing.Size(106, 17)
        Me.chkBegeleidingsbrief.TabIndex = 3
        Me.chkBegeleidingsbrief.Text = "Begeleidingsbrief"
        Me.chkBegeleidingsbrief.UseVisualStyleBackColor = True
        '
        'chkEigenlijst
        '
        Me.chkEigenlijst.AutoSize = True
        Me.chkEigenlijst.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkEigenlijst.Location = New System.Drawing.Point(0, 176)
        Me.chkEigenlijst.Name = "chkEigenlijst"
        Me.chkEigenlijst.Size = New System.Drawing.Size(106, 17)
        Me.chkEigenlijst.TabIndex = 4
        Me.chkEigenlijst.Text = "Eigen lijst            "
        Me.chkEigenlijst.UseVisualStyleBackColor = True
        '
        'ProjectcodeView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(355, 301)
        Me.Controls.Add(Me.chkEigenlijst)
        Me.Controls.Add(Me.chkBegeleidingsbrief)
        Me.Controls.Add(Me.txtOpmerkingen)
        Me.Controls.Add(Me.txtOpdrachtgever)
        Me.Controls.Add(Me.txtVolgnummer)
        Me.Controls.Add(Me.lblOpmerkingen)
        Me.Controls.Add(Me.lblOpdrachtgever)
        Me.Controls.Add(Me.lblVolgnummer)
        Me.Controls.Add(Me.btnZkprojectcode)
        Me.Controls.Add(Me.txtProjectcode)
        Me.Controls.Add(Me.cboZkprojectcode)
        Me.Controls.Add(Me.btnNietOpslaan)
        Me.Controls.Add(Me.btnOpslaan)
        Me.Controls.Add(Me.btnLaatste)
        Me.Controls.Add(Me.btnVolgende)
        Me.Controls.Add(Me.btnVorige)
        Me.Controls.Add(Me.btnEerste)
        Me.Controls.Add(Me.btnNieuw)
        Me.Controls.Add(Me.btnWijzigen)
        Me.Controls.Add(Me.btnBekijken)
        Me.Controls.Add(Me.lblOmschrijving)
        Me.Controls.Add(Me.lblProjectcode)
        Me.Controls.Add(Me.txtOmschrijving)
        Me.Name = "ProjectcodeView"
        Me.Text = "Projectcodes"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnZkprojectcode As System.Windows.Forms.Button
    Friend WithEvents txtProjectcode As System.Windows.Forms.TextBox
    Friend WithEvents cboZkprojectcode As System.Windows.Forms.ComboBox
    Friend WithEvents btnNietOpslaan As System.Windows.Forms.Button
    Friend WithEvents btnOpslaan As System.Windows.Forms.Button
    Friend WithEvents btnLaatste As System.Windows.Forms.Button
    Friend WithEvents btnVolgende As System.Windows.Forms.Button
    Friend WithEvents btnVorige As System.Windows.Forms.Button
    Friend WithEvents btnEerste As System.Windows.Forms.Button
    Friend WithEvents btnNieuw As System.Windows.Forms.Button
    Friend WithEvents btnWijzigen As System.Windows.Forms.Button
    Friend WithEvents btnBekijken As System.Windows.Forms.Button
    Friend WithEvents lblOmschrijving As System.Windows.Forms.Label
    Friend WithEvents lblProjectcode As System.Windows.Forms.Label
    Friend WithEvents txtOmschrijving As System.Windows.Forms.TextBox
    Friend WithEvents lblVolgnummer As System.Windows.Forms.Label
    Friend WithEvents lblOpdrachtgever As System.Windows.Forms.Label
    Friend WithEvents lblOpmerkingen As System.Windows.Forms.Label
    Friend WithEvents txtVolgnummer As System.Windows.Forms.TextBox
    Friend WithEvents txtOpdrachtgever As System.Windows.Forms.TextBox
    Friend WithEvents txtOpmerkingen As System.Windows.Forms.TextBox
    Friend WithEvents chkBegeleidingsbrief As System.Windows.Forms.CheckBox
    Friend WithEvents chkEigenlijst As System.Windows.Forms.CheckBox
End Class
