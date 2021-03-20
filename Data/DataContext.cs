using MehrabaniCom.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MehrabaniCom.Data
{
    public class DataContext:IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        //DbSets
        public DbSet<cProducts> Products { get; set; }
        public DbSet<cComments> Comments { get; set; }
        public DbSet<cRatings> Ratings { get; set; }
        public DbSet<cUser> User { get; set; }
        public DbSet<cSellerType> SellerType { get; set; }

    }
}
