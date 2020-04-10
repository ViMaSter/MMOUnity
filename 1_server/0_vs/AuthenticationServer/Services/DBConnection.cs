using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using Dapper;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace AuthenticationServer.Services
{
    public interface IAuthorizationDatabase
    {
        public Task<bool> CreateUser(string username, string password);
        public Task<bool> AuthorizeUser(string username, string password);
    }

    public class AuthorizationDatabase : IAuthorizationDatabase
    {
        string connectionString;
        byte[] authorizationSaltInBytes;
        int cryptographyItterationCount;

        public AuthorizationDatabase(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DatabaseContext");
            authorizationSaltInBytes = System.Text.Encoding.UTF8.GetBytes(configuration.GetValue<string>("AuthorizationSalt"));
            cryptographyItterationCount = configuration.GetValue<int>("CryptographyItterationCount");
        }

        public async Task<bool> AuthorizeUser(string username, string password)
        {
            byte[] hashedPassword = KeyDerivation.Pbkdf2(
                password: password,
                salt: authorizationSaltInBytes,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: cryptographyItterationCount,
                numBytesRequested: 256 / 8
            );

            using (SqlConnection mysqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    return await mysqlConnection.QuerySingleAsync<bool>(
                        @"SELECT CASE WHEN EXISTS (
                            SELECT * FROM UserAccounts WHERE Username = @Username AND PasswordHash = @PasswordHash
                        )
                        THEN CAST(1 AS BIT)
                        ELSE CAST(0 AS BIT) END",
                        param: new
                        {
                            Username = username,
                            PasswordHash = Convert.ToBase64String(hashedPassword)
                        }
                    );
                }
                catch (SqlException sqlException)
                {
                    return false;
                }

            }
        }

        public async Task<bool> CreateUser(string username, string password)
        {
            byte[] hashedPassword = KeyDerivation.Pbkdf2(
                password: password,
                salt: authorizationSaltInBytes,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: cryptographyItterationCount,
                numBytesRequested: 256 / 8
            );

            using (SqlConnection mysqlConnection = new SqlConnection(connectionString))
            {
                try
                {
                    return await mysqlConnection.ExecuteAsync(
                        @"INSERT INTO UserAccounts(Username, PasswordHash) VALUES
                        (@Username, @PasswordHash)",
                        param: new
                        {
                            Username = username,
                            PasswordHash = Convert.ToBase64String(hashedPassword)
                        }
                    ) == 1;
                }
                catch(SqlException sqlException)
                {
                    return false;
                }
            }
        }
    }
}
