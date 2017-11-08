using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

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

        public string search(string numberPlate)
        {
            //fetch from database
            return string.Format("You entered: {0}", numberPlate);
        }

        public void create()
        {
            //create new vehicle
            //insert into db
        }

        public string list()
        {
            //fetch all vehicles from db
            return "vehicles list";
        }


    }
}
