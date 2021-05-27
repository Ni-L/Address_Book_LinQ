﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookLinQ
{

     class AddressBookDataTable
    {
        //Creating DataTable for addressbook problem UC1
        DataTable dataTable = new DataTable();

        /// Create the Address Book table and add attributes.
        public DataTable CreateAddressBookTable()
        {
            dataTable.Columns.Add("FirstName", typeof(string));
            dataTable.Columns.Add("LastName", typeof(string));
            dataTable.Columns.Add("Address", typeof(string));
            dataTable.Columns.Add("City", typeof(string));
            dataTable.Columns.Add("State", typeof(string));
            dataTable.Columns.Add("ZipCode", typeof(int));
            dataTable.Columns.Add("PhoneNumber", typeof(long));
            dataTable.Columns.Add("Email", typeof(string));
            dataTable.Rows.Add("Nilima", "wadal", "akola", "navimumbai", "maharashtra", 400705, 9987932434, "nilima.com");
            dataTable.Rows.Add("Naina", "wadal", "mumbai", "navimumbai", "maharashtra", 400701, 9987932434, "naina@gmail.com");
            dataTable.Rows.Add("ritesh", "deshmukh", "thane", "navimumbai", "maharashtra", 400703, 9987932434, "ritesh@gmail.com");
            dataTable.Rows.Add("Shivam", "borole", "dombivli", "Mumbai", "maharashtra", 400710, 9987932434, "shivam@gmail.com");
            dataTable.Rows.Add("rahul", "sable", "hgt", "Mumbai", "maharashtra", 400703, 9987932434, "rahul@gmail.com");
            dataTable.Rows.Add("Aniket", "sable", " mum", "navimumbai", "maharashtra", 400701, 9987932434, "aniket@gmail.com");
            dataTable.Rows.Add("Snehal", "parde", "vashi", "navimumbai", "maharashtra", 400701, 9987932434, "snehal@gmail.com");
            // displayAddressBook();
            return dataTable;
        }

        public void DisplayAddressBook()
        {
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
        public void addContact(Contacts contact)
        {
            dataTable.Rows.Add(contact.FirstName, contact.LastName, contact.Address, contact.City,
            contact.State, contact.ZipCode, contact.PhoneNumber, contact.Email);
            Console.WriteLine("Added contact successfully");
        }

        public void editContact(DataTable dataTable)
        {
            var recordData = dataTable.AsEnumerable().Where(data => data.Field<string>("FirstName") == "Pratibha");
            foreach (var contact in recordData)
            {
                contact.SetField("LastName", "Karande");
                contact.SetField("Address", "Seawoods");
                Console.WriteLine("Updated contact");
                DisplayAddressBook();
            }
        }
    }

}