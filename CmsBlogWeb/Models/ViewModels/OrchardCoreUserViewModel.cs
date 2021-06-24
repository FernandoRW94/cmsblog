using CmsBlogWeb.Models.ContentTypeModels;
using Microsoft.AspNetCore.Identity;
using OrchardCore.Users.Models;
using System.Collections.Generic;

namespace CmsBlogWeb.Models.ViewModels
{
    public class OrchardCoreUserViewModel
    {
        public string PasswordHash { get; set; }
        public IList<UserClaim> UserClaims { get; set; }
        public IList<string> RoleNames { get; set; }
        public string ResetToken { get; set; }
        public bool IsEnabled { get; set; }
        public bool EmailConfirmed { get; set; }
        public string SecurityStamp { get; set; }
        public IList<UserToken> UserTokens { get; set; }
        public string NormalizedEmail { get; set; }
        public string Email { get; set; }
        public string NormalizedUserName { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public int Id { get; set; }
        public IList<UserLoginInfo> LoginInfos { get; set; }

        public UserProfileContentTypeModel UserProfile { get; set; }

        public static explicit operator OrchardCoreUserViewModel(User v)
        {
            return new OrchardCoreUserViewModel
            {
                PasswordHash = v.PasswordHash,
                UserClaims = v.UserClaims,
                RoleNames = v.RoleNames,
                ResetToken = v.ResetToken,
                IsEnabled = v.IsEnabled,
                EmailConfirmed = v.EmailConfirmed,
                SecurityStamp = v.SecurityStamp,
                UserTokens = v.UserTokens,
                NormalizedEmail = v.NormalizedEmail,
                Email = v.Email,
                NormalizedUserName = v.NormalizedUserName,
                UserName = v.UserName,
                UserId = v.UserId,
                Id = v.Id,
                LoginInfos = v.LoginInfos
            };
        }
    }
}
