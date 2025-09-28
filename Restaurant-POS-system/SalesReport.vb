Imports System.Data.OleDb

Public Class SalesReport
    Private Sub SalesReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim connstring = GetOrdersConnectionString()

        Using conn As New OleDbConnection(connString)
            Try
                conn.Open()

                Dim dt As DataTable = conn.GetSchema("Tables")

                For Each row As DataRow In dt.Rows
                    Dim tableType As String = row("TABLE_TYPE").ToString()
                    Dim tableName As String = row("TABLE_NAME").ToString()

                    If tableType = "TABLE" Then
                        MsgBox("Table: " & tableName)
                    End If
                Next

            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End Using
    End Sub
End Class