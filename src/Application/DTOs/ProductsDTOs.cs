using System.ComponentModel.DataAnnotations;
using Domain.Enums;
public class CreatProductRequestDTOs
{

    [Required]
    public string NameProduct { get; set; }
    [Required]
    public Guid ProductId { get; set; }
    [Required]
    [Range(0.01, int.MaxValue)]
    public decimal Price { get; set; }
    [Required]

    [Range(1, int.MaxValue)]
    public int Quantity { get; set; }
    [Required] 
    public int Stock {get;  set;}
    public StageProduct StageProduct {get;  set;}

}