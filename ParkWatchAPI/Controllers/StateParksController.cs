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
    public ActionResult<IEnumerable<StatePark>> Get()
    {
      return _db.StateParks.ToList();
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
  }
}