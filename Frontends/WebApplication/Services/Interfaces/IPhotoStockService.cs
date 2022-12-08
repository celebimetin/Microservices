using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using WebApplication.Models.PhotoStocks;

namespace WebApplication.Services.Interfaces
{
    public interface IPhotoStockService
    {
        Task<PhotoViewModel> UploadPhoto(IFormFile photo);
        Task<bool> DeletePhoto(string photoUrl);
    }
}