using System.Collections.Generic;
using System.IO;
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
        public DbSet<QuestionSubject> QuestionSubjects { get; set; } = null!;
        public DbSet<SocialNetwork> SocialNetworks { get; set; } = null!;
        public DbSet<SocialNetworkReference> SocialNetworkReferences { get; set; } = null!;
        public DbSet<UserQuestion> UserQuestions { get; set; } = null!;
        
        public MobileProviderContext(DbContextOptions<MobileProviderContext> options)
            : base(options)
        {
            base.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Role adminRole = new Role() { Id = 1, RoleName = "Admin" };
            
            SocialNetwork vk = new SocialNetwork() { Id = 1, NetworkName = "VK" },
                faceBook = new SocialNetwork() { Id = 2, NetworkName = "FaceBook" },
                instagram = new SocialNetwork() { Id = 3, NetworkName = "Instagram" },
                twitter = new SocialNetwork() { Id = 4, NetworkName = "Twitter" },
                telegram = new SocialNetwork() { Id = 5, NetworkName = "Telegram" };

            Contact firstContact = new Contact()
                {
                    Id = 1, Address = "г.Минск, ул.Казинца 25а",
                    Email = "salon1@gmail.com", PhoneNumber = "253348812"
                },
                secondContact = new Contact()
                {
                    Id = 2, Address = "г.Минск, ул.Бобруйская 5",
                    Email = "newSalon@gmail.com", PhoneNumber = "296671280"
                },
                thirdContact = new Contact()
                {
                    Id = 3, Address = "г.Минск, ул.Петра Глебки 1",
                    Email = "Salon25@gmail.com", PhoneNumber = "440231142"
                };



            modelBuilder.Entity<QuestionSubject>().HasData(
                new List<QuestionSubject>()
                {
                    new QuestionSubject() { Id = 1, Subject = "Мобильная связь" },
                    new QuestionSubject() { Id = 2, Subject = "Мобильный интернет" },
                    new QuestionSubject() { Id = 3, Subject = "Домашний интернет" },
                    new QuestionSubject() { Id = 4, Subject = "Услуги салона" },
                    new QuestionSubject() { Id = 5, Subject = "Ассортимент товаров" },
                });

            modelBuilder.Entity<SocialNetwork>().HasData(
                new List<SocialNetwork>()
                {
                    vk,
                    faceBook,
                    instagram,
                    twitter,
                    telegram
                });

            modelBuilder.Entity<Contact>().HasData(
                new List<Contact>()
                {
                    firstContact,
                    secondContact,
                    thirdContact
                });
            
            modelBuilder.Entity<SocialNetworkReference>().HasData(
                new List<SocialNetworkReference>()
                {
                    new SocialNetworkReference()
                    {
                        Id = 1,
                        Reference = "@SalonTel",
                        ContactId = secondContact.Id,
                        SocialNetworkId = telegram.Id
                    },
                    new SocialNetworkReference()
                    {
                        Id = 2,
                        Reference = "@mobileSalon.by",
                        ContactId = secondContact.Id,
                        SocialNetworkId = instagram.Id
                    },
                });
            
            modelBuilder.Entity<Role>().HasData(
                new List<Role>()
                {
                    adminRole,
                    new Role() { Id = 2, RoleName = "Client" },
                    new Role() { Id = 3, RoleName = "Service" },
                    new Role() { Id = 4, RoleName = "HomeInternet" },
                    new Role() { Id = 5, RoleName = "MobileInternet" },
                    new Role() { Id = 6, RoleName = "MobileConnection" },
                    new Role() { Id = 7, RoleName = "Products" },
                });
            
            modelBuilder.Entity<Account>().HasData(new Account()
            {
                Id = 1,
                Login = "Administrator2022",
                Password = "Password112@",
                RoleId = adminRole.Id,
            });
        }
    }
}