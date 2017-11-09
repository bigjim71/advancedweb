using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VehicleDBApplication
{
    public abstract class Vehicle : VehicleDBApplication.IVehicle
    {
        private string numberPlate;
        private int mileage;
        private double rentalCharge;
        private string vehicleType;

        public string NumberPlate
        {
            get { return numberPlate; }
            set { numberPlate = value; }
        }


        public int Mileage
        {
            get { return mileage; }
            set { mileage = value; }
        }
        

        public double RentalCharge
        {
            get { return rentalCharge; }
            set { rentalCharge = value; }
        }

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

    public class Vehicle4WD : Vehicle, VehicleDBApplication.IVehicle
    {
        private bool offRoad = false;
        private bool dirtRoad = true;
        private bool normalRoad = true;

        public bool OffRoad
        {
            get { return offRoad; }
            set { offRoad = value; }
        }
        

        public bool DirtRoad
        {
            get { return dirtRoad; }
            set { dirtRoad = value; }
        }
        

        public bool NormalRoad
        {
            get { return normalRoad; }
            set { normalRoad = value; }
        }


    }

    public class Vehicle2WD : Vehicle, VehicleDBApplication.IVehicle
    {
        private bool under21 = false;

        public bool Under21
        {
            get { return under21; }
            set { under21 = value; }
        }

    }

    public class CamperVan : Vehicle, VehicleDBApplication.IVehicle
    {
        private int numberBeds;
        private bool toilet;

        public int NumberBeds
        {
            get { return numberBeds; }
            set { numberBeds = value; }
        }

        public bool Toilet
        {
            get { return toilet; }
            set { toilet = value; }
        }


    }
}
