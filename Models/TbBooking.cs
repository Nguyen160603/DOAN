namespace DOAN.Models
{
    public class TbBooking
    { 
    public int BookingId { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public DateTime ArivalDate { get; set; }

    public DateTime DepartureDate { get; set; }
    public int? Adults { get; set; }

    public int? Children { get; set; }

    public string? Message { get; set; }

    public int? IsRead { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }
    }
}