using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace server_travel.Entities;

public partial class TravelApiContext : DbContext
{
    public TravelApiContext()
    {
    }

    public TravelApiContext(DbContextOptions<TravelApiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Resort> Resorts { get; set; }

    public virtual DbSet<Restaurant> Restaurants { get; set; }

    public virtual DbSet<Tour> Tours { get; set; }

    public virtual DbSet<Touristspot> Touristspots { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

   // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=QUAN68;Initial Catalog=travel_api;Integrated Security=True; TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__hotels__3213E83F47977C99");

            entity.ToTable("hotels");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(250)
                .HasColumnName("address");
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("contactNumber");
            entity.Property(e => e.Location)
                .HasMaxLength(250)
                .HasColumnName("location");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .HasColumnName("name");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.SpotId).HasColumnName("spotId");

            entity.HasOne(d => d.Spot).WithMany(p => p.Hotels)
                .HasForeignKey(d => d.SpotId)
                .HasConstraintName("FK__hotels__spotId__4E88ABD4");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__images__3213E83F79A33295");

            entity.ToTable("images");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.HotelId).HasColumnName("hotelId");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("imageUrl");
            entity.Property(e => e.ResortId).HasColumnName("resortId");
            entity.Property(e => e.RestaurantId).HasColumnName("restaurantId");
            entity.Property(e => e.SpotId).HasColumnName("spotId");

            entity.HasOne(d => d.Hotel).WithMany(p => p.Images)
                .HasForeignKey(d => d.HotelId)
                .HasConstraintName("FK__images__hotelId__5CD6CB2B");

            entity.HasOne(d => d.Resort).WithMany(p => p.Images)
                .HasForeignKey(d => d.ResortId)
                .HasConstraintName("FK__images__resortId__5DCAEF64");

            entity.HasOne(d => d.Restaurant).WithMany(p => p.Images)
                .HasForeignKey(d => d.RestaurantId)
                .HasConstraintName("FK__images__restaura__5EBF139D");

            entity.HasOne(d => d.Spot).WithMany(p => p.Images)
                .HasForeignKey(d => d.SpotId)
                .HasConstraintName("FK__images__spotId__5FB337D6");
        });

        modelBuilder.Entity<Resort>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__resorts__3213E83FCFD0CDD2");

            entity.ToTable("resorts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(250)
                .HasColumnName("address");
            entity.Property(e => e.Cacilities)
                .HasMaxLength(250)
                .HasColumnName("cacilities");
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("contactNumber");
            entity.Property(e => e.Location)
                .HasMaxLength(250)
                .HasColumnName("location");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .HasColumnName("name");
            entity.Property(e => e.SpotId).HasColumnName("spotId");

            entity.HasOne(d => d.Spot).WithMany(p => p.Resorts)
                .HasForeignKey(d => d.SpotId)
                .HasConstraintName("FK__resorts__spotId__5441852A");
        });

        modelBuilder.Entity<Restaurant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__restaura__3213E83FF2E08E5A");

            entity.ToTable("restaurants");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(250)
                .HasColumnName("address");
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("contactNumber");
            entity.Property(e => e.CuisineType)
                .HasMaxLength(250)
                .HasColumnName("cuisineType");
            entity.Property(e => e.Location)
                .HasMaxLength(250)
                .HasColumnName("location");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .HasColumnName("name");
            entity.Property(e => e.SpotId).HasColumnName("spotId");

            entity.HasOne(d => d.Spot).WithMany(p => p.Restaurants)
                .HasForeignKey(d => d.SpotId)
                .HasConstraintName("FK__restauran__spotI__5165187F");
        });

        modelBuilder.Entity<Tour>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tours__3213E83FA2BEF46B");

            entity.ToTable("tours");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.SpotId).HasColumnName("spotId");
            entity.Property(e => e.TravelDate)
                .HasColumnType("date")
                .HasColumnName("travelDate");

            entity.HasOne(d => d.Spot).WithMany(p => p.Tours)
                .HasForeignKey(d => d.SpotId)
                .HasConstraintName("FK__tours__spotId__4BAC3F29");
        });

        modelBuilder.Entity<Touristspot>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tourists__3213E83F0CCAB314");

            entity.ToTable("touristspots");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Location)
                .HasMaxLength(350)
                .HasColumnName("location");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83FF89A88D3");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "UQ__users__AB6E616434C83F40").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Birthday)
                .HasColumnType("date")
                .HasColumnName("birthday");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.JobTitle)
                .HasMaxLength(250)
                .HasColumnName("jobTitle");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.RoleTitle)
                .HasMaxLength(250)
                .HasColumnName("roleTitle");
            entity.Property(e => e.Tel)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("tel");
            entity.Property(e => e.Token)
                .HasMaxLength(250)
                .HasColumnName("token");
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__vehicles__3213E83F8F7FEB7D");

            entity.ToTable("vehicles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .HasColumnName("name");
            entity.Property(e => e.SpotId).HasColumnName("spotId");
            entity.Property(e => e.Type)
                .HasMaxLength(250)
                .HasColumnName("type");

            entity.HasOne(d => d.Spot).WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.SpotId)
                .HasConstraintName("FK__vehicles__spotId__571DF1D5");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
