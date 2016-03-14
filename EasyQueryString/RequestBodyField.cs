using System;

namespace EasyQueryString
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public class RequestBodyField : Attribute
    {
        public string Field;
        public RequestBodyField(string field)
        {
            Field = field;
        }
    }
}
