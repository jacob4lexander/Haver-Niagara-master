using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable enable


namespace Haver_Niagara.Models
{
    public class Procurement : IValidatableObject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; } //PK

        [Display(Name = "Return rejected items to supplier")]
        [Required(ErrorMessage = "Please select if rejected items should be returned")]
        public bool ReturnRejected { get; set; } //Return rejected items to supplier?

        //if ReturnRejected = true (yes)
        [Display(Name = "RMA No.")]
        public int? RMANumber {  get; set; }

        [Display(Name = "Carrier")]
        public string? CarrierName {  get; set; }

        [Display(Name = "Carrier Phone No.")]
        public string? CarrierPhone { get; set; }

        [Display(Name = "Account No.")]
        public int? AccountNumber { get; set; }

        [Display(Name = "Dispose on site")] 
        public bool? DisposeOnSite {  get; set; } //if ReturnRejected = false (no)

        [Display(Name = "When will replacement/ reworked item be received/returned?")]
        [Required(ErrorMessage = "Date is Required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ToReceiveDate { get; set; } //When will replacement/reworked item be received/returned?

        [Display(Name = "Supplier return has been completed in SAP")]
        public bool SuppReturnCompletedSAP {  get; set; } //Supplier return has been completed in SAP

        [Display(Name = "Expecting credit from supplier")]
        public bool ExpectSuppCredit {  get; set; } //Expecting credit from supplier

        [Display(Name = "Billing supplier for expenses incurred in the rework process")]
        public bool BillSupplier {  get; set; } //Billing supplier for expenses incurred in rework process



#nullable disable

        public NCR NCR { get; set; } //FK
        public Procurement()
        {
            ToReceiveDate = DateTime.Today;
        }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ReturnRejected == true)
            {
                if (RMANumber <= 0 || RMANumber == null)
                    yield return new ValidationResult("RMA Number is Required.", new[] { "RMANumber" });
                if (string.IsNullOrWhiteSpace(CarrierName))
                    yield return new ValidationResult("Carrier Name is Required.", new[] { "CarrierName" });
                if (string.IsNullOrWhiteSpace(CarrierPhone))
                    yield return new ValidationResult("Carrier Phone Number is Required.", new[] { "CarrierPhone" });
                if (AccountNumber <= 0 || AccountNumber == null)
                    yield return new ValidationResult("Account Number is Required.", new[] { "AccountNumber" });
            }
            var today = DateTime.Today;
            if(ToReceiveDate < today)
            {
                yield return new ValidationResult("Recieve Date Cannot Be in The Past", new[] { "ToReceiveDate" });
            }
        }
    }
}
