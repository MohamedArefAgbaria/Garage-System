using System;

namespace Ex03.GarageLogic
{
    public sealed class Wheel
    {
        private readonly float r_MaximumAirPressure;
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
       
        public Wheel(string i_ManufacturerName, float i_MaximumAirPressure, float i_CurrentAirPressure)
        {
            this.m_ManufacturerName = i_ManufacturerName;
            this.r_MaximumAirPressure = i_MaximumAirPressure;
            this.m_CurrentAirPressure = i_CurrentAirPressure;
        }

        public string ManufacturerName
        {
            get { return this.m_ManufacturerName; }
            set { this.m_ManufacturerName = value; }
        }

        public float CurrentAirPressure
        {
            get { return this.m_CurrentAirPressure; }
            set { this.m_CurrentAirPressure = value; }
        }

        public float MaximumAirPressure
        {
            get { return this.r_MaximumAirPressure; }
        }

        public void Inflate(float i_HowManyAirToAddToWheel)
        {
            this.m_CurrentAirPressure += i_HowManyAirToAddToWheel;
        }

        public override string ToString()
        {
            string wheelInformation = string.Format(
                "     *    Manufactur: {0}{1}" +
                                                    "     *    Maximum Air Pressure: {2} PSI{1}" +
                                                    "     *    Current Air Pressure: {3} PSI{1}" +
                                                    "     *{1}", 
                                                    m_ManufacturerName,
                                                    Environment.NewLine, 
                                                    r_MaximumAirPressure, 
                                                    m_CurrentAirPressure);
            return wheelInformation;
        }
    }
}
