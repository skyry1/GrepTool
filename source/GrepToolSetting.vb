Public Class GrepToolSetting
    Private Sub GrepToolSetting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = My.Settings.Keyword
        TextBox2.Text = My.Settings.Extension
        TextBox3.Text = My.Settings.Folder
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        My.Settings.Keyword = TextBox1.Text
        My.Settings.Extension = TextBox2.Text
        My.Settings.Folder = TextBox3.Text
        My.Settings.Save()

        MsgBox("履歴を変更しました。")
        Me.Close()
    End Sub
End Class