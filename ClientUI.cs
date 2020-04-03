using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public static class ClientUI
    {
        public static Client GetNewClient()
        {
            clientDetailsLabel();
            return new Client(getClientName(), getClientPhoneNumber());
        }

        private static void clientDetailsLabel()
        {
            Console.WriteLine("{0}---------------", Environment.NewLine);
            Console.WriteLine("- Client Details");
            Console.WriteLine("---------------{0}", Environment.NewLine);
        }

        private static void clientNameInputMessage()
        {
            Console.Write("=> Inser Client Name: ");
        }

        private static void clientPhoneNumberInputMessage()
        {
            Console.Write("=> Inser Client Phone Number: ");
        }

        private static string getClientName()
        {
            clientNameInputMessage();
            string clientName = Console.ReadLine();
            try
            {
                checkClientNameValidation(clientName);
            }
            catch(FormatException ex)
            {
                Console.WriteLine(ex.Message);
                clientName = getClientName();
            }

            return clientName;
        }

        private static string getClientPhoneNumber()
        {
            clientPhoneNumberInputMessage();
            string clientPhoneNumber = Console.ReadLine();
            try
            {
                checkClientPhoneNumberValidation(clientPhoneNumber);
            }
            catch(FormatException ex)
            {
                Console.WriteLine(ex.Message);
                clientPhoneNumber = getClientPhoneNumber();
            }

            return clientPhoneNumber;
        }

        private static void checkClientNameValidation(string i_ClientName)
        {
            foreach(char letter in i_ClientName)
            {
                if(char.IsLetter(letter) == false && letter != ' ')
                {
                    throw new FormatException(string.Format("Bad Input Client Name Contain Only Letters {0}", Environment.NewLine));
                }
            }
        }

        private static void checkClientPhoneNumberValidation(string i_ClientPhonrNumber)
        {
            foreach(char letter in i_ClientPhonrNumber)
            {
                if(char.IsDigit(letter) == false)
                {
                    throw new FormatException(string.Format("Bad Input Client Phone Number Contain only Digits {0}", Environment.NewLine));
                }
            }

            if(i_ClientPhonrNumber.Length != InputInstructions.PhoneNumberLength)
            {
                throw new FormatException(string.Format("Bad Input Client Phone Number Contain {0} Digits {0}", InputInstructions.PhoneNumberLength, Environment.NewLine));
            }
        }
    }
}
