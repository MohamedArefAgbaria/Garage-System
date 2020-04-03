namespace Ex03.GarageLogic
{
    public abstract class EnergySystem
    {
        protected float m_CurrentEnergyStorage;
        protected float m_MaximumEnergyStorage;
        
        public EnergySystem(float i_CurrentEnergyStorage, float i_MaximumEnergyStorage)
        { 
            this.m_CurrentEnergyStorage = i_CurrentEnergyStorage;
            this.m_MaximumEnergyStorage = i_MaximumEnergyStorage;
        }

        public virtual void SupplyEnergy(float i_EnergyToSupply)
        {
        }

        public float CurrentEnergyStorage
        {
            get { return m_CurrentEnergyStorage; }
            set { this.m_CurrentEnergyStorage = value; }
        }

        public float MaximumEnergyStorage
        {
            get { return m_MaximumEnergyStorage; }
            set { this.m_MaximumEnergyStorage = value; }
        }
    }
}
