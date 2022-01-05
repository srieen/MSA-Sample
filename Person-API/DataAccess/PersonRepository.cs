using Dapper;
using Person_API.Interfaces;
using Person_API.Model;
using System.Data;

namespace Person_API.DataAccess
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IDbConnection _dbConnection;

        public PersonRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<bool> AddPerson(Person person, string correlationId, CancellationToken cancellationToken)
        {

            await _dbConnection.ExecuteScalarAsync<int>("INSERT INTO [dbo].[New-Person] " +
                "(Id,FirstName,LastName,Address,DateOfBirth,Email,PhoneNumber) VALUES " +
                "(@Id,@FirstName, @LastName, @Address, @DateOfBirth, @Email ,@PhoneNumber)",
                new
                {
                    person.Id,
                    person.FirstName,
                    person.LastName,
                    person.Address,
                    person.DateofBirth,
                    person.Email,
                    person.PhoneNumber
                });

            return await Task.FromResult(true);
        }

        public async Task<List<Person>> GetAllPersons(string correlationId, CancellationToken cancellationToken)
        {
            var sql = "SELECT TOP (1000) [Id] ,[FirstName],[LastName] ,[Address] ," +
                "[DateOfBirth] ,[Email],[PhoneNumber],[CreatedDate],[ModifiedDate] " +
                "FROM [PersonDB].[dbo].[New-Person] Order by ModifiedDate Desc ";

            var persons = await _dbConnection.QueryAsync<Person>(sql);

            return (List<Person>)persons;
        }

        public Task<Person> GetPersonByName(string fristName, string lastName, string dateOfBirth, string correlationId, CancellationToken cancellationToken)
        {
          return Task.FromResult(new Person());
        }
    }
}
