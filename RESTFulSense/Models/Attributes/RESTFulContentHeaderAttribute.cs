using System;

namespace RESTFulSense.Models.Attributes
{
    [AttributeUsage(validOn: AttributeTargets.Property)]
    public sealed class RESTFulContentHeaderAttribute : Attribute
    {
        //public RESTFulContentHeaderAttribute(string name, string value)
        //{
        //    Name = name;
        //    Value = value;
        //}

        //public string Name { get; }
        //public string Value { get; }

        public RESTFulContentHeaderAttribute(string name) => Name = name;

        public string Name { get; }
    }
}