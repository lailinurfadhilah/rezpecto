Imports System.Data.Odbc
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class jenis
    Public var_id As String
    Sub datagrid()
        'untuk menampilkan data ke grid
        datad = New OdbcDataAdapter("SELECT * from jenis order by id", konek)
        datset = New DataSet
        datad.Fill(datset, "jenis")
        DataGridView1.DataSource = datset.Tables("jenis")
        DataGridView1.ReadOnly = True

        DataGridView1.Columns("id").HeaderText = "ID"
        DataGridView1.Columns("namajenis").HeaderText = "Nama Jenis"

        DataGridView1.Columns("id").Width = "50"
        DataGridView1.Columns("namajenis").Width = "200"
    End Sub
    Sub kosong()
        TextBox1.Clear()
        var_id = ""
        TextBox1.Focus()
    End Sub
    Private Sub jenis_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksiodbc()
        datagrid()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        koneksiodbc()
        comm = New OdbcCommand("SELECT * FROM jenis where id ='" + var_id + "'", konek)
        datread = comm.ExecuteReader
        datread.Read()
        If Not datread.HasRows Then
            Dim simpan As String
            simpan = "INSERT into jenis (namajenis) values ('" &
                TextBox1.Text &
                "')"
            comm = New OdbcCommand(simpan, konek)
            comm.ExecuteNonQuery()
        Else
            Dim ubah As String
            ubah = "UPDATE jenis set id='" & TextBox1.Text &
                "' WHERE id='" & var_id & "'"
            comm = New OdbcCommand(ubah, konek)
            comm.ExecuteNonQuery()
        End If
        datagrid()
        kosong()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim carihapus As String
        carihapus = InputBox("Hapus Data Berdasarkan ID", "Pencarian", "Isi Di Sini...")

        Dim hapus As String
        hapus = "DELETE FROM jenis where id ='" & carihapus & "'"
        comm = New OdbcCommand(hapus, konek)
        datagrid()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim pencarian As String
        pencarian = InputBox("Cari Data Berdasarkan ID", "Pencarian", "Isi Di Sini ...")

        comm = New OdbcCommand("SELECT * FROM jenis where id = '" + pencarian + "'", konek)
        datread = comm.ExecuteReader
        datread.Read()
        If datread.HasRows Then
            var_id = pencarian
            TextBox1.Text = datread.Item("namajenis")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        kosong()
    End Sub

    Private Sub butMenu_Click(sender As Object, e As EventArgs) Handles butMenu.Click
        beranda.Show()
        Me.Hide()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        var_id = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
    End Sub
End Class