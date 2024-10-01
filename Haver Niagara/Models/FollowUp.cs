using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable

namespace Haver_Niagara.Models
{
    public class FollowUp
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Display(Name = "Expected Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FollowUpDate { get; set; }

        [Display(Name = "Type")]
        public string? FollowUpType { get; set; }

#nullable disable

        [ForeignKey("Operation")]
        public int? OperationID { get; set; }
        public Operation Operation { get; set; }
    }
}
