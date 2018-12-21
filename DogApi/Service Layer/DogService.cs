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
                _context.DogList.Add(new DogItem { Breed = "Corgi", Path = @"https://www.pets4homes.co.uk/images/breeds/50/large/d248d59954bb644e4437cce1758a9ce2.jpg" });
                _context.DogList.Add(new DogItem { Breed = "Rottweiler", Path = @"https://www.idenyt.dk/globalassets/denmark/kaledyr-2/rottweiler-i-snor.jpg" });
                _context.DogList.Add(new DogItem { Breed = "Labrador", Path = @"https://www.dagens.dk/files/styles/article_top_fullwidth_1x/public/media/2018/09/labrador_retriever.jpg?itok=FYKbPmAI" });
                _context.DogList.Add(new DogItem { Breed = "Labrador", Path = @"https://www.telegraph.co.uk/content/dam/science/2018/10/21/TELEMMGLPICT000178469115_trans_NvBQzQNjv4BqpVlberWd9EgFPZtcLiMQfyf2A9a6I9YchsjMeADBa08.jpeg?imwidth=450" });
                _context.DogList.Add(new DogItem { Breed = "Corgi", Path = @"http://www.bravotv.com/sites/nbcubravotv/files/styles/blog-post--mobile/public/field_blog_image/2018/04/unleashed-corgi-people-promo.jpg?itok=mKp8i56f&timestamp=1524257239" });
                _context.SaveChanges();
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
