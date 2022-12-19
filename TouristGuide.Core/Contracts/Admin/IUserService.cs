using TouristGuide.Core.Models.Admin;
using TouristGuide.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;

namespace TouristGuide.Core.Contracts.Admin
{
    public interface IUserService
    {
        Task<string> UserFullName(string userId);

        Task<IEnumerable<UserServiceModel>> All();

        Task<bool> Forget(string userId);
    }
}
