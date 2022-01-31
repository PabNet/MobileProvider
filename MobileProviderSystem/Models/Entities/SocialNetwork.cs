using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileProviderSystem.Models.Entities
{
    [Table("SocialNetworks")]
    public class SocialNetwork
    {
        [Key, Column("SocialNetworkId",TypeName = "INT UNSIGNED")]
        public uint Id { get; set; }
        
        [Column(TypeName = "VARCHAR(50)")]
        public string NetworkName { get; set; } = null!;
        
        [Column(TypeName = "TEXT")]
        public string Reference { get; set; } = null!;

        public Contact Contact { get; set; }

    }
}