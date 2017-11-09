using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DTOClassLibrary;
using VehicleDBApplication;
using VehicleService.ServiceReferenceUpper;

namespace VehicleService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class VehicleService : IVehicleService
    {
        /*
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
         */

        public List<SoapVehicle> search(string numberPlate)
        {

            //UpperOperatorService.UpperOperatorPortTypeClient upperSvc = new UpperOperatorService.UpperOperatorPortTypeClient("UpperOperatorSOAP12port_http");
            //numberPlate = upperSvc.upper(numberPlate);

            //fetch from database
            VehicleDBApplication.DBService dbService = new DBService();
            List<Vehicle> vList = dbService.advancedSearch(numberPlate);
            List<SoapVehicle> soapVehicles = new List<SoapVehicle>();

            foreach (Vehicle v in vList)
            {
                SoapVehicle sv = new SoapVehicle();
                sv.NumberPlate = v.NumberPlate;
                sv.VehicleType = v.VehicleType;
                sv.Mileage = v.Mileage;
                sv.RentalCharge = v.RentalCharge;
                soapVehicles.Add(sv);

            }
            return soapVehicles;
        }

        public SoapVehicle create(string numberPlate)
        {

            //UpperOperatorService.UpperOperatorPortTypeClient upperSvc = new UpperOperatorService.UpperOperatorPortTypeClient("UpperOperatorSOAP12port_http");
            //numberPlate = upperSvc.upper(numberPlate);

            //create new vehicle
            VehicleDBApplication.DBService dbService = new DBService();

            DTOClassLibrary.Vehicle2WD moto = new Vehicle2WD();
            moto.NumberPlate = numberPlate;
            moto.VehicleType = "2WD";
            moto.Mileage = 10000;
            moto.RentalCharge = 10.46;
            moto.Under21 = true;

            dbService.createVehicle(moto);
            SoapVehicle sv = new SoapVehicle();
            sv.NumberPlate = moto.NumberPlate;
            sv.VehicleType = moto.VehicleType;
            sv.Mileage = moto.Mileage;
            sv.RentalCharge = moto.RentalCharge;

            return sv;
        }

        public List<SoapVehicle> list()
        {
            //fetch all vehicles from db
            VehicleDBApplication.DBService dbService = new DBService();
            List<Vehicle> vList = dbService.listVehicles();
            List<SoapVehicle> soapVehicles = new List<SoapVehicle>();

            foreach (Vehicle v in vList)
            {
                SoapVehicle sv = new SoapVehicle();
                sv.NumberPlate = v.NumberPlate;
                sv.VehicleType = v.VehicleType;
                sv.Mileage = v.Mileage;
                sv.RentalCharge = v.RentalCharge;
                soapVehicles.Add(sv);

            }
            return soapVehicles;
        }


    }
}
