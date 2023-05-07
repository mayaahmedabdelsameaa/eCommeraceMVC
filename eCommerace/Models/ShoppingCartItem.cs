using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eCommerace.Models
{
    public class ShoppingCartItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Movie Movie { get; set; }
        public int Amount { get; set; }

        // to store all orders of the same user
        public string ShoppingCartId { get; set; }
    }
}
