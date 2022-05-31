using Practic.Data.Interfaces;
using Practic.Domain.Enum;
using Practic.Domain.Responce;
using Practic.Domain.ViewModels.User;
using Practic.Models;
using Practic.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Practic.Service.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IBaseResponce<UserViewModel>> Create(UserViewModel userViewModel)
        {
            var baseResponce = new BaseResponce<UserViewModel>();

            try
            {
                var userLog = await _userRepository.GetLogin(userViewModel.Login);

                if (userLog == null)
                {
                    var user = new User()
                    {
                        Id = Guid.NewGuid().ToString(),
                        First_name = userViewModel.First_name,
                        Midle_name = userViewModel.Midle_name,
                        Last_name = userViewModel.Last_name,
                        Login = userViewModel.Login,
                        Password = userViewModel.Password,
                        RoleId = userViewModel.RoleId
                    };

                    await _userRepository.Create(user);
                }

                baseResponce.Description = "The user exists";
                baseResponce.StatusCode = StatusCode.Exists;
            }
            catch (Exception ex)
            {
                return new BaseResponce<UserViewModel>()
                {
                    Description = $"[CreateUser] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
            return baseResponce;
        }

        public async Task<IBaseResponce<bool>> Delete(string id)
        {
            var baseResponce = new BaseResponce<bool>();

            try
            {
                var user = await _userRepository.Get(id);

                if (user == null)
                {
                    baseResponce.Description = "User not found";
                    baseResponce.StatusCode = StatusCode.NotFound;
                    return baseResponce;
                }

                await _userRepository.Delete(user);

                return baseResponce;
            }
            catch(Exception ex)
            {
                return new BaseResponce<bool>()
                {
                    Description = $"[DeleteUser] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponce<User>> Get(string id)
        {
            var baseResponce = new BaseResponce<User>();

            try
            {
                var user = await _userRepository.Get(id);

                if (user == null)
                {
                    baseResponce.Description = "User not found";
                    baseResponce.StatusCode = StatusCode.NotFound;
                    return baseResponce;
                }

                baseResponce.Data = user;
                return baseResponce;
            }
            catch(Exception ex)
            {
                return new BaseResponce<User>()
                {
                    Description = $"[GetUser] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponce<IEnumerable<User>>> GetUsers()
        {
            var baseResponce = new BaseResponce<IEnumerable<User>>();

            try
            {
                var users = await _userRepository.GetAll();

                if (users.Count == 0)
                {
                    baseResponce.Description = "Найдено 0 элементов";
                    baseResponce.StatusCode = StatusCode.NotFound;
                    return baseResponce;
                }

                baseResponce.Data = users;
                baseResponce.StatusCode = StatusCode.OK;

                return baseResponce;
            }
            catch(Exception ex)
            {
                return new BaseResponce<IEnumerable<User>>()
                {
                    Description = $"[GetUsers] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
        };
            }
        }

        public async Task<IBaseResponce<User>> Update(string id, UserViewModel model)
        {
            var baseResponce = new BaseResponce<User>();

            try
            {
                var user = await _userRepository.Get(id);
                if (user == null)
                {
                    baseResponce.Description = "User not found";
                    baseResponce.StatusCode = StatusCode.NotFound;
                    return baseResponce;
                }

                user.First_name = model.First_name;
                user.Midle_name = model.Midle_name;
                user.Last_name = model.Last_name;
                user.Login = model.Login;
                user.Password = model.Password;
                user.RoleId = model.RoleId;

                await _userRepository.Update(user);

                return baseResponce;
            }
            catch (Exception ex)
            {
                return new BaseResponce<User>()
                {
                    Description = $"[UpdateUsers] : {ex.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
