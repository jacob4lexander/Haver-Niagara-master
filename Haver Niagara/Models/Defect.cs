using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Haver_Niagara.Models
{
    public class Defect
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required(ErrorMessage = "You cannot leave the name of the defect blank")]
        [Display(Name = "Defect Name")]
        public string Name { get; set; }
        public ICollection<DefectList> DefectLists { get; set; } = new HashSet<DefectList>();
    }
}
