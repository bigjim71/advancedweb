using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using DTOClassLibrary;

namespace VehicleDBApplication
{
    class Program
    {


        static void Main(string[] args)
        {
            Program app = new Program();
            DBService dbService = new DBService();

            String choice;
            Console.WriteLine("Please choose operation : "); 
            Console.WriteLine("     a) create vehicles");
            Console.WriteLine("     b) list vehicles");
            choice=Console.ReadLine();

            if (choice.ToLower().Equals("a"))
            {
                app.createData(dbService);
            }
            else
            {
                app.listData(dbService);
            }
            Console.WriteLine(); 
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();

        }

        private void createData(DBService app)
        {
            //create some new records
            Vehicle2WD moto = new Vehicle2WD();
            moto.NumberPlate = "cd123 moto";
            moto.VehicleType = "2WD";
            moto.Mileage = 10000;
            moto.RentalCharge = 10.46;
            moto.Under21 = true;

            app.createVehicle(moto);

            Vehicle4WD w = new Vehicle4WD();
            w.NumberPlate = "cd456 4wd";
            w.VehicleType = "4WD";
            w.Mileage = 206000;
            w.RentalCharge = 540.5;
            w.OffRoad = true;
            w.DirtRoad = true;
            w.NormalRoad = true;

            app.createVehicle(w);

            CamperVan c = new CamperVan();
            c.NumberPlate = "cd678 Camp";
            c.VehicleType = "CAMPER";
            c.Mileage = 9999;
            c.RentalCharge = 1000;
            c.NumberBeds = 3;
            c.Toilet = false;

            app.createVehicle(c);


        }

        private void listData(DBService app )
        {
            // The loop will print every Vehicle in the list
            foreach
            (Vehicle e in app.listVehicles())
            {
                Console.WriteLine(e);

            }
        }



    }
}
