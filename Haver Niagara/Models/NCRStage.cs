using System.ComponentModel.DataAnnotations;

namespace Haver_Niagara.Models
{
    public enum NCRStage    //If you're going to re order these or want to make changes LET ME KNOW (DORIAN) because currently the ncr stage system is RELIANT on the values of each enum value.
    {
        [Display(Name = "Quality Rep")] //0
        QualityRepresentative,
        [Display(Name = "Engineering")] //1
        Engineering,
        [Display(Name = "Operations")] //2
        Operations,
        [Display(Name = "Procurement")] //3
        Procurement,
        [Display(Name = "Quality Rep")] //4
        QualityRepresentative_Final,
        //[Display(Name = "Complete")]
        //Completed,
        [Display(Name = "Complete")] //5       
        Closed_NCR
    }
}
