using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using StoreDSWI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StoreDSWI.Services
{
    public class StoreDSWISignInManager : SignInManager<StoreDSWIUser, string>
    {
        public StoreDSWISignInManager(StoreDSWIUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(StoreDSWIUser user)
        {
            return user.GenerateUserIdentityAsync((StoreDSWIUserManager)UserManager);
        }

        public static StoreDSWISignInManager Create(IdentityFactoryOptions<StoreDSWISignInManager> options, IOwinContext context)
        {
            return new StoreDSWISignInManager(context.GetUserManager<StoreDSWIUserManager>(), context.Authentication);
        }
    }
}
