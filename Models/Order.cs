using System.ComponentModel.DataAnnotations;

namespace OrderApi.Models
{
    public class Order
    {

        [Required] public string account { get; set; }
        [Required] public string symbol { get; set; }
        public string? side { get; set; }
        [Required] public int qty { get; set; }
        [Required] public decimal price { get; set; }

    }
}
