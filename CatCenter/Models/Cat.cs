using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatCenter.Models
{
    internal class Cat
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? BirthDate { get; set; }
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }
        public bool isAdopted { get; set; } = false;
    }
}
