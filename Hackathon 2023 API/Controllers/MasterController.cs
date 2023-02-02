using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hackathon_2023_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterController : ControllerBase
    {
        // GET: api/<MasterController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<MasterController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MasterController>
        [HttpPost]
        public async void Post([FromForm] IFormFile file)
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new("http://localhost:5823")
            };

            await using var stream = System.IO.File.OpenRead(@"C:\Hackathon2023\uploadbilleder\pexels-deva-darshan-1123972.jpg");
            using (var multipartFormContent = new MultipartFormDataContent())
            {
                var fileStreamContent = new StreamContent(stream);
                fileStreamContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");

                multipartFormContent.Add(fileStreamContent, name: "file", fileName: "billede.jpg");

                using var request = new HttpRequestMessage(HttpMethod.Post, "file");

                request.Content = multipartFormContent;
                await httpClient.SendAsync(request);
            };
        }

        // PUT api/<MasterController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MasterController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
