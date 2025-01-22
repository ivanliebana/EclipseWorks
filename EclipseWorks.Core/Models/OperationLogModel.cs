using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EclipseWorks.Core.Models
{
    [Table("operationlog")]
    public class OperationLogModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("table")]
        public string Table { get; set; }

        [Required]
        [Column("column")]
        public string Column { get; set; }

        [Column("oldvalue")]
        public string OldValue { get; set; }

        [Required]
        [Column("newvalue")]
        public string NewValue { get; set; }

        [Required]
        [Column("date", TypeName = "timestamp(6)")]
        public DateTime Date { get; set; }

        [Required]
        [Column("userid")]
        public long UserId { get; set; }

        [ForeignKey("UserId")]
        public UserModel User { get; set; }
    }
}