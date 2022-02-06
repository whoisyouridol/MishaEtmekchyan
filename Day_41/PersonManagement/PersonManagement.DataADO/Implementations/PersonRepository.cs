using Microsoft.Extensions.Options;
using PersonManagement.Data;
using PersonManagement.DataADO.Models;
using PersonManagement.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace PersonManagement.DataADO.Implementations
{
    public class PersonRepository : IPersonRepository
    {
        #region Private Members

        private readonly string _connection;

        #endregion

        #region Ctor

        public PersonRepository(IOptions<ConnectionStrings> options)
        {
            _connection = options.Value.DefaultConnection;
        }

        #endregion

        #region Methods

        public async Task<List<Person>> GetAllAsync()
        {
            List<Person> persons = new List<Person>();

            string selectQuery = "select * from person";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(selectQuery, connection);

                connection.Open();

                SqlDataReader reader = await command.ExecuteReaderAsync();

                while (reader.Read())
                {
                    persons.Add(new Person
                    {
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        PersonIdentifier = reader.GetString(3),
                        Gender = reader.GetBoolean(4),
                        BirthDate = reader.GetDateTime(5)
                    });
                }
                reader.Close();

                return persons;
            }
        }

        public async Task<Person> GetAsync(int id)
        {
            string selectQuery = "select * from person where id = @id";

            using (SqlConnection connection = new SqlConnection(_connection))
            {
                SqlCommand command = new SqlCommand(selectQuery, connection);

                command.Parameters.AddWithValue("id", id);

                connection.Open();

                SqlDataReader reader = await command.ExecuteReaderAsync();

                Person person = null;

                while (reader.Read())
                {
                    person = new Person
                    {
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        PersonIdentifier = reader.GetString(3),
                        Gender = reader.GetBoolean(4),
                        BirthDate = reader.GetDateTime(5)
                    };
                }
                reader.Close();

                return person;
            }
        }

        public async Task<int> CreateAsync(Person person)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                string insertQuery = "Insert into person output INSERTED.Id values (@FirstName, @LastName, @PersonIdentifier, @Gender, @BirthDate)";

                SqlCommand command = new SqlCommand(insertQuery, connection);

                command.Parameters.AddWithValue("FirstName", person.FirstName);
                command.Parameters.AddWithValue("LastName", person.LastName);
                command.Parameters.AddWithValue("PersonIdentifier", person.PersonIdentifier);
                command.Parameters.AddWithValue("Gender", person.Gender);
                command.Parameters.AddWithValue("BirthDate", person.BirthDate);

                connection.Open();

                return (int)await command.ExecuteScalarAsync();
            }
        }

        public async Task<bool> Exists(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                string existQuery = "select Count(*) from person where id = @id";

                SqlCommand command = new SqlCommand(existQuery, connection);

                command.Parameters.AddWithValue("id", id);

                connection.Open();

                int count = (int)await command.ExecuteScalarAsync();

                return count > 0;
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                string existQuery = "delete from person  where id = @id";

                SqlCommand command = new SqlCommand(existQuery, connection);

                command.Parameters.AddWithValue("id", id);

                connection.Open();

                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task UpdateAsync(Person person)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                string updateQuery = "update person set FirstName=@FirstName, LastName = @LastName, PersonIdentifier = @PersonIdentifier, Gender = @Gender, BirthDate = @BirthDate where id = @id";

                SqlCommand command = new SqlCommand(updateQuery, connection);

                command.Parameters.AddWithValue("id", person.Id);
                command.Parameters.AddWithValue("FirstName", person.FirstName);
                command.Parameters.AddWithValue("LastName", person.LastName);
                command.Parameters.AddWithValue("PersonIdentifier", person.PersonIdentifier);
                command.Parameters.AddWithValue("Gender", person.Gender);
                command.Parameters.AddWithValue("BirthDate", person.BirthDate);

                connection.Open();

                await command.ExecuteNonQueryAsync();
            }
        }

        #endregion
    }
}
