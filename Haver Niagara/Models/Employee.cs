using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Haver_Niagara.Models
{
    [ModelMetadataType(typeof(EmployeeMetaData))]
    public class Employee : Auditable
    {
        public int ID { get; set; }

        [Display(Name = "Employee")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public string FormalName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }

        public string FirstName { get; set; }

     
        public string LastName { get; set; }

        public string Email { get; set; }

        public bool Active { get; set; } = true;

        public ICollection<Subscription> Subscriptions { get; set; }
    }
}
