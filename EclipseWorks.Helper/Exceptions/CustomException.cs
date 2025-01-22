namespace EclipseWorks.Helper.Exceptions
{
    public class CustomException : Exception
    {
        public CustomException(string error) : base(error) { }

        private static List<string> ErrorList { get; set; }

        public static void Validate()
        {
            var errors = new List<string>();

            foreach (var error in ErrorList)
                errors.Add(error);

            ErrorList = [];

            if (errors.Count > 0)
                throw new CustomException(Helper.Message.MSG0017(errors));
        }

        public static void When(bool hasError, string error)
        {
            if (hasError)
                throw new CustomException(error);
        }

        public static void MaxLength(long lenght, long maxLength, string error) => When(lenght > maxLength, error);

        public static void MinLength(long lenght, long minLength, string error) => When(lenght < minLength, error);

        public static void Required(string value, string error) => When(string.IsNullOrEmpty(value), error);
    }
}