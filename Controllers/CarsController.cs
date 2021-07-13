using System.Collections.Generic;
using gregslist_cs.Models;
using gregslist_cs.Services;
using Microsoft.AspNetCore.Mvc;

namespace gregslist_cs.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CarsController : ControllerBase
  {

    private readonly CarsService _cs;
    public CarsController(CarsService cs)
    {
      _cs = cs;
    }

    [HttpGet]
    public List<Car> GetAllCars()
    {
      return _cs.GetAllCars();
    }

    [HttpGet("{id}")]
    public ActionResult<Car> GetCarById(int id)
    {
      try
      {
        var car = _cs.GetCarById(id);
        if (car == null)
        {
          return BadRequest("Invalid Id");
        }
        return car;
      }
      catch (System.Exception e)
      {
        return Forbid(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<Car> CreateCar([FromBody] Car carData)
    {
      try
      {
        var car = _cs.CreateCar(carData);
        return Created("api/cars/" + car.id, car);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // [HttpPut("{id}")]
    // public ActionResult<Car> EditCar([FromBody] Car carData, int id)
    // {
    //   try
    //   {
    //     var car = _cs.EditCar(carData, id);
    //     if (car == null)
    //     {
    //       return Unauthorized("not authorized");
    //     }
    //     return Ok(car);
    //   }
    //   catch (System.Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }

    [HttpDelete("{id}")]
    public ActionResult<Car> DeleteCar(int id)
    {
      try
      {
        var car = _cs.DeleteCar(id);
        return Ok(car);
      }
      catch (System.Exception e)
      {
        return Forbid(e.Message);
      }
    }
  }
}