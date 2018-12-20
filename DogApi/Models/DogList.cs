using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogApi.Models
{
    public class DogList
    {
        public List<DogItem> Dogs { get; set; }
        public string Breed { get; set; }
    }
}
