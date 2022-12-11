Imports System.Data.Odbc
Imports System.Reflection.Emit

Public Class riwayat
    Sub tanggal()
        Try
            Call koneksiodbc()
            datad = New OdbcDataAdapter("SELECT * FROM pembelian where tglbeli like '%" & TextBox1.Text & "%'", konek)
            datset = New DataSet
            datad.Fill(datset)
            DataGridView1.DataSource = datset.Tables(0)

        Catch ex As Exception

        End Try
    End Sub
    Sub nopembelian()
        Try
            Call koneksiodbc()
            datad = New OdbcDataAdapter("SELECT * FROM pembelian where id like '%" & TextBox1.Text & "%'", konek)
            datset = New DataSet
            datad.Fill(datset)
            DataGridView1.DataSource = datset.Tables(0)

        Catch ex As Exception
        End Try
    End Sub
    Sub iduser()
        Try
            Call koneksiodbc()
            datad = New OdbcDataAdapter("SELECT * FROM pembelian where pengguna_id like '%" & TextBox1.Text & "%'", konek)
            datset = New DataSet
            datad.Fill(datset)
            DataGridView1.DataSource = datset.Tables(0)

        Catch ex As Exception
        End Try
    End Sub
    Sub datagrid()
        'untuk menampilkan data ke grid
        datad = New OdbcDataAdapter("SELECT * FROM pembelian order by id", konek)
        datset = New DataSet
        datad.Fill(datset, "pembelian")
        DataGridView1.DataSource = datset.Tables("pembelian")
        DataGridView1.ReadOnly = True

        DataGridView1.Columns("id").HeaderText = "Nomor Pembelian"
        DataGridView1.Columns("tglbeli").HeaderText = "Tanggal Transaksi"
        DataGridView1.Columns("total").HeaderText = "Total"
        DataGridView1.Columns("dibayar").HeaderText = "Bayar"
        DataGridView1.Columns("kembalian").HeaderText = "Kembalian"
        DataGridView1.Columns("pengguna_id").HeaderText = "ID Pengguna"

        DataGridView1.Columns("id").Width = "100"
        DataGridView1.Columns("tglbeli").Width = "150"
        DataGridView1.Columns("total").Width = "100"
        DataGridView1.Columns("dibayar").Width = "100"
        DataGridView1.Columns("kembalian").Width = "100"
        DataGridView1.Columns("pengguna_id").Width = "110"
    End Sub

    Private Sub riwayat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        datagrid()
    End Sub

    Private Sub butMenu_Click(sender As Object, e As EventArgs) Handles butMenu.Click
        beranda.Show()
        Me.Hide()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If RadioButton1.Checked = True Then
            If (e.KeyChar = Chr(13)) Then
                tanggal()
            End If
        ElseIf RadioButton2.Checked = True Then
            If (e.KeyChar = Chr(13)) Then
                iduser()
            End If
        Else
            nopembelian()
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        TextBox1.Enabled = True
        TextBox1.Text = ""
        datagrid()
        TextBox1.Focus()
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        TextBox1.Enabled = True
        TextBox1.Text = ""
        datagrid()
        TextBox1.Focus()
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        TextBox1.Enabled = True
        TextBox1.Text = ""
        datagrid()
        TextBox1.Focus()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Text = ""
        datagrid()
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub
End Class