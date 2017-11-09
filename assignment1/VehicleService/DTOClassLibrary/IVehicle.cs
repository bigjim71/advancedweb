using System;
namespace DTOClassLibrary
{
    interface IVehicle
    {
        int Mileage { get; set; }
        string NumberPlate { get; set; }
        double RentalCharge { get; set; }
    }
}
