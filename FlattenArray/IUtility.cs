using Newtonsoft.Json.Linq;

namespace FlattenArray
{
    public interface IUtility
    {
        bool CheckIfInteger(object value);
        string RemoveLastComma(string value);
        JArray CommaSeparatedToJSONArray(string value);
    }
}
