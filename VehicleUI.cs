using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public static class VehicleUI
    { 
        public static Vehicle GetNewVehicle(ref Client i_Client, ref Garage i_Garage)
        {
            Vehicle newVehicle = null;
            generalVehicleDetailsLabel();
            string vehicleLicenseNumber = GetVehicleLicenseNumber();
            if (i_Garage.IsVehicleFoundInGarage(vehicleLicenseNumber))
            {
                Folder folder;
                i_Garage.GarageDataBase.TryGetValue(vehicleLicenseNumber, out folder);
                folder.FolderSubject.Status = Vehicle.VehicleStatus.InRepair;
                Console.WriteLine("Vehicle License Number {0} Existing In Garage", vehicleLicenseNumber);
                Console.WriteLine("Vehicle Status Chaned to {0}", Vehicle.VehicleStatus.InRepair);
            }
            else
            {
                vehicleTypeLabel();
                vehicleTypesInstructionMessage();
                Vehicle.VehicleType vehicleType = getVehicleType();
                string vehicleModel = getVehicleModel();
                short vehicleWheelsNumber = getVehicleWheelsNumber(vehicleType);
                EnergySystem vehicleEnergySystem = EnergySystemUI.GetNewEnergySystem(vehicleType);
                List<Wheel> vehicleWheels = getVehicleWheels(vehicleWheelsNumber, vehicleType);

                if (vehicleType == Vehicle.VehicleType.Car)
                {
                    newVehicle = CarUI.GetNewCar(
                        ref i_Client,
                        vehicleType,
                        vehicleModel,
                        vehicleLicenseNumber,
                        ref vehicleEnergySystem,
                        vehicleWheelsNumber,
                        ref vehicleWheels);
                }
                else if (vehicleType == Vehicle.VehicleType.Motorcycle)
                {
                    newVehicle = MotorcycleUI.GetNewMotorcycle(
                        ref i_Client,
                        vehicleType,
                        vehicleModel,
                        vehicleLicenseNumber,
                        ref vehicleEnergySystem,
                        vehicleWheelsNumber,
                        ref vehicleWheels);
                }
                else if (vehicleType == Vehicle.VehicleType.Truck)
                {
                    newVehicle = TruckUI.GetNewTruck(
                        ref i_Client,
                        vehicleType,
                        vehicleModel,
                        vehicleLicenseNumber,
                        ref vehicleEnergySystem,
                        vehicleWheelsNumber,
                        ref vehicleWheels);
                }
                else
                {
                    Console.WriteLine("Bad Selection");
                }
            }
            
            return newVehicle;
        }

        private static void generalVehicleDetailsLabel()
        {
            Console.Clear();
            Console.WriteLine("{0}-------------------------", Environment.NewLine);
            Console.WriteLine("- General Vehicle Details");
            Console.WriteLine("-------------------------{0}", Environment.NewLine);
        }

        private static void vehicleTypeLabel()
        {
            Console.WriteLine("{0}-----------------", Environment.NewLine);
            Console.WriteLine("- Vehicle Type");
            Console.WriteLine("-----------------{0}", Environment.NewLine);
        }

        public static void VehicleStatusLabel() // public: Used In ClientInteractions class
        {
            Console.WriteLine("{0}----------------------", Environment.NewLine);
            Console.WriteLine("- Vehicle Status Options");
            Console.WriteLine("-------------------------{0}", Environment.NewLine);
        }

        private static void vehicleTypesInstructionMessage()
        {
            Console.WriteLine("            ************* ");
            Console.WriteLine("            * (1) {0}", Vehicle.VehicleType.Motorcycle);
            Console.WriteLine("            * (2) {0}", Vehicle.VehicleType.Car);
            Console.WriteLine("            * (3) {0}", Vehicle.VehicleType.Truck);
            Console.WriteLine("            *************{0}", Environment.NewLine);
        }

        public static void VehicleStatusOptionsInstuctionMessage() // public: Used In ClientInteractions class
        {   
            Console.WriteLine("            *****************");
            Console.WriteLine("            * (1) {0}", Vehicle.VehicleStatus.InRepair);
            Console.WriteLine("            * (2) {0}", Vehicle.VehicleStatus.Fixed);
            Console.WriteLine("            * (3) {0}", Vehicle.VehicleStatus.Realeased);
            Console.WriteLine("            *****************{0}", Environment.NewLine);
        }

        private static void vehicleModelInputMessage()
        {
            Console.Write("=> Insert Vehicle Model: ");
        }

        private static void licenseNumberInputMessage()
        {
            Console.Write("=> Insert License Number: ");
        }

        private static void vehicleTypeInputMessage()
        {
            Console.Write("=> Insert Vehicle Type: ");
        }

        private static Vehicle.VehicleType getVehicleType()
        {
            Vehicle.VehicleType vehicleType = 0;
            vehicleTypeInputMessage();
            string vehicleTypeStringFormat  = Console.ReadLine();
            try
            {
                checkVehicleType(vehicleTypeStringFormat, ref vehicleType);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                vehicleTypesInstructionMessage();
                vehicleType = getVehicleType();
            }

            return vehicleType;
        }

        private static string getVehicleModel()
        {
            vehicleModelInputMessage();
            return Console.ReadLine();
        }

        public static string GetVehicleLicenseNumber() // public: Used In ClientInteractions class
        {
            licenseNumberInputMessage();
            string licenseNumber = Console.ReadLine();
            try
            {
                checkLicenseNumberValidation(licenseNumber);
            }
            catch(FormatException ex)
            {
                Console.WriteLine(ex.Message);
                licenseNumber = GetVehicleLicenseNumber();
            }

            return licenseNumber;
        }

        private static short getVehicleWheelsNumber(Vehicle.VehicleType i_VehicleType)
        {
            short wheelsNumber;
            if(i_VehicleType == Vehicle.VehicleType.Motorcycle)
            {
                wheelsNumber = InputInstructions.MotorcycleWheelsNumber;
            }
            else if(i_VehicleType == Vehicle.VehicleType.Car)
            {
                wheelsNumber = InputInstructions.CarWheelsNumber;
            }
            else
            {
                wheelsNumber = InputInstructions.TruckWheelNumber;
            }

            return wheelsNumber;
        }

        private static List<Wheel> getVehicleWheels(short i_WheelsNumber, Vehicle.VehicleType i_VehicleType)
        {
            List<Wheel> vehicleWheels = new List<Wheel>();
            for (int i = 0; i < i_WheelsNumber; i++)
            {
                vehicleWheels.Add(WheelUI.GetOneWheel(i + 1, i_VehicleType));
            }

            return vehicleWheels;
        }

        private static void checkLicenseNumberValidation(string i_LicenseNumber)
        {
            foreach(char letter in i_LicenseNumber)
            {
                if (char.IsDigit(letter) == false)
                {
                    throw new FormatException(string.Format("Bad Input License Number Contain only digits {0}", Environment.NewLine));
                }
            }

            if(i_LicenseNumber.Length != InputInstructions.LicenseNumberLength)
            {
                throw new FormatException(string.Format(
                        "Bad Input License Number Consist of {0} digits {1}",
                    InputInstructions.LicenseNumberLength, 
                    Environment.NewLine));
            }                
        }

        private static void checkVehicleType(string i_VehicleTypeFormatString, ref Vehicle.VehicleType io_VehicleType)
        {
           if(i_VehicleTypeFormatString != "1" && i_VehicleTypeFormatString != "2" && i_VehicleTypeFormatString != "3")
            {
                throw new FormatException(string.Format("Bad Selection Chose One Number From (1-3) {0}", Environment.NewLine));
            }

            io_VehicleType = (Vehicle.VehicleType)int.Parse(i_VehicleTypeFormatString);
        }
    }
}
