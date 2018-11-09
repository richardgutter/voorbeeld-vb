Imports System.Data.OleDb

Public Class ZkaanspreektitelDlg

    Private m_aanspreektitel As String
    Private m_aanspreektitel_id As String

    Public Property Aanspreektitel() As String
        Get
            Return m_aanspreektitel
        End Get
        Set(ByVal value As String)
            m_aanspreektitel = value
        End Set
    End Property

    Public Property Aanspreektitel_id() As String
        Get
            Return m_aanspreektitel_id
        End Get
        Set(ByVal value As String)
            m_aanspreektitel_id = value
        End Set
    End Property

    Private Sub ZkaanspreektitelDlg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim m_strconn As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Richard\Documents\databases\EPACENTRUM\eaisIVnieuwdataII.mdb"
        Dim m_connection As New OleDbConnection(m_strconn)
        Dim m_command = New OleDbCommand("Select * FROM tbl_aanspreektitel ORDER BY aanspreektitel", m_connection)

        m_command.Connection.Open()
        Dim m_datareader As OleDbDataReader = m_command.ExecuteReader()

        Me.Cursor() = Cursors.WaitCursor
        While m_datareader.Read()
            Dim m_item As New ListViewItem
            m_item.Text = m_datareader("aanspreektitel")
            m_item.SubItems.Add(m_datareader("aanspreektitel_ID"))
            Zkaanspreektitellist.Items.Add(m_item)
        End While
        Me.Cursor() = Cursors.Arrow

        m_command.Connection.Close()

    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim m_item As New ListViewItem

        If Zkaanspreektitellist.SelectedItems.Count = 1 Then
            For Each m_item In Zkaanspreektitellist.SelectedItems
                m_aanspreektitel = m_item.SubItems(0).Text
                m_aanspreektitel_id = m_item.SubItems(1).Text
            Next
        Else
            m_aanspreektitel = ""
            m_aanspreektitel_id = ""
        End If
    End Sub

    Private Sub Zkaanspreektitellist_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Zkaanspreektitellist.MouseDoubleClick
        btnOK_Click(sender, e)
        Me.DialogResult = vbOK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        m_aanspreektitel = ""
        m_aanspreektitel_id = ""
    End Sub

End Class