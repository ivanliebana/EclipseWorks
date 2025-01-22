using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text;

namespace EclipseWorks.Helper.Json
{
    public class JsonUtility<T> where T : class
    {
        public static StringContent CreateJsonObjectContent(T model)
        {
            var jsonObject = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");

            return content;
        }

        public static T GetObjectFromJson(string value)
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value, settings);
        }

        public static string SetObjectAsJson(object value)
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Newtonsoft.Json.Formatting.None
            };

            var jsonString = JsonConvert.SerializeObject(value, settings);

            if (!jsonString.IsNullOrEmpty())
            {
                jsonString = jsonString.Replace("'", @"\'"); 
                jsonString = jsonString.Replace("`", @"\`"); 
                jsonString = jsonString.Replace(@"\t", "");
            }

            return jsonString;
        }
    }
}
