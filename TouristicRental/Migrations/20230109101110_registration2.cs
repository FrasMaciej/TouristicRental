using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TouristicRental.Data;
using TouristicRental.Models;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Security.Policy;

#nullable disable

namespace TouristicRental.Migrations
{
    /// <inheritdoc />
    public partial class registration2 : Migration
    {
        //private readonly UserManager<IdentityUser> _userManager;
        //private readonly RoleManager<IdentityRole> _roleManager;
        //private readonly IUserStore<IdentityUser> _userStore;
        //private readonly IUserEmailStore<IdentityUser> _emailStore;
        //private readonly ILogger<RegisterModel> _logger;
        //private readonly TouristicRentalContext _context;

        //public registration2(RoleManager<IdentityRole> roleManager, 
        //    UserManager<IdentityUser> userManager,
        //    IUserStore<IdentityUser> userStore)
        //{
        //    _roleManager = roleManager;
        //    _userManager = userManager;
        //    _userStore = userStore;
        //}

        /// <inheritdoc />
        protected async override void Up(MigrationBuilder migrationBuilder)
        {
            //await _roleManager.CreateAsync(new IdentityRole("Client"));
            //await _roleManager.CreateAsync(new IdentityRole("Worker"));

            //var user = CreateUser();

            //await _userStore.SetUserNameAsync(user, "jan.nowak@gmail.com", CancellationToken.None);
            //await _emailStore.SetEmailAsync(user, "jan.nowak@gmail.com", CancellationToken.None);
            //var result = _userManager.CreateAsync(user, "JanNowak123_");

            //_logger.LogInformation("User created a new account with password.");
            //IdentityResult roleresult = await _userManager.AddToRoleAsync(user, "Client");
            //var userId = await _userManager.GetUserIdAsync(user);
        }

        //private IdentityUser CreateUser()
        //{
        //    try
        //    {
        //        return Activator.CreateInstance<IdentityUser>();
        //    }
        //    catch
        //    {
        //        throw new InvalidOperationException($"Can't create an instance of '{nameof(IdentityUser)}'. " +
        //            $"Ensure that '{nameof(IdentityUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
        //            $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
        //    }
        //}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
