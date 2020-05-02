Imports DataGridViewAutoFilter

Public Class GrepToolDataGridView
    Inherits DataGridView

    Dim filterStatusLabel As New ToolStripStatusLabel()
    Dim WithEvents showAllLabel As New ToolStripStatusLabel("Show &All")

    Private Sub GrepToolDataGridView_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles Me.CellDoubleClick

        Dim rowIndex = CurrentCell.RowIndex
        Dim filePath As String
        filePath = Rows(rowIndex).Cells(0).Value.ToString + "\" + Rows(rowIndex).Cells(1).Value.ToString

        Dim command As String
        command = """" + filePath + """" + " -X=" + Rows(rowIndex).Cells(3).Value.ToString + " -Y=" + Rows(rowIndex).Cells(2).Value.ToString

        Try
            Process.Start(My.Settings.SakuraEditorPath, command)
        Catch ex As Exception
            Process.Start("""" + filePath + """")
        Finally
            Console.WriteLine(command)
        End Try
    End Sub

    Private Sub GrepToolDataGridView_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles Me.CellMouseDown

        '0指定なら処理しない
        If (e.RowIndex < 0 Or e.ColumnIndex < 0) Then
            Return
        End If

        '右クリック時のみ処理を実行します。
        If e.Button = Windows.Forms.MouseButtons.Right Then
            ClearSelection()
            Rows(e.RowIndex).Selected = True
            Columns(e.ColumnIndex).Selected = True
            CurrentCell = Me(e.ColumnIndex, e.RowIndex)
        End If
    End Sub

    Private Sub GrepToolDataGridView_CellPainting(ByVal sender As Object,
            ByVal e As DataGridViewCellPaintingEventArgs) _
            Handles Me.CellPainting
        '列ヘッダーかどうか調べる
        If e.ColumnIndex < 0 And e.RowIndex >= 0 Then
            'セルを描画する
            e.Paint(e.ClipBounds, DataGridViewPaintParts.All)

            '行番号を描画する範囲を決定する
            'e.AdvancedBorderStyleやe.CellStyle.Paddingは無視しています
            Dim indexRect As Rectangle = e.CellBounds
            indexRect.Inflate(-2, -2)
            '行番号を描画する
            TextRenderer.DrawText(e.Graphics,
                (e.RowIndex + 1).ToString(),
                e.CellStyle.Font,
                indexRect,
                e.CellStyle.ForeColor,
                TextFormatFlags.Right Or TextFormatFlags.VerticalCenter)
            '描画が完了したことを知らせる
            e.Handled = True
        End If
    End Sub

    Private Sub GrepToolDataGridView_DataBindingComplete(ByVal sender As Object, ByVal e As DataGridViewBindingCompleteEventArgs) Handles Me.DataBindingComplete

        Dim filterStatus As String = DataGridViewAutoFilterColumnHeaderCell.GetFilterStatus(Me)
        If String.IsNullOrEmpty(filterStatus) Then
            showAllLabel.Visible = False
            filterStatusLabel.Visible = False
        Else
            showAllLabel.Visible = True
            filterStatusLabel.Visible = True
            filterStatusLabel.Text = filterStatus
        End If

    End Sub

    Private Sub GrepToolDataGridView_BindingContextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Me.BindingContextChanged

        ' Continue only if the data source has been set.
        If Me.DataSource Is Nothing Then
            Return
        End If

        ' Add the AutoFilter header cell to each column.
        For Each col As DataGridViewColumn In Me.Columns
            col.HeaderCell = New DataGridViewAutoFilterColumnHeaderCell(col.HeaderCell)
        Next

        ' Format the OrderTotal column as currency. 
        'Me.Columns("OrderTotal").DefaultCellStyle.Format = "c"

        ' Resize the columns to fit their contents.
        Me.AutoResizeColumns()

    End Sub

    Private Sub GrepToolDataGridView_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown

        If e.Alt AndAlso (e.KeyCode = Keys.Down OrElse e.KeyCode = Keys.Up) Then
            Dim filterCell As DataGridViewAutoFilterColumnHeaderCell = TryCast(Me.CurrentCell.OwningColumn.HeaderCell,
                DataGridViewAutoFilterColumnHeaderCell)
            If filterCell IsNot Nothing Then
                filterCell.ShowDropDownList()
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub showAllLabel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles showAllLabel.Click
        DataGridViewAutoFilterColumnHeaderCell.RemoveFilter(Me)
    End Sub
End Class
