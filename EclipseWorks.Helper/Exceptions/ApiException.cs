namespace EclipseWorks.Helper.Exceptions
{
    public class ApiException : Exception
    {
        public int StatusCode { get; set; }
        public string Content { get; set; }
    }
}
