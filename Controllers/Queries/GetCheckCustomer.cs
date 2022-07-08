namespace fresher_test_ASP.NET_Core_Web_API_Dapper_ORM.Controllers.Queries
{
    public class GetCheckCustomer
    {
        public string query( string findID)
        {
            var stringGetLastCustomerQuery =
                "SELECT c.*, "
                + "( SELECT group_concat(l.loaitiemnangContent SEPARATOR  '#') FROM loaitiemnang l WHERE l.customerId = c._id  ) AS loaitiemnangContent,"
                + " ( SELECT group_concat(t.theContent SEPARATOR  '#') FROM the t WHERE t.customerId = c._id  ) AS theContent,"
                + "( SELECT group_concat(h.historyContent SEPARATOR  '#') FROM history h WHERE h.customerId = c._id  ) AS historyContent"
                + " FROM customer c"
                + $" WHERE c._id  = '{findID}'";

            return stringGetLastCustomerQuery;
        }

    }
}
