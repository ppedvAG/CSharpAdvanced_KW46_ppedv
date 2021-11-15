using System;

namespace SingleResponsibilityPrincipe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }


    #region Schlechtes Beispiel
    public class EmployeeBad
    {
        public int Employee_Id { get; set; }
        public string Employee_Name { get; set; }

        /// <summary>
        /// This method used to insert into employee table
        /// </summary>
        /// <param name="em">Employee object</param>
        /// <returns>Successfully inserted or not</returns>
        public bool InsertIntoEmployeeTable(EmployeeBad em)
        {
            // Insert into employee table.
            return true;
        }

        /// <summary>
        /// Method to generate report
        /// </summary>
        /// <param name="em"></param>
        public void GenerateReport(EmployeeBad em)
        {
            // Report generation with employee data using crystal report.
        }
    }
    #endregion


    #region Guten Beispiel
    public class Employee //Ich halte die Daten zusammen
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class EmployeeRepository //Ich rede mit der Datenbank 
    {
        public void Insert(Employee employee)
        {
            //Employee wird in die Tabelle (DB) eingefügt. 
        }
    }

    public class ReportGenerator //Ich schreibe Reports
    {
        public void Generate()
        {
            //Mach ein Report
        }

        public string OutputFolder { get; set; }
    }
    #endregion
}
