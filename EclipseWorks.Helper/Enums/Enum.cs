using System.ComponentModel;

namespace EclipseWorks.Helper.Enums
{
    public class EnumLoad
    {
        public static List<KeyValuePair<string, short>> LoadTaskPriority()
        {
            var objEnumList = EnumUtil.GetItens<eTaskPriority>();

            var objList = new List<KeyValuePair<string, short>>();

            foreach (var obj in objEnumList)
                objList.Add(new KeyValuePair<string, short>(obj.Value, obj.Key.ToInt16()));

            objList = [.. objList.OrderBy(o => o.Key)];

            return objList;
        }

        public static List<KeyValuePair<string, short>> LoadTaskStatus()
        {
            var objEnumList = EnumUtil.GetItens<eTaskStatus>();

            var objList = new List<KeyValuePair<string, short>>();

            foreach (var obj in objEnumList)
                objList.Add(new KeyValuePair<string, short>(obj.Value, obj.Key.ToInt16()));

            objList = [.. objList.OrderBy(o => o.Key)];

            return objList;
        }
    }

    public enum eTaskPriority
    {
        [Description("Low")]
        Low = 1,
        [Description("Medium")]
        Medium = 2,
        [Description("High")]
        High = 3
    }

    public enum eTaskStatus
    {
        [Description("Pending")]
        Pending = 1,
        [Description("In progress")]
        InProgress = 2,
        [Description("Completed")]
        Completed = 3
    }
}
