namespace EclipseWorks.Core.Models
{
    public class TaskPerformanceLast30DaysModel
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public int NumberTasksCompleted { get; set; }
        public double AverageNumberTasksCompleted { get; set; }
        public string ResultText { get; set; }
    }
}
