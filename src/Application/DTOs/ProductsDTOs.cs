public class CreatRequestProduct
{

    [Required]
    public string NameProduct { get; set; }
    [Required]
    [Range(0.01, int.MaxValue)]
    public decimal Price { get; set; }
    [Required]
    [Range(1, int.MaxValue)]
    public int Quantity { get; set; }
 
   
}