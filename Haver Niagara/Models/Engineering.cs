using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Haver_Niagara.Models
{
    public class Engineering : IValidatableObject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter a name")] //Name
        [Display(Name = "Engineering Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required")] //Date
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Please select one")] //Notify Customer?
        [Display(Name = "Notify Customer Required?")] 
        public bool CustomerNotify { get; set; }

        [Required(ErrorMessage = "Please select one")] //Update Drawing?
        [Display(Name = "Drawing Updated?")]
        public bool DrawUpdate { get; set; }

        [Display(Name = "Disposition Sequence")] //Disposition Notes
        public string? DispositionNotes { get; set; }

        //not required
        [Display(Name = "Original Revision Number")] //Original Revision Number
        public int? RevisionOriginal { get; set; }

        //not required
        [Display(Name = "Updated Revision Number")] //Updated Revision Number
        public int? RevisionUpdated { get; set; }

        [Display(Name = "Revision Date")] //Revision Date
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RevisionDate { get; set; }

        [Display(Name = "Engineering Disposition")] //Review by HBC Engineering (disposition)
        [Required(ErrorMessage = "Please select one")]
        public EngineeringDisposition EngineeringDisposition { get; set; }
        //Link to NCR 
        public NCR NCR { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var TodaysDate = DateTime.Today;
            if (Date > TodaysDate || RevisionDate > TodaysDate)
            {
                yield return new ValidationResult("Date Cannot be in The Future", new[] { "Date", "RevisionDate"});
            }
            if(EngineeringDisposition == EngineeringDisposition.Repair || EngineeringDisposition == EngineeringDisposition.Rework)
            {
                if (string.IsNullOrEmpty(DispositionNotes)){
                    yield return new ValidationResult("Disposition Notes Required", new[] {"DispositionNotes"});
                }
            }
            if(RevisionOriginal != null && RevisionUpdated == null)
                yield return new ValidationResult("Updated Revision Number Required", new[] { "RevisionUpdated" } );
            if (RevisionUpdated != null && RevisionOriginal== null)
                yield return new ValidationResult("Original Revision Number Required", new[] { "RevisionOriginal" });

        }
    }
}
