using ConsumingAnAPI.Contracts;
using ConsumingAnAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ConsumingAnAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDosController : Controller
    {
        private readonly ITodos _todos;

        public ToDosController(ITodos todos)
        {
            _todos = todos;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<List<ToDo>> Get()
        {
            var todos = _todos.Get();
            return Ok(todos);
        }

        [HttpGet]
        //[Route("{id}")]
        [Route("{id}")]
        public ActionResult<ToDo> GetById(int id)
        {

            var product = _todos.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(product);
            }
        }

        [HttpGet]
        //[Route("{id}")]
        [Route("GetByCondition")]
        public ActionResult<List<ToDo>> GetByCondition()
        {
            var query = _todos.Get().Where(t => t.Completed == true);
           
            var products = query.ToList();
            if (products == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(products);
            }
        }

    }
}
