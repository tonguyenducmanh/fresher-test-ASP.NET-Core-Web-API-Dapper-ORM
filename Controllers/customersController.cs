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

                customerIds = db.Query<string>(sqlGetCustomerIds).ToList();
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
                                customer customerEntry;
                                if (!customerDictionary.TryGetValue(customer._id, out customerEntry))
                                {
                                    customerEntry = customer;
                                    customerEntry.loaitiemnang = loaitiemnang.loaitiemnangContent.Split("#").ToList();
                                    customerEntry.the = the.theContent.Split("#").ToList();
                                    customerEntry.history = history.historyContent.Split("#").ToList();
                                    customerDictionary.Add(customerEntry._id, customerEntry);
                                }
                                return customerEntry;
                            }, splitOn: "loaitiemnangContent, theContent, historyContent")
                            .Distinct().ToList();
            }
            return Ok(customers);
        }

        // POST : /customers/count đếm lượng người dùng
        [HttpPost()]
        [Route("/customers/count")]
        public async Task<ActionResult> PostCountCustomer([FromForm] PostSearchAndFilter PostSearchAndFilter)
        {
            // tương tự trường hợp trên, tuy nhiên chỉ dùng query đầu để đếm lượng khách hàng,
            // cũng như bỏ qua toàn bộ LIMIT và OFFSET
            // dùng SELECT DISTINCT để chỉ 

            string sqlGetCustomerIds = new PostCountCustomerQuery().query(PostSearchAndFilter);
            int customerIds = 0 ;
            using (IDbConnection db = new MySqlConnection("server=localhost;port=5060;user=root;password=140300;database=customerdatabase"))
            {

                customerIds = db.Query<int>(sqlGetCustomerIds).First();
            }


            return Ok(customerIds);
        }

        // GET : /customers/last tải bản ghi cuối cùng
        [HttpGet()]
        [Route("/customers/last")]
        public async Task<ActionResult> GetLastCustomer()
        {
            // tương tự trường hợp đầu, cần dùng 2 query.
            // 1 query để lấy id cuối cùng
            // 1 query để lấy thông tin, do nó có liên kết nhiều bảng với nhau
            // ở đây dùng subqueries cho nhanh

            var sqlGetLast = new GetLastCustomerQuery().query();
            List<customer> customers = new();
            using (IDbConnection db = new MySqlConnection("server=localhost;port=5060;user=root;password=140300;database=customerdatabase"))
            {
            var customerDictionary = new Dictionary<string, customer>();

                customers = db.Query<customer, loaitiemnang, the, history, customer>
                            (sqlGetLast, (customer, loaitiemnang, the, history)
                                =>
                            {
                                customer customerEntry;
                                if (!customerDictionary.TryGetValue(customer._id, out customerEntry))
                                {
                                    customerEntry = customer;
                                    customerEntry.loaitiemnang = loaitiemnang.loaitiemnangContent.Split("#").ToList();
                                    customerEntry.the = the.theContent.Split("#").ToList();
                                    customerEntry.history = history.historyContent.Split("#").ToList();
                                    customerDictionary.Add(customerEntry._id, customerEntry);
                                }
                                return customerEntry;
                            }, splitOn: "loaitiemnangContent, theContent, historyContent")
                            .Distinct().ToList();
            }
            return Ok(customers);
        }

        // POST : /customers/find tìm danh sách người dùng theo id (để xuất ra file excell)
        [HttpPost()]
        [Route("/customers/find")]
        public async Task<ActionResult> PostFindCustomer(string[] idsString)
        {

            // tương tự trường hợp đầu, cần dùng 2 query.
            // 1 query để lấy id cuối cùng
            // 1 query để lấy thông tin, do nó có liên kết nhiều bảng với nhau
            // ở đây dùng subqueries cho nhanh

            var sqlGetFind = new PostFindCustomerQuery().query(idsString);
            var customerDictionary = new Dictionary<string, customer>();
            List<customer> customers = new();
            using (IDbConnection db = new MySqlConnection("server=localhost;port=5060;user=root;password=140300;database=customerdatabase"))
            {

                customers = db.Query<customer, loaitiemnang, the, history, customer>
                            (sqlGetFind, (customer, loaitiemnang, the, history)
                                   =>
                            {
                                customer customerEntry;
                                if (!customerDictionary.TryGetValue(customer._id, out customerEntry))
                                {
                                    customerEntry = customer;
                                    customerEntry.loaitiemnang = loaitiemnang.loaitiemnangContent.Split("#").ToList();
                                    customerEntry.the = the.theContent.Split("#").ToList();
                                    customerEntry.history = history.historyContent.Split("#").ToList();
                                    customerDictionary.Add(customerEntry._id, customerEntry);
                                }
                                return customerEntry;
                            }, splitOn: "loaitiemnangContent, theContent, historyContent")
                            .Distinct().ToList();
            }
            return Ok(customers);
    }

        // GET : /customers/check check người dùng
        [HttpGet()]
        [Route("/customers/check")]
        public async Task<ActionResult> GetCheckCustomer(string findID)
        {
            var sqlGetCheck = new GetCheckCustomer().query(findID);
            var customerDictionary = new Dictionary<string, customer>();
            List<customer> customers = new();
            using (IDbConnection db = new MySqlConnection("server=localhost;port=5060;user=root;password=140300;database=customerdatabase"))
            {

                customers = db.Query<customer, loaitiemnang, the, history, customer>
                            (sqlGetCheck, (customer, loaitiemnang, the, history)
                                                                   =>
                            {
                                customer customerEntry;
                                if (!customerDictionary.TryGetValue(customer._id, out customerEntry))
                                {
                                    customerEntry = customer;
                                    customerEntry.loaitiemnang = loaitiemnang.loaitiemnangContent.Split("#").ToList();
                                    customerEntry.the = the.theContent.Split("#").ToList();
                                    customerEntry.history = history.historyContent.Split("#").ToList();
                                    customerDictionary.Add(customerEntry._id, customerEntry);
                                }
                                return customerEntry;
                            }, splitOn: "loaitiemnangContent, theContent, historyContent")
                            .Distinct().ToList();
            }
            return Ok(customers.First());
        }

        // POST: /customers (thêm bản ghi vào các cơ sở dữ liệu)
        [HttpPost()]
        [Route("/customers")]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult> PostCreateCustomer(
            [FromForm] PostCustomerBody PostCustomerBody
            )
        {
            var sqlCreateCustomer = new PostCreateCustomerQuery().query(PostCustomerBody);
            List<string> customerIds = new();
            using (IDbConnection db = new MySqlConnection("server=localhost;port=5060;user=root;password=140300;database=customerdatabase"))
            {

                customerIds = db.Query<string>(sqlCreateCustomer).ToList();
            }
            return Ok();
        }

        // PUT:/customers/edit chỉnh sửa ở mức cơ bản, yêu cầu phải trùng id của tất cả các cơ sở dữ liệu
        [HttpPut()]
        [Route("/customers/edit")]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult> PutEditCustomer(
            [FromForm] PostCustomerBody PostCustomerBody
            )
        {
            var sqlCreateCustomer = new PostUpdateCustomerQuery().query(PostCustomerBody);
            List<string> customerIds = new();
            using (IDbConnection db = new MySqlConnection("server=localhost;port=5060;user=root;password=140300;database=customerdatabase"))
            {

                customerIds = db.Query<string>(sqlCreateCustomer).ToList();
            }
            return Ok();
        }

        // POST : /customers/delete xóa nhiều bản ghi
        [HttpPost()]
        [Route("/customers/delete")]
        public async Task<ActionResult> PostDeleteCustomer(string[] idsString)
        {


            // tương tự trường hợp đầu, cần dùng 2 query.
            // 1 query để lấy id cuối cùng
            // 1 query để lấy thông tin, do nó có liên kết nhiều bảng với nhau
            // ở đây dùng subqueries cho nhanh

            var sqlPostDelete = new PostDeleteCustomerQuery().query(idsString);
            List<string> customers = new();
            using (IDbConnection db = new MySqlConnection("server=localhost;port=5060;user=root;password=140300;database=customerdatabase"))
            {

                customers = db.Query<string>(sqlPostDelete).ToList();
            }
            return Ok();
        }


    }
}
