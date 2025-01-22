using System.ComponentModel;
using System.Reflection;

namespace EclipseWorks.Helper.Enums
{
    public static class EnumUtil
    {
        /// <summary>
        /// Converte um objeto para o enum especificado.
        /// </summary>
        /// <typeparam name="T">Enum para o qual será convertido o objeto.</typeparam>
        /// <param name="obj">Objeto a ser convertido.</param>
        /// <returns>Objeto convertido no enum especificado.</returns>
        public static T Convert<T>(object obj) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type.");
            }

            return (T)Enum.Parse(typeof(T), obj.ToString());
        }

        /// <summary>
        /// Retorna o atributo "description" do enum.
        /// </summary>
        /// <param name="value">Valor do enum a ser obtido a descrição.</param>
        /// <returns>Descrição obtida do enum.</returns>
        public static string GetDescription(System.Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
        }

        /// <summary>
        /// Retorna um conjunto de todos os itens de um enum.
        /// </summary>
        /// <typeparam name="T">Enum a ser usado.</typeparam>
        /// <returns>Dictionary contendo o texto e o valor de todos os itens do enum.</returns>
        public static Dictionary<int, string> GetItens<T>() where T : struct, IConvertible
        {
            return GetItens(typeof(T));
        }

        /// <summary>
        /// Retorna um conjunto de todos os itens de um enum.
        /// </summary>
        /// <param name="enumType">Enum a ser usado.</param>
        /// <returns>Dictionary contendo o texto e o valor de todos os itens do enum.</returns>
        public static Dictionary<int, string> GetItens(Type enumType)
        {
            if (!enumType.IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type.");
            }

            Dictionary<int, string> dic = new Dictionary<int, string>();
            string[] names = System.Enum.GetNames(enumType);

            foreach (string item in names)
            {
                System.Enum e = (System.Enum)System.Enum.Parse(enumType, item);

                dic.Add(e.ToInt32(), GetDescription(e));
            }

            return dic;
        }

        /// <summary>
        /// Retorna o value de um enum a partir de uma string (description do enum)
        /// </summary>
        /// <param name="T">Enum a ser usado.</param>
        /// <param name="description">Description que deseja se saber o value.</param>
        /// <returns>Value do Enum.</returns>
        public static T Parse<T>(string description)
        {

            Type t = typeof(T);

            if (!t.IsEnum) throw new ArgumentException("Type provided must be an Enum", "TEnum");

            return (T)Enum.Parse(typeof(T), description);
        }
    }
}
