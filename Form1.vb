Imports System.IO
Imports Microsoft.VisualBasic.CompilerServices

Public Class Form1
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer

    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseDown
        drag = True
        mousex = Cursor.Position.X - Me.Left
        mousey = Cursor.Position.Y - Me.Top
    End Sub

    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseMove
        If drag Then
            Top = Cursor.Position.Y - mousey
            Left = Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub Form1_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseUp
        drag = False
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Text = Softwarename & softwareversion

        Dim process As Process
        For Each process In Process.GetProcessesByName("SMΔRTP")
            process.Kill()
        Next
        ComboBox1.Items.Add("Perusahaan")
        ComboBox1.Items.Add("Warnet")
        ComboBox1.SelectedItem = "Perusahaan"
        getsmadavinfo()

        My.Computer.FileSystem.CreateDirectory(tempfolder)
        File.WriteAllBytes(tempfolder & "\1.exe", My.Resources.protect)
        File.WriteAllBytes(tempfolder & "\2.exe", My.Resources.unprotect)
        File.WriteAllBytes(tempfolder & "\color.reg", My.Resources.dfc)
    End Sub

    Private Sub Kasi_Purutik_Click(sender As Object, e As EventArgs) Handles Kasi_Purutik.Click
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\SMADΔV\Exception", "Fil0", "C:\\Windows\\system32\\drivers\\etc\\hosts")
        Shell(tempfolder & "\1.exe", AppWinStyle.Hide, Wait:=True)
        MsgBox("Serial Number Protected!", vbInformation, Softwarename & softwareversion)
    End Sub

    Private Sub Inda_Purutik_Click(sender As Object, e As EventArgs) Handles Inda_Purutik.Click
        Shell(tempfolder & "\2.exe", AppWinStyle.Hide, Wait:=True)
        MsgBox("Serial Number Unprotected!", vbInformation, Softwarename & softwareversion)
    End Sub

    Private Sub Naiktarap_Click(sender As Object, e As EventArgs) Handles Naiktarap.Click
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\SMADΔV", "Name", "SMADAV Toolkit 1.4")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\SMADΔV", "Key", "991599257525")
        getsmadavinfo()
        MsgBox("Your SMADAV Antivirus upgraded to Pro Version", vbInformation, Softwarename & softwareversion)
    End Sub

    Private Sub Karual_Click(sender As Object, e As EventArgs) Handles Karual.Click
        File.Delete(tempfolder & "\1.exe")
        File.Delete(tempfolder & "\2.exe")
        My.Computer.FileSystem.DeleteDirectory(tempfolder, FileIO.DeleteDirectoryOption.DeleteAllContents)
        End
    End Sub

    Private Sub Kasi_Borisi_Click(sender As Object, e As EventArgs) Handles Kasi_Borisi.Click
        Try
            My.Computer.Registry.CurrentUser.DeleteSubKey("Software\Microsoft\Notepad")
        Catch ex As Exception
        End Try
        Shell("reg import " & tempfolder & "\color.reg", AppWinStyle.Hide, Wait:=True)
        Label8.Text = "Blacklisted: NO"
        Label8.Refresh()
        MsgBox("Blacklist Removed!", vbInformation, Softwarename & softwareversion)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If ComboBox1.Text = "Perusahaan" Then
            genperusahaan()
        End If
        If ComboBox1.Text = "Warnet" Then
            genwarnet()
        End If
    End Sub

    Sub genperusahaan()
        Dim numArray As Integer() = New Integer(7 - 1) {}
        Dim numArray2 As Integer() = New Integer(&H16 - 1) {}
        Dim numArray3 As Integer() = New Integer(&H15 - 1) {}
        numArray(0) = Conversions.ToInteger("00")
        numArray(1) = Conversions.ToInteger("00")
        numArray(2) = Conversions.ToInteger("00")
        numArray(3) = Conversions.ToInteger("99")
        numArray(4) = Conversions.ToInteger("99")
        numArray(5) = Conversions.ToInteger("00")
        numArray2(0) = &H26
        numArray2(1) = &H38
        numArray2(2) = &H39
        numArray2(3) = &H39
        numArray2(4) = &H63
        numArray2(5) = 15
        numArray2(6) = &H3A
        numArray2(7) = 12
        numArray2(8) = 13
        numArray2(9) = &H11
        numArray2(10) = &H13
        numArray2(11) = &H12
        numArray2(12) = &H58
        numArray2(13) = &H3A
        numArray2(14) = &H34
        numArray2(15) = &H34
        numArray2(&H10) = 12
        numArray2(&H11) = 13
        numArray2(&H12) = 12
        numArray2(&H13) = &H39
        numArray2(20) = &H34
        numArray2(&H15) = &H62
        Try
            Dim expression As String = UCase(Replace(TextBox1.Text, " ", "", 1, -1, CompareMethod.Binary))
            Dim num2 As Integer = (Len(expression) - 1)
            Dim index As Integer = 0
            Dim num4 As Integer = 0
            Do While (index <= num2)
                Dim num5 As Integer = Len(expression)
                Dim i As Integer = 1
                Do While (i <= num5)
                    numArray3(index) = Asc(Mid(expression, i, 1))
                    If (num4 > 2) Then
                        num4 = 0
                    End If
                    numArray(num4) = ((numArray3(index) * Len(expression)) + (numArray(num4) Mod 100))
                    If (numArray(num4) >= 100) Then
                        numArray(num4) = (numArray(num4) Mod 100)
                    End If
                    index += 1
                    num4 += 1
                    i += 1
                Loop
            Loop

            For index = 0 To 5 - 1
                numArray(5) = ((numArray(5) + (numArray(index) * Len(expression))) Mod &H16)
            Next index
            numArray(5) = numArray2(numArray(5))
            If (Conversions.ToDouble(Trim(Conversions.ToString(Len(TextBox1.Text)))) < 1) Then
                TextBox2.Text = ""
            Else
                TextBox2.Text = String.Concat(New String() {Conversions.ToString(numArray(3)), Conversions.ToString(numArray(5)), Conversions.ToString(numArray(4)), $"{numArray(0):0#}", $"{numArray(1):0#}", $"{numArray(2):0#}"})
            End If
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            MessageBox.Show(exception.Message, Softwarename & softwareversion, MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Err.Clear()
            ProjectData.ClearProjectError()
        End Try
    End Sub

    Sub genwarnet()
        Dim numArray As Integer() = New Integer(7 - 1) {}
        Dim numArray2 As Integer() = New Integer(&H16 - 1) {}
        Dim numArray3 As Integer() = New Integer(&H15 - 1) {}
        numArray(0) = Conversions.ToInteger("00")
        numArray(1) = Conversions.ToInteger("00")
        numArray(2) = Conversions.ToInteger("00")
        numArray(3) = Conversions.ToInteger("77")
        numArray(4) = Conversions.ToInteger("77")
        numArray(5) = Conversions.ToInteger("00")
        numArray2(0) = &H26
        numArray2(1) = &H38
        numArray2(2) = &H39
        numArray2(3) = &H39
        numArray2(4) = &H63
        numArray2(5) = 15
        numArray2(6) = &H3A
        numArray2(7) = 12
        numArray2(8) = 13
        numArray2(9) = &H11
        numArray2(10) = &H13
        numArray2(11) = &H12
        numArray2(12) = &H58
        numArray2(13) = &H3A
        numArray2(14) = &H34
        numArray2(15) = &H34
        numArray2(&H10) = 12
        numArray2(&H11) = 13
        numArray2(&H12) = 12
        numArray2(&H13) = &H39
        numArray2(20) = &H34
        numArray2(&H15) = &H62
        Try
            Dim expression As String = UCase(Replace(TextBox1.Text, " ", "", 1, -1, CompareMethod.Binary))
            Dim num2 As Integer = (Len(expression) - 1)
            Dim index As Integer = 0
            Dim num4 As Integer = 0
            Do While (index <= num2)
                Dim num5 As Integer = Len(expression)
                Dim i As Integer = 1
                Do While (i <= num5)
                    numArray3(index) = Asc(Mid(expression, i, 1))
                    If (num4 > 2) Then
                        num4 = 0
                    End If
                    numArray(num4) = ((numArray3(index) * Len(expression)) + (numArray(num4) Mod 100))
                    If (numArray(num4) >= 100) Then
                        numArray(num4) = (numArray(num4) Mod 100)
                    End If
                    index += 1
                    num4 += 1
                    i += 1
                Loop
            Loop

            For index = 0 To 5 - 1
                numArray(5) = ((numArray(5) + (numArray(index) * Len(expression))) Mod &H16)
            Next index
            numArray(5) = numArray2(numArray(5))
            If (Conversions.ToDouble(Trim(Conversions.ToString(Len(TextBox1.Text)))) < 1) Then
                TextBox2.Text = ""
            Else
                TextBox2.Text = String.Concat(New String() {Conversions.ToString(numArray(3)), Conversions.ToString(numArray(5)), Conversions.ToString(numArray(4)), $"{numArray(0):0#}", $"{numArray(1):0#}", $"{numArray(2):0#}"})
            End If
        Catch exception1 As Exception
            ProjectData.SetProjectError(exception1)
            Dim exception As Exception = exception1
            MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Err.Clear()
            ProjectData.ClearProjectError()
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "Perusahaan" Then
            genperusahaan()
        End If
        If ComboBox1.Text = "Warnet" Then
            genwarnet()
        End If
    End Sub

    Sub getsmadavinfo()
        If My.Computer.FileSystem.DirectoryExists("C:\Program Files (x86)\") Then
            If My.Computer.FileSystem.FileExists("C:\Program Files (x86)\SMADAV\SMΔRTP.exe") Then
                Label6.Text = "Smadav is Installed: YES"
                Label6.Refresh()
            Else
                Label6.Text = "Smadav is Installed: NO"
                Label6.Refresh()
            End If
        Else
            If My.Computer.FileSystem.FileExists("C:\Program Files\SMADAV\SMΔRTP.exe") Then
                Label6.Text = "Smadav is Installed: YES"
                Label6.Refresh()
            Else
                Label6.Text = "Smadav is Installed: NO"
                Label6.Refresh()
            End If
        End If

        If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\SMADΔV", "name", "") = "" Then
            Label7.Text = "Pro Version: NO"
            Label7.Refresh()
        Else
            Label7.Text = "Pro Version: YES (Registered Name: " & My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\SMADΔV", "name", "") & ")"
            Label7.Refresh()
        End If

        Try
            If My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Notepad", "lfPitchΔndFamily", "") Then
                Label8.Text = "Blacklisted: YES"
                Label8.Refresh()
            ElseIf My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Notepad", "lfPitchΔndFamily2", "") Then
                Label8.Text = "Blacklisted: YES"
                Label8.Refresh()
            ElseIf My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Notepad", "lfPitchΔndFamily3", "") Then
                Label8.Text = "Blacklisted: YES"
                Label8.Refresh()
            End If
        Catch ex As Exception
        End Try

    End Sub

    Private Sub TentangBtn_Click(sender As Object, e As EventArgs) Handles TentangBtn.Click
        MsgBox("SMADAV TOOLKIT 1.4" & vbNewLine & vbNewLine & "Cracker: Gomutan Sungai" & vbNewLine & "Protection: Serial Number, Online Serial Check, blacklist" & vbNewLine & "Release Date: January 2019")
    End Sub
End Class
