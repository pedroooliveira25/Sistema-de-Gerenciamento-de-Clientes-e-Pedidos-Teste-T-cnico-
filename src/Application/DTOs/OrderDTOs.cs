using System.ComponentModel.DataAnnotations;
using Domain.Enums;

public class CreateOrderDTO
{
    [Required]
    public Guid ProductId { get; set; }

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than zero")]
    public int Quantity { get; set; }

    [Required]
    public string Address { get; set; }
    public int Cep { get; set; }

    public decimal Value { get; set; }
    public StatusOrder statusOrder = StatusOrder.Pending;


}