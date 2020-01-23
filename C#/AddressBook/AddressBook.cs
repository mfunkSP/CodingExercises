using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAddressBook
{
    class AddressBook
    {
        List<AddressBookEntry> entries = new List<AddressBookEntry>();

        public AddressBook()
        {
            this.entries.Add(new AddressBookEntry());
            this.entries[0].FirstName = "John";
            this.entries[0].LastName = "Doe";
            this.entries[0].Address1 = "123 Main St";
            this.entries[0].City = "Anytown";
            this.entries[0].State = "US";
            this.entries[0].Zip = "12345";
            this.entries[0].PhoneNumber = "(555) 555-5555";
            this.entries[0].EmailAddress = "john.doe@company.com";

            this.entries.Add(new AddressBookEntry());
            this.entries[1].FirstName = "John";
            this.entries[1].LastName = "Smith";
            this.entries[1].Address1 = "88 Wall St";
            this.entries[1].City = "New York";
            this.entries[1].State = "NY";
            this.entries[1].Zip = "01125";
            this.entries[1].PhoneNumber = "(555) 555-5555";
            this.entries[1].EmailAddress = "john.smith@stock.com";

            this.entries.Add(new AddressBookEntry());
            this.entries[2].FirstName = "Jane";
            this.entries[2].LastName = "Doe";
            this.entries[2].Address1 = "12 North St";
            this.entries[2].City = "Northtown";
            this.entries[2].State = "ND";
            this.entries[2].Zip = "88653";
            this.entries[2].PhoneNumber = "(555) 555-5555";
            this.entries[2].EmailAddress = "jane.doe@mtrushmore.com";
        }
        public List<AddressBookEntry> Entries
        {
            get
            {
                return this.entries;
            }
        }
    }
}
