namespace _21July2026.Models
{
    public static class DepartmentData
    {
        public static List<Department> GetDepartments()
        {
            return new List<Department>
            {
                new Department
                {
                    DepartmentName = "IT",
                    DepartmentHead = "John Doe",
                    HeadContactNumber = "9876543210",
                    HeadEmail = "john@company.com"
                },
                new Department
                {
                    DepartmentName = "HR",
                    DepartmentHead = "Jane Smith",
                    HeadContactNumber = "9876543211",
                    HeadEmail = "jane@company.com"
                },
                new Department
                {
                    DepartmentName = "Finance",
                    DepartmentHead = "Mike Johnson",
                    HeadContactNumber = "9876543212",
                    HeadEmail = "mike@company.com"
                }
            };
        }
    }
}
