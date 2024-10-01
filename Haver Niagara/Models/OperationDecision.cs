using System.ComponentModel.DataAnnotations;

namespace Haver_Niagara.Models
{
    public enum OperationDecision
    {
        [Display(Name ="Rework In House")]
        ReworkInHouse,
        [Display(Name ="Scrap In House")]
        ScrapInHouse,
        [Display(Name ="Defer for HBC Engineering Review")]
        DeferToEngineering,
        [Display(Name ="Return To Supplier for either rework or replacement")]
        ReturnToSupplier
    }
}
