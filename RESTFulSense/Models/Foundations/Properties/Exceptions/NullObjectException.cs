﻿// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Xeptions;

namespace RESTFulSense.Models.Foundations.Properties.Exceptions
{
    public class NullObjectException : Xeption
    {
        public NullObjectException()
            : base(message: "Object is null.")
        { }
    }
}
