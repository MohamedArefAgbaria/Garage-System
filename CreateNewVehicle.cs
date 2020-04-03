using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public static class CreateNewVehicle
    {
        public static Vehicle CreateNewCar(
           ref Client i_Owner,
           Vehicle.VehicleType i_Type,
           string i_ModelName, 
           string i_LicenseNumber, 
           ref EnergySystem i_EnergySystem, 
           short i_WheelsNumber, 
           ref List<Wheel> i_Wheels,
           Car.CarColor i_CarColor, 
           Car.CarDoors i_DoorsNumber)
        {
            return new Car(
                ref i_Owner, 
                i_Type, 
                i_ModelName, 
                i_LicenseNumber, 
                ref i_EnergySystem, 
                i_WheelsNumber,
                ref i_Wheels, 
                i_CarColor, 
                i_DoorsNumber); 
        }

        public static Motorcycle CreateNewMotorcycle(
           ref Client i_Owner,
           Vehicle.VehicleType i_Type,
           string i_ModelName,
           string i_LicenseNumber,
           ref EnergySystem i_EnergySystem,
           short i_WheelsNumber,
           ref List<Wheel> i_Wheels,
           int i_EngineCapacity,
           Motorcycle.LicenseType i_LicenseType)
        {
             return new Motorcycle(
                 ref i_Owner, 
                 i_Type, 
                 i_ModelName, 
                 i_LicenseNumber, 
                 ref i_EnergySystem,
                 i_WheelsNumber,
                 ref i_Wheels, 
                 i_EngineCapacity, 
                 i_LicenseType);
        }

        public static Truck CreatNewTruck(
           ref Client i_Owner,
           Vehicle.VehicleType i_Type,
           string i_ModelName,
           string i_LicenseNumber,
           ref EnergySystem i_EnergySystem,
           short i_WheelsNumber,
           ref List<Wheel> i_Wheels,
           float i_CargoVolume,
           bool i_CargoDangerousMaterials)
        {
            return new Truck(
                 ref i_Owner,
                 i_Type,
                 i_ModelName,
                 i_LicenseNumber,
                 ref i_EnergySystem,
                i_WheelsNumber,
                ref i_Wheels,
                i_CargoVolume,
                i_CargoDangerousMaterials);
        }
    }
}
