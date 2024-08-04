using System.Globalization;

namespace Assignment13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //13)	Enter date in dd/mm/yy format.
            //Write a program to print total no. Of days in a month and month as character month.

            Console.WriteLine("Write date in dd/mm/yy format");
            string date = Console.ReadLine();

            DateTime dateTime;
            if (DateTime.TryParseExact(date, "dd/MM/yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
            {
                int daysInMonth = DateTime.DaysInMonth(dateTime.Year, dateTime.Month);
                string monthName = dateTime.ToString("MMMM", CultureInfo.InvariantCulture);

                Console.WriteLine($"Total number of days in the month: {daysInMonth}");
                Console.WriteLine($"Month as a character month: {monthName}");
            }
            else
            {
                Console.WriteLine("Invalid date format.");
            }
        }
    }
}
