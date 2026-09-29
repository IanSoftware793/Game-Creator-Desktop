Imports System.Windows.Forms

Public Class PlayForm
    Inherits Form

    Public Sub New(scene As List(Of Form1.SceneObject), assets As Dictionary(Of String, Image), size As Size)
        Me.Text = "Playtest"
        Me.StartPosition = FormStartPosition.CenterParent
        Me.ClientSize = size
        Me.FormBorderStyle = FormBorderStyle.Sizable

        For Each so In scene
            If assets.ContainsKey(so.AssetKey) Then
                Dim img = assets(so.AssetKey)
                Dim pb = New PictureBox()
                pb.Image = img
                pb.SizeMode = PictureBoxSizeMode.StretchImage
                pb.Left = so.X
                pb.Top = so.Y
                pb.Width = so.Width
                pb.Height = so.Height
                pb.Enabled = False
                Me.Controls.Add(pb)
            End If
        Next

    End Sub

End Class
