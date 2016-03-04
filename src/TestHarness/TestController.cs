using System.Web.Http;

namespace TestHarness
{
    public class TestController : ApiController
    {
        public class Model
        {
            public string Value { get; set; }
        }

        [Route("test")]
        public IHttpActionResult Post(Model value)
        {
            return Ok(value);
        }
    }
}