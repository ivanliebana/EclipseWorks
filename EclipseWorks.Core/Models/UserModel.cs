using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EclipseWorks.Core.Models
{
    [Table("user")]
    public class UserModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [StringLength(150)]
        [Column("email")]
        public string Email { get; set; }

        [Required]
        [StringLength(500)]
        [Column("password")]
        public string Password { get; set; }

        [Required]
        [StringLength(500)]
        [Column("hash")]
        public string Hash { get; set; }

        [Required]
        [Column("registrationdate", TypeName = "timestamp(6)")]
        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        [Required]
        [Column("ismanager")]
        public bool IsManager { get; set; }

        [Required]
        [Column("active")]
        public bool Active { get; set; } = true;

        [InverseProperty("User")]
        public List<ProjectModel> Project { get; set; }
    }
}