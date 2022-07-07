namespace fresher_test_ASP.NET_Core_Web_API_Dapper_ORM.Controllers.Queries
{
    public class GetCheckCustomer
    {
        public string query( string findID)
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
                + $" WHERE c._id  = '{findID}'";

            return stringGetLastCustomerQuery;
        }

    }
}
