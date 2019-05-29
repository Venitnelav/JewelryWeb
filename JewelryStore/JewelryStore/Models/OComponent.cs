using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JewelryStore.Models
{
    public class OComponent
    {
        [Key]
        public int oID { get; set; }
        public string Name { get; set; }
        public string Cost { get; set; }
        public bool InStock { get; set; }
        public int pID { get; set; }

        public ICollection<Jewelry> jewelries { get; set; }
        public  Provisioner provisioner{ get; set; }
    }
}
