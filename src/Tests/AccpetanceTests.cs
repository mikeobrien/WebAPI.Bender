using System;
using System.IO;
using System.Net;
using NUnit.Framework;
using Should;

namespace Tests
{
    [TestFixture]
    public class AccpetanceTests
    {
        private Website _website;

        [TestFixtureSetUp]
        public void Setup()
        {
            _website = Website.Create(@"..\..\..\TestHarness");
            _website.Start();
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            _website.Stop();
        }

        [Test]
        public void should_deserialize_and_serialize_with_bender()
        {
            var client = new WebClient();
            client.Headers.Add("content-type", "application/json");
            client.Headers.Add("accept", "application/json");
            try
            {
                client.UploadString($"{_website.Url}test",
                    "{\"value\":\"fark\"}").ShouldEqual("{\"value\":\"fark\"}");
            }
            catch (WebException exception)
            {
                Console.WriteLine(new StreamReader(exception.Response.GetResponseStream()).ReadToEnd());
                throw;
            }
        }
    }
}