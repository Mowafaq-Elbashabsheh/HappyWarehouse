using HappyWarehouse.App.Models.User;
using HappyWarehouse.App.Models.Warehouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyWarehouse.App.Services
{
    public interface IUserService
    {
        Task<LoginResponseModel?> LoginAsync(LoginUserModel loginUserModel);
        Task<List<EditUserModel>> GetAllUsers();
        Task<EditUserModel?> GetUserById(int id);
        Task<bool> AddUser(AddUserModel model);
        Task<bool> UpdateUser(EditUserModel model);
        Task<bool> DeleteUser(int id);
    }
}
