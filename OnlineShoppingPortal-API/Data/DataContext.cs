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
            modelBuilder.Entity<Customer>()
                .ToTable("User");


            modelBuilder.Seed();

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseLazyLoadingProxies();
        //}

        // just as line 42 customer model is user table as roles are defined as well
        public DbSet<Customer> Users { get; set; }
        public DbSet<Segment> Segments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<BrandProduct> BrandProducts { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<CardDetail> CardDetails { get; set; }

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

            modelBuilder.Entity<Customer>().HasData(
              // seeded admin user because registeration is set for USER roles only
              // admin password : admin123
              new Customer() { CustomerId = 1, FirstName = "Master", LastName = "User", UserName = "AdminMasterUser01", EmailId = "adminuser@mail.com", Password = "0VT5s7zLvBycKO1sFrhtcBIQICNCmqPspfmuWpBESX/XSKx3", Role = "admin" }
              );

            modelBuilder.Entity<Brand>().HasData(
              new Brand() { BrandId = 1, CategoryId = 101, BrandName = "Pasar" },
              new Brand() { BrandId = 2, CategoryId = 101, BrandName = "TasteMaxx" },
              new Brand() { BrandId = 3, CategoryId = 102, BrandName = "FairP" },
              new Brand() { BrandId = 4, CategoryId = 103, BrandName = "Deli" },
              new Brand() { BrandId = 5, CategoryId = 103, BrandName = "Nutri GO" },
              new Brand() { BrandId = 6, CategoryId = 104, BrandName = "Quechzxc" }
              );

            modelBuilder.Entity<Product>().HasData(
              new Product() { ProductId = 1, ProductName = "Leek", ProductDescription = "A green vegetable", ProductModel = "66A", ProductPrice = 30 },
              new Product() { ProductId = 2, ProductName = "Carrot", ProductDescription = "An orange edible, safe for consumption", ProductModel = "67B", ProductPrice = 50 },
              new Product() { ProductId = 3, ProductName = "Apple", ProductDescription = "A red, juicy and sweet fruit", ProductModel = "68X", ProductPrice = 70 },
              new Product() { ProductId = 4, ProductName = "Honey Dew", ProductDescription = "Top grade, Japan Import, perishable, good for gifts", ProductModel = "69Z", ProductPrice = 5000 },
              new Product() { ProductId = 5, ProductName = "Nugget", ProductDescription = "(1kg) Savory, munchable, to-go, kids love it!", ProductModel = "70S", ProductPrice = 300 },
              new Product() { ProductId = 6, ProductName = "Sandwich", ProductDescription = "Mini-ones for quick breakfast on busy days", ProductModel = "71M", ProductPrice = 250 },
              new Product() { ProductId = 7, ProductName = "Diet Coke", ProductDescription = "For guilty diet, sweet, no sugar added", ProductModel = "72L", ProductPrice = 30 },
              new Product() { ProductId = 8, ProductName = "Pepsi", ProductDescription = "Just like Coke but blue can, maybe better", ProductModel = "73P", ProductPrice = 30 },
              new Product() { ProductId = 9, ProductName = "Pomelo", ProductDescription = "Sweet and sour fruit, non-seasonal", ProductModel = "74K", ProductPrice = 300 },
              new Product() { ProductId = 10, ProductName = "Cabbage", ProductDescription = "Be it in soup or fried dishes, a versatile veg", ProductModel = "75D", ProductPrice = 350 },
              new Product() { ProductId = 11, ProductName = "Golden Grape", ProductDescription = "One of a kind, limited edition grapes, natural gold", ProductModel = "76B", ProductPrice = 3000 },
              new Product() { ProductId = 12, ProductName = "Bitter Gourd", ProductDescription = "A vegetable that requires an acquired taste", ProductModel = "77Q", ProductPrice = 304 }
              );

            modelBuilder.Entity<BrandProduct>().HasData(
                new BrandProduct() { BrandId = 1, ProductId = 1 },
                new BrandProduct() { BrandId = 2, ProductId = 2 },
                new BrandProduct() { BrandId = 3, ProductId = 3 },
                new BrandProduct() { BrandId = 3, ProductId = 4 },
                new BrandProduct() { BrandId = 4, ProductId = 5 },
                new BrandProduct() { BrandId = 5, ProductId = 6 },
                new BrandProduct() { BrandId = 6, ProductId = 7 },
                new BrandProduct() { BrandId = 6, ProductId = 8 },
                new BrandProduct() { BrandId = 1, ProductId = 9 },
                new BrandProduct() { BrandId = 1, ProductId = 10 },
                new BrandProduct() { BrandId = 1, ProductId = 11 },
                new BrandProduct() { BrandId = 1, ProductId = 12 }
                );














        }
    }
}
