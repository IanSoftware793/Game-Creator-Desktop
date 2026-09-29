<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.menuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportAssetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RunToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CompileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PlaytestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsOpenEditor = New System.Windows.Forms.ToolStripButton()
        Me.tsOpenCode = New System.Windows.Forms.ToolStripButton()
        Me.tsImportAsset = New System.Windows.Forms.ToolStripButton()
        Me.tsDeleteObject = New System.Windows.Forms.ToolStripButton()
        Me.tsCompile = New System.Windows.Forms.ToolStripButton()
        Me.tsPlaytest = New System.Windows.Forms.ToolStripButton()
        Me.lbAssets = New System.Windows.Forms.ListBox()
        Me.openImageDialog = New System.Windows.Forms.OpenFileDialog()
        Me.openSceneDialog = New System.Windows.Forms.OpenFileDialog()
        Me.saveSceneDialog = New System.Windows.Forms.SaveFileDialog()
        Me.folderExportDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.menuStrip1.SuspendLayout()
        Me.toolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'menuStrip1
        '
        Me.menuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.EditToolStripMenuItem, Me.RunToolStripMenuItem})
        Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip1.Name = "menuStrip1"
        Me.menuStrip1.Size = New System.Drawing.Size(1230, 28)
        Me.menuStrip1.TabIndex = 0
        Me.menuStrip1.Text = "menuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.OpenToolStripMenuItem, Me.SaveToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(73, 24)
        Me.FileToolStripMenuItem.Text = "Archivo"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(154, 26)
        Me.NewToolStripMenuItem.Text = "Nuevo"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(154, 26)
        Me.OpenToolStripMenuItem.Text = "Abrir..."
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(154, 26)
        Me.SaveToolStripMenuItem.Text = "Guardar..."
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportAssetToolStripMenuItem})
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(62, 24)
        Me.EditToolStripMenuItem.Text = "Editar"
        '
        'ImportAssetToolStripMenuItem
        '
        Me.ImportAssetToolStripMenuItem.Name = "ImportAssetToolStripMenuItem"
        Me.ImportAssetToolStripMenuItem.Size = New System.Drawing.Size(212, 26)
        Me.ImportAssetToolStripMenuItem.Text = "Importar asset(s)..."
        '
        'RunToolStripMenuItem
        '
        Me.RunToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CompileToolStripMenuItem, Me.PlaytestToolStripMenuItem})
        Me.RunToolStripMenuItem.Name = "RunToolStripMenuItem"
        Me.RunToolStripMenuItem.Size = New System.Drawing.Size(76, 24)
        Me.RunToolStripMenuItem.Text = "Ejecutar"
        '
        'CompileToolStripMenuItem
        '
        Me.CompileToolStripMenuItem.Name = "CompileToolStripMenuItem"
        Me.CompileToolStripMenuItem.Size = New System.Drawing.Size(162, 26)
        Me.CompileToolStripMenuItem.Text = "Compilar..."
        '
        'PlaytestToolStripMenuItem
        '
        Me.PlaytestToolStripMenuItem.Name = "PlaytestToolStripMenuItem"
        Me.PlaytestToolStripMenuItem.Size = New System.Drawing.Size(162, 26)
        Me.PlaytestToolStripMenuItem.Text = "Playtest"
        '
        'toolStrip1
        '
        Me.toolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsOpenEditor, Me.tsOpenCode, Me.tsImportAsset, Me.tsDeleteObject, Me.tsCompile, Me.tsPlaytest})
        Me.toolStrip1.Location = New System.Drawing.Point(0, 28)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(1230, 27)
        Me.toolStrip1.TabIndex = 1
        Me.toolStrip1.Text = "toolStrip1"
        '
        'tsOpenEditor
        '
        Me.tsOpenEditor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsOpenEditor.Name = "tsOpenEditor"
        Me.tsOpenEditor.Size = New System.Drawing.Size(53, 24)
        Me.tsOpenEditor.Text = "Editor"
        '
        'tsOpenCode
        '
        Me.tsOpenCode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsOpenCode.Name = "tsOpenCode"
        Me.tsOpenCode.Size = New System.Drawing.Size(48, 24)
        Me.tsOpenCode.Text = "Code"
        '
        'tsImportAsset
        '
        Me.tsImportAsset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsImportAsset.Name = "tsImportAsset"
        Me.tsImportAsset.Size = New System.Drawing.Size(58, 24)
        Me.tsImportAsset.Text = "Import"
        '
        'tsDeleteObject
        '
        Me.tsDeleteObject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsDeleteObject.Name = "tsDeleteObject"
        Me.tsDeleteObject.Size = New System.Drawing.Size(57, 24)
        Me.tsDeleteObject.Text = "Delete"
        '
        'tsCompile
        '
        Me.tsCompile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsCompile.Name = "tsCompile"
        Me.tsCompile.Size = New System.Drawing.Size(69, 24)
        Me.tsCompile.Text = "Compile"
        '
        'tsPlaytest
        '
        Me.tsPlaytest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsPlaytest.Name = "tsPlaytest"
        Me.tsPlaytest.Size = New System.Drawing.Size(64, 24)
        Me.tsPlaytest.Text = "Playtest"
        '
        'lbAssets
        '
        Me.lbAssets.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbAssets.ItemHeight = 16
        Me.lbAssets.Location = New System.Drawing.Point(1030, 24)
        Me.lbAssets.Name = "lbAssets"
        Me.lbAssets.Size = New System.Drawing.Size(180, 84)
        Me.lbAssets.TabIndex = 2
        Me.lbAssets.Visible = False
        '
        'openImageDialog
        '
        Me.openImageDialog.Filter = "Imágenes|*.png;*.jpg;*.jpeg;*.bmp|Todos los archivos|*.*"
        Me.openImageDialog.Multiselect = True
        '
        'openSceneDialog
        '
        Me.openSceneDialog.Filter = "Scene files|*.scene|XML files|*.xml|All files|*.*"
        '
        'saveSceneDialog
        '
        Me.saveSceneDialog.DefaultExt = "scene"
        Me.saveSceneDialog.Filter = "Scene files|*.scene|XML files|*.xml|All files|*.*"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1230, 823)
        Me.Controls.Add(Me.lbAssets)
        Me.Controls.Add(Me.toolStrip1)
        Me.Controls.Add(Me.menuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.menuStrip1
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Game Creator"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.menuStrip1.ResumeLayout(False)
        Me.menuStrip1.PerformLayout()
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents menuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImportAssetToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RunToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CompileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PlaytestToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsOpenEditor As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsOpenCode As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsImportAsset As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsDeleteObject As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsCompile As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsPlaytest As System.Windows.Forms.ToolStripButton
    Friend WithEvents lbAssets As System.Windows.Forms.ListBox
    Friend WithEvents openImageDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents openSceneDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents saveSceneDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents folderExportDialog As System.Windows.Forms.FolderBrowserDialog

End Class
