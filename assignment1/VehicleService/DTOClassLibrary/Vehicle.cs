using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace DTOClassLibrary
{
    public abstract class Vehicle : DTOClassLibrary.IVehicle
    {
        private string numberPlate;
        private int mileage;
        private double rentalCharge;
        private string vehicleType;

        public virtual string NumberPlate
        {
            get { return numberPlate; }
            set { numberPlate = value; }
        }


        public virtual int Mileage
        {
            get { return mileage; }
            set { mileage = value; }
        }
        

        public virtual double RentalCharge
        {
            get { return rentalCharge; }
            set { rentalCharge = value; }
        }

        public virtual string VehicleType
        {
            get { return vehicleType; }
            set { vehicleType = value; }
        }

        public override string ToString()
        {
            return "Vehicle: " + numberPlate + " of type: " + vehicleType;
        }

        public virtual string get_basic_information()
        {
            return "Vehicle: " + numberPlate + " of type: " + vehicleType + "with mileage: " + mileage + " rental charge: " + rentalCharge;
        }
    }

    public class Vehicle4WD : Vehicle, DTOClassLibrary.IVehicle
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

        public string which_roads()
        {
            return "OffRoad: " + offRoad + " DirtRoad: " + dirtRoad + " NormalRoad: " + normalRoad;
        }

    }

    public class Vehicle2WD : Vehicle, DTOClassLibrary.IVehicle
    {
        private bool under21 = false;

        public bool Under21
        {
            get { return under21; }
            set { under21 = value; }
        }

        public string under_21()
        {
            return "Under21: " + under21;
        }

    }

    public class CamperVan : Vehicle, DTOClassLibrary.IVehicle
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

        public string get_equipment()
        {
            return "NumberBeds: " + numberBeds + " Toilet: " + toilet;
        }
    }
}
