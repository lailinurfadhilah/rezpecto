Imports MySql.Data.MySqlClient
Imports System.Data.Odbc

Public Class datamenu
    Private Sub butMenu_Click(sender As Object, e As EventArgs) Handles butMenu.Click
        beranda.Show()
        Me.Hide()
    End Sub

    Sub tampildata()
        datad = New OdbcDataAdapter("SELECT * FROM data_menu", konek)
        datset = New DataSet
        datad.Fill(datset)
        tabData.DataSource = datset.Tables(0)
        tabData.ReadOnly = True
    End Sub

    Sub bersih()
        boxKode.Text = " "
        boxNama.Text = " "
        boxHarga.Text = " "
        boxStok.Text = " "
        boxKode.Focus()
    End Sub

    Private Sub butEdit_Click(sender As Object, e As EventArgs) Handles butEdit.Click
        Try
            If boxKode.Text = " " Then
                MsgBox("Kode Menu Tidak Boleh Kosong", vbExclamation, "Pesan")
                Exit Sub
            ElseIf boxNama.Text = " " Then
                MsgBox("Nama Menu Tidak Boleh Kosong", vbExclamation, "Pesan")
                Exit Sub
            ElseIf boxHarga.Text = " " Then
                MsgBox("Nama Harga Tidak Boleh Kosong", vbExclamation, "Pesan")
                Exit Sub
            ElseIf boxStok.Text = " " Then
                MsgBox("Stok Menu Tidak Boleh Kosong", vbExclamation, "Pesan")
                Exit Sub
            Else
                comm = New OdbcCommand("SELECT * FROM data_menu WHERE kd_data = '" & boxKode.Text & "'", konek)
                datread = comm.ExecuteReader
                datread.Read()
                If datread.HasRows Then
                    Dim edit As String = "UPDATE data_menu set nama_menu = '" & boxNama.Text &
                                            "', harga_menu = '" & boxHarga.Text &
                                            "', stok_menu = '" & boxStok.Text &
                                            "' WHERE kd_data = '" & boxKode.Text & "'"
                    comm = New OdbcCommand(edit, konek)
                    comm.ExecuteNonQuery()
                    MsgBox("Berhasil Diedit", vbInformation, "Edit")
                    Call tampildata()
                    Call bersih()
                Else
                    MsgBox("Data Belum Dipilih")
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            MsgBox("Oops! Ada kesalahan Dipengeditan" & ex.Message)
        End Try
    End Sub

    Private Sub tabData_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles tabData.CellContentClick

    End Sub

    Private Sub butTambah_Click_1(sender As Object, e As EventArgs) Handles butTambah.Click
        Call bersih()
    End Sub

    Private Sub butSimpan_Click(sender As Object, e As EventArgs) Handles butSimpan.Click
        Try
            If boxKode.Text = " " Then
                MsgBox("Kode Menu Tidak Boleh Kosong", vbExclamation, "Pesan")
                Exit Sub
            ElseIf boxNama.Text = " " Then
                MsgBox("Nama Menu Tidak Boleh Kosong", vbExclamation, "Pesan")
                Exit Sub
            ElseIf boxHarga.Text = " " Then
                MsgBox("Nama Harga Tidak Boleh Kosong", vbExclamation, "Pesan")
                Exit Sub
            ElseIf boxStok.Text = " " Then
                MsgBox("Stok Menu Tidak Boleh Kosong", vbExclamation, "Pesan")
                Exit Sub
            Else
                comm = New OdbcCommand("SELECT * FROM data_menu WHERE kd_data = '" & boxKode.Text & "'", konek)
                datread = comm.ExecuteReader
                datread.Read()
                If Not datread.HasRows Then
                    Dim simpan As String = "INSERT INTO data_menu values ('" & boxKode.Text & "','" _
                                                                            & boxNama.Text & "','" _
                                                                            & boxHarga.Text & "','" _
                                                                            & boxStok.Text & "' ) "
                    comm = New OdbcCommand(simpan, konek)
                    comm.ExecuteNonQuery()
                    MsgBox("Data Berhasil Disimpan", vbInformation, "Simpan")
                    Call tampildata()
                    Call bersih()
                Else
                    MsgBox("Data Sudah Ada")
                End If
            End If
        Catch ex As Exception
            MsgBox("Oops! Ada kesalahan Dipenyimpanan" & ex.Message)
        End Try
    End Sub

    Private Sub datamenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call koneksiodbc()
        Call tampildata()
    End Sub

    Private Sub butHapus_Click(sender As Object, e As EventArgs) Handles butHapus.Click
        If boxKode.Text = "" Then
            MsgBox("Datat Belum Dipilih", vbInformation, "Pesan")
            Exit Sub
        Else
            Dim hapus As String = "DELETE FROM data_menu WHERE kd_data = '" & boxKode.Text & "'"
            comm = New OdbcCommand(hapus, konek)

            comm.ExecuteNonQuery()
            MsgBox("Data Berhasil Dihapus", vbInformation, "Pesan")
            Call tampildata()
            Call bersih()
        End If
    End Sub

    Private Sub tabData_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles tabData.CellMouseClick
        On Error Resume Next
        boxKode.Text = tabData.Rows(e.RowIndex).Cells(0).Value
        comm = New OdbcCommand("SELECT * FROM data_menu WHERE kd_data = '" & boxKode.Text & "'", konek)
        datread = comm.ExecuteReader
        datread.Read()
        If datread.HasRows Then
            boxKode.Text = datread.Item("kd_data")
            boxNama.Text = datread.Item("nama_menu")
            boxHarga.Text = datread.Item("harga_menu")
            boxStok.Text = datread.Item("stok_menu")

        End If
    End Sub

    Private Sub boxKode_TextChanged(sender As Object, e As EventArgs) Handles boxKode.TextChanged

    End Sub
End Class