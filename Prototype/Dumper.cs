using System;
using Newtonsoft.Json;
public static class Dumper
{
    public static string ToPrettyString(this object value)
    {
         return JsonConvert.SerializeObject(value, Formatting.Indented);
    }

    public static T Dump<T>(this T value)
    {
        Console.WriteLine(value.ToPrettyString());
        return value;
    }
}