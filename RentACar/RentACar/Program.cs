namespace RentACar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarRentalService carRentalService = new CarRentalService();

            // Örnek araçlar oluşturma ve sisteme ekleme
            Car car = new Car();
            car.Plate = "34 ABC 123";
            car.Brand = "Renault";
            car.Model = "Clio";
            car.YearOfProduction = 2020;
            car.km = 5000;
            car.Colour = "Kırmızı";
            car.Status = true;
            carRentalService.AddCar(car);

            Minibus minibüs = new Minibus();
            minibüs.Plate = "34 DEF 456";
            minibüs.Brand = "Mercedes";
            minibüs.Model = "Sprinter";
            minibüs.YearOfProduction = 2019;
            minibüs.km = 10000;
            minibüs.Colour = "Beyaz";
            minibüs.Status = false;
            carRentalService.AddCar(minibüs);

            Truc truc = new Truc();
            truc.Plate = "34 GHI 789";
            truc.Brand = "Volvo";
            truc.Model = "FH";
            truc.YearOfProduction = 2021;
            truc.km = 2000;
            truc.Colour = "Mavi";
            truc.Status = true;
            carRentalService.AddCar(truc);

            Console.WriteLine("Araç Kiralama Sistemi");
            Console.WriteLine("----------------------");

            while (true)
            {
                Console.WriteLine("1- Araç Ekle");
                Console.WriteLine("2- Araç Kirala");
                Console.WriteLine("3- Çıkış");
                Console.Write("Seçiminizi yapın: ");
                string option = Console.ReadLine();

                if (option == "1")
                {
                    Console.WriteLine("Araç Bilgilerini Girin");

                    Console.Write("Plaka: ");
                    string plate = Console.ReadLine();

                    Console.Write("Marka: ");
                    string brand = Console.ReadLine();

                    Console.Write("Model: ");
                    string model = Console.ReadLine();

                    Console.Write("Üretim Yılı: ");
                    int yearOfProduction = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Kilometre: ");
                    int km = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Renk: ");
                    string colour = Console.ReadLine();

                    Console.Write("Muayene Durumu (Evet/Hayır): ");
                    bool status = Console.ReadLine().ToLower() == "evet";

                    Console.Write("Araç Türü (Otomobil/Minibüs/Kamyon): ");
                    string araçTürü = Console.ReadLine().ToLower();

                    Cars arac = null;

                    switch (araçTürü)
                    {
                        case "otomobil":
                            arac = new Car();
                            break;
                        case "minibüs":
                            arac = new Minibus();
                            break;
                        case "kamyon":
                            arac = new Truc();
                            break;
                        default:
                            Console.WriteLine("Geçersiz araç türü.");
                            break;
                    }

                    if (car != null)
                    {
                        car.Plate = plate;
                        car.Brand = brand;
                        car.Model = model;
                        car.YearOfProduction = yearOfProduction;
                        car.km = km;
                        car.Colour = colour;
                        car.Status = status;

                        carRentalService.AddCar(car);
                    }
                }


                else if (option == "2")
                {
                    Console.Write("Kiralayacağınız aracın plakasını girin: ");
                    string plate = Console.ReadLine();

                    
            
                        Console.Write("Kiralama gün sayısını girin: ");
                        int gün = Convert.ToInt32(Console.ReadLine());

                        carRentalService.Rent(plate, gün);
                    
                   
                }
                else if (option == "3")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                }

                Console.WriteLine();
            }

            Console.WriteLine("Programdan çıkılıyor...");
            Console.ReadLine();
        }
    }
}
