using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Text;

namespace FlattenArray
{
    public class Flattener : IFlattener
    {
        IUtility _utility;

        public Flattener(IUtility utility)
        {
            _utility = utility;
        }

        public string FlattenJSONString(string arrayInput)
        {
            var commaSeparated = FlattenJSONStringImplement(arrayInput);
            var output = _utility.RemoveLastComma(commaSeparated);

            return output;
        }

        public string FlattenJSONStringImplement(string arrayInput)
        {
            StringBuilder values = new StringBuilder();
            values.Append("");

            if (string.IsNullOrEmpty(arrayInput))
                return "";

            if (arrayInput.Equals("[]"))
                return "";

            JArray array = JsonConvert.DeserializeObject<JArray>(arrayInput);

            foreach (Object value in array)
            {
                if (value is JArray)
                {
                    var jValue = (JArray)value;
                    values.Append(FlattenJSONStringImplement(jValue.ToString()));
                }
                else
                {
                    if (_utility.CheckIfInteger(value))
                    {
                        var valueString = value.ToString();
                        values.Append(valueString.Replace("{", "").Replace("}", "") + ",");
                    }
                    else
                        values.Append("invalid,");
                }
            }
            
            return values.ToString();
        }

        public string FlattenString(string arrayInput)
        {
            var commaSeparated = FlattenStringImplement(arrayInput);
            var output = _utility.RemoveLastComma(commaSeparated);

            return output;
        }

        public string FlattenStringImplement(string arrayInput)
        {
            if (string.IsNullOrEmpty(arrayInput))
                return "";

            if (arrayInput.Equals("[]"))
                return "";

            arrayInput = arrayInput.Replace("[", "")
                                    .Replace("]", "");

            return arrayInput;
        }
    }
}
