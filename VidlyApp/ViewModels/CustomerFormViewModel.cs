using System.ComponentModel.DataAnnotations;
using VidlyApp.Models;

namespace VidlyApp.ViewModels;

public class CustomerFormViewModel
{
    public int Id { get; set; }
    [Display(Name = "Membership Type")]
    public int MembershipTypeId { get; set; }
    public required IEnumerable<MembershipType> MembershipTypes { get; set; }
    public string Name { get; set; } = string.Empty;
    [Display(Name = "Date of Birth")]
    public DateTime? Birthdate { get; set; }
    public bool IsSubscribedToNewsletter { get; set; }
}