﻿using System.Text.RegularExpressions;

namespace System
{
    public static partial class CheckMethods
    {
        public static Boolean IsValid(this Object o)
        {
            return !o.IsNullOrEmpty() || !o.IsNullOrWhiteSpace();
        }

        public static Boolean IsNull(this Object o)
        {
            return o == null;
        }

        public static Boolean IsNullOrEmpty(this Object o)
        {
            return o.IsNull() ? true : String.IsNullOrEmpty(o.ToString());
        }

        public static Boolean IsNullOrWhiteSpace(this Object o)
        {
            return o.IsNull() ? true : String.IsNullOrWhiteSpace(o.ToString());
        }

        public static Boolean IsChar(this Object o)
        {
            Char c;

            return o.IsNull() ? false : Char.TryParse(o.ToString(), out c);
        }

        public static Boolean IsBoolean(this Object o)
        {
            Boolean b;

            return o.IsNull() ? false : Boolean.TryParse(o.ToString(), out b);
        }

        public static Boolean IsInt16(this Object o)
        {
            Int16 i;

            return o.IsNull() ? false : Int16.TryParse(o.ToString(), out i);
        }

        public static Boolean IsInt32(this Object o)
        {
            Int32 i;

            return o.IsNull() ? false : Int32.TryParse(o.ToString(), out i);
        }

        public static Boolean IsInt64(this Object o)
        {
            Int64 i;

            return o.IsNull() ? false : Int64.TryParse(o.ToString(), out i);
        }

        public static Boolean IsDecimal(this Object o)
        {
            Decimal d;

            return o.IsNull() ? false : Decimal.TryParse(o.ToString(), out d);
        }

        public static Boolean IsDateTime(this Object o)
        {
            DateTime d;

            return o.IsNull() ? false : DateTime.TryParse(o.ToString(), out d);
        }

        public static Boolean IsDouble(this Object o)
        {
            Double d;

            return o.IsNull() ? false : Double.TryParse(o.ToString(), out d);
        }

        public static Boolean IsTimeSpan(this object o)
        {
            TimeSpan t;
            return o.IsNull() ? false : TimeSpan.TryParse(o.ToString(), out t);
        }

        public static Boolean ContainsLetters(this object o)
        {
            return o.IsNull() ? false : (Regex.Matches(o.ToString(), @"[a-zA-Z]").Count > 0);
        }
    }
}
