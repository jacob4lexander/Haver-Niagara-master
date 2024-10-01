using System.ComponentModel.DataAnnotations;
namespace Haver_Niagara.Models
{
    public enum QualityIdentify
    {
        [Display(Name ="Supplier or Rec-Insp")]
        Supplier_Or_Rec_Inspection,

        [Display(Name ="WIP (Production Order)")]
        WIP_Production_Order
    }
}
