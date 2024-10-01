using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Haver_Niagara.Models
{
    public class Supplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required(ErrorMessage = "You cannot leave the name of the supplier blank")]
        [Display(Name = "Supplier Name")]
        public string Name { get; set; }
        public ICollection<Part> Parts { get; set; } = new HashSet<Part>();
    }   
}
