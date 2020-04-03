namespace Ex03.GarageLogic
{
    public class Folder
    {
        private Client m_Client;
        private Vehicle m_Vehicle;

        public Folder(ref Client i_Client, ref Vehicle i_Vehicle)
        {
            this.m_Client = i_Client;
            this.m_Vehicle = i_Vehicle;
        }

        public Client FolderOwner
        {
            get { return this.m_Client; }
            set { this.m_Client = value; }
        }

        public Vehicle FolderSubject
        {
            get { return this.m_Vehicle; }
            set { this.m_Vehicle = value; }
        }
    }
}
