using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        public enum LicenseType
        {
            A = 1,
            A1,
            AB,
            B1
        }

        private int m_EngineCapacity;
        private LicenseType m_LicenseType;

        public Motorcycle(
            ref Client i_Owner,
            VehicleType i_Type,
            string i_ModelName,
            string i_LicenseNumber,
            ref EnergySystem i_EnergySystem,
            short i_WheelsNumber,
            ref List<Wheel> i_VehicleWheels,
            int i_EngineCapacity,
            LicenseType i_LicenseType) :
            base(ref i_Owner, i_Type, i_ModelName, i_LicenseNumber, ref i_EnergySystem, i_WheelsNumber, ref i_VehicleWheels)
        {
            this.m_EngineCapacity = i_EngineCapacity;
            this.m_LicenseType = i_LicenseType;
        }

        public int EngineCapacity
        {
            get { return this.m_EngineCapacity; }
            set { this.m_EngineCapacity = value; }
        }

        public LicenseType LicenseTypee
        {
            get { return this.m_LicenseType; }
            set { this.m_LicenseType = value; }
        }

        public override string ToString()
        {
            string generalInformation = base.ToString();
            string motorcycleInformation = string.Format(
                "     ******************  Additional Information  ********************{0}" +
                                                  "     *    EngineCapacity: {1}{0}" +
                                                  "     *    LicenseType: {2}{0}" +
                                                  "     ****************************************************************{0}",
                                                  Environment.NewLine, 
                                                  m_EngineCapacity, 
                                                  m_LicenseType);
            return generalInformation + motorcycleInformation;
        }
    }
}
