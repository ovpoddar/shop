﻿using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Routing;
using Shop.Builders;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xunit;
using Xunit.Sdk;

namespace Shop.Tests.BuildersTest
{
    public class RequestBuilderTest
    {
        private readonly RequestBuilder _requestBuilder;
        public RequestBuilderTest()
        {
            _requestBuilder = new RequestBuilder();
        }

        [Fact]
        public void BuildRequestWithoutParameterTest()
        {
            var uri = "myServer/api/location/guid";
            var method = HttpMethod.Patch;

            var output = _requestBuilder.BuildRequest(method, uri);

            output.RequestUri.Should().Be($"{uri}");
            output.Method.Should().Be(method);
        }

        //[Theory]
        //[InlineData()]
        //public void BuildRequestWithParameterTest(HttpMethod method)
        //{
        //    var uri = "myServer/api/location/guid";
        //    const string content = "Content";

        //    var output = _requestBuilder.BuildRequest(method, uri, content);

        //    output.Method.Should().Be(method);
        //    output.RequestUri.Should().Be(uri);
        //    output.Content.ReadAsStringAsync().Result.Should().Be(content);
        //}

    }
}
