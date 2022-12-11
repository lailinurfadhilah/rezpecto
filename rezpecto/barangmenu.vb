Imports System.Data.Odbc
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class barangmenu
    Public var_id As String
    Sub datagrid()
        'untuk menampilkan data ke grid
        datad = New OdbcDataAdapter("SELECT * from barang order by id", konek)
        datset = New DataSet
        datad.Fill(datset, "barang")
        DataGridView1.DataSource = datset.Tables("barang")
        DataGridView1.ReadOnly = True

        DataGridView1.Columns("id").HeaderText = "ID"
        DataGridView1.Columns("namabarang").HeaderText = "Nama Menu"
        DataGridView1.Columns("jenis_id").HeaderText = "Jenis Menu"
        DataGridView1.Columns("hargadapur").HeaderText = "Harga Dapur"
        DataGridView1.Columns("hargajual").HeaderText = "Harga Jual"

        DataGridView1.Columns("id").Width = "50"
        DataGridView1.Columns("namabarang").Width = "200"
    End Sub
    Sub kosong()
        ComboBox1.Text = ""
        TextBox1.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        var_id = ""
        TextBox1.Focus()
    End Sub
    Sub ambiljenis()
        'untuk mengambil data dari database tabel cabang
        comm = New OdbcCommand("SELECT id, namajenis FROM jenis", konek)
        datread = comm.ExecuteReader
        While datread.Read()
            ComboBox1.Items.Add(datread("id") & Space(3) & datread("namajenis"))
        End While
    End Sub
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub barangmenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksiodbc()
        datagrid()
        ambiljenis()
    End Sub

    Private Sub butMenu_Click(sender As Object, e As EventArgs) Handles butMenu.Click
        beranda.Show()
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        koneksiodbc()
        comm = New OdbcCommand("SELECT * FROM barang where id ='" + var_id + "'", konek)
        datread = comm.ExecuteReader
        datread.Read()
        If Not datread.HasRows Then
            Dim simpan As String
            simpan = "INSERT into barang (jenis_id, namabarang, hargadapur, hargajual, stok) values('" &
                ComboBox1.Text &
                "','" & TextBox1.Text &
                "','" & TextBox3.Text &
                "','" & TextBox4.Text &
                 "','" & TextBox5.Text &
                "')"
            comm = New OdbcCommand(simpan, konek)
            comm.ExecuteNonQuery()
        Else
            Dim ubah As String
            ubah = "UPDATE barang set jenis_id='" & ComboBox1.Text &
                "', namabarang='" & TextBox1.Text &
                "', hargadapur='" & TextBox3.Text &
                "', hargajual='" & TextBox4.Text &
                "', stok='" & TextBox5.Text &
                "' WHERE id='" & var_id & "'"
            comm = New OdbcCommand(ubah, konek)
            comm.ExecuteNonQuery()
        End If
        datagrid()
        kosong()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        kosong()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim carihapus As String
        carihapus = InputBox("Hapus Data Berdasarkan ID", "Pencarian", "Isi Di Sini...")

        Dim hapus As String
        hapus = "DELETE FROM barang where id ='" & carihapus & "'"
        comm = New OdbcCommand(hapus, konek)
        comm.ExecuteNonQuery()
        datagrid()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim pencarian As String
        pencarian = InputBox("Cari Data Berdasarkan ID", "Pencarian", "Isi Di Sini ...")

        comm = New OdbcCommand("SELECT * FROM barang where id = '" + pencarian + "'", konek)
        datread = comm.ExecuteReader
        datread.Read()
        If datread.HasRows Then
            var_id = pencarian
            ComboBox1.Text = datread.Item("jenis_id")
            TextBox1.Text = datread.Item("namabarang")
            TextBox3.Text = datread.Item("hargadapur")
            TextBox4.Text = datread.Item("hargajual")
            TextBox5.Text = datread.Item("stok")
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        var_id = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        ComboBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
        TextBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value
        TextBox5.Text = DataGridView1.Rows(e.RowIndex).Cells(5).Value
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub
End Class