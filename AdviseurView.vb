Imports System.Data.OleDb
Imports System.String

Public Class AdviseurView

    Private m_combovisible As Boolean

    Private m_max_id As Integer
    Private m_epavestiging_id As Integer
    Private m_aanspreektitel_id As Integer

    Private m_tonen As Boolean
    Private m_nieuw As Boolean
    Private m_wijzigen As Boolean

    Private m_strconn As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Richard\Documents\databases\EPACENTRUM\eaisIVnieuwdataII.mdb"
    Private m_connection As New OleDbConnection(m_strconn)
    Private m_dataadapter As New OleDbDataAdapter("SELECT tbl_adviseur.*, tbl_aanspreektitel.aanspreektitel, tbl_EPA_vestiging.EPA_vestiging" _
& " FROM (tbl_adviseur LEFT JOIN tbl_aanspreektitel ON tbl_adviseur.aanspreektitel_ID = tbl_aanspreektitel.aanspreektitel_ID) LEFT JOIN tbl_EPA_vestiging ON tbl_adviseur.EPA_vestiging_ID = tbl_EPA_vestiging.EPA_vestiging_ID" _
& " ORDER BY tbl_adviseur.achternaam", m_connection)
    Private m_dataadapter2 As New OleDbDataAdapter("Select * FROM tbl_adviseur ORDER BY achternaam", m_connection)
    Private m_commandbuilder As New OleDbCommandBuilder(m_dataadapter)
    Private m_commandbuilder2 As New OleDbCommandBuilder(m_dataadapter2)
    Private m_dataset As New DataSet
    Private m_dataset2 As New DataSet
    Private m_datarow As DataRow
    Private m_datarow2 As DataRow

    Private m_bindingsource As New BindingSource
    Private DBNull As Object

    Private Sub AdviseurView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        m_dataadapter.Fill(m_dataset, "tbl_adviseur")
        m_bindingsource.DataSource = m_dataset.Tables("tbl_adviseur")

        m_dataadapter2.Fill(m_dataset2, "tbl_adviseur2")

        m_combovisible = False
        cboZkadviseur.Visible = m_combovisible
        If m_combovisible Then
            cboZkadviseur.ValueMember = "achternaam"
            Dim m_command_zk = New OleDbCommand("SELECT achternaam, voornaam FROM tbl_adviseur ORDER BY achternaam DESC", m_connection)
            m_command_zk.Connection.Open()
            Dim m_datareader_zk As OleDbDataReader = m_command_zk.ExecuteReader()
            Me.Cursor() = Cursors.WaitCursor
            While m_datareader_zk.Read()
                cboZkadviseur.Items.Add(m_datareader_zk("achternaam") & ", " & m_datareader_zk("voornaam"))
            End While
            Me.Cursor() = Cursors.Arrow
            m_command_zk.Connection.Close()
        End If

        Dim m_command_max = New OleDbCommand("SELECT MAX(adviseur_ID) FROM tbl_adviseur", m_connection)

        m_command_max.Connection.Open()
        Dim m_datareader_max As OleDbDataReader = m_command_max.ExecuteReader(CommandBehavior.CloseConnection)

        m_datareader_max.Read()
        If Not IsDBNull(m_datareader_max(0)) Then
            m_max_id = m_datareader_max(0)
        Else
            m_max_id = 0
        End If

        m_command_max.Connection.Close()

        txtAanspreektitel.ReadOnly = True
        txtEPAvestiging.ReadOnly = True

        If m_bindingsource.Count() > 0 Then
            btnBekijken_Click()
        Else
            btnNieuw_Click()
        End If

    End Sub

    Private Sub btnBekijken_Click() Handles btnBekijken.Click
        'Private Sub btnBekijken_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBekijken.Click

        Me.Text = "Adviseurs - BEKIJKEN"

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

        If m_combovisible Then
            cboZkadviseur.Visible() = True
        End If
        btnZkadviseur.Visible() = True
        btnZkaanspreektitel.Visible = False
        btnZkepavestiging.Visible = False

        btnEerste.Visible() = True
        btnVorige.Visible() = True
        btnVolgende.Visible() = True
        btnLaatste.Visible() = True

        btnOpslaan.Visible() = False
        btnNietOpslaan.Visible() = False

    End Sub

    Private Sub btnWijzigen_Click() Handles btnWijzigen.Click

        Me.Text = "Adviseurs - WIJZIGEN"

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

        If m_combovisible Then
            cboZkadviseur.Visible() = True
        End If
        btnZkadviseur.Visible() = True
        btnZkaanspreektitel.Visible = True
        btnZkepavestiging.Visible = True

        btnEerste.Visible() = True
        btnVorige.Visible() = True
        btnVolgende.Visible() = True
        btnLaatste.Visible() = True

        btnOpslaan.Visible() = True
        btnNietOpslaan.Visible() = True

    End Sub

    Private Sub btnNieuw_Click() Handles btnNieuw.Click

        Me.Text = "Adviseurs - TOEVOEGEN"

        m_tonen = False
        m_nieuw = True
        m_wijzigen = False

        'GetDlgItem(IDC_MENU_BUTTON)->ShowWindow(SW_HIDE);
        'GetDlgItem(IDC_CODE_BUTTON)->ShowWindow(SW_HIDE);

        veldenediten(True)
        veldenleegmaken()

        If m_combovisible Then
            cboZkadviseur.Visible() = False
        End If
        btnZkadviseur.Visible() = False
        btnZkaanspreektitel.Visible = True
        btnZkepavestiging.Visible = True

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
                m_datarow = m_dataset.Tables("tbl_adviseur").NewRow
                m_datarow2 = m_dataset2.Tables("tbl_adviseur2").NewRow
                m_max_id += 1
                inhoudvullen()
                m_dataset.Tables("tbl_adviseur").Rows.Add(m_datarow)
                m_dataset2.Tables("tbl_adviseur2").Rows.Add(m_datarow2)
                m_dataadapter2.Update(m_dataset2, "tbl_adviseur2")
                veldenleegmaken()
            ElseIf (m_wijzigen) Then
                m_datarow2 = m_dataset2.Tables("tbl_adviseur2")(m_bindingsource.Position())
                inhoudvullen()
                m_dataadapter2.Update(m_dataset2, "tbl_adviseur2")
            End If
        End If
    End Sub

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

        If txtAchternaam.Text = "" Then
            MessageBox.Show("De achternaam moet ingevuld zijn !\n",
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

        txtVoornaam.ReadOnly = Not edit
        txtVoorletters.ReadOnly = Not edit
        txtAchternaam.ReadOnly = Not edit
        txtStraat.ReadOnly = Not edit
        txtHuisnummer.ReadOnly = Not edit
        txtPostcode.ReadOnly = Not edit
        txtPlaats.ReadOnly = Not edit
        txtPrive.ReadOnly = Not edit
        txtWerk.ReadOnly = Not edit
        txtMobiel.ReadOnly = Not edit
        txtEmail.ReadOnly = Not edit
        txtCapaciteit.ReadOnly = Not edit
        txtAdviesbureau.ReadOnly = Not edit
        chkNietinzetbaar.Enabled = edit
        chkEpawlabel.Enabled = edit
        chkEpawmaatwerk.Enabled = edit
        chkEpaulabel.Enabled = edit
        chkEpaumaatwerk.Enabled = edit
        chkEpaulabel.Enabled = edit
        txtOpmerkingen.ReadOnly = Not edit

    End Sub

    Private Sub recordweergeven()

        m_datarow = m_dataset.Tables("tbl_adviseur")(m_bindingsource.Position())
        If Not IsDBNull(m_datarow.Item(22)) Then
            txtAanspreektitel.Text = m_datarow.Item(22)
        Else
            txtAanspreektitel.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(2)) Then
            txtVoorletters.Text = m_datarow.Item(2)
        Else
            txtVoorletters.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(3)) Then
            txtVoornaam.Text = m_datarow.Item(3)
        Else
            txtVoornaam.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(4)) Then
            txtAchternaam.Text = m_datarow.Item(4)
        Else
            txtAchternaam.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(5)) Then
            txtStraat.Text = m_datarow.Item(5)
        Else
            txtStraat.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(6)) Then
            txtHuisnummer.Text = m_datarow.Item(6)
        Else
            txtHuisnummer.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(7)) Then
            txtPostcode.Text = m_datarow.Item(7)
        Else
            txtPostcode.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(8)) Then
            txtPlaats.Text = m_datarow.Item(8)
        Else
            txtPlaats.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(9)) Then
            txtPrive.Text = m_datarow.Item(9)
        Else
            txtPrive.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(10)) Then
            txtWerk.Text = m_datarow.Item(10)
        Else
            txtWerk.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(11)) Then
            txtMobiel.Text = m_datarow.Item(11)
        Else
            txtMobiel.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(12)) Then
            txtEmail.Text = m_datarow.Item(12)
        Else
            txtEmail.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(13)) Then
            txtCapaciteit.Text = m_datarow.Item(13)
        Else
            txtCapaciteit.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(23)) Then
            txtEPAvestiging.Text = m_datarow.Item(23)
        Else
            txtEPAvestiging.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(15)) Then
            txtAdviesbureau.Text = m_datarow.Item(15)
        Else
            txtAdviesbureau.Text = ""
        End If
        chkNietinzetbaar.Checked() = m_datarow.Item(16)
        chkEpawlabel.Checked() = m_datarow.Item(17)
        chkEpawmaatwerk.Checked() = m_datarow.Item(18)
        chkEpaulabel.Checked() = m_datarow.Item(19)
        chkEpaumaatwerk.Checked() = m_datarow.Item(20)
        If Not IsDBNull(m_datarow.Item(21)) Then
            txtOpmerkingen.Text = m_datarow.Item(21)
        Else
            txtOpmerkingen.Text = ""
        End If

    End Sub

    Private Sub veldenleegmaken()

        txtAanspreektitel.Text = ""
        txtVoornaam.Text = ""
        txtVoorletters.Text = ""
        txtAchternaam.Text = ""
        txtStraat.Text = ""
        txtHuisnummer.Text = ""
        txtPostcode.Text = ""
        txtPlaats.Text = ""
        txtPrive.Text = ""
        txtWerk.Text = ""
        txtMobiel.Text = ""
        txtEmail.Text = ""
        txtCapaciteit.Text = ""
        txtEPAvestiging.Text = ""
        txtAdviesbureau.Text = ""
        chkNietinzetbaar.Checked() = False
        chkEpawlabel.Checked() = False
        chkEpawmaatwerk.Checked() = False
        chkEpaulabel.Checked() = False
        chkEpaumaatwerk.Checked() = False
        txtOpmerkingen.Text = ""

    End Sub

    Private Sub inhoudvullen()

        If m_nieuw Then
            m_datarow.Item(0) = m_max_id
        End If
        m_datarow.Item(1) = m_aanspreektitel_id
        If txtAanspreektitel.Text <> "" Then
            m_datarow.Item(22) = txtAanspreektitel.Text
        Else
            m_datarow.Item(22) = DBNull
        End If
        If txtVoorletters.Text <> "" Then
            m_datarow.Item(2) = txtVoorletters.Text
        Else
            m_datarow.Item(2) = DBNull
        End If
        If txtVoornaam.Text <> "" Then
            m_datarow.Item(3) = txtVoornaam.Text
        Else
            m_datarow.Item(3) = DBNull
        End If
        If txtAchternaam.Text <> "" Then
            m_datarow.Item(4) = txtAchternaam.Text
        Else
            m_datarow.Item(4) = DBNull
        End If
        If txtStraat.Text <> "" Then
            m_datarow.Item(5) = txtStraat.Text
        Else
            m_datarow.Item(5) = DBNull
        End If
        If txtHuisnummer.Text <> "" Then
            m_datarow.Item(6) = txtHuisnummer.Text
        Else
            m_datarow.Item(6) = DBNull
        End If
        If txtPostcode.Text <> "" Then
            m_datarow.Item(7) = txtPostcode.Text
        Else
            m_datarow.Item(7) = DBNull
        End If
        If txtPlaats.Text <> "" Then
            m_datarow.Item(8) = txtPlaats.Text
        Else
            m_datarow.Item(8) = DBNull
        End If
        If txtPrive.Text <> "" Then
            m_datarow.Item(9) = txtPrive.Text
        Else
            m_datarow.Item(9) = DBNull
        End If
        If txtWerk.Text <> "" Then
            m_datarow.Item(10) = txtWerk.Text
        Else
            m_datarow.Item(10) = DBNull
        End If
        If txtMobiel.Text <> "" Then
            m_datarow.Item(11) = txtMobiel.Text
        Else
            m_datarow.Item(11) = DBNull
        End If
        If txtEmail.Text <> "" Then
            m_datarow.Item(12) = txtEmail.Text
        Else
            m_datarow.Item(12) = DBNull
        End If
        If txtCapaciteit.Text <> "" Then
            m_datarow.Item(13) = txtCapaciteit.Text
        Else
            m_datarow.Item(13) = 0
        End If
        m_datarow.Item(14) = m_epavestiging_id
        If txtEPAvestiging.Text <> "" Then
            m_datarow.Item(23) = txtEPAvestiging.Text
        Else
            m_datarow.Item(23) = DBNull
        End If
        If txtAdviesbureau.Text <> "" Then
            m_datarow.Item(15) = txtAdviesbureau.Text
        Else
            m_datarow.Item(15) = DBNull
        End If

        m_datarow.Item(16) = chkNietinzetbaar.Checked()
        m_datarow.Item(17) = chkEpawlabel.Checked()
        m_datarow.Item(18) = chkEpawmaatwerk.Checked()
        m_datarow.Item(19) = chkEpaulabel.Checked()
        m_datarow.Item(20) = chkEpaumaatwerk.Checked()

        If txtOpmerkingen.Text <> "" Then
            m_datarow.Item(21) = txtOpmerkingen.Text
        Else
            m_datarow.Item(21) = DBNull
        End If

        If m_nieuw Then
            m_datarow2.Item(0) = m_max_id
        End If
        m_datarow2.Item(1) = m_aanspreektitel_id
        If txtVoorletters.Text <> "" Then
            m_datarow2.Item(2) = txtVoorletters.Text
        Else
            m_datarow2.Item(2) = DBNull
        End If
        If txtVoornaam.Text <> "" Then
            m_datarow2.Item(3) = txtVoornaam.Text
        Else
            m_datarow2.Item(3) = DBNull
        End If
        If txtAchternaam.Text <> "" Then
            m_datarow2.Item(4) = txtAchternaam.Text
        Else
            m_datarow2.Item(4) = DBNull
        End If
        If txtStraat.Text <> "" Then
            m_datarow2.Item(5) = txtStraat.Text
        Else
            m_datarow2.Item(5) = DBNull
        End If
        If txtHuisnummer.Text <> "" Then
            m_datarow2.Item(6) = txtHuisnummer.Text
        Else
            m_datarow2.Item(6) = DBNull
        End If
        If txtPostcode.Text <> "" Then
            m_datarow2.Item(7) = txtPostcode.Text
        Else
            m_datarow2.Item(7) = DBNull
        End If
        If txtPlaats.Text <> "" Then
            m_datarow2.Item(8) = txtPlaats.Text
        Else
            m_datarow2.Item(8) = DBNull
        End If
        If txtPrive.Text <> "" Then
            m_datarow2.Item(9) = txtPrive.Text
        Else
            m_datarow2.Item(9) = DBNull
        End If
        If txtWerk.Text <> "" Then
            m_datarow2.Item(10) = txtWerk.Text
        Else
            m_datarow2.Item(10) = DBNull
        End If
        If txtMobiel.Text <> "" Then
            m_datarow2.Item(11) = txtMobiel.Text
        Else
            m_datarow2.Item(11) = DBNull
        End If
        If txtEmail.Text <> "" Then
            m_datarow2.Item(12) = txtEmail.Text
        Else
            m_datarow2.Item(12) = DBNull
        End If
        If txtCapaciteit.Text <> "" Then
            m_datarow2.Item(13) = txtCapaciteit.Text
        Else
            m_datarow2.Item(13) = 0
        End If
        m_datarow2.Item(14) = m_epavestiging_id
        If txtAdviesbureau.Text <> "" Then
            m_datarow2.Item(15) = txtAdviesbureau.Text
        Else
            m_datarow2.Item(15) = DBNull
        End If

        m_datarow2.Item(16) = chkNietinzetbaar.Checked()
        m_datarow2.Item(17) = chkEpawlabel.Checked()
        m_datarow2.Item(18) = chkEpawmaatwerk.Checked()
        m_datarow2.Item(19) = chkEpaulabel.Checked()
        m_datarow2.Item(20) = chkEpaumaatwerk.Checked()

        If txtOpmerkingen.Text <> "" Then
            m_datarow2.Item(21) = txtOpmerkingen.Text
        Else
            m_datarow2.Item(21) = DBNull
        End If

    End Sub

    Private Sub btnZkadviseur_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZkadviseur.Click
        Dim m_zkadviseurdlg As New ZkadviseurDlg
        Dim m_achternaam As String

        m_zkadviseurdlg.ShowDialog()
        If m_zkadviseurdlg.DialogResult = Windows.Forms.DialogResult.OK Then
            m_achternaam = m_zkadviseurdlg.Adviseur()

            Me.Cursor() = Cursors.WaitCursor
            m_bindingsource.MoveFirst()

            m_datarow = m_dataset.Tables("tbl_adviseur")(m_bindingsource.Position())
            While m_bindingsource.Position() + 1 <= m_bindingsource.Count() And Compare(m_datarow.Item(4), m_achternaam, False) < 0
                m_bindingsource.MoveNext()
                m_datarow = m_dataset.Tables("tbl_adviseur")(m_bindingsource.Position())
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
            'm_datarow = m_dataset.Tables("tbl_adviseur")(m_bindingsource.Position())
            'm_datarow.Item(1) = m_zkaanspreektiteldlg.Aanspreektitel_id()
            'm_datarow2 = m_dataset2.Tables("tbl_adviseur2")(m_bindingsource.Position())
            'm_datarow2.Item(1) = m_zkaanspreektiteldlg.Aanspreektitel_id()
            m_aanspreektitel_id = m_zkaanspreektiteldlg.Aanspreektitel_id()
        End If

    End Sub

    Private Sub btnZkepavestiging_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZkepavestiging.Click
        Dim m_zkepavestigingdlg As New ZkepavestigingDlg

        m_zkepavestigingdlg.ShowDialog()
        If m_zkepavestigingdlg.DialogResult = Windows.Forms.DialogResult.OK Then
            txtEPAvestiging.Text = m_zkepavestigingdlg.Epavestiging()
            'm_datarow = m_dataset.Tables("tbl_adviseur")(m_bindingsource.Position())
            'm_datarow.Item(14) = m_zkepavestigingdlg.Epavestiging_id()
            'm_datarow2 = m_dataset2.Tables("tbl_adviseur2")(m_bindingsource.Position())
            'm_datarow2.Item(14) = m_zkepavestigingdlg.Epavestiging_id()
            m_epavestiging_id = m_zkepavestigingdlg.Epavestiging_id()
        End If

    End Sub

    Private Sub cboZkadviseur_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboZkadviseur.SelectedIndexChanged
        If Not m_nieuw Then
            Me.Cursor() = Cursors.WaitCursor
            m_bindingsource.MoveFirst()

            m_datarow = m_dataset.Tables("tbl_adviseur")(m_bindingsource.Position())
            While m_bindingsource.Position() + 1 <= m_bindingsource.Count() And Compare(m_datarow.Item(4) & ", " & m_datarow.Item(3), cboZkadviseur.SelectedItem, False) < 0
                m_bindingsource.MoveNext()
                m_datarow = m_dataset.Tables("tbl_adviseur")(m_bindingsource.Position())
            End While

            recordweergeven()
            Me.Cursor() = Cursors.Arrow
        End If
    End Sub

    Private Sub AdviseurView_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        EAISIVSchermen.Adviseurviewed() = False
    End Sub

End Class