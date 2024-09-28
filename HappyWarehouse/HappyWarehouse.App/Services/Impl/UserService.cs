using HappyWarehouse.App.Helpers;
using HappyWarehouse.App.Models.User;
using HappyWarehouse.Core.Entities;
using HappyWarehouse.DataAccess.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HappyWarehouse.App.Services.Impl
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<User> _userRepository;
        private readonly UserContext _userContext;
        private readonly IConfiguration _configuration;

        public UserService(IBaseRepository<User> repo, UserContext userContext, IConfiguration configuration)
        {
            _userRepository = repo;
            _userContext = userContext;
            _configuration = configuration;
        }

        public async Task<bool> AddUser(AddUserModel model)
        {
            var user = new User
            {
                Email = model.Email.Trim(),
                FullName = model.FullName,
                Active = model.Active,
                Password = model.Password,
                RoleId = model.RoleId,
                IsDeleted = false,
                CreatedBy = _userContext.Id,
                CreationOn = DateTime.Now,
            };

            var isUnique = await _userRepository.CheckUnique(x => x.Email.ToLower() == user.Email.ToLower());
            if (!isUnique)
            {
                return false;
            }

            await _userRepository.AddAsync(user);
            return true;
        }

        public async Task<bool> DeleteUser(int id)
        {
            await _userRepository.DeleteAsync(id);
            return true;
        }

        public async Task<List<EditUserModel>> GetAllUsers()
        {
            var users = _userRepository.GetAllInclude(x => !x.IsDeleted, new List<Expression<Func<User, object>>> { x => x.Role }, false);

            return users.Select(w => new EditUserModel
            {
                Id = w.Id,
                Email = w.Email,
                FullName= w.FullName,
                Active = w.Active,
                RoleId = w.RoleId,
                Role = w.Role.Name,
                Password = w.Password,
                CreatedBy = w.CreatedBy,
                CreationOn = w.CreationOn,
                IsDeleted = w.IsDeleted,
                ModificationDate = w.ModificationDate,
            }).ToList();
        }

        public async Task<EditUserModel?> GetUserById(int id)
        {
            var user = await _userRepository.GetFirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                return null;
            }

            return new EditUserModel
            {
                Id = user.Id,
                Email = user.Email,
                Role = user.Role.Name,
                RoleId= user.RoleId,
                Active = user.Active,
                FullName = user.FullName,
                Password = user.Password,
            };
        }

        public async Task<LoginResponseModel?> LoginAsync(LoginUserModel loginUserModel)
        {
            var user = _userRepository.GetAllInclude(x => 
            x.Email.ToLower() == loginUserModel.Email.ToLower() && x.Password == loginUserModel.Password && !x.IsDeleted, new List<Expression<Func<User, object>>> { x => x.Role }).FirstOrDefault();

            if(user == null)
            {
                return new LoginResponseModel { ErrorMessage = "Email Or Password is not correct" };
            }

            var token = "";
            if (!user.Active)
            {
                return new LoginResponseModel
                {
                    Token = "",
                    Email = "",
                    Role = "",
                    ErrorMessage = "Your account is disabled please contact support"
                };
            }

            token = JwtHelper.GenerateToken(user, _configuration);

            return new LoginResponseModel
            {
                Token = token,
                Email = loginUserModel.Email,
                Role = user.Role.Name
            };
        }

        public async Task<bool> UpdateUser(EditUserModel model)
        {
            var userEntity = new User
            {
                Id = model.Id,
                Email = model.Email,
                FullName= model.FullName,
                Password=model.Password,
                Active = model.Active,
                RoleId = model.RoleId,
                ModificationDate = DateTime.Now,
                IsDeleted = model.IsDeleted,
                CreationOn = model.CreationOn,
                CreatedBy = model.CreatedBy
            };

            await _userRepository.UpdateAsync(userEntity);
            return true;
        }
    }
}
