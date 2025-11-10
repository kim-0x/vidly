using System.ComponentModel.DataAnnotations;

namespace VidlyApp.Models;
public class Customer
{
    public int Id { get; set; }
    
    [StringLength(255)]
    public required string Name { get; set; }
    public DateTime? Birthdate { get; set; }
    public bool IsSubscribedToNewsletter { get; set; }
    public MembershipType? MembershipType { get; set; }
    public byte MembershipTypeId { get; set; }
}
