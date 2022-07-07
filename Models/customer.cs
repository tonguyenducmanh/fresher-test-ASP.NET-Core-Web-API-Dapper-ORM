using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fresher_test_ASP.NET_Core_Web_API.Models
{
    [Table("customer")]
    public class customer
    {
        [Key]
        public string _id { get; set; }
        public string? anh { get; set; }
        public string? xungho { get; set; }
        public string hovadem { get; set; }
        public string ten { get; set; }
        public string? phongban { get; set; }
        public string? chucdanh { get; set; }
        public string? dtdidong { get; set; }
        public string? dtcoquan { get; set; }
        public List<string>? loaitiemnang { get; set; }
        //loại tiềm năng được gán thẳng giá trị mảng, theo dạng List<string>
        //để phù hợp với kết quả của bên client yêu cầu là dạng json.
        //nếu lấy tất cả thì dùng customerEntry.loaitiemnang = new List<loatiemnang>
        //và sửa model customer chỗ list<string> loại tiềm năng thành ICollection<loaitiemnang>
        // như bên entity framework ( cả ở file này và file customerController.cs
        public List<string>? the { get; set; }
        public string? nguongoc { get; set; }
        public string? zalo { get; set; }
        public string? emailcanhan { get; set; }
        public string? emailcoquan { get; set; }
        public string? tochuc { get; set; }
        public string? masothue { get; set; }
        public string? taikhoannganhang { get; set; }
        public string? motainganhang { get; set; }
        public string? ngaythanhlap { get; set; }
        public string? loaihinh { get; set; }
        public string? linhvuc { get; set; }
        public string? nganhnghe { get; set; }
        public string? doanhthu { get; set; }
        public string? quocgia { get; set; }
        public string? tinhthanhpho { get; set; }
        public string? quanhuyen { get; set; }
        public string? phuongxa { get; set; }
        public string? sonha { get; set; }
        public string? mota { get; set; }
        public bool dungchung { get; set; }
        public List<string>? history { get; set; }
    }
}
