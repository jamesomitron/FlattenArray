using Newtonsoft.Json.Linq;
using System;

namespace FlattenArray
{
    public class Utility : IUtility
    {
        public bool CheckIfInteger(object value)
        {
            if (value == null)
                return false;

            var valueCheck = value.ToString();
            valueCheck.Replace("{", "").Replace("}", "");
            int num;

            return int.TryParse(valueCheck, out num);
        }

        public string RemoveLastComma(string value)
        {
            char[] lastComma = { ',' };
            return value.EndsWith(',') ? value.TrimEnd(lastComma) : value;
        }

        public JArray CommaSeparatedToJSONArray(string value)
        {
            if (string.IsNullOrEmpty(value))
                return new JArray();

            var splitString = value.Split(',');
            var intArray = Array.ConvertAll<string, int>(splitString, int.Parse);

            return JArray.FromObject(intArray);
        }
    }
}
