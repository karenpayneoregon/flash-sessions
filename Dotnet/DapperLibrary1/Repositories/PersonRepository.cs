using System.Data;
using System.Transactions;
using Dapper;
using DapperLibrary1.Classes;
using DapperLibrary1.Handlers;
using DapperLibrary1.Interfaces;
using DapperLibrary1.Models;
using Microsoft.Data.SqlClient;
#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8603 // Possible null reference return.
#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.

namespace DapperLibrary1.Repositories;

public class PersonRepository : IBaseRepository
{
    private IDbConnection _cn;

    /// <summary>
    /// Setup for DateOnly handler and for creating a connection
    /// </summary>
    public PersonRepository()
    {
        _cn = new SqlConnection(ConnectionString());
        SqlMapper.AddTypeHandler(new DapperSqlDateOnlyTypeHandler());
    }

    /// <summary>
    /// Get all records in the Person table synchronously
    /// </summary>
    public List<Person> GetAll() 
        => _cn.Query<Person>(SqlStatements.ReadPeople).ToList();


    /// <summary>
    /// Get all records in the Person table asynchronously
    /// </summary>
    public async Task<List<Person>> GetAllAsync() 
        => (List<Person>)await _cn.QueryAsync<Person>(SqlStatements.ReadPeople);


    /// <summary>
    /// Get a single person by id (primary key)
    /// </summary>
    /// <param name="id">Existing primary key</param>   
    /// <returns>A single person or null if not located</returns>
    public async Task<Person> GetByPrimaryKey(int id) 
        => (await _cn.QueryFirstOrDefaultAsync<Person>(SqlStatements.GetByPrimaryKey, new { Id = id }))!;

    public async Task<Person> GetByFirstLastName(string firstName, string lastName)
        => (await _cn.QueryFirstOrDefaultAsync<Person>(SqlStatements.GetByFirstAndLastName, new 
            { FirstName = firstName, LastName = lastName }))!;

    /// <summary>
    /// Perform a WHERE IN for identifiers
    /// </summary>
    /// <param name="ids">one or more identifiers</param>
    /// <returns>list of people</returns>
    public async Task<List<Person>> WhereIn(int[] ids)
    {
        IEnumerable<Person> result = await _cn.QueryAsync<Person>(
            SqlStatements.WhereInClause, new
            {
                Ids = ids
            });

        return result.ToList();
    }

    /// <summary>
    /// Update an existing <see cref="Person"/>
    /// </summary>
    /// <param name="person"></param>
    /// <returns>success and on failure an exception</returns>
    public async Task<(bool, Exception ex)> Update(Person person)
    {
        try
        {
            var affected = await _cn.ExecuteAsync(SqlStatements.UpdatePerson, new
            {
                person.FirstName,
                person.LastName,
                person.BirthDate,
                person.Id
            });

            return (affected == 1, null);

        }
        catch (Exception localException)
        {
            return (false, localException);
        }
    }

    /// <summary>
    /// Add a single person
    /// </summary>
    /// <param name="person">Valid person</param>
    public async Task Add(Person person)
    {
        person.Id = await _cn.QueryFirstAsync<int>(SqlStatements.InsertPerson, person);
    }

    /// <summary>
    /// Add list of person to the person table
    /// </summary>
    /// <param name="list">List of people</param>
    /// <returns>success and on failure an exception</returns>
    public async Task<(bool, Exception ex)> AddRange(List<Person> list)
    {

        using TransactionScope transScope = new(TransactionScopeAsyncFlowOption.Enabled);

        try
        {
            foreach (var person in list)
            {
                await Add(person);
            }

            transScope.Complete();
            
            return (list.All(p => p.Id > 0), null);

        }
        catch (Exception localException)
        {
            return (false, localException);
        }
    }

    /// <summary>
    /// Slim down version of <seealso cref="AddRange"/>
    /// </summary>
    /// <param name="list"></param>
    /// <returns></returns>
    public async Task AddRangeSlim(List<Person> list)
    {
        await _cn.ExecuteAsync(SqlStatements.InsertPerson, list);
    }
    /// <summary>
    /// Remove a single <see cref="Person"/> record by primary key
    /// </summary>
    /// <param name="person">Existing person</param>
    /// <returns>success of operation</returns>
    public async Task<bool> Remove(Person person)
    {
        var affected = await _cn.ExecuteAsync(SqlStatements.RemovePerson, new { person.Id });
        return affected == 1;
    }

    #region For code samples

    /// <summary>
    /// Remove all records from the <see cref="Person"/> table and reset primary key
    /// </summary>
    /// <remarks>
    /// No exception handling is performed in this method
    /// </remarks>
    public async Task ResetPersonTable()
    {
        await using SqlConnection cn = new(ConnectionString());

        await cn.ExecuteAsync($"DELETE FROM dbo.{nameof(Person)}");

        await cn.ExecuteAsync($"DBCC CHECKIDENT ({nameof(Person)}, RESEED, 0)");
    }

    /// <summary>
    /// Count of records in the <see cref="Person"/>
    /// </summary>
    /// <returns></returns>
    public async Task<int> RecordCount()
    {
        return await _cn.ExecuteScalarAsync<int>(SqlStatements.CountOfPeople);
    }

    #endregion
}
