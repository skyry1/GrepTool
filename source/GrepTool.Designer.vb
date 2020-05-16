<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class GrepTool
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Reference_Button = New System.Windows.Forms.Button()
        Me.Search_Button = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Folder_TextBox = New System.Windows.Forms.ComboBox()
        Me.Extension_TextBox = New System.Windows.Forms.ComboBox()
        Me.Keyword_TextBox = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Grep_CheckBox = New System.Windows.Forms.CheckBox()
        Me.SearchAllSubDirectories = New System.Windows.Forms.CheckBox()
        Me.CaseSensitivity = New System.Windows.Forms.CheckBox()
        Me.TabControl = New System.Windows.Forms.TabControl()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ファイルToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteTab_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.全タブを保存ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.設定ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.サクラエディタのパスを設定ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.履歴管理ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.フォントToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.セルをコピーするToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.フルパスをコピーするToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.エクスプローラーで開くToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.列を非表示にするToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.列を再表示するToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.現在のタブを保存ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Meiryo UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 40)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(147, 42)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "キーワード"
        '
        'Reference_Button
        '
        Me.Reference_Button.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Reference_Button.Font = New System.Drawing.Font("Meiryo UI", 8.142858!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Reference_Button.Location = New System.Drawing.Point(1089, 140)
        Me.Reference_Button.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Reference_Button.Name = "Reference_Button"
        Me.Reference_Button.Size = New System.Drawing.Size(50, 51)
        Me.Reference_Button.TabIndex = 14
        Me.Reference_Button.Text = "..."
        Me.Reference_Button.UseVisualStyleBackColor = True
        '
        'Search_Button
        '
        Me.Search_Button.Location = New System.Drawing.Point(442, 110)
        Me.Search_Button.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Search_Button.Name = "Search_Button"
        Me.Search_Button.Size = New System.Drawing.Size(114, 70)
        Me.Search_Button.TabIndex = 8
        Me.Search_Button.Text = "検索"
        Me.Search_Button.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Meiryo UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label2.Location = New System.Drawing.Point(40, 89)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(117, 42)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "拡張子"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Folder_TextBox)
        Me.GroupBox1.Controls.Add(Me.Extension_TextBox)
        Me.GroupBox1.Controls.Add(Me.Keyword_TextBox)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Reference_Button)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Meiryo UI", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(13, 44)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox1.Size = New System.Drawing.Size(1140, 191)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "検索条件"
        '
        'Folder_TextBox
        '
        Me.Folder_TextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Folder_TextBox.FormattingEnabled = True
        Me.Folder_TextBox.Location = New System.Drawing.Point(165, 140)
        Me.Folder_TextBox.Margin = New System.Windows.Forms.Padding(2)
        Me.Folder_TextBox.Name = "Folder_TextBox"
        Me.Folder_TextBox.Size = New System.Drawing.Size(919, 40)
        Me.Folder_TextBox.TabIndex = 3
        '
        'Extension_TextBox
        '
        Me.Extension_TextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Extension_TextBox.FormattingEnabled = True
        Me.Extension_TextBox.Location = New System.Drawing.Point(165, 89)
        Me.Extension_TextBox.Margin = New System.Windows.Forms.Padding(2)
        Me.Extension_TextBox.Name = "Extension_TextBox"
        Me.Extension_TextBox.Size = New System.Drawing.Size(967, 40)
        Me.Extension_TextBox.TabIndex = 2
        '
        'Keyword_TextBox
        '
        Me.Keyword_TextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Keyword_TextBox.FormattingEnabled = True
        Me.Keyword_TextBox.Location = New System.Drawing.Point(165, 40)
        Me.Keyword_TextBox.Margin = New System.Windows.Forms.Padding(2)
        Me.Keyword_TextBox.Name = "Keyword_TextBox"
        Me.Keyword_TextBox.Size = New System.Drawing.Size(967, 40)
        Me.Keyword_TextBox.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Meiryo UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Label3.Location = New System.Drawing.Point(44, 142)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 42)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "フォルダ"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Grep_CheckBox)
        Me.GroupBox2.Controls.Add(Me.SearchAllSubDirectories)
        Me.GroupBox2.Controls.Add(Me.CaseSensitivity)
        Me.GroupBox2.Controls.Add(Me.Search_Button)
        Me.GroupBox2.Font = New System.Drawing.Font("Meiryo UI", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(1161, 44)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.GroupBox2.Size = New System.Drawing.Size(563, 191)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "検索オプション"
        '
        'Grep_CheckBox
        '
        Me.Grep_CheckBox.AutoSize = True
        Me.Grep_CheckBox.Font = New System.Drawing.Font("Meiryo UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Grep_CheckBox.Location = New System.Drawing.Point(31, 142)
        Me.Grep_CheckBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Grep_CheckBox.Name = "Grep_CheckBox"
        Me.Grep_CheckBox.Size = New System.Drawing.Size(153, 40)
        Me.Grep_CheckBox.TabIndex = 6
        Me.Grep_CheckBox.Text = "正規表現"
        Me.Grep_CheckBox.UseVisualStyleBackColor = True
        '
        'SearchAllSubDirectories
        '
        Me.SearchAllSubDirectories.AutoSize = True
        Me.SearchAllSubDirectories.Checked = True
        Me.SearchAllSubDirectories.CheckState = System.Windows.Forms.CheckState.Checked
        Me.SearchAllSubDirectories.Font = New System.Drawing.Font("Meiryo UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.SearchAllSubDirectories.Location = New System.Drawing.Point(31, 89)
        Me.SearchAllSubDirectories.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.SearchAllSubDirectories.Name = "SearchAllSubDirectories"
        Me.SearchAllSubDirectories.Size = New System.Drawing.Size(237, 40)
        Me.SearchAllSubDirectories.TabIndex = 5
        Me.SearchAllSubDirectories.Text = "サブフォルダを含む"
        Me.SearchAllSubDirectories.UseVisualStyleBackColor = True
        '
        'CaseSensitivity
        '
        Me.CaseSensitivity.AutoSize = True
        Me.CaseSensitivity.Font = New System.Drawing.Font("Meiryo UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.CaseSensitivity.Location = New System.Drawing.Point(31, 40)
        Me.CaseSensitivity.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CaseSensitivity.Name = "CaseSensitivity"
        Me.CaseSensitivity.Size = New System.Drawing.Size(349, 40)
        Me.CaseSensitivity.TabIndex = 4
        Me.CaseSensitivity.Text = "大文字と小文字を区別する"
        Me.CaseSensitivity.UseVisualStyleBackColor = True
        '
        'TabControl
        '
        Me.TabControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl.Font = New System.Drawing.Font("Meiryo UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.TabControl.Location = New System.Drawing.Point(13, 243)
        Me.TabControl.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(1711, 798)
        Me.TabControl.TabIndex = 12
        Me.TabControl.Visible = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.GripMargin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(28, 28)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ファイルToolStripMenuItem, Me.設定ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1736, 38)
        Me.MenuStrip1.TabIndex = 13
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ファイルToolStripMenuItem
        '
        Me.ファイルToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteTab_ToolStripMenuItem, Me.全タブを保存ToolStripMenuItem, Me.現在のタブを保存ToolStripMenuItem})
        Me.ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem"
        Me.ファイルToolStripMenuItem.Size = New System.Drawing.Size(112, 34)
        Me.ファイルToolStripMenuItem.Text = "ファイル(F)"
        '
        'DeleteTab_ToolStripMenuItem
        '
        Me.DeleteTab_ToolStripMenuItem.Name = "DeleteTab_ToolStripMenuItem"
        Me.DeleteTab_ToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.W), System.Windows.Forms.Keys)
        Me.DeleteTab_ToolStripMenuItem.Size = New System.Drawing.Size(331, 40)
        Me.DeleteTab_ToolStripMenuItem.Text = "このタブを削除"
        '
        '全タブを保存ToolStripMenuItem
        '
        Me.全タブを保存ToolStripMenuItem.Name = "全タブを保存ToolStripMenuItem"
        Me.全タブを保存ToolStripMenuItem.Size = New System.Drawing.Size(331, 40)
        Me.全タブを保存ToolStripMenuItem.Text = "全タブを保存"
        '
        '設定ToolStripMenuItem
        '
        Me.設定ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.サクラエディタのパスを設定ToolStripMenuItem, Me.履歴管理ToolStripMenuItem, Me.フォントToolStripMenuItem})
        Me.設定ToolStripMenuItem.Name = "設定ToolStripMenuItem"
        Me.設定ToolStripMenuItem.Size = New System.Drawing.Size(73, 34)
        Me.設定ToolStripMenuItem.Text = "設定"
        '
        'サクラエディタのパスを設定ToolStripMenuItem
        '
        Me.サクラエディタのパスを設定ToolStripMenuItem.Name = "サクラエディタのパスを設定ToolStripMenuItem"
        Me.サクラエディタのパスを設定ToolStripMenuItem.Size = New System.Drawing.Size(347, 40)
        Me.サクラエディタのパスを設定ToolStripMenuItem.Text = "サクラエディタのパスを設定"
        '
        '履歴管理ToolStripMenuItem
        '
        Me.履歴管理ToolStripMenuItem.Name = "履歴管理ToolStripMenuItem"
        Me.履歴管理ToolStripMenuItem.Size = New System.Drawing.Size(347, 40)
        Me.履歴管理ToolStripMenuItem.Text = "履歴管理"
        '
        'フォントToolStripMenuItem
        '
        Me.フォントToolStripMenuItem.Name = "フォントToolStripMenuItem"
        Me.フォントToolStripMenuItem.Size = New System.Drawing.Size(347, 40)
        Me.フォントToolStripMenuItem.Text = "フォント"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(28, 28)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.セルをコピーするToolStripMenuItem, Me.フルパスをコピーするToolStripMenuItem, Me.エクスプローラーで開くToolStripMenuItem, Me.列を非表示にするToolStripMenuItem, Me.列を再表示するToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(260, 184)
        '
        'セルをコピーするToolStripMenuItem
        '
        Me.セルをコピーするToolStripMenuItem.Name = "セルをコピーするToolStripMenuItem"
        Me.セルをコピーするToolStripMenuItem.Size = New System.Drawing.Size(259, 36)
        Me.セルをコピーするToolStripMenuItem.Text = "セルをコピーする"
        '
        'フルパスをコピーするToolStripMenuItem
        '
        Me.フルパスをコピーするToolStripMenuItem.Name = "フルパスをコピーするToolStripMenuItem"
        Me.フルパスをコピーするToolStripMenuItem.Size = New System.Drawing.Size(259, 36)
        Me.フルパスをコピーするToolStripMenuItem.Text = "フルパスをコピーする"
        '
        'エクスプローラーで開くToolStripMenuItem
        '
        Me.エクスプローラーで開くToolStripMenuItem.Name = "エクスプローラーで開くToolStripMenuItem"
        Me.エクスプローラーで開くToolStripMenuItem.Size = New System.Drawing.Size(259, 36)
        Me.エクスプローラーで開くToolStripMenuItem.Text = "エクスプローラーで開く"
        '
        '列を非表示にするToolStripMenuItem
        '
        Me.列を非表示にするToolStripMenuItem.Name = "列を非表示にするToolStripMenuItem"
        Me.列を非表示にするToolStripMenuItem.Size = New System.Drawing.Size(259, 36)
        Me.列を非表示にするToolStripMenuItem.Text = "列を非表示にする"
        '
        '列を再表示するToolStripMenuItem
        '
        Me.列を再表示するToolStripMenuItem.Name = "列を再表示するToolStripMenuItem"
        Me.列を再表示するToolStripMenuItem.Size = New System.Drawing.Size(259, 36)
        Me.列を再表示するToolStripMenuItem.Text = "列を再表示する"
        '
        '現在のタブを保存ToolStripMenuItem
        '
        Me.現在のタブを保存ToolStripMenuItem.Name = "現在のタブを保存ToolStripMenuItem"
        Me.現在のタブを保存ToolStripMenuItem.Size = New System.Drawing.Size(331, 40)
        Me.現在のタブを保存ToolStripMenuItem.Text = "現在のタブを保存"
        '
        'GrepTool
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1736, 1055)
        Me.Controls.Add(Me.TabControl)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "GrepTool"
        Me.Text = "GrepTool"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Reference_Button As Button
    Friend WithEvents Search_Button As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents SearchAllSubDirectories As CheckBox
    Friend WithEvents CaseSensitivity As CheckBox
    Friend WithEvents Keyword_TextBox As ComboBox
    Friend WithEvents Folder_TextBox As ComboBox
    Friend WithEvents Extension_TextBox As ComboBox
    Friend WithEvents TabControl As TabControl
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ファイルToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteTab_ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents セルをコピーするToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents フルパスをコピーするToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents エクスプローラーで開くToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Grep_CheckBox As CheckBox
    Friend WithEvents 全タブを保存ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 設定ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents サクラエディタのパスを設定ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 履歴管理ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents フォントToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 列を非表示にするToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 列を再表示するToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 現在のタブを保存ToolStripMenuItem As ToolStripMenuItem
End Class
