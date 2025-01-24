namespace EclipseWorks.DTO.Report
{
    public class TaskListingPerformanceLast30DaysDTO
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public int NumberTasksCompleted { get; set; }
        public double AverageNumberTasksCompleted { get; set; }
        public string ResultText { get; set; }
    }
}
