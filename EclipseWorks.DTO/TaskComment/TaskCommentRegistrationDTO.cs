namespace EclipseWorks.DTO.TaskComment
{
    public class TaskCommentRegistrationDTO
    {
        public long TaskId { get; set; }

        public long AuthorId { get; set; }

        public string Comment { get; set; }
    }
}
