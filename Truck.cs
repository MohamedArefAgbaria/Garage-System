using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private float m_CargoVolume;
        private bool m_CargoDangerousMaterials;

        public Truck(
            ref Client i_Owner, 
            VehicleType i_Type, 
            string i_ModelName,
            string i_LicenseNumber, 
            ref EnergySystem i_EnergySystem, 
            short i_WheelsNumber,
            ref List<Wheel> i_VehicleWheels, 
            float i_CargoVolume, 
            bool i_CargoDangerousMaterials) :
            base(ref i_Owner, i_Type, i_ModelName, i_LicenseNumber, ref i_EnergySystem, i_WheelsNumber, ref i_VehicleWheels)
        {
            this.m_CargoVolume = i_CargoVolume;
            this.m_CargoDangerousMaterials = i_CargoDangerousMaterials;
        }

        public float CargoVolume
        {
            get { return this.m_CargoVolume; }
            set { this.m_CargoVolume = value; }
        }

        public bool CargoDangerousMaterials
        {
            get { return this.m_CargoDangerousMaterials; }
            set { this.m_CargoDangerousMaterials = value; }
        }

        public override string ToString()
        {
            string generalInformation = base.ToString();
            string carInformation = string.Format(
                "     ******************  Additional Information  ********************{0}" +
                                                  "     *    CargoVolume: {1} Kg{0}" +
                                                  "     *    Cargo Dangerous Materials: {2}{0}" +
                                                  "     ****************************************************************{0}",
                                                  Environment.NewLine, 
                                                  m_CargoVolume,
                                                  cargoDangerousMaterialsTostring(m_CargoDangerousMaterials));
            return generalInformation + carInformation;
        }

        private static string cargoDangerousMaterialsTostring(bool i_CargoDangerousMaterials)
        {
            string answer;
            if(i_CargoDangerousMaterials)
            {
                answer = "Yes";
            }
            else
            {
                answer = "No";
            }

            return answer;
        }
    }
}
