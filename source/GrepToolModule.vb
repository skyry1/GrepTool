Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions
Imports DataGridViewAutoFilter
Imports Microsoft.Office.Interop

Module GrepToolModule

    Public Function CreateDataGridView(contextMenuStrip As ContextMenuStrip, grepToolDataGridViewName As String, info As GrepInfo)

        'DataGridView定義
        Dim dgv As New GrepToolDataGridView With {
            .Name = grepToolDataGridViewName,
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            .AllowUserToAddRows = False,
            .[ReadOnly] = True,
            .AllowUserToResizeRows = False,
            .ContextMenuStrip = contextMenuStrip,
            .Font = My.Settings.Font
        }

        'テーブル作成
        Dim dt = CreateDataTableHeader(info.Keyword)
        If info.Grep_CheckBox Then
            dt = CreateDataTableGrep(dt, info)
        Else
            dt = CreateDataTable(dt, info)
        End If
        Dim dataSource As New BindingSource(dt, Nothing)
        dgv.DataSource = dataSource

        For Each col As DataGridViewColumn In dgv.Columns
            col.HeaderCell = New DataGridViewAutoFilterColumnHeaderCell(col.HeaderCell)
        Next

        '列幅を自動調整
        dgv.Dock = DockStyle.Fill
        dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgv.RowHeadersWidthSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        Return dgv
    End Function

    Private Function CreateDataTableHeader(tableName As String)

        'DataTable作成
        Dim dt As New DataTable With {
            .TableName = tableName
        }
        dt.Columns.Add(New DataColumn("FOLDER", GetType(String)))
        dt.Columns.Add(New DataColumn("FILE", GetType(String)))
        dt.Columns.Add(New DataColumn("ROW", GetType(Integer)))
        dt.Columns.Add(New DataColumn("COLUMN", GetType(Integer)))
        dt.Columns.Add(New DataColumn("LINE", GetType(String)))
        Return dt
    End Function

    Private Function CreateDataTableGrep(dt As DataTable, info As GrepInfo)

        '正規表現のオプションを設定
        Dim opts As Text.RegularExpressions.RegexOptions = Text.RegularExpressions.RegexOptions.None
        If Not info.CaseSensitivityChecked Then
            opts = opts Or Text.RegularExpressions.RegexOptions.IgnoreCase
        End If
        Dim reg As New Text.RegularExpressions.Regex(info.Keyword, opts)

        'フォルダ内にあるファイルを取得
        Dim dir As New DirectoryInfo(info.Folder)
        Dim files As FileInfo()

        '拡張子ごとに検索を行う
        For Each extension As String In ((info.Extension).Replace(" ", "")).Split(",")
            If info.SearchAllSubDirectoriesChecked Then
                files = dir.GetFiles(extension, SearchOption.AllDirectories)
            Else
                files = dir.GetFiles(extension)
            End If

            For Each file As FileInfo In files
                '一つずつファイルを調べる
                'ファイルを読み込む
                Dim strm As StreamReader = Nothing
                Try
                    strm = New StreamReader(file.FullName, Text.Encoding.Default, True)
                    Dim row As Integer = 0
                    Dim column As Integer
                    While (strm.Peek() >= 0)
                        Dim line As String = strm.ReadLine
                        column = reg.Match(line).Index
                        '見つかったらレコードを追加する
                        If column > 0 Then
                            Dim dr As DataRow = dt.NewRow()
                            dr("FOLDER") = Path.GetDirectoryName(file.FullName)
                            dr("FILE") = Path.GetFileName(file.FullName)
                            dr("ROW") = row + 1
                            dr("COLUMN") = column + 1
                            dr("LINE") = line
                            dt.Rows.Add(dr)
                        End If
                        row += 1
                    End While
                Finally
                    strm.Close()
                End Try
            Next file
        Next
        Return dt
    End Function

    Private Function CreateDataTable(dt As DataTable, info As GrepInfo)

        'サブフォルダを含める
        Dim searchOption As SearchOption = FileIO.SearchOption.SearchTopLevelOnly
        If (info.SearchAllSubDirectoriesChecked) Then
            searchOption = FileIO.SearchOption.SearchAllSubDirectories
        End If

        '検索拡張子リスト
        Dim extentionList = ((info.Extension).Replace(" ", "")).Split(",")

        '対象のファイルを探す
        Dim files As ObjectModel.ReadOnlyCollection(Of String)
        files = My.Computer.FileSystem.FindInFiles(info.Folder, info.Keyword, True, searchOption, extentionList)

        'ファイルの内容を検査
        For Each file_path As String In files
            Dim row As Integer = 0
            Dim column As Integer
            Dim line As String

            'ファイルを開く
            Dim fs As New FileStream(file_path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
            Dim file As New StreamReader(fs, Text.Encoding.Default)

            'ファイルの中身を確認する
            While (file.Peek() >= 0)
                line = file.ReadLine
                '大文字小文字を区別する
                If (info.CaseSensitivityChecked) Then
                    column = line.IndexOf(info.Keyword)
                Else
                    '大文字小文字を区別しない
                    column = line.IndexOf(info.Keyword, StringComparison.OrdinalIgnoreCase)
                End If
                '見つかったらレコードを追加する
                If column > -1 Then
                    Dim dr As DataRow = dt.NewRow()
                    dr("FOLDER") = Path.GetDirectoryName(file_path)
                    dr("FILE") = Path.GetFileName(file_path)
                    dr("ROW") = row + 1
                    dr("COLUMN") = column + 1
                    dr("LINE") = line
                    dt.Rows.Add(dr)
                End If
                column = 0
                row += 1
            End While
            file.Close()
        Next
        Return dt
    End Function

    Public Function ExtractionDataGridView(dgv As GrepToolDataGridView)
        'ヘッダー作成
        Dim headerRecord As String = ""
        For i As Integer = 0 To (dgv.ColumnCount - 1)
            headerRecord += dgv.Columns(i).HeaderCell.Value.ToString
            If i <> dgv.ColumnCount - 1 Then
                headerRecord += ","
            End If
        Next

        'レコード作成
        Dim records(dgv.RowCount) As String
        records(0) = headerRecord
        For i As Integer = 0 To (dgv.RowCount - 1)
            Dim insertNum = i + 1
            For j As Integer = 0 To (dgv.ColumnCount - 1)
                records(insertNum) += dgv.Rows(i).Cells(j).Value.ToString
                If j <> dgv.ColumnCount - 1 Then
                    records(insertNum) += ","
                End If
            Next
        Next

        Return records
    End Function

    Public Sub OutputCsvFile(fileName As String, records() As String, info As GrepInfo)

        Dim sw As StreamWriter = Nothing
        Try
            'CSVファイル書込に使うEncoding
            Dim enc As Text.Encoding = Text.Encoding.GetEncoding("Shift_JIS")
            '書き込むファイルを開く
            sw = New StreamWriter(fileName, False, enc)
            For Each record As String In records
                sw.Write(record + vbCrLf)
            Next
            sw.Write("キーワード：" + """" + info.Keyword + """" + vbCrLf)
            sw.Write("拡張子：" + """" + info.Extension + """" + vbCrLf)
            sw.Write("フォルダ：" + """" + info.Folder + """" + vbCrLf)
            sw.Write((records.Length - 1).ToString + "件が検出されました。")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If sw IsNot Nothing Then
                sw.Close()
            End If
        End Try
    End Sub

    Public Sub OutputExcelFile(fileName As String, dgv As GrepToolDataGridView, info As GrepInfo)

        Dim app As Excel.Application = Nothing
        Dim book As Excel.Workbook = Nothing
        Dim sheet As Excel.Worksheet = Nothing

        Try
            'シートの作成
            app = New Excel.Application()
            app.Workbooks.Add()
            app.DisplayAlerts = False
            book = app.Workbooks(1)
            sheet = CType(book.Worksheets(1), Excel.Worksheet)

            'シート名を設定する
            If Regex.IsMatch(info.Keyword, "履歴") Then
                sheet.Name = "GrepResult"
            ElseIf Len(info.Keyword) = 0 Then
                sheet.Name = "GrepResult"
            ElseIf Regex.IsMatch(info.Keyword, "(\*|\\|\/|\:|\[|\]|\?)") Then
                sheet.Name = "GrepResult"
            Else
                sheet.Name = info.Keyword
            End If

            'ヘッダ部を作成
            For i As Integer = 0 To dgv.ColumnCount - 1
                sheet.Cells(1, i + 1) = dgv.Columns(i).HeaderCell.Value
            Next
            'データ部を作成
            For row As Integer = 0 To dgv.RowCount - 1
                For column As Integer = 0 To dgv.ColumnCount - 1
                    sheet.Cells(row + 2, column + 1) = dgv.Rows(row).Cells(column).Value.ToString
                Next
            Next

            '保存する
            book.SaveAs(fileName)

        Catch ex As Exception
            Throw ex
        Finally
            'オブジェクト解放
            app.Quit()
            Marshal.ReleaseComObject(sheet)
            Marshal.ReleaseComObject(book)
            Marshal.ReleaseComObject(app)
        End Try
    End Sub

    Public Sub WriteSakuraEditorPath()
        Dim ofd As New OpenFileDialog With {
            .FileName = "sakura.exe",
            .InitialDirectory = "C:\",
            .Title = "sakura.exeを選択してください",
            .RestoreDirectory = True,
            .CheckFileExists = True,
            .CheckPathExists = True
        }

        'ダイアログを表示する
        If ofd.ShowDialog() = DialogResult.OK Then
            My.Settings.SakuraEditorPath = ofd.FileName
            My.Settings.Save()
        End If
    End Sub
End Module
