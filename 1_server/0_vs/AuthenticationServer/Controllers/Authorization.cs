using AuthenticationServer.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace AuthenticationServer.Controllers
{
    public class LoginModel
    {
        [MaxLength(255)]
        public string Username { get; set; }
        [MaxLength(55)]
        public string Password { get; set; }
    }

    public class SignupModel : LoginModel { }

    public class Authorization : ControllerBase
    {
        private readonly IAuthorizationDatabase _database;
        private readonly ISessionManager _sessionManager;

        public Authorization(Services.IAuthorizationDatabase database, Services.ISessionManager sessionManager)
        {
            _database = database;
            _sessionManager = sessionManager;
        }

        [HttpPost]
        public async Task<int> CreateSession([FromBody]LoginModel loginModel)
        {
            if (!(await _database.AuthorizeUser(loginModel.Username, loginModel.Password)))
            {
                return -1;
            }
            if (!_sessionManager.TryCreateSessionIDForUser(loginModel.Username, out int sessionID))
            {
                return -1;
            }
            return sessionID;
        }

        [HttpPost]
        public async Task<bool> CreateUser([FromBody]SignupModel signupModel)
        {
            return await _database.CreateUser(signupModel.Username, signupModel.Password);
        }
    }
}
