using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VehicleDBApplication
{
    abstract class Vehicle
    {
        private string numberPlate;
        private int mileage;
        private double rentalCharge;

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
    }

    class Vehicle4WD : Vehicle
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

    class Vehicle2WD : Vehicle
    {
        private bool under21 = false;

        public bool Under21
        {
            get { return under21; }
            set { under21 = value; }
        }
    }

    class CamperVan : Vehicle
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
