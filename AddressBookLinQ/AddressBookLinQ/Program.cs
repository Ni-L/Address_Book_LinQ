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
           Contacts contact = new Contacts();
            //Console.WriteLine("Enter the City  ");
            //contact.City = Console.ReadLine();
            //addressBookDataTable.RetrieveContactByCity(contact);
            //Console.WriteLine("Enter the State");
            //contact.State = Console.ReadLine();
            //addressBookDataTable.GetCountByCityAndState(table);
            addressBookDataTable.GetSortedDataBasedOnPersonName(table);

            Console.Read();
        }
    }
}