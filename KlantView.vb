Imports System.Data.OleDb
Imports System.String

Public Class KlantView

    Private m_maxklant_id As Integer
    Private m_maxproject_id As Integer

    Private m_sqlstring As String = "SELECT tbl_klant.*, tbl_project.projectcode, tbl_project.code, tbl_project.volgnummer, tbl_project.opdrachtdatum_opdrachtgever, tbl_project.opdrachtdatum_EPA_centrum, tbl_project.aangebracht_door, tbl_project.EPA_type, tbl_project.verkort_traject, tbl_project.adviseur_ID, tbl_project.toewijzing_adviseur, tbl_project.LabelGenAfm, tbl_project.opmerkingen_opdrachtgever, tbl_project.datum_nieuw," _
    & " [tbl_adviseur]![achternaam] & ', ' &  [tbl_adviseur]![voornaam] AS adviseur, tbl_project.project_ID FROM tbl_adviseur  RIGHT JOIN (tbl_project INNER JOIN tbl_klant ON tbl_project.projectcode = tbl_klant.projectcode) ON tbl_adviseur.adviseur_ID = tbl_project.adviseur_ID ORDER BY tbl_project.projectcode"

    Private m_tonen As Boolean
    Private m_nieuw As Boolean
    Private m_wijzigen As Boolean

    Private m_strconn As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Richard\Documents\databases\EPACENTRUM\eaisIVnieuwdataII.mdb"
    Private m_connection As New OleDbConnection(m_strconn)
    Private m_dataadapter As New OleDbDataAdapter(m_sqlstring, m_connection)
    Private m_commandbuilder As New OleDbCommandBuilder(m_dataadapter)
    Private m_dataset As New DataSet
    Private m_datarow As DataRow
    Private m_dataadapter2 As New OleDbDataAdapter("Select * FROM tbl_klant ORDER BY projectcode", m_connection)
    Private m_commandbuilder2 As New OleDbCommandBuilder(m_dataadapter2)
    Private m_dataset2 As New DataSet
    Private m_datarow2 As DataRow
    Private m_dataadapter3 As New OleDbDataAdapter("Select * FROM tbl_project ORDER BY projectcode", m_connection)
    Private m_commandbuilder3 As New OleDbCommandBuilder(m_dataadapter3)
    Private m_dataset3 As New DataSet
    Private m_datarow3 As DataRow

    Private m_bindingsource As New BindingSource
    Private DBNull As Object

    Private Sub KlantView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        m_dataadapter.Fill(m_dataset, "tbl_klant")
        m_bindingsource.DataSource = m_dataset.Tables("tbl_klant")

        m_dataadapter2.Fill(m_dataset2, "tbl_klant2")
        m_dataadapter3.Fill(m_dataset3, "tbl_project")

        'm_combovisible = False
        'If m_combovisible Then
        '    cboZkadviseur.Visible = m_combovisible
        '    cboZkadviseur.ValueMember = "achternaam"
        '    Dim m_command_zk = New OleDbCommand("SELECT achternaam, voornaam FROM tbl_adviseur ORDER BY achternaam DESC", m_connection)
        '    m_command_zk.Connection.Open()
        '    Dim m_datareader_zk As OleDbDataReader = m_command_zk.ExecuteReader()
        '    Me.Cursor() = Cursors.WaitCursor
        '    While m_datareader_zk.Read()
        '        cboZkadviseur.Items.Add(m_datareader_zk("achternaam") & ", " & m_datareader_zk("voornaam"))
        '    End While
        '    Me.Cursor() = Cursors.Arrow
        '    m_command_zk.Connection.Close()
        'End If

        Dim m_command_maxklant = New OleDbCommand("SELECT MAX(klant_ID) FROM tbl_klant", m_connection)

        m_command_maxklant.Connection.Open()
        Dim m_datareader_maxklant As OleDbDataReader = m_command_maxklant.ExecuteReader(CommandBehavior.CloseConnection)

        m_datareader_maxklant.Read()
        If Not IsDBNull(m_datareader_maxklant(0)) Then
            m_maxklant_id = m_datareader_maxklant(0)
        Else
            m_maxklant_id = 0
        End If

        m_command_maxklant.Connection.Close()

        Dim m_command_maxproject = New OleDbCommand("SELECT MAX(project_ID) FROM tbl_project", m_connection)

        m_command_maxproject.Connection.Open()
        Dim m_datareader_maxproject As OleDbDataReader = m_command_maxproject.ExecuteReader(CommandBehavior.CloseConnection)

        m_datareader_maxproject.Read()
        If Not IsDBNull(m_datareader_maxproject(0)) Then
            m_maxproject_id = m_datareader_maxproject(0)
        Else
            m_maxproject_id = 0
        End If

        m_command_maxproject.Connection.Close()

        txtProjectcode.ReadOnly = True
        txtAdviseur.ReadOnly = True
        txtVolgnummer.ReadOnly = True
        txtProject.ReadOnly = True
        txtAanspreektitel.ReadOnly = True
        txtEpatype.ReadOnly = True

        If m_bindingsource.Count() > 0 Then
            btnBekijken_Click()
        Else
            btnNieuw_Click()
        End If

    End Sub

    Private Sub btnBekijken_Click() Handles btnBekijken.Click
        'Private Sub btnBekijken_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBekijken.Click

        Me.Text = "Klant - BEKIJKEN"

        m_tonen = True
        m_nieuw = False
        m_wijzigen = False

        'GetDlgItem(IDC_MENU_BUTTON)->ShowWindow(SW_SHOW);
        'GetDlgItem(IDC_CODE_BUTTON)->ShowWindow(SW_SHOW);

        veldenediten(False)
        If m_bindingsource.Count() > 0 Then
            recordweergeven()
        Else
            veldenleegmaken()
        End If

        lblProject.Visible() = True
        txtProject.Visible() = True
        btnZkproject.Visible() = True
        lblProjectcode.Visible() = False
        txtProjectcode.Visible() = False
        txtVolgnummer.Visible() = False
        btnZkprojectcode.Visible() = False
        btnZkaanspreektitel.Visible() = False
        btnZkepatype.Visible() = False
        btnZkadviseur.Visible() = False

        btnEerste.Visible() = True
        btnVorige.Visible() = True
        btnVolgende.Visible() = True
        btnLaatste.Visible() = True

        btnOpslaan.Visible() = False
        btnNietOpslaan.Visible() = False

        m_datarow = m_dataset.Tables("tbl_klant")(m_bindingsource.Position())
        m_datarow2 = m_dataset2.Tables("tbl_klant2")(m_bindingsource.Position())
        m_datarow3 = m_dataset3.Tables("tbl_project")(m_bindingsource.Position())

    End Sub

    Private Sub btnWijzigen_Click() Handles btnWijzigen.Click

        Me.Text = "Klant - WIJZIGEN"

        m_tonen = False
        m_nieuw = False
        m_wijzigen = True

        'GetDlgItem(IDC_MENU_BUTTON)->ShowWindow(SW_SHOW);
        'GetDlgItem(IDC_CODE_BUTTON)->ShowWindow(SW_SHOW);

        veldenediten(True)
        If m_bindingsource.Count() > 0 Then
            recordweergeven()
        Else
            veldenleegmaken()
        End If

        lblProject.Visible() = True
        txtProject.Visible() = True
        btnZkproject.Visible() = True
        lblProjectcode.Visible() = False
        txtProjectcode.Visible() = False
        txtVolgnummer.Visible() = False
        btnZkprojectcode.Visible() = False
        btnZkaanspreektitel.Visible() = True
        btnZkepatype.Visible() = True
        btnZkadviseur.Visible() = True

        btnEerste.Visible() = True
        btnVorige.Visible() = True
        btnVolgende.Visible() = True
        btnLaatste.Visible() = True

        btnOpslaan.Visible() = True
        btnNietOpslaan.Visible() = True

    End Sub

    Private Sub btnNieuw_Click() Handles btnNieuw.Click

        Me.Text = "Klant - TOEVOEGEN"

        m_tonen = False
        m_nieuw = True
        m_wijzigen = False

        'GetDlgItem(IDC_MENU_BUTTON)->ShowWindow(SW_HIDE);
        'GetDlgItem(IDC_CODE_BUTTON)->ShowWindow(SW_HIDE);

        veldenediten(True)
        veldenleegmaken()

        lblProject.Visible() = False
        txtProject.Visible() = False
        btnZkproject.Visible() = False
        lblProjectcode.Visible() = True
        txtProjectcode.Visible() = True
        txtVolgnummer.Visible() = True
        btnZkprojectcode.Visible() = True
        btnZkaanspreektitel.Visible() = True
        btnZkepatype.Visible() = True
        btnZkadviseur.Visible() = True

        btnEerste.Visible() = False
        btnVorige.Visible() = False
        btnVolgende.Visible() = False
        btnLaatste.Visible() = False

        btnOpslaan.Visible() = True
        btnNietOpslaan.Visible() = True

    End Sub

    Private Sub btnEerste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEerste.Click

        m_bindingsource.MoveFirst()
        recordweergeven()

    End Sub

    Private Sub btnVorige_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVorige.Click

        m_bindingsource.MovePrevious()
        recordweergeven()

    End Sub

    Private Sub btnVolgende_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVolgende.Click

        m_bindingsource.MoveNext()
        recordweergeven()

    End Sub

    Private Sub btnLaatste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLaatste.Click

        m_bindingsource.MoveLast()
        recordweergeven()

    End Sub

    Private Sub btnOpslaan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpslaan.Click

        If (OpslaanCheck()) Then
            If (m_nieuw) Then
                m_datarow = m_dataset.Tables("tbl_klant").NewRow
                m_datarow2 = m_dataset2.Tables("tbl_klant2").NewRow
                m_datarow3 = m_dataset3.Tables("tbl_project").NewRow
                inhoudvullen()
                inhoudvullen_klant()
                inhoudvullen_project()
                m_dataset.Tables("tbl_klant").Rows.Add(m_datarow)
                m_datarow = m_dataset.Tables("tbl_klant")(m_bindingsource.Position())
                m_dataset2.Tables("tbl_klant2").Rows.Add(m_datarow2)
                m_dataadapter2.Update(m_dataset2, "tbl_klant2")
                m_datarow2 = m_dataset2.Tables("tbl_klant2")(m_bindingsource.Position())
                m_dataset3.Tables("tbl_project").Rows.Add(m_datarow3)
                m_dataadapter3.Update(m_dataset3, "tbl_project")
                veldenleegmaken()
            ElseIf (m_wijzigen) Then
                m_datarow2 = m_dataset2.Tables("tbl_klant2")(m_bindingsource.Position())
                m_datarow3 = m_dataset3.Tables("tbl_project")(m_bindingsource.Position())
                inhoudvullen()
                inhoudvullen_klant()
                inhoudvullen_project()
                m_dataadapter2.Update(m_dataset2, "tbl_klant2")
                m_dataadapter3.Update(m_dataset3, "tbl_project")
            End If
        End If
    End Sub

    Function Volgnummer_ophogen(ByVal code As String)
        Dim m_volgnummer As Integer
        Dim m_sqlstring As String = "SELECT * FROM tbl_projectcode Where projectcode = '" & code & "'"

        Dim m_command_volgnummer = New OleDbCommand(m_sqlstring, m_connection)
        Dim m_dataadapter_volgnummer As New OleDbDataAdapter(m_sqlstring, m_connection)
        Dim m_commandbuilder_volgnummer As New OleDbCommandBuilder(m_dataadapter_volgnummer)
        Dim m_dataset_volgnummer As New DataSet
        Dim m_datarow_volgnummer As DataRow

        m_command_volgnummer.Connection.Open()
        Dim m_datareader_volgnummer As OleDbDataReader = m_command_volgnummer.ExecuteReader(CommandBehavior.CloseConnection)

        m_datareader_volgnummer.Read()
        If Not IsDBNull(m_datareader_volgnummer(2)) Then
            m_volgnummer = m_datareader_volgnummer(2) + 1
        End If

        m_command_volgnummer.Connection.Close()

        m_dataadapter_volgnummer.Fill(m_dataset_volgnummer, "tbl_projectcode")
        m_datarow_volgnummer = m_dataset_volgnummer.Tables("tbl_projectcode")(0)
        m_datarow_volgnummer.Item(2) = m_volgnummer
        m_dataadapter_volgnummer.Update(m_dataset_volgnummer, "tbl_projectcode")
        
        Return m_volgnummer
    End Function

    Private Sub btnNietOpslaan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNietOpslaan.Click

        If m_nieuw Then
            veldenleegmaken()
        Else
            recordweergeven()
        End If

    End Sub

    Function OpslaanCheck()

        If m_nieuw Then
            If MessageBox.Show("Weet u het zeker dat u deze gegevens wilt toevoegen?",
                               "Gegevens wijzigen", MessageBoxButtons.OKCancel) = vbCancel Then
                Return False
            End If
        End If

        If m_wijzigen Then
            If MessageBox.Show("Weet u het zeker dat u deze gegevens wilt wijzigen?",
                               "Gegevens wijzigen", MessageBoxButtons.OKCancel) = vbCancel Then
                recordweergeven()
                Return False
            End If
        End If

        If txtProjectcode.Text = "" Then
            MessageBox.Show("De projectcode moet ingevuld zijn !\n",
                            "Gegevens wijzigen", MessageBoxButtons.OK)
            Return False
        End If

        If txtPostcode.Text <> "" Then
            If txtPostcode.Text.Length() < 6 Then
                MessageBox.Show("De postcode is niet in het juiste formaat '0000AA' !\n",
                                "Gegevens wijzigen", MessageBoxButtons.OK)
                Return False
            ElseIf Not (IsNumeric(txtPostcode.Text.Substring(0, 4)) _
               And Char.IsLetter(txtPostcode.Text.Substring(4, 1)) And Char.IsLetter(txtPostcode.Text.Substring(5, 1))) Then
                MessageBox.Show("De postcode is niet in het juiste formaat '0000AA' !\n",
                                "Gegevens wijzigen", MessageBoxButtons.OK)
                Return False
            End If
        End If

        If txtEpapostcode.Text <> "" Then
            If txtEpapostcode.Text.Length() < 6 Then
                MessageBox.Show("De postcode is niet in het juiste formaat '0000AA' !\n",
                                "Gegevens wijzigen", MessageBoxButtons.OK)
                Return False
            ElseIf Not (IsNumeric(txtEpapostcode.Text.Substring(0, 4)) _
               And Char.IsLetter(txtEpapostcode.Text.Substring(4, 1)) And Char.IsLetter(txtEpapostcode.Text.Substring(5, 1))) Then
                MessageBox.Show("De postcode is niet in het juiste formaat '0000AA' !\n",
                                "Gegevens wijzigen", MessageBoxButtons.OK)
                Return False
            End If
        End If

        Return True
    End Function

    'Function aanwezig()

    '    Dim m_aanwezig As Boolean

    '    If m_bindingsource.Count() > 0 Then
    '        Me.Cursor() = Cursors.WaitCursor
    '        m_bindingsource.MoveFirst()

    '        m_datarow = m_dataset.Tables("tbl_adviseur")(m_bindingsource.Position())
    '        While m_bindingsource.Position() + 1 < m_bindingsource.Count() And Compare(m_datarow.Item(4), txtAchternaam.Text, False) < 0
    '            m_bindingsource.MoveNext()
    '            m_datarow = m_dataset.Tables("tbl_adviseur")(m_bindingsource.Position())
    '        End While

    '        If Compare(m_datarow.Item(4), txtAchternaam.Text, False) = 0 Then
    '            m_aanwezig = True
    '        Else
    '            m_aanwezig = False
    '        End If
    '        Me.Cursor() = Cursors.Arrow
    '    Else
    '        m_aanwezig = False
    '    End If

    '    Return m_aanwezig
    'End Function

    Private Sub veldenediten(ByVal edit As Boolean)

        txtVoorletters.ReadOnly = Not edit
        txtTussenvoegsels.ReadOnly = Not edit
        txtAchternaam.ReadOnly = Not edit
        txtEpastraat.ReadOnly = Not edit
        txtEpahuisnummer.ReadOnly = Not edit
        txtEpapostcode.ReadOnly = Not edit
        txtEpaplaats.ReadOnly = Not edit
        txtPrive.ReadOnly = Not edit
        txtWerk.ReadOnly = Not edit
        txtMobiel.ReadOnly = Not edit
        txtEmail.ReadOnly = Not edit
        chkVerkorttraject.Enabled = edit
        dtpLabelafgemeld.Enabled = edit
        txtBedrijfsnaam.ReadOnly = Not edit
        txtBedrijfstak.ReadOnly = Not edit
        txtZaak.ReadOnly = Not edit
        txtStraat.ReadOnly = Not edit
        txtHuisnummer.ReadOnly = Not edit
        txtPostcode.ReadOnly = Not edit
        txtPlaats.ReadOnly = Not edit
        dtpOpdrachtgeverdatum.Enabled = edit
        dtpEpacentrumdatum.Enabled = edit
        txtAangebrachtdoor.ReadOnly = Not edit
        txtOpmerkingen.ReadOnly = Not edit

    End Sub

    Private Sub recordweergeven()

        m_datarow = m_dataset.Tables("tbl_klant")(m_bindingsource.Position())
        If Not IsDBNull(m_datarow.Item(22)) Then
            txtProjectcode.Text = m_datarow.Item(22)
        Else
            txtProjectcode.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(1)) Then
            txtProject.Text = m_datarow.Item(1)
        Else
            txtProject.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(23)) Then
            txtVolgnummer.Text = m_datarow.Item(23)
        Else
            txtVolgnummer.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(3)) Then
            txtAanspreektitel.Text = m_datarow.Item(3)
        Else
            txtAanspreektitel.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(4)) Then
            txtVoorletters.Text = m_datarow.Item(4)
        Else
            txtVoorletters.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(5)) Then
            txtTussenvoegsels.Text = m_datarow.Item(5)
        Else
            txtTussenvoegsels.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(6)) Then
            txtAchternaam.Text = m_datarow.Item(6)
        Else
            txtAchternaam.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(16)) Then
            txtEpastraat.Text = m_datarow.Item(16)
        Else
            txtEpastraat.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(17)) Then
            txtEpahuisnummer.Text = m_datarow.Item(17)
        Else
            txtEpahuisnummer.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(18)) Then
            txtEpapostcode.Text = m_datarow.Item(18)
        Else
            txtEpapostcode.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(19)) Then
            txtEpaplaats.Text = m_datarow.Item(19)
        Else
            txtEpaplaats.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(12)) Then
            txtPrive.Text = m_datarow.Item(12)
        Else
            txtPrive.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(13)) Then
            txtWerk.Text = m_datarow.Item(13)
        Else
            txtWerk.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(14)) Then
            txtMobiel.Text = m_datarow.Item(14)
        Else
            txtMobiel.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(15)) Then
            txtEmail.Text = m_datarow.Item(15)
        Else
            txtEmail.Text = ""
        End If
        chkVerkorttraject.Checked() = m_datarow.Item(28)
        If Not IsDBNull(m_datarow.Item(34)) Then
            txtAdviseur.Text = m_datarow.Item(34)
        Else
            txtAdviseur.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(31)) Then
            dtpLabelafgemeld.Text = m_datarow.Item(31)
        Else
            dtpLabelafgemeld.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(2)) Then
            txtBedrijfsnaam.Text = m_datarow.Item(2)
        Else
            txtBedrijfsnaam.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(20)) Then
            txtBedrijfstak.Text = m_datarow.Item(20)
        Else
            txtBedrijfstak.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(11)) Then
            txtZaak.Text = m_datarow.Item(11)
        Else
            txtZaak.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(7)) Then
            txtStraat.Text = m_datarow.Item(7)
        Else
            txtStraat.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(8)) Then
            txtHuisnummer.Text = m_datarow.Item(8)
        Else
            txtHuisnummer.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(9)) Then
            txtPostcode.Text = m_datarow.Item(9)
        Else
            txtPostcode.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(10)) Then
            txtPlaats.Text = m_datarow.Item(10)
        Else
            txtPlaats.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(24)) Then
            dtpOpdrachtgeverdatum.Text = m_datarow.Item(24)
        Else
            dtpOpdrachtgeverdatum.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(25)) Then
            dtpEpacentrumdatum.Text = m_datarow.Item(25)
        Else
            dtpEpacentrumdatum.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(26)) Then
            txtAangebrachtdoor.Text = m_datarow.Item(26)
        Else
            txtAangebrachtdoor.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(27)) Then
            txtEpatype.Text = m_datarow.Item(27)
        Else
            txtEpatype.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(32)) Then
            txtOpmerkingen.Text = m_datarow.Item(32)
        Else
            txtOpmerkingen.Text = ""
        End If

    End Sub

    Private Sub veldenleegmaken()

        txtProject.Text = ""
        txtProjectcode.Text = ""
        txtVolgnummer.Text = ""
        txtAanspreektitel.Text = ""
        txtVoorletters.Text = ""
        txtTussenvoegsels.Text = ""
        txtAchternaam.Text = ""
        txtEpastraat.Text = ""
        txtEpahuisnummer.Text = ""
        txtEpapostcode.Text = ""
        txtEpaplaats.Text = ""
        txtPrive.Text = ""
        txtWerk.Text = ""
        txtMobiel.Text = ""
        txtEmail.Text = ""
        chkVerkorttraject.Checked() = False
        txtAdviseur.Text = ""
        dtpLabelafgemeld.Text = ""
        txtBedrijfsnaam.Text = ""
        txtBedrijfstak.Text = ""
        txtZaak.Text = ""
        txtStraat.Text = ""
        txtHuisnummer.Text = ""
        txtPostcode.Text = ""
        txtPlaats.Text = ""
        dtpOpdrachtgeverdatum.Text = ""
        dtpEpacentrumdatum.Text = ""
        txtAangebrachtdoor.Text = ""
        txtEpatype.Text = ""
        txtOpmerkingen.Text = ""

    End Sub

    Private Sub inhoudvullen()

        Dim m_volgnummer As Integer = Volgnummer_ophogen(txtProjectcode.Text)

        If m_nieuw Then
            m_maxklant_id += 1
            m_maxproject_id += 1
            m_datarow.Item(0) = m_maxklant_id
            m_datarow.Item(35) = m_maxproject_id
            If m_volgnummer < 10 Then
                txtVolgnummer.Text = "000" & CStr(m_volgnummer)
            ElseIf m_volgnummer < 100 Then
                txtVolgnummer.Text = "00" & CStr(m_volgnummer)
            ElseIf m_volgnummer < 1000 Then
                txtVolgnummer.Text = "0" & CStr(m_volgnummer)
            Else
                txtVolgnummer.Text = m_volgnummer
            End If
            txtProject.Text = txtProjectcode.Text & txtVolgnummer.Text
        End If
        If txtProjectcode.Text <> "" Then
            m_datarow.Item(22) = txtProjectcode.Text
        Else
            m_datarow.Item(22) = DBNull
        End If
        If txtProject.Text <> "" Then
            m_datarow.Item(1) = txtProject.Text
        Else
            m_datarow.Item(1) = DBNull
        End If
        If txtProject.Text <> "" Then
            m_datarow.Item(21) = txtProject.Text
        Else
            m_datarow.Item(21) = DBNull
        End If
        If txtVolgnummer.Text <> "" Then
            m_datarow.Item(23) = txtVolgnummer.Text
        Else
            m_datarow.Item(23) = DBNull
        End If
        If txtAanspreektitel.Text <> "" Then
            m_datarow.Item(3) = txtAanspreektitel.Text
        Else
            m_datarow.Item(3) = DBNull
        End If
        If txtVoorletters.Text <> "" Then
            m_datarow.Item(4) = txtVoorletters.Text
        Else
            m_datarow.Item(4) = DBNull
        End If
        If txtTussenvoegsels.Text <> "" Then
            m_datarow.Item(5) = txtTussenvoegsels.Text
        Else
            m_datarow.Item(5) = DBNull
        End If
        If txtAchternaam.Text <> "" Then
            m_datarow.Item(6) = txtAchternaam.Text
        Else
            m_datarow.Item(6) = DBNull
        End If
        If txtEpastraat.Text <> "" Then
            m_datarow.Item(16) = txtEpastraat.Text
        Else
            m_datarow.Item(16) = DBNull
        End If
        If txtEpahuisnummer.Text <> "" Then
            m_datarow.Item(17) = txtEpahuisnummer.Text
        Else
            m_datarow.Item(17) = DBNull
        End If
        If txtEpapostcode.Text <> "" Then
            m_datarow.Item(18) = txtEpapostcode.Text
        Else
            m_datarow.Item(18) = DBNull
        End If
        If txtEpaplaats.Text <> "" Then
            m_datarow.Item(19) = txtEpaplaats.Text
        Else
            m_datarow.Item(19) = DBNull
        End If
        If txtPrive.Text <> "" Then
            m_datarow.Item(12) = txtPrive.Text
        Else
            m_datarow.Item(12) = DBNull
        End If
        If txtWerk.Text <> "" Then
            m_datarow.Item(13) = txtWerk.Text
        Else
            m_datarow.Item(13) = DBNull
        End If
        If txtMobiel.Text <> "" Then
            m_datarow.Item(14) = txtMobiel.Text
        Else
            m_datarow.Item(14) = DBNull
        End If
        If txtEmail.Text <> "" Then
            m_datarow.Item(15) = txtEmail.Text
        Else
            m_datarow.Item(15) = DBNull
        End If

        m_datarow.Item(28) = chkVerkorttraject.Checked()

        If txtAdviseur.Text <> "" Then
            m_datarow.Item(34) = txtAdviseur.Text
        Else
            m_datarow.Item(34) = DBNull
        End If
        If dtpLabelafgemeld.Checked() Then
            m_datarow.Item(31) = dtpLabelafgemeld.Text
        Else
            m_datarow.Item(31) = System.DBNull.Value
        End If
        If txtBedrijfsnaam.Text <> "" Then
            m_datarow.Item(2) = txtBedrijfsnaam.Text
        Else
            m_datarow.Item(2) = DBNull
        End If
        If txtBedrijfstak.Text <> "" Then
            m_datarow.Item(20) = txtBedrijfstak.Text
        Else
            m_datarow.Item(20) = DBNull
        End If
        If txtZaak.Text <> "" Then
            m_datarow.Item(11) = txtZaak.Text
        Else
            m_datarow.Item(11) = DBNull
        End If
        If txtStraat.Text <> "" Then
            m_datarow.Item(7) = txtStraat.Text
        Else
            m_datarow.Item(7) = DBNull
        End If
        If txtHuisnummer.Text <> "" Then
            m_datarow.Item(8) = txtHuisnummer.Text
        Else
            m_datarow.Item(8) = DBNull
        End If
        If txtPostcode.Text <> "" Then
            m_datarow.Item(9) = txtPostcode.Text
        Else
            m_datarow.Item(9) = DBNull
        End If
        If txtPlaats.Text <> "" Then
            m_datarow.Item(10) = txtPlaats.Text
        Else
            m_datarow.Item(10) = DBNull
        End If
        If dtpOpdrachtgeverdatum.Checked() Then
            m_datarow.Item(24) = dtpOpdrachtgeverdatum.Text
        Else
            m_datarow.Item(24) = System.DBNull.Value
        End If
        If dtpEpacentrumdatum.Checked() Then
            m_datarow.Item(25) = dtpEpacentrumdatum.Text
        Else
            m_datarow.Item(25) = System.DBNull.Value
        End If
        If txtAangebrachtdoor.Text <> "" Then
            m_datarow.Item(26) = txtAangebrachtdoor.Text
        Else
            m_datarow.Item(26) = DBNull
        End If
        If txtEpatype.Text <> "" Then
            m_datarow.Item(27) = txtEpatype.Text
        Else
            m_datarow.Item(27) = DBNull
        End If
        If txtOpmerkingen.Text <> "" Then
            m_datarow.Item(32) = txtOpmerkingen.Text()
        Else
            m_datarow.Item(32) = DBNull
        End If

    End Sub

    Private Sub inhoudvullen_klant()

        If m_nieuw Then
            m_datarow2.Item(0) = m_maxklant_id
        End If
        If txtProject.Text <> "" Then
            m_datarow2.Item(1) = txtProject.Text
        Else
            m_datarow2.Item(1) = DBNull
        End If
        If txtAanspreektitel.Text <> "" Then
            m_datarow2.Item(3) = txtAanspreektitel.Text
        Else
            m_datarow2.Item(3) = DBNull
        End If
        If txtVoorletters.Text <> "" Then
            m_datarow2.Item(4) = txtVoorletters.Text
        Else
            m_datarow2.Item(4) = DBNull
        End If
        If txtTussenvoegsels.Text <> "" Then
            m_datarow2.Item(5) = txtTussenvoegsels.Text
        Else
            m_datarow2.Item(5) = DBNull
        End If
        If txtAchternaam.Text <> "" Then
            m_datarow2.Item(6) = txtAchternaam.Text
        Else
            m_datarow2.Item(6) = DBNull
        End If
        If txtEpastraat.Text <> "" Then
            m_datarow2.Item(16) = txtEpastraat.Text
        Else
            m_datarow2.Item(16) = DBNull
        End If
        If txtEpahuisnummer.Text <> "" Then
            m_datarow2.Item(17) = txtEpahuisnummer.Text
        Else
            m_datarow2.Item(17) = DBNull
        End If
        If txtEpapostcode.Text <> "" Then
            m_datarow2.Item(18) = txtEpapostcode.Text
        Else
            m_datarow2.Item(18) = DBNull
        End If
        If txtEpaplaats.Text <> "" Then
            m_datarow2.Item(19) = txtEpaplaats.Text
        Else
            m_datarow2.Item(19) = DBNull
        End If
        If txtPrive.Text <> "" Then
            m_datarow2.Item(12) = txtPrive.Text
        Else
            m_datarow2.Item(12) = DBNull
        End If
        If txtWerk.Text <> "" Then
            m_datarow2.Item(13) = txtWerk.Text
        Else
            m_datarow2.Item(13) = DBNull
        End If
        If txtMobiel.Text <> "" Then
            m_datarow2.Item(14) = txtMobiel.Text
        Else
            m_datarow2.Item(14) = DBNull
        End If
        If txtEmail.Text <> "" Then
            m_datarow2.Item(15) = txtEmail.Text
        Else
            m_datarow2.Item(15) = DBNull
        End If
        If txtBedrijfsnaam.Text <> "" Then
            m_datarow2.Item(2) = txtBedrijfsnaam.Text
        Else
            m_datarow2.Item(2) = DBNull
        End If
        If txtBedrijfstak.Text <> "" Then
            m_datarow2.Item(20) = txtBedrijfstak.Text
        Else
            m_datarow2.Item(20) = DBNull
        End If
        If txtZaak.Text <> "" Then
            m_datarow2.Item(11) = txtZaak.Text
        Else
            m_datarow2.Item(11) = DBNull
        End If
        If txtStraat.Text <> "" Then
            m_datarow2.Item(7) = txtStraat.Text
        Else
            m_datarow2.Item(7) = DBNull
        End If
        If txtHuisnummer.Text <> "" Then
            m_datarow2.Item(8) = txtHuisnummer.Text
        Else
            m_datarow2.Item(8) = DBNull
        End If
        If txtPostcode.Text <> "" Then
            m_datarow2.Item(9) = txtPostcode.Text
        Else
            m_datarow2.Item(9) = DBNull
        End If
        If txtPlaats.Text <> "" Then
            m_datarow2.Item(10) = txtPlaats.Text
        Else
            m_datarow2.Item(10) = DBNull
        End If

    End Sub

    Private Sub inhoudvullen_project()

        If m_nieuw Then
            m_datarow3.Item(0) = m_maxproject_id
        End If
        If txtProject.Text <> "" Then
            m_datarow3.Item(1) = txtProject.Text
        Else
            m_datarow3.Item(1) = DBNull
        End If
        If txtProjectcode.Text <> "" Then
            m_datarow3.Item(2) = txtProjectcode.Text
        Else
            m_datarow3.Item(2) = DBNull
        End If
        If txtVolgnummer.Text <> "" Then
            m_datarow3.Item(3) = txtVolgnummer.Text
        Else
            m_datarow3.Item(3) = DBNull
        End If
        If dtpOpdrachtgeverdatum.Checked() Then
            m_datarow.Item(4) = dtpOpdrachtgeverdatum.Text
        Else
            m_datarow.Item(4) = System.DBNull.Value
        End If
        If dtpEpacentrumdatum.Checked() Then
            m_datarow3.Item(5) = dtpEpacentrumdatum.Text
        Else
            m_datarow3.Item(5) = System.DBNull.Value
        End If
        If txtEpatype.Text <> "" Then
            m_datarow3.Item(7) = txtEpatype.Text
        Else
            m_datarow3.Item(7) = DBNull
        End If
        m_datarow3.Item(8) = chkVerkorttraject.Checked()
        If dtpLabelafgemeld.Checked() Then
            m_datarow3.Item(16) = dtpLabelafgemeld.Text
        Else
            m_datarow3.Item(16) = System.DBNull.Value
        End If
        If txtAangebrachtdoor.Text <> "" Then
            m_datarow3.Item(6) = txtAangebrachtdoor.Text
        Else
            m_datarow3.Item(6) = DBNull
        End If
        If txtOpmerkingen.Text <> "" Then
            m_datarow3.Item(26) = txtOpmerkingen.Text()
        Else
            m_datarow3.Item(26) = DBNull
        End If
    End Sub

    Private Sub btnZkproject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZkproject.Click
        Dim m_zkprojectopcodedlg As New ZkprojectopcodeDlg
        Dim m_project As String

        m_zkprojectopcodedlg.ShowDialog()
        If m_zkprojectopcodedlg.DialogResult = Windows.Forms.DialogResult.OK Then
            m_project = m_zkprojectopcodedlg.Project()

            Me.Cursor() = Cursors.WaitCursor
            m_bindingsource.MoveFirst()

            m_datarow = m_dataset.Tables("tbl_klant")(m_bindingsource.Position())
            While m_bindingsource.Position() + 1 <= m_bindingsource.Count() And Compare(m_datarow.Item(1), m_project, False) < 0
                m_bindingsource.MoveNext()
                m_datarow = m_dataset.Tables("tbl_klant")(m_bindingsource.Position())
            End While

            recordweergeven()
            Me.Cursor() = Cursors.Arrow
        End If
    End Sub

    Private Sub btnZkaanspreektitel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZkaanspreektitel.Click
        Dim m_zkaanspreektiteldlg As New ZkaanspreektitelDlg

        m_zkaanspreektiteldlg.ShowDialog()
        If m_zkaanspreektiteldlg.DialogResult = Windows.Forms.DialogResult.OK Then
            txtAanspreektitel.Text = m_zkaanspreektiteldlg.Aanspreektitel()
            'm_datarow = m_dataset.Tables("tbl_klant")(m_bindingsource.Position())
            ' m_datarow.Item(3) = m_zkaanspreektiteldlg.Aanspreektitel_id()
            'm_datarow2 = m_dataset2.Tables("tbl_klant2")(m_bindingsource.Position())
            ' m_datarow2.Item(3) = m_zkaanspreektiteldlg.Aanspreektitel_id()
        End If

    End Sub

    Private Sub btnZkprojectcode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZkprojectcode.Click
        Dim m_zkprojectcodedlg As New ZkprojectcodeDlg

        m_zkprojectcodedlg.ShowDialog()
        If m_zkprojectcodedlg.DialogResult = Windows.Forms.DialogResult.OK Then
            txtProjectcode.Text = m_zkprojectcodedlg.Projectcode()
            'm_datarow = m_dataset.Tables("tbl_klant")(m_bindingsource.Position())
            'm_datarow.Item(1) = m_zkprojectcodedlg.Projectcode()
            'm_datarow3 = m_dataset3.Tables("tbl_project")(m_bindingsource.Position())
            'm_datarow3.Item(1) = m_zkprojectcodedlg.Projectcode()
        End If
    End Sub

    Private Sub btnZkepatype_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZkepatype.Click
        Dim m_zkepatypedlg As New ZkepatypeDlg

        m_zkepatypedlg.ShowDialog()
        If m_zkepatypedlg.DialogResult = Windows.Forms.DialogResult.OK Then
            txtEpatype.Text = m_zkepatypedlg.Epatype()
            'm_datarow = m_dataset.Tables("tbl_project")(m_bindingsource.Position())
            'm_datarow.Item(14) = m_zkepatypedlg.Epatype_id()
            'm_datarow3 = m_dataset3.Tables("tbl_project")(m_bindingsource.Position())
            'm_datarow3.Item(14) = m_zkepatypedlg.Epatype_id()
        End If

    End Sub

    Private Sub btnZkadviseur_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZkadviseur.Click
        Dim m_zkadviseurdlg As New ZkadviseurDlg

        m_zkadviseurdlg.ShowDialog()
        If m_zkadviseurdlg.DialogResult = Windows.Forms.DialogResult.OK Then
            txtAdviseur.Text = m_zkadviseurdlg.Adviseur("c")
            m_datarow = m_dataset.Tables("tbl_klant")(m_bindingsource.Position())
            m_datarow.Item(29) = m_zkadviseurdlg.Adviseur_id()
            m_datarow3 = m_dataset3.Tables("tbl_project")(m_bindingsource.Position())
            m_datarow3.Item(10) = m_zkadviseurdlg.Adviseur_id()
        End If

    End Sub

    'Private Sub cboZkadviseur_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboZkadviseur.SelectedIndexChanged
    '    If Not m_nieuw Then
    '        Me.Cursor() = Cursors.WaitCursor
    '        m_bindingsource.MoveFirst()

    '        m_datarow = m_dataset.Tables("tbl_adviseur")(m_bindingsource.Position())
    '        While m_bindingsource.Position() + 1 <= m_bindingsource.Count() And Compare(m_datarow.Item(4) & ", " & m_datarow.Item(3), cboZkadviseur.SelectedItem, False) < 0
    '            m_bindingsource.MoveNext()
    '            m_datarow = m_dataset.Tables("tbl_adviseur")(m_bindingsource.Position())
    '        End While

    '        recordweergeven()
    '        Me.Cursor() = Cursors.Arrow
    '    End If
    'End Sub

    Private Sub KlantView_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        EAISIVSchermen.Klantviewed() = False
    End Sub

End Class