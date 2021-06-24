using CmsBlogWeb.Business.Services.Interfaces;
using CmsBlogWeb.Models.ViewModels;
using Newtonsoft.Json;
using OrchardCore.Users.Services;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CmsBlogWeb.Business.Services
{
    public class OrchardCoreUserService : IOrchardCoreUserService
    {
        private readonly IUserService _userService;
        private readonly ICmsBlogDbAccessService _cmsBlogDbAccessService;

        public OrchardCoreUserService(IUserService userService, ICmsBlogDbAccessService cmsBlogDbAccessService)
        {
            _userService = userService;
            _cmsBlogDbAccessService = cmsBlogDbAccessService;
        }

        public async Task<OrchardCoreUserViewModel> GetOrchardCoreUser(ClaimsPrincipal user)
        {
            var lightTypedUser = await _userService.GetAuthenticatedUserAsync(user) as OrchardCore.Users.Models.User;

            var stronglyTypedUser = (OrchardCoreUserViewModel)lightTypedUser;

            if (lightTypedUser.Properties == null || lightTypedUser.Properties.Count == 0)
            {
                return stronglyTypedUser;
            }

            var userProperties = JsonConvert.DeserializeObject<OrchardCoreUserViewModel>(lightTypedUser.Properties.ToString());
            stronglyTypedUser.UserProfile = userProperties.UserProfile;

            return stronglyTypedUser;
        }

        public async Task UpdateUserDocumentData(OrchardCore.Users.Models.User user, string serializedData)
        {
            var commandText = "UPDATE [dbo].[Document] SET [Content] = @USER WHERE [Id] = @DOCID";
            var parameters = new Dictionary<string, string>(new List<KeyValuePair<string, string>> {
                KeyValuePair.Create("@USER", serializedData),
                KeyValuePair.Create("@DOCID", user.Id.ToString())
            });

            try
            {
                await _cmsBlogDbAccessService.ExecuteNonQuery(commandText, parameters);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task RemoveUserFromDatabase(OrchardCore.Users.Models.User user)
        {
            var deleteCommandText = @"
                    DELETE FROM [dbo].[UserByClaimIndex] WHERE [DocumentId] = @DOCID;
                    DELETE FROM [dbo].[UserByLoginInfoIndex] WHERE [DocumentId] = @DOCID;
                    DELETE FROM [dbo].[UserByRoleNameIndex_Document] WHERE [DocumentId] = @DOCID;
                    DELETE FROM [dbo].[UserIndex] WHERE [DocumentId] = @DOCID;
                    DELETE FROM [dbo].[Document] WHERE [Id] = @DOCID;
                ";

            var parameters = new Dictionary<string, string>(new List<KeyValuePair<string, string>> {
                KeyValuePair.Create("@DOCID", user.Id.ToString())
            });

            try
            {
                await _cmsBlogDbAccessService.ExecuteNonQuery(deleteCommandText, parameters);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}