﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace VehicleRentalService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        /*
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);*/

        [OperationContract]
        List<SoapVehicle> search(string numberPlate);

        [OperationContract]
        SoapVehicle create(string numberPlate);

        [OperationContract]
        List<SoapVehicle> list();
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }

    /*
     * I tried to reuse the class VehicleX from DTOClassLibrary but IIS complained bitterly ;-)
     * So, I created a local class instead.
     */

    [DataContract]
    public class SoapVehicle
    {
        private string numberPlate;
        private int mileage;
        private double rentalCharge;
        private string vehicleType;

        [DataMember]
        public string NumberPlate
        {
            get { return numberPlate; }
            set { numberPlate = value; }
        }

        [DataMember]
        public int Mileage
        {
            get { return mileage; }
            set { mileage = value; }
        }

        [DataMember]
        public double RentalCharge
        {
            get { return rentalCharge; }
            set { rentalCharge = value; }
        }

        [DataMember]
        public string VehicleType
        {
            get { return vehicleType; }
            set { vehicleType = value; }
        }

        public override string ToString()
        {
            return "Vehicle: " + numberPlate + " of type: " + vehicleType;
        }

    }
}
