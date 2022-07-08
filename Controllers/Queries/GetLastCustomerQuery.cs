namespace fresher_test_ASP.NET_Core_Web_API_Dapper_ORM.Controllers.Queries
{
    public class GetLastCustomerQuery
    {
        public string query()
        {
            var stringGetLastCustomerQuery =
                // phải dùng group_concat thay cho join nhiều table, vì nó sẽ tránh được lặp kết quả của 1 ID.
                // kết quả sql chỉ trả về 1 row 1 column, cách này nhóm nhiều column vào 1 row
                "SELECT c.*, "
                + "( SELECT group_concat(l.loaitiemnangContent SEPARATOR  '#') FROM loaitiemnang l WHERE l.customerId = c._id  ) AS loaitiemnangContent,"
                + " ( SELECT group_concat(t.theContent SEPARATOR  '#') FROM the t WHERE t.customerId = c._id  ) AS theContent,"
                + "( SELECT group_concat(h.historyContent SEPARATOR  '#') FROM history h WHERE h.customerId = c._id  ) AS historyContent"
                + " FROM customer c"
                + $" WHERE c._id  = (SELECT c._id FROM customer c ORDER BY c._id DESC LIMIT 1)";
            return stringGetLastCustomerQuery;
        }

    }
}
