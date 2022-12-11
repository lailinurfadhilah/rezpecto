Imports System.Data.Odbc
Public Class beranda
    Private Sub beranda_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub beranda_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus
        If Label4.Text = "user" Then
            MasterDataToolStripMenuItem.Visible = False

        End If
    End Sub

    Private Sub KeluarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles KeluarToolStripMenuItem.Click
        Form1.boxUsername.Focus()
        Form1.boxUsername.Text = ""
        Form1.boxPassword.Text = ""
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub AlamatRestoranToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AlamatRestoranToolStripMenuItem.Click
        cabang.Show()
        Me.Hide()
    End Sub

    Private Sub DataPenggunaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataPenggunaToolStripMenuItem.Click
        pengguna.Show()
        Me.Hide()
    End Sub

    Private Sub DataMenuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataMenuToolStripMenuItem.Click
        barangmenu.Show()
        Me.Hide()
    End Sub

    Private Sub HargaKotorDapurToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HargaKotorDapurToolStripMenuItem.Click
        pembelian.Show()
        Me.Hide()
    End Sub

    Private Sub PenjualanToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PenjualanToolStripMenuItem1.Click
        riwayat.Show()
        Me.Hide()
    End Sub

    Private Sub LaporanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LaporanToolStripMenuItem.Click

    End Sub

    Private Sub HargaDapurToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HargaDapurToolStripMenuItem.Click
        riwayatdetail.Show()
        Me.Hide()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub
End Class