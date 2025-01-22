namespace EclipseWorks.DTO.BaseDTO
{
    public class APIResponseDTO<T> where T : class
    {
        public bool Success { get; set; } = false;
        public T Data { get; set; } = null;
        public List<string> Errors { get; set; } = null;
    }

    public class APIRequestDTO<T> where T : class
    {
        public T Data { get; set; } = null;
    }

    public class APIResponseDTO
    {
        public bool Success { get; set; } = false;
        public List<string> Errors { get; set; } = null;
    }

    public class ErrorDTO
    {

    }
}
