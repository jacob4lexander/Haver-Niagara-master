using Haver_Niagara.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Haver_Niagara.Data
{
    public static class ApplicationDbInitializer //followed from video / took from previous mvc course
    {
        public static async void Seed(IApplicationBuilder applicationBuilder)
        {
            ApplicationDbContext context = applicationBuilder.ApplicationServices.CreateScope()
                .ServiceProvider.GetRequiredService<ApplicationDbContext>();
            try
            {
                //Create the database if it does not exist and apply the Migration
                context.Database.Migrate();

                //DO NOT HAVE ENSURE DELETED OR ANYTHING LIKE THAT
                //Create Roles
                var RoleManager = applicationBuilder.ApplicationServices.CreateScope()
                    .ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                string[] roleNames = { "Admin", "Quality Representative",  //Role Names a User can be assigned
                                       "Engineer", "Procurement", "Operations", "Finance" };
                IdentityResult roleResult;
                foreach (var roleName in roleNames)
                {
                    var roleExist = await RoleManager.RoleExistsAsync(roleName);
                    if (!roleExist)
                    {
                        roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                    }
                }
                //Create Users
                var userManager = applicationBuilder.ApplicationServices.CreateScope()
                    .ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

       
                //Admin
                if (userManager.FindByEmailAsync("admin@outlook.com").Result == null)
                {
                    ApplicationUser user = new ApplicationUser
                    {
                        FirstName = "Admin",
                        LastName = "Power",
                        UserName = "admin@outlook.com",
                        Email = "admin@outlook.com",
                        EmailConfirmed = true
                    };

                    IdentityResult result = userManager.CreateAsync(user, "rx5g8E^xGYy").Result; //If you are going to set a custom password,
                                                                                              //Is must not break the constraints found in program.cs
                    if (result.Succeeded)                                                     //for simplicity I disabled some constraints
                    {                                                                         //so instead of having to use something like P@5w0rd! just use password
                        userManager.AddToRoleAsync(user, "Admin").Wait();
                    }
                }
                //Quality Representative Stuff
                if (userManager.FindByEmailAsync("qualityrepresentative@outlook.com").Result == null)
                {
                    ApplicationUser user = new ApplicationUser
                    {
                        FirstName = "Quality",
                        LastName = "User",
                        UserName = "qualityrepresentative@outlook.com",
                        Email = "qualityrepresentative@outlook.com",
                        EmailConfirmed = true
                    };

                    IdentityResult result = userManager.CreateAsync(user, "s?og1oyQ~RD").Result;

                    if (result.Succeeded)
                    {
                        userManager.AddToRoleAsync(user, "Quality Representative").Wait();
                    }
                }
                //Engineer
                if (userManager.FindByEmailAsync("engineer@outlook.com").Result == null)
                {
                    ApplicationUser user = new ApplicationUser
                    {
                        FirstName = "Engineer",
                        LastName = "User",
                        UserName = "engineer@outlook.com",
                        Email = "engineer@outlook.com",
                        EmailConfirmed = true
                    };

                    IdentityResult result = userManager.CreateAsync(user, "5Z6uwE9!R~x").Result;

                    if (result.Succeeded)
                    {
                        userManager.AddToRoleAsync(user, "Engineer").Wait();
                    }
                }
                //Procurement
                if (userManager.FindByEmailAsync("procurement@outlook.com").Result == null)
                {
                    ApplicationUser user = new ApplicationUser
                    {
                        FirstName = "Procurement",
                        LastName = "User",
                        UserName = "procurement@outlook.com",
                        Email = "procurement@outlook.com",
                        EmailConfirmed = true
                    };

                    IdentityResult result = userManager.CreateAsync(user, "w3gAr?MQ^VD").Result;

                    if (result.Succeeded)
                    {
                        userManager.AddToRoleAsync(user, "Procurement").Wait();
                    }
                }

                //Operations Stuff
                if (userManager.FindByEmailAsync("operations@outlook.com").Result == null)
                {
                    ApplicationUser user = new ApplicationUser
                    {
                        FirstName = "Operations",
                        LastName = "User",
                        UserName = "operations@outlook.com",
                        Email = "operations@outlook.com",
                        EmailConfirmed = true
                    };

                    IdentityResult result = userManager.CreateAsync(user, "Gc3ov?J63sF").Result;

                    if (result.Succeeded)
                    {
                        userManager.AddToRoleAsync(user, "Operations").Wait();
                    }
                }
                //Finance Stuff
                if (userManager.FindByEmailAsync("finance@outlook.com").Result == null)
                {
                    ApplicationUser user = new ApplicationUser
                    {
                        FirstName = "Finance",
                        LastName = "User",
                        UserName = "finance@outlook.com",
                        Email = "finance@outlook.com",
                        EmailConfirmed = true
                    };

                    IdentityResult result = userManager.CreateAsync(user, "Gc2JSJ63sF").Result;

                    if (result.Succeeded)
                    {
                        userManager.AddToRoleAsync(user, "Finance").Wait();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.GetBaseException().Message);
            }
        }
    }
}
