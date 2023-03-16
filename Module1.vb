Imports System.IO
Module Module1

    Sub Main()
        Dim mFileReader As FileStream = Nothing
        Dim mFileWriter As FileStream = Nothing
        Dim Writer As BinaryWriter = Nothing
        Dim Reader As BinaryReader = Nothing

        Try
            mFileWriter = New FileStream("data.dat", FileMode.OpenOrCreate, FileAccess.Write)
            Writer = New BinaryWriter(mFileWriter)
            Writer.Write("Sarahi")
            Writer.Write(23)
            Writer.Write(1.6)
            Writer.Write("F"c)

            Writer.Write("Enrique")
            Writer.Write(48)
            Writer.Write(1.62)
            Writer.Write("M"c)
        Catch ex As IOException
            Console.WriteLine("Error writing to file: " & ex.Message)
        Finally
            If Writer IsNot Nothing Then Writer.Close()
            If mFileWriter IsNot Nothing Then mFileWriter.Close()
        End Try

        Try
            mFileReader = New FileStream("data.dat", FileMode.OpenOrCreate, FileAccess.Read)
            Reader = New BinaryReader(mFileReader)

            While mFileReader.Position <> mFileReader.Length
                Console.WriteLine(Reader.ReadString())
                Console.WriteLine(Reader.ReadInt32())
                Console.WriteLine(Reader.ReadDouble())
                Console.WriteLine(Reader.ReadChar())
            End While
        Catch ex As IOException
            Console.WriteLine("Error reading file: " & ex.Message)
        Finally
            If Reader IsNot Nothing Then Reader.Close()
            If mFileReader IsNot Nothing Then mFileReader.Close()
        End Try

        Console.ReadKey()
    End Sub

End Module

