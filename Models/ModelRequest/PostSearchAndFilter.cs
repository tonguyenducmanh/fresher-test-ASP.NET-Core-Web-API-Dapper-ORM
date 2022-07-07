using System.ComponentModel;

namespace fresher_test_ASP.NET_Core_Web_API.Models.ModelRequest
{
    public class PostSearchAndFilter
    {
        [DefaultValue("")]
        public string? searchString { get; set; }
        public int limit { get; set; } = 0;
        public int startIndex { get; set; } = 0;

        public string? xunghoString { get; set; }
        public int? xunghoCondition { get; set; }
        public string? hovademString { get; set; }
        public int? hovademCondition { get; set; }
        public string? tenString { get; set; }
        public int? tenCondition { get; set; }
        public string? phongbanString { get; set; }
        public int? phongbanCondition { get; set; }
        public string? chucdanhString { get; set; }
        public int? chucdanhCondition { get; set; }
        public string? dtdidongString { get; set; }
        public int? dtdidongCondition { get; set; }
        public string? dtcoquanString { get; set; }
        public int? dtcoquanCondition { get; set; }
        public string? loaitiemnangString { get; set; }
        public int? loaitiemnangCondition { get; set; }
        public string? theString { get; set; }
        public int? theCondition { get; set; }
        public string? historyString { get; set; }
        public int? historyCondition { get; set; }
        public string? nguongocString { get; set; }
        public int? nguongocCondition { get; set; }
        public string? zaloString { get; set; }
        public int? zaloCondition { get; set; }
        public string? emailcanhanString { get; set; }
        public int? emailcanhanCondition { get; set; }
        public string? emailcoquanString { get; set; }
        public int? emailcoquanCondition { get; set; }
        public string? tochucString { get; set; }
        public int? tochucCondition { get; set; }
        public string? masothueString { get; set; }
        public int? masothueCondition { get; set; }
        public string? taikhoannganhangString { get; set; }
        public int? taikhoannganhangCondition { get; set; }
        public string? motainganhangString { get; set; }
        public int? motainganhangCondition { get; set; }
        public string? ngaythanhlapString { get; set; }
        public int? ngaythanhlapCondition { get; set; }
        public string? loaihinhString { get; set; }
        public int? loaihinhCondition { get; set; }
        public string? linhvucString { get; set; }
        public int? linhvucCondition { get; set; }
        public string? nganhngheString { get; set; }
        public int? nganhngheCondition { get; set; }
        public string? doanhthuString { get; set; }
        public int? doanhthuCondition { get; set; }
        public string? quocgiaString { get; set; }
        public int? quocgiaCondition { get; set; }
        public string? tinhthanhphoString { get; set; }
        public int? tinhthanhphoCondition { get; set; }
        public string? quanhuyenString { get; set; }
        public int? quanhuyenCondition { get; set; }
        public string? phuongxaString { get; set; }
        public int? phuongxaCondition { get; set; }
        public string? sonhaString { get; set; }
        public int? sonhaCondition { get; set; }
        public string? motaString { get; set; }
        public int? motaCondition { get; set; }
        public bool? dungchungString { get; set; }
        public int? dungchungCondition { get; set; }
    }
}
