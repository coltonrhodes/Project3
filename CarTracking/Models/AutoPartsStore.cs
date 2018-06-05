using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class AutoPartsStore
    {
        [Key]
        public int id { set; get; }
        public string StoreName { set; get; }
        public string Address { set; get; }
        public virtual ICollection<AutoPartsStore> AutoPartStore { set; get; }
        public virtual ICollection<CarParts> CarParts { set; get; }

    }
}
