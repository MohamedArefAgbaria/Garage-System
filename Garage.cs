using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, Folder> m_DataBase;

        public Garage()
        {
            m_DataBase = new Dictionary<string, Folder>();
        }

        public Dictionary<string, Folder> GarageDataBase
        {
            get { return this.m_DataBase; }
        }

        public bool IsEmpty()
        {
            return m_DataBase.Count == 0;
        }

        public bool IsVehicleFoundInGarage(string i_LicenseNumber)
        {
            return m_DataBase.ContainsKey(i_LicenseNumber);
        }
    }
}
