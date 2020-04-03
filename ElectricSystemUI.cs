using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public static class ElectricSystemUI
    {
        public static EnergySystem GetElectricSystem(Vehicle.VehicleType i_VehicleType)
        {
            batteryInformationLable();
            EnergySystem energySystem = new ElectricSystem(
                getMaximumBatteryWorkingTime2(i_VehicleType), 
                getCurrentBatteryStorage(getMaximumBatteryWorkingTime2(i_VehicleType)));
            return energySystem;
        }

        private static void batteryInformationLable()
        {
            Console.WriteLine();
            Console.WriteLine("-----------------------");
            Console.WriteLine("| Battery Information |");
            Console.WriteLine("-----------------------{0}", Environment.NewLine);
        }

        private static void currentBatteryWorkingTimeInputMessage()
        {
            Console.Write("=> Insert Current Battery Storage In Hours: ");
        }

        private static float getCurrentBatteryStorage(float i_MaxBatteryTime)
        {
            float currentBatteryStorage = 0;
            currentBatteryWorkingTimeInputMessage();

            string currentBatteryStorageStringFormat = Console.ReadLine();
            try
            {
                currentBatteryStorage = float.Parse(currentBatteryStorageStringFormat);
                if(currentBatteryStorage > i_MaxBatteryTime)
                {
                    throw new ValueOutOfRangeException(i_MaxBatteryTime, 0);
                }
            }
            catch(FormatException)
            {
                Console.WriteLine("Current Battery Storage Should be A number");
                currentBatteryStorage = getCurrentBatteryStorage(i_MaxBatteryTime);
            }
            catch(ValueOutOfRangeException ex)
            {
                Console.WriteLine("Current Battery Storage Should be Between {0} to {1}", ex.MinValue, ex.MaxValue);
                currentBatteryStorage = getCurrentBatteryStorage(i_MaxBatteryTime);
            }

            return currentBatteryStorage;
        }

        private static float getMaximumBatteryWorkingTime2(Vehicle.VehicleType i_VehicleType)
        {
            float maximumBatteryWorkingTime;
            if (i_VehicleType == Vehicle.VehicleType.Car)
            {
                maximumBatteryWorkingTime = InputInstructions.CarMaxBatteryTime;
            }
            else
            {
                maximumBatteryWorkingTime = InputInstructions.MotorcycleMaxBatteryTime;
            }

            return maximumBatteryWorkingTime;
        }
    }
}
