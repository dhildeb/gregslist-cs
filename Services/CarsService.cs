using System;
using System.Collections.Generic;
using gregslist_cs.Data;
using gregslist_cs.Models;

namespace gregslist_cs.Services
{
  public class CarsService
  {
    public List<Car> GetAllCars()
    {
      return FakeDb.Cars;
    }
    public Car GetCarById(int id)
    {
      return FakeDb.Cars.Find(c => c.id == id);
    }

    public Car CreateCar(Car carData)
    {
      var r = new Random();
      carData.id = r.Next(100000, 999999);
      FakeDb.Cars.Add(carData);
      return carData;
    }
    // public Car EditCar(Car carData, int id)
    // {
    //   var car = FakeDb.Cars.Find(c => c.id == id);
    //   FakeDb.Cars.Remove(car);
    //   FakeDb.Cars.Add(carData);
    //   return carData;
    // }


    public Car DeleteCar(int id)
    {
      Car car = FakeDb.Cars.Find(c => c.id == id);
      if (car == null)
      {
        throw new Exception("Invalid Id");
      }
      FakeDb.Cars.Remove(car);
      return car;
    }

  }
}