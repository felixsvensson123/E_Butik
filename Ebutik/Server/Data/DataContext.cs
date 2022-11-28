using Microsoft.EntityFrameworkCore;
using System.Security.Policy;

namespace BlazorEcom.Server.Data;

public class DataContext : IdentityDbContext<ApplicationUser>
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<ApplicationUser> Customers { get; set; }
      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
        base.OnModelCreating(modelBuilder);

        var Hash = new PasswordHasher<ApplicationUser>();
        var CustomerRole = new IdentityRole() { Name = "Customer", NormalizedName = "CUSTOMER", Id = "d153c726-e709-4946-824b-0ed63bbf136a" };
        var StaffRole = new IdentityRole() { Name = "Staff", NormalizedName = "STAFF", Id = "d7fc4ba6-4957-41a7-96b5-52b65c06bc35" };
        var AdminRole = new ApplicationUser()
        {
            Id = "d7fc4ba6-4957-41a7-96b5-52b65c06bc35",
            Email = "Admin@Mail.com",
            UserName = "admin",
            CustomerName = "Admin Account",
            Adress = "Malmö Stad",
            NormalizedEmail = "ADMIN@MAIL.COM",
            NormalizedUserName = "ADMIN@MAIL.COM",
            EmailConfirmed = true,
            PasswordHash = Hash.HashPassword(null!, "qwe123")
          
        };
    
        modelBuilder.Entity<IdentityRole>().HasData(CustomerRole, StaffRole);
        modelBuilder.Entity<ApplicationUser>().HasData(AdminRole);

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>()
        {
            RoleId = AdminRole.Id,
            UserId = StaffRole.Id,
        });

        modelBuilder.Entity<ProductModel>().HasData(new ProductModel()
              {
                  Id = 1,
                  Name = "Coke",
                  Category = "Sodas",
                  Stock = 122,
                  Loaned = false,
                  ImgUrl = "https://media.istockphoto.com/id/458669357/sv/foto/coca-cola-can.jpg?s=612x612&w=is&k=20&c=lKdYVD9ThwyI5OWmMatT02wSAJu_u2wPO83c167sO2g=",
                  Price = 12.50,
              }
          );
          modelBuilder.Entity<ProductModel>().HasData(new ProductModel()
              {
                  Id = 2,
                  Name = "Fanta",
                  Category = "Sodas",
                  Stock = 62,
                  Loaned = false,
                  ImgUrl = "https://media.istockphoto.com/id/458669357/sv/foto/coca-cola-can.jpg?s=612x612&w=is&k=20&c=lKdYVD9ThwyI5OWmMatT02wSAJu_u2wPO83c167sO2g=",
                  Price = 12.50,
              }
          );
      }
}