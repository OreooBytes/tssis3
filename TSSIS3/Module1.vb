Imports MySql.Data.MySqlClient
Imports Mysqlx
Imports System.Windows.Forms
Imports System.IO


Module SessionData
    Public role As String
    Public fullName As String
End Module

Module Module1

    Public LoggedInUserType As String

    'Public connectionstring As String = "server=192.168.100.44;port=3306;user=tssis;password=;database=tssis"

    Public connectionstring As String = "server=localhost;port=3306;user=root;password=;database=tssis"


    ' Opens and returns an open MySQL connection
    Public Function Openconnection() As MySqlConnection
        Dim conn As New MySqlConnection(connectionstring)
        Try
            conn.Open()
            Return conn
        Catch ex As MySqlException
            MessageBox.Show("Error: " & ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

    ' Closes the MySQL connection safely
    Public Sub ConnectionClose(conn As MySqlConnection)
        Try
            If conn IsNot Nothing AndAlso conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        Catch ex As MySqlException
            MessageBox.Show("Error closing connection: " & ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Executes an INSERT, UPDATE, or DELETE query with parameters and returns affected rows
    Public Function ExecuteQuery(query As String, parameters As Dictionary(Of String, Object)) As Integer
        Dim conn As MySqlConnection = Openconnection()
        If conn Is Nothing Then Return 0 ' Exit if connection fails

        Try
            Using cmd As New MySqlCommand(query, conn)
                ' Add parameters dynamically
                For Each param In parameters
                    cmd.Parameters.AddWithValue(param.Key, param.Value)
                Next

                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                Return rowsAffected
            End Using
        Catch ex As Exception
            MessageBox.Show("Database Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 0
        Finally
            ConnectionClose(conn)
        End Try
    End Function

    Public Sub FormOpen(newForm As Form, currentForm As Form)
        Try
            ' ✅ Close all other open forms except current one
            Dim formsToClose As New List(Of Form)
            For Each f As Form In Application.OpenForms
                If f IsNot currentForm Then
                    formsToClose.Add(f)
                End If
            Next
            For Each f As Form In formsToClose
                f.Close()
            Next

            ' ✅ Show the new form and hide the current
            newForm.Show()
            currentForm.Hide()

        Catch ex As Exception
            MessageBox.Show("Error opening form: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub




End Module
