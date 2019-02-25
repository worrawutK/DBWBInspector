'-------------------------------------------------------------------------------
' Resizer
' This class is used to dynamically resize and reposition all controls on a form.
' Container controls are processed recursively so that all controls on the form
' are handled.
'
' Usage:
'  Resizing functionality requires only three lines of code on a form:
'
'  1. Create a form-level reference to the Resize class:
'     Dim myResizer as Resizer
'
'  2. In the Form_Load event, call the  Resizer class FIndAllControls method:
'     myResizer.FindAllControls(Me)
'
'  3. In the Form_Resize event, call the  Resizer class ResizeAllControls method:
'     myResizer.ResizeAllControls(Me)
'
'-------------------------------------------------------------------------------
Public Class Resizer

    '----------------------------------------------------------
    ' ControlInfo
    ' Structure of original state of all processed controls
    '----------------------------------------------------------
    Private Structure ControlInfo
        Public name As String
        Public parentName As String
        Public leftOffsetPercent As Double
        Public topOffsetPercent As Double
        Public heightPercent As Double
        Public originalHeight As Integer
        Public originalWidth As Integer
        Public widthPercent As Double
        Public originalFontSize As Single
        Public originalcolumnWidth As Integer
        Public originalcolumnHight As Integer
    End Structure

    '-------------------------------------------------------------------------
    ' ctrlDict
    ' Dictionary of (control name, control info) for all processed controls
    '-------------------------------------------------------------------------
    Private ctrlDict As Dictionary(Of String, ControlInfo) = New Dictionary(Of String, ControlInfo)

    '----------------------------------------------------------------------------------------
    ' FindAllControls
    ' Recursive function to process all controls contained in the initially passed
    ' control container and store it in the Control dictionary
    '----------------------------------------------------------------------------------------
    Public Sub FindAllControls(thisCtrl As Control)

        '-- If the current control has a parent, store all original relative position
        '-- and size information in the dictionary.
        '-- Recursively call FindAllControls for each control contained in the
        '-- current Control
        For Each ctl As Control In thisCtrl.Controls
            Try
                'If (ctl.GetType() Is GetType(DataGridView)) Then
                '    If ctl.Name = "ViewData" Then
                '        Dim aa = ""
                '    End If
                'End If
                If (ctl.GetType() Is GetType(DataGridView)) Then
                    Dim Grid As DataGridView = CType(ctl, DataGridView)
                    If Not IsNothing(ctl.Parent) Then
                        Dim parentHeight = ctl.Parent.Height
                        Dim parentWidth = ctl.Parent.Width

                        Dim c As New ControlInfo
                        c.name = Grid.Name
                        c.parentName = Grid.Parent.Name
                        c.topOffsetPercent = Convert.ToDouble(Grid.Top) / Convert.ToDouble(parentHeight)
                        c.leftOffsetPercent = Convert.ToDouble(Grid.Left) / Convert.ToDouble(parentWidth)
                        c.heightPercent = Convert.ToDouble(Grid.Height) / Convert.ToDouble(parentHeight)
                        c.widthPercent = Convert.ToDouble(Grid.Width) / Convert.ToDouble(parentWidth)
                        c.originalFontSize = Grid.DefaultCellStyle.Font.Size 'Grid.Font.Size
                        c.originalHeight = Grid.Height
                        c.originalWidth = Grid.Width
                        '   c.originalcolumnWidth = Grid.Columns(0).Width
                        ' c.originalcolumnHight = Grid.Rows(0).Height
                        ctrlDict.Add(c.name, c)

                    End If
                Else
                    If Not IsNothing(ctl.Parent) Then
                        Dim parentHeight = ctl.Parent.Height
                        Dim parentWidth = ctl.Parent.Width

                        Dim c As New ControlInfo
                        c.name = ctl.Name
                        c.parentName = ctl.Parent.Name
                        c.topOffsetPercent = Convert.ToDouble(ctl.Top) / Convert.ToDouble(parentHeight)
                        c.leftOffsetPercent = Convert.ToDouble(ctl.Left) / Convert.ToDouble(parentWidth)
                        c.heightPercent = Convert.ToDouble(ctl.Height) / Convert.ToDouble(parentHeight)
                        c.widthPercent = Convert.ToDouble(ctl.Width) / Convert.ToDouble(parentWidth)
                        c.originalFontSize = ctl.Font.Size
                        c.originalHeight = ctl.Height
                        c.originalWidth = ctl.Width
                        ctrlDict.Add(c.name, c)
                    End If
                End If



            Catch ex As Exception
                Debug.Print(ex.Message)
            End Try

            If ctl.Controls.Count > 0 Then
                FindAllControls(ctl)
            End If

        Next '-- For Each

    End Sub

    '----------------------------------------------------------------------------------------
    ' ResizeAllControls
    ' Recursive function to resize and reposition all controls contained in the Control
    ' dictionary
    '----------------------------------------------------------------------------------------
    Public Sub ResizeAllControls(thisCtrl As Control)

        Dim fontRatioW As Single
        Dim fontRatioH As Single
        Dim fontRatio As Single
        Dim f As Font

        '-- Resize and reposition all controls in the passed control
        For Each ctl As Control In thisCtrl.Controls
            'If (ctl.GetType() Is GetType(DataGridView)) Or (ctl.GetType() Is GetType(Panel)) Then
            '    If ctl.Name = "ViewData" Or ctl.Name = "PanelNG" Then
            '        Dim aa = ""
            '    End If
            'End If
            Try
                If (ctl.GetType() Is GetType(PictureBox)) Then
                    Dim pb As PictureBox = CType(ctl, PictureBox)
                    If pb.Name = "pbxLogo" Then
                        Continue For
                    End If
                    'MinimizeButton
                End If
                If (ctl.GetType() Is GetType(Button)) Then
                    Dim bt As Button = CType(ctl, Button)
                    If bt.Name = "MinimizeButton" OrElse bt.Name = "BtExit2" Then
                        Continue For
                    End If
                    'MinimizeButton
                End If

                If (ctl.GetType() Is GetType(Label)) Then
                    Dim lb As Label = CType(ctl, Label)
                    If lb.Name = "lbVersion" Then
                        Continue For
                    End If
                    'MinimizeButton
                End If

                'If (ctl.GetType() Is GetType(DataGridView)) Then
                '    Dim Gd As DataGridView = CType(ctl, DataGridView)

                '    'MinimizeButton
                'End If
                'lbVersion
                If Not IsNothing(ctl.Parent) Then
                    Dim parentHeight = ctl.Parent.Height
                    Dim parentWidth = ctl.Parent.Width

                    Dim c As New ControlInfo

                    Dim ret As Boolean = False
                    Try

                        '-- Get the current control's info from the control info dictionary
                        ret = ctrlDict.TryGetValue(ctl.Name, c)

                        '-- If found, adjust the current control based on control relative
                        '-- size and position information stored in the dictionary
                        If (ret) Then
                            '-- Size
                            ctl.Width = Int(parentWidth * c.widthPercent)
                            ctl.Height = Int(parentHeight * c.heightPercent)

                            '-- Position
                            ctl.Top = Int(parentHeight * c.topOffsetPercent)
                            ctl.Left = Int(parentWidth * c.leftOffsetPercent)

                            '-- Font
                            f = ctl.Font
                            fontRatioW = ctl.Width / c.originalWidth
                            fontRatioH = ctl.Height / c.originalHeight
                            fontRatio = (fontRatioW +
                            fontRatioH) / 2 '-- average change in control Height and Width
                            ctl.Font = New Font(f.FontFamily,
                            c.originalFontSize * fontRatio, f.Style)

                        End If
                    Catch
                    End Try
                End If
            Catch ex As Exception

            End Try

            '-- Recursive call for controls contained in the current control
            If ctl.Controls.Count > 0 Then
                ResizeAllControls(ctl)
            End If

        Next '-- For Each
    End Sub

End Class
