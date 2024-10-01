using System.ComponentModel.DataAnnotations;

namespace Haver_Niagara.Models
{
    public enum EngineeringDisposition
    {
        [Display(Name ="Rework")]
        Rework,
        [Display(Name="Scrap")]
        Scrap,
        [Display(Name ="Use As Is")]
        UseAsIs,
        [Display(Name = "Repair")]
        Repair
    }
}
