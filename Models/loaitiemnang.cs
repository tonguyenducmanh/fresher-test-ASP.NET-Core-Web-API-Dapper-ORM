using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fresher_test_ASP.NET_Core_Web_API.Models
{
    [Table("loaitiemnang")]
    public class loaitiemnang
    {
        [Key]
        public int loaitiemnangId { get; set; }
        public string loaitiemnangContent { get; set; }
        [ForeignKey("customer")]
        public string customerId { get; set; }
        public customer customer { get; set; }
    }
}
