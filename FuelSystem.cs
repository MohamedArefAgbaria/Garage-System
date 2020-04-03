using System;

namespace Ex03.GarageLogic
{
    public class FuelSystem : EnergySystem
    {
        public enum FuelType
        {
            Octan95 = 1,
            Octan96,
            Octan98,
            Soler
        }

        private FuelType m_fuelType;

        public FuelSystem(FuelType i_FuelType, float i_MaximumAmountOfFuelInLiters, float i_AmountOfCurrentFuelInLiters) :
            base(i_AmountOfCurrentFuelInLiters, i_MaximumAmountOfFuelInLiters)
        {
            this.m_fuelType = i_FuelType;
        }

        public void SupplyEnergy(float i_FuelAmountToSupplyInLiters, FuelType fuelType)
        {
            if(fuelType == this.m_fuelType)
            {
                this.CurrentEnergyStorage += i_FuelAmountToSupplyInLiters;
            }
        }

        public FuelType VehicleFuelType
        {
            get { return this.m_fuelType; }
            set { this.m_fuelType = value; }
        }

        public override string ToString()
        {
            string fuelSystemInformation = string.Format(
                "     ********************  Fuel Information  **********************{0}" +
                                                         "     *    Type: {1}{0}" +
                                                         "     *    Maximum Tank Capacity: {2} Liters{0}" +
                                                         "     *    Current Fuel Amount : {3} Liters{0}" +
                                                         "     *{0}",
                                                         Environment.NewLine, 
                                                         m_fuelType, 
                                                         m_MaximumEnergyStorage, 
                                                         m_CurrentEnergyStorage);
            return fuelSystemInformation;
        }
    }
}
