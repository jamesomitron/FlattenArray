namespace FlattenArray
{
    public interface IFlattener
    {
        string FlattenJSONString(string arrayInput);
        string FlattenString(string arrayInput);
        string FlattenJSONStringImplement(string arrayInput);
        string FlattenStringImplement(string arrayInput);
    }
}
