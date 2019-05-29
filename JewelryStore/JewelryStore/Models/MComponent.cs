using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JewelryStore.Models
{
    
    public class MComponent
    {
        [Key]
        public int mcID { get; set; }
        public string Name { get; set; }
        public string Cost { get; set; }
        public bool InStock { get; set; }
        public int mID      { get; set; }
       // public int pID { get; set; }
       
        public int jtID{ get; set; }
        public int pID { get; set; }


        public Metals Metals { get; set; }
        public Provisioner provisioner { get; set; }
        public JType JType { get; set; }
        public ICollection<Jewelry> jewelries { get; set; }
        
    }
}
