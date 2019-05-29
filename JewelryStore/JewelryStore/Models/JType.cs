using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JewelryStore.Models
{
    public class JType
    {
        [Key]
        public int jtID { get; set; }
        public string Name { get; set; }



        public ICollection< MComponent> MComponent{ get; set; }
    }
}
