using EclipseWorks.Helper.Exceptions;
using System.ComponentModel;
using System.Data;

namespace System
{
    public static partial class ConvertMethods
    {
        public static bool? ToNBoolean(this Object o)
        {
            bool? b;

            try
            {
                if (o.IsNullOrEmpty())
                    return null;

                b = Convert.ToBoolean(o);
            }
            catch (Exception)
            {
                b = null;
            }

            return b;
        }

        public static bool ToBoolean(this Object o)
        {
            bool? b = o.ToNBoolean();

            if (b.HasValue)
            {
                return b.Value;
            }
            else
            {
                throw new ConvertExtensionException();
            }
        }

        public static Char? ToNChar(this Object o)
        {
            Char? c;

            try
            {
                c = Convert.ToChar(o);
            }
            catch (Exception)
            {
                c = null;
            }

            return c;
        }

        public static Char ToChar(this Object o)
        {
            try
            {
                return Convert.ToChar(o);
            }
            catch (Exception)
            {
                throw new ConvertExtensionException();
            }
        }

        public static Int16? ToNInt16(this Object o)
        {
            Int16? i;

            try
            {
                if (o.IsNullOrEmpty())
                    return null;

                i = Convert.ToInt16(o);
            }
            catch (Exception)
            {
                i = null;
            }

            return i;
        }

        public static Int16 ToInt16(this Object o)
        {
            try
            {
                return Convert.ToInt16(o);
            }
            catch (Exception)
            {
                throw new ConvertExtensionException();
            }
        }

        public static Int32? ToNInt32(this Object o)
        {
            Int32? i;

            try
            {
                if (o.IsNullOrEmpty())
                    return null;

                i = Convert.ToInt32(o);
            }
            catch (Exception)
            {
                i = null;
            }

            return i;
        }

        public static Int32 ToInt32(this Object o)
        {
            try
            {
                return Convert.ToInt32(o);
            }
            catch (Exception)
            {
                throw new ConvertExtensionException();
            }
        }

        public static Int64? ToNInt64(this Object o)
        {
            Int64? i;

            try
            {
                if (o.IsNullOrEmpty())
                    return null;

                i = Convert.ToInt64(o);
            }
            catch (Exception)
            {
                i = null;
            }

            return i;
        }

        public static Int64 ToInt64(this Object o)
        {
            try
            {
                if (o.IsNullOrEmpty())
                {
                    return 0;
                }

                return Convert.ToInt64(o);
            }
            catch (Exception)
            {
                throw new ConvertExtensionException();
            }
        }

        public static Decimal? ToNDecimal(this Object o)
        {
            Decimal? d;

            try
            {
                if (o == null)
                {
                    return null;
                }

                d = Convert.ToDecimal(o);
            }
            catch (Exception)
            {
                d = null;
            }

            return d;
        }

        public static Decimal ToDecimal(this Object o)
        {
            try
            {
                return Convert.ToDecimal(o);
            }
            catch (Exception)
            {
                throw new ConvertExtensionException();
            }
        }

        public static DateTime? ToNDateTime(this Object o)
        {
            DateTime? d;

            try
            {
                if (o == null)
                {
                    return null;
                }

                d = Convert.ToDateTime(o);
            }
            catch (Exception)
            {
                d = null;
            }

            return d;
        }

        public static DateTime ToDateTime(this Object o)
        {
            try
            {
                return Convert.ToDateTime(o);
            }
            catch (Exception)
            {
                if (o.IsDateTime())
                {
                    try
                    {
                        return DateTime.Parse(o.ToString());
                    }
                    catch (Exception)
                    {
                        throw new ConvertExtensionException();
                    }
                }

                throw new ConvertExtensionException();
            }
        }

        public static Double? ToNDouble(this Object o)
        {
            Double? d;

            try
            {
                d = Convert.ToDouble(o);
            }
            catch (Exception)
            {
                d = null;
            }

            return d;
        }

        public static Double ToDouble(this Object o)
        {
            try
            {
                return Convert.ToDouble(o);
            }
            catch (Exception)
            {
                throw new ConvertExtensionException();
            }
        }

        public static TimeSpan? ToNTimeSpan(this Object o)
        {
            TimeSpan? t;

            try
            {
                t = TimeSpan.Parse(o.ToString());
            }
            catch (Exception)
            {
                t = null;
            }

            return t;
        }

        public static TimeSpan ToTimeSpan(this Object o)
        {
            try
            {
                return TimeSpan.Parse(o.ToString());
            }
            catch (Exception)
            {
                throw new ConvertExtensionException();
            }
        }

        public static IOrderedQueryable<T> ToOrderedQueryable<T>(this IQueryable<T> query)
        {
            return (IOrderedQueryable<T>)query;
        }

        public static DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        public static String ToFormatNumber(this Object o)
        {
            try
            {
                return String.Format("{0:0,0.00}", o);//.Replace(",","x").Replace(".",",").Replace("x",".");                
            }
            catch (Exception)
            {
                throw new ConvertExtensionException();
            }
        }
    }
}
