using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileProviderSystem.Models.Entities
{
    [Table("SocialNetworks")]
    public class SocialNetwork
    {
        [Key, Column("NetworkId",TypeName = "TINYINT UNSIGNED")]
        public sbyte Id { get; set; }
        
        [Column(TypeName = "VARCHAR(50)")]
        public string NetworkName { get; set; } = null!;

        public List<SocialNetworkReference> NetworkReferences { get; set; } = new();

    }
}