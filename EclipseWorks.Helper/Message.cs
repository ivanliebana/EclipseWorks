namespace EclipseWorks.Helper
{
    public static class Message
    {
        /// <summary>
        /// Invalid access credentials
        /// </summary>
        public const string MSG0001 = "Invalid access credentials";

        /// <summary>
        /// Data saved successfully!
        /// </summary>
        public const string MSG0002 = "Data saved successfully!";

        /// <summary>
        /// Unable to save data
        /// </summary>
        public const string MSG0003 = "Unable to save data";

        /// <summary>
        /// Successfully deleted record!
        /// </summary>
        public const string MSG0005 = "Successfully deleted record!";

        /// <summary>
        /// Unable to delete record
        /// </summary>
        public const string MSG0006 = "Unable to delete record";

        /// <summary>
        /// Failed to authenticate
        /// </summary>
        public const string MSG0007 = "Failed to authenticate";

        /// <summary>
        /// Invalid login or password
        /// </summary>
        public const string MSG0008 = "Invalid login or password";

        /// <summary>
        /// No records found
        /// </summary>
        public const string MSG0009 = "No records found";

        /// <summary>
        /// Invalid model state
        /// </summary>
        public const string MSG0010 = "Invalid model state";

        /// <summary>
        /// Registration already exists: 'x': 'y'
        /// </summary>
        public static string MSG0013(string property, object value)
        {
            return $"Registration already exists: '{property}': '{value}'";
        }

        /// <summary>
        /// '{property}' must have up to '{qtyCharacter}' characters
        /// </summary>
        public static string MSG0014(string property, int qtyCharacter)
        {
            return $"'{property}' must have up to '{qtyCharacter}' characters";
        }

        /// <summary>
        /// '{property}' must have at least '{qtdCharacter}' characters
        /// </summary>
        public static string MSG0015(string property, int qtdCharacter)
        {
            return $"'{property}' must have at least '{qtdCharacter}' characters";
        }

        /// <summary>
        ///'{property}' is required
        /// </summary>
        public static string MSG0016(string property)
        {
            return $"'{property}' is required";
        }

        /// <summary>
        /// Check out the following information:
        /// </summary>
        /// <param name="erros">{0} - List Of Erros.</param>
        public static string MSG0017(List<string> erros)
        {
            string message = "Check out the following information: <br /> - {0}";
            return String.Format(message, String.Join("<br /> - ", erros));
        }

        /// <summary>
        /// Data added successfully!
        /// </summary>
        public const string MSG0018 = "Data added successfully!";

        /// <summary>
        /// Fill in the field '{0}'
        /// </summary>
        public const string MSG0019 = "Fill in the field '{0}'";

        /// <summary>
        /// The field '{0}' must have between '{2}' and '{1}' characters
        /// </summary>
        public const string MSG0020 = "The field '{0}' must have between '{2}' and '{1}' characters";

        /// <summary>
        /// Incorrect '{0}' padding. Only letters (upper and lower case) and numbers are accepted
        /// </summary>
        public const string MSG0021 = "Incorrect '{0}' padding. Only letters (upper and lower case) and numbers are accepted";

        /// <summary>
        /// Incorrect '{0}' padding.
        /// </summary>
        public const string MSG0022 = "Incorrect '{0}' padding.";

        /// <summary>
        /// Incorrect '{0}' padding. Only letters (upper and lower case) are accepted
        /// </summary>
        public const string MSG0023 = "Incorrect '{0}' padding. Only letters (upper and lower case) are accepted";

        /// <summary>
        /// Field '{0}' must have '{1}' characters
        /// </summary>
        public const string MSG0024 = "Field '{0}' must have '{1}' characters";

        /// <summary>
        /// Select '{0}'
        /// </summary>
        public const string MSG0025 = "Select '{0}'";

        /// <summary>
        /// Incorrect '{0}' padding. Only letters, numbers or the following characters (.,/-) are accepted
        /// </summary>
        public const string MSG0026 = "Incorrect '{0}' padding. Only letters, numbers or the following characters (.,/-) are accepted";

        /// <summary>
        /// Incorrect '{0}' padding. Only numbers are accepted (No Spaces)
        /// </summary>
        public const string MSG0027 = "Incorrect '{0}' padding. Only numbers are accepted (No Spaces)";

        /// <summary>
        /// Incorrect '{0}' padding. Letters (upper and lower case), numbers or the following characters (.,/-%+) are accepted
        /// </summary>
        public const string MSG0028 = "Incorrect '{0}' padding. Letters (upper and lower case), numbers or the following characters (.,/-%+) are accepted";

        /// <summary>
        /// The field '{0}' must have a maximum of '{1}' characters
        /// </summary>
        public const string MSG0029 = "The field '{0}' must have a maximum of '{1}' characters";

        /// <summary>
        /// Access denied. You do not have permission to perform the desired operation
        /// </summary>
        public const string MSG0030 = "Access denied. You do not have permission to perform the desired operation";

        /// <summary>
        /// An issue occurred while processing your request.The technical team has already been contacted and the problem will soon be resolved.
        /// </summary>
        public const string MSG0031 = "An issue occurred while processing your request. The technical team has already been contacted and the problem will soon be resolved.";

        /// <summary>
        /// Select
        /// </summary>
        public const string MSG0032 = "Select";

        /// <summary>
        /// Values ​​between '{1}' and '{2}' are accepted
        /// </summary>
        public const string MSG0033 = "Values ​​between '{1}' and '{2}' are accepted";

        /// <summary>
        /// There is already a record with '{x}': '{y}' in value range
        /// </summary>
        public static string MSG0034(string property, object value)
        {
            return $"There is already a record with '{property}': '{value}' in value range";
        }

        /// <summary>
        /// There is already a record with a range between '{property1}': '{value1}' and '{property2}': '{value2}'
        /// </summary>
        public static string MSG0035(string property1, string property2, object value1, object value2)
        {
            return $"There is already a record with a range between '{property1}': '{value1}' and '{property2}': '{value2}'";
        }

        /// <summary>
        /// Unable to delete as there are dependent records
        /// </summary>
        public const string MSG0036 = "Unable to delete as there are dependent records";

        /// <summary>
        /// Registration already exists
        /// </summary>
        public const string MSG0037 = "Registration already exists";

        /// <summary>
        /// Incorrect '{0}' padding. Only letters (without accent and without space) and numbers are accepted
        /// </summary>
        public const string MSG0038 = "Incorrect '{0}' padding. Only letters (without accent and without space) and numbers are accepted";

        /// <summary>
        /// '{property}' already exists
        /// </summary>
        public static string MSG0039(string property)
        {
            return $"'{property}' already exists";
        }

        /// <summary>
        /// Incorrect '{0}' padding. Only letters, numbers or the following characters (.,/-%+) are accepted
        /// </summary>
        public const string MSG0040 = "Incorrect '{0}' padding. Only letters, numbers or the following characters (.,/-%+) are accepted";

        /// <summary>
        /// Incorrect '{0}' padding. Only letters (without accent) or the following characters (.) are accepted.
        /// </summary>
        public const string MSG0041 = "Incorrect '{0}' padding. Only letters (without accent) or the following characters (.) are accepted.";

        /// <summary>
        /// Incorrect '{0}' padding. Values ​​between '{1}' and '{2}' are accepted
        /// </summary>
        public const string MSG0042 = "Incorrect '{0}' padding. Values ​​between '{1}' and '{2}' are accepted";

        /// <summary>
        /// The field '{0}' must have up to '{1}' characters
        /// </summary>
        public const string MSG0043 = "The field '{0}' must have up to '{1}' characters";

        /// <summary>
        /// Incorrect '{0}' padding. Only letters, numbers or the following characters (./-) are accepted
        /// </summary>
        public const string MSG0044 = "Incorrect '{0}' padding. Only letters, numbers or the following characters (./-) are accepted";

        /// <summary>
        /// Incorrect '{0}' padding. Only letters and numbers are accepted
        /// </summary>
        public const string MSG0045 = "Incorrect '{0}' padding. Only letters and numbers are accepted";

        /// <summary>
        /// Choose 'x'
        /// </summary>
        public const string MSG0046 = "Choose '{0}'";

        /// <summary>
        /// {property}' entered is invalid
        /// </summary>
        public static string MSG0047(string property)
        {
            return $"'{property}' entered is invalid";
        }

        /// <summary>
        /// No '{key}' found with the given '{property}'
        /// </summary>
        public static string MSG0049(string key, string property)
        {
            return $"No '{key}' found with the given '{property}'";
        }

        /// <summary>
        /// '{property}' informed is already registered and active in the system.
        /// </summary>
        public static string MSG0055(string property)
        {
            return $"'{property}' informed is already registered and active in the system.";
        }
    }
}
