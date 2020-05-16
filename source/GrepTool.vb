Imports System.IO

Public Class GrepTool

    'DataGridView名称
    Private Const _DATA_GRID_VIEW_NAME As String = "dgv"

    Private _Searching As Boolean = False

    Private Sub GrepTool_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Init()
    End Sub

    Private Sub Init()
        Save_ToolStripMenuItem.Visible = False
        DeleteTab_ToolStripMenuItem.Visible = False
        Call ReadConfig()
    End Sub

    Private Sub Save_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Save_ToolStripMenuItem.Click
        Dim sfd As New SaveFileDialog With {
            .FileName = "GrepResult.xlsx",
            .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),
            .Filter = "CSVファイル(*.csv)|*.csv|EXCELファイル(*.xlsx)|*.xlsx",
            .FilterIndex = 2,
            .Title = "保存先のファイルを選択してください",
            .RestoreDirectory = True,
            .OverwritePrompt = True,
            .CheckPathExists = True
        }

        'ダイアログを表示する
        If sfd.ShowDialog() = DialogResult.OK Then
            'DataGridViewを定義
            Dim dgv As GrepToolDataGridView
            dgv = DirectCast(TabControl.SelectedTab.Controls.Find(_DATA_GRID_VIEW_NAME, True)(0), GrepToolDataGridView)

            Dim info As GrepInfo = New GrepInfo(Keyword_TextBox.Text, Extension_TextBox.Text, Folder_TextBox.Text)
            If sfd.FilterIndex = 1 Then
                Dim records = ExtractionDataGridView(dgv)
                OutputCsvFile(sfd.FileName, records, info)
            Else
                OutputExcelFile(sfd.FileName, dgv, info)
            End If
        End If
    End Sub

    Private Sub 全タブを保存ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 全タブを保存ToolStripMenuItem.Click
        Dim sfd As New SaveFileDialog With {
            .FileName = "GrepResult.xlsx",
            .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),
            .Filter = "EXCELファイル(*.xlsx)|*.xlsx",
            .FilterIndex = 1,
            .Title = "保存先のファイルを選択してください",
            .RestoreDirectory = True,
            .OverwritePrompt = True,
            .CheckPathExists = True
        }

        'ダイアログを表示する
        If sfd.ShowDialog() = DialogResult.OK Then
            'DataGridViewを定義
            Dim dgv As GrepToolDataGridView
            dgv = DirectCast(TabControl.SelectedTab.Controls.Find(_DATA_GRID_VIEW_NAME, True)(0), GrepToolDataGridView)

            Dim info As GrepInfo = New GrepInfo(Keyword_TextBox.Text, Extension_TextBox.Text, Folder_TextBox.Text)
            OutputExcelFile(sfd.FileName, dgv, info)
        End If
    End Sub

    Private Sub DeleteTab_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteTab_ToolStripMenuItem.Click

        If TabControl.Controls.Count <> 0 Then
            TabControl.TabPages.Remove(TabControl.SelectedTab)
        End If

        If TabControl.Controls.Count = 0 Then
            Save_ToolStripMenuItem.Visible = False
            DeleteTab_ToolStripMenuItem.Visible = False
        End If
    End Sub


    Private Sub Reference_Button_Click(sender As Object, e As EventArgs) Handles Reference_Button.Click

        Dim filePath As String = "C:"
        If (Folder_TextBox.Text <> "") Then
            filePath = Folder_TextBox.Text
        End If

        Dim fbd As New FolderBrowserDialog With {
            .Description = "フォルダを指定してください。",
            .SelectedPath = filePath,
            .ShowNewFolderButton = True
        }

        If fbd.ShowDialog(Me) = DialogResult.OK Then
            Folder_TextBox.Text = fbd.SelectedPath
        End If
    End Sub

    Private Sub Search_Button_Click(sender As Object, e As EventArgs) Handles Search_Button.Click
        Call GrepAction()
    End Sub

    Private Sub GrepAction()
        If _Searching Then
            Return
        End If

        If Folder_TextBox.Text.Equals("") Or Keyword_TextBox.Text.Equals("") Or Extension_TextBox.Text.Equals("") Then
            MsgBox("Grep情報が不足しています。")
            Return
        End If

        If Not Directory.Exists(Folder_TextBox.Text) Then
            MsgBox("フォルダが存在しません。")
            Return
        End If

        If Keyword_TextBox.Text.Length = 1 Then
            If MsgBox("1文字で検索を行うと処理に時間がかかります。" + vbCrLf + "処理を続けます。", vbYesNo + vbQuestion + vbDefaultButton2) = vbNo Then
                Return
            End If
        End If

        Cursor.Current = Cursors.WaitCursor
        Me.SuspendLayout()
        _Searching = True
        Call AddTextBoxItems()
        Call CreateTabPage()
        Save_ToolStripMenuItem.Visible = True
        DeleteTab_ToolStripMenuItem.Visible = True
        _Searching = False
        Me.ResumeLayout()
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub ReadConfig()

        For Each item As String In My.Settings.Keyword.Split(vbTab)
            Keyword_TextBox.Items.Add(item)
        Next
        For Each item As String In My.Settings.Extension.Split(vbTab)
            Extension_TextBox.Items.Add(item)
        Next
        For Each item As String In My.Settings.Folder.Split(vbTab)
            Folder_TextBox.Items.Add(item)
        Next
        Keyword_TextBox.SelectedIndex = Keyword_TextBox.Items.Count - 1
        Extension_TextBox.SelectedIndex = Extension_TextBox.Items.Count - 1
        Folder_TextBox.SelectedIndex = Folder_TextBox.Items.Count - 1
        Grep_CheckBox.Checked = My.Settings.RegularExpression
        SearchAllSubDirectories.Checked = My.Settings.IncludeSubfolders
        CaseSensitivity.Checked = My.Settings.CaseSensitive
    End Sub

    Private Sub AddTextBoxItems()

        Dim keyword As String = Keyword_TextBox.Text
        Dim extension As String = Extension_TextBox.Text
        Dim folder As String = Folder_TextBox.Text

        If Not Keyword_TextBox.Items.Contains(Keyword_TextBox.Text) Then
            Keyword_TextBox.Items.Insert(0, Keyword_TextBox.Text)
            If Not My.Settings.Keyword.Equals(String.Empty) Then
                My.Settings.Keyword = My.Settings.Keyword & vbTab & keyword
            End If
        End If

        If Not Extension_TextBox.Items.Contains(Extension_TextBox.Text) Then
            Extension_TextBox.Items.Insert(0, Extension_TextBox.Text)
            If Not My.Settings.Extension.Equals(String.Empty) Then
                My.Settings.Extension = My.Settings.Extension & vbTab & extension
            End If
        End If

        If Not Folder_TextBox.Items.Contains(Folder_TextBox.Text) Then
            Folder_TextBox.Items.Insert(0, Folder_TextBox.Text)
            If Not My.Settings.Folder.Equals(String.Empty) Then
                My.Settings.Folder = My.Settings.Folder & vbTab & folder
            End If
        End If

        My.Settings.RegularExpression = Grep_CheckBox.Checked
        My.Settings.IncludeSubfolders = SearchAllSubDirectories.Checked
        My.Settings.CaseSensitive = CaseSensitivity.Checked

        My.Settings.Save()
    End Sub

    Private Sub CreateTabPage()

        'ToolTipText作成
        Dim toolTipText As String
        toolTipText = "キーワード:" + Keyword_TextBox.Text + vbCrLf + "拡張子:" + Extension_TextBox.Text + vbCrLf + "フォルダ:" + Folder_TextBox.Text
        If Grep_CheckBox.Checked Then
            toolTipText += vbCrLf + "正規表現"
        End If
        If SearchAllSubDirectories.Checked Then
            toolTipText += vbCrLf + "サブフォルダを含む"
        Else
            toolTipText += vbCrLf + "サブフォルダを含まない"
        End If
        If CaseSensitivity.Checked Then
            toolTipText += vbCrLf + "大文字と小文字を区別する"
        Else
            toolTipText += vbCrLf + "大文字と小文字を区別しない"
        End If


        '追加するタブを作成
        Dim newTab As New TabPage With {
            .Text = Keyword_TextBox.Text,
            .ToolTipText = toolTipText
        }
        Dim info As GrepInfo = New GrepInfo(Keyword_TextBox.Text, Extension_TextBox.Text, Folder_TextBox.Text, SearchAllSubDirectories.Checked, CaseSensitivity.Checked, Grep_CheckBox.Checked)
        newTab.Controls.Add(CreateDataGridView(Me.ContextMenuStrip1, _DATA_GRID_VIEW_NAME, info))
        'タブページを追加
        TabControl.Visible = True
        TabControl.ShowToolTips = True
        TabControl.TabPages.Add(newTab)
        TabControl.SelectedTab = newTab
    End Sub

    Private Sub TextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Keyword_TextBox.KeyPress, Extension_TextBox.KeyPress, Folder_TextBox.KeyPress
        If e.KeyChar = Chr(13) Then
            Call GrepAction()
        End If
    End Sub

    Private Sub セルをコピーするToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles セルをコピーするToolStripMenuItem.Click
        Dim dgv As GrepToolDataGridView = DirectCast(TabControl.SelectedTab.Controls.Find(_DATA_GRID_VIEW_NAME, True)(0), GrepToolDataGridView)
        Clipboard.SetText(dgv.CurrentCell.Value)
    End Sub

    Private Sub フルパスをコピーするToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles フルパスをコピーするToolStripMenuItem.Click
        Dim dgv As GrepToolDataGridView = DirectCast(TabControl.SelectedTab.Controls.Find(_DATA_GRID_VIEW_NAME, True)(0), GrepToolDataGridView)
        Dim fullPath As String = dgv.CurrentRow.Cells(0).Value + "\" + dgv.CurrentRow.Cells(1).Value
        Clipboard.SetText(fullPath)
    End Sub

    Private Sub エクスプローラーで開くToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles エクスプローラーで開くToolStripMenuItem.Click
        Dim dgv As GrepToolDataGridView = DirectCast(TabControl.SelectedTab.Controls.Find(_DATA_GRID_VIEW_NAME, True)(0), GrepToolDataGridView)
        Dim folderPath = dgv.CurrentRow.Cells(0).Value
        Process.Start(folderPath)
    End Sub

    Private Sub サクラエディタのパスを設定ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles サクラエディタのパスを設定ToolStripMenuItem.Click
        WriteSakuraEditorPath()
    End Sub

    Private Sub 履歴管理ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 履歴管理ToolStripMenuItem.Click
        Dim form As New GrepToolSetting()
        form.Show()
    End Sub

    Private Sub フォントToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles フォントToolStripMenuItem.Click

        Dim fd As New FontDialog
        Try
            fd.Font = DirectCast(TabControl.SelectedTab.Controls.Find(_DATA_GRID_VIEW_NAME, True)(0), GrepToolDataGridView).DefaultCellStyle.Font
        Catch ex As Exception
            fd.Font = My.Settings.Font
        End Try

        If fd.ShowDialog <> DialogResult.Cancel Then
            My.Settings.Font = fd.Font
            My.Settings.Save()
        End If

        Try
            DirectCast(TabControl.SelectedTab.Controls.Find(_DATA_GRID_VIEW_NAME, True)(0), GrepToolDataGridView).DefaultCellStyle.Font = My.Settings.Font
        Catch ex As Exception

        End Try
    End Sub

    Private Sub 列を非表示にするToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 列を非表示にするToolStripMenuItem.Click
        Dim dgv As GrepToolDataGridView = DirectCast(TabControl.SelectedTab.Controls.Find(_DATA_GRID_VIEW_NAME, True)(0), GrepToolDataGridView)
        Dim currentColumn As Integer = dgv.CurrentCell.ColumnIndex
        DirectCast(TabControl.SelectedTab.Controls.Find(_DATA_GRID_VIEW_NAME, True)(0), GrepToolDataGridView).Columns(currentColumn).Visible = False
    End Sub

    Private Sub 列を再表示するToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 列を再表示するToolStripMenuItem.Click
        Dim dgv As GrepToolDataGridView = DirectCast(TabControl.SelectedTab.Controls.Find(_DATA_GRID_VIEW_NAME, True)(0), GrepToolDataGridView)
        For i As Integer = 0 To dgv.Columns.Count - 1
            DirectCast(TabControl.SelectedTab.Controls.Find(_DATA_GRID_VIEW_NAME, True)(0), GrepToolDataGridView).Columns(i).Visible = True
        Next i
    End Sub
End Class