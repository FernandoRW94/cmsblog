using CmsBlogWeb.Models.ViewModels;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CmsBlogWeb.Business.Services.Interfaces
{
    public interface IOrchardCoreUserService
    {
        Task<OrchardCoreUserViewModel> GetOrchardCoreUser(ClaimsPrincipal user);

        Task UpdateUserDocumentData(OrchardCore.Users.Models.User user, string serializedData);

        Task RemoveUserFromDatabase(OrchardCore.Users.Models.User user);
    }
}
