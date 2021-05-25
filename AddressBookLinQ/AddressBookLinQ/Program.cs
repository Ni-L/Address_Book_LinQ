﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookLinQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----------WELCOME TO THE ADDRESSBOOK LINQ------------");        
            //Creating DataTable for addressbook problem UC1
            DataTable addressBookTable = new DataTable();

            //adding columns into address book table UC2
            DataColumn column;
            DataRow row;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "firstName";
            addressBookTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "lastName";
            addressBookTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "address";
            addressBookTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "city";
            addressBookTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "state";
            addressBookTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "zip";
            addressBookTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Double");
            column.ColumnName = "phoneNumber";
            addressBookTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "eMail";
            addressBookTable.Columns.Add(column);

            DataColumn[] PrimaryKeyColumns = new DataColumn[2];
            PrimaryKeyColumns[0] = addressBookTable.Columns["firstName"];
            PrimaryKeyColumns[1] = addressBookTable.Columns["phoneNumber"];
            addressBookTable.PrimaryKey = PrimaryKeyColumns;

            //Inserting data into columns into datatable UC3
            addressBookTable.Rows.Add("Nilima", "Wadal", "AtPost", "Akola", "Maharashtra", 444101, 8570934858, "nilima@gmail.com");
            addressBookTable.Rows.Add("Ritesh", "Patkar", "buldhana", "Amravti", "Karnataka", 125433, 9898989898, "Ritesh@gmail.com");
            addressBookTable.Rows.Add("Sne", "Gunde", "Andheri", "Mumbai", "Maharashtra", 125445, 9384782647, "Snehal@gmail.com");
            addressBookTable.Rows.Add("Aishwarya", "Yede", "hgt", "Hinghat", "Haryana", 222000, 9595959895, "aishwaray@gamil.com");
            addressBookTable.Rows.Add("Pravina", "Deshmukh", "amt", "Delhi", "Delhi", 435121, 99997898, "pravina@gmail.com");
            addressBookTable.Rows.Add("Vishal", "Bunde", "Andheri", "Mumbai", "Maharashtra", 8276737, 2345678900000, "vishal@gmail.com");
        }
    }
}
