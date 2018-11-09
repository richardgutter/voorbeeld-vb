Imports System.Data.OleDb
Imports System.String

Public Class ProjectcodeView

    Private m_combovisible As Boolean

    Private m_tonen As Boolean
    Private m_nieuw As Boolean
    Private m_wijzigen As Boolean

    Private m_strconn As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Richard\Documents\databases\EPACENTRUM\eaisIVnieuwdataII.mdb"
    Private m_connection As New OleDbConnection(m_strconn)
    Private m_dataadapter As New OleDbDataAdapter("Select * FROM tbl_projectcode ORDER BY projectcode", m_connection)
    Private m_commandbuilder As New OleDbCommandBuilder(m_dataadapter)
    Private m_dataset As New DataSet
    Private m_datarow As DataRow

    Private m_bindingsource As New BindingSource
    Private DBNull As Object

    Private Sub ProjectcodeView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        m_dataadapter.Fill(m_dataset, "tbl_projectcode")
        m_bindingsource.DataSource = m_dataset.Tables("tbl_projectcode")

        m_combovisible = False
        cboZkprojectcode.Visible = m_combovisible
        If m_combovisible Then
            cboZkprojectcode.ValueMember = "projectcode"
            Dim m_command_zk = New OleDbCommand("SELECT projectcode, omschrijving FROM tbl_projectcode ORDER BY projectcode DESC", m_connection)
            m_command_zk.Connection.Open()
            Dim m_datareader_zk As OleDbDataReader = m_command_zk.ExecuteReader()
            Me.Cursor() = Cursors.WaitCursor
            While m_datareader_zk.Read()
                cboZkprojectcode.Items.Add(m_datareader_zk("projectcode") & "          " & m_datareader_zk("omschrijving"))
            End While
            Me.Cursor() = Cursors.Arrow
            m_command_zk.Connection.Close()
        End If

        If m_bindingsource.Count() > 0 Then
            btnBekijken_Click()
        Else
            btnNieuw_Click()
        End If

    End Sub

    Private Sub btnBekijken_Click() Handles btnBekijken.Click
        'Private Sub btnBekijken_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBekijken.Click

        Me.Text = "Projectcodes - BEKIJKEN"

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
            cboZkprojectcode.Visible() = True
        End If
        btnZkprojectcode.Visible() = True

        btnEerste.Visible() = True
        btnVorige.Visible() = True
        btnVolgende.Visible() = True
        btnLaatste.Visible() = True

        btnOpslaan.Visible() = False
        btnNietOpslaan.Visible() = False

    End Sub

    Private Sub btnWijzigen_Click() Handles btnWijzigen.Click

        Me.Text = "Projectcodes - WIJZIGEN"

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
            cboZkprojectcode.Visible() = True
        End If
        btnZkprojectcode.Visible() = True

        btnEerste.Visible() = True
        btnVorige.Visible() = True
        btnVolgende.Visible() = True
        btnLaatste.Visible() = True

        btnOpslaan.Visible() = True
        btnNietOpslaan.Visible() = True

    End Sub

    Private Sub btnNieuw_Click() Handles btnNieuw.Click

        Me.Text = "Projectcodes - TOEVOEGEN"

        m_tonen = False
        m_nieuw = True
        m_wijzigen = False

        'GetDlgItem(IDC_MENU_BUTTON)->ShowWindow(SW_HIDE);
        'GetDlgItem(IDC_CODE_BUTTON)->ShowWindow(SW_HIDE);

        veldenediten(True)
        veldenleegmaken()

        If m_combovisible Then
            cboZkprojectcode.Visible() = False
        End If
        btnZkprojectcode.Visible() = False

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
                m_datarow = m_dataset.Tables("tbl_projectcode").NewRow
                inhoudvullen()
                m_dataset.Tables("tbl_projectcode").Rows.Add(m_datarow)
                m_dataadapter.Update(m_dataset, "tbl_projectcode")
                veldenleegmaken()
            ElseIf (m_wijzigen) Then
                m_datarow = m_dataset.Tables("tbl_projectcode")(m_bindingsource.Position())
                inhoudvullen()
                m_dataadapter.Update(m_dataset, "tbl_projectcode")
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

        Dim m_null As String = "0"

        If m_nieuw Then
            If MessageBox.Show("Weet u het zeker dat u deze gegevens wilt toevoegen?",
                               "Gegevens wijzigen", MessageBoxButtons.OKCancel) = vbCancel Then
                Return False
            End If
        End If

        If m_nieuw Then
            If aanwezig() Then
                MessageBox.Show("Deze projectcode bestaat al !\n",
                 "Gegevens wijzigen", MessageBoxButtons.OK)
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

        If m_wijzigen And txtProjectcode.Text <> m_datarow.Item(0) Then
            If txtVolgnummer.Text > 0 Then
                MessageBox.Show("Deze projectcode is al gebruikt en kan niet meer gewijzigd worden !\n",
                 "Gegevens wijzigen", MessageBoxButtons.OK)
                Return False
            End If
        End If

        If txtProjectcode.Text = "" Then
            MessageBox.Show("Projectcode moet ingevuld zijn !\n",
                            "Gegevens wijzigen", MessageBoxButtons.OK)
            Return False

        End If

        Return True
    End Function

    Function aanwezig()

        Dim m_aanwezig As Boolean

        If m_bindingsource.Count() > 0 Then
            Me.Cursor() = Cursors.WaitCursor
            m_bindingsource.MoveFirst()

            m_datarow = m_dataset.Tables("tbl_projectcode")(m_bindingsource.Position())
            While m_bindingsource.Position() + 1 < m_bindingsource.Count() And Compare(m_datarow.Item(0), txtProjectcode.Text, False) < 0
                m_bindingsource.MoveNext()
                m_datarow = m_dataset.Tables("tbl_projectcode")(m_bindingsource.Position())
            End While

            If Compare(m_datarow.Item(1), txtProjectcode.Text, False) = 0 Then
                m_aanwezig = True
            Else
                m_aanwezig = False
            End If
            Me.Cursor() = Cursors.Arrow
        Else
            m_aanwezig = False
        End If

        Return m_aanwezig
    End Function

    Private Sub veldenediten(ByVal edit As Boolean)

        txtProjectcode.ReadOnly = Not edit
        txtOmschrijving.ReadOnly = Not edit
        txtOpdrachtgever.ReadOnly = Not edit
        chkBegeleidingsbrief.Enabled = edit
        chkEigenlijst.Enabled = edit
        txtOpmerkingen.ReadOnly = Not edit

    End Sub

    Private Sub recordweergeven()

        m_datarow = m_dataset.Tables("tbl_projectcode")(m_bindingsource.Position())
        txtProjectcode.Text = m_datarow.Item(0)
        If Not IsDBNull(m_datarow.Item(1)) Then
            txtOmschrijving.Text = m_datarow.Item(1)
        Else
            txtOmschrijving.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(2)) Then
            txtVolgnummer.Text = m_datarow.Item(2)
        Else
            txtVolgnummer.Text = ""
        End If
        If Not IsDBNull(m_datarow.Item(3)) Then
            txtOpdrachtgever.Text = m_datarow.Item(3)
        Else
            txtOpdrachtgever.Text = ""
        End If
        chkBegeleidingsbrief.Checked() = m_datarow.Item(4)
        chkEigenlijst.Checked() = m_datarow.Item(5)
        If Not IsDBNull(m_datarow.Item(6)) Then
            txtOpmerkingen.Text = m_datarow.Item(6)
        Else
            txtOpmerkingen.Text = ""
        End If
    End Sub

    Private Sub veldenleegmaken()

        txtProjectcode.Text = ""
        txtOmschrijving.Text = ""
        txtVolgnummer.Text = 0
        txtOpdrachtgever.Text = ""
        chkBegeleidingsbrief.Checked() = False
        chkEigenlijst.Checked() = False
        txtOpmerkingen.Text = ""

    End Sub

    Private Sub inhoudvullen()

        m_datarow.Item(0) = txtProjectcode.Text
        If txtOmschrijving.Text <> "" Then
            m_datarow.Item(1) = txtOmschrijving.Text
        Else
            m_datarow.Item(1) = DBNull
        End If
        If txtOpdrachtgever.Text <> "" Then
            m_datarow.Item(3) = txtOpdrachtgever.Text
        Else
            m_datarow.Item(3) = DBNull
        End If
        m_datarow.Item(4) = chkBegeleidingsbrief.Checked()
        m_datarow.Item(5) = chkEigenlijst.Checked()
        If txtOpmerkingen.Text <> "" Then
            m_datarow.Item(6) = txtOpmerkingen.Text
        Else
            m_datarow.Item(6) = DBNull
        End If

    End Sub

    Private Sub btnZkprojectcode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZkprojectcode.Click
        Dim m_zkprojectcodedlg As New ZkprojectcodeDlg
        Dim m_projectcode As String

        m_zkprojectcodedlg.ShowDialog()
        If m_zkprojectcodedlg.DialogResult = Windows.Forms.DialogResult.OK Then
            m_projectcode = m_zkprojectcodedlg.Projectcode()

            Me.Cursor() = Cursors.WaitCursor
            m_bindingsource.MoveFirst()

            m_datarow = m_dataset.Tables("tbl_projectcode")(m_bindingsource.Position())
            While m_bindingsource.Position() + 1 <= m_bindingsource.Count() And Compare(m_datarow.Item(0), m_projectcode, False) < 0
                m_bindingsource.MoveNext()
                m_datarow = m_dataset.Tables("tbl_projectcode")(m_bindingsource.Position())
            End While

            recordweergeven()
            Me.Cursor() = Cursors.Arrow
        End If
    End Sub

    Private Sub cboZkprojectcode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboZkprojectcode.SelectedIndexChanged
        If Not m_nieuw Then
            Me.Cursor() = Cursors.WaitCursor
            m_bindingsource.MoveFirst()

            m_datarow = m_dataset.Tables("tbl_projectcode")(m_bindingsource.Position())
            While m_bindingsource.Position() + 1 <= m_bindingsource.Count() And Compare(m_datarow.Item(0) & "          " & m_datarow.Item(1), cboZkprojectcode.SelectedItem, False) < 0
                m_bindingsource.MoveNext()
                m_datarow = m_dataset.Tables("tbl_projectcode")(m_bindingsource.Position())
            End While

            recordweergeven()
            Me.Cursor() = Cursors.Arrow
        End If
    End Sub

    Private Sub ProjectcodeView_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        EAISIVSchermen.Projectcodeviewed() = False
    End Sub

End Class