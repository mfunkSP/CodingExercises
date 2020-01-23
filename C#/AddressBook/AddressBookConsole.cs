using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace ConsoleAddressBook
{
    class AddressBookConsole
    {
        AddressBook addressBook = new AddressBook();
        public void StartConsole()
        {
            Console.WriteLine("Welcome to the Address Book Console Manager.");
            ConsoleKey key;
            while ((key = DisplayMenu()) != ConsoleKey.Q)
            {
                if (key != ConsoleKey.M)
                {
                    switch (key)
                    {
                        case ConsoleKey.A:
                            AddNewEntry();
                            break;
                        case ConsoleKey.D:
                            DeleteEntry();
                            break;
                        case ConsoleKey.E:
                            EditEntry();
                            break;
                        case ConsoleKey.F:
                            FindEntry();
                            break;
                        case ConsoleKey.L:
                            ListAllEntries();
                            break;
                        default:
                            //TODO: Implement a default behavior when an invalid key is pressed.
                            throw new InvalidOperationException("Input key is not valid for this application.");
                    }
                }
                Console.WriteLine(Environment.NewLine);
            }
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Goodbye!");
        }
        private ConsoleKey DisplayMenu()
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Please select from the following options: ");
            Console.WriteLine("(A)dd new entry.");
            Console.WriteLine("(D)elete an existing entry.");
            Console.WriteLine("(E)dit an existing entry.");
            Console.WriteLine("(F)ind an entry.");
            Console.WriteLine("(L)ist all entries.");
            Console.WriteLine("(M)ain menu. This menu.");
            Console.WriteLine("(Q)uit application.");
            Console.Write("Selection: ");
			ConsoleKeyInfo keyinfo;
			keyinfo = Console.ReadKey();
            return keyinfo.Key;
        }
        private void AddNewEntry()
        {
            do
            {
                Console.WriteLine(Environment.NewLine);
                var entry = new AddressBookEntry();
                SetEntryDetails(entry);
                this.addressBook.Entries.Add(entry);
                Console.WriteLine(entry.ToString() + " was added successfully.");
                Console.Write("Do you want to add another entry (y/N)?: ");
            } 
            while (Console.ReadKey().Key == ConsoleKey.Y);
        }
        
        private void EditEntry()
        {
            //TODO: Implement entry editing.
            throw new NotImplementedException();
        }
        private void DeleteEntry()
        {
            do
            {
                Console.WriteLine(Environment.NewLine);
                for (int index = 0; index < this.addressBook.Entries.Count; index++)
                {
                    var entry = this.addressBook.Entries[index];
                    Console.WriteLine("({0}) {1}", index, entry);
                }
                var selection = ConsoleHelperMethods.PromptForNumericInput("Please select an entry to delete: ");
                this.addressBook.Entries.RemoveAt(selection);
                Console.Write("Do you want to delete another entry (y/N)?: ");
            } 
            while (Console.ReadKey().Key == ConsoleKey.Y);
        }
        private void SetEntryDetails(AddressBookEntry entry)
        {
            entry.FirstName = ConsoleHelperMethods.PromptForInput("Please enter the", "first name");
            entry.LastName = ConsoleHelperMethods.PromptForInput("Please enter the", "last name");
            entry.Address1 = ConsoleHelperMethods.PromptForInput("Please enter", "address line 1");
            entry.Address2 = ConsoleHelperMethods.PromptForInput("Please enter", "address line 2", true);
            entry.City = ConsoleHelperMethods.PromptForInput("Please enter the", "city");
            entry.State = ConsoleHelperMethods.PromptForInput("Please enter the", "state");
            entry.Zip = ConsoleHelperMethods.PromptForInput("Please enter the", "zip code");
            //TODO: Implement formatting phone number input so it's always (###) ###-####.
            entry.PhoneNumber = ConsoleHelperMethods.PromptForInput("Please enter the", "phone number");
            entry.EmailAddress = ConsoleHelperMethods.PromptForInput("Please enter the", "email address");
        }
        private void FindEntry()
        {
            do
            {
                Console.WriteLine(Environment.NewLine);
                Console.Write("Please enter a last name to search with: ");
                var input = Console.ReadLine();
                var matches = this.addressBook.Entries.FindAll(match => match.FirstName == input);
                foreach (var entry in matches)
                {
                    ListFullEntry(entry);
                }
                Console.WriteLine("Found ({0}) matches.", matches.Count);
                Console.Write("Do you want to search for more entries (y/N)?: ");

            }
            while (Console.ReadKey().Key == ConsoleKey.Y);
        }
        private void ListAllEntries()
        {
            Console.WriteLine(Environment.NewLine);
            for (int index = 0; index <= this.addressBook.Entries.Count; index++)
            {
                ListFullEntry(this.addressBook.Entries[index]);
            }
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("{0} entries listed.", this.addressBook.Entries.Count);
        }
        private void ListFullEntry(AddressBookEntry entry)
        {
            Console.WriteLine();
            Console.WriteLine("Name: {0}", entry.ToString());
            Console.WriteLine("Address 1: {0}", entry.Address1);
            Console.WriteLine("Address 2: {0}", entry.Address2);
            Console.WriteLine("City: {0}, {2}, {1}", entry.City, entry.State, entry.Zip);
            Console.WriteLine("Phone: {0}", entry.PhoneNumber);
            Console.WriteLine("Email: {0}", entry.EmailAddress);
        }
    }
}
