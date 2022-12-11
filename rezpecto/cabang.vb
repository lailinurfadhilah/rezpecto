Imports System.Data.Odbc
Public Class cabang
    Public var_id As String
    Sub kosong()
        TextBox1.Clear()
        TextBox2.Clear()
        var_id = ""
        TextBox1.Focus()
    End Sub
    Sub datagrid()
        'untuk menampilkan data ke grid
        datad = New OdbcDataAdapter("SELECT * from cabang order by id", konek)
        datset = New DataSet
        datad.Fill(datset, "cabang")
        DataGridView1.DataSource = datset.Tables("cabang")
        DataGridView1.ReadOnly = True

        DataGridView1.Columns("id").HeaderText = "ID"
        DataGridView1.Columns("namacabang").HeaderText = "Nama Cabang"
        DataGridView1.Columns("alamat").HeaderText = "Alamat"
        DataGridView1.Columns("total").HeaderText = "Total Pengguna"

        DataGridView1.Columns("id").Width = "50"
        DataGridView1.Columns("namacabang").Width = "200"
        DataGridView1.Columns("alamat").Width = "280"
    End Sub

    Private Sub cabang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksiodbc()
        datagrid()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        koneksiodbc()
        comm = New OdbcCommand("SELECT * FROM cabang where id ='" + var_id + "'", konek)
        datread = comm.ExecuteReader
        datread.Read()
        If Not datread.HasRows Then
            Dim simpan As String
            simpan = "INSERT into cabang (namacabang, alamat) values('" &
                TextBox1.Text &
                "','" & TextBox2.Text & "')"
            comm = New OdbcCommand(simpan, konek)
            comm.ExecuteNonQuery()
        Else
            Dim ubah As String
            ubah = "UPDATE cabang set namacabang='" & TextBox1.Text &
                "', alamat='" & TextBox2.Text &
                "' WHERE id='" & var_id & "'"
            comm = New OdbcCommand(ubah, konek)
            comm.ExecuteNonQuery()
        End If
        datagrid()
        kosong()
    End Sub

    Private Sub butMenu_Click(sender As Object, e As EventArgs) Handles butMenu.Click
        beranda.Show()
        Me.Close()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        var_id = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim pencarian As String
        pencarian = InputBox("Cari Data Berdasarkan ID", "Pencarian", "Isi Di Sini ...")

        comm = New OdbcCommand("SELECT * FROM cabang where id = '" + pencarian + "'", konek)
        datread = comm.ExecuteReader
        datread.Read()
        If datread.HasRows Then
            var_id = pencarian
            TextBox1.Text = datread.Item("namacabang")
            TextBox2.Text = datread.Item("alamat")
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim carihapus As String
        carihapus = InputBox("Hapus Data Berdasarkan ID", "Pencarian", "Isi Di Sini...")

        Dim hapus As String
        hapus = "DELETE FROM cabang where id ='" & carihapus & "'"
        comm = New OdbcCommand(hapus, konek)
        comm.ExecuteNonQuery()
        datagrid()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        kosong()
    End Sub
End Class