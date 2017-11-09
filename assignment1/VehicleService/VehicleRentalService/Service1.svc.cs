using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using VehicleDBApplication;
using DTOClassLibrary;
using VehicleRentalService.ServiceReferenceUpper;

namespace VehicleRentalService
{
    public class Service1 : IService1
    {

        public List<SoapVehicle> search(string numberPlate)
        {


            /*
             * For some reason this isn't working.
             * It should work, as I've done the same as in the labs where it did work.
             * I've had to re-create the VehicleRentalService several times as VS screwed up some config files (impossible to figure what was wrong).
             * Project wouldn't even compile.
             * Now, at least, it compiles, but there is still the runtime error.
             * Too often the server says it's "Too busy"! I don't know why, there is only one request ??? 
             * Constantly have to restart the IDE to clear the IIS successfully.
             * 
             * Exception is:
             * There was no endpoint listening at https://campus.cs.le.ac.uk/tyche/axis2/services/UpperOperator that could accept the message. 
             * This is often caused by an incorrect address or SOAP action. See InnerException, if present, for more details.
             */
            //ServiceReferenceUpper.UpperOperatorPortTypeClient upperSvc = new ServiceReferenceUpper.UpperOperatorPortTypeClient("UpperOperatorSOAP12port_http");
            //string plate = upperSvc.upper(numberPlate);

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

            /*
             * For some reason this isn't working.
             * It should work, as I've done the same as in the labs where it did work.
             * I've had to re-create the VehicleRentalService several times as VS screwed up some config files (impossible to figure what was wrong).
             * Project wouldn't even compile.
             * Now, at least, it compiles, but there is still the runtime error.
             * Too often the server says it's "Too busy"! I don't know why, there is only one request ??? 
             * Constantly have to restart the IDE to clear the IIS successfully.
             * 
             * Exception is:
             * There was no endpoint listening at https://campus.cs.le.ac.uk/tyche/axis2/services/UpperOperator that could accept the message. 
             * This is often caused by an incorrect address or SOAP action. See InnerException, if present, for more details.
             */
            //ServiceReferenceUpper.UpperOperatorPortTypeClient upperSvc = new ServiceReferenceUpper.UpperOperatorPortTypeClient("UpperOperatorSOAP12port_http");
            //string plate = upperSvc.upper(numberPlate);

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
