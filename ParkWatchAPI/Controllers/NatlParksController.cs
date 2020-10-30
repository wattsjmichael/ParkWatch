using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ParkWatchApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ParkWatchApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class NatlParksController : ControllerBase
  {
    private ParkWatchApiContext _db;

    public NatlParksController(ParkWatchApiContext db)
    {
      _db = db;
    }

    // GET api/NatlParks
    [HttpGet]
    public ActionResult<IEnumerable<NatlPark>> Get(string natlParkState, string natlParkCity, int? natlParkCampingSpots, bool? isOpenNatl )
    {
      var query = _db.NatlParks.AsQueryable();
      if (natlParkState != null)
      {
        query = query.Where(entry => entry.NatlParkState == natlParkState);
      }
      if (natlParkCity != null)
      {
        query = query.Where(entry => entry.NatlParkCity == natlParkCity);
      }
      if (natlParkCampingSpots != null)
      {
        query = query.Where(entry => entry.NatlParkCampingSpots == natlParkCampingSpots);
      }
      if (isOpenNatl != null)
      {
        query = query.Where(entry => entry.IsOpenNatl == isOpenNatl);
      }
      return query.ToList();
    }

    // POST api/natlparks
    [HttpPost]
    public void Post([FromBody] NatlPark natlPark)
    {
      _db.NatlParks.Add(natlPark);
      _db.SaveChanges();
    }

    //GET by Id Api/natlparks/2
    [HttpGet("{id}")]
    public ActionResult<NatlPark> Get(int id)
    {
      return _db.NatlParks.FirstOrDefault(entry => entry.NatlParkId == id);
    }

    //PUT api/natlparks/3
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] NatlPark natlPark)
    {
      natlPark.NatlParkId = id;
      _db.Entry(natlPark).State = EntityState.Modified;
      _db.SaveChanges();
    }

    //Delete api/natlparks/2
    public void Delete(int id)
    {
      var natlParkToDelete = _db.NatlParks.FirstOrDefault(entry => entry.NatlParkId == id);
      _db.NatlParks.Remove(natlParkToDelete);
      _db.SaveChanges();
    }

    //Get api/natlparks/random
    [HttpGet("random")]
    public ActionResult<NatlPark> Get()
    {
    int count = _db.NatlParks.Count();
    int index = new Random().Next(count);
    return _db.NatlParks.Skip(index).FirstOrDefault();
    }
  }
}