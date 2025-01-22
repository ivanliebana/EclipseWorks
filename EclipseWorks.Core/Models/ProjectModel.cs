using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EclipseWorks.Core.Models
{
    [Table("project")]
    public class ProjectModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("userid")]
        public long UserId { get; set; }

        [Required]
        [StringLength(150)]
        [Column("title")]
        public string Title { get; set; }

        [Required]
        [Column("active")]
        public bool Active { get; set; } = true;

        [ForeignKey("UserId")]
        public UserModel User { get; set; }

        [InverseProperty("Project")]
        public List<TaskModel> Task { get; set; }
    }
}