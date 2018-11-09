<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AanspreektitelView
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
        Me.btnZkaanspreektitel = New System.Windows.Forms.Button()
        Me.txtAanspreektitel = New System.Windows.Forms.TextBox()
        Me.cboZkaanspreektitel = New System.Windows.Forms.ComboBox()
        Me.btnNietopslaan = New System.Windows.Forms.Button()
        Me.btnOpslaan = New System.Windows.Forms.Button()
        Me.btnLaatste = New System.Windows.Forms.Button()
        Me.btnVolgende = New System.Windows.Forms.Button()
        Me.btnVorige = New System.Windows.Forms.Button()
        Me.btnEerste = New System.Windows.Forms.Button()
        Me.btnNieuw = New System.Windows.Forms.Button()
        Me.btnWijzigen = New System.Windows.Forms.Button()
        Me.btnBekijken = New System.Windows.Forms.Button()
        Me.lblAanspreektitel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnZkaanspreektitel
        '
        Me.btnZkaanspreektitel.Location = New System.Drawing.Point(231, 39)
        Me.btnZkaanspreektitel.Name = "btnZkaanspreektitel"
        Me.btnZkaanspreektitel.Size = New System.Drawing.Size(27, 23)
        Me.btnZkaanspreektitel.TabIndex = 43
        Me.btnZkaanspreektitel.Text = "<>"
        Me.btnZkaanspreektitel.UseVisualStyleBackColor = True
        '
        'txtAanspreektitel
        '
        Me.txtAanspreektitel.Location = New System.Drawing.Point(76, 39)
        Me.txtAanspreektitel.MaxLength = 25
        Me.txtAanspreektitel.Name = "txtAanspreektitel"
        Me.txtAanspreektitel.Size = New System.Drawing.Size(149, 20)
        Me.txtAanspreektitel.TabIndex = 0
        '
        'cboZkaanspreektitel
        '
        Me.cboZkaanspreektitel.FormattingEnabled = True
        Me.cboZkaanspreektitel.Location = New System.Drawing.Point(281, 42)
        Me.cboZkaanspreektitel.MaxLength = 2
        Me.cboZkaanspreektitel.Name = "cboZkaanspreektitel"
        Me.cboZkaanspreektitel.Size = New System.Drawing.Size(140, 21)
        Me.cboZkaanspreektitel.Sorted = True
        Me.cboZkaanspreektitel.TabIndex = 41
        '
        'btnNietopslaan
        '
        Me.btnNietopslaan.Location = New System.Drawing.Point(267, 70)
        Me.btnNietopslaan.Name = "btnNietopslaan"
        Me.btnNietopslaan.Size = New System.Drawing.Size(79, 23)
        Me.btnNietopslaan.TabIndex = 40
        Me.btnNietopslaan.Text = "Niet Opslaan"
        Me.btnNietopslaan.UseVisualStyleBackColor = True
        '
        'btnOpslaan
        '
        Me.btnOpslaan.Location = New System.Drawing.Point(181, 70)
        Me.btnOpslaan.Name = "btnOpslaan"
        Me.btnOpslaan.Size = New System.Drawing.Size(79, 23)
        Me.btnOpslaan.TabIndex = 39
        Me.btnOpslaan.Text = "Opslaan"
        Me.btnOpslaan.UseVisualStyleBackColor = True
        '
        'btnLaatste
        '
        Me.btnLaatste.Location = New System.Drawing.Point(111, 70)
        Me.btnLaatste.Name = "btnLaatste"
        Me.btnLaatste.Size = New System.Drawing.Size(29, 23)
        Me.btnLaatste.TabIndex = 38
        Me.btnLaatste.Text = ">>"
        Me.btnLaatste.UseVisualStyleBackColor = True
        '
        'btnVolgende
        '
        Me.btnVolgende.Location = New System.Drawing.Point(76, 70)
        Me.btnVolgende.Name = "btnVolgende"
        Me.btnVolgende.Size = New System.Drawing.Size(29, 23)
        Me.btnVolgende.TabIndex = 37
        Me.btnVolgende.Text = ">"
        Me.btnVolgende.UseVisualStyleBackColor = True
        '
        'btnVorige
        '
        Me.btnVorige.Location = New System.Drawing.Point(41, 70)
        Me.btnVorige.Name = "btnVorige"
        Me.btnVorige.Size = New System.Drawing.Size(29, 23)
        Me.btnVorige.TabIndex = 36
        Me.btnVorige.Text = "<"
        Me.btnVorige.UseVisualStyleBackColor = True
        '
        'btnEerste
        '
        Me.btnEerste.Location = New System.Drawing.Point(6, 70)
        Me.btnEerste.Name = "btnEerste"
        Me.btnEerste.Size = New System.Drawing.Size(29, 23)
        Me.btnEerste.TabIndex = 35
        Me.btnEerste.Text = "<<"
        Me.btnEerste.UseVisualStyleBackColor = True
        '
        'btnNieuw
        '
        Me.btnNieuw.Location = New System.Drawing.Point(167, 6)
        Me.btnNieuw.Name = "btnNieuw"
        Me.btnNieuw.Size = New System.Drawing.Size(75, 23)
        Me.btnNieuw.TabIndex = 34
        Me.btnNieuw.Text = "Nieuw"
        Me.btnNieuw.UseVisualStyleBackColor = True
        '
        'btnWijzigen
        '
        Me.btnWijzigen.Location = New System.Drawing.Point(86, 6)
        Me.btnWijzigen.Name = "btnWijzigen"
        Me.btnWijzigen.Size = New System.Drawing.Size(75, 23)
        Me.btnWijzigen.TabIndex = 33
        Me.btnWijzigen.Text = "Wijzigen"
        Me.btnWijzigen.UseVisualStyleBackColor = True
        '
        'btnBekijken
        '
        Me.btnBekijken.Location = New System.Drawing.Point(5, 6)
        Me.btnBekijken.Name = "btnBekijken"
        Me.btnBekijken.Size = New System.Drawing.Size(75, 23)
        Me.btnBekijken.TabIndex = 32
        Me.btnBekijken.Text = "Bekijken"
        Me.btnBekijken.UseVisualStyleBackColor = True
        '
        'lblAanspreektitel
        '
        Me.lblAanspreektitel.AutoSize = True
        Me.lblAanspreektitel.Location = New System.Drawing.Point(2, 42)
        Me.lblAanspreektitel.Name = "lblAanspreektitel"
        Me.lblAanspreektitel.Size = New System.Drawing.Size(74, 13)
        Me.lblAanspreektitel.TabIndex = 31
        Me.lblAanspreektitel.Text = "Aanspreektitel"
        '
        'AanspreektitelView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(352, 100)
        Me.Controls.Add(Me.btnZkaanspreektitel)
        Me.Controls.Add(Me.txtAanspreektitel)
        Me.Controls.Add(Me.cboZkaanspreektitel)
        Me.Controls.Add(Me.btnNietopslaan)
        Me.Controls.Add(Me.btnOpslaan)
        Me.Controls.Add(Me.btnLaatste)
        Me.Controls.Add(Me.btnVolgende)
        Me.Controls.Add(Me.btnVorige)
        Me.Controls.Add(Me.btnEerste)
        Me.Controls.Add(Me.btnNieuw)
        Me.Controls.Add(Me.btnWijzigen)
        Me.Controls.Add(Me.btnBekijken)
        Me.Controls.Add(Me.lblAanspreektitel)
        Me.Name = "AanspreektitelView"
        Me.Text = "Aanspreektitels"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnZkaanspreektitel As System.Windows.Forms.Button
    Friend WithEvents txtAanspreektitel As System.Windows.Forms.TextBox
    Friend WithEvents cboZkaanspreektitel As System.Windows.Forms.ComboBox
    Friend WithEvents btnNietopslaan As System.Windows.Forms.Button
    Friend WithEvents btnOpslaan As System.Windows.Forms.Button
    Friend WithEvents btnLaatste As System.Windows.Forms.Button
    Friend WithEvents btnVolgende As System.Windows.Forms.Button
    Friend WithEvents btnVorige As System.Windows.Forms.Button
    Friend WithEvents btnEerste As System.Windows.Forms.Button
    Friend WithEvents btnNieuw As System.Windows.Forms.Button
    Friend WithEvents btnWijzigen As System.Windows.Forms.Button
    Friend WithEvents btnBekijken As System.Windows.Forms.Button
    Friend WithEvents lblAanspreektitel As System.Windows.Forms.Label
End Class
