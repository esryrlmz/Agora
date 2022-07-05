using Agora.MODEL.Dto;
using Agora.MODEL.Entities;
using Agora.MODEL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agora.BLL.Interfaces
{
    public interface IUserRepository:IRepository<User>
    {
        void AddUserDto(UserDto item);

        List<User> UserList(Role role);
        User GetUser(int userId);
        UserDetail GetUserDetail(int userId);
        void UpdateUser(User user);
    }
}
