using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public static class GarageMangerUI
    {
        public enum ClientCommand
        {
            EnterVehicleToGarage = 1,
            ShowAllLicense,
            ChangeVehicleStatus,
            InflateWheels,
            TankeUpFuelVehicle,
            ChargeElectricVehicle,
            ShowVehicleData,
            Exit
        }

        public static Garage CreateNewGarage()
        {
            return new Garage();
        }

        public static void StartGarageWorking(ref Garage i_Garage)
        {
            ClientCommand clientCommand;
            do
            {
                showMainMenuInstructionsMessage();
                clientCommand = getClientCommand();
                executeClientCommand(clientCommand, ref i_Garage);
            }
            while (clientCommand != ClientCommand.Exit);
        }

        private static void showMainMenuInstructionsMessage()
        {
            Console.WriteLine(
                @"{0}Select One Service From The Menu
                    1 - Enter vehicle to garage
                    2 - Show all license (Filtering according To Vehicle Status)
                    3 - Change vehicle status to Fixed or Realeased
                    4 - Inflate Wheels
                    5 - Tank up fuel vehicle
                    6 - Charge electric vehicle
                    7 - Show vehicle data
                    8 - Exit",
                    Environment.NewLine);
            Console.Write("=> Select one of the options:");
        }

        private static ClientCommand getClientCommand()
        {
            ClientCommand command = 0;
            string commandStringFormat = Console.ReadLine();
            try
            {
                command = (ClientCommand)int.Parse(commandStringFormat);
                if(command > ClientCommand.Exit || command < ClientCommand.EnterVehicleToGarage)
                {
                    throw new ValueOutOfRangeException((float)ClientCommand.Exit, (float)ClientCommand.EnterVehicleToGarage);
                }
            }
            catch(FormatException)
            {
                Console.WriteLine("Bad Service Selection");
                showMainMenuInstructionsMessage();
                command = getClientCommand();
            }
            catch(ValueOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                showMainMenuInstructionsMessage();
                command = getClientCommand();
            }

            return command;
        }

        private static void executeClientCommand(ClientCommand i_Command, ref Garage i_Garage)
        {
            GarageServicesUI garageServices = new GarageServicesUI();
            ClientInteractions clientInteractions = new ClientInteractions();
            Vehicle wantedVehicle = null;
            clientInteractions.ShowClientServies(i_Command);
            if (i_Command == ClientCommand.EnterVehicleToGarage)
            {
                garageServices.AddNewVehicleToGarage(ref i_Garage);
            }
            else if(i_Command == ClientCommand.ShowAllLicense)
            {
                garageServices.ShowVehiclseLicense(ref i_Garage);
            }
            else if (i_Command == ClientCommand.ChangeVehicleStatus)
            {
                wantedVehicle = getWantedVehicle(ref i_Garage);
                garageServices.ChangeVehicleStatus(ref wantedVehicle);
            }
            else if (i_Command == ClientCommand.InflateWheels)
            {
                wantedVehicle = getWantedVehicle(ref i_Garage);
                garageServices.InflateVehicleWheels(ref wantedVehicle);
            }
            else if (i_Command == ClientCommand.TankeUpFuelVehicle)
            {
                wantedVehicle = getWantedVehicle(ref i_Garage);
                garageServices.TankeUpFuelVehicle(ref wantedVehicle);
            }
            else if(i_Command == ClientCommand.ChargeElectricVehicle)
            {
                wantedVehicle = getWantedVehicle(ref i_Garage);
                garageServices.ChargeElectricVehicle(ref wantedVehicle);
            }
            else if (i_Command == ClientCommand.ShowVehicleData)
            {
                wantedVehicle = getWantedVehicle(ref i_Garage);
                garageServices.ShowVehicleData(ref wantedVehicle);
            }
            else if(i_Command == ClientCommand.Exit)
            {
                Console.WriteLine("Good Bye");
            }
        }

        private static Vehicle getWantedVehicle(ref Garage i_Garage)
        {
            Vehicle wantedVehicle = null;
            string licenceNumber = VehicleUI.GetVehicleLicenseNumber();
            if (i_Garage.GarageDataBase.ContainsKey(licenceNumber))
            {
                Folder wantedFolder;
                i_Garage.GarageDataBase.TryGetValue(licenceNumber, out wantedFolder);
                wantedVehicle = wantedFolder.FolderSubject;
            }

            return wantedVehicle;
        }
    }
}
