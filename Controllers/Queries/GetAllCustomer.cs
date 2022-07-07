using fresher_test_ASP.NET_Core_Web_API.Models.ModelRequest;
using fresher_test_ASP.NET_Core_Web_API_Dapper_ORM.Controllers.Queries.QueryFunctions;
using Microsoft.AspNetCore.Mvc;

namespace fresher_test_ASP.NET_Core_Web_API_Dapper_ORM.Controllers.Queries
{
    public class GetAllCustomer
    {
        public string query(List<string> customerIds)
        {
            string query = "";
            for(int i = 0; i < customerIds.Count(); i++)
            {
                if(i < customerIds.Count() -1)
                {
                    query += $" '{customerIds[i]}' ,";
                }
                else
                {
                    query += $"'{customerIds[i]}'";
                }
            }
            var stringCustomerAllQuery = 
                "SELECT c.*, " 
                + "l.loaitiemnangContent AS loaitiemnangContent," 
                +" t.theContent AS theContent," 
                +" h.historyContent AS historyContent"
                + " FROM customer c"
                + " LEFT JOIN loaitiemnang l ON c._id = l.customerId"
                + " LEFT JOIN the t ON c._id = t.customerId"
                + " LEFT JOIN history h ON c._id = h.customerId"
                + $" WHERE c._id IN ({query}) ";
            // thêm 2>1 để khi không có tìm kiếm hay filter thì không bị lỗi cú pháp WHERE

            Console.WriteLine(stringCustomerAllQuery);
            return stringCustomerAllQuery;
        }

            // phải dùng where để tính ra số kết quả có id nhỏ hơn hoặc bằng giá trị bao nhiêu cho trước
            // vì truy vấn này trả về nhiều kết quả cùng id, nên nếu dùng limit để limit id
            // thì sau khi group lại thành json sẽ cho ra số lượng nhỏ hơn số ban đầu
            // tương tự với start index cũng thế. không dùng offset được mà phải tính ra giá
            // trị id bắt đầu
    }
}
