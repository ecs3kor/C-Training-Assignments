namespace BoschProjectInterviewApp
{
    public delegate void BoschInterview();
    internal class Employee
    {
        public event BoschInterview Selected;
        public event BoschInterview Rejected;
        private int _id;
        public int EmployeeID { get { //Console.WriteLine("Get executed!");
                                      return _id; }
            set { //Console.WriteLine("Set executed!");
                  _id = value; } }

        //Auto Implemented Properties [Creating backing field]
        public string EmployeeName { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public int TotalMarks { get; set; }
        public string ProjectName { get; set; } = "Internal Projects";
        public string CalculateResult(int totalMarks, out string city)
        {
            if (totalMarks > 80)
            {
                if (Selected != null)
                {
                    Selected();
                }
                city = "Bangalore";
                return $"{EmployeeName}, Congratulations! You have been selected for the development of {ProjectName}!";
            }
            else
            {
                if (Rejected != null)
                {
                    Rejected();
                }
                city = City;
                return $"{EmployeeName}, Sorry! You have been rejected for the development of {ProjectName}!";
            }
        }

        //Only one params and it must be the last parameter in the list
        public void PrintBoschCities(params string[] cities) {
            foreach (var c in cities) { 
                Console.Write(c );
            }
            Console.WriteLine();

        }


    }
}
