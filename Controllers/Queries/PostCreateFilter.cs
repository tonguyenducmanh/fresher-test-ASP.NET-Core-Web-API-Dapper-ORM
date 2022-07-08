using fresher_test_ASP.NET_Core_Web_API.Models.ModelRequest;
using Microsoft.AspNetCore.Mvc;

namespace fresher_test_ASP.NET_Core_Web_API_Dapper_ORM.Controllers.Queries
{
    public class PostCreateFilter
    {
        public string query([FromForm] PostFilterBody PostFilterBody)
        {
            var stringCreateFilterQuery = $"INSERT INTO filter VALUES (DEFAULT, '{PostFilterBody.name}') ;";

            var stringValues = "( filterContentId, filterId ";
            var stringInserts = "(DEFAULT , LAST_INSERT_ID()  ";

            if(PostFilterBody.xunghoString != null)
            {
                stringValues += ", xunghoString ";
                stringInserts += $", '{PostFilterBody.xunghoString}' ";
            }
            if(PostFilterBody.xunghoCondition != null)
            {
                stringValues += ", xunghoCondition ";
                stringInserts += $", '{PostFilterBody.xunghoCondition}'  ";
            }
            if(PostFilterBody.hovademString != null)
            {
                stringValues += ", hovademString ";
                stringInserts += $", '{PostFilterBody.hovademString}' ";
            }
            if(PostFilterBody.hovademCondition != null)
            {
                stringValues += ", hovademCondition ";
                stringInserts += $", '{PostFilterBody.hovademCondition}'  ";
            }
            if(PostFilterBody.tenString != null)
            {
                stringValues += ", tenString ";
                stringInserts += $", '{PostFilterBody.tenString}'  ";
            }
            if(PostFilterBody.tenCondition != null)
            {
                stringValues += ", tenCondition ";
                stringInserts += $", '{PostFilterBody.tenCondition}'  ";
            }
            if(PostFilterBody.phongbanString != null)
            {
                stringValues += ", phongbanString ";
                stringInserts += $", '{PostFilterBody.phongbanString}'  ";
            }
            if(PostFilterBody.phongbanCondition != null)
            {
                stringValues += ", phongbanCondition ";
                stringInserts += $", '{PostFilterBody.phongbanCondition}'  ";
            }
            if(PostFilterBody.chucdanhString != null)
            {
                stringValues += ", chucdanhString ";
                stringInserts += $", '{PostFilterBody.chucdanhString}'  ";
            }
            if(PostFilterBody.chucdanhCondition != null)
            {
                stringValues += ", chucdanhCondition ";
                stringInserts += $", '{PostFilterBody.chucdanhCondition}'  ";
            }
            if(PostFilterBody.dtdidongString != null)
            {
                stringValues += ", dtdidongString ";
                stringInserts += $", '{PostFilterBody.dtdidongString}'  ";
            }
            if(PostFilterBody.dtdidongCondition != null)
            {
                stringValues += ", dtdidongCondition ";
                stringInserts += $", '{PostFilterBody.dtdidongCondition}'  ";
            }
            if(PostFilterBody.dtcoquanString != null)
            {
                stringValues += ", dtcoquanString ";
                stringInserts += $", '{PostFilterBody.dtcoquanString}'  ";
            }
            if(PostFilterBody.dtcoquanCondition != null)
            {
                stringValues += ", dtcoquanCondition ";
                stringInserts += $", '{PostFilterBody.dtcoquanCondition}'  ";
            }
            if(PostFilterBody.loaitiemnangString != null)
            {
                stringValues += ", loaitiemnangString ";
                stringInserts += $", '{PostFilterBody.loaitiemnangString}'  ";
            }
            if(PostFilterBody.loaitiemnangCondition != null)
            {
                stringValues += ", loaitiemnangCondition ";
                stringInserts += $", '{PostFilterBody.loaitiemnangCondition}'  ";
            }
            if(PostFilterBody.theString != null)
            {
                stringValues += ", theString ";
                stringInserts += $", '{PostFilterBody.theString}'  ";
            }
            if(PostFilterBody.theCondition != null)
            {
                stringValues += ", theCondition ";
                stringInserts += $", '{PostFilterBody.theCondition}'  ";
            }
            if(PostFilterBody.nguongocString != null)
            {
                stringValues += ", nguongocString ";
                stringInserts += $", '{PostFilterBody.nguongocString}'  ";
            }
            if(PostFilterBody.nguongocCondition != null)
            {
                stringValues += ", nguongocCondition ";
                stringInserts += $", '{PostFilterBody.nguongocCondition}'  ";
            }
            if(PostFilterBody.zaloString != null)
            {
                stringValues += ", zaloString ";
                stringInserts += $", '{PostFilterBody.zaloString}'  ";
            }
            if(PostFilterBody.zaloCondition != null)
            {
                stringValues += ", zaloCondition ";
                stringInserts += $", '{PostFilterBody.zaloCondition}'  ";
            }
            if(PostFilterBody.emailcanhanString != null)
            {
                stringValues += ", emailcanhanString ";
                stringInserts += $", '{PostFilterBody.emailcanhanString}'  ";
            }
            if(PostFilterBody.emailcanhanCondition != null)
            {
                stringValues += ", emailcanhanCondition ";
                stringInserts += $", '{PostFilterBody.emailcanhanCondition}'  ";
            }
            if(PostFilterBody.emailcoquanString != null)
            {
                stringValues += ", emailcoquanString ";
                stringInserts += $", '{PostFilterBody.emailcoquanString}'  ";
            }
            if(PostFilterBody.emailcoquanCondition != null)
            {
                stringValues += ", emailcoquanCondition ";
                stringInserts += $", '{PostFilterBody.emailcoquanCondition}'  ";
            }
            if(PostFilterBody.tochucString != null)
            {
                stringValues += ", tochucString ";
                stringInserts += $", '{PostFilterBody.tochucString}'  ";
            }
            if(PostFilterBody.tochucCondition != null)
            {
                stringValues += ", tochucCondition ";
                stringInserts += $", '{PostFilterBody.tochucCondition}'  ";
            }
            if(PostFilterBody.masothueString != null)
            {
                stringValues += ", masothueString ";
                stringInserts += $", '{PostFilterBody.masothueString}'  ";
            }
            if(PostFilterBody.masothueCondition != null)
            {
                stringValues += ", masothueCondition ";
                stringInserts += $", '{PostFilterBody.masothueCondition}'  ";
            }
            if(PostFilterBody.taikhoannganhangString != null)
            {
                stringValues += ", taikhoannganhangString ";
                stringInserts += $", '{PostFilterBody.taikhoannganhangString}'  ";
            }
            if(PostFilterBody.taikhoannganhangCondition != null)
            {
                stringValues += ", taikhoannganhangCondition ";
                stringInserts += $", '{PostFilterBody.taikhoannganhangCondition}'  ";
            }
            if(PostFilterBody.motainganhangString != null)
            {
                stringValues += ", motainganhangString ";
                stringInserts += $", '{PostFilterBody.motainganhangString}'  ";
            }
            if(PostFilterBody.motainganhangCondition != null)
            {
                stringValues += ", motainganhangCondition ";
                stringInserts += $", '{PostFilterBody.motainganhangCondition}'  ";
            }
            if(PostFilterBody.ngaythanhlapString != null)
            {
                stringValues += ", ngaythanhlapString ";
                stringInserts += $", '{PostFilterBody.ngaythanhlapString}'  ";
            }
            if(PostFilterBody.ngaythanhlapCondition != null)
            {
                stringValues += ", ngaythanhlapCondition ";
                stringInserts += $", '{PostFilterBody.ngaythanhlapCondition}'  ";
            }
            if(PostFilterBody.loaihinhString != null)
            {
                stringValues += ", loaihinhString ";
                stringInserts += $", '{PostFilterBody.loaihinhString}'  ";
            }
            if(PostFilterBody.loaihinhCondition != null)
            {
                stringValues += ", loaihinhCondition ";
                stringInserts += $", '{PostFilterBody.loaihinhCondition}'  ";
            }
            if(PostFilterBody.linhvucString != null)
            {
                stringValues += ", linhvucString ";
                stringInserts += $", '{PostFilterBody.linhvucString}'  ";
            }
            if(PostFilterBody.linhvucCondition != null)
            {
                stringValues += ", linhvucCondition ";
                stringInserts += $", '{PostFilterBody.linhvucCondition}'  ";
            }
            if(PostFilterBody.nganhngheString != null)
            {
                stringValues += ", nganhngheString ";
                stringInserts += $", '{PostFilterBody.nganhngheString}'  ";
            }
            if(PostFilterBody.nganhngheCondition != null)
            {
                stringValues += ", nganhngheCondition ";
                stringInserts += $", '{PostFilterBody.nganhngheCondition}'  ";
            }
            if(PostFilterBody.doanhthuString != null)
            {
                stringValues += ", doanhthuString ";
                stringInserts += $", '{PostFilterBody.doanhthuString}'  ";
            }
            if(PostFilterBody.doanhthuCondition != null)
            {
                stringValues += ", doanhthuCondition ";
                stringInserts += $", '{PostFilterBody.doanhthuCondition}'  ";
            }
            if(PostFilterBody.quocgiaString != null)
            {
                stringValues += ", quocgiaString ";
                stringInserts += $", '{PostFilterBody.quocgiaString}'  ";
            }
            if(PostFilterBody.quocgiaCondition != null)
            {
                stringValues += ", quocgiaCondition ";
                stringInserts += $", '{PostFilterBody.quocgiaCondition}'  ";
            }
            if(PostFilterBody.tinhthanhphoString != null)
            {
                stringValues += ", tinhthanhphoString ";
                stringInserts += $", '{PostFilterBody.tinhthanhphoString}'  ";
            }
            if(PostFilterBody.tinhthanhphoCondition != null)
            {
                stringValues += ", tinhthanhphoCondition ";
                stringInserts += $", '{PostFilterBody.tinhthanhphoCondition}'  ";
            }
            if(PostFilterBody.quanhuyenString != null)
            {
                stringValues += ", quanhuyenString ";
                stringInserts += $", '{PostFilterBody.quanhuyenString}'  ";
            }
            if(PostFilterBody.quanhuyenCondition != null)
            {
                stringValues += ", quanhuyenCondition ";
                stringInserts += $", '{PostFilterBody.quanhuyenCondition}'  ";
            }
            if(PostFilterBody.phuongxaString != null)
            {
                stringValues += ", phuongxaString ";
                stringInserts += $", '{PostFilterBody.phuongxaString}'  ";
            }
            if(PostFilterBody.phuongxaCondition != null)
            {
                stringValues += ", phuongxaCondition ";
                stringInserts += $", '{PostFilterBody.phuongxaCondition}'  ";
            }
            if(PostFilterBody.sonhaString != null)
            {
                stringValues += ", sonhaString ";
                stringInserts += $", '{PostFilterBody.sonhaString}'  ";
            }
            if(PostFilterBody.sonhaCondition != null)
            {
                stringValues += ", sonhaCondition ";
                stringInserts += $", '{PostFilterBody.sonhaCondition}'  ";
            }
            if(PostFilterBody.motaString != null)
            {
                stringValues += ", motaString ";
                stringInserts += $", '{PostFilterBody.motaString}'  ";
            }
            if(PostFilterBody.motaCondition != null)
            {
                stringValues += ", motaCondition ";
                stringInserts += $", '{PostFilterBody.motaCondition}'  ";
            }
            if(PostFilterBody.dungchungString != null)
            {
                stringValues += ", dungchungString ";
                stringInserts += $", '{PostFilterBody.dungchungString}'  ";
            }
            if(PostFilterBody.dungchungCondition != null)
            {
                stringValues += ", dungchungCondition ";
                stringInserts += $", '{PostFilterBody.dungchungCondition}'  ";
            }

                stringValues += ") ";
                stringInserts += $" ) ";
            stringCreateFilterQuery += $"INSERT INTO filtercontent {stringValues} VALUES {stringInserts}  ";

               


           
            return stringCreateFilterQuery;
        }

        
    }
}
