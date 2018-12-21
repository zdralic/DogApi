using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DogApi.Models;
using DogApi.Service_Layer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogController : ControllerBase
    {
        private readonly IDogService _service;

        public DogController(IDogService service)
        {
            _service = service;
        }

        // GET: api/Dog
        [HttpGet]
        public ActionResult<IEnumerable<DogList>> GetTodoItems()
        {
            return _service.GetAllDogs();
        }

        /// <summary>
        /// Deletes a specific TodoItem.
        /// </summary>
        /// <param name="id"></param>   
        [HttpPost]
        public ActionResult<DogItem> AddDog(string breed, DogItem dog)
        {
            _service.AddDog(breed, dog);
            return CreatedAtAction("GetTodoItem", new { id = dog.Id }, dog);
        }
    }
}
