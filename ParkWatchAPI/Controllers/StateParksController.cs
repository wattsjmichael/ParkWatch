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
  public class StateParksController : ControllerBase
  {
    private ParkWatchApiContext _db;

    public StateParksController(ParkWatchApiContext db)
    {
      _db = db;
    }

    // GET api/stateparks
    [HttpGet]
    public ActionResult<IEnumerable<StatePark>> Get(string stateParkState, string stateParkCity, int? stateParkCampingSpots, bool? isOpenState )
    {
      var query = _db.StateParks.AsQueryable();
      if (stateParkState != null)
      {
        query = query.Where(entry => entry.StateParkState == stateParkState);
      }
      if (stateParkCity != null)
      {
        query = query.Where(entry => entry.StateParkCity == stateParkCity);
      }
      if (stateParkCampingSpots != null)
      {
        query = query.Where(entry => entry.StateParkCampingSpots == stateParkCampingSpots);
      }
      if (isOpenState != null)
      {
        query = query.Where(entry => entry.IsOpenState == isOpenState);
      }
      return query.ToList();
    }


    // POST api/stateparks
    [HttpPost]
    public void Post([FromBody] StatePark statePark)
    {
      _db.StateParks.Add(statePark);
      _db.SaveChanges();
    }

    //Get Api/stateparks/2
    [HttpGet("{id}")]
    public ActionResult<StatePark> Get(int id)
    {
      return _db.StateParks.FirstOrDefault(entry=>entry.StateParkId == id);
    }
    //PUT api/stateparks/2
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] StatePark statePark)
    {
      statePark.StateParkId = id;
      _db.Entry(statePark).State = EntityState.Modified;
      _db.SaveChanges();
    }

    //DELETE api/stateparks/3
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var stateParkToDelete = _db.StateParks.FirstOrDefault(entry=>entry.StateParkId == id);
      _db.StateParks.Remove(stateParkToDelete);
      _db.SaveChanges();
    }
    //Random api/stateparks/Random
    [HttpGet("random")]
    public ActionResult<StatePark> Get()
    {
      int count = _db.StateParks.Count();
      int index = new Random().Next(count);
      return _db.StateParks.Skip(index).FirstOrDefault();
    }
  }
}