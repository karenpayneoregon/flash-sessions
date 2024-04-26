Public Class SqlStatements

    Public Shared ReadOnly Property InsertPeople As String
        Get
            Return _
                <SQL>
                    INSERT INTO dbo.Person
                    (
                        FirstName,
                        LastName,
                        BirthDate
                    )
                    VALUES
                    (@FirstName, @LastName, @BirthDate);
                    SELECT CAST(scope_identity() AS int);
                    </SQL>.Value

        End Get
    End Property

End Class






