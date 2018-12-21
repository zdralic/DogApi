using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogApi.Models;

namespace DogApi.Service_Layer
{
    public interface IDogService
    {
        List<DogItem> GetAllDogs();
        DogItem GetDog(long id);
        void AddDog(DogItem dog);
        DogItem GetRandomDog(string breed);
        void DeleteDog(long id);
        //DogItem GetRandomDogByBreed();
        //DogList GetDogByBreed(string breed);

    }

    public class DogService : IDogService
    {
        private static Random random = new Random();
        private readonly DogContext _context;

        public DogService(DogContext context)
        {
            _context = context;

            if (_context.DogList.Count() == 0)
            {
                _context.DogList.Add(new DogItem { Breed = "Labrador", Path = @"https://s3.amazonaws.com/cdn-origin-etr.akc.org/wp-content/uploads/2017/11/12231410/Labrador-Retriever-On-White-01.jpg" });
                _context.DogList.Add(new DogItem { Breed = "Pitbull", Path = @"https://s3.amazonaws.com/cdn-origin-etr.akc.org/wp-content/uploads/2017/11/12231410/Labrador-Retriever-On-White-01.jpg" });
                _context.SaveChanges();
            }
        }

        public List<DogItem> GetAllDogs()
        {
            return _context.DogList.ToList();
        }

        public DogItem GetDog(long id)
        {
            return _context.DogList.Find(id);
        }

        public void AddDog(DogItem dog)
        {
            _context.DogList.Add(dog);
            _context.SaveChanges();
        }

        public DogItem GetRandomDog(string breed)
        {
            if (breed == "Random")
            {
                var dogItem = _context.DogList.ToList()[random.Next(_context.DogList.Count())];
                return dogItem;
            }
            else
            {
                List<DogItem> filteredDogs = _context.DogList.Where(obj => obj.Breed == breed).ToList();
                var dogItem = filteredDogs[random.Next(filteredDogs.Count())];
                return dogItem;
            }
        }

        public void DeleteDog(long id)
        {
            var dog = GetDog(id);
            _context.DogList.Remove(dog);
            _context.SaveChanges();
        }
    }
}
