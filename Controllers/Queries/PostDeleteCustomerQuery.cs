using fresher_test_ASP.NET_Core_Web_API.Models.ModelRequest;
using Microsoft.AspNetCore.Mvc;

namespace fresher_test_ASP.NET_Core_Web_API_Dapper_ORM.Controllers.Queries
{
    public class PostDeleteCustomerQuery
    {
        public string query(string[] idsString)
        {
            //xóa 
            string query = "";
            for (int i = 0; i < idsString.Count(); i++)
            {
                if (i < idsString.Count() - 1)
                {   
                    query += $" '{idsString[i]}' ,";
                }
                else
                {
                    query += $"'{idsString[i]}'";
                }
            }
            var stringCreateCustomerQuery =
            $"DELETE FROM customer c WHERE c._id IN ({query}) ; ";

            return stringCreateCustomerQuery;
        }

        
    }
}
