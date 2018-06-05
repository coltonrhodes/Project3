using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class CarParts
    {
        [Key]
        public int id { set; get; }
        public int PartNumber { set; get; }
        public string PartName { set; get; }
        public string VehicleBrand { set; get; }
    }
}
