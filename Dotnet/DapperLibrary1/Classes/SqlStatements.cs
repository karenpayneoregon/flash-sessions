﻿namespace DapperLibrary1.Classes;

/// <summary>
/// All SQL statements for the project except for reset code.
/// (statements can also be in stored procedures)
/// </summary>
public class SqlStatements
{
    /// <summary>
    /// Add new person, return new primary key
    /// </summary>
    public static string InsertPerson =>
        """
        INSERT INTO dbo.Person
        (
            FirstName,
            LastName,
            BirthDate
        )
        VALUES
        (@FirstName, @LastName, @BirthDate);
        SELECT CAST(scope_identity() AS int);
        """;

    /// <summary>
    /// Get all records from Person table
    /// </summary>
    public static string ReadPeople =>
        """
        SELECT Id,
               FirstName,
               LastName,
               BirthDate
        FROM dbo.Person;
        """;

    public static string ReadPeopleJson =>
        """
        SELECT Id,
               FirstName,
               LastName,
               BirthDate
        FROM dbo.Person 
        
        FOR JSON PATH;
        
        """;

    /// <summary>
    /// Get a single person by primary key
    /// </summary>
    public static string GetByPrimaryKey => 
        """
        SELECT Id,
               FirstName,
               LastName,
               BirthDate
        FROM dbo.Person
        WHERE Id = @Id;
        """;

    /// <summary>
    /// Get a single person by primary key
    /// </summary>
    public static string GetByFirstAndLastName =>
        """
        SELECT Id
              ,FirstName
              ,LastName
              ,BirthDate
          FROM dbo.Person
        WHERE FirstName = @FirstName AND LastName = @LastName 
        """;

    /// <summary>
    /// Update person by primary key
    /// </summary>
    public static string UpdatePerson => 
        """
        UPDATE dbo.Person
        SET FirstName = @FirstName,
            LastName = @LastName,
            BirthDate = @BirthDate
        WHERE Id = @Id;
        """;

    /// <summary>
    /// Remove person by primary key
    /// </summary>
    public static string RemovePerson =>
        """
        DELETE FROM dbo.Person
        WHERE Id = @Id;
        """;

    /// <summary>
    /// Get count of records for Person table
    /// </summary>
    public static string CountOfPeople =>
        """
        SELECT COUNT(Id)
        FROM dbo.Person;
        """;

    /// <summary>
    /// SELECT WHERE BETWEEN years for birthdate
    /// </summary>
    public static string BirthDateBetweenYears => 
        """
        SELECT Id,
               FirstName,
               LastName,
               BirthDate
        FROM InsertExamples.dbo.Person
        WHERE YEAR(BirthDate)
        BETWEEN @StartYear AND @EndYear;
        """;

    /// <summary>
    /// Example for WHERE IN primary key
    /// </summary>
    public static string WhereInClause =>
        """
        SELECT Id,
               FirstName,
               LastName,
               BirthDate
        FROM dbo.Person
        WHERE Id IN @Ids;
        """;
}