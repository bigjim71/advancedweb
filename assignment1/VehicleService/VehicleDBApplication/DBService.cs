using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using DTOClassLibrary;

namespace VehicleDBApplication
{
    public class DBService
    {
        private static string database_name = "leicester";
        private static string user_id = "leicester";
        private static string password = "leicester1";
        private static string dataSource = "192.168.5.131";

        static MySqlConnection getConnection()
        {
            //this static method will return a connection constructed by connection string
            string myConnectionString = "Database=" + database_name + ";DataSource=" + dataSource + ";User Id=" + user_id + ";Password=" + password;
            MySqlConnection connection = new MySqlConnection(myConnectionString);
            return connection;
        }

        public List<Vehicle> listVehicles()
        { //a list of Vehicles
            List<Vehicle> Vehicles = new List<Vehicle>();
            try
            {
                //Open connection
                MySqlConnection connection = getConnection();
                connection.Open();
                // SQL query assignment
                MySqlCommand mycm = new MySqlCommand
                    ("select * from vehicle", connection);
                //execute query
                MySqlDataReader msdr = mycm.ExecuteReader();
                while (msdr.Read())
                {
                    if (msdr.HasRows)
                    {
                        Vehicles.Add(asBean(msdr));

                    }
                }
                msdr.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            //return Vehicle list
            return Vehicles;
        }

        public List<Vehicle> advancedSearch(string key)
        {
            //a list of Vehicles 
            List<Vehicle> Vehicles = new List<Vehicle>();
            try
            {
                if (key.Contains('*'))
                {    //replace wild card character with '%' 
                    key = key.Replace('*', '%');
                }
                else
                {
                    //look up keyword in the whole string if it doesn't contain wild card, 
                    key = "%" + key + "%";
                }
                //Open connection 
                MySqlConnection connection = getConnection();
                connection.Open();
                //assign SQL query 
                MySqlCommand mycm = new MySqlCommand("select * from vehicle where upper(numberPlate) like '" + key + "'", connection);
                //execute query 
                MySqlDataReader msdr = mycm.ExecuteReader();
                while (msdr.Read())
                {
                    if (msdr.HasRows)
                    {
                        Vehicles.Add(asBean(msdr));
                    }
                }
                msdr.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            //return Vehicle list 
            return Vehicles;
        }

        public bool createVehicle(Vehicle vehicle)
        {
            try
            {
                MySqlConnection connection = getConnection();
                connection.Open();
                MySqlCommand mycm = new MySqlCommand("", connection);
                mycm.Prepare();

                if (vehicle.VehicleType.ToUpper().Equals("4WD"))
                {
                    mycm.CommandText = "INSERT INTO vehicle(numberPlate, vehicleType, mileage, rentalCharge, offRoad, dirtRoad, normalRoad) VALUES(@numberPlate, @vehicleType, @mileage, @rentalCharge, @offRoad, @dirtRoad, @normalRoad)";
                    addBasicParams(mycm, vehicle);
                    add4WDParams(mycm, (Vehicle4WD)vehicle);
                }

                if (vehicle.VehicleType.ToUpper().Equals("2WD"))
                {
                    mycm.CommandText = "INSERT INTO vehicle(numberPlate, vehicleType, mileage, rentalCharge, under21) VALUES(@numberPlate, @vehicleType, @mileage, @rentalCharge, @under21)";
                    addBasicParams(mycm, vehicle);
                    addMotoParams(mycm, (Vehicle2WD)vehicle);
                }

                if (vehicle.VehicleType.ToUpper().Equals("CAMPER"))
                {
                    mycm.CommandText = "INSERT INTO vehicle(numberPlate, vehicleType, mileage, rentalCharge, numberBeds, toilet) VALUES(@numberPlate, @vehicleType, @mileage, @rentalCharge, @numberBeds, @toilet)";
                    addBasicParams(mycm, vehicle);
                    addCamperParams(mycm, (CamperVan)vehicle);
                }

                mycm.ExecuteNonQuery();
                connection.Close();
                return true; //successful 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false; //fail 
            }
        }

        public bool deleteVehicleById(int id)
        {
            try
            {
                MySqlConnection connection = getConnection();
                connection.Open();
                MySqlCommand mycm = new MySqlCommand("", connection);
                mycm.Prepare();
                mycm.CommandText = String.Format("delete from Vehicle where id=?id_para");
                mycm.Parameters.AddWithValue("?id_para", id);
                mycm.ExecuteNonQuery();
                connection.Close();
                return true; //successful 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false; //fail 
            }
        }

        //create bean
        private Vehicle asBean(MySqlDataReader msdr)
        {
            string vehicleType = msdr.GetString("vehicleType");

            switch (vehicleType)
            {
                case "4WD":
                    Vehicle4WD v4 = new Vehicle4WD();
                    v4.NumberPlate = msdr.GetString("numberPlate");
                    v4.Mileage = msdr.GetInt32("mileage");
                    v4.RentalCharge = msdr.GetDouble("rentalCharge");
                    v4.VehicleType = msdr.GetString("vehicleType");
                    v4.OffRoad = msdr.GetBoolean("offRoad");
                    v4.DirtRoad = msdr.GetBoolean("dirtRoad");
                    v4.NormalRoad = msdr.GetBoolean("normalRoad");
                    return v4;
                case "2WD":
                    Vehicle2WD v2 = new Vehicle2WD();
                    v2.NumberPlate = msdr.GetString("numberPlate");
                    v2.Mileage = msdr.GetInt32("mileage");
                    v2.RentalCharge = msdr.GetDouble("rentalCharge");
                    v2.VehicleType = msdr.GetString("vehicleType");
                    v2.Under21 = msdr.GetBoolean("under21");
                    return v2;
                case "CAMPER":
                    CamperVan vc = new CamperVan();
                    vc.NumberPlate = msdr.GetString("numberPlate");
                    vc.Mileage = msdr.GetInt32("mileage");
                    vc.RentalCharge = msdr.GetDouble("rentalCharge");
                    vc.VehicleType = msdr.GetString("vehicleType");
                    vc.NumberBeds = msdr.GetInt16("numberBeds");
                    vc.Toilet = msdr.GetBoolean("toilet");
                    return vc;
                default:
                    throw new InvalidOperationException("cannot instantiate object of type: " + vehicleType);
            }
        }

        //add basic params
        private void addBasicParams(MySqlCommand mycm, Vehicle vehicle)
        {
            mycm.Parameters.AddWithValue("@numberPlate", vehicle.NumberPlate);
            mycm.Parameters.AddWithValue("@vehicleType", vehicle.VehicleType);
            mycm.Parameters.AddWithValue("@mileage", vehicle.Mileage);
            mycm.Parameters.AddWithValue("@rentalCharge", vehicle.RentalCharge);
        }

        private void addMotoParams(MySqlCommand mycm, Vehicle2WD vehicle)
        {
            mycm.Parameters.AddWithValue("@under21", vehicle.Under21);
        }

        private void add4WDParams(MySqlCommand mycm, Vehicle4WD vehicle)
        {
            mycm.Parameters.AddWithValue("@offRoad", vehicle.OffRoad);
            mycm.Parameters.AddWithValue("@dirtRoad", vehicle.DirtRoad);
            mycm.Parameters.AddWithValue("@normalRoad", vehicle.NormalRoad);
        }

        private void addCamperParams(MySqlCommand mycm, CamperVan vehicle)
        {
            mycm.Parameters.AddWithValue("@numberBeds", vehicle.NumberBeds);
            mycm.Parameters.AddWithValue("@toilet", vehicle.Toilet);
        }
    }
}
