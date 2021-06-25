using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StoreDSWI.Entities
{
    public class StoreDSWIUser : IdentityUser
    {
        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Apellidos")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Dirección")]
        public string Address { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(Microsoft.AspNet.Identity.UserManager<StoreDSWIUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
