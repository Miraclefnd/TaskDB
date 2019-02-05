using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TaskDB.Models
{
    public class AppDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var role_1 = new IdentityRole{Name = "admin"};
            var role_2 = new IdentityRole{Name = "user"};

            roleManager.Create(role_1);
            roleManager.Create(role_2);

            var admin = new ApplicationUser {Email = "danielsmithld@gmail.com", Firstname = "Daniil", Surname = "Manita",Login = "Danser",UserName = "danielsmithld@gmail.com",  EmailConfirmed = true};
            string password = "Danser73#";
            var result = userManager.Create(admin, password);

            if (result.Succeeded)
            {
                userManager.AddToRole(admin.Id, role_1.Name);
                userManager.AddToRole(admin.Id, role_2.Name);
            }
            base.Seed(context);
        }
    }
}