Imports System.Data.Odbc
Public Class pengguna
    Public var_id As String
    Sub datagrid()
        'untuk menampilkan data ke grid
        datad = New OdbcDataAdapter("SELECT pengguna.id, cabang.namacabang, pengguna.namap, pengguna.namau, pengguna.level from pengguna inner join cabang on pengguna.cabang_id = cabang.id order by pengguna.id", konek)
        datset = New DataSet
        datad.Fill(datset, "pengguna")
        DataGridView1.DataSource = datset.Tables("pengguna")
        DataGridView1.ReadOnly = True

        DataGridView1.Columns("id").HeaderText = "ID"
        DataGridView1.Columns("namacabang").HeaderText = "Cabang"
        DataGridView1.Columns("namap").HeaderText = "Nama Pengguna"
        DataGridView1.Columns("namau").HeaderText = "Username"
        DataGridView1.Columns("level").HeaderText = "Jabatan"

        DataGridView1.Columns("id").Width = "50"
        DataGridView1.Columns("namacabang").Width = "150"
        DataGridView1.Columns("namap").Width = "150"
    End Sub
    Sub kosong()
        ComboBox1.Text = ""
        ComboBox2.Text = ""
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        var_id = ""
        TextBox1.Focus()
    End Sub
    Sub ambilcabang()
        'untuk mengambil data dari database tabel cabang
        comm = New OdbcCommand("SELECT id, namacabang FROM cabang", konek)
        datread = comm.ExecuteReader
        While datread.Read()
            ComboBox1.Items.Add(datread("id") & Space(3) & datread("namacabang"))
        End While
    End Sub
    Private Sub pengguna_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksiodbc()
        datagrid()
        ambilcabang()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        koneksiodbc()
        comm = New OdbcCommand("SELECT * FROM pengguna where id ='" + var_id + "'", konek)
        datread = comm.ExecuteReader
        datread.Read()
        If Not datread.HasRows Then
            Dim simpan As String
            simpan = "INSERT into pengguna (cabang_id, namap, level, namau, ktsandi) values('" &
                Mid(ComboBox1.Text, 1, 1) &
                "','" & TextBox1.Text &
                "','" & ComboBox2.Text &
                "','" & TextBox2.Text &
                "','" & TextBox3.Text &
                "')"

            comm = New OdbcCommand("SELECT * FROM cabang where id ='" + Mid(ComboBox1.Text, 1, 1) + "'", konek)
            datread = comm.ExecuteReader
            datread.Read()
            If datread.HasRows Then
                Dim ubah As String
                ubah = "UPDATE cabang set total='" & datread.Item("total") + 1 &
                    "'where id ='" & Mid(ComboBox1.Text, 1, 1) & "'"
                comm = New OdbcCommand(ubah, konek)
                comm.ExecuteNonQuery()
            End If

            comm = New OdbcCommand(simpan, konek)
            comm.ExecuteNonQuery()
        Else
            Dim ubah As String
            ubah = "UPDATE pengguna set cabang_id='" & Mid(ComboBox1.Text, 1, 1) &
                "', namap='" & TextBox1.Text &
                "', level='" & ComboBox2.Text &
                "', namau='" & TextBox2.Text &
                "', ktsandi='" & TextBox3.Text &
                "' WHERE id='" & var_id & "'"
            comm = New OdbcCommand(ubah, konek)
            comm.ExecuteNonQuery()
        End If
        datagrid()
        kosong()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        var_id = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        ComboBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        ComboBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
        TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value
        TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(5).Value
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim pencarian As String
        pencarian = InputBox("Cari Data Berdasarkan ID", "Pencarian", "Isi Di Sini ...")

        comm = New OdbcCommand("SELECT * FROM pengguna where id = '" + pencarian + "'", konek)
        datread = comm.ExecuteReader
        datread.Read()
        If datread.HasRows Then
            var_id = pencarian
            ComboBox1.Text = datread.Item("cabang_id")
            TextBox1.Text = datread.Item("namap")
            ComboBox2.Text = datread.Item("level")
            TextBox2.Text = datread.Item("namau")
            TextBox3.Text = datread.Item("ktsandi")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        kosong()
    End Sub

    Private Sub butMenu_Click(sender As Object, e As EventArgs) Handles butMenu.Click
        beranda.Show()
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim carihapus As String
        carihapus = InputBox("Hapus Data Berdasarkan ID", "Pencarian", "Isi Di Sini...")

        Dim hapus As String
        hapus = "DELETE FROM pengguna where id ='" & carihapus & "'"
        comm = New OdbcCommand(hapus, konek)
        comm.ExecuteNonQuery()
        datagrid()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub
End Class