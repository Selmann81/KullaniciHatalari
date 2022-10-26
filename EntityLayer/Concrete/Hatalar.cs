using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityLayer.Concrete
{
    public class Hatalar
    {
        [Key]
        public int HataId { get; set; }
        [Required]
        public string HataBaslik { get; set; }
        public string Hataİcerik { get; set; }
        public string HataCozum { get; set; }
        public bool HataBitti { get; set; }
        public bool Status { get; set; } 

    }
}
