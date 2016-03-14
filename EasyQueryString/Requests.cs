using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace EasyQueryString
{
    public static class Requests
    {
        public static T GetFromQueryString<T>(RequestType type = RequestType.GET) where T : new()
        {
            var obj = new T();
            var properties = typeof(T).GetProperties();

            var queries = new NameValueCollection();
            if (type == RequestType.GET)
                queries = HttpContext.Current.Request.QueryString;
            else
            {
                queries = HttpContext.Current.Request.Form;
            }

            foreach (var property in properties)
            {
                foreach (Attribute attribute in property.GetCustomAttributes(true))
                {
                    var requestBodyField = attribute as RequestBodyField;
                    if (requestBodyField == null) continue;

                    //get value of query string
                    var valueAsString = queries[requestBodyField.Field];

                    if (valueAsString == null)
                    {
                        var keys = from key in queries.AllKeys where key.StartsWith(requestBodyField.Field) select key;

                        if (!keys.Any())
                            continue;

                        var collection = new NameValueCollection();

                        foreach (var key in keys)
                        {
                            var openBraketIndex = key.IndexOf("[", StringComparison.Ordinal);
                            var closeBraketIndex = key.IndexOf("]", StringComparison.Ordinal);

                            if (openBraketIndex < 0 || closeBraketIndex < 0)
                                throw new Exception("query string is crupted.");

                            openBraketIndex++;
                            //get key in [...]
                            var fieldName = key.Substring(openBraketIndex, closeBraketIndex - openBraketIndex);
                            collection.Add(fieldName, queries[key]);
                        }
                        property.SetValue(obj, collection, null);
                        continue;
                    }

                    var converter = TypeDescriptor.GetConverter(property.PropertyType);
                    var value = converter.ConvertFrom(valueAsString);

                    if (value == null)
                        continue;

                    property.SetValue(obj, value, null);
                }
            }
            return obj;
        }
    }
}
