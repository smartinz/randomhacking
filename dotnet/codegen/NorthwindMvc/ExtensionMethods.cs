public static class ExtensionMethods
{
    public static T Get<T>(this object o, string getterName)
    {
        return (T) o.GetType().GetProperty(getterName).GetValue(o, null);
    }
}