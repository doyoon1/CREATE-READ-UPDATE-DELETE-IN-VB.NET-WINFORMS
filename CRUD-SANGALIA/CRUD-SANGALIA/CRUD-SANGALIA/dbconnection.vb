Imports System.Data.OleDb
Module Database
    Public cn As New OleDbConnection
    Public cmd As OleDbCommand
    Public sql As String
    Public dr As OleDbDataReader

    Public Sub connection()
        cn.Close()
        cn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Admin\OneDrive\Desktop\CRUD-SANGALIA\StudentInformation.mdb"
        cn.Open()
        MsgBox("Connection success", MsgBoxStyle.Information, "Database Connection")
    End Sub
End Module
