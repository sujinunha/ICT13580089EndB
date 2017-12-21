using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using ICT13580089EndB.Models;
using static ICT13580089EndB.Models.Cars;

namespace ICT13580568EndB.Helpers
{
	public class DbHelper
	{

		SQLiteConnection db;

		public DbHelper(string dbPath)
		{
			db = new SQLiteConnection(dbPath);
			db.CreateTable<Car>();
		}
		public int AddProduct(Car car)
		{
			db.Insert(car);
			return car.Id;
		}

		public List<Car> GetCars()
		{
			return db.Table<Car>().ToList();
		}
		public int UpdateProduct(Car car)
		{
			return db.Update(car);
		}
		public int DeleteProduct(Car car)
		{
			return db.Delete(car);
		}
	}
}