﻿using System.Net.Http;
using System.Security.Policy;
using System.Text;

namespace Checkout.Builders
{
    public class RequestBuilder : IRequestBuilder
    {
        public HttpRequestMessage BuildRequest(HttpMethod method, Url url, string token)
        {
            var message = new HttpRequestMessage(method, url.Value);
            message.Headers.Add("Authorization", $"Bearer {token}");
            return message;
        }

        public HttpRequestMessage BuildRequest(HttpMethod method, string url, string token, string content)
        {
            var message = new HttpRequestMessage(method, url)
            {
                Content = new StringContent(content, Encoding.UTF8, "application/json")
            };
            message.Headers.Add("Authorization", $"Bearer {token}");
            return message;
        }

        public HttpRequestMessage BuildRequest(HttpMethod method, string url, string content) =>
             new HttpRequestMessage(method, url)
             {
                 Content = new StringContent(content, Encoding.UTF8, "application/json")
             };
    }
}
