using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public static class Program
    {
        public static void Main()
        {
            Garage newGarage = GarageMangerUI.CreateNewGarage();
            GarageMangerUI.StartGarageWorking(ref newGarage);
        }
    }
}
