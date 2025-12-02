using System;

public class Common
{
    public static int GetEnumLength<T>()
    {
        return Enum.GetValues(typeof(T)).Length;
    }
}
