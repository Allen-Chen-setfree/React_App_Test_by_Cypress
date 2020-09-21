using NUnit.Framework;
using api.Services;
using System;
using RestSharp;
using RestSharp.Authenticators;
using System.Net;
using Newtonsoft.Json.Linq;
using Microsoft.VisualBasic.CompilerServices;

namespace api.tests
{

    public class testPageContent
    {
        private const string denyMsg = "System.Collections.Generic.KeyNotFoundException";

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        [TestCase("home","Home")]
        [TestCase("factorial","N!")]
        [TestCase("fibonacci","Fib(n)")]
        [TestCase("randomSquare","Random square")]
        public void Test_Page_Title(String path, String title)
        {
            RestClient client = new RestClient("http://localhost:3001/api/content/"+path);
            RestRequest request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.ContentType, Is.EqualTo("application/json; charset=utf-8"));
            string result = (string)JObject.Parse(response.Content).SelectToken("title");
            Assert.AreEqual(title,result);
        }

        [Test]
        [TestCase("random_deny", denyMsg)]
        public void Test_Fibonacci_Deny(string path, string msg)
        {
            RestClient client = new RestClient("http://localhost:3001/api/content/"+path);
            RestRequest request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
            Assert.That(response.ContentType, Is.EqualTo("text/plain"));
            StringAssert.Contains(msg, response.Content);

        }

    }
}