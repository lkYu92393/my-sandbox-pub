using Microsoft.AspNetCore.Mvc;

namespace DataTableTest.Controllers
{
    public class DataController : Controller
    {
        Services.EmployeeService employeeService;
        public DataController()
        {
            employeeService = new();
        }
        public IActionResult GetData(Models.DataTable.DataTableParameter dtParams)
        {
            (List<Models.Employee> filterList, int filteredCount) = employeeService.GetFilteredData(dtParams);

            return Json(new
            {
                draw = dtParams.draw,
                data = filterList,
                recordsTotal = employeeService.GetDataCount(),
                recordsFiltered = filteredCount,
            });
        }

        public IActionResult GetDataWithoutAutoBinding()
        {
            Dictionary<string, string> inputParams = new Dictionary<string, string>();
            foreach (var key in Request.Form.Keys)
            {
                if (key.StartsWith("order") || key.StartsWith("draw") || key.StartsWith("search") || key.StartsWith("length") || key.StartsWith("start") || key.StartsWith("columns"))
                {
                    inputParams.Add(key, Request.Form[key]);
                }
            }
            var dtParams = new Models.DataTable.DataTableParameter(inputParams);
            (List<Models.Employee> filterList, int filteredCount) = employeeService.GetFilteredData(dtParams);

            return Json(new
            {
                draw = dtParams.draw,
                data = filterList,
                recordsTotal = employeeService.GetDataCount(),
                recordsFiltered = filteredCount,
            });
        }
    }
}
