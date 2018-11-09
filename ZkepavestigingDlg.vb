Imports System.Data.OleDb

Public Class ZkepavestigingDlg

    Private m_epavestiging As String
    Private m_epavestiging_id As String

    Public Property Epavestiging() As String
        Get
            Return m_epavestiging
        End Get
        Set(ByVal value As String)
            m_epavestiging = value
        End Set
    End Property

    Public Property Epavestiging_id() As String
        Get
            Return m_epavestiging_id
        End Get
        Set(ByVal value As String)
            m_epavestiging_id = value
        End Set
    End Property

    Private Sub ZkepavestigingDlg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim m_strconn As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Richard\Documents\databases\EPACENTRUM\eaisIVnieuwdataII.mdb"
        Dim m_connection As New OleDbConnection(m_strconn)
        Dim m_command = New OleDbCommand("Select * FROM tbl_EPA_vestiging ORDER BY EPA_vestiging", m_connection)

        m_command.Connection.Open()
        Dim m_datareader As OleDbDataReader = m_command.ExecuteReader()

        Me.Cursor() = Cursors.WaitCursor
        While m_datareader.Read()
            Dim m_item As New ListViewItem
            m_item.Text = m_datareader("EPA_vestiging")
            m_item.SubItems.Add(m_datareader("EPA_vestiging_ID"))
            'm_item.Text = m_datareader("EPA_vestiging")
            Zkepavestiginglist.Items.Add(m_item)
        End While
        Me.Cursor() = Cursors.Arrow

        m_command.Connection.Close()

    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim m_item As New ListViewItem

        If Zkepavestiginglist.SelectedItems.Count = 1 Then
            For Each m_item In Zkepavestiginglist.SelectedItems
                m_epavestiging = m_item.SubItems(0).Text
                m_epavestiging_id = m_item.SubItems(1).Text
            Next
        Else
            m_epavestiging = ""
            m_epavestiging_id = ""
        End If
    End Sub

    Private Sub Zkepavestiginglist_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Zkepavestiginglist.MouseDoubleClick
        btnOK_Click(sender, e)
        Me.DialogResult = vbOK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        m_epavestiging = ""
        m_epavestiging_id = ""
    End Sub

End Class