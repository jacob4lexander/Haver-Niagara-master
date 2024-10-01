namespace Haver_Niagara.Models
{
    internal interface IAuditable   //Got from old MVC Text Files
    {
        string CreatedBy { get; set; }
        DateTime? CreatedOn { get; set; }
        string UpdatedBy { get; set; }
        DateTime? UpdatedOn { get; set; }
    }
}
