Option Strict On
Option Explicit On
Option Infer Off

Imports System

Module Program
    '
    ' Class level variables
    '
    Private pSomeVar As Integer = 1

    Sub Main(args As String())


        ' declare variable
        Dim strFirstName As String = "Karen"
        Dim lastName As String = "Payne"

        ' declare and initialize variable
        Dim someList As New List(Of String) From {"one", "two", "three"}

        ' loop through list
        ' and display each element
        For Each item As String In someList
            Console.WriteLine(item)
        Next

        ChangeValue()
        Console.WriteLine(pSomeVar)
        Console.ReadLine()

    End Sub

    Sub ChangeValue()
        pSomeVar = 2
    End Sub
End Module