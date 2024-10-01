using Haver_Niagara.Data;
using Haver_Niagara.Utilities;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Haver_Niagara.Models
{
    public class NCR
    {
        private readonly HaverNiagaraDbContext _context;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public NCR(HaverNiagaraDbContext context)
        {
            _context = context;
        }

        [Display(Name = "NCR No.")]

        public string FormattedID
        {
            get
            { 
                if (_context != null)
                {
                    var ncrsForYear = _context.NCRs.Where(a => a.NCR_Date.Year == NCR_Date.Year).OrderBy(a => a.ID).ToList();
                    //gets the index position of the list returned and then adds 1 bc lists start at 0.
                    int index = ncrsForYear.FindIndex(a => a.ID == this.ID) + 1;
                    return $"{NCR_Date.Year}-{index.ToString().PadLeft(3, '0')}";
                }
                else
                {
                    return "Error: NCR ID could not be generated";
                }
            }
        }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime NCR_Date { get; set; }

        [Required(ErrorMessage = "Keep NCR Open? field is required")]
        [Display(Name = "Status")]
        public bool NCR_Status { get; set; } //If NCR status == true then report is active, else, report is closed!

        //new properties for new ncrs

        [Display(Name = "New NCR Number")]
        public int? NewNCRID { get; set; }

        [Display(Name = "Old NCR Number")]
        public int? OldNCRID { get; set; }

        public bool? IsArchived
        {
            get
            {
                int daysInFiveYears = 365 * 5 + 1; // 365 days per year + 1 additional day for possible leap year

                if (DateTime.Now.Subtract(NCR_Date).Days >= daysInFiveYears)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            set { }
        }

        public bool? IsVoid { get; set; }

        //NCR Enumeration To Determine the Stage
        [Display(Name = "Stage")]
        public NCRStage NCR_Stage { get; set; }

        // PART ENTITY //
        [ForeignKey("Supplier")]
        [Display(Name = "Select Supplier")]
        [Required(ErrorMessage = "Please select a supplier")]
        //[Range(0, Int32.MaxValue, ErrorMessage = "Please select a Value")]
        public int NCRSupplierID { get; set; }
        public Supplier Supplier { get; set; }

        // PART ENTITY //
        [ForeignKey("Part")]
        public int? PartID { get; set; }
        public Part Part { get; set; }

        // PURCHASING //
        [ForeignKey("Operation")]
        public int? OperationID { get; set; }
        public Operation Operation { get; set; }

        // ENGINEERING // 
        [ForeignKey("Engineering")]
        public int? EngineeringID { get; set; }
        public Engineering Engineering { get; set; }

        // QUALITY //
        [ForeignKey("QualityInspection")]
        public int? QualityInspectionID { get; set; }
        public QualityInspection QualityInspection { get; set; }

        // PROCUREMENT //
        [ForeignKey("Procurement")]
        public int? ProcurementID { get; set; }
        public Procurement Procurement { get; set; }

        // QUALITY FINAL //
        [ForeignKey("QualityInspectionFinal")]
        public int? QualityInspectionFinalID { get; set; }
        public QualityInspectionFinal QualityInspectionFinal { get; set; }

        // DEFAULT CONSTRUCTOR //
        public NCR()
        {
            //Sets the NCR_Status to true because its active bc it was just made
            NCR_Status = true; //change back to false if everthing breaks
            //Defaulting when creating an NCR to have the quality representative as the first stage
            //NCR_Stage = NCRStage.Procurement;
            //Setting a default of todays date
            NCR_Date = DateTime.Today;
            IsVoid = false;
        }
    }
}
