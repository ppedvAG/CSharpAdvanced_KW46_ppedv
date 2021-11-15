using System;

namespace OpenClosePrinzip
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }


    #region BadCode
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }


    public class ReportGenerator
    {
        /// <summary>
        /// Report type
        /// </summary>
        public string ReportType { get; set; }

        /// <summary>
        /// Method to generate report
        /// </summary>
        /// <param name="em"></param>
        public void GenerateReport(Employee em)
        {
            if (ReportType == "CRS")
            {
                // Report generation with employee data in Crystal Report.
            }
            else if (ReportType == "PDF")
            {
                //Libary für PDF Export
                //Fülllogik us
                // Report generation with employee data in PDF.
            }
            else
            {

            }
        }
    }

    #endregion

    #region Guter Code - Variante 1
    public abstract class ReportGeneratorBase
    {
        public abstract void Generate();
    }

    public class CrystalReportGenerator : ReportGeneratorBase
    {
        // Properties haben einen kompletten Bezug auf CrystalReport 

        public override void Generate()
        {
            // CrystalReport implementierung
        }
    }

    public class PDFReportGenerator : ReportGeneratorBase
    {
        // Properties haben einen kompletten Bezug auf CrystalReport 

        public override void Generate()
        {
            // CrystalReport implementierung
        }
    }
    #endregion


    #region Guter Code - Variante 2
    public interface IReportGenerator
    {
        void Generate();
    }

    public class CRGenerator : IReportGenerator
    {
        public void Generate()
        {
            throw new NotImplementedException();
        }
    }

    public class PDFGenerator : IReportGenerator
    {
        public void Generate()
        {
            throw new NotImplementedException();
        }
    }
    #endregion
}
