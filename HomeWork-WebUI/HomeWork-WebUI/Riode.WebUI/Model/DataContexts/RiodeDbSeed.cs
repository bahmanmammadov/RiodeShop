using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Riodetask.Model.Memberships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Riodetask.Model.DataContexts
{
    public static class RiodeDbSeed
    {
        public static IApplicationBuilder SeedMembership(this IApplicationBuilder builder)
        {
            using (var scope = builder.ApplicationServices.CreateScope())
            {
                var role = new RiodeRole
                {
                    Name = "SuperAdmin"

                };

                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<RiodeUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<RiodeRole>>();
                

                if (roleManager.RoleExistsAsync(role.Name).Result)
                {
                    role = roleManager.FindByNameAsync(role.Name).Result;
                }
                else
                {
                    var iReult = roleManager.CreateAsync(role).Result;
                    if (!iReult.Succeeded)
                    {
                        goto end;
                    }
                }
                string password = "123";
                
                var user = new RiodeUser
                {
                     UserName = "Bahman",
                     Email ="Bahman@mail.ru",
                     EmailConfirmed=true
                };


              var foundUser =  userManager.FindByEmailAsync(user.Email).Result;
                if (foundUser != null && !userManager.IsInRoleAsync(foundUser, role.Name).Result)
                {
                    userManager.AddToRoleAsync(foundUser , role.Name).Wait();
                }
                else if(foundUser == null)
                {
                    var  iCreateUser = userManager.CreateAsync(user, password).Result;
                    if (iCreateUser.Succeeded)
                    {
                        userManager.AddToRoleAsync(user, role.Name).Wait();

                    }

                }
            }

            end:
            return builder;
        }
    }
}
