using Dapper;
using fresher_test_ASP.NET_Core_Web_API.Models;
using fresher_test_ASP.NET_Core_Web_API.Models.ModelRequest;
using fresher_test_ASP.NET_Core_Web_API_Dapper_ORM.Controllers.Queries;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Data;

namespace fresher_test_ASP.NET_Core_Web_API_Dapper_ORM.Controllers
{
    [ApiController]
    public class customersController : ControllerBase
    {
        // POST: /customers/all (tải danh sách cơ sở dữ liệu theo dạng json, có điều kiện tìm kiếm)
        [HttpPost]
        [Route("/customers/all")]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult> PostFetchCustomer([FromForm] PostSearchAndFilter PostSearchAndFilter)
        {
            // query 2 lần, 1 lần để lấy danh sách ID, 1 lần để lấy toàn bộ thông tin
            // vì có áp dụng limit và startIndex trên quan hệ one to many nên phải chia làm 2 query
            // query lấy id của tất cả các customer thỏa mãn điều kiện tìm kiếm 
            // dùng SELECT DISTINCT nên LIMIT và OFFSET không bị ảnh hưởng bởi những id trùng nhau

            var sqlGetCustomerIds = new PostCustomerAllQuery().query(PostSearchAndFilter);
            var customerIdsDictionary = new Dictionary<string, customer>();
            List<string> customerIds = new();
            using (IDbConnection db = new MySqlConnection("server=localhost;port=5060;user=root;password=140300;database=customerdatabase"))
            {

                customerIds = db.Query<string>(new PostCustomerAllQuery().query(PostSearchAndFilter)).ToList();
            }

            // query lấy danh sách
            // lần này SELECT không có DISTINCT để hiện toàn bộ thẻ, loại tiềm năng và lịch sử giao dịch
            var sqlGetAll = new GetAllCustomer().query(customerIds);
            var customerDictionary = new Dictionary<string, customer>();
            List<customer> customers = new();
            using (IDbConnection db = new MySqlConnection("server=localhost;port=5060;user=root;password=140300;database=customerdatabase"))
            {

                customers = db.Query<customer,loaitiemnang,the,history,customer>
                            (sqlGetAll, (customer, loaitiemnang, the, history)
                                =>
                            {
                                customer cusomerEntry;
                                if(!customerDictionary.TryGetValue(customer._id, out cusomerEntry)){
                                    cusomerEntry = customer;
                                    cusomerEntry.loaitiemnang = new List<string>();
                                    cusomerEntry.the = new List<string>();
                                    cusomerEntry.history = new List<string>();
                                    customerDictionary.Add(cusomerEntry._id, cusomerEntry);
                                }
                                if (loaitiemnang != null)
                                {
                                    cusomerEntry.loaitiemnang.Add(loaitiemnang.loaitiemnangContent);
                                }
                                else { cusomerEntry.loaitiemnang.Add(null); }

                                if(the != null)
                                {
                                    cusomerEntry.the.Add(the.theContent);
                                }
                                else { cusomerEntry.the.Add(null); }

                                if(history != null)
                                {
                                    cusomerEntry.history.Add(history.historyContent);
                                }
                                else { cusomerEntry.history.Add(null); }

                                return cusomerEntry;
                            }, splitOn: "loaitiemnangContent, theContent,historyContent")
                            .Distinct().ToList();
            }
            return Ok(customers);
        }
    }
}
