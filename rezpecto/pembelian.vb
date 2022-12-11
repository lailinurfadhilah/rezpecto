Imports System.Data.Odbc
Public Class pembelian
    Public var_id As String
    Sub kosong()
        TextBox2.Clear()
        Label5.Text = ""
        Label6.Text = ""
        Label7.Text = ""
        Label15.Text = ""
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox2.Focus()
    End Sub

    Sub nootomatis()
        comm = New OdbcCommand("SELECT * from pembelian where id in (select(max(id)) from pembelian)", konek)
        datread = comm.ExecuteReader()
        datread.Read()
        Dim hitungno As Integer
        If Not datread.HasRows Then
            TextBox1.Text = Label13.Text + Label14.Text + Format(Now, "yyMMdd") + "0001"
        Else
            hitungno = Val(Microsoft.VisualBasic.Right(datread.Item("id").ToString, 4)) + 1
            TextBox1.Text = Label13.Text + Label14.Text + Format(Now, "yyMMdd") + "000" & hitungno
        End If
    End Sub

    Sub totalbelanja()
        TextBox6.Text = (From row As DataGridViewRow In DataGridView1.Rows
                         Where row.Cells(6).FormattedValue.ToString() <> String.Empty
                         Select Convert.ToInt32(row.Cells(6).FormattedValue)).Sum().ToString()
    End Sub
    Sub datagrid()
        'untuk menampilkan data ke grid
        datad = New OdbcDataAdapter("SELECT sementara.id, sementara.barang_id, barang.namabarang, sementara.hargadapur, sementara.hargajual, sementara.qty, sementara.subtotal from sementara inner join barang on sementara.barang_id = barang.id where sementara.pengguna_id ='" & Label13.Text & "' order by sementara.id desc", konek)
        datset = New DataSet
        datad.Fill(datset, "sementara")
        DataGridView1.DataSource = datset.Tables("sementara")
        DataGridView1.ReadOnly = True

        DataGridView1.Columns("id").HeaderText = "ID"
        DataGridView1.Columns("barang_id").HeaderText = "ID Menu"
        DataGridView1.Columns("namabarang").HeaderText = "Pesanan"
        DataGridView1.Columns("hargadapur").HeaderText = "Harga"
        DataGridView1.Columns("hargajual").HeaderText = "Harga (PPN)"
        DataGridView1.Columns("qty").HeaderText = "QTY"
        DataGridView1.Columns("subtotal").HeaderText = "Subtotal"

        DataGridView1.Columns("id").Width = "30"
        DataGridView1.Columns("barang_id").Width = "60"
    End Sub
    Private Sub pembelian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksiodbc()
        datagrid()
        nootomatis()
        totalbelanja()
        kosong()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        var_id = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(5).Value
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim simpan As String
        simpan = "INSERT into sementara (barang_id, hargadapur, hargajual, qty, subtotal, pengguna_id) values('" &
            TextBox2.Text &
            "','" & Label7.Text &
            "','" & Label15.Text &
            "','" & TextBox3.Text &
            "','" & TextBox3.Text * Label15.Text &
            "','" & Label13.Text &
            "')"

        comm = New OdbcCommand("SELECT stok from barang where id ='" & TextBox2.Text & "'", konek)
        datread = comm.ExecuteReader()
        datread.Read()
        If datread.HasRows Then
            Dim ubah As String = "UPDATE barang set stok ='" & datread("stok") - TextBox3.Text & 'mengurangi stok di database
                "' where id ='" & TextBox2.Text & "'"
            comm = New OdbcCommand(ubah, konek)
            comm.ExecuteNonQuery()
        End If
        comm = New OdbcCommand(simpan, konek)
        comm.ExecuteNonQuery()
        datagrid()
        totalbelanja()
        kosong()
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        comm = New OdbcCommand("SELECT * FROM barang where id ='" & TextBox2.Text & "'", konek)
        datread = comm.ExecuteReader
        datread.Read()
        If datread.HasRows Then
            Label5.Text = datread.Item("namabarang")
            Label6.Text = datread.Item("stok")
            Label7.Text = datread.Item("hargadapur")
            Label15.Text = datread.Item("hargajual")
        End If
    End Sub

    Private Sub butMenu_Click(sender As Object, e As EventArgs) Handles butMenu.Click
        beranda.Show()
        Me.Hide()
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        totalbelanja()
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim hapus As String
        hapus = "DELETE from sementara where id ='" & var_id & "'"

        comm = New OdbcCommand("SELECT stok from barang where id ='" & TextBox2.Text & "'", konek)
        datread = comm.ExecuteReader()
        datread.Read()
        If datread.HasRows Then
            Dim ubah As String = "UPDATE barang set stok ='" & datread("stok") + TextBox3.Text & 'stok kembali ke database krn batal beli
                "' where id ='" & TextBox2.Text & "'"
            comm = New OdbcCommand(ubah, konek)
            comm.ExecuteNonQuery()
        End If

        comm = New OdbcCommand(hapus, konek)
        comm.ExecuteNonQuery()

        datagrid()
        kosong()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        koneksiodbc()
        comm = New OdbcCommand("SELECT * from pembelian where id ='" & TextBox1.Text & "'", konek)
        datread = comm.ExecuteReader
        datread.Read()
        If Not datread.HasRows Then
            Dim simpan As String
            simpan = "INSERT into pembelian (id, tglbeli, total, dibayar, kembalian, pengguna_id) values ('" &
                TextBox1.Text &
                "','" & Format(Now, "yyyy-MM-dd") &
                "','" & TextBox6.Text &
                "','" & TextBox5.Text &
                "','" & TextBox4.Text &
                "','" & Label13.Text &
                "')"

            For baris As Integer = 0 To DataGridView1.RowCount - 2 'menambahkan namabarang, hargajual, bayar, kembalian
                Dim simpandetail As String
                simpandetail = "INSERT into detailpembelian (pembelian_id, barang_id,hargadapur, hargajual, qty, subtotal, pengguna_id) values('" &
                    TextBox1.Text & 'pembelian id ambil dari textbox1 
                    "','" & Val(DataGridView1.Rows(baris).Cells(1).Value) & 'baris 1 barang id
                    "','" & Val(DataGridView1.Rows(baris).Cells(3).Value) & 'baris 3 hargajual
                    "','" & Val(DataGridView1.Rows(baris).Cells(4).Value) & 'baris 4 hargabeli
                    "','" & Val(DataGridView1.Rows(baris).Cells(5).Value) & 'baris 5 qty
                    "','" & Val(DataGridView1.Rows(baris).Cells(6).Value) & 'baris 6 subtotal
                    "','" & Label13.Text & 'pengguna id ambil dari label 13
                    "')"
                comm = New OdbcCommand(simpandetail, konek)
                comm.ExecuteNonQuery()
            Next
            comm = New OdbcCommand(simpan, konek)
            comm.ExecuteNonQuery()

            Dim hapus As String = "DELETE from sementara"
            comm = New OdbcCommand(hapus, konek)
            comm.ExecuteNonQuery()

            nootomatis()
            datagrid()
            TextBox4.Clear()
            TextBox5.Clear()
            TextBox6.Clear()
            kosong()
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        nootomatis()
    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        If e.KeyChar = Chr(13) Then
            TextBox4.Text = TextBox5.Text - TextBox6.Text
        End If
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub
End Class