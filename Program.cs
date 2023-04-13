using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    class Program
        {
            static void Main(string[] args)
            {
                bool ProgramIsRunning = true;
                AdressBook ab = StartProgram();

                Console.WriteLine("--------- AdressBook 1.0 ---------");

                while (ProgramIsRunning)
                {
                    // Print user options
                    PrintUserOptions();
                    var userInput = Console.ReadLine();

                    switch (userInput)
                    {
                        case "1":
                            ab.CreateUser();
                            break;
                        case "2":
                            ab.UpdateUserInformation();
                            break;
                        case "3":
                            ab.RemovePersonFromList();
                            break;
                        case "4":
                            ab.ShowAllPersonsInList();
                            break;
                        case "x":
                            ProgramIsRunning = false;
                            break;
                    }
                }
            }

            private static void PrintUserOptions()
            {
                Console.WriteLine("Choose one of the following options: ");
                Console.WriteLine("#1 Create new user");
                Console.WriteLine("#2 Edit user information");
                Console.WriteLine("#3 Delete existing user");
                Console.WriteLine("#4 Show all users in adressBook");
            }

            private static AdressBook StartProgram()
            {
                AdressBook ab = new AdressBook();

                //Start program by loading saved users from txt-file
                WriteAndReadToFile writer = new WriteAndReadToFile();
                writer.ReadFromFile(ab);
                return ab;
            }
        }

    }
    
