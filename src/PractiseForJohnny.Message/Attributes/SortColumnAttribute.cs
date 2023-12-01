namespace PractiseForJohnny.Message.Attributes;

public class SortColumnAttribute : System.Attribute
{
    public SortColumnAttribute(string sortKey, string sortValue)
    {
        SortKey = sortKey;
        SortValue = sortValue;
    }

    public string SortKey { get; set; }

    public string SortValue { get; set; }
}