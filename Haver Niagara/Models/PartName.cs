using System.ComponentModel.DataAnnotations;

namespace Haver_Niagara.Models
{
    public class PartName
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "You cannot leave the name of the part blank")]
        [Display(Name = "Part Name")]
        public string Name { get; set; }

        //Part Name can have many Part Objects
        public ICollection<Part> Parts { get; set; } = new HashSet<Part>();
    }
}
