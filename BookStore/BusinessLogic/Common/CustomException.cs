namespace Ustoz_Proyekti.BusinessLogic.Common;

public class CustomException(string key, string message)
    : Exception
{
    public string Key { get; set; } = key;
}
