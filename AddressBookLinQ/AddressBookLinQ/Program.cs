using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookLinQ
{
    class Program

    {
        public DataTable addressBookTable = new DataTable();
        static void Main(string[] args)
        {
            Console.WriteLine("***************Welcome To AddressBook Using Linq*************");
            AddressBookDataTable addressBookDataTable = new AddressBookDataTable();
            DataTable table = addressBookDataTable.CreateAddressBookTable();
            addressBookDataTable.editContact(table);

            Console.Read();
        }
    }
}