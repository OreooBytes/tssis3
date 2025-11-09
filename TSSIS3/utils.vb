Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Module Utils
    Public Sub ApplyRoundedCorners(ByVal pnl As Control, ByVal radius As Integer)
        Dim rect As New Rectangle(0, 0, pnl.Width - 1, pnl.Height - 1)
        Dim path As New GraphicsPath()

        path.AddArc(rect.X, rect.Y, radius, radius, 180, 90)
        path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90)
        path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90)
        path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90)
        path.CloseFigure()

        Using g As Graphics = pnl.CreateGraphics()
            g.SmoothingMode = SmoothingMode.AntiAlias
            pnl.Region = New Region(path)
        End Using
    End Sub



End Module
