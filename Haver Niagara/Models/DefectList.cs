using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Haver_Niagara.Models
{
    public class DefectList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DefectListID { get; set; }

        //Foreign key to defect
        [Required(ErrorMessage = "test")]
        public int? DefectID { get; set; }   
        public Defect Defect { get; set; }

        //foreign key to product
        public int PartID { get; set; }
        public Part Part{ get; set; }

    }
}
