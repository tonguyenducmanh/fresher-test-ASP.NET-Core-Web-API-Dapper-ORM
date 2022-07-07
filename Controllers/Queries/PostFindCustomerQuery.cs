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
                + "l.loaitiemnangContent AS loaitiemnangContent,"
                + " t.theContent AS theContent,"
                + " h.historyContent AS historyContent"
                + " FROM customer c"
                + " LEFT JOIN loaitiemnang l ON c._id = l.customerId"
                + " LEFT JOIN the t ON c._id = t.customerId"
                + " LEFT JOIN history h ON c._id = h.customerId"
                + $" WHERE c._id  IN ({query}) ";

            return stringGetLastCustomerQuery;
        }


    }
}
