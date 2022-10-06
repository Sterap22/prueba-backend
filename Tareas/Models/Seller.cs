using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace Tareas.Models
{
    public class Seller
    {
        [Key]
        public int code { get; set; }
        public string names { get; set; }
        public string last_name { get; set; }
        public string document { get; set; }
        public int? city_id { get; set; }
        //[ForeignKey("city_id")]
        //public virtual City city_id { get; set; }
        public bool vigente { get; set; }
    }
}
