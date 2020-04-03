using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public static class FuelSystemUI
    {
        public static EnergySystem GetFuelSystem(Vehicle.VehicleType i_VehicleType)
        {
            fuelInformationLable();
            EnergySystem energySystem = new FuelSystem(
                getAutomatedFuelType(i_VehicleType), 
                getMaximumFuelAmount(i_VehicleType), 
                getCurrentFuelAmount(getMaximumFuelAmount(i_VehicleType)));
            return energySystem;
        }

        private static void fuelInformationLable()
        {
            Console.WriteLine();
            Console.WriteLine("--------------------");
            Console.WriteLine("| Fuel Information |");
            Console.WriteLine("---------------------");
        }

        private static void fuelTypeLabel()
        {
            Console.WriteLine("{0}------------", Environment.NewLine);
            Console.WriteLine("- Fuel Type");
            Console.WriteLine("------------{0}", Environment.NewLine);
        }

        private static void fuelTypesInstructionMessage()
        {
            Console.WriteLine("            *************** ");
            Console.WriteLine("            * (1) {0}", FuelSystem.FuelType.Octan95);
            Console.WriteLine("            * (2) {0}", FuelSystem.FuelType.Octan96);
            Console.WriteLine("            * (3) {0}", FuelSystem.FuelType.Octan98);
            Console.WriteLine("            * (4) {0}", FuelSystem.FuelType.Soler);
            Console.WriteLine("            ***************{0}", Environment.NewLine);
        }

        private static void fuelTypeInputMessage()
        {
            Console.Write("=> Select Fuel Type Option: ");
        }

        private static void currentFuelAmountInputMessage()
        {
            Console.Write("=> Insert Current Fuel Amount In Liters: ");
        }

        public static FuelSystem.FuelType GetFuelTypeToAdd(FuelSystem.FuelType i_FuelType)
        {
            FuelSystem.FuelType fuelType = 0;
            fuelTypeLabel();
            fuelTypesInstructionMessage();
            fuelTypeInputMessage();
            string fuelTypeString = Console.ReadLine();
            try
            {
                fuelType = (FuelSystem.FuelType)int.Parse(fuelTypeString);
                if(fuelType > FuelSystem.FuelType.Soler || fuelType < FuelSystem.FuelType.Octan95)
                {
                    throw new ValueOutOfRangeException((float)FuelSystem.FuelType.Soler, (float)FuelSystem.FuelType.Octan95);
                }

                if(fuelType != i_FuelType)
                {
                    throw new ArgumentException();
                }
            }
            catch(FormatException)
            {
                Console.WriteLine("Bad Fuel Type Input");
                fuelType = GetFuelTypeToAdd(i_FuelType);
            }
            catch(ValueOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                fuelType = GetFuelTypeToAdd(i_FuelType);
            }
            catch(ArgumentException)
            {
                Console.WriteLine("Fuel Type Doesnot Fit To Vechicle Fuel Type");
                fuelType = GetFuelTypeToAdd(i_FuelType);
            }

            return fuelType;
        }

        private static FuelSystem.FuelType getAutomatedFuelType(Vehicle.VehicleType i_VehicleType)
        {
            FuelSystem.FuelType fuelType;
            if (i_VehicleType == Vehicle.VehicleType.Car)
            {
                fuelType = InputInstructions.CarFuelType;
            }
            else if(i_VehicleType == Vehicle.VehicleType.Motorcycle)
            {
                fuelType = InputInstructions.MotorcycleFuelType;
            }
            else
            {
                fuelType = InputInstructions.TruckFuelType;
            }

            return fuelType;      
        }

        private static float getCurrentFuelAmount(float i_MaxFuelAmount)
        {
            float currentFuelAmount = 0;
            currentFuelAmountInputMessage();
            string currentFuelAmountStringFormat = Console.ReadLine();
            try
            {
                currentFuelAmount = float.Parse(currentFuelAmountStringFormat);
                if(currentFuelAmount > i_MaxFuelAmount || currentFuelAmount < 0)
                {
                    throw new ValueOutOfRangeException(i_MaxFuelAmount, 0);
                }
            }
            catch(FormatException)
            {
                Console.WriteLine("Current Fuel Amount Should be a Number {0}", Environment.NewLine);
                currentFuelAmount = getCurrentFuelAmount(i_MaxFuelAmount);
            }
            catch(ValueOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                currentFuelAmount = getCurrentFuelAmount(i_MaxFuelAmount);
            }

            return currentFuelAmount;
        }

        private static float getMaximumFuelAmount(Vehicle.VehicleType i_VehicleType)
        {
            float maximumFuelAmount;

            if(i_VehicleType == Vehicle.VehicleType.Car)
            {
                maximumFuelAmount = InputInstructions.CarMaxTank;
            }
            else if(i_VehicleType == Vehicle.VehicleType.Motorcycle)
            {
                maximumFuelAmount = InputInstructions.MotorcycleMaxTank;
            }
            else
            {
                maximumFuelAmount = InputInstructions.TruckMaxTank;
            }

            return maximumFuelAmount;
        } 
    }
}
