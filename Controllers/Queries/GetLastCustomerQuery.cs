namespace fresher_test_ASP.NET_Core_Web_API_Dapper_ORM.Controllers.Queries
{
    public class GetLastCustomerQuery
    {
        public string query()
        {
            var stringGetLastCustomerQuery =
                "SELECT c.*, "
                + "l.loaitiemnangContent AS loaitiemnangContent,"
                + " t.theContent AS theContent,"
                + " h.historyContent AS historyContent"
                + " FROM customer c"
                + " LEFT JOIN loaitiemnang l ON c._id = l.customerId"
                + " LEFT JOIN the t ON c._id = t.customerId"
                + " LEFT JOIN history h ON c._id = h.customerId"
                + $" WHERE c._id  = (SELECT c._id FROM customer c ORDER BY c._id DESC LIMIT 1)";

            return stringGetLastCustomerQuery;
        }

    }
}
