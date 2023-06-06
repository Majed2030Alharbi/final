using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using SQLite;

namespace The_final_test
{
    class UserOperations
    {
        private readonly string dbPath = Path.Combine(System.Environment.GetFolderPath(
            System.Environment.SpecialFolder.Personal), "FA2DB.dp3");

        public UserOperations()
        {
            //Creating database, if it doesn't already exist 
            if (!File.Exists(dbPath))
            {
                var db = new SQLiteConnection(dbPath);
                db.CreateTable<Address>();
                //  db.CreateTable<Students>();
                public Address GetAddressById(int id)
                {
                    var db = new SQLiteConnection(dbPath);

                    return db.Table<Address>().Where(i => i.Id == id).FirstOrDefault();
                }
                public void UpdateAddress(Address user)
                {
                    var db = new SQLiteConnection(dbPath);
                    db.Update(user);
                }
                public void DeleteUser(Address user)
                {
                    var db = new SQLiteConnection(dbPath);
                    db.Delete(user);
                }

                public Address GoAddress(string homenumber, string city )
                {
                    var db = new SQLiteConnection(dbPath);

                    return db.Table<Address>().Where(i => i.Homenumber == homenumber && i.City == city).FirstOrDefault();
                }
                public List<Address> GetAllAddress()
                {
                    var db = new SQLiteConnection(dbPath);
                    return db.Table<Address>().ToList();
                }
                public List<Address> SearchCity(string city)
                {
                    var db = new SQLiteConnection(dbPath);
                    return db.Table<Address>().Where(i => i.City == city).ToList();
                }

                [Table("Address")]
                public class Address
        {
            [PrimaryKey, AutoIncrement]   // , Column("_uid")
            public int Id { get; set; }
            public string Name { get; set; }
            public string Homenumber { get; set; }
            public string City { get; set; }
        }
    }
        }
    