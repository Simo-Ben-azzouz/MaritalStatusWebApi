using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using patrickLearn.DTOs.Wife;
using patrickLearn.Models;

namespace patrickLearn.DTOs.Husband
{
    public class GetHusbandDTO
    {
         public int HusbandId { get; set; }
        public string Name { get; set; } = "badr";
        public DateTime BirthDay { get; set; }
        public string CIN { get; set; }="tx232323";
        public string? HusbandImageUrl { get; set; }
        public List<GetWifeDTO>? wives { get; set; }

    }
}