Imports System
Imports System.Windows.Forms
Imports System.Drawing

Public Class EditorForm
    Inherits Form

    Private lbAssets As ListBox
    Private splitMain As SplitContainer
    Private rightSplit As SplitContainer
    Private panelCanvas As Panel
    Private propertyGrid As PropertyGrid

    Private currentAssetKey As String = Nothing

    Public Sub New()
        Me.Text = "Editor"
        Me.Size = New Size(800, 600)
        Me.StartPosition = FormStartPosition.CenterParent

        splitMain = New SplitContainer()
        splitMain.Dock = DockStyle.Fill
        splitMain.SplitterDistance = 200

        lbAssets = New ListBox()
        lbAssets.Dock = DockStyle.Fill
        AddHandler lbAssets.SelectedIndexChanged, AddressOf lbAssets_SelectedIndexChanged

        rightSplit = New SplitContainer()
        rightSplit.Dock = DockStyle.Fill
        rightSplit.Orientation = Orientation.Horizontal
        rightSplit.SplitterDistance = CInt(Me.ClientSize.Height * 0.7)

        panelCanvas = New Panel()
        panelCanvas.Dock = DockStyle.Fill
        panelCanvas.BackColor = Color.DarkGray
        AddHandler panelCanvas.MouseDown, AddressOf panelCanvas_MouseDown

        propertyGrid = New PropertyGrid()
        propertyGrid.Dock = DockStyle.Fill

        rightSplit.Panel1.Controls.Add(panelCanvas)
        rightSplit.Panel2.Controls.Add(propertyGrid)

        splitMain.Panel1.Controls.Add(lbAssets)
        splitMain.Panel2.Controls.Add(rightSplit)

        Me.Controls.Add(splitMain)
    End Sub

    Private Function ParentMain() As Form1
        Return TryCast(Me.MdiParent, Form1)
    End Function

    Protected Overrides Sub OnLoad(e As EventArgs)
        MyBase.OnLoad(e)
        RefreshAssets()
        RefreshFromModel()
    End Sub

    Public Sub RefreshAssets()
        Dim p = ParentMain()
        If p Is Nothing Then Return
        lbAssets.Items.Clear()
        For Each k In p.assets.Keys
            lbAssets.Items.Add(k)
        Next
    End Sub

    Public Sub RefreshFromModel()
        Dim p = ParentMain()
        If p Is Nothing Then Return
        panelCanvas.Controls.Clear()
        For Each so In p.sceneObjects
            If Not p.assets.ContainsKey(so.AssetKey) Then Continue For
            Dim img = p.assets(so.AssetKey)
            Dim pb = New PictureBox()
            pb.Image = img
            pb.SizeMode = PictureBoxSizeMode.StretchImage
            pb.Left = so.X
            pb.Top = so.Y
            pb.Width = so.Width
            pb.Height = so.Height
            pb.Cursor = Cursors.Hand
            pb.Tag = so
            panelCanvas.Controls.Add(pb)

            so.SetUpdateAction(Sub(s)
                                   pb.Left = s.X
                                   pb.Top = s.Y
                                   pb.Width = s.Width
                                   pb.Height = s.Height
                               End Sub)

            AddHandler pb.MouseDown, AddressOf OnObjectMouseDown
            AddHandler pb.MouseMove, AddressOf OnObjectMouseMove
            AddHandler pb.MouseUp, AddressOf OnObjectMouseUp
            AddHandler pb.Click, AddressOf OnObjectClick
        Next
    End Sub

    Private Sub lbAssets_SelectedIndexChanged(sender As Object, e As EventArgs)
        currentAssetKey = If(lbAssets.SelectedItem IsNot Nothing, lbAssets.SelectedItem.ToString(), Nothing)
    End Sub

    Private Sub panelCanvas_MouseDown(sender As Object, e As MouseEventArgs)
        Dim p = ParentMain()
        If p Is Nothing Then Return
        If e.Button = MouseButtons.Left AndAlso currentAssetKey IsNot Nothing AndAlso p.assets.ContainsKey(currentAssetKey) Then
            Dim img = p.assets(currentAssetKey)
            Dim pb = New PictureBox()
            pb.Image = img
            pb.SizeMode = PictureBoxSizeMode.StretchImage
            pb.Width = Math.Min(128, img.Width)
            pb.Height = Math.Min(128, img.Height)
            pb.Left = e.X - (pb.Width \ 2)
            pb.Top = e.Y - (pb.Height \ 2)
            pb.Cursor = Cursors.Hand
            panelCanvas.Controls.Add(pb)

            Dim so = New Form1.SceneObject() With {
                .AssetKey = currentAssetKey,
                .X = pb.Left,
                .Y = pb.Top,
                .Width = pb.Width,
                .Height = pb.Height
            }
            so.SetUpdateAction(Sub(s)
                                   pb.Left = s.X
                                   pb.Top = s.Y
                                   pb.Width = s.Width
                                   pb.Height = s.Height
                               End Sub)
            pb.Tag = so
            p.sceneObjects.Add(so)

            AddHandler pb.MouseDown, AddressOf OnObjectMouseDown
            AddHandler pb.MouseMove, AddressOf OnObjectMouseMove
            AddHandler pb.MouseUp, AddressOf OnObjectMouseUp
            AddHandler pb.Click, AddressOf OnObjectClick

            p.SelectedObject = so
            propertyGrid.SelectedObject = so
        End If
    End Sub

    Private draggingObj As Form1.SceneObject = Nothing
    Private dragOffset As Point
    Private isDragging As Boolean = False

    Private Sub OnObjectMouseDown(sender As Object, e As MouseEventArgs)
        Dim pb = DirectCast(sender, PictureBox)
        Dim so = DirectCast(pb.Tag, Form1.SceneObject)
        If e.Button = MouseButtons.Left Then
            draggingObj = so
            dragOffset = e.Location
            isDragging = True
            Dim p = ParentMain()
            If p IsNot Nothing Then p.SelectedObject = so
            propertyGrid.SelectedObject = so
        End If
    End Sub

    Private Sub OnObjectMouseMove(sender As Object, e As MouseEventArgs)
        If Not isDragging OrElse draggingObj Is Nothing Then Return
        Dim pb = DirectCast(sender, PictureBox)
        Dim mousePos = panelCanvas.PointToClient(Control.MousePosition)
        Dim nx = mousePos.X - dragOffset.X
        Dim ny = mousePos.Y - dragOffset.Y
        pb.Left = nx
        pb.Top = ny
        draggingObj.X = pb.Left
        draggingObj.Y = pb.Top
    End Sub

    Private Sub OnObjectMouseUp(sender As Object, e As MouseEventArgs)
        isDragging = False
        draggingObj = Nothing
    End Sub

    Private Sub OnObjectClick(sender As Object, e As EventArgs)
        Dim pb = DirectCast(sender, PictureBox)
        Dim so = DirectCast(pb.Tag, Form1.SceneObject)
        Dim p = ParentMain()
        If p IsNot Nothing Then p.SelectedObject = so
        propertyGrid.SelectedObject = so
    End Sub

    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditorForm))
        Me.SuspendLayout()
        '
        'EditorForm
        '
        Me.ClientSize = New System.Drawing.Size(282, 253)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "EditorForm"
        Me.ResumeLayout(False)

    End Sub
End Class
