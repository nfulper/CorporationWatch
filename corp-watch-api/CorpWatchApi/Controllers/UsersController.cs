using System.Linq;
using CorpWatchApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CorpWatchApi.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private UserContext context;
        private Auth Auth;

        public UsersController(UserContext context, Auth auth)
        {
            this.context = context;
            this.Auth = auth;
        
        }

        // //Get: api/Users/validation
        // [HttpGet("validation")]
        // public bool Get()
        // {

        //     return Auth.IsValidToken(Request.Headers["Authorization"]);
        // }

        // Post api/Users/register    
        [HttpPost("register")]
        public string Post([FromBody] User user)
        {
            User foundUser = context.Users.SingleOrDefault<User>(u => u.Username == user.Username);
            if (foundUser != null)
            {
                return "Username not available.";
            }
            // user.Salt = Auth.GenerateSalt();
            // user.Password = Auth.Hash(user.Password, user.Salt);
            context.Users.Add(user);
            context.SaveChanges();
            return Auth.GenerateJWT(user);

        }

        [HttpPost("login")]
        public string login([FromBody] User user)
        {
            User foundUser = context.Users.SingleOrDefault<User>(
                u => u.Username == user.Username && u.Password == Auth.Hash(user.Password, u.Salt)
            );
            if (foundUser != null)
            {
                return Auth.GenerateJWT(foundUser);
            }
            return "Invalid Login Information.";
        }
    }
}
