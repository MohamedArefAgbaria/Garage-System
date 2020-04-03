using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public static class TruckUI
    {
        public static Vehicle GetNewTruck(
          ref Client i_Owner,
          Vehicle.VehicleType i_VehicleType,
          string i_VehicleModel,
          string i_VehicleLicenseNumber,
          ref EnergySystem i_VehicleEnergySystem,
          short i_WheelsNumber,
          ref List<Wheel> i_VehicleWheels)
        {
            additionalTruckInformationLabel();
            return CreateNewVehicle.CreatNewTruck(
                ref i_Owner,
                i_VehicleType,
                i_VehicleModel,
                i_VehicleLicenseNumber,
                ref i_VehicleEnergySystem,
                i_WheelsNumber,
                ref i_VehicleWheels,
                getcargoVolume(),
                cargoDangerousMaterials());
        }

        private static void additionalTruckInformationLabel()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("--------------------------------");
            Console.WriteLine("| Additional {0} Information |", Vehicle.VehicleType.Truck);
            Console.WriteLine("---------------------------------");
        }

        private static void cargoVolumeLabel()
        {
            Console.WriteLine("{0}--------------", Environment.NewLine);
            Console.WriteLine("- Cargo Volume");
            Console.WriteLine("---------------{0}", Environment.NewLine);
        }

        public static void cargoDangerousMaterialsLabel()
        {
            Console.WriteLine("{0}---------------------", Environment.NewLine);
            Console.WriteLine("- Cargo Dangerous Materials");
            Console.WriteLine("-----------------------{0}", Environment.NewLine);
        }

        private static void cargoVolumeInputMessage()
        {
            Console.Write("=> Insert cargo Volume in Kg: ");
        }

        private static float getcargoVolume()
        {
            float cargoVolume = 0;
            cargoVolumeLabel();
            cargoVolumeInputMessage();
            string cargoVolumeString = Console.ReadLine();
            try
            {
                cargoVolume = float.Parse(cargoVolumeString);
                if(cargoVolume > InputInstructions.TruckMaxCargoVolume || cargoVolume < 0)
                {
                    throw new ValueOutOfRangeException(InputInstructions.TruckMaxCargoVolume, 0);    
                }
            }
            catch(FormatException)
            {
                Console.WriteLine("Cargo Valume Should be a number {0}", Environment.NewLine);
                cargoVolume = getcargoVolume();
            }
            catch(ValueOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                cargoVolume = getcargoVolume();
            }

            return cargoVolume;
        }

        private static bool cargoDangerousMaterials()
        {
            string message = string.Format("{0}---------------------{0}- Cargo Dangerous Materials{0}-----------------------{0}", Environment.NewLine);
            ClientInteractions clientInteractions = new ClientInteractions();
            return clientInteractions.GetCargoDangerousMaterials(message);
        }
    }
}
