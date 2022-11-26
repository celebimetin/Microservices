using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserViewModel> GetUser();
    }
}