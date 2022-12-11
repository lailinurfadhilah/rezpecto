Imports System.Data.Odbc
Imports System.Runtime.Intrinsics.Arm

Public Class transaksi
    Dim kode As Long
    Dim nama, harga, stok, jumlah, total As Long
    Dim faktur, tgl As String
    Dim grandtotal, subtotal, kembali, bayar, diskon As Long

    Sub pindah()
        Dim jum, har, tot As Long
        jum = boxJumt.Text
        har = boxHargat.Text
        tot = boxTotalt.Text

        tabelTrans.AllowUserToAddRows = True
        tabelTrans.RowCount = tabelTrans.RowCount + 1
        tabelTrans(0, tabelTrans.RowCount - 2).Value = kode
        tabelTrans(1, tabelTrans.RowCount - 2).Value = boxNamat.Text
        tabelTrans(2, tabelTrans.RowCount - 2).Value = jum
        tabelTrans(3, tabelTrans.RowCount - 2).Value = har
        tabelTrans(4, tabelTrans.RowCount - 2).Value = tot
        tabelTrans.AllowUserToAddRows = True

        Dim b_atasjumlah As Long
        For barisatas As Long = 0 To tabelTrans.RowCount - 1
            For barisbawah As Long = barisatas + 1 To tabelTrans.RowCount - 1
                b_atasjumlah = tabelTrans.Rows(barisatas).Cells(2).Value

                If tabelTrans.Rows(barisbawah).Cells(0).Value = tabelTrans.Rows(barisatas).Cells(0) Then
                    Dim totjumlah As Long
                    totjumlah = b_atasjumlah + tabelTrans.Rows(barisbawah).Cells(2).Value
                    If totjumlah > stok Then
                        MessageBox.Show("Jumlah lebih besar dari stok yang ada" & vbCrLf _
                                & "Stok hanya " & stok, "Oops", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        tabelTrans.Rows(barisatas).Cells(2).Value = stok
                        tabelTrans.Rows(barisatas).Cells(3).Value = tabelTrans.Rows(barisbawah).Cells(3).Value
                        tabelTrans.Rows(barisatas).Cells(4).Value = (tabelTrans.Rows(barisatas).Cells(2).Value * tabelTrans.Rows(barisatas).Cells(3).Value)
                        tabelTrans.CurrentCell = tabelTrans.Rows(barisbawah).Cells(2)
                        hapusrow()
                    Else
                        tabelTrans.Rows(barisatas).Cells(2).Value = b_atasjumlah + tabelTrans.Rows(barisbawah).Cells(2).Value
                        tabelTrans.Rows(barisatas).Cells(3).Value = tabelTrans.Rows(barisbawah).Cells(3).Value
                        tabelTrans.Rows(barisatas).Cells(4).Value = (tabelTrans.Rows(barisatas).Cells(2).Value * tabelTrans.Rows(barisatas).Cells(3).Value)
                        tabelTrans.CurrentCell = tabelTrans.Rows(barisbawah).Cells(2)
                        hapusrow()
                    End If
                End If
            Next
        Next
        Hitunggrandtotal()
    End Sub

    Private Sub boxKodet_TextChanged(sender As Object, e As EventArgs) Handles boxKodet.TextChanged

    End Sub

    Sub hapusrow()
        If tabelTrans.CurrentRow.Index <> tabelTrans.NewRowIndex Then
            tabelTrans.Rows.RemoveAt(tabelTrans.CurrentRow.Index)
        End If
    End Sub
    Sub Hitunggrandtotal()
        Dim hitung As Long = 0
        boxDiskon.Text = 0
        For baris As Long = 0 To tabelTrans.RowCount - 1

        Next
        subtotal = hitung
        boxSubt.Text = Format(hitung, "##,##0")
        diskon = boxDiskon.Text
        boxGrandt.Text = "Rp. " + Format(hitung - diskon, "##,##0")
        boxGrandt.Text = Format(hitung - diskon, "##,##0")
        grandtotal = hitung - diskon
    End Sub

    Private Sub boxDiskon_TextChanged(sender As Object, e As EventArgs) Handles boxDiskon.TextChanged

    End Sub

    Private Sub butMenu_Click(sender As Object, e As EventArgs) Handles butMenu.Click
        beranda.Show()
        Me.Close()
    End Sub

    Private Sub transaksi_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Sub nofaktur()
        Dim tgl As String = Format(Today, "ddMMyy")
        koneksiodbc()
        comm = New Odbc.OdbcCommand("SELECT * FROM tbl_jual WHERE left (no_faktur,6) = '" & tgl & "' order by no_faktur desc,", konek)
        datread = comm.ExecuteReader
        datread.Read()

        If datread.HasRows Then
            faktur = Val(Microsoft.VisualBasic.Mid(datread.Item("no_faktur").ToString, 7, 4)) + 1
            If Len(faktur) = 1 Then
                faktur = tgl + "000" & faktur
            ElseIf Len(faktur) = 2 Then
                faktur = tgl + "00" & faktur
            ElseIf Len(faktur) = 3 Then
                faktur = tgl + "0" & faktur
            ElseIf Len(faktur) = 4 Then
                faktur = tgl & faktur
            End If
        Else
            faktur = tgl + "000"
        End If
        tutup()
    End Sub

    Sub simpanjual()
        tgl = Format("dd/MM/yy HH:mm:ss")
        Try
            'simpan tabel jual
            koneksiodbc()
            str = "INSERT into tbl_jual values (@faktur, @tgl, @subtotal, @diskon, @grandtotal, @bayar @username)"
            comm = konek.CreateCommand
            With comm
                .CommandText = str
                .Connection = konek
                .Parameters.Add("faktur", odbcType:=OdbcType.Text = 20).Value = faktur
                .Parameters.Add("tgl", odbcType:=OdbcType.DateTime).Value = tgl
                .Parameters.Add("subtotal", odbcType:=OdbcType.BigInt = 10).Value = subtotal
                .Parameters.Add("diskon", odbcType:=OdbcType.BigInt = 10).Value = diskon
                .Parameters.Add("grandtotal", odbcType:=OdbcType.BigInt = 10).Value = grandtotal
                .Parameters.Add("dibayar", odbcType:=OdbcType.BigInt = 10).Value = bayar
                .Parameters.Add("username", odbcType:=OdbcType.BigInt = 10).Value = "admin"
                .ExecuteNonQuery()
            End With
            tutup()

            'simpan tabel detail jual
            For baris As Long = 0 To tabelTrans.RowCount - 1
                koneksiodbc()
                str = "insert into tbl_djual values (@faktur, @kode, @jumlah, @harga, @total)"
                comm = konek.CreateCommand
                With comm
                    .CommandText = str
                    .Connection = konek
                    .Parameters.Add("faktur", odbcType:=OdbcType.Text = 20).Value = faktur
                    .Parameters.Add("kode", odbcType:=OdbcType.Text = 20).Value = tabelTrans.Rows(baris).Cells(0).Value
                    .Parameters.Add("jumlah", odbcType:=OdbcType.BigInt = 10).Value = tabelTrans.Rows(baris).Cells(2).Value
                    .Parameters.Add("harga", odbcType:=OdbcType.BigInt = 10).Value = tabelTrans.Rows(baris).Cells(3).Value
                    .Parameters.Add("total", odbcType:=OdbcType.BigInt = 10).Value = tabelTrans.Rows(baris).Cells(4).Value
                    .ExecuteNonQuery()
                End With
                tutup()

                'kurang stok
                koneksiodbc()
                comm = New OdbcCommand("select * from data_menu where kd_data = '" & tabelTrans.Rows(baris).Cells(0).Value & "'", konek)
                datread = comm.ExecuteReader
                datread.Read()
                If datread.HasRows Then
                    Dim stk, jlh As Long
                    stk = datread.Item("stok")
                    jlh = tabelTrans.Rows(baris).Cells(2).Value
                    koneksiodbc()
                    str = "update data_menu set stok = @stok where kd_data = @kode"
                    comm = konek.CreateCommand
                    With comm
                        .CommandText = str
                        .Connection = konek
                        .Parameters.Add("kode", odbcType:=OdbcType.Int).Value = tabelTrans.Rows(baris).Cells(0).Value
                        .Parameters.Add("stok", odbcType:=OdbcType.Int = 10).Value = stk - jlh
                        .ExecuteNonQuery()
                    End With
                    tutup()
                End If
                tutup()
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub boxJumt_TextChanged(sender As Object, e As EventArgs) Handles boxJumt.TextChanged
        If boxJumt.Text = "" Then
            jumlah = 0
            total = jumlah * harga
            boxJumt.Text = total
        Else
            jumlah = boxJumt.Text
            total = jumlah * harga
            boxJumt.Text = total
        End If
    End Sub
    Private Sub boxBayart_TextChanged(sender As Object, e As EventArgs) Handles boxBayart.TextChanged
        Dim f As Long
        If boxBayart.Text = " " Or Not IsNumeric(boxDiskon.Text) Then
            Exit Sub
        End If
        f = boxBayart.Text
        boxBayart.Text = Format(f, "##,##0")
        boxBayart.SelectionStart = Len(boxBayart.Text)

        Dim hitung As Long = 0
        For baris As Long = 0 To tabelTrans.RowCount - 1
            hitung = hitung + tabelTrans.Rows(baris).Cells(4).Value
        Next

        subtotal = Format(hitung, "##,##0")
        grandtotal = hitung - boxDiskon.Text
        boxKembalit.Text = Format(boxBayart.Text - grandtotal, "##,##0")

        total = Format(grandtotal, "##,##0")
        kembali = Format(boxBayart.Text - grandtotal, "##,##0t")

    End Sub

    Private Sub boxBayart_KeyPress(sender As Object, e As KeyPressEventArgs) Handles boxBayart.KeyPress
        Dim keyascii As Short = Asc(e.KeyChar)
        If (e.KeyChar Like "[0-9]" OrElse keyascii = Keys.Back) Then
            keyascii = 0
        Else
            e.Handled = CBool(keyascii)
        End If
        If (e.KeyChar = Chr(13)) Then
            If boxDiskon.Text = " " Then
                MessageBox.Show("Kasih Pelangganmu diskon yuk!", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf boxDiskon.Text > subtotal Then
                MessageBox.Show("Diskon terlalu banyak, nanti kamu rugi", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                diskon = boxDiskon.Text
                If boxBayart.Text = " " Then
                    MessageBox.Show("Bayar dulu dong", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf boxBayart.Text < grandtotal Then
                    MessageBox.Show("Jumlah bayar kurang!", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    bayar = boxBayart.Text
                    nofaktur()
                    simpanjual()
                    MessageBox.Show("Pemesanan berhasil", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If
            End If
        End If
    End Sub

    Private Sub boxKodet_KeyDown(sender As Object, e As KeyEventArgs) Handles boxKodet.KeyDown
        If e.KeyCode = Keys.F2 Then
            Dim hitung As Long = 0
            For baris As Long = 0 To tabelTrans.RowCount - 1
                hitung = hitung + tabelTrans.Rows(baris).Cells(4).Value

            Next
            If hitung = 0 Then
                MessageBox.Show("Lengkapi transaksi terlebih dahulu", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                boxDiskon.ReadOnly = False
                boxDiskon.Focus()
            End If
        End If
    End Sub

    Private Sub boxJumt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles boxJumt.KeyPress
        Dim keyascii As Short = Asc(e.KeyChar)
        If (e.KeyChar Like "[0-9]" OrElse keyascii = Keys.Back) Then
            keyascii = 0
        Else
            e.Handled = CBool(keyascii)
        End If
        If (e.KeyChar = Chr(13)) Then
            If boxJumt.Text = "" Then
                MessageBox.Show("Isi jumlah terlebih dahulu", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf boxJumt.Text = 0 Then
                MessageBox.Show("Jumlah tidak boleh kurang", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf boxJumt.Text > stok Then
                MessageBox.Show("Jumlah lebih besar dari stok yang ada" & vbCrLf _
                    & "Stok hanya" & stok, "Oops", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                pindah()
                boxKodet.Text = ""
                boxNamat.Text = ""
                boxJumt.Text = ""
                boxHargat.Text = ""
                boxTotalt.Text = ""
                boxKodet.Focus()
            End If
        End If
    End Sub

    Private Sub boxKodet_KeyPress(sender As Object, e As KeyPressEventArgs) Handles boxKodet.KeyPress
        If (e.KeyChar = Chr(13)) Then
            If boxKodet.Text = "" Then
                MessageBox.Show("Isi kode barang terlebih dahulu", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                koneksiodbc()
                comm = New OdbcCommand("select * from data_menu where kd_data = '" & boxKodet.Text & "'", konek)
                datread = comm.ExecuteReader
                datread.Read()
                If datread.HasRows Then
                    kode = datread.Item("kd_data")
                    boxNamat.Text = datread.Item("nama_menu")
                    stok = datread.Item("stok_menu")
                    jumlah = 1
                    harga = datread.Item("harga_menu")
                    total = jumlah * harga
                    boxJumt.Text = jumlah
                    boxHargat.Text = harga
                    boxTotalt.Text = total
                    boxTotalt.Focus()
                Else
                    MessageBox.Show("Kode Menu tidak terdaftar !", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    boxKodet.Text = ""
                End If
            End If
        End If
    End Sub

    Private Sub boxDiskon_KeyPress(sender As Object, e As KeyPressEventArgs) Handles boxDiskon.KeyPress
        Dim keyascii As Short = Asc(e.KeyChar)
        If (e.KeyChar Like "[0-9]" OrElse keyascii = Keys.Back) Then
            keyascii = 0
        Else
            e.Handled = CBool(keyascii)
        End If
        If (e.KeyChar = Chr(13)) Then
            If boxDiskon.Text = "" Then
                MessageBox.Show("Isi jumlah diskon terlebih dahulu !", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ElseIf boxDiskon.Text >= subtotal Then
                MessageBox.Show("Jumlah diskon melebihi penjulan !", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                diskon = boxDiskon.Text
                boxBayart.Text = ""
                boxBayart.ReadOnly = False
                boxBayart.Focus()
            End If
        End If
    End Sub
End Class