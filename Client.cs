namespace Ex03.GarageLogic
{
    public class Client
    {
        private string m_Name;
        private string m_PhoneNumber;

        public Client(string i_Name, string i_PhoneNumner)
        {
            this.m_Name = i_Name;
            this.m_PhoneNumber = i_PhoneNumner;
        }

        public string Name
        {
            get { return this.m_Name; }
            set { this.m_Name = value; }
        }

        public string PhoneNumber
        {
            get { return this.m_PhoneNumber; }
            set { this.m_PhoneNumber = value; }
        }
    }
}
