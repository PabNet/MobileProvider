using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MobileProviderSystem.Models.Entities
{
    [Table("Roles")]
    public class Role
    {
        [Key, Column("RoleId",TypeName = "SMALLINT UNSIGNED")]
        public ushort Id { get; set; }
        
        [Column("Role",TypeName = "VARCHAR(100)")]
        public string RoleName { get; set; } = null!;
        public List<Account> Accounts { get; set; } = new();
        
    }
}