using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JewelryStore.Models
{
    public class Jewelry
    {
        [Key]
        public int jID { get; set; }
        public byte[] Image { get; set; }
        public string Name { get; set; }
        public string Cost { get; set; }
        public bool InStock { get; set; }
        public int mcID { get; set; }
        public int erID { get; set; }
        public int oID { get; set; }
       
  
        public  OComponent OComponents { get; set; }
        public MComponent  MComponents { get; set; }
        public EResin EResins { get; set; }
    }
}
