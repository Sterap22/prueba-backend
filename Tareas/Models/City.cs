using System.ComponentModel.DataAnnotations;

namespace Tareas.Models
{
    public class City
    {
        [Key]
        public int code { get; set; }
        public string descriptionC { get; set; }
    }
}
