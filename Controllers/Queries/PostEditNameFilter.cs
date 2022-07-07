using fresher_test_ASP.NET_Core_Web_API.Models.ModelRequest;
using Microsoft.AspNetCore.Mvc;

namespace fresher_test_ASP.NET_Core_Web_API_Dapper_ORM.Controllers.Queries
{
    public class PostEditNameFilter
    {
        public string query(int id, string name)
        {
            var stringEditNameFilterQuery = 
                $"UPDATE filter SET name = '{name}' WHERE filterId = {id} ;";

            return stringEditNameFilterQuery;
        }

        
    }
}
