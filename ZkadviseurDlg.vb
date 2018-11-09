Imports System.Data.OleDb

Public Class ZkadviseurDlg

    Private m_adviseur As String
    Private m_adviseur_achtervoor As String
    Private m_adviseur_id As String

    Public Property Adviseur() As String
        Get
            Return m_adviseur
        End Get
        Set(ByVal value As String)
            m_adviseur = value
        End Set
    End Property

    Public Property Adviseur(ByVal m_par As String) As String
        Get
            Return m_adviseur_achtervoor
        End Get
        Set(ByVal value As String)
            m_adviseur_achtervoor = value
        End Set
    End Property

    Public Property Adviseur_id() As String
        Get
            Return m_adviseur_id
        End Get
        Set(ByVal value As String)
            m_adviseur_id = value
        End Set
    End Property

    Private Sub ZkadviseurDlg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim m_strconn As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Richard\Documents\databases\EPACENTRUM\eaisIVnieuwdataII.mdb"
        Dim m_connection As New OleDbConnection(m_strconn)
        Dim m_command = New OleDbCommand("Select * FROM tbl_adviseur ORDER BY achternaam", m_connection)

        m_command.Connection.Open()
        Dim m_datareader As OleDbDataReader = m_command.ExecuteReader()

        Me.Cursor() = Cursors.WaitCursor
        While m_datareader.Read()
            Dim m_item As New ListViewItem
            m_item.Text = m_datareader("achternaam")
            If Not IsDBNull(m_datareader("voornaam")) Then
                m_item.SubItems.Add(m_datareader("voornaam"))
            Else
                m_item.SubItems.Add("")
            End If
            m_item.SubItems.Add(m_datareader("adviseur_id"))
            Zkadviseurlist.Items.Add(m_item)
        End While
        Me.Cursor() = Cursors.Arrow

        m_command.Connection.Close()

    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim m_item As New ListViewItem

        If Zkadviseurlist.SelectedItems.Count = 1 Then
            For Each m_item In Zkadviseurlist.SelectedItems
                m_adviseur = m_item.SubItems(0).Text
                m_adviseur_achtervoor = m_item.SubItems(0).Text & ", " & m_item.SubItems(1).Text
                m_adviseur_id = m_item.SubItems(2).Text
            Next
        Else
            m_adviseur = ""
            m_adviseur_achtervoor = ""
            m_adviseur_id = ""
        End If
    End Sub

    Private Sub ZkadviseurDlg_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Zkadviseurlist.MouseDoubleClick
        btnOK_Click(sender, e)
        Me.DialogResult = vbOK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        m_adviseur = ""
        m_adviseur_achtervoor = ""
        m_adviseur_id = ""
    End Sub

End Class