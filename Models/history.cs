using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fresher_test_ASP.NET_Core_Web_API.Models
{
    [Table("history")]
    public class history
    {
        [Key]
        public int historyId { get; set; }
        public string historyContent { get; set; }
        [ForeignKey("customer")]
        public string customerId { get; set; }
        public customer customer { get; set; }
    }
}
