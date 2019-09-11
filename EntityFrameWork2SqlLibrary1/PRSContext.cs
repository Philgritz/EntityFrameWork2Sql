using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EntityFrameWork2SqlLibrary1
{
    public partial class PRSContext : DbContext
    {
        public PRSContext()
        {
        }

        public PRSContext(DbContextOptions<PRSContext> options)  //another constructor.  calling base constructor(db context constructor)
            : base(options)
        {
        }

        public virtual DbSet<Products> Products { get; set; }  //communicate with db from these collection variables
        public virtual DbSet<Request> Request { get; set; }   //must add one of these properties to access db when adding tables
        public virtual DbSet<RequestLine> RequestLine { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Vendors> Vendors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies();  //not generated
                optionsBuilder.UseSqlServer("server=localhost\\sqlexpress;database=PRS;trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasIndex(e => e.PartNbr)
                    .HasName("UQ__Product__DAFC0C1E67562CDA")
                    .IsUnique();

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.VendorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product__VendorI__52593CB8");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.Property(e => e.DeliveryMode).HasDefaultValueSql("('pickup')");

                entity.Property(e => e.Status).HasDefaultValueSql("('NEW')");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Request)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Request__UserId__5812160E");
            });

            modelBuilder.Entity<RequestLine>(entity =>
            {
                entity.Property(e => e.Quantity).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.RequestLine)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RequestLi__Produ__5BE2A6F2");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.RequestLine)
                    .HasForeignKey(d => d.RequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RequestLi__Reque__5AEE82B9");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasIndex(e => e.Username)
                    .HasName("UQ__USER__536C85E4D7AD3D8A")
                    .IsUnique();

                entity.Property(e => e.IsAdmin).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsReviewer).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Vendors>(entity =>  //fluent API
            {
                entity.HasIndex(e => e.Code)
                    .HasName("UQ__Vendor__A25C5AA73F84ADD1")
                    .IsUnique();
            });
        }
    }
}
