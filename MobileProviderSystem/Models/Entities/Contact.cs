using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileProviderSystem.Models.Entities
{
    [Table("ContactDetails")]
    public class Contact
    {
        [Key, Column("RoleId",TypeName = "SMALLINT UNSIGNED")]
        public ushort Id { get; set; }

        [Column(TypeName = "TEXT")] public string Address { get; set; } = null!;

        [Column("WorkPhone", TypeName = "VARCHAR(10)")]
        public string PhoneNumber { get; set; } = null!;
        [Column("WorkEmail",TypeName = "TEXT")]
        public string? Email { get; set; }

        [Column(TypeName = "INT UNSIGNED")]
        public uint SocialNetworkId { get; set; }
        public SocialNetwork SocialNetwork { get; set; }


    }
}