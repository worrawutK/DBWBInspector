Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf

Public Class AQI
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try


            If tbTotalNG.Text = "" Or tbTotalNG.Text = "" Or cbMagazine.Text = "" Or cbProcess.Text = "" Then
                    MsgBox("กรุณากรอกข้อมูลให้ครบ")
                    Exit Sub
                End If
                If cbMagazine.Text = "PASS LOT" Then
                    If tbFirstFrom.Text = "" Or tbEndFrom.Text = "" Then
                        MsgBox("กรุณากรอกข้อมูล FROM ให้ครบ")
                        Exit Sub
                    End If
                End If
                If lbDateRequest.Text = "" Then
                    MsgBox("ไม่มีข้อมูล Date Request กรุณาตรวจสอบ Process")
                    Exit Sub
                End If

                Dim PathAQI As String = My.Application.Info.DirectoryPath & "\AQI"
                If Not (Directory.Exists(PathAQI)) Then
                    Directory.CreateDirectory(PathAQI)
                End If
                Dim PDFname As String = PathAQI & "\AQI_" & Format(Now, "yyyy-MM-dd_HH_mm_ss") & ".pdf"

                Dim pdfDoc As New iTextSharp.text.Document()
                Dim pdfWrite As iTextSharp.text.pdf.PdfWriter = iTextSharp.text.pdf.PdfWriter.GetInstance(pdfDoc, New FileStream(PDFname, FileMode.Create))
                pdfDoc.Open()

                iTextSharp.text.FontFactory.Register(My.Application.Info.DirectoryPath & "\Font\angsa.ttf", "AngsanaNew")
                Dim Font12 As Font = FontFactory.GetFont("AngsanaNew", 12, 0, BaseColor.BLACK) '0 ตัวธรรมดา ,1 ตัวหนา ,2 ตัวเอียง ,3 เอียงและหนา,.....
                Dim Font10 As Font = FontFactory.GetFont("AngsanaNew", 10, 0, BaseColor.BLACK) '0 ตัวธรรมดา ,1 ตัวหนา ,2 ตัวเอียง ,3 เอียงและหนา,.....
                Dim Font18 As Font = FontFactory.GetFont("AngsanaNew", 20, 0, BaseColor.RED) '0 ตัวธรรมดา ,1 ตัวหนา ,2 ตัวเอียง ,3 เอียงและหนา,.....

                Dim HeaderNull As PdfPCell = New PdfPCell(New Paragraph(" ", Font18))
                HeaderNull.Border = 0
                Dim Header As PdfPCell = New PdfPCell(New Paragraph("ABNORMAL QUALITY INFORMATION OF DB/WB INSPECTION", Font18))
                Header.Border = 0
            'Dim Header As Paragraph = New Paragraph("ABNORMAL QUALITY INFORMATION OF DB/WB INSPECTION", Font18)
            'Header.Alignment = Element.ALIGN_CENTER
            'Header.Alignment = Element.ALIGN_BOTTOM
            ' Header.Font.Color = BaseColor.RED



            Dim tableCheck As PdfPTable = New PdfPTable(2)
                Dim lssue As PdfPCell = New PdfPCell(New Phrase("lssue"))
                Dim check As PdfPCell = New PdfPCell(New Phrase("check"))

                lssue.HorizontalAlignment = HorizontalAlignment.Right 'center
                check.HorizontalAlignment = HorizontalAlignment.Right 'center
                tableCheck.DefaultCell.Border = Rectangle.NO_BORDER
                tableCheck.AddCell(lssue)
                tableCheck.AddCell(check)

                Dim cell_lssue As PdfPCell = New PdfPCell(New Phrase(" "))
                Dim cell_check As PdfPCell = New PdfPCell(New Phrase(" "))
                cell_lssue.FixedHeight = 50.0F
                cell_check.FixedHeight = 50.0F
                tableCheck.AddCell(cell_lssue)
                tableCheck.AddCell(cell_check)

                Dim wid() As Integer = {750, 110, 110}
                Dim Headertable As PdfPTable = New PdfPTable(3)
                Headertable.WidthPercentage = 100

                Headertable.SetWidths(wid)
                ' Headertable.DefaultCell.Border = Rectangle.NO_BORDER
                Headertable.AddCell(HeaderNull)
                Headertable.AddCell(lssue)
                Headertable.AddCell(check)
                Headertable.AddCell(Header)
                Headertable.AddCell(cell_lssue)
                Headertable.AddCell(cell_check)
                '  Headertable.AddCell(Header)

                '  Headertable.AddCell(tableCheck)
                pdfDoc.Add(Headertable)

                'Dim table As PdfPTable = New PdfPTable(2)

                'Dim cell1 As PdfPCell = New PdfPCell(New Phrase("R_O C_0"))
                'Dim cell2 As PdfPCell = New PdfPCell(New Phrase("R_O C_1"))
                'Dim cell3 As PdfPCell = New PdfPCell(New Phrase("R_1 C_all"))
                'cell3.Colspan = 2
                'table.AddCell(cell1)
                'table.AddCell(cell2)
                'table.AddCell(cell3)

                'pdfDoc.Add(table)



                Dim Main_table As PdfPTable = New PdfPTable(2)
                Main_table.WidthPercentage = 100
                Dim widMain() As Integer = {450, 450}
                Main_table.DefaultCell.Border = Rectangle.BOX
                Main_table.SetWidths(widMain)
                '   Main_table.DefaultCell.Border = Rectangle.NO_BORDER 'Rectangle.BOX

#Region "Sub1"

                'Sub1
                Dim Sub_table1 As PdfPTable = New PdfPTable(2)
                '  Sub_table.WidthPercentage = 100
                Dim widSub() As Integer = {18, 10}
                Sub_table1.SetWidths(widSub)
                Sub_table1.DefaultCell.Border = Rectangle.NO_BORDER

                Dim SubCell_1 As PdfPCell = New PdfPCell(New Phrase("PACKAGE : " & lbPackage.Text, Font12))
                Dim SubCell_2 As PdfPCell = New PdfPCell(New Phrase("DEVICE NAME : " & lbDevice.Text, Font12))
                Dim SubCell_3 As PdfPCell = New PdfPCell(New Phrase("LOT NO. : " & lbLotNo.Text, Font12))
                Dim SubCell_4 As PdfPCell = New PdfPCell(New Phrase("MODE REQUEST1 :" & lbMode1.Text, Font12))
                Dim SubCell_5 As PdfPCell = New PdfPCell(New Phrase("REMARK1 : " & lbRemark1.Text, Font12))
                Dim REQUEST2 As PdfPCell = New PdfPCell(New Phrase("MODE REQUEST2 :" & lbMode2.Text, Font12))
                Dim REMARK2 As PdfPCell = New PdfPCell(New Phrase("REMARK2 : " & lbRemark2.Text, Font12))
                Dim SubCell_6 As PdfPCell = New PdfPCell(New Phrase("OBJECT MAGAZINE : " & cbMagazine.Text, Font12))
                Dim SubCell_7 As PdfPCell = New PdfPCell(New Phrase("FROM : " & tbFirstFrom.Text & " TO " & tbEndFrom.Text, Font12))
                Dim SubCell_8 As PdfPCell = New PdfPCell(New Phrase("PROCESS : " & cbProcess.Text, Font12))
                Dim SubCell_9 As PdfPCell = New PdfPCell(New Phrase("M/C NO. : " & tbMCNo.Text & vbCrLf & " ", Font12))

                SubCell_1.Border = 0
                SubCell_2.Border = 0
                SubCell_3.Border = 0
                SubCell_4.Border = 0
                SubCell_5.Border = 0
                REQUEST2.Border = 0
                REMARK2.Border = 0

                SubCell_6.Border = 0
                SubCell_7.Border = 0
                SubCell_8.Border = 0
                SubCell_9.Border = 0
                SubCell_1.Colspan = 2
                SubCell_2.Colspan = 2
                SubCell_3.Colspan = 2

                Sub_table1.AddCell(SubCell_1)
                Sub_table1.AddCell(SubCell_2)
                Sub_table1.AddCell(SubCell_3)
                Sub_table1.AddCell(SubCell_4)
                Sub_table1.AddCell(SubCell_5)
                Sub_table1.AddCell(REQUEST2)
                Sub_table1.AddCell(REMARK2)
                Sub_table1.AddCell(SubCell_6)
                Sub_table1.AddCell(SubCell_7)
                Sub_table1.AddCell(SubCell_8)
                Sub_table1.AddCell(SubCell_9)
#End Region
#Region "Sub2"
                'Sub2
                Dim Sub_table2 As PdfPTable = New PdfPTable(3)
                '  Sub_table.WidthPercentage = 100
                Dim widSub2() As Integer = {10, 10, 10}
                Sub_table2.SetWidths(widSub2)
                Sub_table2.DefaultCell.Border = Rectangle.NO_BORDER
                '  Sub_table2.DefaultCell.FixedHeight = 200.0F
                Dim Sub2Cell_1 As PdfPCell = New PdfPCell(New Phrase("DARE REQUEST : " & lbDateRequest.Text, Font12))
                Dim Sub2Cell_2 As PdfPCell = New PdfPCell(New Phrase("DATE INSPECTION : " & lbDateInspection.Text, Font12))
                Dim Sub2Cell_3 As PdfPCell = New PdfPCell(New Phrase("INSPECTOR NO. : " & lbInspectorNo.Text, Font12))
                ' Dim Sub2Cell_5 As PdfPCell = New PdfPCell(New Phrase("TOTAL Q'TY : - PCS.", Font12))
                Dim Sub2Cell_4 As PdfPCell = New PdfPCell(New Phrase("TOTAL NG : " & tbTotalNG.Text & " PCS.", Font12))
                '    Dim Sub2Cell_6 As PdfPCell = New PdfPCell(New Phrase("NG RATE : - %", Font12))
                Dim Sub2Cell_7 As PdfPCell = New PdfPCell(New Phrase(tbDetailAbnormal.Text, Font12))

                Sub2Cell_1.Colspan = 3
                Sub2Cell_2.Colspan = 3
                Sub2Cell_3.Colspan = 3
                Sub2Cell_7.Colspan = 3
                Sub2Cell_4.Colspan = 3
                Sub2Cell_1.Border = 0
                Sub2Cell_2.Border = 0
                Sub2Cell_3.Border = 0
                Sub2Cell_4.Border = 0
                '   Sub2Cell_5.Border = 0
                ' Sub2Cell_6.Border = 0
                '   Sub2Cell_7.Border = 0

                '  Sub2Cell_7.NoWrap = True
                '  Sub2Cell_7.Rowspan = 2
                'Sub2Cell_8.Rowspan = 2
                '  Sub2Cell_7.FixedHeight = 50.0F
                Sub_table2.AddCell(Sub2Cell_1)
                Sub_table2.AddCell(Sub2Cell_2)
                Sub_table2.AddCell(Sub2Cell_3)
                Sub_table2.AddCell(Sub2Cell_4)
                '   Sub_table2.AddCell(Sub2Cell_5)
                '  Sub_table2.AddCell(Sub2Cell_6)
                Sub_table2.AddCell(Sub2Cell_7)
                'Sub_table2.AddCell(Sub2Cell_8)
#End Region
#Region "Sub3"
                'Sub3
                Dim Column As Integer = 14
                Dim Sub_table3 As PdfPTable = New PdfPTable(Column)
                '  Sub_table.WidthPercentage = 100
                Dim widSub3() As Integer = {30, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 15}
                Sub_table3.SetWidths(widSub3)
                Sub_table3.DefaultCell.Border = Rectangle.NO_BORDER
                '  Sub_table2.DefaultCell.FixedHeight = 200.0F
                Dim Sub3Cell_1 As PdfPCell = New PdfPCell(New Phrase("NG MODE", Font10))
                Dim Sub3Cell_2 As PdfPCell = New PdfPCell(New Phrase("MAG1", Font10))
                Dim Sub3Cell_3 As PdfPCell = New PdfPCell(New Phrase("MAG2", Font10))
                Dim Sub3Cell_4 As PdfPCell = New PdfPCell(New Phrase("MAG3", Font10))
                Dim Sub3Cell_5 As PdfPCell = New PdfPCell(New Phrase("MAG4", Font10))
                Dim Sub3Cell_6 As PdfPCell = New PdfPCell(New Phrase("MAG5", Font10))
                Dim Sub3Cell_7 As PdfPCell = New PdfPCell(New Phrase("MAG6", Font10))
                Dim Sub3Cell_8 As PdfPCell = New PdfPCell(New Phrase("MAG7", Font10))
                Dim Sub3Cell_9 As PdfPCell = New PdfPCell(New Phrase("MAG8", Font10))
                Dim Sub3Cell_10 As PdfPCell = New PdfPCell(New Phrase("MAG9", Font10))
                Dim Sub3Cell_11 As PdfPCell = New PdfPCell(New Phrase("MAG10", Font10))
                Dim Sub3Cell_12 As PdfPCell = New PdfPCell(New Phrase("MAG11", Font10))
                Dim Sub3Cell_13 As PdfPCell = New PdfPCell(New Phrase("MAG12", Font10))
                Dim Sub3Cell_14 As PdfPCell = New PdfPCell(New Phrase("TOTAL (PCS.)", Font10))
                Sub3Cell_1.HorizontalAlignment = Element.ALIGN_CENTER
                Sub3Cell_2.HorizontalAlignment = Element.ALIGN_CENTER
                Sub3Cell_3.HorizontalAlignment = Element.ALIGN_CENTER
                Sub3Cell_4.HorizontalAlignment = Element.ALIGN_CENTER
                Sub3Cell_4.HorizontalAlignment = Element.ALIGN_CENTER
                Sub3Cell_5.HorizontalAlignment = Element.ALIGN_CENTER
                Sub3Cell_6.HorizontalAlignment = Element.ALIGN_CENTER
                Sub3Cell_7.HorizontalAlignment = Element.ALIGN_CENTER
                Sub3Cell_8.HorizontalAlignment = Element.ALIGN_CENTER
                Sub3Cell_9.HorizontalAlignment = Element.ALIGN_CENTER
                Sub3Cell_10.HorizontalAlignment = Element.ALIGN_CENTER
                Sub3Cell_11.HorizontalAlignment = Element.ALIGN_CENTER
                Sub3Cell_12.HorizontalAlignment = Element.ALIGN_CENTER
                Sub3Cell_13.HorizontalAlignment = Element.ALIGN_CENTER
                Sub3Cell_14.HorizontalAlignment = Element.ALIGN_CENTER
                '  Sub2Cell_7.NoWrap = True
                '  Sub2Cell_7.Rowspan = 2
                'Sub2Cell_8.Rowspan = 2
                '  Sub2Cell_7.FixedHeight = 50.0F
                Sub3Cell_1.FixedHeight = 20.0F
                Sub_table3.AddCell(Sub3Cell_1)
                Sub_table3.AddCell(Sub3Cell_2)
                Sub_table3.AddCell(Sub3Cell_3)
                Sub_table3.AddCell(Sub3Cell_4)
                Sub_table3.AddCell(Sub3Cell_5)
                Sub_table3.AddCell(Sub3Cell_6)
                Sub_table3.AddCell(Sub3Cell_7)
                Sub_table3.AddCell(Sub3Cell_8)
                Sub_table3.AddCell(Sub3Cell_9)
                Sub_table3.AddCell(Sub3Cell_10)
                Sub_table3.AddCell(Sub3Cell_11)
                Sub_table3.AddCell(Sub3Cell_12)
                Sub_table3.AddCell(Sub3Cell_13)
            Sub_table3.AddCell(Sub3Cell_14)

            Dim p As Paragraph = New Paragraph("value")
                p.Alignment = Element.ALIGN_CENTER
                'For j = 0 To 7
                '    For i = 1 To Column
                '        Dim Sub3Cell As PdfPCell = New PdfPCell(New Phrase(j & "," & i, Font10))
                '        Sub3Cell.FixedHeight = 15.0F
                '        Sub3Cell.HorizontalAlignment = Element.ALIGN_CENTER
                '        Sub_table3.AddCell(Sub3Cell)
                '    Next
                'Next
                Dim sumM1 As String = "0"
                Dim sumM2 As String = "0"
                Dim sumM3 As String = "0"
                Dim sumM4 As String = "0"
                Dim sumM5 As String = "0"
                Dim sumM6 As String = "0"
                Dim sumM7 As String = "0"
                Dim sumM8 As String = "0"
                Dim sumM9 As String = "0"
                Dim sumM10 As String = "0"
                Dim sumM11 As String = "0"
                Dim sumM12 As String = "0"
                Dim sumTOTAL As String = "0"

                For Each data As DataRow In Detail.Rows
                    For i = 1 To Column
                        'Dim Sub3Cell As PdfPCell = New PdfPCell(New Phrase("", Font10))
                        'Sub3Cell.FixedHeight = 15.0F
                        'Sub3Cell.HorizontalAlignment = Element.ALIGN_CENTER
                        'Sub_table3.AddCell(Sub3Cell)
                    Next
                    Dim NG_Mode As PdfPCell = New PdfPCell(New Phrase(data("NG_Mode"), Font10))
                    NG_Mode.FixedHeight = 15.0F
                    NG_Mode.HorizontalAlignment = Element.ALIGN_LEFT
                    Sub_table3.AddCell(NG_Mode)

                    Dim MAG1 As PdfPCell
                    If Not data("MAG1") Is DBNull.Value Then
                        MAG1 = New PdfPCell(New Phrase(data("MAG1"), Font10))
                        sumM1 = CInt(sumM1) + CInt(data("MAG1"))
                    Else
                        MAG1 = New PdfPCell(New Phrase("", Font10))
                    End If
                    MAG1.FixedHeight = 15.0F
                    MAG1.HorizontalAlignment = Element.ALIGN_CENTER
                    Sub_table3.AddCell(MAG1)

                    Dim MAG2 As PdfPCell
                    If Not data("MAG2") Is DBNull.Value Then
                        MAG2 = New PdfPCell(New Phrase(data("MAG2"), Font10))
                        sumM2 = CInt(sumM2) + CInt(data("MAG2"))
                    Else
                        MAG2 = New PdfPCell(New Phrase("", Font10))
                    End If
                    MAG2.FixedHeight = 15.0F
                    MAG2.HorizontalAlignment = Element.ALIGN_CENTER
                    Sub_table3.AddCell(MAG2)

                    Dim MAG3 As PdfPCell
                    If Not data("MAG3") Is DBNull.Value Then
                        MAG3 = New PdfPCell(New Phrase(data("MAG3"), Font10))
                        sumM3 = CInt(sumM3) + CInt(data("MAG3"))
                    Else
                        MAG3 = New PdfPCell(New Phrase("", Font10))
                    End If
                    MAG3.FixedHeight = 15.0F
                    MAG3.HorizontalAlignment = Element.ALIGN_CENTER
                    Sub_table3.AddCell(MAG3)

                    Dim MAG4 As PdfPCell
                    If Not data("MAG4") Is DBNull.Value Then
                        MAG4 = New PdfPCell(New Phrase(data("MAG4"), Font10))
                        sumM4 = CInt(sumM4) + CInt(data("MAG4"))
                    Else
                        MAG4 = New PdfPCell(New Phrase("", Font10))
                    End If
                    MAG4.FixedHeight = 15.0F
                    MAG4.HorizontalAlignment = Element.ALIGN_CENTER
                    Sub_table3.AddCell(MAG4)

                    Dim MAG5 As PdfPCell
                    If Not data("MAG5") Is DBNull.Value Then
                        MAG5 = New PdfPCell(New Phrase(data("MAG5"), Font10))
                        sumM5 = CInt(sumM5) + CInt(data("MAG5"))
                    Else
                        MAG5 = New PdfPCell(New Phrase("", Font10))
                    End If
                    MAG5.FixedHeight = 15.0F
                    MAG5.HorizontalAlignment = Element.ALIGN_CENTER
                    Sub_table3.AddCell(MAG5)

                    Dim MAG6 As PdfPCell
                    If Not data("MAG6") Is DBNull.Value Then
                        MAG6 = New PdfPCell(New Phrase(data("MAG6"), Font10))
                        sumM6 = CInt(sumM6) + CInt(data("MAG6"))
                    Else
                        MAG6 = New PdfPCell(New Phrase("", Font10))
                    End If
                    MAG6.FixedHeight = 15.0F
                    MAG6.HorizontalAlignment = Element.ALIGN_CENTER
                    Sub_table3.AddCell(MAG6)

                    Dim MAG7 As PdfPCell
                    If Not data("MAG7") Is DBNull.Value Then
                        MAG7 = New PdfPCell(New Phrase(data("MAG7"), Font10))
                        sumM7 = CInt(sumM7) + CInt(data("MAG7"))
                    Else
                        MAG7 = New PdfPCell(New Phrase("", Font10))
                    End If
                    MAG7.FixedHeight = 15.0F
                    MAG7.HorizontalAlignment = Element.ALIGN_CENTER
                    Sub_table3.AddCell(MAG7)

                    Dim MAG8 As PdfPCell
                    If Not data("MAG8") Is DBNull.Value Then
                        MAG8 = New PdfPCell(New Phrase(data("MAG8"), Font10))
                        sumM8 = CInt(sumM8) + CInt(data("MAG8"))
                    Else
                        MAG8 = New PdfPCell(New Phrase("", Font10))
                    End If
                    MAG8.FixedHeight = 15.0F
                    MAG8.HorizontalAlignment = Element.ALIGN_CENTER
                    Sub_table3.AddCell(MAG8)

                    Dim MAG9 As PdfPCell
                    If Not data("MAG9") Is DBNull.Value Then
                        MAG9 = New PdfPCell(New Phrase(data("MAG9"), Font10))
                        sumM9 = CInt(sumM9) + CInt(data("MAG9"))
                    Else
                        MAG9 = New PdfPCell(New Phrase("", Font10))
                    End If
                    MAG9.FixedHeight = 15.0F
                    MAG9.HorizontalAlignment = Element.ALIGN_CENTER
                    Sub_table3.AddCell(MAG9)

                    Dim MAG10 As PdfPCell
                    If Not data("MAG10") Is DBNull.Value Then
                        MAG10 = New PdfPCell(New Phrase(data("MAG10"), Font10))
                        sumM10 = CInt(sumM10) + CInt(data("MAG10"))
                    Else
                        MAG10 = New PdfPCell(New Phrase("", Font10))
                    End If
                    MAG10.FixedHeight = 15.0F
                    MAG10.HorizontalAlignment = Element.ALIGN_CENTER
                    Sub_table3.AddCell(MAG10)

                    Dim MAG11 As PdfPCell
                    If Not data("MAG11") Is DBNull.Value Then
                        MAG11 = New PdfPCell(New Phrase(data("MAG11"), Font10))
                        sumM11 = CInt(sumM11) + CInt(data("MAG11"))
                    Else
                        MAG11 = New PdfPCell(New Phrase("", Font10))
                    End If
                    MAG11.FixedHeight = 15.0F
                    MAG11.HorizontalAlignment = Element.ALIGN_CENTER
                    Sub_table3.AddCell(MAG11)

                    Dim MAG12 As PdfPCell
                    If Not data("MAG12") Is DBNull.Value Then
                        MAG12 = New PdfPCell(New Phrase(data("MAG12"), Font10))
                        sumM12 = CInt(sumM12) + CInt(data("MAG12"))
                    Else
                        MAG12 = New PdfPCell(New Phrase("", Font10))
                    End If
                    MAG12.FixedHeight = 15.0F
                    MAG12.HorizontalAlignment = Element.ALIGN_CENTER
                    Sub_table3.AddCell(MAG12)

                    Dim TOTAL As PdfPCell
                    If Not data("TOTAL") Is DBNull.Value Then
                        TOTAL = New PdfPCell(New Phrase(data("TOTAL"), Font10))
                        sumTOTAL = CInt(sumTOTAL) + CInt(data("TOTAL"))
                    Else
                        TOTAL = New PdfPCell(New Phrase("", Font10))
                    End If
                    TOTAL.FixedHeight = 15.0F
                    TOTAL.HorizontalAlignment = Element.ALIGN_CENTER
                    Sub_table3.AddCell(TOTAL)
                    If Detail.Rows.Count < 8 Then
                        If RowId(data) = Detail.Rows.Count Then
                            Dim AddRow As Integer = 7 - RowId(data)
                            For i = 1 To AddRow
                                For j = 1 To 14
                                    Dim CellNull As PdfPCell
                                    CellNull = New PdfPCell(New Phrase("", Font10))
                                    CellNull.FixedHeight = 15.0F
                                    CellNull.HorizontalAlignment = Element.ALIGN_CENTER
                                    Sub_table3.AddCell(CellNull)
                                Next
                            Next
                        End If

                    End If

                Next
                If Detail.Rows.Count = 0 Then

                    Dim AddRow As Integer = 7
                    For i = 1 To AddRow
                        For j = 1 To 14
                            Dim CellNull As PdfPCell
                            CellNull = New PdfPCell(New Phrase("", Font10))
                            CellNull.FixedHeight = 15.0F
                            CellNull.HorizontalAlignment = Element.ALIGN_CENTER
                            Sub_table3.AddCell(CellNull)
                        Next
                    Next

                End If
                'End Row
                If sumM1 = "0" Then sumM1 = ""
                If sumM2 = "0" Then sumM2 = ""
                If sumM3 = "0" Then sumM3 = ""
                If sumM4 = "0" Then sumM4 = ""
                If sumM5 = "0" Then sumM5 = ""
                If sumM6 = "0" Then sumM6 = ""
                If sumM7 = "0" Then sumM7 = ""
                If sumM8 = "0" Then sumM8 = ""
                If sumM9 = "0" Then sumM9 = ""
                If sumM10 = "0" Then sumM10 = ""
                If sumM11 = "0" Then sumM11 = ""
                If sumM12 = "0" Then sumM12 = ""
                If sumTOTAL = "0" Then sumTOTAL = ""

                Dim NGTOTAL As PdfPCell
                NGTOTAL = New PdfPCell(New Phrase("TOTAL(PCS.)", Font10))
                NGTOTAL.FixedHeight = 15.0F
                NGTOTAL.HorizontalAlignment = Element.ALIGN_CENTER
                Sub_table3.AddCell(NGTOTAL)

                Dim SumCellM1 As PdfPCell
                SumCellM1 = New PdfPCell(New Phrase(sumM1, Font10))
                SumCellM1.FixedHeight = 15.0F
                SumCellM1.HorizontalAlignment = Element.ALIGN_CENTER
                Sub_table3.AddCell(SumCellM1)

                Dim SumCellM2 As PdfPCell
                SumCellM2 = New PdfPCell(New Phrase(sumM2, Font10))
                SumCellM2.FixedHeight = 15.0F
                SumCellM2.HorizontalAlignment = Element.ALIGN_CENTER
                Sub_table3.AddCell(SumCellM2)

                Dim SumCellM3 As PdfPCell
                SumCellM3 = New PdfPCell(New Phrase(sumM3, Font10))
                SumCellM3.FixedHeight = 15.0F
                SumCellM3.HorizontalAlignment = Element.ALIGN_CENTER
                Sub_table3.AddCell(SumCellM3)

                Dim SumCellM4 As PdfPCell
                SumCellM4 = New PdfPCell(New Phrase(sumM4, Font10))
                SumCellM4.FixedHeight = 15.0F
                SumCellM4.HorizontalAlignment = Element.ALIGN_CENTER
                Sub_table3.AddCell(SumCellM4)

                Dim SumCellM5 As PdfPCell
                SumCellM5 = New PdfPCell(New Phrase(sumM5, Font10))
                SumCellM5.FixedHeight = 15.0F
                SumCellM5.HorizontalAlignment = Element.ALIGN_CENTER
                Sub_table3.AddCell(SumCellM5)

                Dim SumCellM6 As PdfPCell
                SumCellM6 = New PdfPCell(New Phrase(sumM6, Font10))
                SumCellM6.FixedHeight = 15.0F
                SumCellM6.HorizontalAlignment = Element.ALIGN_CENTER
                Sub_table3.AddCell(SumCellM6)

                Dim SumCellM7 As PdfPCell
                SumCellM7 = New PdfPCell(New Phrase(sumM7, Font10))
                SumCellM7.FixedHeight = 15.0F
                SumCellM7.HorizontalAlignment = Element.ALIGN_CENTER
                Sub_table3.AddCell(SumCellM7)

                Dim SumCellM8 As PdfPCell
                SumCellM8 = New PdfPCell(New Phrase(sumM8, Font10))
                SumCellM8.FixedHeight = 15.0F
                SumCellM8.HorizontalAlignment = Element.ALIGN_CENTER
                Sub_table3.AddCell(SumCellM8)

                Dim SumCellM9 As PdfPCell
                SumCellM9 = New PdfPCell(New Phrase(sumM9, Font10))
                SumCellM9.FixedHeight = 15.0F
                SumCellM9.HorizontalAlignment = Element.ALIGN_CENTER
                Sub_table3.AddCell(SumCellM9)

                Dim SumCellM10 As PdfPCell
                SumCellM10 = New PdfPCell(New Phrase(sumM10, Font10))
                SumCellM10.FixedHeight = 15.0F
                SumCellM10.HorizontalAlignment = Element.ALIGN_CENTER
                Sub_table3.AddCell(SumCellM10)

                Dim SumCellM11 As PdfPCell
                SumCellM11 = New PdfPCell(New Phrase(sumM11, Font10))
                SumCellM11.FixedHeight = 15.0F
                SumCellM11.HorizontalAlignment = Element.ALIGN_CENTER
                Sub_table3.AddCell(SumCellM11)

                Dim SumCellM12 As PdfPCell
                SumCellM12 = New PdfPCell(New Phrase(sumM12, Font10))
                SumCellM12.FixedHeight = 15.0F
                SumCellM12.HorizontalAlignment = Element.ALIGN_CENTER
                Sub_table3.AddCell(SumCellM12)

                Dim SumCellTOTAL As PdfPCell
                SumCellTOTAL = New PdfPCell(New Phrase(sumTOTAL, Font10))
                SumCellTOTAL.FixedHeight = 15.0F
                SumCellTOTAL.HorizontalAlignment = Element.ALIGN_CENTER
                Sub_table3.AddCell(SumCellTOTAL)


                'For j = 1 To 13
                '    Dim SumCell As PdfPCell
                '    SumCell = New PdfPCell(New Phrase("", Font10))
                '    SumCell.FixedHeight = 15.0F
                '    SumCell.HorizontalAlignment = Element.ALIGN_CENTER
                '    Sub_table3.AddCell(SumCell)
                'Next

#End Region
#Region "Sub4"
                'Sub4
                Dim Sub_table4 As PdfPTable = New PdfPTable(3)
                Sub_table4.TotalWidth = 500.0F

                '  Sub_table.WidthPercentage = 100
                Dim widSub4() As Integer = {10, 10, 10}
                Sub_table4.SetWidths(widSub4)
                '  Sub_table4.DefaultCell.Border = Rectangle.BOX
                '  Sub_table2.DefaultCell.FixedHeight = 200.0F

                'Dim imgFRAME As String
                'Dim imgGOOD As String
                'Dim imgNG1 As String
                'Dim imgNG2 As String
                'If imgFRAME <> Nothing Then

                'End If
                Dim PNG1 As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(imgFRAME)
                ' PNG1.ScalePercent(20.0F) 'ปรับขนาดรูป
                PNG1.ScaleAbsolute(480, 110)
                PNG1.Border = Rectangle.BOX
                PNG1.BorderWidth = 3
                PNG1.BorderColor = BaseColor.BLACK
                Dim Sub4Cell_1_header As PdfPCell = New PdfPCell(New Phrase("POSITION ON FRAME", Font12))
                Dim Sub4Cell_1 As PdfPCell = New PdfPCell(PNG1, False)



                Dim PNG2 As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(imgGOOD)
                ' PNG2.ScalePercent(60.0F) 'ปรับขนาดรูป
                PNG2.ScaleAbsolute(155, 155)
                PNG2.Border = Rectangle.BOX
                PNG2.BorderWidth = 3
                PNG2.BorderColor = BaseColor.BLACK
                '  PNG2.ScaleAbsolute(300, 100)
                Dim Sub4Cell_2_header As PdfPCell = New PdfPCell(New Phrase("GOOD PRODUCT", Font12))
                Dim Sub4Cell_2 As PdfPCell = New PdfPCell(PNG2, False)


                Dim PNG3 As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(imgNG1)
                '  PNG3.ScalePercent(60.0F) 'ปรับขนาดรูป
                PNG3.ScaleAbsolute(155, 155)
                PNG3.Border = Rectangle.BOX
                PNG3.BorderWidth = 3
                PNG3.BorderColor = BaseColor.BLACK
                ' PNG3.ScaleAbsolute(300, 100)
                Dim Sub4Cell_3_header As PdfPCell = New PdfPCell(New Phrase("NG PRODUCT", Font12))
                Dim Sub4Cell_3 As PdfPCell = New PdfPCell(PNG3, False)


                Dim PNG4 As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(imgNG2)
                '  PNG4.ScalePercent(60.0F) 'ปรับขนาดรูป
                PNG4.ScaleAbsolute(155, 155)
                ' PNG4.ScaleAbsolute(50, 50)
                PNG4.Border = Rectangle.BOX
                PNG4.BorderWidth = 3
                PNG4.BorderColor = BaseColor.BLACK
                ' PNG4.ScaleAbsolute(300, 100)
                Dim Sub4Cell_4_header As PdfPCell = New PdfPCell(New Phrase("NG PRODUCT", Font12))
                Dim Sub4Cell_4 As PdfPCell = New PdfPCell(PNG4, False)

                '  PNG.BorderWidth = Rectangle.BOX


                '   Sub4Cell_3.Border = PdfPCell.NO_BORDER
                Sub4Cell_1_header.HorizontalAlignment = Element.ALIGN_CENTER
                Sub4Cell_1_header.VerticalAlignment = Element.ALIGN_TOP
                Sub4Cell_2_header.HorizontalAlignment = Element.ALIGN_CENTER
                Sub4Cell_2_header.VerticalAlignment = Element.ALIGN_MIDDLE
                Sub4Cell_3_header.HorizontalAlignment = Element.ALIGN_CENTER
                Sub4Cell_3_header.VerticalAlignment = Element.ALIGN_MIDDLE
                Sub4Cell_4_header.HorizontalAlignment = Element.ALIGN_CENTER
                Sub4Cell_4_header.VerticalAlignment = Element.ALIGN_MIDDLE

                'image1
                Sub4Cell_1.HorizontalAlignment = Element.ALIGN_CENTER
                ' Sub4Cell_1.VerticalAlignment = Element.ALIGN_MIDDLE
                'image2
                Sub4Cell_2.HorizontalAlignment = Element.ALIGN_CENTER
                ' Sub4Cell_2.VerticalAlignment = Element.ALIGN_MIDDLE

                'image3
                Sub4Cell_3.HorizontalAlignment = Element.ALIGN_CENTER
                ' Sub4Cell_3.VerticalAlignment = Element.ALIGN_MIDDLE

                'image4
                Sub4Cell_4.HorizontalAlignment = Element.ALIGN_CENTER
                ' Sub4Cell_4.VerticalAlignment = Element.ALIGN_MIDDLE

                'Dim Sub4Cell_5 As PdfPCell = New PdfPCell(New Phrase("TOTAL NG : - PCS.", Font14))
                'Dim Sub4Cell_6 As PdfPCell = New PdfPCell(New Phrase("NG RATE : - %", Font14))
                'Dim Sub4Cell_7 As PdfPCell = New PdfPCell(New Phrase("DETAIL ABNORMAL: ", Font14))
                ' Sub4Cell_1.Rectangl
                '  Sub4Cell_1.BorderWidth = 1


                Sub4Cell_1_header.Colspan = 3
                Sub4Cell_1.Colspan = 3
                Sub4Cell_1.HorizontalAlignment = Element.ALIGN_CENTER
                'Sub4Cell_2.Colspan = 3
                'Sub4Cell_3.Colspan = 3
                '  Sub4Cell_7.Colspan = 3
                '  Sub2Cell_7.NoWrap = True
                '  Sub2Cell_7.Rowspan = 2
                'Sub2Cell_8.Rowspan = 2
                '  Sub2Cell_7.FixedHeight = 50.0F

                Sub4Cell_1_header.Border = 0
                Sub4Cell_1.Border = 0
                Sub4Cell_2_header.Border = 0
                Sub4Cell_3_header.Border = 0
                Sub4Cell_4_header.Border = 0
                Sub4Cell_2.Border = 0
                Sub4Cell_3.Border = 0
                Sub4Cell_4.Border = 0
                Sub4Cell_1.FixedHeight = 120
                Sub_table4.AddCell(Sub4Cell_1_header)
                Sub_table4.AddCell(Sub4Cell_1)
                Sub_table4.AddCell(Sub4Cell_2_header)
                Sub_table4.AddCell(Sub4Cell_3_header)
                Sub_table4.AddCell(Sub4Cell_4_header)
                Sub_table4.AddCell(Sub4Cell_2)
                Sub_table4.AddCell(Sub4Cell_3)
                Sub_table4.AddCell(Sub4Cell_4)



#End Region

                Dim Test1 As PdfPCell = New PdfPCell(New Phrase("H3"))
                Dim Test2 As PdfPCell = New PdfPCell(New Phrase("H3"))
                Dim Test3 As PdfPCell = New PdfPCell(New Phrase("H3"))
                Dim Test4 As PdfPCell = New PdfPCell(New Phrase("H3"))

            Dim MainCell_1 As PdfPCell = New PdfPCell(Sub_table1)
                Dim MainCell_2 As PdfPCell = New PdfPCell(Sub_table2)

                Dim MainCell_3 As PdfPCell = New PdfPCell(Sub_table3)
                Dim MainCell_4 As PdfPCell = New PdfPCell(Sub_table4)

                Dim CrLf As PdfPCell = New PdfPCell(New Phrase(vbCrLf))
                CrLf.Colspan = 2
                CrLf.Border = 0
                MainCell_1.FixedHeight = 125
                ' MainCell_3.FixedHeight = 120
                MainCell_3.Colspan = 2
                MainCell_4.Colspan = 2
                MainCell_4.FixedHeight = 350
                'Test1.Border = 0
                'Main_table.AddCell(Test1)
                'Main_table.AddCell(Test2)
                'Main_table.AddCell(Test3)
                'Main_table.AddCell(Test4)
                'MainCell_4.Border = 0
                Main_table.AddCell(CrLf)
                Main_table.AddCell(MainCell_1)
                '  
                Main_table.AddCell(MainCell_2)

                Main_table.AddCell(MainCell_3)
                Main_table.AddCell(MainCell_4)
                pdfDoc.Add(Main_table)
            '    pdfDoc.Add(Sub_table)
            'Dim Header1 As Paragraph = New Paragraph("ABNORMAL QUALITY INFORMATION OF DB/WB INSPECTIONxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx")
            'pdfDoc.Add(Header1)

            Dim content = pdfWrite.DirectContent
                'Dim pageBorderRect = New Rectangle(pdfDoc.PageSize)
                'pageBorderRect.Left += pdfDoc.LeftMargin
                'pageBorderRect.Right += pdfDoc.RightMargin
                'pageBorderRect.Top += pdfDoc.TopMargin
                'pageBorderRect.Bottom += pdfDoc.BottomMargin
                content.SetColorStroke(BaseColor.BLACK)
                content.SetLineWidth(1)
                content.Rectangle(0 + 20, 0 + 20, 595 - 40, 842 - 50)
                ' content.Rectangle(0 + 40, 0 + 40, 595 - 80, 842 - 120)
                '   content.Rectangle(pageBorderRect.Left, pageBorderRect.Bottom, pageBorderRect.Right, pageBorderRect.Top)
                content.Stroke()

                pdfDoc.Close()
                Process.Start(PDFname)


            Catch ex As Exception
                Dim trace = New Diagnostics.StackTrace(ex, True)
            Dim line As String = Strings.Right(trace.ToString, 5)
            Dim nombreMetodo As String = ""
            Dim Xcont As Integer = 0

            For Each sf As StackFrame In trace.GetFrames
                Xcont = Xcont + 1
                nombreMetodo = nombreMetodo & Xcont & "- " & sf.GetMethod().ReflectedType.ToString & " " & sf.GetMethod().Name & vbCrLf
            Next

            MessageBox.Show("Error en Linea number: " & line & ex.Message & vbCrLf & "Metodos : " & vbCrLf & nombreMetodo)

        End Try
    End Sub

    Public Function RowId(ByVal row As DataRow) As Integer
        Dim fieldInfo As Reflection.FieldInfo =
            row.GetType().GetField("_rowID",
                Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance)
        Dim value As Integer = CInt(fieldInfo.GetValue(row))
        Return value
    End Function
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.DialogResult = DialogResult.OK
    End Sub

    Dim imgFRAME As String = My.Application.Info.DirectoryPath & "\image\NoImage.png"
    Dim imgGOOD As String = My.Application.Info.DirectoryPath & "\image\NoImage.png"
    Dim imgNG1 As String = My.Application.Info.DirectoryPath & "\image\NoImage.png"
    Dim imgNG2 As String = My.Application.Info.DirectoryPath & "\image\NoImage.png"

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles pbFRAME.Click, pbGOOD.Click, pbNG1.Click, pbNG2.Click
        Dim fd As OpenFileDialog = New OpenFileDialog()
        Dim strFileName As String = ""
        Dim val As PictureBox = CType(sender, PictureBox)
        fd.Title = "Open File Dialog"
        fd.InitialDirectory = My.Application.Info.DirectoryPath & "\image"
        fd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            strFileName = fd.FileName


            'image PDF
            If val.Name = "pbFRAME" Then
                imgFRAME = strFileName

            End If

            If val.Name = "pbGOOD" Then
                imgGOOD = strFileName
            End If
            If val.Name = "pbNG1" Then
                imgNG1 = strFileName
            End If
            If val.Name = "pbNG2" Then
                imgNG2 = strFileName
            End If

            val.BackgroundImage = System.Drawing.Image.FromFile(strFileName)
        End If
    End Sub

    Private Sub AQI_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub
    Dim Detail As DataTable
    Public Sub Loaddata(PKG As String, Device As String, LotNo As String, Request1 As String, Remark1 As String, Request2 As String, Remark2 As String,
                        MCNo As String, InsTime As String, OPID As String, NG As String, NG_Tb As DataTable, Total As DataTable)
        lbPackage.Text = PKG
        lbDevice.Text = Device
        lbLotNo.Text = LotNo
        lbMode1.Text = Request1
        lbMode2.Text = Request2
        lbRemark1.Text = Remark1
        lbRemark2.Text = Remark2
        ' tbMCNo.Text = MCNo 
        lbDateInspection.Text = InsTime
        lbInspectorNo.Text = OPID
        'tbTotalNG.Text = NG
        DataGridView1.DataSource = NG_Tb
        Detail = New DataTable
        Detail = NG_Tb

        dgvTotal.DataSource = Total
        Process.Start("C:\Program Files\Common Files\Microsoft Shared\ink\TabTip.exe")
        Me.ShowDialog()

    End Sub

    Private Sub Label20_Click(sender As Object, e As EventArgs)
        Process.Start("C:\Program Files\Common Files\Microsoft Shared\ink\TabTip.exe")
        tbDetailAbnormal.Focus()
    End Sub

    Private Sub tbDetailAbnormal_TextChanged(sender As Object, e As EventArgs) Handles tbDetailAbnormal.TextChanged
        ' Label20.Text = tbDetailAbnormal.Text

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbMagazine.SelectedIndexChanged
        If cbMagazine.Text.ToUpper = "FULL LOT" Then
            tbFirstFrom.Text = "-"
            tbEndFrom.Text = "-"
            tbFirstFrom.Enabled = False
            tbEndFrom.Enabled = False
        ElseIf cbMagazine.Text.ToUpper = "PASS LOT" Then
            tbFirstFrom.Text = ""
            tbEndFrom.Text = ""
            tbFirstFrom.Enabled = True
            tbEndFrom.Enabled = True
        End If
    End Sub

    Private Sub cbProcess_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbProcess.SelectedIndexChanged
        Dim Date_Request As String = ""
        Dim RequestTime_tb As DBxDataSet.DBWBINSDataDataTable = New DBxDataSet.DBWBINSDataDataTable
        Dim RequestTime_ad As DBxDataSetTableAdapters.DBWBINSDataTableAdapter = New DBxDataSetTableAdapters.DBWBINSDataTableAdapter

        RequestTime_ad.FillRequestTimeAQI(RequestTime_tb, lbLotNo.Text, cbProcess.Text)
        For Each data As DBxDataSet.DBWBINSDataRow In RequestTime_tb
            Date_Request = data.ReqDate
        Next
        lbDateRequest.Text = Date_Request
    End Sub
End Class