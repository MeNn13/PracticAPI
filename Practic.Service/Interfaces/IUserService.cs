using Practic.Domain.Responce;
using Practic.Domain.ViewModels.User;
using Practic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Practic.Service.Interfaces
{
    public interface IUserService
    {
        Task<IBaseResponce<IEnumerable<User>>> GetUsers();
        Task<IBaseResponce<User>> Get(string id);
        Task<IBaseResponce<UserViewModel>> Create(UserViewModel userViewModel);
        Task<IBaseResponce<bool>> Delete(string id);
        Task<IBaseResponce<User>> Update(string id, UserViewModel model);
    }
}
