using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLotDAL.EF;
using AutoLotDAL.Models;
using AutoLotDAL.Repos;



namespace AutoLotTestDrive
{
    class Program
    {
        static void Main(string[] args)
        {
          //  Database.SetInitializer(new MyDataInitializer());
            //Console.WriteLine("*****Fun with ADO.NET EF Code First * ****\n");
            //using (var context = new AutoLotEntities())
            //{
            //    foreach (Test t in context.Cars)
            //        Console.WriteLine(t);
            //}
            Console.WriteLine("***** Using a Repository *****\n");
            using (var repo = new InventoryRepo())
            {
                foreach (Test t in repo.GetAll())
                    Console.WriteLine(t);

            }

        }

        private static void AddNewRecord (Test car)
        {
            using (var repo = new InventoryRepo())
            {
                repo.Add(car);
            }
        }

        private static void UpdateRecord (int carID)
        {
            using (var repo = new InventoryRepo())
            {
                var cartoupdate = repo.GetOne(carID);
                if (cartoupdate == null)
                    return;
                cartoupdate.Color = "Blue";
                repo.Save(cartoupdate);
            }
        }

        private static void RemoveRecordCar(Test carDelete)
        {
            using (var repo = new InventoryRepo())
            {
                repo.Delete(carDelete);
            }
        }

        private static void RemoveRecordById(int carID, byte [] timeStamp)
        {
            using (var repo = new InventoryRepo())
            {
                repo.Delete(carID, timeStamp);
            }
        }
    }
}
