namespace EclipseWorks.DTO.Task
{
    public class TaskListingDTO
    {
        public long Id { get; set; }

        public long ProjectId { get; set; }

        public string ProjectTitle { get; set; }

        public string Title { get; set; }

        public short TaskPriorityId { get; set; }

        public string TaskPriorityName { get; set; }

        public short TaskStatusId { get; set; }

        public string TaskStatusName { get; set; }

        public string Description { get; set; }

        public DateOnly DueDate { get; set; }
    }
}
