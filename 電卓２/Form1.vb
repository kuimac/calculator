Public Class Form1
    Dim Input_str As String = ""  ' 入力された数字
    Dim Result As Double = 0  ' 計算結果
    Dim operators As String = Nothing  ' 押された演算子

    Dim ResultArray_number As Integer = 0

    Dim ResultArray(0) As String




    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
    End Sub


    Private Sub btnSeven_Click(sender As Object, e As EventArgs) Handles btnZero.Click, btnOne.Click, tnTwo.Click, btnThree.Click, btnFour.Click, btnFive.Click, btnSix.Click, btnSeven.Click, btnEight.Click, btnNine.Click
        ' senderの詳しい情報を取り扱えるようにする
        Dim btn = CType(sender, Button)
        ' 押されたボタンの数字
        Dim Text As String = btn.Text
        ' [入力された数字]に連結する
        Input_str += Text
        ' 画面上に数字を出す
        TextBox1.Text = Input_str
    End Sub

    Private Sub btnDivide_Click(sender As Object, e As EventArgs) Handles btnPlus.Click, btnMinus.Click, btnMultiply.Click, btnDivide.Click, btnResult.Click
        Dim num1 As Double = Result
        Dim num2 As Double
        If Input_str IsNot "" Then
            ' 入力した文字を数字に変換
            num2 = Double.Parse(Input_str)

            If operators = "+" Then
                Result = num1 + num2
            End If
            If operators = "-" Then
                Result = num1 - num2
            End If
            If operators = "*" Then
                Result = num1 * num2
            End If

            'If operators = "/" Then
            '  Result = num1 / num2
            ' End If

            If operators = "/" Then
                Result = num1 / num2
            End If

            If operators = "/" And
                     num1 = 0 And
            num2 = 0 Then
                MsgBox("0除算はだめです",
    MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation,
    "エラー")
            End If


            ' 演算子を押されていなかった場合、入力されている文字をそのまま結果扱いにする
            If operators = Nothing Then
                    Result = num2
                End If
            End If




            ' 画面に計算結果を表示する
            TextBox1.Text = Result.ToString()


        ' 今入力されている数字をリセットする
        Input_str = ""
        ' 演算子をOperator変数に入れる
        Dim btn = CType(sender, Button)
        operators = btn.Text
        If operators = "=" Then
            operators = ""
        End If
    End Sub

    Private Sub btnResult_Click(sender As Object, e As EventArgs) Handles btnResult.Click
        ResultArray(ResultArray_number) = Result.ToString() & Environment.NewLine
        ResultArray_number += ResultArray_number

        For i = 0 To ResultArray.Count - 1
            RichTextBox1.AppendText(ResultArray(i))
        Next i
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ' 今入力されている数字をリセットする
        Input_str = ""
        TextBox1.Text = Input_str

        RichTextBox1.Text = Nothing
    End Sub

End Class
