using Agora.BLL.Interfaces;
using Agora.MODEL.Entities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Agora.API.Controllers
{
    [Route("api/v1/users")]
    [ApiController]
    public class UserController : Controller
    {
        IUserRepository _repoUser;
        public UserController(IUserRepository repoUser)
        {
            _repoUser = repoUser;   
        }


        [HttpGet("LoginControl/{username}/{password}")]
        public int UserControl(string username, string password)
        {
            int userid = 0;
            User luser = _repoUser.IsUserLogin(username);
            if (luser != null&& BCrypt.Net.BCrypt.Verify(password, luser.Password))
            {
                userid = luser.ID;
            }
            return userid;
        }

        [HttpGet("{user_id}")]
        public UserDetail getProfile(string user_id)
        {
            return _repoUser.GetUserDetail(Convert.ToInt32(user_id));
        }
       
    }
}
