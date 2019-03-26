using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.Models
{
    public partial class TestDbContext : DbContext
    {
        public TestDbContext()
        {
        }

        public TestDbContext(DbContextOptions<TestDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<CategoryPerProduct> CategoryPerProduct { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderLog> OrderLog { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductPerOrder> ProductPerOrder { get; set; }
        public virtual DbSet<Shop> Shop { get; set; }
        public virtual DbSet<Theme> Theme { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=mssql.fhict.local;Initial Catalog=dbi391176_elayed;Persist Security Info=False;User ID=dbi391176_elayed;Password=testappels123;Integrated Security=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address1).HasMaxLength(100);

                entity.Property(e => e.Address2).HasMaxLength(100);

                entity.Property(e => e.City).HasMaxLength(100);

                entity.Property(e => e.Company).HasMaxLength(100);

                entity.Property(e => e.Country).HasMaxLength(100);

                entity.Property(e => e.Firstname).HasMaxLength(100);

                entity.Property(e => e.Lastname).HasMaxLength(100);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.Postcode).HasMaxLength(50);

                entity.Property(e => e.StateCounty).HasMaxLength(100);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Address_User");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<CategoryPerProduct>(entity =>
            {
                entity.HasOne(d => d.Category)
                    .WithMany(p => p.CategoryPerProduct)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_CategoryPerProduct_Category");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CategoryPerProduct)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_CategoryPerProduct_Product");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email).HasMaxLength(150);

                entity.HasOne(d => d.BillingAddress)
                    .WithMany(p => p.OrderBillingAddress)
                    .HasForeignKey(d => d.BillingAddressId)
                    .HasConstraintName("FK_Order_Billing_Address");

                entity.HasOne(d => d.ShippingAddress)
                    .WithMany(p => p.OrderShippingAddress)
                    .HasForeignKey(d => d.ShippingAddressId)
                    .HasConstraintName("FK_Order_Shipping_Address");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.ShopId)
                    .HasConstraintName("FK_Order_Shop");
            });

            modelBuilder.Entity<OrderLog>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.LogText).HasColumnType("text");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderLog)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_OrderLog_Order");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.Sku)
                    .HasColumnName("SKU")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<ProductPerOrder>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.ProductPerOrder)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_ProductPerOrder_Order");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductPerOrder)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_ProductPerOrder_Product");
            });

            modelBuilder.Entity<Shop>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.Theme)
                    .WithMany(p => p.Shop)
                    .HasForeignKey(d => d.ThemeId)
                    .HasConstraintName("FK_Shop_Theme");
            });

            modelBuilder.Entity<Theme>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Settings).HasColumnType("text");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(150);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .HasMaxLength(128)
                    .IsUnicode(false);
            });
        }
    }
}
