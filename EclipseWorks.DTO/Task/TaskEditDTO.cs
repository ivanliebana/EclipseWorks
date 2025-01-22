namespace EclipseWorks.DTO.Task
{
    public class TaskEditDTO
    {
        public long Id { get; set; }

        public short TaskStatusId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
