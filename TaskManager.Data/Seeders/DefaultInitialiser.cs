using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TaskManager.Entities;

namespace TaskManager.Data.Seeders
{
    public class DefaultInitialiser : DropCreateDatabaseAlways<TaskManagerContext>
    {
        protected override void Seed(TaskManagerContext context)
        {
            var adminRoleId = Guid.NewGuid().ToString();
            var managerRoleId = Guid.NewGuid().ToString();

            var adminRole = new IdentityRole
            {
                Id = adminRoleId,
                Name = "Administrator"
            };

            var managerRole = new IdentityRole
            {
                Id = managerRoleId,
                Name = "Manager"
            };

            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            roleManager.Create(adminRole);
            roleManager.Create(managerRole);

            var rootUser = new User
            {
                UserName = "nickcoad@gmail.com",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                GivenName = "Nick",
                Surname = "Coad",
                Email = "nickcoad@gmail.com"
            };

            var userStore = new UserStore<User>(context);
            var userManager = new UserManager<User>(userStore);

            userManager.Create(rootUser, "password");
            userManager.AddToRole(rootUser.Id, "Administrator");

            context.SaveChanges();
        }
    }
}
