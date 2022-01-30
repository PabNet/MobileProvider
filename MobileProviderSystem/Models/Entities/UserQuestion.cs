using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileProviderSystem.Models.Entities
{
    [Table("Questions")]
    public class UserQuestion
    {
        [Key, Column("QuestionId",TypeName = "SMALLINT UNSIGNED")]
        public ushort Id { get; set; }
        
        [Column(TypeName = "TEXT")]
        public string Question { get; set; } = null!;
        [Column(TypeName = "TEXT")]
        public string Answer { get; set; } = null!;
        
        [Column(TypeName = "SMALLINT UNSIGNED")] 
        public ushort UserId { get; set; }
        public Account UserAccount { get; set; } = null!;
    }
}