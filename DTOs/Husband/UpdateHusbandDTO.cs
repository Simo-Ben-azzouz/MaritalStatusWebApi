using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace patrickLearn.DTOs.Husband
{
    public class UpdateHusbandDTO
    {
        [Required]
        public int HusbandId { get; set; }
        
        [Required]
        [MinLength(3,ErrorMessage ="name should have at least 3 character")]
        [MaxLength(12,ErrorMessage ="name should not have better than 12 character")]
        public string Name { get; set; } = "badr";
        
        [Required]
        public DateTime BirthDay { get; set; }
        
        [Required]
        [MinLength(8,ErrorMessage ="CIN should not have less than 8 character")]
        [MaxLength(8,ErrorMessage ="CIN should not have greater than 8 character")]
        public string CIN { get; set; }="tx232323";
        public string? HusbandImageUrl { get; set; }

    }
}