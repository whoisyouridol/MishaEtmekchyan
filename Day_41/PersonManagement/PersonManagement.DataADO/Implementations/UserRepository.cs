using MailService;
using MailService.Models;
using Microsoft.Extensions.Options;
using PersonManagement.Data;
using PersonManagement.DataADO.Models;
using PersonManagement.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagement.DataADO.Implementations
{
    public class UserRepository : IUserRepository
    {
        const string SECRET_KEY = "asldij23324";

        private readonly string _connection;
        private string GenerateMD5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] bytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(bytes);

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }

                return sb.ToString();
            }
        }

        public UserRepository(IOptions<ConnectionStrings> options)
        {
            _connection = options.Value.DefaultConnection;
        }

        public async Task<string> CreateAsync(User user)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                string insertQuery = "INSERT INTO Users(FirstName, LastName, Password, Email,UserName,Verified,GUID) OUTPUT INSERTED.Username VALUES(@FirstName, @LastName, @Password,@Email, @Username, 0, @GUID)";

                SqlCommand command = new SqlCommand(insertQuery, connection);

                command.Parameters.AddWithValue("FirstName", user.FirstName);
                command.Parameters.AddWithValue("LastName", user.LastName);
                command.Parameters.AddWithValue("Username", user.Username);
                command.Parameters.AddWithValue("Email", user.Email);
                var newPass = GenerateMD5Hash(user.Password + SECRET_KEY);
                command.Parameters.AddWithValue("Password", newPass);
                command.Parameters.AddWithValue("Verified", 0);
                var guid = Guid.NewGuid().ToString();
                command.Parameters.AddWithValue("GUID", guid);



                connection.Open();

                return (string)await command.ExecuteScalarAsync().ConfigureAwait(false);
            }

        }

        public async Task<bool> Exists(string username)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                string existQuery = "SELECT COUNT(*) FROM Users WHERE Username = @username";

                SqlCommand command = new SqlCommand(existQuery, connection);

                command.Parameters.AddWithValue("username", username);

                connection.Open();

                int count = (int)await command.ExecuteScalarAsync().ConfigureAwait(false);

                return count > 0;

            }
        }

        public async Task<User> GetAsync(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                string existQuery = "SELECT * FROM Users WHERE Username = @username AND Password = @password";

                SqlCommand command = new SqlCommand(existQuery, connection);

                command.Parameters.AddWithValue("username", username);

                var newPass = GenerateMD5Hash(password + SECRET_KEY);
                command.Parameters.AddWithValue("Password", newPass);

                connection.Open();

                SqlDataReader reader = await command.ExecuteReaderAsync();

                User user = null;

                while (reader.Read())
                {
                    user = new User
                    {
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Password = reader.GetString(3),
                        Email = reader.GetString(4),
                        Username = reader.GetString(5),
                        IsVerified = reader.GetBoolean(6),
                        GUID = reader.GetString(7)
                    };
                }
                reader.Close();

                return user;
            }
        }

        public async Task<bool> ConfirmGuid(string guid)
        {
            using SqlConnection connection = new SqlConnection(_connection);
            string existQuery = "SELECT * FROM Users WHERE GUID = @guid";

            SqlCommand command = new SqlCommand(existQuery, connection);

            command.Parameters.AddWithValue("GUID", guid);

            connection.Open();

            SqlDataReader reader = await command.ExecuteReaderAsync();

            User user = null;

            while (reader.Read())
            {
                user = new User
                {
                    Id = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    Username = reader.GetString(4),
                    IsVerified = reader.GetBoolean(6),
                    GUID = reader.GetString(7)
                };
                break;
            }
            reader.Close();
            if (user.GUID == guid)
            {
                string updateQuery = "UPDATE Users Set Verified = 1 WHERE GUID = @guid ";
                SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                updateCommand.Parameters.AddWithValue("GUID", guid);

                var result = (string)await updateCommand.ExecuteScalarAsync().ConfigureAwait(false);
            }
            return true;
        }

        private async Task UpdatePassword(UpdateUserModel model)
        {
            using SqlConnection connection = new SqlConnection(_connection);
            var password = GenerateMD5Hash(model.NewPassword + SECRET_KEY);
            //aq ase ver davwere imitom rom exception-s migdebda : ystem.Data.SqlClient.SqlException (0x80131904): Must declare the scalar variable "@Password".
            ////da veranairad ver mivxvdi rashia saqme, identuri kodi sxva metodshi uproblemod mushaobs
            //string updateQuery = "UPDATE Users SET Password =@Password WHERE UserName = @UserName";
            //command.Parameters.AddWithValue("Password", password);
            //command.Parameters.AddWithValue("UserName", model.UserName);
            string updateQuery = $"UPDATE Users SET Password='{password}' WHERE UserName='{model.UserName}'";
            connection.Open();
            SqlCommand command = new SqlCommand(updateQuery, connection);
           


            SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
            var result = await updateCommand.ExecuteNonQueryAsync().ConfigureAwait(false);

        }
        public async Task<(bool, string)> UpdatePasswordAsync(UpdateUserModel user)
        {

            if (user.NewPassword == user.ConfirmPassword)
            {
                var result = await GetAsync(user.UserName, user.OldPassword);
                if (result.Password == GenerateMD5Hash(user.OldPassword + SECRET_KEY))
                    await UpdatePassword(user);

                return (true, result.Email);
            }
            else return (false, null);

        }


    }
}
