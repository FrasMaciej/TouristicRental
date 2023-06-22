using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TouristicRental.Models;

namespace TouristicRental.Data
{
    public class TouristicRentalContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public TouristicRentalContext (DbContextOptions<TouristicRentalContext> options)
            : base(options)
        {
        }

        public DbSet<TouristicRental.Models.Good> Goods { get; set; } = default!;
        public DbSet<TouristicRental.Models.FinanceRecord> Finances { get; set; } = default!;
        public DbSet<TouristicRental.Models.Order> Orders { get; set; } = default!;
        public DbSet<TouristicRental.Models.Worker> Workers { get; set; } = default!;
        public DbSet<TouristicRental.Models.Client> Clients { get; set; } = default!;
        //public DbSet<TouristicRental.Models.User> Users { get; set; } = default!;

    }
}
