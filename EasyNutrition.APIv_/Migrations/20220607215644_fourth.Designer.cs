﻿// <auto-generated />
using EasyNutrition.APIv_.CoreBussines.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EasyNutrition.APIv_.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220607215644_fourth")]
    partial class fourth
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EasyNutrition.APIv_.CoreBussines.Domain.Models.Diet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("description");

                    b.Property<int>("SessionId")
                        .HasColumnType("int")
                        .HasColumnName("session_id");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("p_k_diets");

                    b.HasIndex("SessionId")
                        .HasDatabaseName("i_x_diets_session_id");

                    b.ToTable("diets", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Lunes: x Martes: x Miercoles: x",
                            SessionId = 1,
                            Title = "Dieta Vegetariana"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Lunes: x Martes: x Miercoles: x",
                            SessionId = 2,
                            Title = "Dieta para aumentar masa musuclar"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Lunes: x Martes: x Miercoles: x",
                            SessionId = 3,
                            Title = "Dieta miniCut"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Lunes: x Martes: x Miercoles: x",
                            SessionId = 4,
                            Title = "Dieta Tonificación Muscular"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Lunes: x Martes: x Miercoles: x",
                            SessionId = 5,
                            Title = "Dieta definición"
                        });
                });

            modelBuilder.Entity("EasyNutrition.APIv_.CoreBussines.Domain.Models.Progress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("description");

                    b.Property<int>("SessionId")
                        .HasColumnType("int")
                        .HasColumnName("session_id");

                    b.HasKey("Id")
                        .HasName("p_k_progresses");

                    b.HasIndex("SessionId")
                        .HasDatabaseName("i_x_progresses_session_id");

                    b.ToTable("progresses", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Bajó 4 kilos",
                            SessionId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "Aumentó su masa en 3 kilos",
                            SessionId = 2
                        },
                        new
                        {
                            Id = 3,
                            Description = "Logró bajar mi porcentaje de grasa a un 12%",
                            SessionId = 3
                        },
                        new
                        {
                            Id = 4,
                            Description = "Aumentó 1kg de masa muscular",
                            SessionId = 4
                        },
                        new
                        {
                            Id = 5,
                            Description = "Aumentó su masa en 2 kilos",
                            SessionId = 5
                        });
                });

            modelBuilder.Entity("EasyNutrition.APIv_.CoreBussines.Domain.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("p_k_roles");

                    b.ToTable("roles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Nutricionista"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Cliente"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Administrador"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Invitado"
                        });
                });

            modelBuilder.Entity("EasyNutrition.APIv_.CoreBussines.Domain.Models.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("EndAt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("end_at");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("link");

                    b.Property<string>("StartAt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("start_at");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("p_k_session");

                    b.HasIndex("UserId")
                        .HasDatabaseName("i_x_session_user_id");

                    b.ToTable("session", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EndAt = "Monday, March 24 ,2019 18:00:00 PM",
                            Link = "https",
                            StartAt = "Monday, March 24,2019 17:00:00 PM",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            EndAt = "Thurday, March 26 ,2019 21:00:00 PM",
                            Link = "https",
                            StartAt = "Thursday, March 26,2019 20:00:00 PM",
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            EndAt = "Monday, March 13 ,2019 18:00:00 PM",
                            Link = "https",
                            StartAt = "Monday, March 13,2019 17:00:00 PM",
                            UserId = 3
                        },
                        new
                        {
                            Id = 4,
                            EndAt = "Monday, March 24 ,2019 17:00:00 PM",
                            Link = "https",
                            StartAt = "Monday, March 24,2019 16:00:00 PM",
                            UserId = 4
                        },
                        new
                        {
                            Id = 5,
                            EndAt = "Monday, March 24 ,2019 18:00:00 PM",
                            Link = "https",
                            StartAt = "Monday, March 24,2019 17:00:00 PM",
                            UserId = 5
                        },
                        new
                        {
                            Id = 6,
                            EndAt = "Monday, March 24 ,2019 18:00:00 PM",
                            Link = "https",
                            StartAt = "Monday, March 24,2019 17:00:00 PM",
                            UserId = 6
                        },
                        new
                        {
                            Id = 7,
                            EndAt = "Thurday, March 26 ,2019 21:00:00 PM",
                            Link = "https",
                            StartAt = "Thursday, March 26,2019 20:00:00 PM",
                            UserId = 7
                        },
                        new
                        {
                            Id = 8,
                            EndAt = "Monday, March 13 ,2019 18:00:00 PM",
                            Link = "https",
                            StartAt = "Monday, March 13,2019 17:00:00 PM",
                            UserId = 8
                        },
                        new
                        {
                            Id = 9,
                            EndAt = "Monday, March 24 ,2019 17:00:00 PM",
                            Link = "https",
                            StartAt = "Monday, March 24,2019 16:00:00 PM",
                            UserId = 9
                        },
                        new
                        {
                            Id = 10,
                            EndAt = "Monday, March 24 ,2019 18:00:00 PM",
                            Link = "https",
                            StartAt = "Monday, March 24,2019 17:00:00 PM",
                            UserId = 10
                        });
                });

            modelBuilder.Entity("EasyNutrition.APIv_.CoreBussines.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Active")
                        .HasColumnType("bit")
                        .HasColumnName("active");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("address");

                    b.Property<string>("Birthday")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("birthday");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("lastname");

                    b.Property<string>("Linkedin")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("linkedin");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)")
                        .HasColumnName("password");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("phone");

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("username");

                    b.HasKey("Id")
                        .HasName("p_k_users");

                    b.HasIndex("RoleId")
                        .HasDatabaseName("i_x_users_role_id");

                    b.ToTable("users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            Address = "Las Malvinas 123",
                            Birthday = "10/10/1985",
                            Email = "alfredito@gmail.com",
                            Lastname = "Gomez",
                            Linkedin = "https:\\afjaowjfiawj.com",
                            Name = "Alfredo",
                            Password = "dbJe*D4xqfd|e]*p&",
                            Phone = "97531546",
                            RoleId = 1,
                            Username = "Alfredo Gomez"
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            Address = "Las Malvinas 667",
                            Birthday = "10/10/1990",
                            Email = "hernes@gmail.com",
                            Lastname = "Sanchez",
                            Linkedin = "https:\\afjaowjfiawj.com",
                            Name = "Hernesto",
                            Password = "1WH1wm%tL#AUsgqB@",
                            Phone = "97531546",
                            RoleId = 1,
                            Username = "Hernesto Sanchez"
                        },
                        new
                        {
                            Id = 3,
                            Active = true,
                            Address = "Las Poncinas 314",
                            Birthday = "10/10/1970",
                            Email = "augus@gmail.com",
                            Lastname = "Hernandez",
                            Linkedin = "https:\\afjaowjfiawj.com",
                            Name = "Agusto",
                            Password = "exCBHH0UdzyGpCxE~",
                            Phone = "97532346",
                            RoleId = 2,
                            Username = "Agusto Hernandez"
                        },
                        new
                        {
                            Id = 4,
                            Active = true,
                            Address = "Villanueva 454",
                            Birthday = "10/10/1989",
                            Email = "jere@gmail.com",
                            Lastname = "ALfonso",
                            Linkedin = "https:\\afjaowjfiawj.com",
                            Name = "Jeremy",
                            Password = "HYO|@o7XJK@T<^W(^",
                            Phone = "978561234",
                            RoleId = 3,
                            Username = "Jeremy ALfonso"
                        },
                        new
                        {
                            Id = 5,
                            Active = true,
                            Address = "Las doce 123",
                            Birthday = "10/10/1987",
                            Email = "augus_14@gmail.com",
                            Lastname = "Salazar",
                            Linkedin = "https:\\afjaowjfiawj.com",
                            Name = "Augusto",
                            Password = "1b}%Ct(Th*(0odt1l",
                            Phone = "97512346",
                            RoleId = 2,
                            Username = "Augusto Salazar"
                        },
                        new
                        {
                            Id = 6,
                            Active = true,
                            Address = "CHavin 123",
                            Birthday = "10/10/1982",
                            Email = "yim23@gmail.com",
                            Lastname = "Neutron",
                            Linkedin = "https:\\afjaowjfiawj.com",
                            Name = "Yimmy",
                            Password = "MW~#o2z2#I)!WjDKR",
                            Phone = "97559746",
                            RoleId = 1,
                            Username = "Yimmy Neutron"
                        },
                        new
                        {
                            Id = 7,
                            Active = true,
                            Address = "Cajamarca 123",
                            Birthday = "10/10/1990",
                            Email = "steve789@gmail.com",
                            Lastname = "Robi",
                            Linkedin = "https:\\afjaowjfiawj.com",
                            Name = "Steve",
                            Password = "7k<GV(qEe%PHJOFc#",
                            Phone = "97539756",
                            RoleId = 2,
                            Username = "Steve Robi"
                        },
                        new
                        {
                            Id = 8,
                            Active = true,
                            Address = "Av. Ayacucho 123",
                            Birthday = "10/10/1990",
                            Email = "san23@gmail.com",
                            Lastname = "Quispe",
                            Linkedin = "https:\\afjaowjfiawj.com",
                            Name = "Sandro",
                            Password = "mh$!iPSvXAfCWkh$f",
                            Phone = "94561546",
                            RoleId = 3,
                            Username = "Sandro Quispe"
                        },
                        new
                        {
                            Id = 9,
                            Active = true,
                            Address = "Av- Bolivar 123",
                            Birthday = "10/10/1987",
                            Email = "alimoha@gmail.com",
                            Lastname = "Jamelio",
                            Linkedin = "https:\\afjaowjfiawj.com",
                            Name = "Ali",
                            Password = "OHG2|CZ^9Z6#d!*Xf",
                            Phone = "97821546",
                            RoleId = 1,
                            Username = "Ali Jamelio"
                        },
                        new
                        {
                            Id = 10,
                            Active = true,
                            Address = "Alfonso Ugarte 123",
                            Birthday = "10/10/1989",
                            Email = "angel123@gmail.com",
                            Lastname = "Gavidia",
                            Linkedin = "https:\\afjaowjfiawj.com",
                            Name = "Angel",
                            Password = "ZNrr&l*xeucG2W(*D",
                            Phone = "94861546",
                            RoleId = 4,
                            Username = "Angel Gavidia"
                        });
                });

            modelBuilder.Entity("EasyNutrition.APIv_.CoreBussines.Domain.Models.Diet", b =>
                {
                    b.HasOne("EasyNutrition.APIv_.CoreBussines.Domain.Models.Session", "Session")
                        .WithMany()
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("f_k_diets__session_session_id");

                    b.Navigation("Session");
                });

            modelBuilder.Entity("EasyNutrition.APIv_.CoreBussines.Domain.Models.Progress", b =>
                {
                    b.HasOne("EasyNutrition.APIv_.CoreBussines.Domain.Models.Session", "Session")
                        .WithMany()
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("f_k_progresses__session_session_id");

                    b.Navigation("Session");
                });

            modelBuilder.Entity("EasyNutrition.APIv_.CoreBussines.Domain.Models.Session", b =>
                {
                    b.HasOne("EasyNutrition.APIv_.CoreBussines.Domain.Models.User", "User")
                        .WithMany("Sessions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("f_k_session__users_user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EasyNutrition.APIv_.CoreBussines.Domain.Models.User", b =>
                {
                    b.HasOne("EasyNutrition.APIv_.CoreBussines.Domain.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("f_k_users_roles_role_id");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("EasyNutrition.APIv_.CoreBussines.Domain.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("EasyNutrition.APIv_.CoreBussines.Domain.Models.User", b =>
                {
                    b.Navigation("Sessions");
                });
#pragma warning restore 612, 618
        }
    }
}