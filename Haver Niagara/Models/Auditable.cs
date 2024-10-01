using System.ComponentModel.DataAnnotations;

namespace Haver_Niagara.Models
{
    public abstract class Auditable : IAuditable //from previous mvc course copy n paste files
    {
        [ScaffoldColumn(false)]
        [StringLength(256)]
        public string CreatedBy { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? CreatedOn { get; set; }

        [ScaffoldColumn(false)]
        [StringLength(256)]
        public string UpdatedBy { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? UpdatedOn { get; set; }
    }

}
