using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace EclipseWorks.Helper.Extensions
{
    public static partial class StringMethods
    {
        public static string ToStringWithoutHtml(this string str)
        {
            if (str.IsNullOrEmpty())
                return str;

            string result = Regex.Replace(str, @"<[^>]+>|&nbsp;", "").Trim();
            result = Regex.Replace(result, @"\s{2,}", " ");
            return result;
        }

        public static string FirstToUpper(this string str)
        {
            if (str.IsNullOrEmpty())
                return str;

            return str[0].ToString().ToUpper() + str.Substring(1);
        }

        public static string ToTrimString(this string str)
        {
            if (str.IsNullOrEmpty())
                return str;

            return str.Trim();
        }

        public static string ToSearchString(this object o)
        {
            return "%" + o.ToSearchStringEquals() + "%";
        }

        public static string ToSearchStringEquals(this object o)
        {
            if (o == null)
                return "";

            string str = o.ToString();

            str = Regex.Replace(str, "[aáàâãª]", "[aáàâãª]");
            str = Regex.Replace(str, "[AÁÀÂÃ]", "[AÁÀÂÃ]");
            str = Regex.Replace(str, "[eéèê]", "[eéèê]");
            str = Regex.Replace(str, "[EÉÈÊ]", "[EÉÈÊ]");
            str = Regex.Replace(str, "[iíìî]", "[iíìî]");
            str = Regex.Replace(str, "[IÍÌÎ]", "[IÍÌÎ]");
            str = Regex.Replace(str, "[oóòôõº]", "[oóòôõº]");
            str = Regex.Replace(str, "[OÓÒÔÕ]", "[OÓÒÔÕ]");
            str = Regex.Replace(str, "[uúùû]", "[uúùû]");
            str = Regex.Replace(str, "[UÚÙÛ]", "[UÚÙÛ]");
            str = Regex.Replace(str, "[cç]", "[cç]");
            str = Regex.Replace(str, "[CÇ]", "[CÇ]");
            str = str.Replace("'", "''");
            str = str.Replace("%", "[%]");

            return str;
        }

        public static string ToStringWithoutAccents(this Object o)
        {
            if (o == null)
                return "";

            string str = o.ToString();

            str = Regex.Replace(str, "[aáàâãª]", "a");
            str = Regex.Replace(str, "[AÁÀÂÃ]", "A");
            str = Regex.Replace(str, "[eéèê]", "e");
            str = Regex.Replace(str, "[EÉÈÊ]", "E");
            str = Regex.Replace(str, "[iíìî]", "i");
            str = Regex.Replace(str, "[IÍÌÎ]", "I");
            str = Regex.Replace(str, "[oóòôõº]", "o");
            str = Regex.Replace(str, "[OÓÒÔÕ]", "O");
            str = Regex.Replace(str, "[uúùû]", "u");
            str = Regex.Replace(str, "[UÚÙÛ]", "U");
            str = Regex.Replace(str, "[cç]", "c");
            str = Regex.Replace(str, "[CÇ]", "C");

            return str;
        }

        public static string URLEncode(this String str)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(str));
        }

        public static string URLDecode(this String str)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(str));
        }

        public static string BreakLine(this Object o)
        {
            string str = "";
            try
            {
                str = Convert.ToString(o);
                str = str.Replace("\n", "<br/>");
            }
            catch { }

            return str;
        }

        public static string Right(this string value, int length)
        {
            return value.Substring(value.Length - length);
        }

        public static string Left(this string value, int length)
        {
            return value.Substring(0, length);
        }

        public static string FillCharacterLeft(this string value, char character, int length)
        {
            return value.PadLeft(length, character);
        }

        public static string FillCharacterRight(this string value, char character, int length)
        {
            return value.PadRight(length, character);
        }

        public static string ToWeekDayBR(this int value)
        {
            switch (value)
            {
                case 0: return "Domingo";
                case 1: return "Segunda-Feira";
                case 2: return "Terça-Feira";
                case 3: return "Quarta-Feira";
                case 4: return "Quinta-Feira";
                case 5: return "Sexta-Feira";
                case 6: return "Sábado";
                default: return "Não informado";
            }
        }

        public static string ToWeekDayBR(this string value)
        {
            switch (value)
            {
                case "0": return "Domingo";
                case "1": return "Segunda-Feira";
                case "2": return "Terça-Feira";
                case "3": return "Quarta-Feira";
                case "4": return "Quinta-Feira";
                case "5": return "Sexta-Feira";
                case "6": return "Sábado";
                default: return "Não informado";
            }
        }

        public static string RemoveDiacritics(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            text = text.Normalize(NormalizationForm.FormD);
            var chars = text.Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark).ToArray();
            return new string(chars).Normalize(NormalizationForm.FormC);
        }

        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }

        public static string TruncateWithEllipsis(this string value, int maxLength)
        {
            if (value.IsNullOrEmpty())
                return value;

            const string ellipsis = "...";

            if (ellipsis.Length > maxLength)
                return value;

            if (value.Length > maxLength)
                return string.Concat(value.AsSpan(0, maxLength - ellipsis.Length), ellipsis);
            else
                return value;
        }

        public static string GetLast(this string source, int tail_length)
        {
            if (tail_length >= source.Length)
                return source;

            return source.Substring(source.Length - tail_length);
        }

        public static string ToURL(this string str)
        {
            str = str.Replace("ª", "");
            str = str.Replace("º", "");
            str = str.Replace("?", "");
            str = str.Replace("!", "");
            str = str.Replace("*", "");
            str = str.Replace("%", "");
            str = str.Replace("#", "");
            str = str.Replace("@", "");
            str = str.Replace("(", "");
            str = str.Replace(")", "");
            str = str.Replace("_", "");
            str = str.Replace("{", "");
            str = str.Replace("}", "");
            str = str.Replace("[", "");
            str = str.Replace("]", "");
            str = str.Replace("^", "");
            str = str.Replace("´", "");
            str = str.Replace("`", "");
            str = str.Replace("º", "");
            str = str.Replace("'", "");
            str = str.Replace(":", "");
            str = str.Replace("%", "");
            str = str.Replace(",-", "-");
            str = str.Replace("-,", "-");
            str = str.Replace("+", "");
            str = str.Replace("“", "");
            str = str.Replace("”", "");
            str = str.Replace("\"", "");
            str = str.Replace("&", "");
            str = str.Replace("‘", "");
            str = str.Replace("’", "");
            str = str.Replace("/", "-");
            str = str.Replace("\\", "-");
            str = str.Replace("  ", " ");
            str = str.Replace(" ", "-");

            str = str.Replace(".aspx", "{aspx}");
            str = str.Replace(".", "");
            str = str.Replace("{aspx}", ".aspx");

            str = str.ToStringWithoutAccents();
            return str;
        }

        public static string ToURL(object obj)
        {
            return ToURL(obj.ToString());
        }

        public static string ToUtf8Encoding(this string str)
        {
            if (str.IsNullOrEmpty())
                return str;

            byte[] bytes = Encoding.Default.GetBytes(str);
            str = Encoding.UTF8.GetString(bytes);

            return str;
        }

        public static string RemoveMask(this string str)
        {
            if (str.IsNullOrEmpty())
                return str;

            return str.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "").Replace(".", "").Replace("/", "").Replace(@"\", "");
        }

        public static string ToPlainTextWithoutSpace(this string str)
        {
            str = str.ToURL().Replace("-", "");
            str = str.ToLower();
            return str;
        }

        public static string ToUpperIgnoreNull(this string value)
        {
            if (value != null)
            {
                value = value.ToUpper(CultureInfo.InvariantCulture);
            }
            return value;
        }

        public static string RemoveAllNumber(this string value)
        {
            if (value.IsNullOrWhiteSpace())
                return value;

            var output = Regex.Replace(value, @"[\d-]", string.Empty);

            return output;
        }

        public static string RemoveExtraSpaces(this string sender)
        {
            const RegexOptions options = RegexOptions.None;
            var regex = new Regex("[ ]{2,}", options);
            return regex.Replace(sender, " ").Trim();
        }
    }
}
