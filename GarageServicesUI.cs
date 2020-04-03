using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public sealed class GarageServicesUI
    {
        public void AddNewVehicleToGarage(ref Garage i_Garage)
        {
            Client newClient = ClientUI.GetNewClient();
            Vehicle newVehicle = VehicleUI.GetNewVehicle(ref newClient, ref i_Garage);
            if (newVehicle != null)
            {
                Folder newFolder = new Folder(ref newClient, ref newVehicle);
                i_Garage.GarageDataBase.Add(newVehicle.LicenseNumber, newFolder);
                Console.WriteLine("Vehicle Added To Garage successfully");
            }
        }

        public void ShowVehiclseLicense(ref Garage i_Garage)
        {
            if (i_Garage.IsEmpty())
            {
                Console.WriteLine("Garage is Empty No Vehicle In The Garage");
            }
            else
            {
                ClientInteractions clientInteractions = new ClientInteractions();
                ClientInteractions.Answer i_WithFilltering = clientInteractions.GetFilteringVehicleLicenseDecisionLabel();
                int leLicenseCounter = 1;
                if (i_WithFilltering == ClientInteractions.Answer.Yes)
                { 
                    Vehicle.VehicleStatus fillteringVehicleStatus = clientInteractions.GetVehicleStatus();
                    foreach (string leLicenseNumber in i_Garage.GarageDataBase.Keys)
                    {
                        Folder folder;
                        i_Garage.GarageDataBase.TryGetValue(leLicenseNumber, out folder);
                        if (fillteringVehicleStatus == folder.FolderSubject.Status)
                        {
                            Console.WriteLine("({0}) {1}", leLicenseCounter++, leLicenseNumber);
                        }
                    }

                    if(leLicenseCounter == 1)
                    {
                        Console.WriteLine("There Are No Vehicle In The Garage With Status: {0} ", fillteringVehicleStatus);
                    }
                }
                else
                {
                    foreach (string leLicenseNumber in i_Garage.GarageDataBase.Keys)
                    {
                        Console.WriteLine("({0}) {1}", leLicenseCounter++, leLicenseNumber);
                    }
                }
            }
        }

        public void ChangeVehicleStatus(ref Vehicle i_Vehicle)
        {
            if (i_Vehicle != null)
            {
                ClientInteractions clientInteractions = new ClientInteractions();
                Vehicle.VehicleStatus newVehicleStatus = clientInteractions.GetVehicleStatus();
                i_Vehicle.Status = newVehicleStatus;
                Console.WriteLine("Vehicle Status Changed To {0} successfully", i_Vehicle.Status);
            }
            else
            {
                Console.WriteLine("License Number Is Not Existing");
            }
        }

        public void InflateVehicleWheels(ref Vehicle i_Vehicle)
        {
            if (i_Vehicle != null)
            {
                foreach (Wheel wheel in i_Vehicle.Wheels)
                {
                    wheel.Inflate(wheel.MaximumAirPressure - wheel.CurrentAirPressure);
                }

                Console.WriteLine("Wheels Inflated successfully");
            }
            else
            {
                Console.WriteLine("License Number Is Not Existing");
            }
        }

        public void TankeUpFuelVehicle(ref Vehicle i_Vehicle)
        {
            if (i_Vehicle != null)
            {
                if (i_Vehicle.EnergySystem is FuelSystem)
                {
                    if (i_Vehicle.EnergySystem.MaximumEnergyStorage == i_Vehicle.EnergySystem.CurrentEnergyStorage)
                    {
                        Console.WriteLine("Fuel Tank is Full");
                    }
                    else
                    {
                        ClientInteractions clientInteractions = new ClientInteractions();
                        float fuelAmount = clientInteractions.GetFuelAmountToAdd(i_Vehicle.EnergySystem.MaximumEnergyStorage - i_Vehicle.EnergySystem.CurrentEnergyStorage);
                        FuelSystem.FuelType fuelType = FuelSystemUI.GetFuelTypeToAdd((i_Vehicle.EnergySystem as FuelSystem).VehicleFuelType);
                        (i_Vehicle.EnergySystem as FuelSystem).SupplyEnergy(fuelAmount, fuelType);
                        Console.WriteLine("Added {0} Liters To Tank successfully", fuelAmount);
                    }
                }
                else
                {
                    Console.WriteLine("Energy system Is Inappropriate");
                }
            }
            else
            {
                Console.WriteLine("License Number Is Not Existing");
            }
        }

        public void ChargeElectricVehicle(ref Vehicle i_Vehicle)
        {
            if(i_Vehicle != null)
            {
                if (i_Vehicle.EnergySystem is ElectricSystem)
                {
                    if (i_Vehicle.EnergySystem.MaximumEnergyStorage == i_Vehicle.EnergySystem.CurrentEnergyStorage)
                    {
                        Console.WriteLine("Battery Is Full");
                    }
                    else
                    {
                        ClientInteractions clientInteractions = new ClientInteractions();
                        float timeToCharge = clientInteractions.GetMinutesToChargeBattery(i_Vehicle.EnergySystem.MaximumEnergyStorage - i_Vehicle.EnergySystem.CurrentEnergyStorage);
                        (i_Vehicle.EnergySystem as EnergySystem).SupplyEnergy(timeToCharge);
                        Console.WriteLine("Battery Charger in {0} Hours successfully", timeToCharge);
                    }
                }
                else
                {
                    Console.WriteLine("Energy system Is Inappropriate");
                }
            }
            else
            {
                Console.WriteLine("License Number Is Not Existing");
            }
        }

        public void ShowVehicleData(ref Vehicle i_Vehicle)
        {
            if (i_Vehicle != null)
            {
                Console.Clear();
                Console.WriteLine(i_Vehicle.ToString());
            }
            else
            {
                Console.WriteLine("License Number Is Not Existing");
            }
        }
    }
}
