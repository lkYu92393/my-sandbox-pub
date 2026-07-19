namespace DataTableTest.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public static List<Employee> GetMockData(int numberOfRecords)
        {
            List<Employee> employeeList = new();
            Random rnd = new Random();
            int age = 0;
            for (int i = 0; i < numberOfRecords; i++)
            {
                age = rnd.Next(30, 60);
                employeeList.Add(new Employee()
                {
                    Id = i,
                    EmployeeFirstName = Helpers.Common.GetRandomName(),
                    EmployeeLastName = Helpers.Common.GetRandomName(),
                    Age = age,
                    BirthDate = DateTime.Parse($"{2024-age}-01-01"),
                    StartDate = DateTime.Parse($"{rnd.Next(2010, 2020)}-01-01"),
                    EndDate = DateTime.Parse("9999-01-01"),
                });
            }
            return employeeList;
        }
    }
}
