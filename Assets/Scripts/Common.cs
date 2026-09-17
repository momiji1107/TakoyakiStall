using System;

public class Common
{
    //enumの要素数を取得する
    public static int GetEnumLength<T>()
    {
        return Enum.GetValues(typeof(T)).Length;
    }
}
