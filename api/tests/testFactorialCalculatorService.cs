using NUnit.Framework;
using api.Services;
using System;
using RestSharp;
using RestSharp.Authenticators;
using System.Net;
using Newtonsoft.Json.Linq;


namespace api.tests
{

    public class testFactorialCalculatorService
    {
        private const string denyMsg = "System.NotSupportedException: n > 10 or n <= 0 is not supported";

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 6)]
        [TestCase(10, 3628800)]
        public void Test_Factorial(int num, int result)
        {
            RestClient client = new RestClient("http://localhost:3001/api/math/factorial/"+num);
            RestRequest request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.ContentType, Is.EqualTo("application/json; charset=utf-8"));
            int outcome = (int)JObject.Parse(response.Content).SelectToken("result");
            Assert.AreEqual(result, outcome);
        }


        [Test]
        [TestCase(0, denyMsg)]
        [TestCase(11, denyMsg)]
        public void Test_Factorial_Deny(int num, string msg)
        {
            RestClient client = new RestClient("http://localhost:3001/api/math/factorial/" + num);
            RestRequest request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
            Assert.That(response.ContentType, Is.EqualTo("text/plain"));
            StringAssert.Contains(msg, response.Content);

        }



    }
}