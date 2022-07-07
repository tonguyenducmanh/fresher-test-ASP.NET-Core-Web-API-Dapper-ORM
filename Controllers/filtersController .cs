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
    public class filtersController : ControllerBase
    {

        // GET: /filters tải toàn bộ danh sách bộ lọc
        [HttpGet]
        [Route("/filters")]
        public async Task<ActionResult> GetFetchFilter()
        {
            var sqlGetAllFilter = new GetFetchFilter().query();
            List<filter> filters = new();
            using (IDbConnection db = new MySqlConnection("server=localhost;port=5060;user=root;password=140300;database=customerdatabase"))
            {

                filters = db.Query<filter, filterContent, filter>
                            (sqlGetAllFilter, (filter, filterContent)
                                =>
                            {
                                filter.filterContent = filterContent;

                                return filter;
                            }, splitOn: "filterContentId")
                            .Distinct().ToList();
            }
            return Ok(filters);
        }

        // GET: /filter/delete xóa danh sách các bộ lọc
        [HttpGet]
        [Route("/filters/delete")]
        public async Task<ActionResult> GetDeleteFilter(int id)
        {
            var sqlDeleteFilter = new GetDeleteFilter().query(id);
            using (IDbConnection db = new MySqlConnection("server=localhost;port=5060;user=root;password=140300;database=customerdatabase"))
            {

                db.Query<filter>(sqlDeleteFilter);
            }
            return NoContent();
        }

        // POST: /filters tạo bộ lọc mới
        [HttpPost]
        [Route("/filters")]
        public async Task<ActionResult<filter>> PostCreateFilter(
            [FromForm] PostFilterBody PostFilterBody
            )
        {
            var sqlCreateFilter = new PostCreateFilter().query(PostFilterBody);
            using (IDbConnection db = new MySqlConnection("server=localhost;port=5060;user=root;password=140300;database=customerdatabase"))
            {

                db.Query<string>(sqlCreateFilter);
            }
            return Ok();
        }

        // PUT: /filters/edit chỉnh sửa tên của bộ lọc
        [HttpPut]
        [Route("/filters/edit")]
        public async Task<IActionResult> PutEditFilter(int id, string name)
        {
            var sqlEditFilter = new PostEditNameFilter().query(id, name);
            using (IDbConnection db = new MySqlConnection("server=localhost;port=5060;user=root;password=140300;database=customerdatabase"))
            {

                db.Query<string>(sqlEditFilter);
            }
            return Ok();
        }


    }
}
