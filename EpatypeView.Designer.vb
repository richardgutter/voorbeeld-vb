<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EpatypeView
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
        Me.txtOmschrijving = New System.Windows.Forms.TextBox()
        Me.lblEPAType = New System.Windows.Forms.Label()
        Me.lblOmschrijving = New System.Windows.Forms.Label()
        Me.btnBekijken = New System.Windows.Forms.Button()
        Me.btnWijzigen = New System.Windows.Forms.Button()
        Me.btnNieuw = New System.Windows.Forms.Button()
        Me.btnEerste = New System.Windows.Forms.Button()
        Me.btnVorige = New System.Windows.Forms.Button()
        Me.btnVolgende = New System.Windows.Forms.Button()
        Me.btnLaatste = New System.Windows.Forms.Button()
        Me.btnOpslaan = New System.Windows.Forms.Button()
        Me.btnNietOpslaan = New System.Windows.Forms.Button()
        Me.cboZkepatype = New System.Windows.Forms.ComboBox()
        Me.txtEpatype = New System.Windows.Forms.TextBox()
        Me.btnZkepatype = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtOmschrijving
        '
        Me.txtOmschrijving.Location = New System.Drawing.Point(75, 70)
        Me.txtOmschrijving.MaxLength = 35
        Me.txtOmschrijving.Name = "txtOmschrijving"
        Me.txtOmschrijving.Size = New System.Drawing.Size(270, 20)
        Me.txtOmschrijving.TabIndex = 1
        '
        'lblEPAType
        '
        Me.lblEPAType.AutoSize = True
        Me.lblEPAType.Location = New System.Drawing.Point(2, 43)
        Me.lblEPAType.Name = "lblEPAType"
        Me.lblEPAType.Size = New System.Drawing.Size(51, 13)
        Me.lblEPAType.TabIndex = 2
        Me.lblEPAType.Text = "EPA-type"
        '
        'lblOmschrijving
        '
        Me.lblOmschrijving.AutoSize = True
        Me.lblOmschrijving.Location = New System.Drawing.Point(2, 73)
        Me.lblOmschrijving.Name = "lblOmschrijving"
        Me.lblOmschrijving.Size = New System.Drawing.Size(67, 13)
        Me.lblOmschrijving.TabIndex = 3
        Me.lblOmschrijving.Text = "Omschrijving"
        '
        'btnBekijken
        '
        Me.btnBekijken.Location = New System.Drawing.Point(5, 7)
        Me.btnBekijken.Name = "btnBekijken"
        Me.btnBekijken.Size = New System.Drawing.Size(75, 23)
        Me.btnBekijken.TabIndex = 4
        Me.btnBekijken.Text = "Bekijken"
        Me.btnBekijken.UseVisualStyleBackColor = True
        '
        'btnWijzigen
        '
        Me.btnWijzigen.Location = New System.Drawing.Point(86, 7)
        Me.btnWijzigen.Name = "btnWijzigen"
        Me.btnWijzigen.Size = New System.Drawing.Size(75, 23)
        Me.btnWijzigen.TabIndex = 5
        Me.btnWijzigen.Text = "Wijzigen"
        Me.btnWijzigen.UseVisualStyleBackColor = True
        '
        'btnNieuw
        '
        Me.btnNieuw.Location = New System.Drawing.Point(167, 7)
        Me.btnNieuw.Name = "btnNieuw"
        Me.btnNieuw.Size = New System.Drawing.Size(75, 23)
        Me.btnNieuw.TabIndex = 5
        Me.btnNieuw.Text = "Nieuw"
        Me.btnNieuw.UseVisualStyleBackColor = True
        '
        'btnEerste
        '
        Me.btnEerste.Location = New System.Drawing.Point(5, 96)
        Me.btnEerste.Name = "btnEerste"
        Me.btnEerste.Size = New System.Drawing.Size(29, 23)
        Me.btnEerste.TabIndex = 7
        Me.btnEerste.Text = "<<"
        Me.btnEerste.UseVisualStyleBackColor = True
        '
        'btnVorige
        '
        Me.btnVorige.Location = New System.Drawing.Point(40, 96)
        Me.btnVorige.Name = "btnVorige"
        Me.btnVorige.Size = New System.Drawing.Size(29, 23)
        Me.btnVorige.TabIndex = 8
        Me.btnVorige.Text = "<"
        Me.btnVorige.UseVisualStyleBackColor = True
        '
        'btnVolgende
        '
        Me.btnVolgende.Location = New System.Drawing.Point(75, 96)
        Me.btnVolgende.Name = "btnVolgende"
        Me.btnVolgende.Size = New System.Drawing.Size(29, 23)
        Me.btnVolgende.TabIndex = 9
        Me.btnVolgende.Text = ">"
        Me.btnVolgende.UseVisualStyleBackColor = True
        '
        'btnLaatste
        '
        Me.btnLaatste.Location = New System.Drawing.Point(110, 96)
        Me.btnLaatste.Name = "btnLaatste"
        Me.btnLaatste.Size = New System.Drawing.Size(29, 23)
        Me.btnLaatste.TabIndex = 10
        Me.btnLaatste.Text = ">>"
        Me.btnLaatste.UseVisualStyleBackColor = True
        '
        'btnOpslaan
        '
        Me.btnOpslaan.Location = New System.Drawing.Point(180, 96)
        Me.btnOpslaan.Name = "btnOpslaan"
        Me.btnOpslaan.Size = New System.Drawing.Size(79, 23)
        Me.btnOpslaan.TabIndex = 11
        Me.btnOpslaan.Text = "Opslaan"
        Me.btnOpslaan.UseVisualStyleBackColor = True
        '
        'btnNietOpslaan
        '
        Me.btnNietOpslaan.Location = New System.Drawing.Point(266, 96)
        Me.btnNietOpslaan.Name = "btnNietOpslaan"
        Me.btnNietOpslaan.Size = New System.Drawing.Size(79, 23)
        Me.btnNietOpslaan.TabIndex = 12
        Me.btnNietOpslaan.Text = "Niet Opslaan"
        Me.btnNietOpslaan.UseVisualStyleBackColor = True
        '
        'cboZkepatype
        '
        Me.cboZkepatype.FormattingEnabled = True
        Me.cboZkepatype.Location = New System.Drawing.Point(214, 44)
        Me.cboZkepatype.MaxLength = 2
        Me.cboZkepatype.Name = "cboZkepatype"
        Me.cboZkepatype.Size = New System.Drawing.Size(149, 21)
        Me.cboZkepatype.Sorted = True
        Me.cboZkepatype.TabIndex = 13
        '
        'txtEpatype
        '
        Me.txtEpatype.Location = New System.Drawing.Point(75, 40)
        Me.txtEpatype.MaxLength = 2
        Me.txtEpatype.Name = "txtEpatype"
        Me.txtEpatype.Size = New System.Drawing.Size(100, 20)
        Me.txtEpatype.TabIndex = 0
        '
        'btnZkepatype
        '
        Me.btnZkepatype.Location = New System.Drawing.Point(181, 40)
        Me.btnZkepatype.Name = "btnZkepatype"
        Me.btnZkepatype.Size = New System.Drawing.Size(27, 23)
        Me.btnZkepatype.TabIndex = 15
        Me.btnZkepatype.Text = "<>"
        Me.btnZkepatype.UseVisualStyleBackColor = True
        '
        'EpatypeView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(349, 125)
        Me.Controls.Add(Me.btnZkepatype)
        Me.Controls.Add(Me.txtEpatype)
        Me.Controls.Add(Me.cboZkepatype)
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
        Me.Controls.Add(Me.lblEPAType)
        Me.Controls.Add(Me.txtOmschrijving)
        Me.Name = "EpatypeView"
        Me.Text = "EPA-Typen"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtOmschrijving As System.Windows.Forms.TextBox
    Friend WithEvents lblEPAType As System.Windows.Forms.Label
    Friend WithEvents lblOmschrijving As System.Windows.Forms.Label
    Friend WithEvents btnBekijken As System.Windows.Forms.Button
    Friend WithEvents btnWijzigen As System.Windows.Forms.Button
    Friend WithEvents btnNieuw As System.Windows.Forms.Button
    Friend WithEvents btnEerste As System.Windows.Forms.Button
    Friend WithEvents btnVorige As System.Windows.Forms.Button
    Friend WithEvents btnVolgende As System.Windows.Forms.Button
    Friend WithEvents btnLaatste As System.Windows.Forms.Button
    Friend WithEvents btnOpslaan As System.Windows.Forms.Button
    Friend WithEvents btnNietOpslaan As System.Windows.Forms.Button
    Friend WithEvents cboZkepatype As System.Windows.Forms.ComboBox
    Friend WithEvents txtEpatype As System.Windows.Forms.TextBox
    Friend WithEvents btnZkepatype As System.Windows.Forms.Button
End Class
