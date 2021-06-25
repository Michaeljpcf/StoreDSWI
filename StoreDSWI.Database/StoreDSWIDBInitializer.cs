using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using StoreDSWI.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDSWI.Database
{
    public class StoreDSWIDBInitializer : CreateDatabaseIfNotExists<CBContext>
    {
        protected override void Seed(CBContext context)
        {
            SeedRoles(context);
            SeedUsers(context);
        }

        public void SeedRoles(CBContext context)
        {
            List<IdentityRole> rolesInStoreDSWI = new List<IdentityRole>();

            rolesInStoreDSWI.Add(new IdentityRole() { Name = "Administrador" });
            rolesInStoreDSWI.Add(new IdentityRole() { Name = "User" });

            var rolesStore = new RoleStore<IdentityRole>(context);
            var rolesManager = new RoleManager<IdentityRole>(rolesStore);

            foreach (IdentityRole role in rolesInStoreDSWI)
            {
                if (!rolesManager.RoleExists(role.Name))
                {
                    var result = rolesManager.Create(role);

                    if (result.Succeeded) continue;
                }
            }
        }

        public void SeedUsers(CBContext context)
        {
            var usersStore = new UserStore<StoreDSWIUser>(context);
            var usersManager = new UserManager<StoreDSWIUser>(usersStore);

            StoreDSWIUser admin = new StoreDSWIUser();
            admin.Name = "Admin";
            admin.LastName = "SomeName";
            admin.Address = "Hello World";
            admin.Email = "admin@email.com";
            admin.UserName = "admin";
            var password = "admin123";

            if (usersManager.FindByEmail(admin.Email) == null)
            {
                var result = usersManager.Create(admin, password);

                if (result.Succeeded)
                {
                    //add necesary roles to admin
                    usersManager.AddToRole(admin.Id, "Administrador");
                    usersManager.AddToRole(admin.Id, "User");
                }
            }
        }
    }
}
