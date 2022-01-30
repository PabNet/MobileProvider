using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileProviderSystem.Models.Entities
{
    [Table("SocialNetworkReferences")]
    public class SocialNetworkReference
    {
        [Key, Column("NetworkReferenceId",TypeName = "SMALLINT UNSIGNED")]
        public ushort Id { get; set; }
        
        [Column(TypeName = "TEXT")]
        public string Reference { get; set; } = null!;
        
        [Column(TypeName = "TINYINT UNSIGNED")]
        public sbyte SocialNetworkId { get; set; }
        public SocialNetwork SocialNetwork { get; set; } = null!;
        
        [Column(TypeName = "SMALLINT UNSIGNED")]
        public ushort ContactId { get; set; }
        public Contact Contact { get; set; } = null!;
    }
}