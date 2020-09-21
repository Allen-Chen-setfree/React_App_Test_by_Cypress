using NUnit.Framework;
using api.Services;
using System;
using RestSharp;
using RestSharp.Authenticators;
using System.Net;
using Newtonsoft.Json.Linq;


namespace api.tests
{

    public class testRandomSquareCalculatorService
    {
        private const string denyMsg = "System.Exception: max must be > 0";

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        [TestCase(1, new int[1] { 0 })]
        [TestCase(2, new int[2] { 0, 1 })]
        [TestCase(3, new int[3] { 0, 1, 4 })]
        public void Test_Fibonacci(int num, ref int[] result)
        {
            RestClient client = new RestClient("http://localhost:3001/api/math/random-square/"+num);
            RestRequest request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.ContentType, Is.EqualTo("application/json; charset=utf-8"));
            int outcome = (int)JObject.Parse(response.Content).SelectToken("result");
            CollectionAssert.Contains(result, outcome);
        }


        [Test]
        [TestCase(0, denyMsg)]
        public void Test_Fibonacci_Deny(int num, string msg)
        {
            RestClient client = new RestClient("http://localhost:3001/api/math/random-square/" + num);
            RestRequest request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
            Assert.That(response.ContentType, Is.EqualTo("text/plain"));
            StringAssert.Contains(msg, response.Content);

        }



    }
}