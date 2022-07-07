namespace fresher_test_ASP.NET_Core_Web_API_Dapper_ORM.Controllers.Queries.QueryFunctions
{
    public class FilterCustomerConditon
    {
        public string ConditionQuery(string columnInTable , string filterString, int? filterCondition)
        {
            string stringCustomerAllQuery = "";
            string addNewCondition = "";
            switch (filterCondition) {
                case 1:
                    // trường hợp là
                    addNewCondition = $" &&  {columnInTable} = '{filterString}' ";
                    stringCustomerAllQuery = addNewCondition;
                    break;
                case 2:
                    // trường hợp không là
                    addNewCondition = $" &&  {columnInTable} != '{filterString}' ";
                    stringCustomerAllQuery = addNewCondition;
                    break;
                case 3:
                    // trường hợp chứa, không phân biệt chữ hoa chữ thường
                    addNewCondition = $" &&  {columnInTable} LIKE '%{filterString}%' ";
                    stringCustomerAllQuery = addNewCondition;
                    break;
                case 4:
                    // trường hợp không chứa, không phân biệt chữ hoa chữ thường
                    addNewCondition = $" &&  {columnInTable} NOT LIKE '%{filterString}%' ";
                    stringCustomerAllQuery = addNewCondition;
                    break;
                case 5:
                    // trường hợp trống hoặc có thể là null
                    addNewCondition = $" &&  {columnInTable} IS NULL ";
                    stringCustomerAllQuery = addNewCondition;
                    break;
                case 6:
                    // trường hợp không trống hoặc có thể là không null, hiểu là có giá trị
                    addNewCondition = $" &&  {columnInTable} IS NOT NULL ";
                    stringCustomerAllQuery = addNewCondition;
                    break;
                default:
                    //return nothing
                    break;
            }
            return stringCustomerAllQuery;
        }
    }
}
