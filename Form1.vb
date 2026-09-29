Imports System.Xml.Serialization
Imports System.IO

Partial Public Class Form1

    ' Modelo compartido
    Public assets As New Dictionary(Of String, Image)()
    Public assetPaths As New Dictionary(Of String, String)()
    Public sceneObjects As New List(Of SceneObject)()
    Public SelectedObject As SceneObject = Nothing

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.IsMdiContainer = True
        AddHandler tsOpenEditor.Click, AddressOf tsOpenEditor_Click
        AddHandler tsOpenCode.Click, AddressOf tsOpenCode_Click
        AddHandler tsImportAsset.Click, AddressOf ImportAssetToolStripMenuItem_Click
        AddHandler tsDeleteObject.Click, AddressOf tsDeleteObject_Click
        AddHandler tsCompile.Click, AddressOf CompileToolStripMenuItem_Click
        AddHandler tsPlaytest.Click, AddressOf PlaytestToolStripMenuItem_Click
    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        sceneObjects.Clear()
        SelectedObject = Nothing
        NotifyEditorsRefresh()
    End Sub

    Private Sub ImportAssetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportAssetToolStripMenuItem.Click
        If openImageDialog.ShowDialog() = DialogResult.OK Then
            For Each file In openImageDialog.FileNames
                Try
                    Dim img = Image.FromFile(file)
                    Dim key = Path.GetFileName(file)
                    Dim baseKey = key
                    Dim i = 1
                    While assets.ContainsKey(key)
                        key = Path.GetFileNameWithoutExtension(baseKey) & "(" & i.ToString() & ")" & Path.GetExtension(baseKey)
                        i += 1
                    End While
                    assets.Add(key, img)
                    assetPaths.Add(key, file)
                    lbAssets.Items.Add(key)
                    NotifyEditorsRefresh()
                Catch ex As Exception
                    MessageBox.Show("Error importando asset: " & ex.Message)
                End Try
            Next
        End If
    End Sub

    Private Sub tsOpenEditor_Click(sender As Object, e As EventArgs)
        For Each f In Me.MdiChildren
            If TypeOf f Is EditorForm Then
                f.Activate()
                Return
            End If
        Next
        Dim ed = New EditorForm()
        ed.MdiParent = Me
        ed.Show()
    End Sub

    Private Sub tsOpenCode_Click(sender As Object, e As EventArgs)
        For Each f In Me.MdiChildren
            If TypeOf f Is CodeForm Then
                f.Activate()
                Return
            End If
        Next
        Dim cf = New CodeForm()
        cf.MdiParent = Me
        cf.Show()
        cf.SetCode(GenerateSampleCode())
    End Sub

    Private Sub tsDeleteObject_Click(sender As Object, e As EventArgs)
        If SelectedObject Is Nothing Then
            MessageBox.Show("No hay objeto seleccionado.")
            Return
        End If
        sceneObjects.Remove(SelectedObject)
        SelectedObject = Nothing
        NotifyEditorsRefresh()
    End Sub

    Private Sub CompileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompileToolStripMenuItem.Click
        If folderExportDialog.ShowDialog() <> DialogResult.OK Then Return
        Dim dest = Path.Combine(folderExportDialog.SelectedPath, "GameCreatorExport")
        Dim tmp = Path.Combine(Path.GetTempPath(), "GameCreatorExport_" & Guid.NewGuid().ToString())
        Directory.CreateDirectory(tmp)
        Try
            ' guardar escena
            Dim sceneFile = Path.Combine(tmp, "scene.scene")
            Dim serializer As New XmlSerializer(GetType(List(Of SceneObject)))
            Using fs As New FileStream(sceneFile, FileMode.Create)
                serializer.Serialize(fs, sceneObjects)
            End Using

            ' copiar assets
            Dim assetsDir = Path.Combine(tmp, "assets")
            Directory.CreateDirectory(assetsDir)
            For Each kvp In assets
                Dim key = kvp.Key
                Dim img = kvp.Value
                Dim outPath = Path.Combine(assetsDir, key)
                If assetPaths.ContainsKey(key) AndAlso File.Exists(assetPaths(key)) Then
                    File.Copy(assetPaths(key), outPath, True)
                Else
                    img.Save(outPath)
                End If
            Next

            ' generar código de ejemplo
            Dim code = GenerateSampleCode()
            File.WriteAllText(Path.Combine(tmp, "playcode.vb"), code)

            ' exportar carpeta
            If Directory.Exists(dest) Then Directory.Delete(dest, True)
            Directory.CreateDirectory(dest)
            For Each filePath In Directory.GetFiles(tmp, "*", SearchOption.AllDirectories)
                Dim relative = filePath.Substring(tmp.Length).TrimStart(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)
                Dim outp = Path.Combine(dest, relative)
                Dim outDir = Path.GetDirectoryName(outp)
                If Not Directory.Exists(outDir) Then Directory.CreateDirectory(outDir)
                File.Copy(filePath, outp, True)
            Next
            MessageBox.Show("Exportado en: " & dest)
        Catch ex As Exception
            MessageBox.Show("Error exportando: " & ex.Message)
        Finally
            Try
                Directory.Delete(tmp, True)
            Catch
            End Try
        End Try
    End Sub

    Private Function GenerateSampleCode() As String
        Dim sb As New Text.StringBuilder()
        sb.AppendLine("' Código de ejemplo generado por Game Creator")
        sb.AppendLine("Imports System.Windows.Forms")
        sb.AppendLine("Imports System.Drawing")
        sb.AppendLine()
        sb.AppendLine("Public Module PlayGenerated")
        sb.AppendLine("    Public Sub Run(frm As Form)")
        sb.AppendLine("        Dim base = System.IO.Path.Combine(Application.StartupPath, ""assets"")")
        For i = 0 To sceneObjects.Count - 1
            Dim so = sceneObjects(i)
            sb.AppendLine($"        Dim pb_{i} = New PictureBox() With {{ .Image = Image.FromFile(System.IO.Path.Combine(base, ""{so.AssetKey}\"")), .SizeMode = PictureBoxSizeMode.StretchImage, .Left = {so.X}, .Top = {so.Y}, .Width = {so.Width}, .Height = {so.Height} }}")
            sb.AppendLine($"        frm.Controls.Add(pb_{i})")
        Next
        sb.AppendLine("    End Sub")
        sb.AppendLine("End Module")
        Return sb.ToString()
    End Function

    Private Sub PlaytestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlaytestToolStripMenuItem.Click
        Dim sizeToUse As Size = New Size(800, 600)
        For Each f In Me.MdiChildren
            If TypeOf f Is EditorForm Then
                sizeToUse = f.ClientSize
                Exit For
            End If
        Next
        Dim pf = New PlayForm(sceneObjects, assets, sizeToUse)
        pf.ShowDialog()
    End Sub

    Public Sub NotifyEditorsRefresh()
        For Each f In Me.MdiChildren
            If TypeOf f Is EditorForm Then
                Dim ed = TryCast(f, EditorForm)
                ed.RefreshAssets()
                ed.RefreshFromModel()
            ElseIf TypeOf f Is CodeForm Then
                Dim cf = TryCast(f, CodeForm)
                cf.SetCode(GenerateSampleCode())
            End If
        Next
    End Sub

    <Serializable>
    Public Class SceneObject
        Public AssetKey As String
        Public X As Integer
        Public Y As Integer
        Public Width As Integer
        Public Height As Integer

        <XmlIgnore>
        Private updateAction As Action(Of SceneObject)

        Public Sub New()
        End Sub

        Public Sub SetUpdateAction(a As Action(Of SceneObject))
            updateAction = a
        End Sub

        Public Property propX As Integer
            Get
                Return X
            End Get
            Set(value As Integer)
                X = value
                If updateAction IsNot Nothing Then updateAction(Me)
            End Set
        End Property

        Public Property propY As Integer
            Get
                Return Y
            End Get
            Set(value As Integer)
                Y = value
                If updateAction IsNot Nothing Then updateAction(Me)
            End Set
        End Property

        Public Property propWidth As Integer
            Get
                Return Width
            End Get
            Set(value As Integer)
                Width = value
                If updateAction IsNot Nothing Then updateAction(Me)
            End Set
        End Property

        Public Property propHeight As Integer
            Get
                Return Height
            End Get
            Set(value As Integer)
                Height = value
                If updateAction IsNot Nothing Then updateAction(Me)
            End Set
        End Property

        Public Property propAssetKey As String
            Get
                Return AssetKey
            End Get
            Set(value As String)
                AssetKey = value
            End Set
        End Property
    End Class
End Class
