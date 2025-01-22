using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EclipseWorks.Core.Models
{
    [Table("taskcomment")]
    public class TaskCommentModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("taskid")]
        public long TaskId { get; set; }

        [Required]
        [Column("authorid")]
        public long AuthorId { get; set; }

        [Required]
        [StringLength(800)]
        [Column("comment")]
        public string Comment { get; set; }

        [Required]
        [Column("active")]
        public bool Active { get; set; } = true;

        [ForeignKey("TaskId")]
        public TaskModel Task { get; set; }
    }
}