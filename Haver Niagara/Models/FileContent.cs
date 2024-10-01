using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Haver_Niagara.Models
{
    public class FileContent
    {
        //Dependant Entity and is in a 1:1
        [Key, ForeignKey("UploadedFile")]
        public int FileContentID { get; set; }

        [ScaffoldColumn(false)]
        public byte[] Content { get; set; }

        public UploadedFile UploadedFile { get; set; }
    }
}
