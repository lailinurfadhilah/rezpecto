Imports System.Data.Odbc
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar

Public Class Form1
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub butLogin_Click(sender As Object, e As EventArgs) Handles butLogin.Click
        boxUsername.Focus()
        If boxUsername.Text = "" Or boxPassword.Text = "" Then
            MsgBox("Ada data yang masih kosong", vbCritical, "Kesalahan")
        Else
            koneksiodbc()
            comm = New OdbcCommand("SELECT * FROM pengguna where namau = '" & boxUsername.Text & "'", konek)
            datread = comm.ExecuteReader()
            datread.Read()
            boxPassword.Focus()
            If datread.HasRows Then
                If boxPassword.Text = datread.Item("ktsandi") Then
                    Me.Hide()
                    beranda.Show()
                    beranda.Label3.Text = "Selamat Bekerja " & datread.Item("namap")
                    beranda.Label4.Text = "Sebagai  " & datread.Item("level") & " di Rezpecto Resto"
                    beranda.Label5.Text = "ID User: " & datread.Item("id")
                    beranda.Label1.Text = "ID Cabang : " & datread.Item("cabang_id")
                    pembelian.Label13.Text = datread.Item("id")
                    pembelian.Label14.Text = datread.Item("cabang_id")
                    If datread.Item("level") = "kasir" Then
                        beranda.MasterDataToolStripMenuItem.Visible = False
                    End If
                Else
                    MsgBox("Password salah!", vbCritical, "Kesalahan")
                    boxPassword.Focus()
                End If
            Else
                MsgBox("Username salah!", vbCritical, "Kesalahan")
                boxUsername.Focus()
            End If
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        boxUsername.Focus()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub
End Class
