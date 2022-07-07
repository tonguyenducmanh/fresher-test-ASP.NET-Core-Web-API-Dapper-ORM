﻿using fresher_test_ASP.NET_Core_Web_API.Models.ModelRequest;
using Microsoft.AspNetCore.Mvc;

namespace fresher_test_ASP.NET_Core_Web_API_Dapper_ORM.Controllers.Queries
{
    public class PostCreateCustomerQuery
    {
        public string query([FromForm] PostCustomerBody PostCustomerBody)
        {
            var stringCreateCustomerQuery =
            "INSERT INTO customer " +
            $"VALUES('{PostCustomerBody._id}'," +
            $" '{PostCustomerBody.anh}'," +
            $" '{PostCustomerBody.xungHo}', " +
            $" '{PostCustomerBody.hoVaDem}', " +
            $" '{PostCustomerBody.ten}', " +
            $" '{PostCustomerBody.phongBan}'," +
            $" '{PostCustomerBody.chucDanh}'," +
            $" '{PostCustomerBody.dienThoaiDiDong}'," +
            $" '{PostCustomerBody.dienThoaiCoQuan}' ," +
            $" '{PostCustomerBody.nguonGoc}' ," +
            $" '{PostCustomerBody.zalo}' ," +
            $" '{PostCustomerBody.emailCaNhan}' ," +
            $" '{PostCustomerBody.emailCoQuan}' ," +
            $" '{PostCustomerBody.toChuc}' ," +
            $" '{PostCustomerBody.maSoThue}' ," +
            $" '{PostCustomerBody.taiKhoanNganHang}' ," +
            $" '{PostCustomerBody.moTaiNganHang}' ," +
            $" '{PostCustomerBody.ngayThanhLap}' ," +
            $" '{PostCustomerBody.loaiHinh}' ," +
            $" '{PostCustomerBody.linhVuc}' ," +
            $" '{PostCustomerBody.nganhNghe}' ," +
            $" '{PostCustomerBody.doanhThu}' ," +
            $" '{PostCustomerBody.quocGia}' ," +
            $" '{PostCustomerBody.tinhThanh}' ," +
            $" '{PostCustomerBody.quanHuyen}' ," +
            $" '{PostCustomerBody.phuongXa}' ," +
            $" '{PostCustomerBody.soNha}' ," +
            $" '{PostCustomerBody.moTa}' ,";
                
            if(PostCustomerBody.dungChung == true){
            stringCreateCustomerQuery +=    $" '1'" ;
            } else{
            stringCreateCustomerQuery +=    $" '0'" ;
            }

            stringCreateCustomerQuery += $"); ";
                
            // thêm thẻ, loại tiềm năng, lịch sử giao dịch

            if(PostCustomerBody.loaiTiemNang.Count() > 0)
            {
                stringCreateCustomerQuery += "INSERT INTO loaitiemnang (loaitiemnangContent, customerId) VALUES ";
                for(int i = 0; i< PostCustomerBody.loaiTiemNang.Count() -1; i++)
                {
                    stringCreateCustomerQuery += $"( '{PostCustomerBody.loaiTiemNang[i]}' ,";
                    stringCreateCustomerQuery += $"'{PostCustomerBody._id}'),";
                }
                stringCreateCustomerQuery += $"( '{PostCustomerBody.loaiTiemNang.Last()}' ,";
                stringCreateCustomerQuery += $"'{PostCustomerBody._id}');";

            }

            if(PostCustomerBody.the.Count() > 0)
            {
                stringCreateCustomerQuery += "INSERT INTO the (theContent, customerId) VALUES ";
                for(int i = 0; i< PostCustomerBody.the.Count() -1; i++)
                {
                    stringCreateCustomerQuery += $"( '{PostCustomerBody.the[i]}' ,";
                    stringCreateCustomerQuery += $"'{PostCustomerBody._id}'),";
                }
                stringCreateCustomerQuery += $"( '{PostCustomerBody.the.Last()}' ,";
                stringCreateCustomerQuery += $"'{PostCustomerBody._id}');";

            }

            
            if(PostCustomerBody.history.Count() > 0)
            {
                stringCreateCustomerQuery += "INSERT INTO history (historyContent, customerId) VALUES ";
                for(int i = 0; i< PostCustomerBody.history.Count() -1; i++)
                {
                    stringCreateCustomerQuery += $"( '{PostCustomerBody.history[i]}' ,";
                    stringCreateCustomerQuery += $"'{PostCustomerBody._id}'),";
                }
                stringCreateCustomerQuery += $" ('{PostCustomerBody.history.Last()}' ,";
                stringCreateCustomerQuery += $"'{PostCustomerBody._id}');";

            }

            return stringCreateCustomerQuery;
        }

        
    }
}