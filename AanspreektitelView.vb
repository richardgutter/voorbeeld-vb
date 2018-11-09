Imports System.Data.OleDb
Imports System.String

Public Class AanspreektitelView

    Private m_combovisible As Boolean

    Private m_max_id As Integer

    Private m_tonen As Boolean
    Private m_nieuw As Boolean
    Private m_wijzigen As Boolean

    Private m_strconn As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Richard\Documents\databases\EPACENTRUM\eaisIVnieuwdataII.mdb"
    Private m_connection As New OleDbConnection(m_strconn)
    Private m_dataadapter As New OleDbDataAdapter("Select * FROM tbl_aanspreektitel ORDER BY aanspreektitel", m_connection)
    Private m_commandbuilder As New OleDbCommandBuilder(m_dataadapter)
    Private m_dataset As New DataSet
    Private m_datarow As DataRow
    Private m_bindingsource As New BindingSource

    Private Sub AanspreektitelView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        m_dataadapter.Fill(m_dataset, "tbl_aanspreektitel")
        m_bindingsource.DataSource = m_dataset.Tables("tbl_aanspreektitel")

        m_combovisible = False
        cboZkaanspreektitel.Visible = m_combovisible
        If m_combovisible Then
            cboZkaanspreektitel.ValueMember = "aanspreektitel"
            Dim m_command_zk = New OleDbCommand("SELECT aanspreektitel FROM tbl_aanspreektitel ORDER BY aanspreektitel DESC", m_connection)
            m_command_zk.Connection.Open()
            Dim m_datareader_zk As OleDbDataReader = m_command_zk.ExecuteReader()
            Me.Cursor() = Cursors.WaitCursor
            While m_datareader_zk.Read()
                cboZkaanspreektitel.Items.Add(m_datareader_zk("aanspreektitel"))
            End While
            Me.Cursor() = Cursors.Arrow
            m_command_zk.Connection.Close()
        End If

        Dim m_command_max = New OleDbCommand("SELECT MAX(aanspreektitel_ID) FROM tbl_aanspreektitel", m_connection)

        m_command_max.Connection.Open()
        Dim m_datareader_max As OleDbDataReader = m_command_max.ExecuteReader(CommandBehavior.CloseConnection)

        m_datareader_max.Read()
        If Not IsDBNull(m_datareader_max(0)) Then
            m_max_id = m_datareader_max(0)
        Else
            m_max_id = 0
        End If

        m_command_max.Connection.Close()

        If m_bindingsource.Count() > 0 Then
            btnBekijken_Click()
        Else
            btnNieuw_Click()
        End If

    End Sub

    Private Sub btnBekijken_Click() Handles btnBekijken.Click
        'Private Sub btnBekijken_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBekijken.Click

        Me.Text = "Aanspreektitels - BEKIJKEN"

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
            cboZkaanspreektitel.Visible() = True
        End If
        btnZkaanspreektitel.Visible() = True

        btnEerste.Visible() = True
        btnVorige.Visible() = True
        btnVolgende.Visible() = True
        btnLaatste.Visible() = True

        btnOpslaan.Visible() = False
        btnNietopslaan.Visible() = False

    End Sub

    Private Sub btnWijzigen_Click() Handles btnWijzigen.Click

        Me.Text = "Aanspreektitels - WIJZIGEN"

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
            cboZkaanspreektitel.Visible() = True
        End If
        btnZkaanspreektitel.Visible() = True

        btnEerste.Visible() = True
        btnVorige.Visible() = True
        btnVolgende.Visible() = True
        btnLaatste.Visible() = True

        btnOpslaan.Visible() = True
        btnNietopslaan.Visible() = True

    End Sub

    Private Sub btnNieuw_Click() Handles btnNieuw.Click

        Me.Text = "Aanspreektitels - TOEVOEGEN"

        m_tonen = False
        m_nieuw = True
        m_wijzigen = False

        'GetDlgItem(IDC_MENU_BUTTON)->ShowWindow(SW_HIDE);
        'GetDlgItem(IDC_CODE_BUTTON)->ShowWindow(SW_HIDE);

        veldenediten(True)
        veldenleegmaken()

        If m_combovisible Then
            cboZkaanspreektitel.Visible() = False
        End If
        btnZkaanspreektitel.Visible() = False

        btnEerste.Visible() = False
        btnVorige.Visible() = False
        btnVolgende.Visible() = False
        btnLaatste.Visible() = False

        btnOpslaan.Visible() = True
        btnNietopslaan.Visible() = True

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
                m_datarow = m_dataset.Tables("tbl_aanspreektitel").NewRow
                m_max_id += 1
                inhoudvullen()
                m_dataset.Tables("tbl_aanspreektitel").Rows.Add(m_datarow)
                m_dataadapter.Update(m_dataset, "tbl_aanspreektitel")
                veldenleegmaken()
            ElseIf (m_wijzigen) Then
                m_datarow = m_dataset.Tables("tbl_aanspreektitel")(m_bindingsource.Position())
                inhoudvullen()
                m_dataadapter.Update(m_dataset, "tbl_aanspreektitel")
            End If
        End If
    End Sub

    Private Sub btnNietOpslaan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNietopslaan.Click

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

        If m_nieuw Then
            If aanwezig() Then
                MessageBox.Show("Deze aanspreektitel bestaat al !\n",
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

        If txtAanspreektitel.Text = "" Then
            MessageBox.Show("Aanspreektitel moet ingevuld zijn !\n",
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

            m_datarow = m_dataset.Tables("tbl_aanspreektitel")(m_bindingsource.Position())
            While m_bindingsource.Position() + 1 < m_bindingsource.Count() And Compare(m_datarow.Item(1), txtAanspreektitel.Text, False) < 0
                m_bindingsource.MoveNext()
                m_datarow = m_dataset.Tables("tbl_aanspreektitel")(m_bindingsource.Position())
            End While

            If Compare(m_datarow.Item(1), txtAanspreektitel.Text, False) = 0 Then
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

        txtAanspreektitel.ReadOnly = Not edit

    End Sub

    Private Sub recordweergeven()

        m_datarow = m_dataset.Tables("tbl_aanspreektitel")(m_bindingsource.Position())
        txtAanspreektitel.Text = m_datarow.Item(1)

    End Sub

    Private Sub veldenleegmaken()

        txtAanspreektitel.Text = ""

    End Sub

    Private Sub inhoudvullen()

        If m_nieuw Then
            m_datarow.Item(0) = m_max_id
        End If
        m_datarow.Item(1) = txtAanspreektitel.Text

    End Sub

    Private Sub btnAanspreektitel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZkaanspreektitel.Click
        Dim m_zkaanspreektiteldlg As New ZkaanspreektitelDlg
        Dim m_aanspreektitel As String

        m_zkaanspreektiteldlg.ShowDialog()
        If m_zkaanspreektiteldlg.DialogResult = Windows.Forms.DialogResult.OK Then
            m_aanspreektitel = m_zkaanspreektiteldlg.Aanspreektitel()

            Me.Cursor() = Cursors.WaitCursor
            m_bindingsource.MoveFirst()

            m_datarow = m_dataset.Tables("tbl_aanspreektitel")(m_bindingsource.Position())
            While m_bindingsource.Position() + 1 <= m_bindingsource.Count() And Compare(m_datarow.Item(1), m_aanspreektitel, False) < 0
                m_bindingsource.MoveNext()
                m_datarow = m_dataset.Tables("tbl_aanspreektitel")(m_bindingsource.Position())
            End While

            recordweergeven()
            Me.Cursor() = Cursors.Arrow
        End If

    End Sub

    Private Sub cboZkaanspreektitel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboZkaanspreektitel.SelectedIndexChanged

        If Not m_nieuw Then
            Me.Cursor() = Cursors.WaitCursor
            m_bindingsource.MoveFirst()

            m_datarow = m_dataset.Tables("tbl_aanspreektitel")(m_bindingsource.Position())
            While m_bindingsource.Position() + 1 <= m_bindingsource.Count() And Compare(m_datarow.Item(1), cboZkaanspreektitel.SelectedItem, False) < 0
                m_bindingsource.MoveNext()
                m_datarow = m_dataset.Tables("tbl_aanspreektitel")(m_bindingsource.Position())
            End While

            recordweergeven()
            Me.Cursor() = Cursors.Arrow
        End If
    End Sub

    Private Sub AanspreektitelView_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        EAISIVSchermen.Aanpreektitelviewed() = False
    End Sub

End Class