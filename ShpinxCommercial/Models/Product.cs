using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models;
    public class Product
    {
    [Key]
    public int ProductId { get; set; }
    [Required]
    [DisplayName("Product Name")]
    public string ProductName { get; set; }

    [Required]
    [DisplayName("Product Description")]
    public string ProductDescription { get; set; } = string.Empty;

    [Required]
    [DisplayName("Product Price")]
    public double ProductPrice { get; set;}

    [Required]
    [DisplayName("Client")]
    public int ClientId { get; set; }

    public Client Client { get; set; }
}
