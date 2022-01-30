using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileProviderSystem.Models.Entities
{
    [Table("Accounts")]
    public class Account
    {
        [Key, Column("AccountId",TypeName = "INT UNSIGNED")]
        public uint Id { get; set; }
        
        [Column(TypeName = "VARCHAR(30)")]
        public string Login { get; set; } = null!;
        [Column(TypeName = "VARCHAR(30)")]
        public string Password { get; set; } = null!;
        
        [Column(TypeName = "SMALLINT UNSIGNED")]    
        public ushort? RoleId { get; set; }

        public Role Role { get; set; } = null!;
        public User? User { get; set; }
    }
}