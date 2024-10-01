using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Haver_Niagara.Models
{
    public class CAR
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Display(Name = "CAR Number")]
        public int? CARNumber { get; set; }

        [Display(Name = "CAR Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Date { get; set; }

        //One to One with Operations
        [ForeignKey("Operation")]
        public int? OperationID { get; set; }
        public Operation Operation { get; set; }
    }
}
