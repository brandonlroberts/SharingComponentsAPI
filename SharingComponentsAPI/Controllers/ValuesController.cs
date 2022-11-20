using Microsoft.AspNetCore.Mvc;
using SharingComponentsAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SharingComponentsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private static List<ValueModel> _values = new List<ValueModel>()
        {
               new ValueModel() { Id = 1, Value = "Brandon" },
               new ValueModel() { Id = 2, Value = "Alex" },
               new ValueModel() { Id = 3, Value = "Jason" },
               new ValueModel() { Id = 4, Value = "Ben" },
               new ValueModel() { Id = 5, Value = "Vinnie" }
        };

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<ValueModel> Get()
        {
            return _values.OrderBy(x => x.Id);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ValueModel Get(int id) => _values.FirstOrDefault(x => x.Id == id);

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] ValueModel valueModel)
        {
            _values.Add(valueModel);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ValueModel valueModel)
        {
            _values.Remove(_values.Where(x => x.Id == id).FirstOrDefault());
            _values.Add(valueModel);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _values.Remove(_values.Where(x => x.Id == id).FirstOrDefault());
        }
    }
}
