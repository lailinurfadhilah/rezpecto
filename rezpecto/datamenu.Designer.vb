<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class datamenu
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(datamenu))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.butMenu = New System.Windows.Forms.Button()
        Me.tabData = New System.Windows.Forms.DataGridView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.butTambah = New System.Windows.Forms.Button()
        Me.butEdit = New System.Windows.Forms.Button()
        Me.butHapus = New System.Windows.Forms.Button()
        Me.butSimpan = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.boxStok = New System.Windows.Forms.TextBox()
        Me.boxNama = New System.Windows.Forms.TextBox()
        Me.boxHarga = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.boxKode = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.tabData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel2.Location = New System.Drawing.Point(0, 114)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1043, 10)
        Me.Panel2.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Book Antiqua", 7.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.Label2.Location = New System.Drawing.Point(212, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(142, 17)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Eat First, Happily After"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Book Antiqua", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point)
        Me.Label1.Location = New System.Drawing.Point(155, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(222, 36)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Rezpecto Resto"
        '
        'butMenu
        '
        Me.butMenu.Font = New System.Drawing.Font("Century Gothic", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.butMenu.Image = CType(resources.GetObject("butMenu.Image"), System.Drawing.Image)
        Me.butMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.butMenu.Location = New System.Drawing.Point(781, 39)
        Me.butMenu.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.butMenu.Name = "butMenu"
        Me.butMenu.Size = New System.Drawing.Size(106, 33)
        Me.butMenu.TabIndex = 6
        Me.butMenu.Text = "      Beranda"
        Me.butMenu.UseVisualStyleBackColor = True
        '
        'tabData
        '
        Me.tabData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.tabData.Location = New System.Drawing.Point(557, 177)
        Me.tabData.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tabData.Name = "tabData"
        Me.tabData.RowHeadersWidth = 51
        Me.tabData.RowTemplate.Height = 29
        Me.tabData.Size = New System.Drawing.Size(380, 397)
        Me.tabData.TabIndex = 23
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1036, 10)
        Me.Panel3.TabIndex = 11
        '
        'butTambah
        '
        Me.butTambah.Font = New System.Drawing.Font("Century Gothic", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.butTambah.Image = CType(resources.GetObject("butTambah.Image"), System.Drawing.Image)
        Me.butTambah.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.butTambah.Location = New System.Drawing.Point(116, 460)
        Me.butTambah.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.butTambah.Name = "butTambah"
        Me.butTambah.Size = New System.Drawing.Size(94, 38)
        Me.butTambah.TabIndex = 24
        Me.butTambah.Text = "     Tambah"
        Me.butTambah.UseVisualStyleBackColor = True
        '
        'butEdit
        '
        Me.butEdit.Font = New System.Drawing.Font("Century Gothic", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.butEdit.Image = CType(resources.GetObject("butEdit.Image"), System.Drawing.Image)
        Me.butEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.butEdit.Location = New System.Drawing.Point(116, 536)
        Me.butEdit.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.butEdit.Name = "butEdit"
        Me.butEdit.Size = New System.Drawing.Size(94, 38)
        Me.butEdit.TabIndex = 25
        Me.butEdit.Text = "Edit"
        Me.butEdit.UseVisualStyleBackColor = True
        '
        'butHapus
        '
        Me.butHapus.Font = New System.Drawing.Font("Century Gothic", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.butHapus.Image = CType(resources.GetObject("butHapus.Image"), System.Drawing.Image)
        Me.butHapus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.butHapus.Location = New System.Drawing.Point(332, 536)
        Me.butHapus.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.butHapus.Name = "butHapus"
        Me.butHapus.Size = New System.Drawing.Size(94, 38)
        Me.butHapus.TabIndex = 26
        Me.butHapus.Text = "Hapus"
        Me.butHapus.UseVisualStyleBackColor = True
        '
        'butSimpan
        '
        Me.butSimpan.Font = New System.Drawing.Font("Century Gothic", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.butSimpan.Image = CType(resources.GetObject("butSimpan.Image"), System.Drawing.Image)
        Me.butSimpan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.butSimpan.Location = New System.Drawing.Point(332, 460)
        Me.butSimpan.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.butSimpan.Name = "butSimpan"
        Me.butSimpan.Size = New System.Drawing.Size(94, 38)
        Me.butSimpan.TabIndex = 42
        Me.butSimpan.Text = "   Simpan"
        Me.butSimpan.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Book Antiqua", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label6.Location = New System.Drawing.Point(71, 255)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 19)
        Me.Label6.TabIndex = 41
        Me.Label6.Text = "Nama Menu"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Book Antiqua", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label5.Location = New System.Drawing.Point(71, 317)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 19)
        Me.Label5.TabIndex = 40
        Me.Label5.Text = "Harga Menu"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Book Antiqua", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label4.Location = New System.Drawing.Point(71, 378)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 19)
        Me.Label4.TabIndex = 39
        Me.Label4.Text = "Stok Menu"
        '
        'boxStok
        '
        Me.boxStok.Font = New System.Drawing.Font("Book Antiqua", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.boxStok.Location = New System.Drawing.Point(212, 376)
        Me.boxStok.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.boxStok.Name = "boxStok"
        Me.boxStok.Size = New System.Drawing.Size(274, 26)
        Me.boxStok.TabIndex = 38
        '
        'boxNama
        '
        Me.boxNama.Font = New System.Drawing.Font("Book Antiqua", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.boxNama.Location = New System.Drawing.Point(212, 250)
        Me.boxNama.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.boxNama.Name = "boxNama"
        Me.boxNama.Size = New System.Drawing.Size(274, 26)
        Me.boxNama.TabIndex = 37
        '
        'boxHarga
        '
        Me.boxHarga.Font = New System.Drawing.Font("Book Antiqua", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.boxHarga.Location = New System.Drawing.Point(212, 317)
        Me.boxHarga.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.boxHarga.Name = "boxHarga"
        Me.boxHarga.Size = New System.Drawing.Size(274, 26)
        Me.boxHarga.TabIndex = 36
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Book Antiqua", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label3.Location = New System.Drawing.Point(71, 192)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 19)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "Kode Menu"
        '
        'boxKode
        '
        Me.boxKode.Font = New System.Drawing.Font("Book Antiqua", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.boxKode.Location = New System.Drawing.Point(212, 187)
        Me.boxKode.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.boxKode.Name = "boxKode"
        Me.boxKode.Size = New System.Drawing.Size(112, 26)
        Me.boxKode.TabIndex = 34
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(71, 15)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(75, 76)
        Me.PictureBox1.TabIndex = 43
        Me.PictureBox1.TabStop = False
        '
        'datamenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(1035, 664)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.butSimpan)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.boxStok)
        Me.Controls.Add(Me.boxNama)
        Me.Controls.Add(Me.boxHarga)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.boxKode)
        Me.Controls.Add(Me.butHapus)
        Me.Controls.Add(Me.butEdit)
        Me.Controls.Add(Me.butTambah)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.tabData)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.butMenu)
        Me.Font = New System.Drawing.Font("Century Gothic", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "datamenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "datamenu"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.tabData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents butMenu As Button
    Friend WithEvents tabData As DataGridView
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents butTambah As Button
    Friend WithEvents butEdit As Button
    Friend WithEvents butHapus As Button
    Friend WithEvents butSimpan As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents boxStok As TextBox
    Friend WithEvents boxNama As TextBox
    Friend WithEvents boxHarga As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents boxKode As TextBox
    Friend WithEvents PictureBox1 As PictureBox
End Class
