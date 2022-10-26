namespace PersionText
{
    public static class StringExtensions
    {
        /// <summary>
        /// Arabic Ke Char \u0643 = ARABIC LETTER KAF
        /// </summary>
        public const char ArabicKeChar = (char)1603;

        /// <summary>
        /// Arabic Ye Char \u0649 = ARABIC LETTER ALEF MAKSURA
        /// </summary>
        public const char ArabicYeChar1 = (char)1609;

        /// <summary>
        /// Arabic Ye Char \u064A = ARABIC LETTER YEH
        /// </summary>
        public const char ArabicYeChar2 = (char)1610;

        /// <summary>
        /// ؠ
        /// </summary>
        public const char ArabicYeWithOneDotBelow = (char)1568;

        /// <summary>
        /// ؽ
        /// </summary>
        public const char ArabicYeWithInvertedV = (char)1597;

        /// <summary>
        /// ؾ
        /// </summary>
        public const char ArabicYeWithTwoDotsAbove = (char)1598;

        /// <summary>
        /// ؿ
        /// </summary>
        public const char ArabicYeWithThreeDotsAbove = (char)1599;

        /// <summary>
        /// ٸ
        /// </summary>
        public const char ArabicYeWithHighHamzeYeh = (char)1656;

        /// <summary>
        /// ې
        /// </summary>
        public const char ArabicYeWithFinalForm = (char)1744;

        /// <summary>
        /// ۑ
        /// </summary>
        public const char ArabicYeWithThreeDotsBelow = (char)1745;

        /// <summary>
        /// ۍ
        /// </summary>
        public const char ArabicYeWithTail = (char)1741;

        /// <summary>
        /// ێ
        /// </summary>
        public const char ArabicYeSmallV = (char)1742;

        /// <summary>
        /// Persian Ke Char \u06A9 = ARABIC LETTER KEHEH
        /// </summary>
        public const char PersianKeChar = (char)1705;

        /// <summary>
        /// Persian Ye Char \u06CC = 'ARABIC LETTER FARSI YEH
        /// </summary>
        public const char PersianYeChar = (char)1740;


        public static bool HasValue(this string value, bool ignoreWhiteSpace = true)
        {
            return ignoreWhiteSpace ? !string.IsNullOrWhiteSpace(value) : !string.IsNullOrEmpty(value);
        }

        public static int ToInt(this string value)
        {
            return Convert.ToInt32(value);
        }

        public static decimal ToDecimal(this string value)
        {
            return Convert.ToDecimal(value);
        }

        public static string ToNumeric(this int value)
        {
            return value.ToString("N0"); //"123,456"
        }

        public static string ToNumeric(this decimal value)
        {
            return value.ToString("N0");
        }

        public static string ToCurrency(this int value)
        {
            //fa-IR => current culture currency symbol => ریال
            //123456 => "123,123ریال"
            return value.ToString("C0");
        }

        public static string ToCurrency(this decimal value)
        {
            return value.ToString("C0");
        }

        public static string En2Fa(this string str)
        {
            return str.Replace("0", "۰")
                .Replace("1", "۱")
                .Replace("2", "۲")
                .Replace("3", "۳")
                .Replace("4", "۴")
                .Replace("5", "۵")
                .Replace("6", "۶")
                .Replace("7", "۷")
                .Replace("8", "۸")
                .Replace("9", "۹");
        }

        public static string Fa2En(this string str)
        {
            return str.Replace("۰", "0")
                .Replace("۱", "1")
                .Replace("۲", "2")
                .Replace("۳", "3")
                .Replace("۴", "4")
                .Replace("۵", "5")
                .Replace("۶", "6")
                .Replace("۷", "7")
                .Replace("۸", "8")
                .Replace("۹", "9")
                //iphone numeric
                .Replace("٠", "0")
                .Replace("١", "1")
                .Replace("٢", "2")
                .Replace("٣", "3")
                .Replace("٤", "4")
                .Replace("٥", "5")
                .Replace("٦", "6")
                .Replace("٧", "7")
                .Replace("٨", "8")
                .Replace("٩", "9");
        }

        public static string FixPersianChars(this string str)
        {
            return str.Replace("ﮎ", "ک")
                .Replace("ﮏ", "ک")
                .Replace("ﮐ", "ک")
                .Replace("ﮑ", "ک")
                .Replace("ك", "ک")
                .Replace(" ", " ")
                .Replace("‌", " ")
                .Replace("ھ", "ه");//.Replace("ئ", "ی");
        }

        public static string ApplyCorrectYeKe(this string? data)
        {
            if (string.IsNullOrWhiteSpace(data)) return string.Empty;

            var dataChars = data.ToCharArray();
            for (var i = 0; i < dataChars.Length; i++)
            {
                switch (dataChars[i])
                {
                    case ArabicYeChar1:
                    case ArabicYeChar2:
                    case ArabicYeWithOneDotBelow:
                    case ArabicYeWithInvertedV:
                    case ArabicYeWithTwoDotsAbove:
                    case ArabicYeWithThreeDotsAbove:
                    case ArabicYeWithHighHamzeYeh:
                    case ArabicYeWithFinalForm:
                    case ArabicYeWithThreeDotsBelow:
                    case ArabicYeWithTail:
                    case ArabicYeSmallV:
                        dataChars[i] = PersianYeChar;
                        break;

                    case ArabicKeChar:
                        dataChars[i] = PersianKeChar;
                        break;
                }
            }

            return new string(dataChars);
        }


        public static string CleanString(this string? str)
        {
            return str is null ?
                        string.Empty : str.ApplyCorrectYeKe().Trim().FixPersianChars().Fa2En();
        }
    }
}
