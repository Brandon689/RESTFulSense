﻿// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.IO;
using System.Net.Http;

namespace RESTFulSense.Brokers.MultipartFormDataContents
{
    internal interface IMultipartFormDataContentBroker
    {
        MultipartFormDataContent AddByteArrayContent(
            MultipartFormDataContent multipartFormDataContent,
            byte[] content,
            string name);

        MultipartFormDataContent AddByteArrayContent(
            MultipartFormDataContent multipartFormDataContent,
            byte[] content,
            string name,
            string fileName);

        MultipartFormDataContent AddStringContent(
            MultipartFormDataContent multipartFormDataContent,
            string content,
            string name);

        MultipartFormDataContent AddStreamContent(
            MultipartFormDataContent multipartFormDataContent,
            Stream stream,
            string name);

        MultipartFormDataContent AddStreamContent(
            MultipartFormDataContent multipartFormDataContent,
            Stream content,
            string name,
            string fileName);

        MultipartFormDataContent AddContentHeader(
            MultipartFormDataContent multipartFormDataContent,
            string name,
            string value);
    }
}
