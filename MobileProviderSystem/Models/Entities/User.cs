using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileProviderSystem.Models.Entities
{
    [Table("Users")]
    public class User
    {
        [Key, Column("UserId",TypeName = "INT UNSIGNED")]
        public uint Id { get; set; }
        
        [Column(TypeName = "TEXT")]
        public string Email { get; set; } = null!;
        [Column(TypeName = "VARCHAR(10)")]
        public string PhoneNumber { get; set; } = null!;
        [Column("FIO", TypeName = "VARCHAR(100)")]
        public string Fio { get; set; } = null!;
        
        [Column(TypeName = "INT UNSIGNED")]  
        public uint AccountId { get; set; }
        public Account Account { get; set; } = null!;
        
    }
}