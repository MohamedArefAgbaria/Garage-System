using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public static class WheelUI
    {
        public static Wheel GetOneWheel(int i_WheelNumber, Vehicle.VehicleType i_VehicleType)
        {
            wheelNumberLabel(i_WheelNumber); 
            return new Wheel(getManufacturerName(), getMaximumAirPressure2(i_VehicleType), getCurrentAirPressure(getMaximumAirPressure2(i_VehicleType)));
        }

        private static void wheelNumberLabel(int i_WheelNumber)
        {
            Console.Clear();
            Console.WriteLine("{0}--------------------------", Environment.NewLine);
            Console.WriteLine("| Wheel Number {0} Details |", i_WheelNumber);
            Console.WriteLine("--------------------------{0}", Environment.NewLine); 
        }
          
        private static void manufacturerNameInputMessage()
        {
            Console.Write("=> Insert Manufacturer Name: ");
        }

        private static void currentAirPressureInputMessage()
        {
            Console.Write("=> Insert Current Air Pressure: ");
        }

        private static string getManufacturerName()
        {
            manufacturerNameInputMessage();
            string manufacturerName = Console.ReadLine();
            return manufacturerName;
        }

        private static float getMaximumAirPressure2(Vehicle.VehicleType i_VehicleType)
        {
            float maximumAirPressure;
            if(i_VehicleType == Vehicle.VehicleType.Car)
            {
                maximumAirPressure = InputInstructions.MaxCarWheelAirPressure;
            }
            else if(i_VehicleType == Vehicle.VehicleType.Motorcycle)
            {
                maximumAirPressure = InputInstructions.MaxMotorcycleAirPressure;
            }
            else
            {
                maximumAirPressure = InputInstructions.MaxTruckAirPressure;
            }

            return maximumAirPressure;
        }

        private static float getCurrentAirPressure(float i_MaxAirPressure)
        {
            float currentAirPressure = 0;
            currentAirPressureInputMessage();
            string currentAirPressureStringFormat = Console.ReadLine();
            try
            {
                currentAirPressure = float.Parse(currentAirPressureStringFormat);
                if (currentAirPressure > i_MaxAirPressure || currentAirPressure < 0)
                {
                    throw new ValueOutOfRangeException(i_MaxAirPressure, 0);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Current Air Pressure should be a number {0}", Environment.NewLine);
                currentAirPressure = getCurrentAirPressure(i_MaxAirPressure);
            }
            catch(ValueOutOfRangeException ex)
            {
                Console.WriteLine("Current Air Pressure should be Between {0} to {1} {2}", ex.MinValue, ex.MaxValue, Environment.NewLine);
                currentAirPressure = getCurrentAirPressure(i_MaxAirPressure);
            }

            return currentAirPressure;
        }
    }
}
