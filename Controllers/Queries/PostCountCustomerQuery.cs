using fresher_test_ASP.NET_Core_Web_API.Models.ModelRequest;
using fresher_test_ASP.NET_Core_Web_API_Dapper_ORM.Controllers.Queries.QueryFunctions;
using Microsoft.AspNetCore.Mvc;

namespace fresher_test_ASP.NET_Core_Web_API_Dapper_ORM.Controllers.Queries
{
    public class PostCountCustomerQuery
    {
        public string query([FromForm] PostSearchAndFilter PostSearchAndFilter)
        {
            var stringCustomerAllQuery =
                "SELECT COUNT( DISTINCT c._id)"
                + " FROM customer c"
                + " LEFT JOIN loaitiemnang l ON c._id = l.customerId"
                + " LEFT JOIN the t ON c._id = t.customerId"
                + " LEFT JOIN history h ON c._id = h.customerId"
                + $" WHERE 2> 1 ";
             // thêm 2>1 để khi không có tìm kiếm hay filter thì không bị lỗi cú pháp WHERE
            // áp dụng tìm kiếm

            if(PostSearchAndFilter.searchString != "")
            {
                string searchString = $" &&  c.hovadem LIKE '%{PostSearchAndFilter.searchString}%'";
                stringCustomerAllQuery += searchString;
            }

            // áp dụng bộ lọc
            stringCustomerAllQuery +=  new FilterCustomerConditon().ConditionQuery("c.xungho",PostSearchAndFilter.xunghoString, PostSearchAndFilter.xunghoCondition);
            stringCustomerAllQuery +=  new FilterCustomerConditon().ConditionQuery("c.hovadem",PostSearchAndFilter.hovademString, PostSearchAndFilter.hovademCondition);
            stringCustomerAllQuery +=  new FilterCustomerConditon().ConditionQuery("c.ten",PostSearchAndFilter.tenString, PostSearchAndFilter.tenCondition);
            stringCustomerAllQuery +=  new FilterCustomerConditon().ConditionQuery("c.phongban",PostSearchAndFilter.phongbanString, PostSearchAndFilter.phongbanCondition);
            stringCustomerAllQuery +=  new FilterCustomerConditon().ConditionQuery("c.chucdanh",PostSearchAndFilter.chucdanhString, PostSearchAndFilter.chucdanhCondition);
            stringCustomerAllQuery +=  new FilterCustomerConditon().ConditionQuery("c.dtdidong",PostSearchAndFilter.dtdidongString, PostSearchAndFilter.dtdidongCondition);
            stringCustomerAllQuery +=  new FilterCustomerConditon().ConditionQuery("c.dtcoquan",PostSearchAndFilter.dtcoquanString, PostSearchAndFilter.dtcoquanCondition);
            stringCustomerAllQuery +=  new FilterCustomerConditon().ConditionQuery("c.nguongoc",PostSearchAndFilter.nguongocString, PostSearchAndFilter.nguongocCondition);
            stringCustomerAllQuery +=  new FilterCustomerConditon().ConditionQuery("c.zalo",PostSearchAndFilter.zaloString, PostSearchAndFilter.zaloCondition);
            stringCustomerAllQuery +=  new FilterCustomerConditon().ConditionQuery("c.emailcanhan",PostSearchAndFilter.emailcanhanString, PostSearchAndFilter.emailcanhanCondition);
            stringCustomerAllQuery +=  new FilterCustomerConditon().ConditionQuery("c.emailcoquan",PostSearchAndFilter.emailcoquanString, PostSearchAndFilter.emailcoquanCondition);
            stringCustomerAllQuery +=  new FilterCustomerConditon().ConditionQuery("c.tochuc",PostSearchAndFilter.tochucString, PostSearchAndFilter.tochucCondition);
            stringCustomerAllQuery +=  new FilterCustomerConditon().ConditionQuery("c.masothue",PostSearchAndFilter.masothueString, PostSearchAndFilter.masothueCondition);
            stringCustomerAllQuery +=  new FilterCustomerConditon().ConditionQuery("c.taikhoannganhang",PostSearchAndFilter.taikhoannganhangString, PostSearchAndFilter.taikhoannganhangCondition);
            stringCustomerAllQuery +=  new FilterCustomerConditon().ConditionQuery("c.motainganhang",PostSearchAndFilter.motainganhangString, PostSearchAndFilter.motainganhangCondition);
            stringCustomerAllQuery +=  new FilterCustomerConditon().ConditionQuery("c.ngaythanhlap",PostSearchAndFilter.ngaythanhlapString, PostSearchAndFilter.ngaythanhlapCondition);
            stringCustomerAllQuery +=  new FilterCustomerConditon().ConditionQuery("c.loaihinh",PostSearchAndFilter.loaihinhString, PostSearchAndFilter.loaihinhCondition);
            stringCustomerAllQuery +=  new FilterCustomerConditon().ConditionQuery("c.linhvuc",PostSearchAndFilter.linhvucString, PostSearchAndFilter.linhvucCondition);
            stringCustomerAllQuery +=  new FilterCustomerConditon().ConditionQuery("c.nganhnghe",PostSearchAndFilter.nganhngheString, PostSearchAndFilter.nganhngheCondition);
            stringCustomerAllQuery +=  new FilterCustomerConditon().ConditionQuery("c.doanhthu",PostSearchAndFilter.doanhthuString, PostSearchAndFilter.doanhthuCondition);
            stringCustomerAllQuery +=  new FilterCustomerConditon().ConditionQuery("c.quocgia",PostSearchAndFilter.quocgiaString, PostSearchAndFilter.quocgiaCondition);
            stringCustomerAllQuery +=  new FilterCustomerConditon().ConditionQuery("c.tinhthanhpho",PostSearchAndFilter.tinhthanhphoString, PostSearchAndFilter.tinhthanhphoCondition);
            stringCustomerAllQuery +=  new FilterCustomerConditon().ConditionQuery("c.quanhuyen",PostSearchAndFilter.quanhuyenString, PostSearchAndFilter.quanhuyenCondition);
            stringCustomerAllQuery +=  new FilterCustomerConditon().ConditionQuery("c.phuongxa",PostSearchAndFilter.phuongxaString, PostSearchAndFilter.phuongxaCondition);
            stringCustomerAllQuery +=  new FilterCustomerConditon().ConditionQuery("c.sonha",PostSearchAndFilter.sonhaString, PostSearchAndFilter.sonhaCondition);
            stringCustomerAllQuery +=  new FilterCustomerConditon().ConditionQuery("c.mota",PostSearchAndFilter.motaString, PostSearchAndFilter.motaCondition);
            stringCustomerAllQuery +=  new FilterCustomerDungChungCondition().ConditionQuery("c.dungchung",PostSearchAndFilter.dungchungString, PostSearchAndFilter.dungchungCondition);
            stringCustomerAllQuery +=  new FilterCustomerConditon().ConditionQuery("l.loaitiemnangContent",PostSearchAndFilter.loaitiemnangString, PostSearchAndFilter.loaitiemnangCondition);
            stringCustomerAllQuery +=  new FilterCustomerConditon().ConditionQuery("t.theContent",PostSearchAndFilter.theString, PostSearchAndFilter.theCondition);
            stringCustomerAllQuery +=  new FilterCustomerConditon().ConditionQuery("h.historyContent",PostSearchAndFilter.historyString, PostSearchAndFilter.historyCondition);

            return stringCustomerAllQuery;
        }

            // phải dùng where để tính ra số kết quả có id nhỏ hơn hoặc bằng giá trị bao nhiêu cho trước
            // vì truy vấn này trả về nhiều kết quả cùng id, nên nếu dùng limit để limit id
            // thì sau khi group lại thành json sẽ cho ra số lượng nhỏ hơn số ban đầu
            // tương tự với start index cũng thế. không dùng offset được mà phải tính ra giá
            // trị id bắt đầu
    }
}
