using System;

namespace DependencyInversion
{
    class Program
    {
        static void Main(string[] args)
        {
            
            ICarService carService = new CarService();

            ICar car = new MockCar();//Test-Objekt
            carService.Repair(car);

            //Nach Tag 5
            ICar car1 = new Car();//Test-Objekt
            carService.Repair(car1);

        }
    }


    #region Bad Code

    //Entities.dll
    public class BadCode_Car // Programmierer A -> 5 Tage (von Tag1 - Tag5)
    {
        public int Id { get; set; }
        public string Marke { get; set; }
        public string Modell { get; set; }
        public int Baujahr { get; set; }
    }

    //Service.dll 
    public class BadCode_CarService //Programmierer B -> (von Tag5/Tag6 - Tag7) 
    {
        //Der Beginn eines noch sehr jungen Monolithes -> Alles ist hart verdrahtet 
        public void RepairCar(BadCode_Car car) //Wir verwenden als Parameter BadCode_Car
        {
            //repariere das Auto 
        }
    }
    #endregion


    #region Contract First -> Dependency Inversion

    //Interface.dll
    public interface ICar
    {
        int Id { get; set; }
        string Marke { get; set; }
        string Modell { get; set; }
        int Baujahr { get; set; }
    }

    public interface ICarService
    {
        void Repair(ICar car);
    }

    #endregion

    #region Gute Code 

    //Entities.dll -> Programmierer A: 5 Tage (von Tag 1 - 5)
    public class Car : ICar
    {
        public int Id { get; set; }
        public string Marke { get; set; }
        public string Modell { get; set; }
        public int Baujahr { get; set; }
    }


    //Service.dll -> Programmierer B - 3 Tage (von Tag 1 - 3)
    public class CarService : ICarService
    {
        public void Repair(ICar car)
        {
            //Repariere Auto
        }
    }

    public class MockCar : ICar
    {
        public int Id { get; set; } = 123;
        public string Marke { get; set; } = "VW";
        public string Modell { get; set; } = "Polo";
        public int Baujahr { get; set; } = 1985;
    }
    #endregion
}
