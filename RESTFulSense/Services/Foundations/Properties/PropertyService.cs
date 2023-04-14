﻿// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using RESTFulSense.Brokers.Reflections;
using RESTFulSense.Models.Foundations.PropertyValues;

namespace RESTFulSense.Services.Foundations.Properties
{
    internal class PropertyService : IPropertyService
    {
        private readonly IReflectionBroker reflectionBroker;

        public PropertyService(IReflectionBroker reflectionBroker) =>
            this.reflectionBroker = reflectionBroker;

        public IEnumerable<PropertyValue> RetrieveProperties<T>(T @object) where T : class =>
            throw new System.NotImplementedException();

        //public IEnumerable<PropertyValue> RetrieveProperties<T>(T @object) where T : class =>
        //    this.reflectionBroker.GetPropertyValues<T>(@object);
    }
}
