namespace DreamFactory.Demo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;

    internal static class Extensions
    {
        public static string ToStringList(this IEnumerable<string> list)
        {
            string temp = string.Join(", ", list.Where(x => !string.IsNullOrEmpty(x)));
            return String.Format("[{0}]", temp);
        }

        public static TTarget Convert<TSource, TTarget>(this TSource src)
        {
            string json = JsonConvert.SerializeObject(src);
            return JsonConvert.DeserializeObject<TTarget>(json);
        }
    }
}
