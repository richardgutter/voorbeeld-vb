Imports System.Data.OleDb

Public Class ZkprojectopcodeDlg

    Private m_project As String
    
    Public Property Project() As String
        Get
            Return m_project
        End Get
        Set(ByVal value As String)
            m_project = value
        End Set
    End Property

    Private Sub ZkprojectopcodeDlg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim m_strconn As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Richard\Documents\databases\EPACENTRUM\eaisIVnieuwdataII.mdb"
        Dim m_connection As New OleDbConnection(m_strconn)
        Dim m_command = New OleDbCommand("Select * FROM tbl_klant ORDER BY projectcode", m_connection)

        Dim m_naam As String
        Dim m_adres As String

        m_command.Connection.Open()
        Dim m_datareader As OleDbDataReader = m_command.ExecuteReader()

        Me.Cursor() = Cursors.WaitCursor
        While m_datareader.Read()
            Dim m_item As New ListViewItem
            m_item.Text = m_datareader("projectcode")

            m_naam = m_datareader("achternaam") & ", " & m_datareader("voorletters") & m_datareader("tussenvoegsels")
            m_adres = m_datareader("EPA_straat") & " " & m_datareader("EPA_huisnummer") & " " & m_datareader("EPA_postcode") & " " & m_datareader("EPA_plaats")

            If m_naam <> "" Then
                m_item.SubItems.Add(m_naam)
            Else
                m_item.SubItems.Add("")
            End If
            If m_adres <> "" Then
                m_item.SubItems.Add(m_adres)
            Else
                m_item.SubItems.Add("")
            End If
            Zkprojectlist.Items.Add(m_item)
        End While
        Me.Cursor() = Cursors.Arrow

        m_command.Connection.Close()

    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim m_item As New ListViewItem

        If Zkprojectlist.SelectedItems.Count = 1 Then
            For Each m_item In Zkprojectlist.SelectedItems
                m_project = m_item.SubItems(0).Text
             Next
        Else
            m_project = ""
         End If
    End Sub

    Private Sub Zkprojectlist_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Zkprojectlist.MouseDoubleClick
        btnOK_Click(sender, e)
        Me.DialogResult = vbOK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        m_project = ""
    End Sub

End Class