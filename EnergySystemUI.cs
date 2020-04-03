using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class EnergySystemUI
    {
        public enum EnergySystemType
        {
            Fuel = 1,
            Electric
        }

        public static EnergySystem GetNewEnergySystem(Vehicle.VehicleType i_VehicleType)
        {
            EnergySystem energySystem;
            if (i_VehicleType != Vehicle.VehicleType.Truck)
            {
                if (getEnergySystem() == EnergySystemType.Fuel)
                {
                    energySystem = FuelSystemUI.GetFuelSystem(i_VehicleType);
                }
                else
                {
                    energySystem = ElectricSystemUI.GetElectricSystem(i_VehicleType);
                }
            }
            else
            {
                energySystem = FuelSystemUI.GetFuelSystem(i_VehicleType);
            }

            return energySystem;
        }

        private static void energySystemLabele()
        {
            Console.WriteLine("{0}---------------", Environment.NewLine);
            Console.WriteLine("- Energy System");
            Console.WriteLine("---------------{0}", Environment.NewLine);
        }

        private static void energySystemInstruction()
        {
            Console.WriteLine("            ****************");
            Console.WriteLine("            * (1) {0}", EnergySystemType.Fuel);
            Console.WriteLine("            * (2) {0}", EnergySystemType.Electric);
            Console.WriteLine("            ****************");
        }

        private static void energySystemTypeInputMessage()
        {
            Console.Write("=> Select Energy System Option: ");
        }

        private static EnergySystemType getEnergySystem()
        {
            EnergySystemType energySystemType = 0;
            energySystemLabele();
            energySystemInstruction();
            energySystemTypeInputMessage();
            string energySystemTypeStringFormat = Console.ReadLine();
            try
            {
                chekEnergySystemTypeValidation(energySystemTypeStringFormat, ref energySystemType);
            }
            catch(FormatException ex)
            {
                Console.WriteLine(ex.Message);
                energySystemType = getEnergySystem();
            }

            return energySystemType;
        }

        private static void chekEnergySystemTypeValidation(string i_EnergySystemType, ref EnergySystemType io_EnergySystem)
        {
            if(i_EnergySystemType != "1" && i_EnergySystemType != "2")
            {
                throw new FormatException("Bad Input Chose one Number (1-2)");
            }

            io_EnergySystem = (EnergySystemType)int.Parse(i_EnergySystemType);
        }
    }
}
