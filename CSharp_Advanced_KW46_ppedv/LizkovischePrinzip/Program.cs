using System;

namespace LizkovischePrinzip
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    #region BadCode
    public class BadErdbeere
    {
        public string GetColor ()
        {
            return "rot";
        }
    }

    public class BadKirsche : BadErdbeere
    {
        public string Color()
        {
            return base.GetColor();
        }
    }
    #endregion

    #region Good Code
    public interface IFruits
    {
        string GetColor();
    }

    public class Erdbeere : IFruits
    {
        public string GetColor()
        {
            return "rot";
        }
    }

    public class Kirsche : IFruits
    {
        public string GetColor()
        {
            return "rot";
        }
    }
    #endregion
}
