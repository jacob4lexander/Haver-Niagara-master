using System.ComponentModel.DataAnnotations;

namespace Haver_Niagara.Models
{
    public class SAPNumber
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "You cannot leave the SAP # blank")]
        [Display(Name = "SAP Number")]
        public int Number { get; set; }

        //SAP Number can have many Part Objects
        public ICollection<Part> Parts { get; set; } = new HashSet<Part>();
    }
}
