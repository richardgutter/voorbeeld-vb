<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ZkprojectzonderklachtDlg
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
        Me.btnOK = New System.Windows.Forms.Button()
        Me.Zkprojectlist = New System.Windows.Forms.ListView()
        Me.chProject = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chNaam = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chEpaadres = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(331, 332)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 7
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'Zkprojectlist
        '
        Me.Zkprojectlist.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chProject, Me.chNaam, Me.chEpaadres})
        Me.Zkprojectlist.FullRowSelect = True
        Me.Zkprojectlist.Location = New System.Drawing.Point(12, 12)
        Me.Zkprojectlist.Name = "Zkprojectlist"
        Me.Zkprojectlist.ShowGroups = False
        Me.Zkprojectlist.Size = New System.Drawing.Size(475, 314)
        Me.Zkprojectlist.TabIndex = 6
        Me.Zkprojectlist.UseCompatibleStateImageBehavior = False
        Me.Zkprojectlist.View = System.Windows.Forms.View.Details
        '
        'chProject
        '
        Me.chProject.Text = "Project"
        Me.chProject.Width = 67
        '
        'chNaam
        '
        Me.chNaam.Text = "Naam"
        Me.chNaam.Width = 162
        '
        'chEpaadres
        '
        Me.chEpaadres.Text = "EPA-Adres"
        Me.chEpaadres.Width = 228
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(412, 332)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Zkprojectzonderklacht
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(499, 364)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.Zkprojectlist)
        Me.Controls.Add(Me.btnCancel)
        Me.Name = "Zkprojectzonderklacht"
        Me.Text = "Project zonder klacht zoeken"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents Zkprojectlist As System.Windows.Forms.ListView
    Friend WithEvents chProject As System.Windows.Forms.ColumnHeader
    Friend WithEvents chNaam As System.Windows.Forms.ColumnHeader
    Friend WithEvents chEpaadres As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
