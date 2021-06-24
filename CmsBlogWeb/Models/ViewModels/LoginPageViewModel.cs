using CmsBlogWeb.Models.FormModels;

namespace CmsBlogWeb.Models.ViewModels
{
    public class LoginPageViewModel : PageViewModel
    {
        public LoginPageViewModel()
        {
            this.FormModel = new LoginFormModel();
        }

        public LoginFormModel FormModel { get; set; }
    }
}
