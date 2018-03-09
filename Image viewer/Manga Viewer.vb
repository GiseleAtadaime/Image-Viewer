Public Class MangáViewer

    Dim Filesindex, Numero As IEnumerator
    Dim Nome As String = "0"
    Dim Posição As Integer = 0
    Dim LBCont As Integer = 0
    Dim pastadel As String = "0"
    Dim pastaini As String = "0"
    Dim controle As Boolean = True

    Private Sub BtnOpen_Click(sender As Object, e As EventArgs) Handles BtnOpen.Click

        BtnSalvar.Enabled = True
        BtnSaveall.Enabled = True
        OpenFileDialog1.Multiselect = True

        Panel1.AutoScroll = True
        If controle = False Then
            OpenFileDialog1.InitialDirectory = pastaini
        End If

        If  OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Filesindex = OpenFileDialog1.FileNames.GetEnumerator()
            pastadel = OpenFileDialog1.FileName.ToString
            pastadel = pastadel.Remove(pastadel.Length - 2)
            MessageBox.Show("Pasta para ser excluída" + pastadel)
            Numero = Filesindex
            ListBox1.Items.Clear()
            LBCont = LBCont + 1
            btnPrimeiro.Enabled = True
            btnUltimo.Enabled = True

            While Filesindex.MoveNext
                ListBox1.Items.Add(Filesindex.Current)

            End While
            ListBox1.SelectedIndex = 0

            PictureBox1.Load(ListBox1.SelectedItem.ToString)
            PictureBox1.SizeMode = PictureBoxSizeMode.AutoSize
            PictureBox2.Load(ListBox1.SelectedItem.ToString)
            PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
            BtnNext.Focus()
            controle = False
        End If
    End Sub

    Private Sub BtnSalvar_Click(sender As Object, e As EventArgs) Handles BtnSalvar.Click

        Dim Local As String
        Dim IMG = New Bitmap(PictureBox1.Image)
        Dim Fnome As String = SaveFileDialog1.FileName
        Nome = CStr(ListBox1.SelectedItem)




        SaveFileDialog1.Title = "Salvar imagem como:"


        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            Local = DialogResult.ToString
            MsgBox("Local = " & Local)

            If SaveFileDialog1.FileName <> "" Then
                Local = SaveFileDialog1.FileName
                IMG.Save(Local, System.Drawing.Imaging.ImageFormat.Jpeg)

            End If
        End If



    End Sub

    Private Sub BtnPrevious_Click(sender As Object, e As EventArgs) Handles BtnPrevious.Click
        Dim Arquivo As String
        Dim Valor As Integer


        Valor = ListBox1.SelectedIndex
        Valor = Valor - 1
        If Valor < 0 Then
            Exit Sub
        Else
            PictureBox3.Image = PictureBox1.Image
            PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage
            ListBox1.SelectedIndex = Valor

            Arquivo = ListBox1.SelectedItem.ToString

            PictureBox1.Load(Arquivo)
            PictureBox2.Image = PictureBox1.Image
            PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage


            If CheckBox1.Checked = True Then
                Dim Local As String
                Dim IMG = New Bitmap(PictureBox1.Image)

                Nome = CStr(ListBox1.SelectedItem)


                SaveFileDialog1.Title = "Salvar imagem como:"

                If SaveFileDialog1.ShowDialog() = DialogResult.OK Then

                    If SaveFileDialog1.FileName <> "" Then
                        Local = SaveFileDialog1.FileName
                        IMG.Save(Local, System.Drawing.Imaging.ImageFormat.Jpeg)

                    End If
                End If
            End If

        End If
    End Sub

    Private Sub BtnNext_Click(sender As Object, e As EventArgs) Handles BtnNext.Click
        Dim Arquivo As String
        Dim Valor As Integer
        Dim Limite As Integer

        Limite = ListBox1.Items.Count
        Valor = ListBox1.SelectedIndex
        Valor = Valor + 1

        If Valor = Limite Then
            Exit Sub
        Else
            PictureBox3.Image = PictureBox1.Image
            PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage
            ListBox1.SelectedIndex = Valor

            Arquivo = ListBox1.SelectedItem.ToString

            PictureBox1.Load(Arquivo)
            PictureBox2.Image = PictureBox1.Image
            PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage

            If CheckBox1.Checked = True Then
                Dim Local As String
                Dim IMG = New Bitmap(PictureBox1.Image)

                Nome = CStr(ListBox1.SelectedItem)


                SaveFileDialog1.Title = "Salvar imagem como:"


                If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
                    If SaveFileDialog1.FileName <> "" Then
                        Local = SaveFileDialog1.FileName
                        IMG.Save(Local, System.Drawing.Imaging.ImageFormat.Jpeg)

                    End If
                End If
            End If
        End If


    End Sub

    Private m_PanStartPoint As New Point

    Private Sub BtnPasta_Click(sender As Object, e As EventArgs) Handles BtnPasta.Click
        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then

            OpenFileDialog1.InitialDirectory = FolderBrowserDialog1.SelectedPath

        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

        If BtnSaveall.Enabled = False Then

            PictureBox1.Load(CStr(ListBox1.SelectedItem))

        End If


    End Sub

    Private Sub BtnMusica_Click(sender As Object, e As EventArgs) Handles BtnMusica.Click

        OpenFileDialog2.Multiselect = True
        OpenFileDialog2.InitialDirectory = "C : \Users\Tamie\Music"

        If OpenFileDialog2.ShowDialog = DialogResult.OK Then
            Dim MusicasC() As String = OpenFileDialog2.FileNames

            My.Computer.Audio.Play(MusicasC(0), AudioPlayMode.Background)


        End If
    End Sub

    Private Sub BtnStop_Click(sender As Object, e As EventArgs) Handles BtnStop.Click

        My.Computer.Audio.Stop()

    End Sub

    Private Sub BtnProximo_Click(sender As Object, e As EventArgs) Handles BtnProximo.Click

        Dim musicas() As String = OpenFileDialog2.FileNames


        My.Computer.Audio.Stop()
        Posição += 1
        My.Computer.Audio.Play(musicas(Posição), AudioPlayMode.Background)

    End Sub

    Private Sub BtnSaveall_Click(sender As Object, e As EventArgs) Handles BtnSaveall.Click

        'Dim Nome As String
        Dim Quanti As Integer
        Dim Imagem As Bitmap
        Dim Local As String
        Dim Formato As String
        Dim Pasta As String = "a"
        Dim i As Integer = 0
        'Dim Time As Int64
        ' Dim Local2 As Boolean = False
        Quanti = ListBox1.Items.Count
        'MsgBox("Quanti = " & Quanti)

        'If rbtnPasta.Checked = True Then

        ' Local2 = True
        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then

            Pasta = FolderBrowserDialog1.SelectedPath
            pastaini = Pasta
            Dim barra As Integer
            barra = pastaini.LastIndexOf("\")
            pastaini = pastaini.Substring(0, barra)
            MsgBox("Substring" + pastaini)

            '  MsgBox("Pasta " & Pasta)


            'OpenFileDialog1.InitialDirectory = FolderBrowserDialog1.SelectedPath

            'End If
        Else
            Exit Sub
        End If

        Formato = cbxFormat.SelectedItem.ToString

        For i = 0 To Quanti - 1
            'Time = 0
            ListBox1.SelectedIndex = i

            'While Time < 500000000
            '    Time = Time + 1

            'End While

            'PictureBox2.Image = PictureBox1.Image
            PictureBox3.Load(ListBox1.SelectedItem.ToString)
            ' MsgBox("Rodada " & i)

            'Time = 0
            'While Time < 100000000
            '    Time = Time + 1

            'End While

            'PictureBox1.SizeMode = PictureBoxSizeMode.AutoSize

            Imagem = CType(PictureBox3.Image, Bitmap)
            ' If Local2 = True Then
            Local = String.Concat(Pasta, "\" & i)
            'Else
            ' Local = ListBox1.SelectedItem.ToString
            ' End If
            Local = String.Concat(Local, "." & Formato)

            Select Case Formato

                Case "Jpeg"
                    Imagem.Save(Local, Imaging.ImageFormat.Jpeg)
                Case "Bitmap"
                    Imagem.Save(Local, Imaging.ImageFormat.Bmp)
                Case "Png"
                    Imagem.Save(Local, Imaging.ImageFormat.Png)


            End Select

        Next

        Dim sSalvo As String
        sSalvo = ListBox1.SelectedItem.ToString
        Dim tam As Integer
        tam = sSalvo.Length


        If i > 10 Then
            sSalvo = sSalvo.Remove(tam - 2)
            Local = String.Copy(sSalvo)

            ' sSalvo.CopyTo(0, CType(Local, Char()), 0, tam - 2)
        Else
            sSalvo = sSalvo.Remove(tam - 1)
            Local = String.Copy(sSalvo)

            ' sSalvo.CopyTo(0, CType(Local, Char()), 0, tam - 1)
        End If

        ' MsgBox("local " & Local)
        ' Local = String.Concat(ListBox1.SelectedItem.ToString)
        Imagem = My.Resources.salvo



        Local = String.Concat(Local, "Salvo.Jpeg")
        Imagem.Save(Local, Imaging.ImageFormat.Jpeg)
        MsgBox(Quanti & " arquivos salvos com sucesso", MsgBoxStyle.Information)
        BtnSaveall.Enabled = False
        BtnSalvar.Enabled = False
        btnDelete.Enabled = True

        ListBox1.Items.Clear()
        PictureBox1.Load(String.Concat(Pasta, "\0.", Formato))
        PictureBox2.Load(String.Concat(Pasta, "\0.", Formato))
        PictureBox3.Load(String.Concat(Pasta, "\0.", Formato))


        If MsgBox("Deseja excluir a pasta de origem?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            System.IO.Directory.Delete(pastadel, True)
            MsgBox("A pasta foi excluída com sucesso!", MsgBoxStyle.Information)
        Else
            MsgBox("A pasta não foi deletada!", MsgBoxStyle.Information)
        End If
        'Local2 = False
        'Dim Local As String
        'Dim IMG = New Bitmap(PictureBox1.Image)
        'Dim Fnome As String = SaveFileDialog1.FileName
        'Nome = CStr(ListBox1.SelectedItem)




        'SaveFileDialog1.Title = "Salvar imagem como:"


        'If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
        '    Local = DialogResult.ToString
        '    MsgBox("Local = " & Local)

        '    If SaveFileDialog1.FileName <> "" Then
        '        Local = SaveFileDialog1.FileName
        '        IMG.Save(Local, System.Drawing.Imaging.ImageFormat.Jpeg)

        '    End If
        'End If


    End Sub

    Private Sub btnPrimeiro_Click(sender As Object, e As EventArgs) Handles btnPrimeiro.Click
        If LBCont > 0 Then
            ListBox1.SelectedIndex = 0
            PictureBox1.Load(ListBox1.SelectedItem.ToString)
            BtnNext.Focus()
        End If

    End Sub

    Private Sub btnUltimo_Click(sender As Object, e As EventArgs) Handles btnUltimo.Click

        Dim Total As Integer

        If LBCont > 0 Then
            Total = ListBox1.Items.Count
            ListBox1.SelectedIndex = Total - 1
            PictureBox1.Load(ListBox1.SelectedItem.ToString)
            BtnPrevious.Focus()
        End If
    End Sub

    Private Sub Panel3_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel3.MouseMove
        ToolTip1.Show("Indisponível", Panel3)
        'ToolTip1.Show("Indisponível", BtnMusica)
        'ToolTip1.Show("Indisponível", ToolStrip1)
        'ToolTip1.Show("Indisponível", ProgressBar1)
    End Sub

    Private Sub BtnSalvar_MouseHover(sender As Object, e As EventArgs) Handles BtnSalvar.MouseHover
        ToolTip1.Show("Salvar apenas um arquivo", BtnSalvar)
    End Sub

    Private Sub BtnSaveall_MouseHover(sender As Object, e As EventArgs) Handles BtnSaveall.MouseHover
        ToolTip1.Show("Salva todos os arquivos no formato selecionado", BtnSaveall)
    End Sub

    Private Sub AjudaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AjudaToolStripMenuItem.Click
        Ajuda.Show()
    End Sub

    Private Sub MangáViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        btnDelete.Enabled = False
    End Sub

    Private Sub Picturebox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown, PictureBox1.MouseMove
        m_PanStartPoint = New Point(e.X, e.Y)
    End Sub


End Class
