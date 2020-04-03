using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public static class MotorcycleUI
    {
        public static Vehicle GetNewMotorcycle(
           ref Client i_Owner,
           Vehicle.VehicleType i_VehicleType,
           string i_VehicleModel,
           string i_VehicleLicenseNumber,
           ref EnergySystem i_VehicleEnergySystem,
           short i_WheelsNumber,
           ref List<Wheel> i_VehicleWheels)
        {
            additionalMotorcycleInformationLabel();
            return CreateNewVehicle.CreateNewMotorcycle(
                ref i_Owner,
                i_VehicleType,
                i_VehicleModel,
                i_VehicleLicenseNumber,
                ref i_VehicleEnergySystem,
                i_WheelsNumber,
                ref i_VehicleWheels,
                getEngineCapacity(),
                getLicenseType());
        }

        private static void additionalMotorcycleInformationLabel()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("| Additional {0} Information |", Vehicle.VehicleType.Motorcycle);
            Console.WriteLine("-------------------------------------");
        }

        private static void engineCapacityLabel()
        {
            Console.WriteLine("{0}-----------------", Environment.NewLine);
            Console.WriteLine("- Engine Capacity");
            Console.WriteLine("-----------------{0}", Environment.NewLine);
        }

        private static void licenseTypeLabel()
        {
            Console.WriteLine("{0}---------------", Environment.NewLine);
            Console.WriteLine("- License Type");
            Console.WriteLine("---------------{0}", Environment.NewLine);
        }

        private static void licenseTypeInstructionMessage()
        {
            Console.WriteLine("            *************** ");
            Console.WriteLine("            * (1) {0}", Motorcycle.LicenseType.A);
            Console.WriteLine("            * (2) {0}", Motorcycle.LicenseType.A1);
            Console.WriteLine("            * (3) {0}", Motorcycle.LicenseType.AB);
            Console.WriteLine("            * (4) {0}", Motorcycle.LicenseType.B1);
            Console.WriteLine("            ***************{0}", Environment.NewLine);
        }

        private static void engineCapacityInputMessage()
        {
            Console.Write("=> Insert Engine Capacity: ");
        }

        private static void licenseTypeInputMessage()
        {
            Console.Write("=> Select License Type Option: ");
        }

        private static int getEngineCapacity()
        {
            int engineCapacity = 0;
            engineCapacityLabel();
            engineCapacityInputMessage();
            string engineCapacityString = Console.ReadLine();
            try
            {
                engineCapacity = int.Parse(engineCapacityString);
                if (engineCapacity > InputInstructions.MotorcycleEngineMaxCapacity || engineCapacity < 0)
                {
                    throw new ValueOutOfRangeException(InputInstructions.MotorcycleEngineMaxCapacity, 50);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Engine Capacite should be a number {0}", Environment.NewLine);
                engineCapacity = getEngineCapacity();
            }
            catch(ValueOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                engineCapacity = getEngineCapacity();
            }

            return engineCapacity;
        }

        private static Motorcycle.LicenseType getLicenseType()
        {
            Motorcycle.LicenseType licenseType = 0;
            licenseTypeLabel();
            licenseTypeInstructionMessage();
            licenseTypeInputMessage();
            string licenseTypeStringFormat = Console.ReadLine();
            try
            {
                checkLicenseType(licenseTypeStringFormat, ref licenseType);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                licenseType = getLicenseType();
            }

            return licenseType;
        }

        private static void checkLicenseType(string i_licenseTypeStringFormat, ref Motorcycle.LicenseType io_LicenseType)
        {
            if (i_licenseTypeStringFormat != "1" && i_licenseTypeStringFormat != "2"
                && i_licenseTypeStringFormat != "3" && i_licenseTypeStringFormat != "4")
            {
                throw new FormatException("Bad Input Chose one Number From (1-4)");
            }

            io_LicenseType = (Motorcycle.LicenseType)int.Parse(i_licenseTypeStringFormat);
        }
    }
}
