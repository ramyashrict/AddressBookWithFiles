using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
   class AddressBookDetails
 
{
    private WriteAndReadToFile wtf;
    private List<Person> adressBookList = new List<Person>();
    public List<Person> AdressBookList
    {
        get { return adressBookList; }
        set { this.adressBookList = value; }
    }


    public AdressBook()
    {
        AdressBookList = new List<Person>();
        wtf = new WriteAndReadToFile();
    }

    // Create instance of Person-class and call AddPersonToList-method
    public void CreateUser()
    {
        Console.WriteLine("Enter firstName:");
        var firstName = Console.ReadLine();

        Console.WriteLine("Enter lastName:");
        var lastName = Console.ReadLine();

        Console.WriteLine("Enter adress:");
        var adress = Console.ReadLine();

        Person person = new Person(firstName, lastName, adress);
        AddPersonToList(person);
        wtf.WriteUserToFile(person);

    }

    // Add new person to AdressBookList
    private void AddPersonToList(Person person) => AdressBookList.Add(person);

    //Remove user from list where first and last name match
    public void RemovePersonFromList()
    {
        Console.WriteLine("Enter firstName of the user you want to remove");
        var firstName = Console.ReadLine();

        Console.WriteLine("Enter lastname of the user you want to remove");
        var lastName = Console.ReadLine();

        AdressBookList.RemoveAll(item => item.FirstName == firstName && item.LastName == lastName);
        wtf.UpdateUserOnFile(adressBookList);
    }

    //Show all Persons in AdressBookList
    public void ShowAllPersonsInList()
    {
        foreach (var person in AdressBookList)
        {
            Console.WriteLine("FirstName: {0}, LastName: {1}, Adress: {2}", person.FirstName, person.LastName, person.Adress);
        }
    }

    public void UpdateUserInformation()
    {
        Console.WriteLine("Which information do you want to update?");
        Console.WriteLine("#1: Firstname, #2: Lastname, 3# Adress");
        var userOption = Console.ReadLine();

        Console.WriteLine("Enter firstname on existing user to be updated");
        var oldFirstName = Console.ReadLine();
        UpdateUserFunction(userOption, oldFirstName);
    }

    private void UpdateUserFunction(string userOption, string oldFirstName)
    {
        var personsWithMatchingFirstName = AdressBookList.Where(person => person.FirstName == oldFirstName);
        string newValue;

        if (userOption == "1")
        {
            Console.WriteLine("Enter a new first Name");
            newValue = Console.ReadLine();

            foreach (var person in personsWithMatchingFirstName)
            {
                person.FirstName = newValue;
                wtf.UpdateUserOnFile(adressBookList);
            }
        }
        else if (userOption == "2")
        {
            Console.WriteLine("Enter a new last name");
            newValue = Console.ReadLine();

            foreach (var person in personsWithMatchingFirstName)
            {
                person.LastName = newValue;
                wtf.UpdateUserOnFile(adressBookList);
            }
        }
        else if (userOption == "3")
        {
            Console.WriteLine("Enter a new adress");
            newValue = Console.ReadLine();

            foreach (var person in personsWithMatchingFirstName)
            {
                person.Adress = newValue;
                wtf.UpdateUserOnFile(adressBookList);
            }
        }
    }
