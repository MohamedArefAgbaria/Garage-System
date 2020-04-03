using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public static class InputInstructions
    {
        private const ushort k_PhoneNumberLength = 10;
        private const ushort k_LicenseNumberLenght = 8;
        private const short k_CarWheelsNumber = 4;
        private const short k_MotorcycleWheelsNumber = 2;
        private const short k_TruckWheelsNumber = 16; 
        private const short K_MaxCarWheelAirPressure = 30;
        private const short k_MaxMotorcycleAirPressure = 28;
        private const short k_MaxTruckAirPressure = 26;
        private const FuelSystem.FuelType k_CarFuelType = FuelSystem.FuelType.Octan96;
        private const FuelSystem.FuelType k_MotorcycleFuelType = FuelSystem.FuelType.Octan95;
        private const FuelSystem.FuelType k_TruckFuelType = FuelSystem.FuelType.Soler;
        private const float k_CarMaxTanke = 42;
        private const float k_MotorcycleMaxTank = 5.5f;
        private const float k_TruckMaxTank = 120;
        private const float k_MotorcycleMaxBatteryTime = 1.6f;
        private const float k_CarMaxBatteryTime = 2.5f;
        private const int k_MotorcycleEngineMaxCapacity = 1000;
        private const float k_TruckMaxCargoVolume = 2000000;

        public static ushort PhoneNumberLength
        {
            get { return k_PhoneNumberLength; }
        }

        public static ushort LicenseNumberLength
        {
            get { return k_LicenseNumberLenght; }
        }

        public static short CarWheelsNumber
        {
            get { return k_CarWheelsNumber; }
        }

        public static short MotorcycleWheelsNumber
        {
            get { return k_MotorcycleWheelsNumber; }
        }

        public static short TruckWheelNumber
        {
            get { return k_TruckWheelsNumber; }
        }

        public static short MaxCarWheelAirPressure
        {
            get { return K_MaxCarWheelAirPressure; }
        }

        public static short MaxMotorcycleAirPressure
        {
            get { return k_MaxMotorcycleAirPressure; }
        }

        public static short MaxTruckAirPressure
        {
            get { return k_MaxTruckAirPressure; }
        }

        public static FuelSystem.FuelType CarFuelType
        {
            get { return k_CarFuelType; }
        }

        public static FuelSystem.FuelType MotorcycleFuelType
        {
            get { return k_MotorcycleFuelType; }
        }

        public static FuelSystem.FuelType TruckFuelType
        {
            get { return k_TruckFuelType; }
        }

        public static float CarMaxTank
        {
            get { return k_CarMaxTanke; }
        }

        public static float MotorcycleMaxTank
        {
            get { return k_MotorcycleMaxTank; }
        }

        public static float TruckMaxTank
        {
            get { return k_TruckMaxTank; }
        }

        public static float MotorcycleMaxBatteryTime
        {
            get { return k_MotorcycleMaxBatteryTime; }
        }

        public static float CarMaxBatteryTime
        {
            get { return k_CarMaxBatteryTime; }
        }

        public static int MotorcycleEngineMaxCapacity
        {
            get { return k_MotorcycleEngineMaxCapacity; }
        }

        public static float TruckMaxCargoVolume
        {
            get { return k_TruckMaxCargoVolume; }
        }
    }
}
