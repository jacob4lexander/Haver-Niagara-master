using System.ComponentModel.DataAnnotations;

namespace Haver_Niagara.Models
{
    public enum EmployeeRole
    {
        //Following https://brightspace.niagaracollege.ca/d2l/le/content/94930/viewContent/1373726/View (LM7-2 Demo: Maintain Employee)
        None,
        [Display(Name = "Quality Representative")]          //So these are the employee roles so far
        QualityRepresentative,
        [Display(Name = "Engineer")]
        Engineering,
        [Display(Name = "Operations")]
        Operations,
        [Display(Name = "Procurement")]
        Procurement,
        [Display(Name = "Finance")]
        Finance
    }
}
