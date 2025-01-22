namespace EclipseWorks.Helper
{
    public static class SecurityConstants
    {
        public const string CookieAuthentication = "CookieAuthentication";

        public const string EclipseWorksPasswordHashPepper = "EclipseWorksPasswordHashPepper";
    }

    public static class APIConstants
    {
        public const string APIName = "API";

        //CORS
        public const string APIDefaultCorsPolicy = "DefaultCorsPolicy";

        //JWT
        public const string JWTIssuer = "Jwt:Issuer";
        public const string JWTAudience = "Jwt:Audience";
        public const string JWTKey = "Jwt:Key";

        public const long MaxFileSize = 1024 * 1024 * 100; //100MB
    }

    public static class RegularExpressionConstants
    {
        public const string Date = @"(((0[1-9]|[12][0-9]|3[01])([-./])(0[13578]|10|12)([-./])(\d{4}))|(([0][1-9]|[12][0-9]|30)([-./])(0[469]|11)([-./])(\d{4}))|((0[1-9]|1[0-9]|2[0-8])([-./])(02)([-./])(\d{4}))|((29)(\.|-|\/)(02)([-./])([02468][048]00))|((29)([-./])(02)([-./])([13579][26]00))|((29)([-./])(02)([-./])([0-9][0-9][0][48]))|((29)([-./])(02)([-./])([0-9][0-9][2468][048]))|((29)([-./])(02)([-./])([0-9][0-9][13579][26])))(\s(20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?";
        public const string OnlyNumber = @"^[0-9]+$";
        public const string Email = @"^[\w.-]+@(?=[a-zA-Z\d][^.]*\.)[a-zA-Z\d.-]*[^.]$";
        public const string CPF = @"(^\d{3}\x2E\d{3}\x2E\d{3}\x2D\d{2}$)";
        public const string CNPJ = @"\d{2}.?\d{3}.?\d{3}/?\d{4}-?\d{2}";
        public const string SUFRAMA = @"^\d{8}\.\d$";
        public const string PIS = @"^\d{3}\.?\d{5}\.?\d{2}-?\d$";
        public const string TelephoneOrCellphone = @"(\(?\d{2}\)?\s)?(\d{4,5}\-\d{4})";
        public const string OnyLetter = @"^(?:[a-zA-ZÀ-ÿ]+\s?)+[a-zA-ZÀ-ÿ]+$";
        public const string OnlyUpperLetter = @"^[A-Z]+$";
        public const string LetterAndNumber = @"^(?:[a-zA-ZÀ-ÿ0-9]+\s?)+[a-zA-ZÀ-ÿ0-9]+$";
        public const string CEP = @"^\d{5}(-\d{3})?$";
        public const string DoubleNumber = @"^(\d+)?([\.\,]?\d{0,2})?$";
        public const string DoubleNumberThreeDigitAfterComma = @"^(\d+)?([\.\,]?\d{0,3})?$";
        public const string MonetaryReal = @"^([1-9]{1}[\d]{0,2}(\.[\d]{3})*(\,[\d]{0,2})?|[1-9]{1}[\d]{0,}(\,[\d]{0,2})?|0(\,[\d]{0,2})?|(\,[\d]{1,2})?)$";
        public const string Password = @"^[a-zA-Z0-9]+$";
        public const string PersonName = @"^[A-ZÀ-ÿ][a-zÀ-ÿ]*(([,.] |[ '-])[A-Za-zÀ-ÿ][a-zÀ-ÿ]*)*(\.?)$";
    }
}