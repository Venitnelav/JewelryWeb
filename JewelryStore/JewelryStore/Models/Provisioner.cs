using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JewelryStore.Models
{
    public class Provisioner
    {
        [Key]
        public int pID { get; set; }
        public string  Name { get; set; }
        public string TelNumber { get; set; }

        public ICollection<EResin> eresins{ get; set; }
        public ICollection<MComponent> mComponents { get; set; }
        public ICollection<OComponent> oComponents { get; set; }
        //public ic
        //public EResin EResin { get; set; }
        //public MComponent MComponent{ get; set; }
        //public OComponent OComponent { get; set; }

    }
}
