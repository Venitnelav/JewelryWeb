using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace JewelryStore.Models
{
    public class EResin
    {
        [Key]
        public int erID { get; set; }
        public string Name { get; set; }
        public string Cost { get; set; }
        public bool InStock { get; set; }
        public int pID { get; set; }


        public ICollection< Jewelry >jewelry { get; set; }
        public Provisioner provisioner { get; set; }
    }
}
