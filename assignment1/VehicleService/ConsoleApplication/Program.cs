using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            String choice;

            while (true)
            {

                Console.WriteLine("Please choose operation : ");
                Console.WriteLine("     a) search for vehicle");
                Console.WriteLine("     b) create vehicle");
                Console.WriteLine("     c) show available vehicles");
                Console.WriteLine("     x) exit");
                choice = Console.ReadLine();

                if (choice.ToLower().Equals("a"))
                {
                    string plateInput;
                    Console.WriteLine("Please input number plate : eg \"cd123 moto\" ");
                    plateInput = Console.ReadLine();

                    VehicleService.VehicleServiceClient vsc = new VehicleService.VehicleServiceClient("BasicHttpBinding_IVehicleService");
                    VehicleService.SoapVehicle[] v_arr = vsc.search(plateInput);//eg "cd123 moto"
                    foreach (VehicleService.SoapVehicle v in v_arr)
                    {
                        Console.WriteLine(v.NumberPlate);
                        Console.WriteLine(v.VehicleType);
                        Console.WriteLine(v.ToString());
                    }
                }
                if (choice.ToLower().Equals("b"))
                {
                    string plateInput;
                    Console.WriteLine("Please input number plate : eg \"cd123 moto\" ");
                    plateInput = Console.ReadLine();

                    VehicleService.VehicleServiceClient vsc = new VehicleService.VehicleServiceClient("BasicHttpBinding_IVehicleService");
                    VehicleService.SoapVehicle v = vsc.create(plateInput);
                    Console.WriteLine(v.NumberPlate);
                    Console.WriteLine(v.VehicleType);
                    Console.WriteLine(v.ToString());

                }
                if (choice.ToLower().Equals("c"))
                {
                    VehicleService.VehicleServiceClient vsc = new VehicleService.VehicleServiceClient("BasicHttpBinding_IVehicleService");
                    VehicleService.SoapVehicle[] v_arr = vsc.list();
                    foreach (VehicleService.SoapVehicle v in v_arr)
                    {
                        Console.WriteLine(v.NumberPlate);
                        Console.WriteLine(v.VehicleType);
                        Console.WriteLine(v.ToString());
                    }

                }
                if (choice.ToLower().Equals("x"))
                {
                    Environment.Exit(0);

                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
