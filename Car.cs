using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        public enum CarColor
        {
            Yellow = 1,
            White,
            Red,
            Black
        }

        public enum CarDoors
        {
            Two = 2,
            Three,
            Four,
            Five
        }

        private CarColor m_Color;
        private CarDoors m_DoorsNumber;

        public Car(
            ref Client i_Owner, 
            VehicleType i_Type, 
            string i_ModelName, 
            string i_LicenseNumber, 
            ref EnergySystem i_EnergySystem, 
            short i_WheelsNumber,
            ref List<Wheel> i_VehicleWheels, 
            CarColor i_CarColor, 
            CarDoors i_DoorsNumber) : 
            base(ref i_Owner, i_Type, i_ModelName, i_LicenseNumber, ref i_EnergySystem, i_WheelsNumber, ref i_VehicleWheels)
        {
            this.m_Color = i_CarColor;
            this.m_DoorsNumber = i_DoorsNumber;
        }

        public CarColor Color
        {
            get { return this.m_Color; }
            set { this.m_Color = value; }
        }

        public CarDoors DoorsNumber
        {
            get { return this.m_DoorsNumber; }
            set { this.m_DoorsNumber = value; }
        }

        public override string ToString()
        {   
            string generalInformation = base.ToString();
            string carInformation = string.Format(
                "     ******************  Additional Information  ********************{0}" +
                                                  "     *    Color: {1}{0}" +
                                                  "     *    Doors Number: {2}{0}" +
                                                  "     ****************************************************************{0}",
                                                  Environment.NewLine, 
                                                  m_Color, 
                                                  m_DoorsNumber);
            return generalInformation + carInformation;
        }
    }
}
