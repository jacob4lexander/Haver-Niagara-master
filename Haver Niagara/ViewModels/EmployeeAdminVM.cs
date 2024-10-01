using Haver_Niagara.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Haver_Niagara.ViewModels
{
    /// <summary>
    /// Add back in any Restricted Properties and list of UserRoles
    /// </summary>
    [ModelMetadataType(typeof(EmployeeMetaData))]
    public class EmployeeAdminVM : EmployeeVM
    {
        public string Email { get; set; }
        //public bool Prescriber { get; set; } //can be replaced with something like, can this employee..create a pocurement? t/f..
        //public EmployeeRole EmployeeRole{ get; set; }
        public bool Active { get; set; }

        public List<string> UserRoles { get; set; } = new List<string>();
    }
}
