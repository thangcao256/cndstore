using System.Data.Entity;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using CDNSTORES.Models.CDNSTORES;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


namespace CDNSTORES.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Birthday { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here          
            return userIdentity;

        }
    }

    //public static class GenericPrincipalExtensions
    //{
    //    public static string Name(this IPrincipal user)
    //    {
    //        if (user.Identity.IsAuthenticated)
    //        {
    //            ClaimsIdentity claimsIdentity = user.Identity as ClaimsIdentity;
    //            foreach (var claim in claimsIdentity.Claims)
    //            {
    //                if (claim.Type == "Name")
    //                    return claim.Value;
    //            }
    //            return "";
    //        }
    //        else
    //            return "";
    //    }
    //}




    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Color> Colors { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderInfo> OrderInfos { get; set; }
        public DbSet<Product> Products { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasRequired(c => c.Customer)
                .WithMany()
                .WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }

       
    }
    
}