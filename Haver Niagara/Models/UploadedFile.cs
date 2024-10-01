
using System.ComponentModel.DataAnnotations;

namespace Haver_Niagara.Models
{
    public class UploadedFile
    {
        public int ID { get; set; }

        [StringLength(255,ErrorMessage = "File name cannot exceed 255 characters.")]
        [Display(Name = "File Name")]
        public string FileName { get; set; }

        [StringLength(255)]
        public string MimeType { get; set; }

        public FileContent FileContent { get; set; } = new FileContent();    
    }
}
