using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace patrickLearn.Models
{
    public class Chilldren
    {
        public int ChilldrenId { get; set; }
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public string? ChilldImageUrl { get; set; }
        // porperty
    public int WifeId { get; set; } // Required foreign key property
    public Wife wife { get; set; } = null!; // Required reference navigation to principal
    // proprety
    public int HusbandId { get; set; } // Required foreign key property
    public Husband husband { get; set; } = null!; // Required reference navigation to principal

    }
}