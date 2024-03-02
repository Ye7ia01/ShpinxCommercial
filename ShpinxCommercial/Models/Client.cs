using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models;

    public class Client
    {

    [Key]
    public int ClientId { get; set; }
    [Required]
    [DisplayName("Client Name")]
    public string ClientName { get; set; } = string.Empty;
    [Required]
    [DisplayName("Client Email")]
    public string ClientEmail { get; set; }
}
