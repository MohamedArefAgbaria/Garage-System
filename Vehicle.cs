using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        public enum VehicleStatus
        {
            InRepair = 1,
            Fixed,
            Realeased
        }

        public enum VehicleType
        {
            Motorcycle = 1,
            Car,
            Truck
        }

        protected Client m_Owner;
        protected VehicleType m_Type;
        protected string m_ModelName;
        protected string m_LicenseNumber;
        protected List<Wheel> m_Wheels;
        protected EnergySystem m_EnergySystem;
        protected readonly short r_WheelsNumber; // System Auto Value 
        protected VehicleStatus m_Status; // at beggining InRepair
        protected float m_PercentageOfRemainingEnergy; // calculate

        public Vehicle(
            ref Client i_Owner, 
            VehicleType i_Type, 
            string i_ModelName, 
            string i_LicenseNumber, 
            ref EnergySystem i_EnergySystem, 
            short i_wheelsNumber,
            ref List<Wheel> i_Wheels)
        {
            this.m_Owner = i_Owner;
            this.m_Type = i_Type;
            this.m_Status = VehicleStatus.InRepair;
            this.m_EnergySystem = i_EnergySystem;
            this.m_ModelName = i_ModelName;
            this.m_LicenseNumber = i_LicenseNumber;
            this.r_WheelsNumber = i_wheelsNumber;
            this.m_PercentageOfRemainingEnergy = calculatePercentageOfRemainingEnergy(); 
            this.m_Wheels = i_Wheels;
        }

        public string ModelName
        {
            get { return this.m_ModelName; }
            set { this.m_ModelName = value; }
        }

        public string LicenseNumber
        {
            get { return this.m_LicenseNumber; }
            set { this.m_LicenseNumber = value; }
        }

        public float PercentageOfRemainingEnergy
        {
            get { return this.m_PercentageOfRemainingEnergy; }
            set { this.m_PercentageOfRemainingEnergy = value; }
        }

        public short WheelsNumber
        {
            get { return this.r_WheelsNumber; }
        }

        public VehicleStatus Status
        {
            get { return this.m_Status; }
            set { this.m_Status = value; }
        }

        public List<Wheel> Wheels
        {
            get { return this.m_Wheels; }
        }

        public EnergySystem EnergySystem
        {
            get { return this.m_EnergySystem; }
        }

        private float calculatePercentageOfRemainingEnergy()
        {
            return (this.m_EnergySystem.CurrentEnergyStorage / this.m_EnergySystem.MaximumEnergyStorage) * 100;
        }

        public void SupplyEnergy(float i_EnergyToSupply)
        {
            this.m_EnergySystem.SupplyEnergy(i_EnergyToSupply);
        }

        public override string ToString()
        {
            string vehicleInformation = 
                string.Format(
                    "     *******************  General Information  *******************{2}" +
                                                      "     *     Owner: {9}{2}" +
                                                      "     *     Owner Phone Number: {10}{2}" +
                                                      "     *     License Number: {0}{2}" +
                                                      "     *     Type: {1}{2}" +
                                                      "     *     Model: {3}{2}" +
                                                      "     *     Status: {4}{2}" +
                                                      "     *     Energy Storage {5}%{2}" +
                                                      "     *     Number Of Wheels: {8}{2}" +
                                                      "     *{2}" +
                                                      "{6}" +
                                                      "{7}",
                                                      m_LicenseNumber,
                                                      m_Type, 
                                                      Environment.NewLine,
                                                      m_ModelName, 
                                                      m_Status, 
                                                      calculatePercentageOfRemainingEnergy(), 
                                                      m_EnergySystem.ToString(), 
                                                      wheelsToString(), 
                                                      r_WheelsNumber,
                                                      m_Owner.Name,
                                                      m_Owner.PhoneNumber);
            return vehicleInformation;
        }

        private string wheelsToString()
        {                                                  
            string wheelsInformation = string.Format(
                "     *******************  Wheels Information  *********************{0}",
                Environment.NewLine);
            int wheelNumber = 1;
            foreach (Wheel wheel in m_Wheels)
            {
                wheelsInformation += string.Format(
                    "     *                   (Wheel {0} Details){1}", 
                    wheelNumber++,
                    Environment.NewLine);
                wheelsInformation += wheel.ToString(); 
            }

            return wheelsInformation;
        }
    }
}