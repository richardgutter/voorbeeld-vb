Imports System.Data.OleDb

Public Class ZkepatypeDlg

    Private m_epatype As String
    Private m_epatype_id As String

    Public Property Epatype() As String
        Get
            Return m_epatype
        End Get
        Set(ByVal value As String)
            m_epatype = value
        End Set
    End Property

    Public Property Epatype_id() As String
        Get
            Return m_epatype_id
        End Get
        Set(ByVal value As String)
            m_epatype_id = value
        End Set
    End Property

    Private Sub ZkepatypeDlg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim m_strconn As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Richard\Documents\databases\EPACENTRUM\eaisIVnieuwdataII.mdb"
        Dim m_connection As New OleDbConnection(m_strconn)
        Dim m_command = New OleDbCommand("Select * FROM tbl_EPA_type ORDER BY EPA_type", m_connection)
        
        m_command.Connection.Open()
        Dim m_datareader As OleDbDataReader = m_command.ExecuteReader()

        Me.Cursor() = Cursors.WaitCursor
        While m_datareader.Read()
            Dim m_item As New ListViewItem
            m_item.Text = m_datareader("EPA_type")
            If Not IsDBNull(m_datareader("omschrijving")) Then
                m_item.SubItems.Add(m_datareader("omschrijving"))
            Else
                m_item.SubItems.Add("")
            End If
            m_item.SubItems.Add(m_datareader("EPA_type_ID"))
            Zkepatypelist.Items.Add(m_item)
        End While
        Me.Cursor() = Cursors.Arrow

        m_command.Connection.Close()

    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim m_item As New ListViewItem

        If Zkepatypelist.SelectedItems.Count = 1 Then
            For Each m_item In Zkepatypelist.SelectedItems
                m_epatype = m_item.SubItems(0).Text
                m_epatype_id = m_item.SubItems(1).Text
            Next
        Else
            m_epatype = ""
            m_epatype_id = ""
        End If
    End Sub

    Private Sub ZkEPATypeList_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Zkepatypelist.MouseDoubleClick
        btnOK_Click(sender, e)
        Me.DialogResult = vbOK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        m_epatype = ""
        m_epatype_id = ""
    End Sub
End Class