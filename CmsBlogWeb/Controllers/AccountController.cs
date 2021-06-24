using CmsBlogWeb.Business;
using CmsBlogWeb.Business.Services.Interfaces;
using CmsBlogWeb.Models;
using CmsBlogWeb.Models.FormModels;
using CmsBlogWeb.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OrchardCore;
using OrchardCore.ContentManagement;
using OrchardCore.Users;
using OrchardCore.Users.Services;
using System;
using System.Threading.Tasks;

namespace CmsBlogWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IOrchardHelper _orchardHelper;
        private readonly IContentManager _contentManager;
        private readonly IOrchardCoreContentService _orchardCoreContentService;
        private readonly IOrchardCoreUserService _orchardCoreUserService;
        private readonly IUserService _userService;
        private readonly SignInManager<IUser> _signInManager;
        private readonly UserManager<IUser> _userManager;

        public AccountController(
            ILogger<AccountController> logger,
            IOrchardHelper orchardHelper,
            IUserService userService,
            SignInManager<IUser> signInManager,
            IOrchardCoreContentService orchardCoreContentHelperService,
            IOrchardCoreUserService orchardCoreUserService,
            IContentManager contentManager,
            UserManager<IUser> userManager)
        {
            _logger = logger;
            _orchardHelper = orchardHelper;
            _userService = userService;
            _signInManager = signInManager;
            _orchardCoreContentService = orchardCoreContentHelperService;
            _orchardCoreUserService = orchardCoreUserService;
            _contentManager = contentManager;
            _userManager = userManager;
        }

        [HttpGet("/login")]
        public async Task<IActionResult> Login()
        {
            var currentUser = await _userService.GetAuthenticatedUserAsync(User) as OrchardCore.Users.Models.User;

            if (currentUser != null)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = await _orchardCoreContentService.GetTypedObject<LoginPageViewModel>(Constants.PageAliases.LoginPage);
            if(model == null)
            {
                model = new LoginPageViewModel()
                {
                    FormModel = new LoginFormModel()
                };
            }
            
            return View(model);
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Login(LoginFormModel model)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            var loginViewModel = await _orchardCoreContentService.GetTypedObject<LoginPageViewModel>(Constants.PageAliases.LoginPage);
            if (loginViewModel == null)
            {
                loginViewModel = new LoginPageViewModel();
            }

            loginViewModel.FormModel = model;

            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if(user == null)
            {
                ModelState.AddModelError("Email", "Something wrong happened. Please try again later.");
                return View(loginViewModel);
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, false);
            if(!result.Succeeded)
            {
                ModelState.AddModelError("Email", "Something wrong happened. Please try again later.");
                return View(loginViewModel);
            }

            var userCasted = user as OrchardCore.Users.Models.User;
            if (userCasted.RoleNames.Contains(Constants.UserRoles.Administrator))
            {
                return Redirect("/admin");
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet("/register")]
        public async Task<IActionResult> Register()
        {
            var currentUser = await _userService.GetAuthenticatedUserAsync(User) as OrchardCore.Users.Models.User;

            if (currentUser != null)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = await _orchardCoreContentService.GetTypedObject<RegisterPageViewModel>(Constants.PageAliases.RegisterPage);
            model.FormModel.SubmitButtonText = model.RegisterPage.SubmitButtonText.Text;
            model.FormModel.FormTitleText = model.RegisterPage.FormTitleText.Text;

            return View(model);
        }

        [HttpPost("/register")]
        public async Task<IActionResult> Register(RegisterFormModel model)
        {
            var currentUser = await _userService.GetAuthenticatedUserAsync(User) as OrchardCore.Users.Models.User;

            if (currentUser != null)
            {
                return RedirectToAction("Index", "Home");
            }

            var pageModel = await _orchardCoreContentService.GetTypedObject<RegisterPageViewModel>(Constants.PageAliases.RegisterPage);
            pageModel.FormModel = model;

            if (!ModelState.IsValid)
            {
                return View(pageModel);
            }

            var createdUser = await _userService.CreateUserAsync(new OrchardCore.Users.Models.User
                {
                    UserName = model.Username,
                    Email = model.Email,
                    RoleNames = { Constants.UserRoles.User }
                },
                model.Password, (string field, string error) => {
                    ModelState.AddModelError(field, error);
                }) as OrchardCore.Users.Models.User;

            if(ModelState.ErrorCount > 0)
            {
                return View(pageModel);
            }

            var userProfileContentType = await _contentManager.NewAsync("UserProfile");
            var newUserSerialized = JsonConvert.SerializeObject(new
            {
                Id = createdUser.Id,
                UserId = createdUser.UserId,
                UserName = createdUser.UserName,
                NormalizedUserName = createdUser.NormalizedUserName,
                Email = createdUser.Email,
                NormalizedEmail = createdUser.NormalizedEmail,
                SecurityStamp = createdUser.SecurityStamp,
                EmailConfirmed = createdUser.EmailConfirmed,
                IsEnabled = createdUser.IsEnabled,
                RoleNames = createdUser.RoleNames,
                UserClaims = createdUser.UserClaims,
                LoginInfos = createdUser.LoginInfos,
                UserTokens = createdUser.UserTokens,
                Properties = new
                {
                    UserProfile = new
                    {
                        ContentItemId = userProfileContentType.ContentItemId,
                        ContentItemVersionId = userProfileContentType.ContentItemVersionId,
                        ContentType = userProfileContentType.ContentType,
                        DisplayText = userProfileContentType.DisplayText,
                        Latest = userProfileContentType.Latest,
                        Published = userProfileContentType.Published,
                        ModifiedUtc = userProfileContentType.ModifiedUtc,
                        PublishedUtc = userProfileContentType.PublishedUtc,
                        CreatedUtc = userProfileContentType.CreatedUtc,
                        Owner = userProfileContentType.Owner,
                        Author = userProfileContentType.Author,
                        UserProfile = new
                        {
                            FirstName = new
                            {
                                Text = model.FirstName
                            },
                            LastName = new
                            {
                                Text = model.LastName
                            },
                            DateOfBirth = new
                            {
                                Value = model.DateOfBirth
                            },
                            AgreeWithTerms = new
                            {
                                Value = model.AgreeWithTerms
                            },
                            EmailVerified = new
                            {
                                Value = false
                            },
                        }
                    }
                }
            });

            try
            {
                await _orchardCoreUserService.UpdateUserDocumentData(createdUser, newUserSerialized);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"AccountController.Register. ERROR. {ex.Message}");
               
                try
                {
                    await _orchardCoreUserService.RemoveUserFromDatabase(createdUser);
                }
                catch(Exception ex2)
                {
                    _logger.LogError(ex2, $"AccountController.Register. ERROR. {ex2.Message}");
                }

                ViewBag.ErrorSavingData = "Something went wrong trying to register you. Please try again. If the error persists get in contact with the support team.";
                
                return View(pageModel);
            }

            return RedirectToAction("Login", "Account");
        }
    }
}
