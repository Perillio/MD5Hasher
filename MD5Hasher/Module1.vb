Imports System.Security.Cryptography
Imports System.Text
Imports System.IO


Module Module1

    Sub Main()
        Dim MyMD5 As String


        For Each argument As String In My.Application.CommandLineArgs
            MyMD5 = MD5FileHash(argument)
            Dim file As System.IO.StreamWriter
            file = My.Computer.FileSystem.OpenTextFileWriter(argument + ".md5", True)
            file.WriteLine(MyMD5)
            file.Close()
        Next
        'Console.ReadLine()
    End Sub
    Public Function MD5FileHash(ByVal sFile As String) As String
        Dim MD5 As New MD5CryptoServiceProvider
        Dim Hash As Byte()
        Dim Result As String = ""
        Dim Tmp As String = ""

        Dim FN As New FileStream(sFile, FileMode.Open, FileAccess.Read, FileShare.Read, 8192)
        MD5.ComputeHash(FN)
        FN.Close()

        Hash = MD5.Hash
        For i As Integer = 0 To Hash.Length - 1
            Tmp = Hex(Hash(i))
            If Len(Tmp) = 1 Then Tmp = "0" & Tmp
            Result += Tmp
        Next
        Return Result
    End Function
End Module
