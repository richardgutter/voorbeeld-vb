Imports System.Data.OleDb

Public Class ZkprojectcodeDlg

    Private m_projectcode As String

    Public Property Projectcode() As String
        Get
            Return m_projectcode
        End Get
        Set(ByVal value As String)
            m_projectcode = value
        End Set
    End Property

    Private Sub ZkprojectcodeDlg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim m_strconn As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Richard\Documents\databases\EPACENTRUM\eaisIVnieuwdataII.mdb"
        Dim m_connection As New OleDbConnection(m_strconn)
        Dim m_command = New OleDbCommand("Select * FROM tbl_projectcode ORDER BY projectcode", m_connection)

        m_command.Connection.Open()
        Dim m_datareader As OleDbDataReader = m_command.ExecuteReader()

        Me.Cursor() = Cursors.WaitCursor
        While m_datareader.Read()
            Dim m_item As New ListViewItem
            m_item.Text = m_datareader("projectcode")
            If Not IsDBNull(m_datareader("omschrijving")) Then
                m_item.SubItems.Add(m_datareader("omschrijving"))
            Else
                m_item.SubItems.Add("")
            End If
            Zkprojectcodelist.Items.Add(m_item)
        End While
        Me.Cursor() = Cursors.Arrow

        m_command.Connection.Close()

    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim m_item As New ListViewItem

        If Zkprojectcodelist.SelectedItems.Count = 1 Then
            For Each m_item In Zkprojectcodelist.SelectedItems
                m_projectcode = m_item.SubItems(0).Text
            Next
        Else
            m_projectcode = ""
        End If
    End Sub

    Private Sub Zkprojectcodelist_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Zkprojectcodelist.MouseDoubleClick
        btnOK_Click(sender, e)
        Me.DialogResult = vbOK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        m_projectcode = ""
    End Sub

End Class