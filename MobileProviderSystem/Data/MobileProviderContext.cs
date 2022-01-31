using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MobileProviderSystem.Models.Entities;

namespace MobileProviderSystem.Data
{
    public class MobileProviderContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Contact> Contacts { get; set; } = null!;
        public DbSet<Description> Descriptions { get; set; } = null!;

        public MobileProviderContext(DbContextOptions<MobileProviderContext> options)
            : base(options)
        {
            base.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Role adminRole = new Role() { Id = 1, RoleName = "Администратор" },
                clientRole = new Role() { Id = 2, RoleName = "Клиент" },
                serviceRole = new Role() { Id = 3, RoleName = "Услуги" },
                homeInternetRole = new Role() { Id = 4, RoleName = "Домашний интернет" },
                mobileInternetRole = new Role() { Id = 5, RoleName = "Мобильный интернет" },
                mobileConnectionRole = new Role() { Id = 6, RoleName = "Мобильная связь" },
                productsRole = new Role() { Id = 7, RoleName = "Товары" };

            SocialNetwork
                telegramFirst = new SocialNetwork() {Id = 1, NetworkName = "Telegram", Reference = "@LuximySalon"},
                telegramSecond = new SocialNetwork() {Id = 3, NetworkName = "Telegram", Reference = "@SalonLux"},
                instagramFirst = new SocialNetwork() {Id = 2, NetworkName = "Instagram", Reference = "@lux.imy"},
                facebookFirst = new SocialNetwork() {Id = 4, NetworkName = "FaceBook", Reference = "@Imylux"};
            

            modelBuilder.Entity<SocialNetwork>().HasData(
                new List<SocialNetwork>()
                {
                    telegramFirst,
                    telegramSecond,
                    instagramFirst,
                    facebookFirst
                });

            modelBuilder.Entity<Contact>().HasData(
                new List<Contact>()
                {
                    new Contact()
                    {
                        Id = 1, Address = "г.Минск, ул.Казинца 25а",
                        Email = "salon1@gmail.com", PhoneNumber = "253348812",
                        SocialNetworkId = telegramFirst.Id
                    },
                    new Contact()
                    {
                        Id = 2, Address = "г.Минск, ул.Бобруйская 5",
                        Email = "newSalon@gmail.com", PhoneNumber = "296671280",
                        SocialNetworkId = facebookFirst.Id
                    },
                    new Contact()
                    {
                        Id = 3, Address = "г.Минск, ул.Петра Глебки 1",
                        Email = "Salon25@gmail.com", PhoneNumber = "440231142",
                        SocialNetworkId = telegramSecond.Id
                    }
                });

            modelBuilder.Entity<Role>().HasData(
                new List<Role>()
                {
                    adminRole,
                    clientRole,
                    serviceRole,
                    mobileInternetRole,
                    mobileConnectionRole,
                    homeInternetRole,
                    productsRole
                });
            
            modelBuilder.Entity<Account>().HasData(new Account()
            {
                Id = 1,
                Login = "Administrator2022",
                Password = "Password112@",
                RoleId = adminRole.Id,
            });

            modelBuilder.Entity<Description>().HasData(
                new List<Description>()
                {
                    new Description() { Id = 1, RoleId = adminRole.Id,
                        SystemDescription = "Вы являетесь администратором данной системы и сами всё про неё знаете." },
                    new Description() { Id = 2, RoleId = clientRole.Id,
                        SystemDescription = "Вы находитесь в официальном приложении одного из лучших мобильных провайдеров страны - Luximy. Мы предоставляем широкий спектр услуг и возможностей для своих клиентов в сфере мобильной связи и интернета." },
                    new Description() { Id = 3, RoleId = homeInternetRole.Id,
                        SystemDescription = "Вы в этой системе являетесь консультантом по домашнему интернету, и ваша задача помогать клиентам настроить его. А про систему вы должны знать сами." },
                    new Description() { Id = 4, RoleId = mobileInternetRole.Id,
                        SystemDescription = "Консультант по мобильному интернету, коим вы и являетесь, обязан разбираться в своих вопросах своей тематики хорошо и предоставлять клиентам только качественную информацию. " },
                    new Description() { Id = 5, RoleId = serviceRole.Id,
                        SystemDescription = "Услуги, предоставляемые в салонах нашей сети Luximy, довольно обширные и разносторонние и ваша задача донести качественно и понятно всю информацию о них до наших клиентов, при возникновении вопросов." },
                    new Description() { Id = 6, RoleId = productsRole.Id,
                        SystemDescription = "Помимо информационных услуг, Luximy даёт возможность приобретать различную продукцию, связанную с мобильной связью и интернетом. НЕ забывайте, что ваша цель: качественно проконсультировать и продать товар клиентам." },
                    new Description() { Id = 7, RoleId = mobileConnectionRole.Id,
                        SystemDescription = "Будучи ответственным за вопросы мобильной связи, вы должны консультировать клиентов касаемо тарифов, задолженностей и так далее." },
                }
            );
            
            modelBuilder.Entity<User>()
                .HasOne(p => p.Account)
                .WithOne(t => t.User)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}