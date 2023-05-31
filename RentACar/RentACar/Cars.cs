using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar
{
    abstract class Cars
    {
        public string Plate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int YearOfProduction { get; set; }
        public int km { get; set; }
        public string Colour { get; set; }
        public double RentMone { get; set; }
        public bool Status { get; set; }

        public abstract double CalculateRent(int day);
        public abstract string Situation();
        public bool VehicleİnspectionCheck()
        {
            if (Status)
            {
                Console.WriteLine("Araç muayenede olduğu için başka bir araç kiralayın.");
                return false;
            }
            return true;
        }

    }

    // Araç sınıfı
    class Car : Cars
    {
        public override double CalculateRent(int day)
        {
            double dailyRentalFee = 100;

            return dailyRentalFee * day;
        }

        public override string Situation()
        {
            if (Status)
                return " Hizmet dişi (Muayenede)";

            else
                return "Hizmette";
        }
    }

    // Minübüs Sınıfı
    class Minibus : Cars
    {
        public override Double CalculateRent(int day)
        {
            double dailyRentalFee = 200;

            return dailyRentalFee * day;
        }

        public override string Situation()
        {
            if (Status)
                return " Hizmet dişi (Muayenede)";

            else
                return "Hizmette";
        }
    }

    // Kamyon sınıfı
    class Truc : Cars
    {
        public override double CalculateRent(int day)
        {
            double dailRentalFree = 300;
            return dailRentalFree * day;
        }

        public override string Situation()
        {
            if (Status)
                return "Hizmet Dışı (Muayene)";
            else
                return "Hizmette";
        }


    }

    // Araç kiralama servisi
    class CarRentalService
    {
        private List<Cars> cars;
        public CarRentalService()
        {
            cars = new List<Cars>();
        }

        public void AddCar(Cars car)
        {
            cars.Add(car);
            Console.WriteLine("Araç başarıyla eklendi.");
        }
        public void Rent (string plate, int day)
        {
            Cars rentalCar = null;

            //kiralanan aracı bulma
            foreach (Cars car in cars)
            {
                if (car.Plate==plate)
                {
                    rentalCar = car;
                    break;
                }
            }

            if (rentalCar != null )
            {
                if (rentalCar.Status)
                {

                    double rentFree = rentalCar.CalculateRent(day);
                    Console.WriteLine("Kiralanan Araç Bilgileri");
                    Console.WriteLine("Plate : " + rentalCar.Plate);
                    Console.WriteLine("Brand : " + rentalCar.Brand);
                    Console.WriteLine("Model : " + rentalCar.Model);
                    Console.WriteLine("Kiralama Gün Sayısı : " + day);
                    Console.WriteLine("Toplam Kira Ücreti: " + rentFree);
                }

                else
                {
                    Console.WriteLine("Araç muayenede olduğu için başka bir araç kiralayın.");
                }
            }
            else
                Console.WriteLine("Belirtilen plakaya sahip bir araç bulunmamaktadır.");
        }
    }
}
