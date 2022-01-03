﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PeakyBarbers.Data;

namespace PeakyBarbers.Data.Migrations
{
    [DbContext(typeof(PeakyBarbersDbContext))]
    [Migration("20220103114311_CustomerCategory")]
    partial class CustomerCategory
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("PeakyBarbers.Data.Entities.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("ApplicationUser");
                });

            modelBuilder.Entity("PeakyBarbers.Data.Entities.AppointmentSlot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BarberId")
                        .HasColumnType("int");

                    b.Property<int>("BookingStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DayOfYear")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("BarberId");

                    b.HasIndex("CustomerId");

                    b.ToTable("AppointmentSlots");
                });

            modelBuilder.Entity("PeakyBarbers.Data.Entities.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ApproximateServiceDurationInMinutes")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ServiceDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ServiceFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ServiceName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Services");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ApproximateServiceDurationInMinutes = 15,
                            CreationDate = new DateTime(2022, 1, 2, 11, 15, 0, 0, DateTimeKind.Local).AddTicks(1149),
                            ModifiedDate = new DateTime(2022, 1, 2, 11, 15, 0, 0, DateTimeKind.Local).AddTicks(1149),
                            ServiceDescription = "Straight Razor Head Shave",
                            ServiceFee = 10m,
                            ServiceName = "Peaky Blood Cut"
                        },
                        new
                        {
                            Id = 2,
                            ApproximateServiceDurationInMinutes = 60,
                            CreationDate = new DateTime(2022, 1, 2, 11, 15, 0, 0, DateTimeKind.Local).AddTicks(1149),
                            ModifiedDate = new DateTime(2022, 1, 2, 11, 15, 0, 0, DateTimeKind.Local).AddTicks(1149),
                            ServiceDescription = "Haircut, neck shave, extended therapeutic scalp massage, shampoo and conditioner.",
                            ServiceFee = 50m,
                            ServiceName = "Executive"
                        },
                        new
                        {
                            Id = 3,
                            ApproximateServiceDurationInMinutes = 20,
                            CreationDate = new DateTime(2022, 1, 2, 11, 15, 0, 0, DateTimeKind.Local).AddTicks(1149),
                            ModifiedDate = new DateTime(2022, 1, 2, 11, 15, 0, 0, DateTimeKind.Local).AddTicks(1149),
                            ServiceDescription = "Complete grooming with neck trim.",
                            ServiceFee = 25m,
                            ServiceName = "Classic"
                        },
                        new
                        {
                            Id = 4,
                            ApproximateServiceDurationInMinutes = 15,
                            CreationDate = new DateTime(2022, 1, 2, 11, 15, 0, 0, DateTimeKind.Local).AddTicks(1149),
                            ModifiedDate = new DateTime(2022, 1, 2, 11, 15, 0, 0, DateTimeKind.Local).AddTicks(1149),
                            ServiceDescription = "A basic haircut for the younger gentlemen.",
                            ServiceFee = 15m,
                            ServiceName = "Young Men's Choice"
                        },
                        new
                        {
                            Id = 5,
                            ApproximateServiceDurationInMinutes = 60,
                            CreationDate = new DateTime(2022, 1, 2, 11, 15, 0, 0, DateTimeKind.Local).AddTicks(1149),
                            ModifiedDate = new DateTime(2022, 1, 2, 11, 15, 0, 0, DateTimeKind.Local).AddTicks(1149),
                            ServiceDescription = "Hair dyeing and natural colouring.",
                            ServiceFee = 40m,
                            ServiceName = "Color Camouflage"
                        });
                });

            modelBuilder.Entity("PeakyBarbers.Data.Entities.WorkingHour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BarberId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Day")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("BarberId", "Day")
                        .IsUnique();

                    b.ToTable("WorkingHours");
                });

            modelBuilder.Entity("PeakyBarbers.Data.Entities.Barber", b =>
                {
                    b.HasBaseType("PeakyBarbers.Data.Entities.ApplicationUser");

                    b.Property<int?>("OverallRating")
                        .HasColumnType("int");

                    b.Property<string>("ProfileDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("YearsOfExperience")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Barber");
                });

            modelBuilder.Entity("PeakyBarbers.Data.Entities.Customer", b =>
                {
                    b.HasBaseType("PeakyBarbers.Data.Entities.ApplicationUser");

                    b.Property<int>("CustomerCategory")
                        .HasColumnType("int");

                    b.Property<bool>("PremiumDiscountEligible")
                        .HasColumnType("bit");

                    b.Property<bool>("StandardDiscountEligible")
                        .HasColumnType("bit");

                    b.HasDiscriminator().HasValue("Customer");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("PeakyBarbers.Data.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("PeakyBarbers.Data.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PeakyBarbers.Data.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("PeakyBarbers.Data.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PeakyBarbers.Data.Entities.AppointmentSlot", b =>
                {
                    b.HasOne("PeakyBarbers.Data.Entities.Barber", "Barber")
                        .WithMany("AllAppointmentSlots")
                        .HasForeignKey("BarberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PeakyBarbers.Data.Entities.Customer", "Customer")
                        .WithMany("AllAppointmentSlots")
                        .HasForeignKey("CustomerId");

                    b.Navigation("Barber");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("PeakyBarbers.Data.Entities.WorkingHour", b =>
                {
                    b.HasOne("PeakyBarbers.Data.Entities.Barber", "Barber")
                        .WithMany("AllWorkingHours")
                        .HasForeignKey("BarberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Barber");
                });

            modelBuilder.Entity("PeakyBarbers.Data.Entities.Barber", b =>
                {
                    b.Navigation("AllAppointmentSlots");

                    b.Navigation("AllWorkingHours");
                });

            modelBuilder.Entity("PeakyBarbers.Data.Entities.Customer", b =>
                {
                    b.Navigation("AllAppointmentSlots");
                });
#pragma warning restore 612, 618
        }
    }
}
