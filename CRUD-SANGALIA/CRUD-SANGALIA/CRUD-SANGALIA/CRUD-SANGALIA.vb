Imports System.Data.OleDb
Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call connection()
        Call StudentList()
    End Sub

    Private Sub StudentList()
        sql = "Select StudentNo,LastName,FirstName,Mi,Department,Course,Address,Birthday,Age,Gender from StudentInformation"
        cmd = New OleDbCommand(sql, cn)
        Dim da As New OleDbDataAdapter(cmd)
        Dim dt As New DataTable
        da.Fill(dt)
        dgvStudents.DataSource = dt
    End Sub

    Private Sub clear()
        txtStudentNo.Clear()
        txtFname.Clear()
        txtLname.Clear()
        txtMname.Clear()
        txtDepartment.Clear()
        txtCourse.Clear()
        txtAddress.Clear()
        dtBirthday.Text = ""
        txtAge.Clear()
        cboGender.Text = ""
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        sql = "Insert into [StudentInformation](StudentNo,LastName,FirstName,Mi,Department,Course,Address,Birthday,Age,Gender)Values('" & txtStudentNo.Text & "','" & txtLname.Text & "','" & txtFname.Text & "','" & txtMname.Text & "','" & txtDepartment.Text & "','" & txtCourse.Text & "','" & txtAddress.Text & "','" & dtBirthday.Text & "','" & txtAge.Text & "','" & cboGender.Text & "')"
        cmd = New OleDbCommand(sql, cn)
        cmd.ExecuteNonQuery()
        MsgBox("Information Successfully Saved", MsgBoxStyle.Information, "Student Information")
        Call clear()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        sql = "Update [StudentInformation] Set [LastName]='" & txtLname.Text & "',[FirstName]='" & txtFname.Text & "',[Mi]='" & txtMname.Text & "',[Department]='" & txtDepartment.Text & "',[Course]='" & txtCourse.Text & "',[Address]='" & txtAddress.Text & "',[Birthday]='" & dtBirthday.Text & "',[Age]='" & txtAge.Text & "',[Gender]='" & cboGender.Text & "' Where [StudentNo]='" & txtStudentNo.Text & "'"
        cmd = New OleDbCommand(sql, cn)
        cmd.ExecuteNonQuery()
        MsgBox("Information Successfully Updated", MsgBoxStyle.Information, "Student Information")
        Call clear()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Call StudentList()
    End Sub

    Private Sub dgvStudents_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvStudents.CellContentClick
        txtStudentNo.Text = dgvStudents.Rows(e.RowIndex).Cells(0).Value
    End Sub

    Private Sub txtStudentNo_TextChanged(sender As Object, e As EventArgs) Handles txtStudentNo.TextChanged
        sql = "Select StudentNo,LastName,FirstName,Mi,Department,Course,Address,Birthday,Age,Gender from StudentInformation where [StudentNo]='" & txtStudentNo.Text & "'"
        cmd = New OleDbCommand(sql, cn)
        dr = cmd.ExecuteReader
        If dr.Read = True Then
            txtLname.Text = dr("LastName")
            txtFname.Text = dr("FirstName")
            txtMname.Text = dr("Mi")
            txtDepartment.Text = dr("Department")
            txtCourse.Text = dr("Course")
            txtAddress.Text = dr("Address")
            dtBirthday.Value = dr("Birthday")
            txtAge.Text = dr("Age")
            cboGender.Text = dr("Gender")
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        sql = "Delete StudentNo,LastName,FirstName,Mi,Department,Course,Address,Birthday,Age,Gender from StudentInformation where [StudentNo]='" & txtStudentNo.Text & "'"
        cmd = New OleDbCommand(sql, cn)
        cmd.ExecuteNonQuery()
        MsgBox("Information Successfully Deleted", MsgBoxStyle.Information, "Student Information")
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        sql = "Select StudentNo,LastName,FirstName,Mi,Department,Course,Address,Birthday,Age,Gender from StudentInformation where [StudentNo] Like '%" & txtSearch.Text & "%' Or [LastName] Like'%" & txtSearch.Text & "%' Or [FirstName] Like'%" & txtSearch.Text & "%'"
        cmd = New OleDbCommand(sql, cn)
        Dim da As New OleDbDataAdapter(cmd)
        Dim dt As New DataTable
        da.Fill(dt)
        dgvStudents.DataSource = dt

        If txtSearch.Text = "" Then
            Call StudentList()
        End If
    End Sub
End Class