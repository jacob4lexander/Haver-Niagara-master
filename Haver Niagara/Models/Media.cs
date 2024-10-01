using System.ComponentModel.DataAnnotations;

namespace Haver_Niagara.Models
{
    public class Media
    {
        public int ID { get; set; }

        [ScaffoldColumn(false)]
        public byte[] Content { get; set; }

        //Description of Image
        public string Description { get; set; }

        [StringLength(255)]
        public string MimeType { get; set; }

        public string Links { get; set; }

        //media notes?
        public string Notes { get; set; }

        //foreign key 
        public int PartID { get; set; }
        public Part Part { get; set; }
    }
}
