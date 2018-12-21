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


        /// <summary>
        /// Gets all dogs
        /// </summary>
        /// <returns></returns>
        // GET: api/Dog
        [HttpGet]
        public ActionResult<IEnumerable<DogItem>> GetDogItems()
        {
            return _service.GetAllDogs();
        }

        /// <summary>
        /// Gets a random dog from a breed
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     
        ///     Get /Dog/specificbreed
        ///     {
        ///         "breed": "Labrador"
        ///     }
        ///     
        ///     Get /Dog/Random
        ///     {
        ///         "breed": "Random"
        ///     }
        /// </remarks>
        /// <param name="breed"></param>
        /// <returns></returns>
        [HttpGet("{breed}")]
        public ActionResult<DogItem> GetRandomDogItem(string breed)
        {
            return _service.GetRandomDog(breed);
        }

        /// <summary>
        /// Gets a dog from a dogs ID
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     Get /Dog/id
        ///     {
        ///         "id": 21
        ///     }
        ///     
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>
        ///     Dog object
        ///     {
        ///         "id": 21
        ///         "breed": "Labrador"
        ///         "path": "Imgpath"
        ///     }
        /// 
        /// </returns>
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
        /// <remarks>
        /// Sample request:
        /// 
        ///     Post /Dog
        ///     {
        ///         "breed": "Labrador",
        ///         "path": "imgurl"
        ///     }
        ///     
        /// </remarks>
        /// <param name="dog"></param>
        [HttpPost]
        public ActionResult<DogItem> AddDog(DogItem dog)
        {
            _service.AddDog(dog);
            return CreatedAtAction("GetDogItem", new { id = dog.Id }, dog);
        }

        /// <summary>
        /// Deletes a dog from the list
        /// </summary>
        /// <remarks>
        ///     Delete /Dog/id
        ///     {
        ///     
        ///     }
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
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
