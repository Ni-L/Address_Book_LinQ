using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookLinQ
{
    class AddressBookDataTable
    {
        //Creating DataTable for addressbook proble
        DataTable dataTable = new DataTable();

        /// Create the Address Book table and add attributes.
        public DataTable CreateAddressBookTable()
        {
            //Adding Data to the Coloumn
            dataTable.Columns.Add("FirstName", typeof(string));
            dataTable.Columns.Add("LastName", typeof(string));
            dataTable.Columns.Add("Address", typeof(string));
            dataTable.Columns.Add("City", typeof(string));
            dataTable.Columns.Add("State", typeof(string));
            dataTable.Columns.Add("ZipCode", typeof(int));
            dataTable.Columns.Add("PhoneNumber", typeof(long));
            dataTable.Columns.Add("Email", typeof(string));
            //Adding data to the rows
            dataTable.Rows.Add("Nilima", "wadal", "atpost", "Akola", "maharashtra", 400705, 9987932434, "nilima.com");
            dataTable.Rows.Add("Naina", "wadal", "mumbai", "HYD", "Andra", 400701, 9987932434, "naina@gmail.com");
            dataTable.Rows.Add("ritesh", "deshmukh", "thane", "Pune", "up", 400703, 9987932434, "ritesh@gmail.com");
            dataTable.Rows.Add("Shivam", "borole", "dombivli", "Akot", "mp", 400710, 9987932434, "shivam@gmail.com");
            dataTable.Rows.Add("rahul", "sable", "hgt", "Mumbai", "goa", 400703, 9987932434, "rahul@gmail.com");
            dataTable.Rows.Add("Aniket", "sable", " mum", "Amravti", "vishrbh", 400701, 9987932434, "aniket@gmail.com");
            dataTable.Rows.Add("Snehal", "parde", "vashi", "Higanghat", "maharashtra", 400701, 9987932434, "snehal@gmail.com");
            // displayAddressBook();
            return dataTable;
        }

        public void DisplayAddressBook()//For displaying table
        {
            //Datarow represenst the data in row
            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine("\nFirstName:-" + row.Field<string>("FirstName"));
                Console.WriteLine("LastName:-" + row.Field<string>("LastName"));
                Console.WriteLine("Address:-" + row.Field<string>("Address"));
                Console.WriteLine("City:-" + row.Field<string>("City"));
                Console.WriteLine("State:-" + row.Field<string>("State"));
                Console.WriteLine("ZipCode:-" + row.Field<int>("ZipCode"));
                Console.WriteLine("PhoneNumber:-" + row.Field<long>("PhoneNumber"));
                Console.WriteLine("Email:-" + row.Field<string>("Email"));
            }
        }
        public void AddContact(Contacts contact)
        {
            //gets the row belongs to that table
            //Add create rows using by specified values and add in to the databelrow
            dataTable.Rows.Add(contact.FirstName, contact.LastName, contact.Address, contact.City,
            contact.State, contact.ZipCode, contact.PhoneNumber, contact.Email);
            Console.WriteLine("Added contact successfully");
        }

        public void EditContact(DataTable dataTable)//For Edit the contact
        {
            //Create 1 variable
            //AsEnumerabel for generic value T as a Datarow
            //where use for satisfy the condition or not
            //Query using lamda Expression
            var recordData = dataTable.AsEnumerable().Where(data => data.Field<string>("FirstName") == "Nilima");
            foreach (var contact in recordData)
            {
                contact.SetField("LastName", "Wadal");
                contact.SetField("Address", "akola");
                Console.WriteLine("Updated contact");
                DisplayAddressBook();
            }
        }
        public void DeleteParticularContact(Contacts input)
        {
            var recordData = dataTable.AsEnumerable().Where(data => data.Field<string>("FirstName") == input.FirstName).First();
            if (recordData != null)
            {
                recordData.Delete();
                Console.WriteLine("Delete contact successfully");
                DisplayAddressBook();

            }
            Console.WriteLine("Contact not present");
        }

        //Ability to Retrieve Person belonging to a State from the Address Book
        public void RetrieveContactByState(Contacts contact)
        {
            var records = from dataTable in dataTable.AsEnumerable().Where(dataTable => dataTable.Field<string>("State") == contact.State) select dataTable;
            foreach (var record in records.AsEnumerable())
            {
                Console.WriteLine("\nFirstName:-" + record.Field<string>("FirstName"));
                Console.WriteLine("LastName:-" + record.Field<string>("LastName"));
                Console.WriteLine("Address:-" + record.Field<string>("Address"));
                Console.WriteLine("City:-" + record.Field<string>("City"));
                Console.WriteLine("State:-" + record.Field<string>("State"));
                Console.WriteLine("ZipCode:-" + record.Field<int>("ZipCode"));
                Console.WriteLine("PhoneNumber:-" + record.Field<long>("PhoneNumber"));
                Console.WriteLine("Email:-" + record.Field<string>("Email"));
                DisplayAddressBook();

            }
        }

        //Ability to Retrieve Person belonging to a State from the Address Book
        public void RetrieveContactByCity(Contacts contact)
        {
            var records = from dataTable in dataTable.AsEnumerable().Where(dataTable => dataTable.Field<string>("City") == contact.City) select dataTable;
            foreach (var record in records.AsEnumerable())
            {
                Console.WriteLine("\nFirstName:-" + record.Field<string>("FirstName"));
                Console.WriteLine("LastName:-" + record.Field<string>("LastName"));
                Console.WriteLine("Address:-" + record.Field<string>("Address"));
                Console.WriteLine("City:-" + record.Field<string>("City"));
                Console.WriteLine("State:-" + record.Field<string>("State"));
                Console.WriteLine("ZipCode:-" + record.Field<int>("ZipCode"));
                Console.WriteLine("PhoneNumber:-" + record.Field<long>("PhoneNumber"));
                Console.WriteLine("Email:-" + record.Field<string>("Email"));
                DisplayAddressBook();

            }
        }
        public void GetCountByCityAndState(DataTable datatable)
        {
            //getting count for particular state or city
            var recordData = datatable.AsEnumerable().Where(r => r.Field<string>("city") == "Mumbai" && r.Field<string>("state") == "Maharashtra").Count();
            //grouping data by city and state
            var recordedData = from data in datatable.AsEnumerable()
                               group data by new { city = data.Field<string>("city"), state = data.Field<string>("state") } into g
                               select new { city = g.Key, count = g.Count() };
            //displaying data for particular city or state
            Console.WriteLine(recordData);
            //displaying total grouped data
            foreach (var data in recordedData.AsEnumerable())
            {
                Console.WriteLine("city:- " + data.city.city);
                Console.WriteLine("state:- " + data.city.state);
                Console.WriteLine("lastName:- " + data.count);
                Console.WriteLine("*******************");
            }

        }
        //Adding GetSortedDataBasedOnPersonName
        public void GetSortedDataBasedOnPersonName(DataTable datatable)
        {
            var recordData = datatable.AsEnumerable().Where(r => r.Field<string>("city") == "Mumbai").OrderBy(r => r.Field<string>("firstName")).ThenBy(r => r.Field<string>("lastName"));
            foreach (var record in recordData)
            {
                Console.WriteLine("\nFirstName:-" + record.Field<string>("FirstName"));
                Console.WriteLine("LastName:-" + record.Field<string>("LastName"));
                Console.WriteLine("Address:-" + record.Field<string>("Address"));
                Console.WriteLine("City:-" + record.Field<string>("City"));
                Console.WriteLine("State:-" + record.Field<string>("State"));
                Console.WriteLine("ZipCode:-" + record.Field<int>("ZipCode"));
                Console.WriteLine("PhoneNumber:-" + record.Field<long>("PhoneNumber"));
                Console.WriteLine("Email:-" + record.Field<string>("Email"));
                DisplayAddressBook();
            }
        }
        //Added GetCounttype method
        public void GetCountByType(DataTable dataTable)
        {
            //
            var recordData = dataTable.AsEnumerable().GroupBy(r => r.Field<string>("type")).Select(r => new { type = r.Key, count = r.Count() });
            foreach (var data in recordData)
            {
                Console.WriteLine("Type-" + data.type);
                Console.WriteLine("Count for type- " + data.count);
            }
        }
    }

}