namespace DataTableTest.Services
{
    public class EmployeeService
    {
        private static List<Models.Employee> dataSrc = null;

        public EmployeeService()
        {
            if (dataSrc == null)
            {
                dataSrc = Models.Employee.GetMockData(217);
            }
        }

        public List<Models.Employee> GetData()
        {
            return dataSrc;
        }

        public int GetDataCount()
        {
            return dataSrc.Count;
        }

        public (List<Models.Employee>, int) GetFilteredData(Models.DataTable.DataTableParameter dtParams)
        {
            var dataQuery = dataSrc.AsQueryable();
            //search


            //order
            foreach (var item in dtParams.order)
            {
                switch(item.name)
                {
                    case "ID":
                        dataQuery = item.dir == "asc" ? dataQuery.OrderBy(obj => obj.Id) : dataQuery.OrderByDescending(obj => obj.Id);
                        break;
                    case "First Name":
                        dataQuery = item.dir == "asc" ? dataQuery.OrderBy(obj => obj.EmployeeFirstName) : dataQuery.OrderByDescending(obj => obj.EmployeeFirstName);
                        break;
                    case "Last Name":
                        dataQuery = item.dir == "asc" ? dataQuery.OrderBy(obj => obj.EmployeeLastName) : dataQuery.OrderByDescending(obj => obj.EmployeeLastName);
                        break;
                    case "Age":
                        dataQuery = item.dir == "asc" ? dataQuery.OrderBy(obj => obj.Age) : dataQuery.OrderByDescending(obj => obj.Age);
                        break;
                    case "Birth Date":
                        dataQuery = item.dir == "asc" ? dataQuery.OrderBy(obj => obj.BirthDate) : dataQuery.OrderByDescending(obj => obj.BirthDate);
                        break;
                    case "Start Date":
                        dataQuery = item.dir == "asc" ? dataQuery.OrderBy(obj => obj.StartDate) : dataQuery.OrderByDescending(obj => obj.StartDate);
                        break;
                    case "End Date":
                        dataQuery = item.dir == "asc" ? dataQuery.OrderBy(obj => obj.EndDate) : dataQuery.OrderByDescending(obj => obj.EndDate);
                        break;
                }
            }

            return (dataQuery.Skip(dtParams.start).Take(dtParams.length).ToList(), dataQuery.Count());
        }
    }
}
