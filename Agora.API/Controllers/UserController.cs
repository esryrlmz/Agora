using Agora.BLL.Interfaces;
using Agora.MODEL.Dto;
using Agora.MODEL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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

        [HttpPost("addUser")]
        public UserDto addUser([FromBody] UserDto userdto)
        {
            return _repoUser.AddUserDto(userdto);
        }
        [HttpPut("/passive/{user_id}/")]
        public bool passiveUser(string user_id)
        {
            try
            {
                _repoUser.Delete(Convert.ToInt32(user_id));
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        } 

        [HttpPut("updateuserdetail/{user_id:int}")]
        public async Task<ActionResult<UserDetail>> UpdateUserDetail(int user_id, [FromBody] UserDetail userdetail)
        {
            try
            {
                if (userdetail == null)
                {
                    return BadRequest("Gelen veri yetersiz");
                }

                UserDetail ud =  _repoUser.GetUserDetail(user_id);

                if (ud == null)
                { return NotFound("Kullanıcıya ait profil bulunamadı!"); }
                ud.NameSurname = userdetail.NameSurname;
                ud.Country = userdetail.Country;
                ud.Towner = userdetail.Towner;
                ud.Status = userdetail.Status;
                ud.Email = userdetail.Email;
                ud.Phone = userdetail.Phone;
                var userdetails =await _repoUser.UpdateUserDetail(ud);
                return Ok(userdetails);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ex);
            }
           
            //
           
            //_repoUser.UpdateUserDetail(ud);
            //return true;
        }




       

    }
}
