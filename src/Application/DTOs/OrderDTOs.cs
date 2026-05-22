using System.ComponentModel.DataAnnotations;

public class CreateOrderDTO
{
    [Required]
    public Guid ProductId { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than zero")]
    public int Quantity { get; set; }

    [Required]
    public string Address { get; set; }
}