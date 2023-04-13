using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
            class WriteAndReadToFile
        {

            private readonly string UserTextFile = ConfigurationManager.AppSettings["textFileName"];

            public void WriteUserToFile(Person person)
            {
                using (StreamWriter sw = new StreamWriter(UserTextFile, true))
                {
                    sw.WriteLine(person.FirstName + "," + person.LastName + "," + person.Adress + ",");
                }
            }

            public void ReadFromFile(AdressBook ab)
            {
                string textLine;
                try
                {
                    using (StreamReader sr = new StreamReader(UserTextFile))
                    {
                        while ((textLine = sr.ReadLine()) != null)
                        {
                            string[] userInformation = textLine.Split(',');
                            Person p = new Person(userInformation[0], userInformation[1], userInformation[2]);
                            ab.AdressBookList.Add(p);
                        }
                    }
                }
                catch (FileNotFoundException fnf)
                {
                    Console.WriteLine("File does not exist " + fnf);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Something went wrong" + e);
                }
            }

            public void UpdateUserOnFile(List<Person> adressBookList)
            {
                // Remove old row
                using (StreamWriter sw = new StreamWriter(UserTextFile))
                {
                    sw.Flush();
                    foreach (var person in adressBookList)
                    {
                        sw.WriteLine(person.FirstName + "," + person.LastName + "," + person.Adress + ",");
                    }
                }
            }
        }
