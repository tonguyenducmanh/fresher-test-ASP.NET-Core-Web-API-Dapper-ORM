namespace fresher_test_ASP.NET_Core_Web_API_Dapper_ORM.Controllers.Queries
{
    public class PostFindCustomerQuery
    {
        public string query(string[] idsString)
        {
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
            var stringGetLastCustomerQuery =
                "SELECT c.*, "
                + "( SELECT group_concat(l.loaitiemnangContent SEPARATOR  '#') FROM loaitiemnang l WHERE l.customerId = c._id  ) AS loaitiemnangContent,"
                + " ( SELECT group_concat(t.theContent SEPARATOR  '#') FROM the t WHERE t.customerId = c._id  ) AS theContent,"
                + "( SELECT group_concat(h.historyContent SEPARATOR  '#') FROM history h WHERE h.customerId = c._id  ) AS historyContent"
                + " FROM customer c"
                + $" WHERE c._id  IN ({query}) ";

            return stringGetLastCustomerQuery;
        }


    }
}
