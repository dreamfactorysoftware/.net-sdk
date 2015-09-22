namespace DreamFactory.AddressBook.Extensions
{
    using System;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Web.Routing;

    public static class Extensions
    {
        public static RouteValueDictionary ToRouteValues(this NameValueCollection col, Object obj = null)
        {
            string[] skip = { "offset", "limit" };

            var values = new RouteValueDictionary(obj);
            if (col != null)
            {
                foreach (string key in col)
                {
                    //values passed in object override those already in collection
                    if (!values.ContainsKey(key) && !skip.Contains(key.ToLowerInvariant())) values[key] = col[key];
                }
            }
            return values;
        }
    }
}
