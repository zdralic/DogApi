using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogApi.Models;

namespace DogApi.Service_Layer
{
    public interface IDogService
    {
        List<DogList> GetAllDogs();
        //DogItem GetRandomDog();
        //DogItem GetRandomDogByBreed();
        //DogList GetDogByBreed(string breed);

    }

    public class DogService : IDogService
    {
        private readonly DogContext _context;

        public DogService(DogContext context)
        {
            _context = context;

            if (_context.DogLists.Count() == 0)
            {
                _context.DogLists.Add(new DogList { Breed = "Labrador", Dogs = new List<DogItem> { new DogItem { Path = @"https://www.google.com/url?sa=i&source=images&cd=&cad=rja&uact=8&ved=2ahUKEwjLz__htq7fAhXHLFAKHXVQBzMQjRx6BAgBEAU&url=https%3A%2F%2Fwww.akc.org%2Fdog-breeds%2Flabrador-retriever%2F&psig=AOvVaw2vxAb-bs07C_8vapiNvs-9&ust=1545395973798237" } } });
                _context.SaveChanges();
            }
        }

        public List<DogList> GetAllDogs()
        {
            return _context.DogLists.ToList();
        }

    }
}
