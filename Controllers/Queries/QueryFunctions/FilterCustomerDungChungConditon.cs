namespace fresher_test_ASP.NET_Core_Web_API_Dapper_ORM.Controllers.Queries.QueryFunctions
{
    public class FilterCustomerDungChungCondition
    {
        public string ConditionQuery(string columnInTable , bool? filterString, int? filterCondition)
        {
            string stringCustomerAllQuery = "";
            string addNewCondition = "";
            switch (filterCondition) {
                
                case 7:
                    // trường hợp dành riêng cho thanh niên dùng chung filter
                    addNewCondition = $" &&  {columnInTable} = {filterString} ";
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
