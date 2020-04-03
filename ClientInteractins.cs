using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public sealed class ClientInteractions
    {
        public enum Answer
        {
            No = 1,
            Yes
        }

        private static void yesNoMenui(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("            *********** ");
            Console.WriteLine("            * (1) {0}", Answer.No);
            Console.WriteLine("            * (2) {0}", Answer.Yes);
            Console.WriteLine("            ***********{0}", Environment.NewLine);
            Console.Write("=> Select Option: ");
        }

        private static void vehicleStatusInputMessage()
        {
            VehicleUI.VehicleStatusLabel();
            VehicleUI.VehicleStatusOptionsInstuctionMessage();
            Console.Write("=> Insert Vehicle Status: ");
        }

        private static void fuelAmountToAdd()
        {
            Console.Write("=> Insert Fule Amount To TankeUp In Litters: ");
        }

        private static void minutesToChargeBatteryInputMessage()
        {
            Console.Write("=> Insert Time To Charge Battery In Minutes: ");
        }

        public void ShowClientServies(GarageMangerUI.ClientCommand i_ClientCommand)
        {
            Console.Clear();
            Console.WriteLine("Service: {0}", i_ClientCommand);
        }

        public float GetFuelAmountToAdd(float i_MaxAmountYouCanAdd)
        {
            float fuelAmount = 0;
            fuelAmountToAdd();
            string fuelAmountString = Console.ReadLine();
            try
            {
                fuelAmount = float.Parse(fuelAmountString);
                if (fuelAmount > i_MaxAmountYouCanAdd || fuelAmount < 0)
                {
                    throw new ValueOutOfRangeException(i_MaxAmountYouCanAdd, 0);
                }
            }
            catch(FormatException)
            {
                Console.WriteLine("Fuel Amount Is a Number");
                fuelAmount = GetFuelAmountToAdd(i_MaxAmountYouCanAdd);
            }
            catch(ValueOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                fuelAmount = GetFuelAmountToAdd(i_MaxAmountYouCanAdd);
            }

            return fuelAmount;
        }

        public float GetMinutesToChargeBattery(float i_MaxTimeYouCanAdd)
        {
            float chargeTime = 0;
            minutesToChargeBatteryInputMessage();
            string chargeTimeSting = Console.ReadLine();
            try
            {
                chargeTime = float.Parse(chargeTimeSting);
                chargeTime /= 60;
                if (chargeTime > i_MaxTimeYouCanAdd || chargeTime < 0)
                {
                    throw new ValueOutOfRangeException(i_MaxTimeYouCanAdd * 60, 0);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Bad Input Charge Time Should be a Number {0}", Environment.NewLine);
                chargeTime = GetMinutesToChargeBattery(i_MaxTimeYouCanAdd);
            }
            catch(ValueOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                chargeTime = GetMinutesToChargeBattery(i_MaxTimeYouCanAdd);
            }

            return chargeTime;
        }

        private static Answer getDecision(string message)
        {
            Answer answer = 0;
            yesNoMenui(message);
            string answerString = Console.ReadLine();
            try
            {
                checkDecision(answerString, ref answer);
            }
            catch(FormatException ex)
            {
                Console.WriteLine(ex.Message);
                answer = getDecision(message);
            }
           
            return answer;
        }

        public Answer GetFilteringVehicleLicenseDecisionLabel()
        {
             string message = string.Format("Search According to specific Vehicle Status?");
            Answer answer = getDecision(message);
            return answer;
        }

        public Vehicle.VehicleStatus GetVehicleStatus()
        {
            Vehicle.VehicleStatus newVehicleStatus = 0;
            vehicleStatusInputMessage();
            string newVehicleStatusString = Console.ReadLine();
            try
            {
                newVehicleStatus = (Vehicle.VehicleStatus)int.Parse(newVehicleStatusString);
                if(newVehicleStatus > Vehicle.VehicleStatus.Realeased || newVehicleStatus < Vehicle.VehicleStatus.InRepair)
                {
                    throw new ValueOutOfRangeException((float)Vehicle.VehicleStatus.Realeased, (float)Vehicle.VehicleStatus.InRepair);
                }
            }
            catch(FormatException)
            {
                Console.WriteLine("Bad Selction Chose One Option (1-3){0}", Environment.NewLine);
                newVehicleStatus = GetVehicleStatus();
            }
            catch(ValueOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                newVehicleStatus = GetVehicleStatus();
            }

            return newVehicleStatus;
        }

        public bool GetCargoDangerousMaterials(string message)
        {
            bool dangerousMaterials = false;
            Answer answer = getDecision(message);
            if (answer == ClientInteractions.Answer.Yes)
            {
                dangerousMaterials = true;
            }

            return dangerousMaterials;
        }

        private static void checkDecision(string i_DecisionStringFormat, ref Answer io_Answer)
        {
            if (i_DecisionStringFormat != "1" && i_DecisionStringFormat != "2")
            {
                throw new FormatException(string.Format("Bad Input Chose one Number From (1-2) {0}", Environment.NewLine));
            }

            io_Answer = (Answer)int.Parse(i_DecisionStringFormat);
        }
    }
}