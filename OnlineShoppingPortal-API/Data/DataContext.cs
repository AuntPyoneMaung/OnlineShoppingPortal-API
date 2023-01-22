using Microsoft.EntityFrameworkCore;
using OnlineShoppingPortal_API.Models;

namespace OnlineShoppingPortal_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BrandProduct>()
                .HasKey(bc => new { bc.BrandId, bc.ProductId });
            modelBuilder.Entity<BrandProduct>()
                .HasOne(bc => bc.Brand)
                .WithMany(b => b.BrandProducts)
                .HasForeignKey(bc => bc.BrandId);
            modelBuilder.Entity<BrandProduct>()
                .HasOne(bc => bc.Product)
                .WithMany(c => c.BrandProducts)
                .HasForeignKey(bc => bc.ProductId);

            // 1-M user-customer
            modelBuilder.Entity<Customer>()
                .HasOne(u => u.User)
                .WithOne(c => c.Customer)
                .HasForeignKey<Customer>(u => u.UserId);

            modelBuilder.Entity<Customer>()
                .ToTable("Customer");
            modelBuilder.Entity<Segment>()
                .ToTable("Segment");
            modelBuilder.Entity<Category>()
                .ToTable("Category");
            modelBuilder.Entity<Brand>()
                .ToTable("Brand");
            modelBuilder.Entity<Product>()
                .ToTable("Product");
            modelBuilder.Entity<Cart>()
                .ToTable("Cart");
            modelBuilder.Entity<Payment>()
                .ToTable("Payment");
            modelBuilder.Entity<CartItem>()
                .ToTable("CartItem");
            modelBuilder.Entity<CardDetail>()
                .ToTable("CardDetail");
            modelBuilder.Entity<User>()
                .ToTable("User");

            modelBuilder.Seed();

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseLazyLoadingProxies();
        //}


        public DbSet<Customer> Customers { get; set; }
        public DbSet<Segment> Segments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<BrandProduct> BrandProducts { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<CardDetail> CardDetails { get; set; }
        public DbSet<User> Users { get; set; }

    }

    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Segment>().HasData(
              new Segment() { SegmentId = 101, SegmentName = "Organic" },
              new Segment() { SegmentId = 102, SegmentName = "Halal" },
              new Segment() { SegmentId = 103, SegmentName = "On-the-Go" }
              );

            modelBuilder.Entity<Category>().HasData(
              new Category() { CategoryId = 101, SegmentId = 101, CategoryName = "Vegetables" },
              new Category() { CategoryId = 102, SegmentId = 101, CategoryName = "Fruits" },
              new Category() { CategoryId = 103, SegmentId = 103, CategoryName = "Finger Food" },
              new Category() { CategoryId = 104, SegmentId = 103, CategoryName = "Drinks" }
              );

            modelBuilder.Entity<User>().HasData(
              new User() { UserId = 001, FirstName = "Master", LastName = "User", UserName = "AdminMasterUser01", EmailId = "adminuser@mail.com", Password = "0VT5s7zLvBycKO1sFrhtcBIQICNCmqPspfmuWpBESX/XSKx3", Role = "admin" }
              );














        }
    }
}
