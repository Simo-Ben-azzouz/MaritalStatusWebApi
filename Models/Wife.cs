using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace patrickLearn.Models
{
    public class Wife
    {
        public int WifeId { get; set; }
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public string CIN { get; set; }
        public string? WifeImageUrl { get; set; }    
        // property
    public int HusbandId { get; set; } // Required foreign key property
    public Husband husband { get; set; } = null!; // Required reference navigation to principal
        // child
    public ICollection<Chilldren> chilldrens { get; } = new List<Chilldren>(); // Collection navigation containing dependents
    
    }
}