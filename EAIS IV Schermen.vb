Imports System.Windows.Forms

Public Class EAISIVSchermen

    Private m_ChildFormNumber As Integer
    Private m_epatypeviewed As Boolean
    Private m_epavestigingviewed As Boolean
    Private m_aanpreektitelviewed As Boolean
    Private m_projectcodeviewed As Boolean
    Private m_adviseurviewed As Boolean
    Private m_klantviewed As Boolean
    Private m_klachtviewed As Boolean
    Private m_adviseurtoewijzenviewed As Boolean
    Private m_bezoektrajectiewed As Boolean
    Private m_rapporttrajectviewed As Boolean
    Private m_eindcontroleviewed As Boolean
    Private m_vervolgtrajectviewed As Boolean
    Private m_totaaloverzichtviewed As Boolean

    Public Property Epatypeviewed() As String
        Get
            Return m_epatypeviewed
        End Get
        Set(ByVal value As String)
            m_epatypeviewed = value
        End Set
    End Property

    Public Property Epavestigingviewed() As String
        Get
            Return m_epavestigingviewed
        End Get
        Set(ByVal value As String)
            m_epavestigingviewed = value
        End Set
    End Property

    Public Property Aanpreektitelviewed() As String
        Get
            Return m_aanpreektitelviewed
        End Get
        Set(ByVal value As String)
            m_aanpreektitelviewed = value
        End Set
    End Property

    Public Property Projectcodeviewed() As String
        Get
            Return m_projectcodeviewed
        End Get
        Set(ByVal value As String)
            m_projectcodeviewed = value
        End Set
    End Property

    Public Property Adviseurviewed() As String
        Get
            Return m_adviseurviewed
        End Get
        Set(ByVal value As String)
            m_adviseurviewed = value
        End Set
    End Property

    Public Property Klantviewed() As String
        Get
            Return m_klantviewed
        End Get
        Set(ByVal value As String)
            m_klantviewed = value
        End Set
    End Property

    Public Property Klachtviewed() As String
        Get
            Return m_klachtviewed
        End Get
        Set(ByVal value As String)
            m_klachtviewed = value
        End Set
    End Property

    Public Property Adviseurtoewijzenviewed() As String
        Get
            Return m_adviseurtoewijzenviewed
        End Get
        Set(ByVal value As String)
            m_adviseurtoewijzenviewed = value
        End Set
    End Property

    Public Property Bezoektrajectiewed() As String
        Get
            Return m_bezoektrajectiewed
        End Get
        Set(ByVal value As String)
            m_bezoektrajectiewed = value
        End Set
    End Property

    Public Property Rapporttrajectviewed() As String
        Get
            Return m_rapporttrajectviewed
        End Get
        Set(ByVal value As String)
            m_rapporttrajectviewed = value
        End Set
    End Property

    Public Property Eindcontroleviewed() As String
        Get
            Return m_eindcontroleviewed
        End Get
        Set(ByVal value As String)
            m_eindcontroleviewed = value
        End Set
    End Property

    Public Property Vervolgtrajectviewed() As String
        Get
            Return m_vervolgtrajectviewed
        End Get
        Set(ByVal value As String)
            m_vervolgtrajectviewed = value
        End Set
    End Property

    Public Property Totaaloverzichtviewed() As String
        Get
            Return m_totaaloverzichtviewed
        End Get
        Set(ByVal value As String)
            m_totaaloverzichtviewed = value
        End Set
    End Property

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs) Handles NewToolStripMenuItem.Click, NewToolStripButton.Click, NewWindowToolStripMenuItem.Click
        ' Create a new instance of the child form.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Window " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs) Handles OpenToolStripMenuItem.Click, OpenToolStripButton.Click
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Add code here to open the file.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Add code here to save the current contents of the form to a file.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CutToolStripMenuItem.Click
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CopyToolStripMenuItem.Click
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PasteToolStripMenuItem.Click
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub

    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolBarToolStripMenuItem.Click
        Me.ToolStrip.Visible = Me.ToolBarToolStripMenuItem.Checked
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StatusBarToolStripMenuItem.Click
        Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ArrangeIconsToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private Sub EAISIVSchermen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        m_epatypeviewed = False
        m_epavestigingviewed = False
        m_aanpreektitelviewed = False
        m_projectcodeviewed = False
        m_adviseurviewed = False
        m_klantviewed = False
        m_klachtviewed = False
    End Sub

    Private Sub EPATypenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EPATypenToolStripMenuItem.Click
        Dim m_epatypeview As New EpatypeView

        If Not m_epatypeviewed Then
            m_epatypeviewed = True
            m_epatypeview.MdiParent = Me
            m_epatypeview.Show()
        End If
    End Sub

    Private Sub EPAVestigingenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EPAVestigingenToolStripMenuItem.Click
        Dim m_epavestigingview As New EpavestigingView

        If Not m_epavestigingviewed Then
            m_epavestigingviewed = True
            m_epavestigingview.MdiParent = Me
            m_epavestigingview.Show()
        End If
    End Sub

    Private Sub AanspreektitelsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AanspreektitelsToolStripMenuItem.Click
        Dim m_aanspreektitelview As New AanspreektitelView

        If Not m_aanpreektitelviewed Then
            m_aanpreektitelviewed = True
            m_aanspreektitelview.MdiParent = Me
            m_aanspreektitelview.Show()
        End If
    End Sub

    Private Sub ProjectcodesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProjectcodesToolStripMenuItem.Click
        Dim m_projectcodeview As New ProjectcodeView

        If Not m_projectcodeviewed Then
            m_projectcodeviewed = True
            m_projectcodeview.MdiParent = Me
            m_projectcodeview.Show()
        End If
    End Sub

    Private Sub AdviseursToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdviseursToolStripMenuItem.Click
        Dim m_adviseursview As New AdviseurView

        If Not m_adviseurviewed Then
            m_adviseurviewed = True
            m_adviseursview.MdiParent = Me
            m_adviseursview.Show()
        End If
    End Sub

    Private Sub KlantenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KlantenToolStripMenuItem.Click
        Dim m_klantview As New KlantView

        If Not m_klantviewed Then
            m_klantviewed = True
            m_klantview.MdiParent = Me
            m_klantview.Show()
        End If
    End Sub

    Private Sub KlachtenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KlachtenToolStripMenuItem.Click
        Dim m_klachtview As New KlachtView

        If Not m_klachtviewed Then
            m_klachtviewed = True
            m_klachtview.MdiParent = Me
            m_klachtview.Show()
        End If
    End Sub

    Private Sub AdviseurToewijzenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdviseurToewijzenToolStripMenuItem.Click
        Dim m_adviseurtoewijzenview As New AdviseurtoewijzenView

        If Not m_adviseurtoewijzenviewed Then
            m_adviseurtoewijzenviewed = True
            m_adviseurtoewijzenview.MdiParent = Me
            m_adviseurtoewijzenview.Show()
        End If
    End Sub

    Private Sub BezoektrajectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BezoektrajectToolStripMenuItem.Click
        Dim m_bezoektrajectiew As New BezoektrajectView

        If Not m_bezoektrajectiewed Then
            m_bezoektrajectiewed = True
            m_bezoektrajectiew.MdiParent = Me
            m_bezoektrajectiew.Show()
        End If
    End Sub

    Private Sub RapporttrajectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RapporttrajectToolStripMenuItem.Click
        Dim m_rapporttrajectview As New RapporttrajectView

        If Not m_rapporttrajectviewed Then
            m_rapporttrajectviewed = True
            m_rapporttrajectview.MdiParent = Me
            m_rapporttrajectview.Show()
        End If
    End Sub

    Private Sub EindcontroleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EindcontroleToolStripMenuItem.Click
        Dim m_eindcontroleview As New EindcontroleView

        If Not m_eindcontroleviewed Then
            m_eindcontroleviewed = True
            m_eindcontroleview.MdiParent = Me
            m_eindcontroleview.Show()
        End If
    End Sub

    Private Sub VervolgtrajectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VervolgtrajectToolStripMenuItem.Click
        Dim m_vervolgtrajectview As New VervolgtrajectView

        If Not m_vervolgtrajectviewed Then
            m_vervolgtrajectviewed = True
            m_vervolgtrajectview.MdiParent = Me
            m_vervolgtrajectview.Show()
        End If
    End Sub

    Private Sub TotaalOverzichtToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TotaalOverzichtToolStripMenuItem.Click
        Dim m_totaaloverzichtview As New TotaaloverzichtView

        If Not m_totaaloverzichtviewed Then
            m_totaaloverzichtviewed = True
            m_totaaloverzichtview.MdiParent = Me
            m_totaaloverzichtview.Show()
        End If
    End Sub
End Class
