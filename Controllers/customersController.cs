using Dapper;
using fresher_test_ASP.NET_Core_Web_API.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace fresher_test_ASP.NET_Core_Web_API_Dapper_ORM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class customersController : ControllerBase
    {
        // GET: api/<customersController>
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            string sql  = @"SELECT c.*, l.loaitiemnangContent, t.theContent, h.historyContent
                            FROM customer c
                            JOIN loaitiemnang l ON c._id = l.customerId
                            JOIN the t ON c._id = t.customerId
                            JOIN history h ON c._id = h.customerId
                            LIMIT 10
                            ";
            var customerDictionary = new Dictionary<string, customer>();

            List<customer> customers = new();
            using (IDbConnection db = new MySqlConnection("server=localhost;port=5060;user=root;password=140300;database=customerdatabase"))
            {

                customers = db.Query<customer,loaitiemnang,the,history,customer>
                            (sql, (customer, loaitiemnang, the, history)
                                =>
                            {
                                customer cusomerEntry;
                                if(!customerDictionary.TryGetValue(customer._id, out cusomerEntry)){
                                    cusomerEntry = customer;
                                    cusomerEntry.loaitiemnang = new List<loaitiemnang>();
                                    cusomerEntry.the = new List<the>();
                                    cusomerEntry.history = new List<history>();
                                    customerDictionary.Add(cusomerEntry._id, cusomerEntry);
                                }
                                cusomerEntry.loaitiemnang.Add(loaitiemnang);
                                cusomerEntry.the.Add(the);
                                cusomerEntry.history.Add(history);
                                return cusomerEntry;
                            }, splitOn: "*")
                            .Distinct().ToList();
            }
            return Ok(customers);
        }
    }
}
