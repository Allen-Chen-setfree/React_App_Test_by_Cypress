using NUnit.Framework;
using api.Services;
using System;
using RestSharp;
using RestSharp.Authenticators;
using System.Net;
using Newtonsoft.Json.Linq;


namespace api.tests
{

    public class testFibonacciCalculatorService
    {
        private const string denyMsg = "System.NotSupportedException: n > 10 or n < 0 is not supported";

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(2, 1)]
        [TestCase(10, 55)]
        public void Test_Fibonacci(int num, int result)
        {
            RestClient client = new RestClient("http://localhost:3001/api/math/fibonacci/"+num);
            RestRequest request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.ContentType, Is.EqualTo("application/json; charset=utf-8"));
            int outcome = (int)JObject.Parse(response.Content).SelectToken("result");
            Assert.AreEqual(result, outcome);
        }


        [Test]
        [TestCase(-1, denyMsg)]
        [TestCase(11, denyMsg)]
        public void Test_Fibonacci_Deny(int num, string msg)
        {
            RestClient client = new RestClient("http://localhost:3001/api/math/fibonacci/" + num);
            RestRequest request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
            Assert.That(response.ContentType, Is.EqualTo("text/plain"));
            StringAssert.Contains(msg, response.Content);

        }



    }
}