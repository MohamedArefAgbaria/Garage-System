using System;

namespace Ex03.GarageLogic
{
    public class ElectricSystem : EnergySystem
    {
        public ElectricSystem(float i_BatteryMaximumTimeInHours, float i_BatteryTimeRemainingInHours) : 
            base(i_BatteryTimeRemainingInHours, i_BatteryMaximumTimeInHours)
        {
        }

        public override void SupplyEnergy(float i_BatteryTimeToSupplyInHourse)
        {
            this.CurrentEnergyStorage += i_BatteryTimeToSupplyInHourse;
        }

        public override string ToString()
        {
            string batteryInformation = string.Format(
                "     *******************  Battery Information  ********************{0}" +
                                                      "     *    Maximum Battery Storage : {1} Hours{0}" +
                                                      "     *    Current Battery Storage : {2} Hours{0}" +
                                                      "     *{0}",
                                                        Environment.NewLine,
                                                        m_MaximumEnergyStorage,
                                                        m_CurrentEnergyStorage);
            return batteryInformation;
        }
    }
}
