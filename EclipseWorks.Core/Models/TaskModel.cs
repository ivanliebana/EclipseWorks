using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EclipseWorks.Core.Models
{
    [Table("task")]
    public class TaskModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("projectid")]
        public long ProjectId { get; set; }

        [Required]
        [Column("taskpriorityid")]
        public short TaskPriorityId { get; set; }

        [Required]
        [Column("taskstatusid")]
        public short TaskStatusId { get; set; }

        [Required]
        [StringLength(150)]
        [Column("title")]
        public string Title { get; set; }

        [Required]
        [StringLength(800)]
        [Column("description")]
        public string Description { get; set; }

        [Required]
        [Column("duedate", TypeName = "timestamp(6)")]
        public DateTime DueDate { get; set; } = DateTime.Now;

        [Column("completiondate", TypeName = "timestamp(6)")]
        public DateTime? CompletionDate { get; set; }

        [Required]
        [Column("active")]
        public bool Active { get; set; } = true;

        [ForeignKey("ProjectId")]
        public ProjectModel Project { get; set; }

        [NotMapped]
        public long AuthorId { get; set; }
    }
}
