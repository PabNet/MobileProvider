using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileProviderSystem.Models.Entities
{
    [Table("QuestionSubjects")]
    public class QuestionSubject
    {
        [Key, Column("QuestionSubjectId",TypeName = "SMALLINT UNSIGNED")]
        public ushort Id { get; set; }
        
        [Column(TypeName = "VARCHAR(100)")]
        public string Subject { get; set; } = null!;

        public List<UserQuestion> Questions { get; set; } = new();
    }
}