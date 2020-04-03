using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public static class CarUI 
    {
        public static Vehicle GetNewCar(
            ref Client i_Owner,
            Vehicle.VehicleType i_VehicleType, 
            string i_VehicleModel,
            string i_VehicleLicenseNumber, 
            ref EnergySystem i_VehicleEnergySystem,
            short i_WheelsNumber, 
            ref List<Wheel> i_VehicleWheels)
        {
            additionalCarInformationLabel();  
            return CreateNewVehicle.CreateNewCar(
                ref i_Owner,
                i_VehicleType, 
                i_VehicleModel, 
                i_VehicleLicenseNumber, 
                ref i_VehicleEnergySystem, 
                i_WheelsNumber, 
                ref i_VehicleWheels, 
                getCarColor(), 
                getCarDoors());
        }

        private static void additionalCarInformationLabel()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("------------------------------");
            Console.WriteLine("| Additional {0} Information |", Vehicle.VehicleType.Car);
            Console.WriteLine("------------------------------");
        }

        private static void carColorLabel()
        {
            Console.WriteLine("{0}------------", Environment.NewLine);
            Console.WriteLine("- Car Color");
            Console.WriteLine("------------{0}", Environment.NewLine);
        }

        private static void carDoorsLabel()
        {
            Console.WriteLine("{0}------------", Environment.NewLine);
            Console.WriteLine("- Car Doors");
            Console.WriteLine("------------{0}", Environment.NewLine);
        }

        private static void carColorInstructiontMessage()
        {
            Console.WriteLine("            *************** ");
            Console.WriteLine("            * (1) {0}", Car.CarColor.Yellow);
            Console.WriteLine("            * (2) {0}", Car.CarColor.White);
            Console.WriteLine("            * (3) {0}", Car.CarColor.Red);
            Console.WriteLine("            * (4) {0}", Car.CarColor.Black);
            Console.WriteLine("            ***************{0}", Environment.NewLine);
        }

        private static void carDoorsInstructionMessage()
        {
            Console.WriteLine("            *************** ");
            Console.WriteLine("            * (1) {0}", Car.CarDoors.Two);
            Console.WriteLine("            * (2) {0}", Car.CarDoors.Three);
            Console.WriteLine("            * (3) {0}", Car.CarDoors.Four);
            Console.WriteLine("            * (4) {0}", Car.CarDoors.Five);
            Console.WriteLine("            ***************{0}", Environment.NewLine);
        }

        private static void carColorInputMessage()
        {
            Console.Write("=> Select Car Color Option: ");
        }

        private static void carDoorInputMessage()
        {
            Console.Write("=> Select Doors Number Option: ");
        }

        private static Car.CarColor getCarColor()
        {
            Car.CarColor carColor = 0;
            carColorLabel();
            carColorInstructiontMessage();
            carColorInputMessage();
            string carColorString = Console.ReadLine();
            try
            {
                checkCarColor(carColorString, ref carColor);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                carColor = getCarColor();
            }

            return carColor;
        }

        private static Car.CarDoors getCarDoors()
        {
            Car.CarDoors carDoors = 0;
            carDoorsLabel();
            carDoorsInstructionMessage();
            carDoorInputMessage();
            string carDoorsStringFormat = Console.ReadLine();
            try
            {
                checkCarDoors(carDoorsStringFormat, ref carDoors);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                carDoors = getCarDoors();
            }

            return carDoors;
        }

        private static void checkCarColor(string i_CarColorStringFormat, ref Car.CarColor io_CarColor)
        {
            if(i_CarColorStringFormat != "1" && i_CarColorStringFormat != "2" 
                && i_CarColorStringFormat != "3" && i_CarColorStringFormat != "4")
            {
                throw new FormatException("Bad Input Chose one Number From (1-4)");
            }

            io_CarColor = (Car.CarColor)int.Parse(i_CarColorStringFormat);
        }

        private static void checkCarDoors(string i_CarDoorsStringFormat, ref Car.CarDoors io_CarDoors)
        {
            if (i_CarDoorsStringFormat != "1" && i_CarDoorsStringFormat != "2"
                && i_CarDoorsStringFormat != "3" && i_CarDoorsStringFormat != "4")
            {
                throw new FormatException("Bad Input Chose one Number From (1-4)");
            }

            io_CarDoors = (Car.CarDoors)(int.Parse(i_CarDoorsStringFormat) + 1);
        }
    }
}
