using EasyNutrition.APIv_.CoreBussines.Domain.Models;
using EasyNutrition.APIv_.Shared.Extentions;
using Microsoft.EntityFrameworkCore;

namespace EasyNutrition.APIv_.CoreBussines.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

    
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Entidad Role

            builder.Entity<Role>().ToTable("Roles");
            builder.Entity<Role>().HasKey(p => p.Id);
            builder.Entity<Role>().Property(p => p.Id)
                .IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Role>().Property(p => p.Name)
                .IsRequired().HasMaxLength(30);
            builder.Entity<Role>()
                .HasMany(p => p.Users)
                .WithOne(p => p.Role)
                .HasForeignKey(p => p.RoleId);

            // Agregar data a Role
            builder.Entity<Role>().HasData
                (
                    new Role { Id = 1, Name = "Nutricionista" },
                    new Role { Id = 2, Name = "Cliente" },
                    new Role { Id = 3, Name = "Administrador" },
                    new Role { Id = 4, Name = "Invitado" }


                );


            //Entidad User

            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id);
            builder.Entity<User>().Property(p => p.Username)
                .IsRequired().HasMaxLength(20);
            builder.Entity<User>().Property(p => p.Password)
               .IsRequired().HasMaxLength(80);
            builder.Entity<User>().Property(p => p.Name)
               .IsRequired().HasMaxLength(40);
            builder.Entity<User>().Property(p => p.Lastname)
               .IsRequired().HasMaxLength(40);
            builder.Entity<User>().Property(p => p.Birthday)
               .IsRequired().HasMaxLength(20);
            builder.Entity<User>().Property(p => p.Email)
               .IsRequired().HasMaxLength(50);
            builder.Entity<User>().Property(p => p.Phone)
               .IsRequired().HasMaxLength(20);
            builder.Entity<User>().Property(p => p.Address)
               .IsRequired().HasMaxLength(50);
            builder.Entity<User>().Property(p => p.Active)
              .IsRequired();
            builder.Entity<User>().Property(p => p.Linkedin)
                .IsRequired().HasMaxLength(100);

            builder.Entity<User>()
              .HasOne(pt => pt.Role)
              .WithMany(p => p.Users)
              .HasForeignKey(pt => pt.RoleId);



            builder.Entity<User>().HasData
          (
               new User { Id = 1, Username = "Alfredo Gomez", Password = "dbJe*D4xqfd|e]*p&", Name = "Alfredo", Lastname = "Gomez", Birthday = "10/10/1985", Email = "alfredito@gmail.com", Phone = "97531546", Address = "Las Malvinas 123", Active = true, Linkedin = "https:\\afjaowjfiawj.com", RoleId = 1 },
               new User { Id = 2, Username = "Hernesto Sanchez", Password = "1WH1wm%tL#AUsgqB@", Name = "Hernesto", Lastname = "Sanchez", Birthday = "10/10/1990", Email = "hernes@gmail.com", Phone = "97531546", Address = "Las Malvinas 667", Active = true, Linkedin = "https:\\afjaowjfiawj.com", RoleId = 1 },
               new User { Id = 3, Username = "Agusto Hernandez", Password = "exCBHH0UdzyGpCxE~", Name = "Agusto", Lastname = "Hernandez", Birthday = "10/10/1970", Email = "augus@gmail.com", Phone = "97532346", Address = "Las Poncinas 314", Active = true, Linkedin = "https:\\afjaowjfiawj.com", RoleId = 2 },
               new User { Id = 4, Username = "Jeremy ALfonso", Password = "HYO|@o7XJK@T<^W(^", Name = "Jeremy", Lastname = "ALfonso", Birthday = "10/10/1989", Email = "jere@gmail.com", Phone = "978561234", Address = "Villanueva 454", Active = true, Linkedin = "https:\\afjaowjfiawj.com", RoleId = 3 },
               new User { Id = 5, Username = "Augusto Salazar", Password = "1b}%Ct(Th*(0odt1l", Name = "Augusto", Lastname = "Salazar", Birthday = "10/10/1987", Email = "augus_14@gmail.com", Phone = "97512346", Address = "Las doce 123", Active = true, Linkedin = "https:\\afjaowjfiawj.com", RoleId = 2 },
               new User { Id = 6, Username = "Yimmy Neutron", Password = "MW~#o2z2#I)!WjDKR", Name = "Yimmy", Lastname = "Neutron", Birthday = "10/10/1982", Email = "yim23@gmail.com", Phone = "97559746", Address = "CHavin 123", Active = true, Linkedin = "https:\\afjaowjfiawj.com", RoleId = 1 },
               new User { Id = 7, Username = "Steve Robi", Password = "7k<GV(qEe%PHJOFc#", Name = "Steve", Lastname = "Robi", Birthday = "10/10/1990", Email = "steve789@gmail.com", Phone = "97539756", Address = "Cajamarca 123", Active = true, Linkedin = "https:\\afjaowjfiawj.com", RoleId = 2 },
               new User { Id = 8, Username = "Sandro Quispe", Password = "mh$!iPSvXAfCWkh$f", Name = "Sandro", Lastname = "Quispe", Birthday = "10/10/1990", Email = "san23@gmail.com", Phone = "94561546", Address = "Av. Ayacucho 123", Active = true, Linkedin = "https:\\afjaowjfiawj.com", RoleId = 3 },
               new User { Id = 9, Username = "Ali Jamelio", Password = "OHG2|CZ^9Z6#d!*Xf", Name = "Ali", Lastname = "Jamelio", Birthday = "10/10/1987", Email = "alimoha@gmail.com", Phone = "97821546", Address = "Av- Bolivar 123", Active = true, Linkedin = "https:\\afjaowjfiawj.com", RoleId = 1 },
               new User { Id = 10, Username = "Angel Gavidia", Password = "ZNrr&l*xeucG2W(*D", Name = "Angel", Lastname = "Gavidia", Birthday = "10/10/1989", Email = "angel123@gmail.com", Phone = "94861546", Address = "Alfonso Ugarte 123", Active = true, Linkedin = "https:\\afjaowjfiawj.com", RoleId = 4 }

          );


            builder.UseSnakeCaseNamingConvention();
        }

    }
}

