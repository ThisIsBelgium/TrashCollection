using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System.Data.Entity;

[assembly: OwinStartupAttribute(typeof(TrashCollection.Startup))]
namespace TrashCollection
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }
        private void createRolesandUsers()
        {
            Models.ApplicationDbContext context = new Models.ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<Models.ApplicationUser>(new UserStore<Models.ApplicationUser>(context));
            if (!roleManager.RoleExists("admin"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "admin";
                roleManager.Create(role);

                var user = new Models.ApplicationUser();
                user.UserName = "thisisbelgium";
                user.Email = "daniel3wheeler@gmail.com";
                user.Address = "1325 n van buren";
                user.ZipCode = "53211";
                user.FirstName = "daniel";
                user.LastName = "wheeler";
                string userPassword = "thisisntbelgium";
                var checkUser = UserManager.Create(user, userPassword);
                if (checkUser.Succeeded)
                {
                    var result = UserManager.AddToRole(user.Id, "admin");
                }
            }
            if (!roleManager.RoleExists("customer"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "customer";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("employee"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "employee";
                roleManager.Create(role);
            }
        }
    }
}