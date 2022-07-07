using fresher_test_ASP.NET_Core_Web_API.Models.ModelRequest;
using Microsoft.AspNetCore.Mvc;

namespace fresher_test_ASP.NET_Core_Web_API_Dapper_ORM.Controllers.Queries
{
    public class PostCreateFilter
    {
        public string query([FromForm] PostFilterBody PostFilterBody)
        {
            var stringCreateFilterQuery = $"INSERT INTO filter VALUES (DEFAULT, '{PostFilterBody.name}') ;";

            stringCreateFilterQuery += "INSERT INTO filtercontent VALUES ";
            stringCreateFilterQuery += $"( DEFAULT ,";
            stringCreateFilterQuery += $"LAST_INSERT_ID(),";
            stringCreateFilterQuery += $" '{PostFilterBody.xunghoString}' ,";
            stringCreateFilterQuery += $" {PostFilterBody.xunghoCondition} ,";
            stringCreateFilterQuery += $" '{PostFilterBody.hovademString}' ,";
            stringCreateFilterQuery += $" {PostFilterBody.hovademCondition} ,";
            stringCreateFilterQuery += $" '{PostFilterBody.tenString}' ,";
            stringCreateFilterQuery += $" {PostFilterBody.tenCondition} ,";
            stringCreateFilterQuery += $" '{PostFilterBody.phongbanString}' ,";
            stringCreateFilterQuery += $" {PostFilterBody.phongbanCondition} ,";
            stringCreateFilterQuery += $" '{PostFilterBody.chucdanhString}' ,";
            stringCreateFilterQuery += $" {PostFilterBody.chucdanhCondition} ,";
            stringCreateFilterQuery += $" '{PostFilterBody.dtdidongString}' ,";
            stringCreateFilterQuery += $" {PostFilterBody.dtdidongCondition} ,";
            stringCreateFilterQuery += $" '{PostFilterBody.dtcoquanString}' ,";
            stringCreateFilterQuery += $" {PostFilterBody.dtcoquanCondition} ,";
            stringCreateFilterQuery += $" '{PostFilterBody.loaitiemnangString}' ,";
            stringCreateFilterQuery += $" {PostFilterBody.loaitiemnangCondition} ,";
            stringCreateFilterQuery += $" '{PostFilterBody.theString}' ,";
            stringCreateFilterQuery += $" {PostFilterBody.theCondition} ,";
            stringCreateFilterQuery += $" '{PostFilterBody.nguongocString}' ,";
            stringCreateFilterQuery += $" {PostFilterBody.nguongocCondition} ,";
            stringCreateFilterQuery += $" '{PostFilterBody.zaloString}' ,";
            stringCreateFilterQuery += $" {PostFilterBody.zaloCondition} ,";
            stringCreateFilterQuery += $" '{PostFilterBody.emailcanhanString}' ,";
            stringCreateFilterQuery += $" {PostFilterBody.emailcanhanCondition} ,";
            stringCreateFilterQuery += $" '{PostFilterBody.emailcoquanString}' ,";
            stringCreateFilterQuery += $" {PostFilterBody.emailcoquanCondition} ,";
            stringCreateFilterQuery += $" '{PostFilterBody.tochucString}' ,";
            stringCreateFilterQuery += $" {PostFilterBody.tochucCondition} ,";
            stringCreateFilterQuery += $" '{PostFilterBody.masothueString}' ,";
            stringCreateFilterQuery += $" {PostFilterBody.masothueCondition} ,";
            stringCreateFilterQuery += $" '{PostFilterBody.taikhoannganhangString}' ,";
            stringCreateFilterQuery += $" {PostFilterBody.taikhoannganhangCondition} ,";
            stringCreateFilterQuery += $" '{PostFilterBody.motainganhangString}' ,";
            stringCreateFilterQuery += $" {PostFilterBody.motainganhangCondition} ,";
            stringCreateFilterQuery += $" '{PostFilterBody.ngaythanhlapString}' ,";
            stringCreateFilterQuery += $" {PostFilterBody.ngaythanhlapCondition} ,";
            stringCreateFilterQuery += $" '{PostFilterBody.loaihinhString}' ,";
            stringCreateFilterQuery += $" {PostFilterBody.loaihinhCondition} ,";
            stringCreateFilterQuery += $" '{PostFilterBody.linhvucString}' ,";
            stringCreateFilterQuery += $" {PostFilterBody.linhvucCondition} ,";
            stringCreateFilterQuery += $" '{PostFilterBody.nganhngheString}' ,";
            stringCreateFilterQuery += $" {PostFilterBody.nganhngheCondition} ,";
            stringCreateFilterQuery += $" '{PostFilterBody.doanhthuString}' ,";
            stringCreateFilterQuery += $" {PostFilterBody.doanhthuCondition} ,";
            stringCreateFilterQuery += $" '{PostFilterBody.quocgiaString}' ,";
            stringCreateFilterQuery += $" {PostFilterBody.quocgiaCondition} ,";
            stringCreateFilterQuery += $" '{PostFilterBody.tinhthanhphoString}' ,";
            stringCreateFilterQuery += $" {PostFilterBody.tinhthanhphoCondition} ,";
            stringCreateFilterQuery += $" '{PostFilterBody.quanhuyenString}' ,";
            stringCreateFilterQuery += $" {PostFilterBody.quanhuyenCondition} ,";
            stringCreateFilterQuery += $" '{PostFilterBody.phuongxaString}' ,";
            stringCreateFilterQuery += $" {PostFilterBody.phuongxaCondition} ,";
            stringCreateFilterQuery += $" '{PostFilterBody.sonhaString}' ,";
            stringCreateFilterQuery += $" {PostFilterBody.sonhaCondition} ,";
            stringCreateFilterQuery += $" '{PostFilterBody.motaString}' ,";
            stringCreateFilterQuery += $" {PostFilterBody.motaCondition} ,";
            stringCreateFilterQuery += $" '{PostFilterBody.dungchungString}' ,";
            stringCreateFilterQuery += $" {PostFilterBody.dungchungCondition});";
               


           
            return stringCreateFilterQuery;
        }

        
    }
}
