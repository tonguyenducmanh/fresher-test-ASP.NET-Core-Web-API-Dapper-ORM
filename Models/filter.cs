using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fresher_test_ASP.NET_Core_Web_API.Models
{
    [Table("filter")]
    public class filter
    {
        [Key]
        public int filterId { get; set; } 
        public string name { get; set; } 
        public filterContent filterContent { get; set; }
    }
}
