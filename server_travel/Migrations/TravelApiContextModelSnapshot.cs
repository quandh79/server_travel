﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using server_travel.Entities;

#nullable disable

namespace server_travel.Migrations
{
    [DbContext(typeof(TravelApiContext))]
    partial class TravelApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("server_travel.Entities.District", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Districts");
                });

            modelBuilder.Entity("server_travel.Entities.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("server_travel.Entities.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("address");

                    b.Property<string>("ContactNumber")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("char(15)")
                        .HasColumnName("contactNumber")
                        .IsFixedLength();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DistrictId")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("location");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("name");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("Rating")
                        .HasColumnType("int")
                        .HasColumnName("rating");

                    b.Property<int?>("SpotId")
                        .HasColumnType("int")
                        .HasColumnName("spotId");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__hotels__3213E83F47977C99");

                    b.HasIndex("DistrictId");

                    b.HasIndex("SpotId");

                    b.ToTable("hotels", (string)null);
                });

            modelBuilder.Entity("server_travel.Entities.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DistrictId")
                        .HasColumnType("int");

                    b.Property<int?>("HotelId")
                        .HasColumnType("int")
                        .HasColumnName("hotelId");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("imageUrl");

                    b.Property<int?>("ResortId")
                        .HasColumnType("int")
                        .HasColumnName("resortId");

                    b.Property<int?>("RestaurantId")
                        .HasColumnType("int")
                        .HasColumnName("restaurantId");

                    b.Property<int?>("RoomId")
                        .HasColumnType("int");

                    b.Property<int?>("SpotId")
                        .HasColumnType("int")
                        .HasColumnName("spotId");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("TourId")
                        .HasColumnType("int");

                    b.Property<int?>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__images__3213E83F79A33295");

                    b.HasIndex("DistrictId");

                    b.HasIndex("HotelId");

                    b.HasIndex("ResortId");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("RoomId");

                    b.HasIndex("SpotId");

                    b.HasIndex("TourId");

                    b.HasIndex("VehicleId");

                    b.ToTable("images", (string)null);
                });

            modelBuilder.Entity("server_travel.Entities.Resort", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("address");

                    b.Property<string>("Cacilities")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("cacilities");

                    b.Property<string>("ContactNumber")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("char(15)")
                        .HasColumnName("contactNumber")
                        .IsFixedLength();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DistrictId")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("location");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("name");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("SpotId")
                        .HasColumnType("int")
                        .HasColumnName("spotId");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__resorts__3213E83FCFD0CDD2");

                    b.HasIndex("DistrictId");

                    b.HasIndex("SpotId");

                    b.ToTable("resorts", (string)null);
                });

            modelBuilder.Entity("server_travel.Entities.Restaurant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("address");

                    b.Property<string>("ContactNumber")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("char(15)")
                        .HasColumnName("contactNumber")
                        .IsFixedLength();

                    b.Property<string>("CuisineType")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("cuisineType");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DistrictId")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("location");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("name");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("SpotId")
                        .HasColumnType("int")
                        .HasColumnName("spotId");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__restaura__3213E83FF2E08E5A");

                    b.HasIndex("DistrictId");

                    b.HasIndex("SpotId");

                    b.ToTable("restaurants", (string)null);
                });

            modelBuilder.Entity("server_travel.Entities.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HotelId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Price")
                        .HasColumnType("int");

                    b.Property<int?>("ResortId")
                        .HasColumnType("int");

                    b.Property<int?>("Sale")
                        .HasColumnType("int");

                    b.Property<int?>("Slot")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.HasIndex("ResortId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("server_travel.Entities.Tour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<int?>("DistrictId")
                        .HasColumnType("int");

                    b.Property<string>("Duration")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("duration");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Person")
                        .HasColumnType("int");

                    b.Property<int?>("Price")
                        .HasColumnType("int");

                    b.Property<int?>("Sale")
                        .HasColumnType("int");

                    b.Property<int?>("SpotId")
                        .HasColumnType("int")
                        .HasColumnName("spotId");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("TravelDate")
                        .HasColumnType("date")
                        .HasColumnName("travelDate");

                    b.Property<string>("TravelType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK__tours__3213E83FA2BEF46B");

                    b.HasIndex("DistrictId");

                    b.HasIndex("SpotId");

                    b.ToTable("tours", (string)null);
                });

            modelBuilder.Entity("server_travel.Entities.Touristspot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<int?>("DistrictId")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)")
                        .HasColumnName("location");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("name");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__tourists__3213E83F0CCAB314");

                    b.HasIndex("DistrictId");

                    b.ToTable("touristspots", (string)null);
                });

            modelBuilder.Entity("server_travel.Entities.TravelPlan", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TourId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("TourId");

                    b.ToTable("TravelPlans");
                });

            modelBuilder.Entity("server_travel.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("date")
                        .HasColumnName("birthday");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("JobTitle")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("jobTitle");

                    b.Property<string>("Name")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("password");

                    b.Property<string>("RoleTitle")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("roleTitle");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Tel")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("tel");

                    b.Property<string>("Token")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("token");

                    b.HasKey("Id")
                        .HasName("PK__users__3213E83FF89A88D3");

                    b.HasIndex(new[] { "Email" }, "UQ__users__AB6E616434C83F40")
                        .IsUnique()
                        .HasFilter("[email] IS NOT NULL");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("server_travel.Entities.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("description");

                    b.Property<int?>("DistrictId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("name");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("TourId")
                        .HasColumnType("int")
                        .HasColumnName("tourId");

                    b.Property<string>("Type")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("type");

                    b.HasKey("Id")
                        .HasName("PK__vehicles__3213E83F8F7FEB7D");

                    b.HasIndex("DistrictId");

                    b.HasIndex("TourId");

                    b.ToTable("vehicles", (string)null);
                });

            modelBuilder.Entity("server_travel.Entities.Hotel", b =>
                {
                    b.HasOne("server_travel.Entities.District", "District")
                        .WithMany("Hotels")
                        .HasForeignKey("DistrictId");

                    b.HasOne("server_travel.Entities.Touristspot", "Spot")
                        .WithMany("Hotels")
                        .HasForeignKey("SpotId")
                        .HasConstraintName("FK__hotels__spotId__4E88ABD4");

                    b.Navigation("District");

                    b.Navigation("Spot");
                });

            modelBuilder.Entity("server_travel.Entities.Image", b =>
                {
                    b.HasOne("server_travel.Entities.District", "District")
                        .WithMany("Images")
                        .HasForeignKey("DistrictId");

                    b.HasOne("server_travel.Entities.Hotel", "Hotel")
                        .WithMany("Images")
                        .HasForeignKey("HotelId")
                        .HasConstraintName("FK__images__hotelId__5CD6CB2B");

                    b.HasOne("server_travel.Entities.Resort", "Resort")
                        .WithMany("Images")
                        .HasForeignKey("ResortId")
                        .HasConstraintName("FK__images__resortId__5DCAEF64");

                    b.HasOne("server_travel.Entities.Restaurant", "Restaurant")
                        .WithMany("Images")
                        .HasForeignKey("RestaurantId")
                        .HasConstraintName("FK__images__restaura__5EBF139D");

                    b.HasOne("server_travel.Entities.Room", "Room")
                        .WithMany("Images")
                        .HasForeignKey("RoomId");

                    b.HasOne("server_travel.Entities.Touristspot", "Spot")
                        .WithMany("Images")
                        .HasForeignKey("SpotId")
                        .HasConstraintName("FK__images__spotId__5FB337D6");

                    b.HasOne("server_travel.Entities.Tour", "Tour")
                        .WithMany("Images")
                        .HasForeignKey("TourId");

                    b.HasOne("server_travel.Entities.Vehicle", "Vehicle")
                        .WithMany("Images")
                        .HasForeignKey("VehicleId");

                    b.Navigation("District");

                    b.Navigation("Hotel");

                    b.Navigation("Resort");

                    b.Navigation("Restaurant");

                    b.Navigation("Room");

                    b.Navigation("Spot");

                    b.Navigation("Tour");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("server_travel.Entities.Resort", b =>
                {
                    b.HasOne("server_travel.Entities.District", "District")
                        .WithMany("Resorts")
                        .HasForeignKey("DistrictId");

                    b.HasOne("server_travel.Entities.Touristspot", "Spot")
                        .WithMany("Resorts")
                        .HasForeignKey("SpotId")
                        .HasConstraintName("FK__resorts__spotId__5441852A");

                    b.Navigation("District");

                    b.Navigation("Spot");
                });

            modelBuilder.Entity("server_travel.Entities.Restaurant", b =>
                {
                    b.HasOne("server_travel.Entities.District", "District")
                        .WithMany("Restaurants")
                        .HasForeignKey("DistrictId");

                    b.HasOne("server_travel.Entities.Touristspot", "Spot")
                        .WithMany("Restaurants")
                        .HasForeignKey("SpotId")
                        .HasConstraintName("FK__restauran__spotI__5165187F");

                    b.Navigation("District");

                    b.Navigation("Spot");
                });

            modelBuilder.Entity("server_travel.Entities.Room", b =>
                {
                    b.HasOne("server_travel.Entities.Hotel", "Hotel")
                        .WithMany("Room")
                        .HasForeignKey("HotelId");

                    b.HasOne("server_travel.Entities.Resort", "Resort")
                        .WithMany("Room")
                        .HasForeignKey("ResortId");

                    b.Navigation("Hotel");

                    b.Navigation("Resort");
                });

            modelBuilder.Entity("server_travel.Entities.Tour", b =>
                {
                    b.HasOne("server_travel.Entities.District", "District")
                        .WithMany("Tours")
                        .HasForeignKey("DistrictId");

                    b.HasOne("server_travel.Entities.Touristspot", "Spot")
                        .WithMany("Tours")
                        .HasForeignKey("SpotId")
                        .HasConstraintName("FK__tours__spotId__4BAC3F29");

                    b.Navigation("District");

                    b.Navigation("Spot");
                });

            modelBuilder.Entity("server_travel.Entities.Touristspot", b =>
                {
                    b.HasOne("server_travel.Entities.District", "District")
                        .WithMany("Touristspots")
                        .HasForeignKey("DistrictId");

                    b.Navigation("District");
                });

            modelBuilder.Entity("server_travel.Entities.TravelPlan", b =>
                {
                    b.HasOne("server_travel.Entities.Tour", "Tour")
                        .WithMany("TravelPlans")
                        .HasForeignKey("TourId");

                    b.Navigation("Tour");
                });

            modelBuilder.Entity("server_travel.Entities.Vehicle", b =>
                {
                    b.HasOne("server_travel.Entities.District", null)
                        .WithMany("Vehicles")
                        .HasForeignKey("DistrictId");

                    b.HasOne("server_travel.Entities.Tour", "Tour")
                        .WithMany("Vehicles")
                        .HasForeignKey("TourId")
                        .HasConstraintName("FK__vehicles__spotId__571DF1D5");

                    b.Navigation("Tour");
                });

            modelBuilder.Entity("server_travel.Entities.District", b =>
                {
                    b.Navigation("Hotels");

                    b.Navigation("Images");

                    b.Navigation("Resorts");

                    b.Navigation("Restaurants");

                    b.Navigation("Touristspots");

                    b.Navigation("Tours");

                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("server_travel.Entities.Hotel", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("server_travel.Entities.Resort", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("server_travel.Entities.Restaurant", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("server_travel.Entities.Room", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("server_travel.Entities.Tour", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("TravelPlans");

                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("server_travel.Entities.Touristspot", b =>
                {
                    b.Navigation("Hotels");

                    b.Navigation("Images");

                    b.Navigation("Resorts");

                    b.Navigation("Restaurants");

                    b.Navigation("Tours");
                });

            modelBuilder.Entity("server_travel.Entities.Vehicle", b =>
                {
                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}
