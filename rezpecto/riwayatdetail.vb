Imports System.Data.Odbc

Public Class riwayatdetail
    Sub datagrid()
        'untuk menampilkan data ke grid
        datad = New OdbcDataAdapter("SELECT * FROM detailpembelian order by pembelian_id", konek)
        datset = New DataSet
        datad.Fill(datset, "detailpembelian")
        DataGridView1.DataSource = datset.Tables("detailpembelian")
        DataGridView1.ReadOnly = True

        DataGridView1.Columns("pembelian_id").HeaderText = "Nomor Pembelian"
        DataGridView1.Columns("barang_id").HeaderText = "ID Menu"
        DataGridView1.Columns("hargadapur").HeaderText = "Harga"
        DataGridView1.Columns("hargajual").HeaderText = "Harga (PPN)"
        DataGridView1.Columns("qty").HeaderText = " QTY"
        DataGridView1.Columns("subtotal").HeaderText = "Subtotal"
        DataGridView1.Columns("pengguna_id").HeaderText = "ID Pengguna"

        DataGridView1.Columns("pembelian_id").Width = "110"
        DataGridView1.Columns("barang_id").Width = "100"
        DataGridView1.Columns("hargadapur").Width = "100"
        DataGridView1.Columns("hargajual").Width = "100"
        DataGridView1.Columns("qty").Width = "100"
        DataGridView1.Columns("subtotal").Width = "100"
        DataGridView1.Columns("pengguna_id").Width = "120"
    End Sub

    Sub idmenu()
        Try
            Call koneksiodbc()
            datad = New OdbcDataAdapter("SELECT * FROM detailpembelian where barang_id like '%" & TextBox1.Text & "%'", konek)
            datset = New DataSet
            datad.Fill(datset)
            DataGridView1.DataSource = datset.Tables(0)

        Catch ex As Exception

        End Try
    End Sub
    Sub nopembelian()
        Try
            Call koneksiodbc()
            datad = New OdbcDataAdapter("SELECT * FROM detailpembelian where pembelian_id like '%" & TextBox1.Text & "%'", konek)
            datset = New DataSet
            datad.Fill(datset)
            DataGridView1.DataSource = datset.Tables(0)

        Catch ex As Exception
        End Try
    End Sub
    Sub iduser()
        Try
            Call koneksiodbc()
            datad = New OdbcDataAdapter("SELECT * FROM detailpembelian where pengguna_id like '%" & TextBox1.Text & "%'", konek)
            datset = New DataSet
            datad.Fill(datset)
            DataGridView1.DataSource = datset.Tables(0)

        Catch ex As Exception
        End Try
    End Sub
    Private Sub riwayatdetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        datagrid()
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        TextBox1.Enabled = True
        TextBox1.Text = ""
        datagrid()
        TextBox1.Focus()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If RadioButton1.Checked = True Then
            If (e.KeyChar = Chr(13)) Then
                idmenu()
            End If
        ElseIf RadioButton2.Checked = True Then
            If (e.KeyChar = Chr(13)) Then
                iduser()
            End If
        Else
            nopembelian()
        End If
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

    Private Sub butMenu_Click(sender As Object, e As EventArgs) Handles butMenu.Click
        beranda.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Text = ""
        datagrid()
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub
End Class