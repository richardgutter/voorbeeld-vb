Imports System.Data.OleDb

Public Class ZkklachtDlg

    Private m_project As String
    Private m_afgehandeld As Boolean

    Public Property Project() As String
        Get
            Return m_project
        End Get
        Set(ByVal value As String)
            m_project = value
        End Set
    End Property

    Public Property Afgehandeld() As String
        Get
            Return m_afgehandeld
        End Get
        Set(ByVal value As String)
            m_afgehandeld = value
        End Set
    End Property

    Private Sub ZkklachtDlg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim m_strconn As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Richard\Documents\databases\EPACENTRUM\eaisIVnieuwdataII.mdb"
        Dim m_connection As New OleDbConnection(m_strconn)

        Dim m_sqlstring_nietafgehandeld As String = "SELECT tbl_klant.*, tbl_klacht.omschrijving, tbl_klacht.urgent" _
                                            & " FROM tbl_klacht INNER JOIN tbl_klant ON tbl_klacht.projectcode = tbl_klant.projectcode" _
                                            & " WHERE (((tbl_klacht.definitieve_afhandelingsdatum) Is Null)) ORDER BY tbl_klant.projectcode"

        Dim m_sqlstring_afgehandeld As String = "SELECT tbl_klant.*, tbl_klacht.omschrijving, tbl_klacht.urgent" _
                                            & " FROM tbl_klacht INNER JOIN tbl_klant ON tbl_klacht.projectcode = tbl_klant.projectcode" _
                                            & " WHERE (((tbl_klacht.definitieve_afhandelingsdatum) Is Not Null)) ORDER BY tbl_klant.projectcode"

        Dim m_sql_string As String

        If m_afgehandeld Then
            m_sql_string = m_sqlstring_afgehandeld
            Me.Text = "Afgehandelde klachten zoeken"
        Else
            m_sql_string = m_sqlstring_nietafgehandeld
            Me.Text = "Onafgehandelde klachten zoeken"
        End If
        Dim m_command = New OleDbCommand(m_sql_string, m_connection)

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

            If m_datareader("urgent") Then
                m_item.SubItems.Add("Ja")
            Else
                m_item.SubItems.Add("Nee")
            End If
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
            If Not IsDBNull(m_datareader("omschrijving")) Then
                m_item.SubItems.Add(m_datareader("omschrijving"))
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