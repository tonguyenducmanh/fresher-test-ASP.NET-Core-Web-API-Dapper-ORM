using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fresher_test_ASP.NET_Core_Web_API.Models
{
    [Table("the")]
    public class the
    {
        [Key]
        public int theId { get; set; }
        public string theContent { get; set; }
        [ForeignKey("customer")]
        public string customerId { get; set; }
        public customer customer { get; set; }
    }
}
