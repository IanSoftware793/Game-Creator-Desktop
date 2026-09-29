Imports System.Windows.Forms

Public Class CodeForm
    Inherits Form

    Private txtCode As TextBox

    Public Sub New()
        Me.Text = "Code"
        Me.Size = New Drawing.Size(800, 600)
        Me.StartPosition = FormStartPosition.CenterParent
        txtCode = New TextBox()
        txtCode.Dock = DockStyle.Fill
        txtCode.Multiline = True
        txtCode.ScrollBars = ScrollBars.Both
        txtCode.Font = New Drawing.Font("Consolas", 10)
        txtCode.WordWrap = False
        Me.Controls.Add(txtCode)
    End Sub

    Public Sub SetCode(code As String)
        txtCode.Text = code
    End Sub

End Class
