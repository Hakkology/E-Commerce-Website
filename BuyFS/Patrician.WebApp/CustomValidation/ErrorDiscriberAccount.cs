using Microsoft.AspNetCore.Identity;

namespace Patrician.WebApp.CustomValidation
{
    //This field would allow us to create custom error messsages for specific cases.
    public class ErrorDiscriberAccount:IdentityErrorDescriber
    {
        public override IdentityError PasswordRequiresLower()
        {
            var error = new IdentityError();
            error.Code = "Passwordfailure";
            error.Description = "Please use lower case letters for your password.";
            return base.PasswordRequiresLower();
        }
    }
}
