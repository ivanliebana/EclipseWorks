namespace EclipseWorks.DTO.Task
{
    public class TaskRegistrationDTO
    {
        public long ProjectId { get; set; }

        public short TaskPriorityId { get; set; }

        public string Title { get; set; }

        public DateOnly DueDate { get; set; }

        public string Description { get; set; }
    }
}
