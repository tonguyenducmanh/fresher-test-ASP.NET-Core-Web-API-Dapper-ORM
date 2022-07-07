namespace fresher_test_ASP.NET_Core_Web_API_Dapper_ORM.Controllers.Queries
{
    public class GetDeleteFilter
    {
        public string query(int id)
        {
            var stringDeleteQuery =
                "DELETE "
                + " FROM filter f"
                + $" WHERE f.filterId = {id}";
            return stringDeleteQuery;
        }
    }
}
