namespace BoschProjectInterviewApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Employee employee = new Employee();
                employee.Selected +=new BoschInterview(SQLServerDb);
                employee.Rejected += OracleDb;
                employee.Selected += SendEmailToBoss;
                employee.EmployeeID = 1;
                employee.EmployeeName = "Test";
                employee.City = "Test City";
                employee.TotalMarks = 97;
                if (employee.TotalMarks < 95) {
                    employee.Selected += SendEmailToBoss;
                }
                string workingCity;
                Console.WriteLine(employee.CalculateResult(employee.TotalMarks,out workingCity));
                Console.WriteLine($"Working city is {workingCity}");
                employee.PrintBoschCities("bangalore","Chennai");
                employee.PrintBoschCities("Delhi", "Coimbatore","Pune");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }

        private static void OracleDb()
        {
            Console.WriteLine("Employees data stored in Oracle DB!");
        }
        private static void SQLServerDb()
        {
            Console.WriteLine("Employees data stored in Micrsoft SQL Server DB!");
        }
        private static void SendEmailToBoss()
        {
            Console.WriteLine("Email sent for student above 95");
        }
    }
}
