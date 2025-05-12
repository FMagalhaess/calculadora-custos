using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace calculadora_custos.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {   
        public Guid Id { get; set; }
        
        [Column(TypeName = "varchar(100)")]
        public string? Name { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string? Email { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string? Password { get; set; }
    }
}