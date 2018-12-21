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
        public ActionResult<IEnumerable<DogItem>> GetDogItems()
        {
            return _service.GetAllDogs();
        }

        [HttpGet("{breed}")]
        public ActionResult<DogItem> GetRandomDogItem(string breed)
        {
            return _service.GetRandomDog(breed);
        }

        //Get: api/dog/5
        [HttpGet("{id}")]
        public ActionResult<DogItem> GetDogItem(long id)
        {
            var dogItem = _service.GetDog(id);
            if (dogItem == null)
            {
                return NotFound();
            }
            return dogItem;
        }

        /// <summary>
        /// Adds a dog
        /// </summary>
        /// <param name="id"></param>   
        [HttpPost]
        public ActionResult<DogItem> AddDog(DogItem dog)
        {
            _service.AddDog(dog);
            return CreatedAtAction("GetDogItem", new { id = dog.Id }, dog);
        }

        [HttpDelete("{id}")]
        public ActionResult<DogItem> DeleteDog(long id)
        {
            var dog = _service.GetDog(id);
            if (dog == null)
            {
                return NotFound();
            }
            _service.DeleteDog(id);
            return dog;
        }
    }
}
