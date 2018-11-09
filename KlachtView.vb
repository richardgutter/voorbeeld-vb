Imports System.Data.OleDb
Imports System.String

Public Class KlachtView

    Private m_max_id As Integer

    Private m_sqlstring As String = "SELECT tbl_klacht.*, [tbl_klant].[aanspreektitel] & ' ' & [tbl_klant.voorletters] & ' ' & [tbl_klant.tussenvoegsels] & ' ' & [tbl_klant.achternaam] AS klant, [tbl_klant].[straat] & ' ' & [tbl_klant].[huisnummer] AS postadres, Left([tbl_klant].[postcode],4) & ' ' & Right([tbl_klant].[postcode],2) & ' ' & [tbl_klant].[plaats] AS postplaats, [tbl_klant].[EPA_straat] & ' ' & [tbl_klant].[EPA_huisnummer] AS epaadres, Left([tbl_klant].[EPA_postcode],4) & ' ' & Right([tbl_klant].[EPA_postcode],2) & ' ' & [tbl_klant].[EPA_plaats] AS epaplaats, [tbl_adviseur.voorletters] & ' ' & [tbl_adviseur.achternaam] AS [naam adviseur], tbl_klant.privé_telefoonnr, tbl_klant.mobiel_telefoonnr, tbl_klant.werk_telefoonnr, tbl_klant.email" _
            & " FROM tbl_adviseur RIGHT JOIN (tbl_klacht RIGHT JOIN (tbl_project INNER JOIN tbl_klant ON tbl_project.projectcode = tbl_klant.projectcode) ON tbl_klacht.projectcode = tbl_project.projectcode) ON tbl_adviseur.adviseur_ID = tbl_project.adviseur_ID" _
            & " WHERE (((tbl_klacht.klacht_ID) Is Not Null)) ORDER BY tbl_project.projectcode"

    Private m_tonen As Boolean
    Private m_nieuw As Boolean
    Private m_wijzigen As Boolean

    Private m_strconn As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Richard\Documents\databases\EPACENTRUM\eaisIVnieuwdataII.mdb"
    Private m_connection As New OleDbConnection(m_strconn)
    Private m_dataadapter As New OleDbDataAdapter(m_sqlstring, m_connection)
    Private m_commandbuilder As New OleDbCommandBuilder(m_dataadapter)
    Private m_dataset As New DataSet
    Private m_datarow As DataRow

    Private m_bindingsource As New BindingSource
    Private DBNull As Object

    Private Sub KlantView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        m_dataadapter.Fill(m_dataset, "tbl_klacht")
        m_bindingsource.DataSource = m_dataset.Tables("tbl_klacht")

        Dim m_command_maxklacht = New OleDbCommand("SELECT MAX(klacht_ID) FROM tbl_klacht", m_connection)

        m_command_maxklacht.Connection.Open()
        Dim m_datareader_maxklacht As OleDbDataReader = m_command_maxklacht.ExecuteReader(CommandBehavior.CloseConnection)

        m_datareader_maxklacht.Read()
        If Not IsDBNull(m_datareader_maxklacht(0)) Then
            m_max_id = m_datareader_maxklacht(0)
        Else
            m_max_id = 0
        End If

        m_command_maxklacht.Connection.Close()

        txtProject.ReadOnly = True
        'txtafgehandeldeklacht.ReadOnly = True
        'txtKlacht.ReadOnly = True

        If m_bindingsource.Count() > 0 Then
            btnBekijken_Click()
        Else
            btnNieuw_Click()
        End If

    End Sub

    Private Sub btnBekijken_Click() Handles btnBekijken.Click
        'Private Sub btnBekijken_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBekijken.Click

        Me.Text = "Klacht - BEKIJKEN"

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

        btnZkproject.Visible() = False
        lblKlachten.Visible() = True
        'txtKlacht.Visible() = True
        btnZkklacht.Visible() = True
        'txtAfgehandeldeklacht.Visible() = True
        btnZkafgehandeldeklacht.Visible() = True
        lblAfgehandeldeklachten.Visible() = True

        btnEerste.Visible() = True
        btnVorige.Visible() = True
        btnVolgende.Visible() = True
        btnLaatste.Visible() = True

        btnOpslaan.Visible() = False
        btnNietOpslaan.Visible() = False

    End Sub

    Private Sub btnWijzigen_Click() Handles btnWijzigen.Click

        Me.Text = "Klacht - WIJZIGEN"

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

        btnZkproject.Visible() = False
        lblKlachten.Visible() = True
        'txtKlacht.Visible() = True
        btnZkklacht.Visible() = True
        'txtAfgehandeldeklacht.Visible() = True
        btnZkafgehandeldeklacht.Visible() = True
        lblAfgehandeldeklachten.Visible() = True

        btnEerste.Visible() = True
        btnVorige.Visible() = True
        btnVolgende.Visible() = True
        btnLaatste.Visible() = True

        btnOpslaan.Visible() = True
        btnNietOpslaan.Visible() = True

    End Sub

    Private Sub btnNieuw_Click() Handles btnNieuw.Click

        Me.Text = "Klacht - TOEVOEGEN"

        m_tonen = False
        m_nieuw = True
        m_wijzigen = False

        'GetDlgItem(IDC_MENU_BUTTON)->ShowWindow(SW_HIDE);
        'GetDlgItem(IDC_CODE_BUTTON)->ShowWindow(SW_HIDE);

        veldenediten(True)
        veldenleegmaken()

        btnZkproject.Visible() = True
        lblKlachten.Visible() = False
        'txtKlacht.Visible() = False
        btnZkklacht.Visible() = False
        'txtAfgehandeldeklacht.Visible() = False
        btnZkafgehandeldeklacht.Visible() = False
        lblAfgehandeldeklachten.Visible() = False

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

        Dim m_dataadapter2 As New OleDbDataAdapter("Select * FROM tbl_klacht WHERE projectcode = '" & txtProject.Text & "'", m_connection)
        Dim m_commandbuilder2 As New OleDbCommandBuilder(m_dataadapter2)
        Dim m_dataset2 As New DataSet
        Dim m_datarow2 As DataRow

        m_dataadapter2.Fill(m_dataset2, "tbl_klacht2")
        If (OpslaanCheck()) Then
            If (m_nieuw) Then
                m_datarow = m_dataset.Tables("tbl_klacht").NewRow
                m_datarow2 = m_dataset2.Tables("tbl_klacht2").NewRow
                m_max_id += 1
                inhoudvullen()
                inhoudvullen_klacht(m_datarow2)
                m_dataset.Tables("tbl_klacht").Rows.Add(m_datarow)
                m_datarow = m_dataset.Tables("tbl_klacht")(m_bindingsource.Position())
                m_dataset2.Tables("tbl_klacht2").Rows.Add(m_datarow2)
                m_dataadapter2.Update(m_dataset2, "tbl_klacht2")
                m_datarow2 = m_dataset2.Tables("tbl_klacht2")(0)
                veldenleegmaken()
            ElseIf (m_wijzigen) Then
                m_datarow2 = m_dataset2.Tables("tbl_klacht2")(0)
                inhoudvullen()
                inhoudvullen_klacht(m_datarow2)
                m_dataadapter2.Update(m_dataset2, "tbl_klacht2")
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

        If txtOntvanger.Text = "" Then
            MessageBox.Show("De naam van de ontvanger moet ingevuld zijn !\n",
                            "Gegevens wijzigen", MessageBoxButtons.OK)
            Return False
        End If

        If dtpOntvangenop.Text = "" Then
            MessageBox.Show("De datum van ontvangst moet ingevuld zijn !\n",
                            "Gegevens wijzigen", MessageBoxButtons.OK)
            Return False
        End If

        If txtOmschrijving.Text = "" Then
            MessageBox.Show("De omschrijving van de klacht moet ingevuld zijn !\n",
                            "Gegevens wijzigen", MessageBoxButtons.OK)
            Return False
        End If

        Return True
    End Function

    Private Sub veldenediten(ByVal edit As Boolean)

        chkUrgent.Enabled = edit
        txtOntvanger.ReadOnly = Not edit
        txtOmschrijving.ReadOnly = Not edit
        txtLeidinggevende.ReadOnly = Not edit
        txtReactie.ReadOnly = Not edit
        dtpOntvangenop.Enabled = edit
        dtpLeidinggevendeop.Enabled = edit
        txtAdviseur2.ReadOnly = Not edit
        dtpAdviseurop.Enabled = edit
        dtpAfhandelingsdatum.Enabled = edit

    End Sub

    Private Sub recordweergeven()

        m_datarow = m_dataset.Tables("tbl_klacht")(m_bindingsource.Position())

        If Not IsDBNull(m_datarow.Item(1)) Then
            txtProject.Text = m_datarow.Item(1)
        Else
            txtProject.Text = ""
        End If
        'If Not IsDBNull(m_datarow.Item(1)) Then
        '    txtKlacht.Text = m_datarow.Item(1)
        'Else
        '    txtKlacht.Text = ""
        'End If
        'If Not IsDBNull(m_datarow.Item(23)) Then
        '    txtAfgehandeldeklacht.Text = m_datarow.Item(23)
        'Else
        '    txtAfgehandeldeklacht.Text = ""
        'End If

        chkUrgent.Checked() = m_datarow.Item(2)

        If Not IsDBNull(m_datarow.Item(3)) Then
            txtOntvanger.Text = m_datarow.Item(3)
        Else
            txtOntvanger.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(4)) Then
            dtpOntvangenop.Text = m_datarow.Item(4)
        Else
            dtpOntvangenop.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(5)) Then
            txtOmschrijving.Text = m_datarow.Item(5)
        Else
            txtOmschrijving.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(6)) Then
            txtLeidinggevende.Text = m_datarow.Item(6)
        Else
            txtLeidinggevende.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(7)) Then
            dtpLeidinggevendeop.Text = m_datarow.Item(7)
        Else
            dtpLeidinggevendeop.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(8)) Then
            txtAdviseur2.Text = m_datarow.Item(8)
        Else
            txtAdviseur2.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(9)) Then
            dtpAdviseurop.Text = m_datarow.Item(9)
        Else
            dtpAdviseurop.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(10)) Then
            txtReactie.Text = m_datarow.Item(10)
        Else
            txtReactie.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(11)) Then
            dtpAfhandelingsdatum.Text = m_datarow.Item(11)
        Else
            dtpAfhandelingsdatum.Text = ""
        End If

        If Not IsDBNull(m_datarow.Item(14)) Then
            txtNaam.Text = m_datarow.Item(14)
        Else
            txtNaam.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(15)) Then
            txtAdres.Text = m_datarow.Item(15)
        Else
            txtAdres.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(16)) Then
            txtPlaats.Text = m_datarow.Item(16)
        Else
            txtPlaats.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(20)) Then
            txtPrive.Text = m_datarow.Item(20)
        Else
            txtPrive.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(21)) Then
            txtWerk.Text = m_datarow.Item(21)
        Else
            txtWerk.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(22)) Then
            txtMobiel.Text = m_datarow.Item(22)
        Else
            txtMobiel.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(23)) Then
            txtEmail.Text = m_datarow.Item(23)
        Else
            txtEmail.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(19)) Then
            txtAdviseur.Text = m_datarow.Item(19)
        Else
            txtAdviseur.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(17)) Then
            txtEpaadres.Text = m_datarow.Item(17)
        Else
            txtEpaadres.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(18)) Then
            txtEpaplaats.Text = m_datarow.Item(18)
        Else
            txtEpaplaats.Text = ""
        End If

    End Sub

    Private Sub recordweergeven_nieuweklacht(ByVal m_datarow3)

        If Not IsDBNull(m_datarow3.Item(0)) Then
            txtProject.Text = m_datarow3.Item(0)
        Else
            txtProject.Text = ""
        End If
 
        If Not IsDBNull(m_datarow3.Item(1)) Then
            txtNaam.Text = m_datarow3.Item(1)
        Else
            txtNaam.Text = ""
        End If
        If Not IsDBNull(m_datarow3.Item(2)) Then
            txtAdres.Text = m_datarow3.Item(2)
        Else
            txtAdres.Text = ""
        End If
        If Not IsDBNull(m_datarow3.Item(3)) Then
            txtPlaats.Text = m_datarow3.Item(3)
        Else
            txtPlaats.Text = ""
        End If
        If Not IsDBNull(m_datarow3.Item(4)) Then
            txtEpaadres.Text = m_datarow3.Item(4)
        Else
            txtEpaadres.Text = ""
        End If
        If Not IsDBNull(m_datarow3.Item(5)) Then
            txtEpaplaats.Text = m_datarow3.Item(5)
        Else
            txtEpaplaats.Text = ""
        End If
        If Not IsDBNull(m_datarow3.Item(6)) Then
            txtPrive.Text = m_datarow3.Item(6)
        Else
            txtPrive.Text = ""
        End If
        If Not IsDBNull(m_datarow3.Item(7)) Then
            txtWerk.Text = m_datarow3.Item(7)
        Else
            txtWerk.Text = ""
        End If
        If Not IsDBNull(m_datarow3.Item(8)) Then
            txtMobiel.Text = m_datarow3.Item(8)
        Else
            txtMobiel.Text = ""
        End If
        If Not IsDBNull(m_datarow3.Item(9)) Then
            txtEmail.Text = m_datarow3.Item(9)
        Else
            txtEmail.Text = ""
        End If
        If Not IsDBNull(m_datarow3.Item(10)) Then
            txtAdviseur.Text = m_datarow3.Item(10)
            txtAdviseur2.Text = m_datarow3.Item(10)
        Else
            txtAdviseur.Text = ""
            txtAdviseur2.Text = ""
        End If

    End Sub

    Private Sub veldenleegmaken()

        txtProject.Text = ""
        'txtKlacht.Text = ""
        'txtAfgehandeldeklacht.Text = ""

        chkUrgent.Checked() = False
        txtOntvanger.Text = ""
        txtOmschrijving.Text = ""
        txtLeidinggevende.Text = ""
        txtReactie.Text = ""
        dtpOntvangenop.Text = ""
        dtpLeidinggevendeop.Text = ""
        txtAdviseur2.Text = ""
        dtpAdviseurop.Text = ""
        dtpAfhandelingsdatum.Text = ""

        txtNaam.Text = ""
        txtAdres.Text = ""
        txtPlaats.Text = ""
        txtPrive.Text = ""
        txtWerk.Text = ""
        txtMobiel.Text = ""
        txtEmail.Text = ""
        txtAdviseur.Text = ""
        txtEpaadres.Text = ""
        txtEpaplaats.Text = ""

    End Sub

    Private Sub inhoudvullen()

        If m_nieuw Then
            m_max_id += 1
            m_datarow.Item(0) = m_max_id
            If txtProject.Text <> "" Then
                m_datarow.Item(1) = txtProject.Text
            Else
                m_datarow.Item(1) = DBNull
            End If
        End If

        m_datarow.Item(2) = chkUrgent.Checked()

        If txtOntvanger.Text <> "" Then
            m_datarow.Item(3) = txtOntvanger.Text
        Else
            m_datarow.Item(3) = DBNull
        End If
        If dtpOntvangenop.Checked() Then
            m_datarow.Item(4) = dtpOntvangenop.Text
        Else
            m_datarow.Item(4) = System.DBNull.Value
        End If
        If txtOmschrijving.Text <> "" Then
            m_datarow.Item(5) = txtOmschrijving.Text()
        Else
            m_datarow.Item(5) = DBNull
        End If
        If txtLeidinggevende.Text <> "" Then
            m_datarow.Item(6) = txtLeidinggevende.Text
        Else
            m_datarow.Item(6) = DBNull
        End If
        If dtpLeidinggevendeop.Checked() Then
            m_datarow.Item(7) = dtpLeidinggevendeop.Text
        Else
            m_datarow.Item(7) = System.DBNull.Value
        End If
        If txtAdviseur2.Text <> "" Then
            m_datarow.Item(8) = txtAdviseur2.Text
        Else
            m_datarow.Item(8) = DBNull
        End If
        If dtpAdviseurop.Checked() Then
            m_datarow.Item(9) = dtpAdviseurop.Text
        Else
            m_datarow.Item(9) = System.DBNull.Value
        End If
        If txtReactie.Text <> "" Then
            m_datarow.Item(10) = txtReactie.Text
        Else
            m_datarow.Item(10) = DBNull
        End If
        If dtpAfhandelingsdatum.Checked() Then
            m_datarow.Item(11) = dtpAfhandelingsdatum.Text
        Else
            m_datarow.Item(11) = System.DBNull.Value
        End If

        If txtNaam.Text <> "" Then
            m_datarow.Item(14) = txtNaam.Text
        Else
            m_datarow.Item(14) = DBNull
        End If
        If txtAdres.Text <> "" Then
            m_datarow.Item(15) = txtAdres.Text
        Else
            m_datarow.Item(15) = DBNull
        End If
        If txtPlaats.Text <> "" Then
            m_datarow.Item(16) = txtPlaats.Text
        Else
            m_datarow.Item(16) = DBNull
        End If
        If txtPrive.Text <> "" Then
            m_datarow.Item(20) = txtPrive.Text
        Else
            m_datarow.Item(20) = DBNull
        End If
        If txtWerk.Text <> "" Then
            m_datarow.Item(21) = txtWerk.Text
        Else
            m_datarow.Item(21) = DBNull
        End If
        If txtMobiel.Text <> "" Then
            m_datarow.Item(22) = txtMobiel.Text
        Else
            m_datarow.Item(22) = DBNull
        End If
        If txtEmail.Text <> "" Then
            m_datarow.Item(23) = txtEmail.Text
        Else
            m_datarow.Item(23) = DBNull
        End If
        If txtAdviseur.Text <> "" Then
            m_datarow.Item(19) = txtAdviseur.Text
        Else
            m_datarow.Item(19) = DBNull
        End If
        If txtEpaadres.Text <> "" Then
            m_datarow.Item(17) = txtEpaadres.Text
        Else
            m_datarow.Item(17) = DBNull
        End If
        If txtEpaplaats.Text <> "" Then
            m_datarow.Item(18) = txtEpaplaats.Text
        Else
            m_datarow.Item(18) = DBNull
        End If

    End Sub

    Private Sub inhoudvullen_klacht(ByVal m_datarow2 As DataRow)

        If m_nieuw Then
            m_datarow2.Item(0) = m_max_id

            If txtProject.Text <> "" Then
                m_datarow2.Item(1) = txtProject.Text
            Else
                m_datarow2.Item(1) = DBNull
            End If
        End If

        m_datarow2.Item(2) = chkUrgent.Checked()

        If txtOntvanger.Text <> "" Then
            m_datarow2.Item(3) = txtOntvanger.Text
        Else
            m_datarow2.Item(3) = DBNull
        End If
        If dtpOntvangenop.Checked() Then
            m_datarow2.Item(4) = dtpOntvangenop.Text
        Else
            m_datarow2.Item(4) = System.DBNull.Value
        End If
        If txtOmschrijving.Text <> "" Then
            m_datarow2.Item(5) = txtOmschrijving.Text()
        Else
            m_datarow2.Item(5) = DBNull
        End If
        If txtLeidinggevende.Text <> "" Then
            m_datarow2.Item(6) = txtLeidinggevende.Text
        Else
            m_datarow2.Item(6) = DBNull
        End If
        If dtpLeidinggevendeop.Checked() Then
            m_datarow2.Item(7) = dtpLeidinggevendeop.Text
        Else
            m_datarow2.Item(7) = System.DBNull.Value
        End If
        If txtAdviseur2.Text <> "" Then
            m_datarow2.Item(8) = txtAdviseur2.Text
        Else
            m_datarow2.Item(8) = DBNull
        End If
        If dtpAdviseurop.Checked() Then
            m_datarow2.Item(9) = dtpAdviseurop.Text
        Else
            m_datarow2.Item(9) = System.DBNull.Value
        End If
        If txtReactie.Text <> "" Then
            m_datarow2.Item(10) = txtReactie.Text
        Else
            m_datarow2.Item(10) = DBNull
        End If
        If dtpAfhandelingsdatum.Checked() Then
            m_datarow2.Item(11) = dtpAfhandelingsdatum.Text
        Else
            m_datarow2.Item(11) = System.DBNull.Value
        End If
        'If dtpAfhandelingsdatum.Text <> "" Then
        '    m_datarow2.Item(12) = dtpAfhandelingsdatum.Text
        'Else
        '    m_datarow2.Item(12) = System.DBNull.Value
        'End If
        'If dtpAfhandelingsdatum.Text <> "" Then
        '    m_datarow2.Item(13) = dtpAfhandelingsdatum.Text
        'Else
        '    m_datarow2.Item(13) = System.DBNull.Value
        'End If

    End Sub

    Private Sub btnZkproject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZkproject.Click
        Dim m_zkprojectzonderklachtdlg As New ZkprojectzonderklachtDlg
        Dim m_project As String
 

        m_zkprojectzonderklachtdlg.ShowDialog()
        If m_zkprojectzonderklachtdlg.DialogResult = Windows.Forms.DialogResult.OK Then
            m_project = m_zkprojectzonderklachtdlg.Project()

            Dim m_sqlstring2 As String = "SELECT tbl_klant.projectcode, [tbl_klant].[aanspreektitel] & ' ' & [tbl_klant.voorletters] & ' ' & [tbl_klant.tussenvoegsels] & ' ' & [tbl_klant.achternaam] AS klant, [tbl_klant].[straat] & ' ' & [tbl_klant].[huisnummer] AS postadres, Left([tbl_klant].[postcode],4) & ' ' & Right([tbl_klant].[postcode],2) & ' ' & [tbl_klant].[plaats] AS postplaats, [tbl_klant].[EPA_straat] & ' ' & [tbl_klant].[EPA_huisnummer] AS epaadres, Left([tbl_klant].[EPA_postcode],4) & ' ' & Right([tbl_klant].[EPA_postcode],2) & ' ' & [tbl_klant].[EPA_plaats] AS epaplaats, tbl_klant.privé_telefoonnr, tbl_klant.mobiel_telefoonnr, tbl_klant.werk_telefoonnr, tbl_klant.email, [tbl_adviseur.voorletters] & ' ' & [tbl_adviseur.achternaam] AS [naam_adviseur]" _
                 & " FROM tbl_adviseur RIGHT JOIN (tbl_project INNER JOIN tbl_klant ON tbl_project.projectcode = tbl_klant.projectcode) ON tbl_adviseur.adviseur_ID = tbl_project.adviseur_ID" _
                 & " WHERE tbl_klant.projectcode = '" & m_project & "' ORDER BY tbl_project.projectcode"
            Dim m_dataadapter3 As New OleDbDataAdapter(m_sqlstring2, m_connection)
            Dim m_commandbuilder3 As New OleDbCommandBuilder(m_dataadapter3)
            Dim m_dataset3 As New DataSet
            Dim m_datarow3 As DataRow

            m_dataadapter3.Fill(m_dataset3, "tbl_project")
            m_datarow3 = m_dataset3.Tables("tbl_project")(0)
            recordweergeven_nieuweklacht(m_datarow3)
         End If

    End Sub

    Private Sub btnZkklacht_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZkklacht.Click
        Dim m_Zkklachtdlg As New ZkklachtDlg
        Dim m_project As String

        m_Zkklachtdlg.Afgehandeld() = False
        m_Zkklachtdlg.ShowDialog()
        If m_Zkklachtdlg.DialogResult = Windows.Forms.DialogResult.OK Then
            m_project = m_Zkklachtdlg.Project()

            Me.Cursor() = Cursors.WaitCursor
            m_bindingsource.MoveFirst()

            m_datarow = m_dataset.Tables("tbl_klacht")(m_bindingsource.Position())
            While m_bindingsource.Position() + 1 <= m_bindingsource.Count() And Compare(m_datarow.Item(1), m_project, False) < 0
                m_bindingsource.MoveNext()
                m_datarow = m_dataset.Tables("tbl_klacht")(m_bindingsource.Position())
            End While

            recordweergeven()
            Me.Cursor() = Cursors.Arrow
        End If
    End Sub

    Private Sub btnZkafgehandeldeklacht_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZkafgehandeldeklacht.Click
        Dim m_Zkklachtdlg As New ZkklachtDlg
        Dim m_project As String

        m_Zkklachtdlg.Afgehandeld() = True
        m_Zkklachtdlg.ShowDialog()
        If m_Zkklachtdlg.DialogResult = Windows.Forms.DialogResult.OK Then
            m_project = m_Zkklachtdlg.Project()

            Me.Cursor() = Cursors.WaitCursor
            m_bindingsource.MoveFirst()

            m_datarow = m_dataset.Tables("tbl_klacht")(m_bindingsource.Position())
            While m_bindingsource.Position() + 1 <= m_bindingsource.Count() And Compare(m_datarow.Item(1), m_project, False) < 0
                m_bindingsource.MoveNext()
                m_datarow = m_dataset.Tables("tbl_klacht")(m_bindingsource.Position())
            End While

            recordweergeven()
            Me.Cursor() = Cursors.Arrow
        End If
    End Sub

    'Private Sub btnZkadviseur_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZkafgehandeldeklacht.Click
    '    Dim m_zkadviseurdlg As New ZkadviseurDlg

    '    m_zkadviseurdlg.ShowDialog()
    '    If m_zkadviseurdlg.DialogResult = Windows.Forms.DialogResult.OK Then
    '        txtAdviseur.Text = m_zkadviseurdlg.Adviseur("c")
    '        m_datarow = m_dataset.Tables("tbl_klant")(m_bindingsource.Position())
    '        m_datarow.Item(29) = m_zkadviseurdlg.Adviseur_id()
    '        'm_datarow3 = m_dataset3.Tables("tbl_project")(m_bindingsource.Position())
    '        'm_datarow3.Item(10) = m_zkadviseurdlg.Adviseur_id()
    '    End If

    'End Sub

    Private Sub KlantView_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        EAISIVSchermen.Klachtviewed() = False
    End Sub

End Class