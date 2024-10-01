using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Haver_Niagara.Models
{
    public class QualityInspection : IValidatableObject
    {
        //Auto generating ID /Key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        //Identify process applicable
        [Display(Name = "Quality Identify")]
        [Required(ErrorMessage = "Please select one")]
        public QualityIdentify QualityIdentify { get; set; }

        //Item marked non-conforming
        [Required(ErrorMessage = "Please select one")]
        [Display(Name = "Item Marked Non-Conforming")]
        public bool ItemMarked { get; set; }

        //Representative Name
        [Required(ErrorMessage = "Please enter a name")]
        [Display(Name = "Quality Representative's Name")]
        public string Name { get; set; }

        //Inspection Date
        [Display(Name = "Quality Representative Inspection Date")]
        [Required(ErrorMessage = "Date is Required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public QualityInspection() //default date to today
        {
            Date = DateTime.Today;
        }

        //Navigation property for NCR
        public NCR NCR { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var TodaysDate = DateTime.Today;
            if (Date > TodaysDate)
            {
                yield return new ValidationResult("Date Cannot be in The Future", new[] { "Date", "InspectorDate", "DepartmentDate" });
            }
        }
    }

    //Final Section (Different Class)
    public class QualityInspectionFinal : IValidatableObject
    {
        //Auto generating ID /Key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Display(Name = "Re-Inspected?")] //Re-inspected Acceptable?
        [Required(ErrorMessage = "Please select one")]
        public bool ReInspected { get; set; }

        [Display(Name = "Inspector's Name")] //Name
        [Required(ErrorMessage = "Please enter a name")]
        public string InspectorName { get; set; }

        [Display(Name = "Inspected Date")] //Date
        [Required(ErrorMessage = "Date is Required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime InspectorDate { get; set; }

        [Display(Name = "Quality Department")] //Department
        [Required(ErrorMessage = "Please enter department")] 
        public string Department { get; set; }

        [Display(Name = "Department Date")] //Department Date
        [Required(ErrorMessage = "Date is Required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DepartmentDate { get; set; }

        //Keep NCR Open = NCR_Status property in NCR class

        public QualityInspectionFinal() //default dates and re-inspect acceptable
        {
            InspectorDate = DateTime.Today;
            DepartmentDate = DateTime.Today;
            ReInspected = true; //default to re-inspected acceptable
        }

        //Navigation property for NCR
        public NCR NCR { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var TodaysDate = DateTime.Today;
            if (InspectorDate > TodaysDate || DepartmentDate > TodaysDate)
            {
                yield return new ValidationResult("Date Cannot be in The Future", new[] { "Date", "InspectorDate", "DepartmentDate" });
            }
        }


    }
}
