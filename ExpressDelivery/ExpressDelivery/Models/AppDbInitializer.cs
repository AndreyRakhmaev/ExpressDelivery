using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace ExpressDelivery.Models
{
    public class AppDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // создаем роли
            var roleAdmin = new IdentityRole { Name = "admin" };
            var roleUser = new IdentityRole { Name = "user" };
            var managerRole = new IdentityRole { Name = "user" };

            // добавляем роли в бд
            roleManager.Create(roleAdmin);
            roleManager.Create(roleUser);

            // создаем пользователей
            var admin = new ApplicationUser { Email = "admin@test.ru", UserName = "admin@test.ru" };
            string password = "Aa12345_";
            var result = userManager.Create(admin, password);

            var user = new ApplicationUser { Email = "user@test.ru", UserName = "user@test.ru" };
            string passwordUser = "Aa12345_";
            var resultUser = userManager.Create(user, passwordUser);

            var manager = new ApplicationUser { Email = "manager@test.ru", UserName = "manager@test.ru" };
            string passwordManager = "Aa12345_";
            var resultManager = userManager.Create(manager, passwordManager);

            // если создание пользователя прошло успешно
            if (result.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(admin.Id, roleAdmin.Name);
            }

            if (resultUser.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(user.Id, roleUser.Name);
            }

            if (resultManager.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(manager.Id, managerRole.Name);
            }

            base.Seed(context);
        }
    }
}