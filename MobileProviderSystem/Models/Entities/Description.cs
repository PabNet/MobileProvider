using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileProviderSystem.Models.Entities
{
    public class Description
    {
        [Key, Column("RoleId",TypeName = "SMALLINT UNSIGNED")]
        public ushort Id { get; set; }
        
        [Column(TypeName = "TEXT")]
        public string SystemDescription { get; set; } = null!;
        
        [Column(TypeName = "SMALLINT UNSIGNED")]
        public ushort RoleId { get; set; }
        public Role Role { get; set; }
    }
}