namespace fresher_test_ASP.NET_Core_Web_API_Dapper_ORM.Controllers.Queries
{
    public class GetFetchFilter
    {
        public string query()
        {
            var stringFilterAllQuery =
                "SELECT * "
                + " FROM filter f"
                + " JOIN filtercontent fc ON f.filterId = fc.filterId";
            return stringFilterAllQuery;
        }
    }
}
