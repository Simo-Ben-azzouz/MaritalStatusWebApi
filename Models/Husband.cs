using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace patrickLearn.Models
{
    public class Husband
    {
        public int HusbandId { get; set; }
        public string Name { get; set; } = "badr";
        public DateTime BirthDay { get; set; }
        public string CIN { get; set; }="tx232323";
        public string? HusbandImageUrl { get; set; }
        // property
        public ICollection<Wife> wives { get; } = new List<Wife>(); // Collection navigation containing dependents
        public ICollection<Chilldren> chilldrens { get; } = new List<Chilldren>(); // Collection navigation containing dependents
        // We have a husband and want to select the corresponding user
        public User? User { get; set; }

    }
}