using IdentityModel.Client;
using Shared.Dtos;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<Response<bool>> SignIn(SigInInput sigInInput);
        Task<TokenResponse> GetAccessTokenByRefreshToken();
        Task RevokeRefreshToken();
    }
}