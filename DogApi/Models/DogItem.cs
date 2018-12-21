using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogApi.Models
{
    public class DogItem
    {
        public long Id { get; set; }
        public string Path { get; set; }
        public string Breed { get; set; }
    }
}
